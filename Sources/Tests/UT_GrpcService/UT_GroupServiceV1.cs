using Grpc.Core;
using GrpcService;
using GrpcService.Services;
using Xunit;
using static UT_GrpcService.GrpcUtils;

namespace UT_GrpcService;

public class UT_GroupServiceV1
{
    [Fact]
    public void ConstructorTest()
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        Assert.NotNull(service);
    }

    #region Reader

    [Theory]
    [MemberData(nameof(GroupServiceDataV1.Data_TestGroupsByName), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestGroupsByName(string name, int page, int pageSize, GroupsReply expected)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        var actual = await service.GetGroupsByName(new GroupPatternRequest
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
    [MemberData(nameof(GroupServiceDataV1.Data_TestGetGroupsByUser), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestGetGroupsByUser(ulong id, int page, int pageSize, GroupsReply expected)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        var actual = await service.GetGroupsByUser(new GroupUserRequest
                                                     {
                                                         UserId = id,
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
    [MemberData(nameof(GroupServiceDataV1.Data_TestLoadAllGroups), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestLoadAllGroups(int page, int pageSize, GroupsReply expected)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        var actual = await service.GetGroups(new Pagination
                                                 {
                                                     Page = page,
                                                     PageSize = pageSize
                                                 },
                                                 CreateCallContext()
        );

        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GroupServiceDataV1.Data_TestGetGroupById), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestGetGroupById(ulong id, GroupReply? expected)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.GetGroup(new IdRequest {Id = id}, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"Group with id {id} not found", error.Status.Detail);
            
            return;
        }
        
        var actual = await service.GetGroup(new IdRequest {Id = id}, CreateCallContext());
        Assert.Equal(expected, actual);
    }

    #endregion
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(GroupServiceDataV1.InsertGroupData), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestInsertGroup(GroupInsertRequest request, GroupReply? expected, int failIndex)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.InsertGroup(request, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"User with id {request.Users[failIndex]} not found", error.Status.Detail);
            
            return;
        }
        
        var actual = await service.InsertGroup(request, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GroupServiceDataV1.UpdateGroupData), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestUpdateGroup(GroupUpdateRequest request, GroupReply? expected, int failIndex)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        if (expected is null)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.UpdateGroup(request, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.StatusCode);

            Assert.Equal(
                failIndex == -1
                    ? $"Group with id {request.Id} not found, so it can't be updated"
                    : $"User with id {request.Users[failIndex]} not found, so it can't be added to group",
                error.Status.Detail
            );

            return;
        }
        
        var actual = await service.UpdateGroup(request, CreateCallContext());
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(GroupServiceDataV1.DeleteGroupData), MemberType = typeof(GroupServiceDataV1))]
    public async Task TestDeleteGroup(ulong id, bool expected)
    {
        var service = new GroupServiceV1(CreateManager(), CreateLogger<GroupServiceV1>());

        if (!expected)
        {
            var error = await Assert.ThrowsAsync<RpcException>(() => service.DeleteGroup(new IdRequest {Id = id}, CreateCallContext()));
            Assert.Equal(StatusCode.NotFound, error.StatusCode);
            Assert.Equal($"Group with id {id} not found, so it can't be deleted", error.Status.Detail);
            
            return;
        }
        
        var actual = await service.DeleteGroup(new IdRequest {Id = id}, CreateCallContext());
        Assert.Equal(expected, actual.Result);
    }
    
    #endregion
}
