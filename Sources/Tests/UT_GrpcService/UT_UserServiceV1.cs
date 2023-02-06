using Grpc.Core;
using GrpcService;
using GrpcService.Services;
using Xunit;
using static UT_GrpcService.GrpcUtils;

namespace UT_GrpcService;

public class UT_UserServiceV1
{

    [Fact]
    public void ConstructorTest()
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        Assert.NotNull(service);
    }

    #region Reader
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.Data_TestAllUsers), MemberType = typeof(UserServiceDataV1))]
    public async Task TestAllUsers(int page, int pageSize, UsersReply expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        var actual = await service.GetUsers(new Pagination {Page = page, PageSize = pageSize}, CreateCallContext());
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.Data_TestUserById), MemberType = typeof(UserServiceDataV1))]
    public async Task TestUserById(ulong id, UserReplyDetails? expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        if (expected is null)
        {
            var error = Assert.ThrowsAsync<RpcException>(async () => await service.GetUser(new IdRequest {Id = id}, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.Result.StatusCode);
            Assert.Equal($"User with id {id} not found", error.Result.Status.Detail);
            
            return;
        }
        
        var actual = await service.GetUser(new IdRequest {Id = id}, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.Data_TestUsersByPattern), MemberType = typeof(UserServiceDataV1))]
    public async Task TestUsersByPattern(string pattern, int page, int pageSize, UsersReply expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        var actual = await service.GetUsersByPattern(
            new UserPatternRequest
            {
                Pattern = pattern, 
                Pagination = new Pagination {Page = page, PageSize = pageSize}
            }, 
            CreateCallContext()); 
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.Data_TestUsersByNickname), MemberType = typeof(UserServiceDataV1))]
    public async Task TestUsersByNickname(string nickname, int page, int pageSize, UsersReply expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        var actual = await service.GetUsersByNickname(
            new UserPatternRequest
            {
                Pattern = nickname, 
                Pagination = new Pagination {Page = page, PageSize = pageSize}
            }, 
            CreateCallContext()); 
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.Data_TestUsersByFirstNameAndLastName), MemberType = typeof(UserServiceDataV1))]
    public async Task TestUsersByFirstNameAndLastName(string firstName, int page, int pageSize, UsersReply expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        var actual = await service.GetUsersByFirstNameAndLastName(
            new UserPatternRequest
            {
                Pattern = firstName, 
                Pagination = new Pagination {Page = page, PageSize = pageSize}
            }, 
            CreateCallContext()); 
        
        Assert.Equal(expected, actual);
    }
    
    #endregion
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.InsertUserData), MemberType = typeof(UserServiceDataV1))]
    public async Task TestInsertUser(UserInsertRequest request, UserReply expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        var actual = await service.InsertUser(request, CreateCallContext());
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.UpdateUserData), MemberType = typeof(UserServiceDataV1))]
    public async Task TestUpdateUser(UserUpdateRequest request, UserReplyDetails? expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());
        
        if (expected is null)
        {
            var error = Assert.ThrowsAsync<RpcException>(async () => await service.UpdateUser(request, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.Result.StatusCode);
            Assert.Equal($"User with id {request.Id} not found, it cannot be updated", error.Result.Status.Detail);
            
            return;
        }
        
        var actual = await service.UpdateUser(request, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceDataV1.DeleteUserData), MemberType = typeof(UserServiceDataV1))]
    public async Task TestDeleteUser(ulong id, bool expected)
    {
        var service = new UserServiceV1(CreateManager(), CreateLogger<UserServiceV1>());

        if (!expected)
        {
            var error = Assert.ThrowsAsync<RpcException>(async () => await service.DeleteUser(new IdRequest {Id = id}, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.Result.StatusCode);
            Assert.Equal($"User with id {id} not found, it cannot be deleted", error.Result.Status.Detail);
            
            return;
        }
        
        var actual = await service.DeleteUser(new IdRequest {Id = id}, CreateCallContext());
        
        
        Assert.Equal(expected, actual.Result);
    }
    
    #endregion
}
