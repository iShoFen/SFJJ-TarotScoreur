using Microsoft.AspNetCore.Mvc;
using RestController.Controllers;
using RestController.DTOs;
using RestController.DTOs.Games;
using RestController.Filter;
using Xunit;

namespace UT_RestController;

public class UT_UsersController
{
    [Fact]
    public void TestConstructor()
    {
        var controller = new UsersController(RestUtils.CreateManager());

        Assert.NotNull(controller);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="pageSize">Number of elements on the page</param>
    /// <param name="expected">Expected result</param>
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestGetUsers), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestGetUsers(int page, int pageSize, List<UserDTO> expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.GetUsers(new PaginationFilter{ Page = page, Count = pageSize });
        
        var response = (actual as OkObjectResult)!.Value as List<UserDTO>;
        
        Assert.Equal(expected, response);
    }
    
    // Test for getUserById method
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestGetUserById), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestGetUserById(ulong id, UserDetailDTO expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.GetUser(id);
        
        var response = (actual as ObjectResult)!.Value as UserDetailDTO;
        
        Assert.Equal(expected,response);
    }
    
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestGetGamesByUserId), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestGetGamesByUserId(ulong id, List<GameDTO> expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.GetGames(id, new PaginationFilter());
        
        var response = (actual as OkObjectResult)!.Value as List<GameDTO>;
        
        Assert.Equal(expected, response);
    }
    
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestGetGroupsByUserId), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestGetGroupsByUserId(ulong id, List<GroupDTO> expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.GetGroups(id, new PaginationFilter());
        
        var response = (actual as ObjectResult)!.Value as List<GroupDTO>;
        
        Assert.Equal(expected, response);
    }

    #region Writer
    
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestPostUser), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestPostUser(UserInsertRequest inserted, UserDTO expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.PostUser(inserted);
        
        var response = (actual as ObjectResult)!.Value as UserDTO;
        
        Assert.Equal(expected, response);
    }
    
    [Theory]
    [MemberData(nameof(UsersControllerDataV1.Data_TestPutUser), MemberType = typeof(UsersControllerDataV1))]
    public async Task TestPutUser(ulong id, UserUpdateRequest updated, UserDTO expected)
    {
        var controller = new UsersController(RestUtils.CreateManager());

        var actual = await controller.PutUser(id, updated);
        
        var response = (actual as ObjectResult)!.Value as UserDTO;
        
        Assert.Equal(expected, response);
    }


    #endregion
    
}