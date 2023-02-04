using Grpc.Core;
using GrpcService;
using GrpcService.Services;
using Model;
using Moq;
using Xunit;
using static TestUtils.DataManagers;


namespace UT_GrpcService;

public class UT_UserService
{
    private static ServerCallContext CreateCallContext() 
        => new Mock<ServerCallContext>().Object;

    [Fact]
    public void ConstructorTest()
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
        Assert.NotNull(service);
    }

    #region Reader
    
    [Theory]
    [MemberData(nameof(UserServiceData.Data_TestAllUsers), MemberType = typeof(UserServiceData))]
    public async Task TestAllUsers(int page, int pageSize, UsersReply expected)
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
        var actual = await service.GetUsers(new Pagination {Page = page, PageSize = pageSize}, CreateCallContext());
        
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(UserServiceData.Data_TestUserById), MemberType = typeof(UserServiceData))]
    public async Task TestUserById(ulong id, UserReply? expected)
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
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
    [MemberData(nameof(UserServiceData.Data_TestUsersByPattern), MemberType = typeof(UserServiceData))]
    public async Task TestUsersByPattern(string pattern, int page, int pageSize, UsersReply expected)
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
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
    [MemberData(nameof(UserServiceData.Data_TestUsersByNickname), MemberType = typeof(UserServiceData))]
    public async Task TestUsersByNickname(string nickname, int page, int pageSize, UsersReply expected)
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
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
    [MemberData(nameof(UserServiceData.Data_TestUsersByFirstNameAndLastName), MemberType = typeof(UserServiceData))]
    public async Task TestUsersByFirstNameAndLastName(string firstName, int page, int pageSize, UsersReply expected)
    {
        var manager = new Manager(Loaders[1].Get(), Writers[0].Get());
        var service = new UserService(manager);
        
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
    
}
