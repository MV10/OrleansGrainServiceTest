using Orleans.Services;
using System.Threading.Tasks;

namespace TestApp
{
    public interface IEchoClient : IGrainServiceClient<IEchoService>, IEchoService
    { }
}
