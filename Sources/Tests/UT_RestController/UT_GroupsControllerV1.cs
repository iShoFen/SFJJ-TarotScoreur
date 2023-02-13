using Microsoft.AspNetCore.Mvc;
using RestController.Controllers;
using RestController.DTOs;
using RestController.Filter;
using Xunit;


namespace UT_RestController;

public class UT_GroupsControllerV1
{
    [Fact]
    public void TestConstructor()
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());

        Assert.NotNull(controller);
    }

    // Test for getGroups method
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestGetGroups), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestGetGroups(int page, int pageSize, List<GroupDTO> expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());

        var actual = await controller.GetGroups(new PaginationFilter { Page = page, Count = pageSize });

        var response = (actual as OkObjectResult)!.Value as List<GroupDTO>;

        Assert.Equal(expected, response);
    }

    // Test for getGroupById method
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestGetGroupById), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestGetGroupById(ulong id, GroupDTO expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());

        var actual = await controller.GetGroup(id);

        var response = (actual as ObjectResult)!.Value as GroupDTO;

        Assert.Equal(expected, response);
    }

    // Test for getGroupUsers method
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestGetGroupUsers), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestGetGroupUsers(ulong id, List<UserDTO> expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());

        var actual = await controller.GetPlayersByGroupId(id);

        var response = (actual as OkObjectResult)!.Value as List<UserDTO>;

        Assert.Equal(expected, response);
    }

    // Test get player by group id
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestGetGroupUserById), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestGetGroupUserById(ulong id, ulong userId, UserDetailDTO expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());

        var actual = await controller.GetPlayerByGroupId(id, userId);

        var response = (actual as ObjectResult)!.Value as UserDetailDTO;

        Assert.Equal(expected, response);
    }

    #region Writer

    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestPostGroup), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestPostGroup(ulong groupId, GroupDTOPostRequest inserted, GroupDTO expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());
        var response = (await controller.PostGroup(inserted) as ObjectResult)?.Value as GroupDTO;

        Assert.Equal(expected, response);
    }
    
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestPutGroup), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestPutGroup(ulong groupId, GroupDTO inserted, GroupDTO expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());
        var response = (await controller.PutGroup(groupId, inserted) as ObjectResult)?.Value as GroupDTO;

        Assert.Equal(expected, response);
    }
    
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestDeleteGroup), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestDeleteGroup(ulong groupId, bool expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager(), RestUtils.CreateLogger<GroupsController>());
        var response = (await controller.DeleteGroup(groupId) as ObjectResult)?.Value as bool?;

        Assert.Equal(expected, response);
    }

    #endregion

}