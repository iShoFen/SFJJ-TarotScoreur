using Microsoft.Extensions.Logging;
using Model;
using Moq;
using static TestUtils.DataManagers;
namespace UT_RestController;

public static class RestUtils
{
    public static ILogger<T> CreateLogger<T>() 
        => new Mock<ILogger<T>>().Object;
    public static Manager CreateManager()
        => new(Loaders[1].Get(), Writers[0].Get());
}