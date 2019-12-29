using Orleans;
using System.Threading.Tasks;

namespace TestApp
{
    public interface ISomeGrain : IGrainWithIntegerKey
    {
        Task<string> Echo(string message);
        Task<bool> IsGrainServiceValid();
    }
}
