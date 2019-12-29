using Microsoft.Extensions.Logging;
using Orleans.Concurrency;
using Orleans.Core;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace TestApp
{
    [Reentrant]
    public class EchoService : GrainService, IEchoService
    {
        // ctor requirements not documented (except in confusing LightStream example)
        // and no error shown until runtime
        public EchoService(IGrainIdentity id, Silo silo, ILoggerFactory loggerFactory)
            : base(id, silo, loggerFactory) 
        { }

        public override Task Init(IServiceProvider serviceProvider)
            => base.Init(serviceProvider);

        public override async Task Start()
            => await base.Start();

        public override Task Stop()
            => base.Stop();

        public Task<string> Echo(string message)
            => Task.FromResult(message);
    }
}
