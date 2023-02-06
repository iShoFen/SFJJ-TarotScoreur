using Grpc.Core;
using GrpcService;
using GrpcService.Services;
using Xunit;
using static UT_GrpcService.GrpcUtils;

namespace UT_GrpcService;

public class UT_GameServiceV1
{
    [Fact]
    public void ConstructorTest()
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        Assert.NotNull(service);
    }

    #region Reader

    [Theory]
    [MemberData(nameof(GameServiceDataV1.Data_TestGetGames), MemberType = typeof(GameServiceDataV1))]
    public async Task TestGetGames(int page, int pageSize, GamesReply expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        var actual = await service.GetGames(new Pagination
                                            {
                                                Page = page,
                                                PageSize = pageSize
                                            },
                                            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GameServiceDataV1.Data_TestGetGameByPlayer), MemberType = typeof(GameServiceDataV1))]
    public async Task TestGetGameByPlayer(ulong playerId, int page, int pageSize, GamesReply expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        var actual = await service.GetGamesByPlayer(
            new GamePlayerRequest
            {
                PlayerId = playerId,
                Pagination = new Pagination
                {
                    Page = page,
                    PageSize = pageSize
                }
            },
            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GameServiceDataV1.GetGameByName), MemberType = typeof(GameServiceDataV1))]
    public async Task TestGetGameByName(string name, int page, int pageSize, GamesReply expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        var actual = await service.GetGamesByName(
            new GamePatternRequest
            {
                Pattern = name,
                Pagination = new Pagination
                {
                    Page = page,
                    PageSize = pageSize
                }
            },
            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GameServiceDataV1.Data_TestGetGameByDate), MemberType = typeof(GameServiceDataV1))]
    public async Task TestGetGameByDate(DateTime startDate, DateTime? endDate, int page, int pageSize, GamesReply expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        var actual = await service.GetGamesByDate(
            new GameDateRequest
            {
                StartDate = startDate.ToTimestamp(),
                EndDate = endDate?.ToTimestamp(),
                Pagination = new Pagination
                {
                    Page = page,
                    PageSize = pageSize
                }
            },
            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GameServiceDataV1.Data_TestGetGameById), MemberType = typeof(GameServiceDataV1))]
    public async Task TestGetGameById(ulong id, GameReplyDetails? expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        if (expected is null)
        { 
            var error = await Assert.ThrowsAsync<RpcException>(async () => await service.GetGame(
                new IdRequest
                {
                    Id = id
                },
                CreateCallContext()
            ));
            
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"Game with id {id} not found", error.Status.Detail);
            
            return;
        }

        var actual = await service.GetGame(
            new IdRequest
            {
                Id = id
            },
            CreateCallContext()
        );
        
        Assert.Equal(expected, actual);
    }
    
    #endregion

    #region Writer

    [Theory]
    [MemberData(nameof(GameServiceDataV1.InsertGameData), MemberType = typeof(GameServiceDataV1))]
    public async Task TestInsertGame(GameInsertRequest request, GameReplyDetails? expected, int failedReason)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(async () => await service.InsertGame(
                request,
                CreateCallContext()
            ));
            
            Assert.Equal(StatusCode.InvalidArgument, error.StatusCode);

            Assert.Equal(failedReason == 1
                             ? $"User with id {request.Players[0]} not found, game cannot be inserted"
                             : $"Rules {request.Rules} does not correspond to any rules, game cannot be inserted",
                         error.Status.Detail
            );
            
            return;
        }

        var actual = await service.InsertGame(
            request,
            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GameServiceDataV1.UpdateGameData), MemberType = typeof(GameServiceDataV1))]
    public async Task TestUpdateGame(GameReplyDetails request, GameReplyDetails? expected, int failedReason)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(async () => await service.UpdateGame(
                request,
                CreateCallContext()
            ));

            if (failedReason == 1)
            {
                Assert.Equal(StatusCode.InvalidArgument, error.StatusCode);
                Assert.Equal($"Rules {request.Rules} does not correspond to any rules, game cannot be updated", error.Status.Detail);
            }
            else
            {
                Assert.Equal(StatusCode.NotFound, error.StatusCode);
                Assert.Equal($"Game with id {request.Id} not found, it cannot be updated", error.Status.Detail);
            }
            
            return;
        }

        var actual = await service.UpdateGame(
            request,
            CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GameServiceDataV1.DeleteGameData), MemberType = typeof(GameServiceDataV1))]
    public async Task TestDeleteGame(ulong id, bool expected)
    {
        var service = new GameServiceV1(CreateManager(), CreateLogger<GameServiceV1>());

        if (!expected)
        {
            var error = await Assert.ThrowsAsync<RpcException>(async () => await service.DeleteGame(
                new IdRequest
                {
                    Id = id
                },
                CreateCallContext()
            ));
            
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"Game with id {id} not found, it cannot be deleted", error.Status.Detail);
            
            return;
        }
        
        var actual = await service.DeleteGame(
            new IdRequest
            {
                Id = id
            },
            CreateCallContext()
        );

        Assert.Equal(expected, actual.Result);
    }
    
    #endregion
}
