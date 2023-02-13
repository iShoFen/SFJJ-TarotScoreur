using Microsoft.AspNetCore.Mvc;
using RestController.Controllers;
using RestController.DTOs;
using Xunit;

namespace UT_RestController;

public class UT_HandsController
{
    [Fact]
    public void TestConstructor()
    {
        var controller = new HandsController(RestUtils.CreateManager(), RestUtils.CreateLogger<HandsController>());

        Assert.NotNull(controller);
    }
    
    // Test get handDetails
    
    /*[Theory]
    [MemberData(nameof(HandsControllerDataV1.Data_TestGetHandDetails), MemberType = typeof(HandsControllerDataV1))]
    public async Task TestGetHandDetails(ulong id, HandDTODetail expected)
    {
        var controller = new HandsController(RestUtils.CreateManager());

        var actual = await controller.GetHand(id);

        var response = (actual as ObjectResult)!.Value as HandDTODetail;

        Assert.Equal(expected, response);
    }*/
}