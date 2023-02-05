using Grpc.Core;
using GrpcService;
using GrpcService.Services;
using Xunit;
using static UT_GrpcService.GrpcUtils;

namespace UT_GrpcService;

public class UT_HandServiceV1
{
    [Fact]
    public void ConstructorTest()
    {
        var service = new HandServiceV1(CreateManager(), CreateLogger<HandServiceV1>());

        Assert.NotNull(service);
    }

    #region Reader
    
    [Theory]
    [MemberData(nameof(HandServiceDataV1.Data_TestGetHandById), MemberType = typeof(HandServiceDataV1))]
    public async Task TestGetHandById(ulong id, HandReply? expected)
    {
        var service = new HandServiceV1(CreateManager(), CreateLogger<HandServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.GetHandById(new IdRequest {Id = id}, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"Hand with id {id} not found", error.Status.Detail);
            
            return;
        }

        var actual = await service.GetHandById(new IdRequest {Id = id}, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    #endregion
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(HandServiceDataV1.InsertHandData), MemberType = typeof(HandServiceDataV1))]
    public async Task TestInsertHand(HandInsertRequest request, HandReply? expected, int failReason)
    {
        var service = new HandServiceV1(CreateManager(), CreateLogger<HandServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.InsertHand(request, CreateCallContext()));
            Assert.Equal(StatusCode.InvalidArgument, error.StatusCode);
            
            switch (failReason)
            {
                case 1:
                    Assert.Equal($"User with id {request.Biddings[0].PlayerId} not found, hand cannot be inserted", error.Status.Detail);
                    break;
                case 2:
                    Assert.Equal($"Rules {request.Rules} does not correspond to any rules, hand cannot be inserted", error.Status.Detail);
                    break;
                case 3:
                    Assert.Equal($"Game with id {request.GameId} not found, hand cannot be inserted", error.Status.Detail);
                    break;
            }
            return;
        }

        var actual = await service.InsertHand(request, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    #endregion
}
