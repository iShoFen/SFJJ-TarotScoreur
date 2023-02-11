using Model;
using static TestUtils.DataManagers;
namespace UT_RestController;

public static class RestUtils
{
    public static Manager CreateManager()
        => new(Loaders[1].Get(), Writers[0].Get());
}