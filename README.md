
Orleans issue [#5822](https://github.com/dotnet/orleans/issues/5822)

Grain Service docs [here](http://dotnet.github.io/orleans/Documentation/grains/grainservices.html)

```
Starting TestApp.EchoService grain service on: S127.0.0.1:11111:315317634 x35992C52, with range <MultiRange: Size=x100000000, %Ring=100.000%>

Getting IEchoClient reference.

Calling IEchoClient.IsGrainServiceValid.

System.NullReferenceException: Object reference not set to an instance of an object.
   at Orleans.Runtime.Services.GrainServiceClient`1.MapGrainReferenceToSiloRing(GrainReference grainRef)
   at Orleans.Runtime.Services.GrainServiceClient`1.get_GrainService()
   at TestApp.EchoClient.IsGrainServiceValid() in C:\Source\OrleansGrainServiceTest\TestApp\EchoClient.cs:line 17
   at TestApp.Program.Main(String[] args) in C:\Source\OrleansGrainServiceTest\TestApp\Program.cs:line 59
```
