using Orleans.Services;

namespace TestApp
{
    public interface IEchoClient : IGrainServiceClient<IEchoService>, IEchoService
    { }
}
