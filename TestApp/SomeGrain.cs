using Orleans;
using System.Threading.Tasks;

namespace TestApp
{
    public class SomeGrain : Grain, ISomeGrain
    {
        private readonly IEchoClient echoClient;

        public SomeGrain(IEchoClient echoClient)
        {
            this.echoClient = echoClient;
        }

        public Task<string> Echo(string message)
            => echoClient.Echo(message);

        public Task<bool> IsGrainServiceValid()
            => echoClient.IsGrainServiceValid();

        // https://github.com/dotnet/orleans/blob/master/src/Orleans.Runtime/Services/GrainServiceClient.cs#L45
        // https://github.com/dotnet/orleans/blob/master/src/Orleans.Runtime/Services/GrainServiceClient.cs#L56
        // CallingGrainReference => (RuntimeContext.Current?.ActivationContext as SchedulingContext)?.Activation?.GrainReference;
    }
}
