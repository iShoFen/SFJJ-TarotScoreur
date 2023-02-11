using RestController.Controllers;
using Xunit;

namespace UT_RestController;

public class UT_HandsController
{
    [Fact]
    public void TestConstructor()
    {
        var controller = new HandsController(RestUtils.CreateManager());

        Assert.NotNull(controller);
    }
}