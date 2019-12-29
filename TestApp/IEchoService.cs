using Orleans.Services;
using System.Threading.Tasks;

namespace TestApp
{
    public interface IEchoService : IGrainService
    {
        Task<string> Echo(string message);
    }
}
