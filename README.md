
Orleans issue [#5822](https://github.com/dotnet/orleans/issues/5822)

Grain Service docs [here](http://dotnet.github.io/orleans/Documentation/grains/grainservices.html)

```
info: TestApp.EchoService[102925]
      Starting TestApp.EchoService grain service on: S127.0.0.1:11111:315316677 xFF35EACC, with range <MultiRange: Size=x100000000, %Ring=100.000%>
System.NullReferenceException: Object reference not set to an instance of an object.
   at Orleans.Runtime.Services.GrainServiceClient`1.MapGrainReferenceToSiloRing(GrainReference grainRef)
   at Orleans.Runtime.Services.GrainServiceClient`1.get_GrainService()
   at TestApp.EchoClient.Echo(String message) in C:\Source\OrleansGrainServiceTest\TestApp\EchoClient.cs:line 14
   at TestApp.Program.Main(String[] args) in C:\Source\OrleansGrainServiceTest\TestApp\Program.cs:line 58
info: TestApp.EchoService[102927]
      Stopping TestApp.EchoService grain service
```
