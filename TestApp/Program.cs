using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHost ihost = null;
            try
            {
                var host = Host.CreateDefaultBuilder(args);

                host.ConfigureLogging(builder =>
                {
                    builder
                    .AddFilter("Microsoft", LogLevel.Warning)   // generic host lifecycle messages
                    .AddFilter("Orleans", LogLevel.Warning)     // suppress status dumps
                    .AddFilter("Runtime", LogLevel.Warning)     // also an Orleans prefix
                    .AddDebug()
                    .AddConsole();
                });

                host.UseOrleans(builder =>
                {
                    builder.UseLocalhostClustering();
                    builder.Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback);
                    builder.ConfigureApplicationParts(parts =>
                    {
                        parts.AddApplicationPart(typeof(EchoService).Assembly).WithReferences();
                        parts.AddApplicationPart(typeof(EchoClient).Assembly).WithReferences();
                    });
                    builder.AddGrainService<EchoService>();
                });

                host.ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddSingleton<IEchoClient, EchoClient>();
                });

                ihost = host.Build();
                await ihost.StartAsync();

                Console.WriteLine("\nGetting IEchoClient reference.");
                var echoClient = ihost.Services.GetRequiredService<IEchoClient>();
                if (echoClient is null) throw new Exception("IEchoClient is null");

                Console.WriteLine("\nCalling IEchoClient.IsGrainServiceValid.");
                var valid = await echoClient.IsGrainServiceValid();
                Console.WriteLine($"Result: {valid}");

                Console.WriteLine("\nCalling IEchoClient.Echo.");
                string message = "test";
                var result = await echoClient.Echo(message);
                if (string.IsNullOrWhiteSpace(result) || !result.Equals(message)) throw new Exception($"Result: {result}");

                Console.WriteLine("\nTest successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}");
            }
            finally
            {
                await ihost?.StopAsync();
                ihost?.Dispose();
            }

            if (!Debugger.IsAttached)
            {
                Console.WriteLine("\n\nPress any key to exit.");
                Console.ReadKey(true);
            }
        }
    }
}