using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Services;
using Microsoft.Extensions.Logging;
using Model;
using Moq;
using static TestUtils.DataManagers;


namespace UT_GrpcService;

public static class GrpcUtils
{
    public static ServerCallContext CreateCallContext() 
        => new Mock<ServerCallContext>().Object;
    
    public static Manager CreateManager() 
        => new(Loaders[1].Get(), Writers[0].Get());
    
    public static ILogger<T> CreateLogger<T>() 
        => new Mock<ILogger<T>>().Object;
    
    public static Timestamp ToTimestamp(this DateTime dateTime)
        =>Timestamp.FromDateTime(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
}
