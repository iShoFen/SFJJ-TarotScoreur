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
        var controller = new GroupsController(RestUtils.CreateManager());

        Assert.NotNull(controller);
    }
    
    // Test for getGroups method
    [Theory]
    [MemberData(nameof(GroupsControllerDataV1.Data_TestGetGroups), MemberType = typeof(GroupsControllerDataV1))]
    public async Task TestGetGroups(int page, int pageSize, List<GroupDTO> expected)
    {
        var controller = new GroupsController(RestUtils.CreateManager());

        var actual = await controller.GetGroups(new PaginationFilter{ Page = page, Count = pageSize });
        
        var response = (actual as OkObjectResult)!.Value as List<GroupDTO>;
        
        Assert.Equal(expected, response);
    }
}