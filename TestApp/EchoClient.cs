using Orleans.Runtime.Services;
using System;
using System.Threading.Tasks;

namespace TestApp
{
    public class EchoClient : GrainServiceClient<IEchoService>, IEchoClient
    {
        public EchoClient(IServiceProvider services)
            : base(services) 
        { }

        public Task<string> Echo(string message)
            => GrainService.Echo(message);
    }
}
