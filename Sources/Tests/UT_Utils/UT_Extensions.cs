using Utils;
using Xunit;

namespace UT_Utils;

public class UT_Extensions
{
    [Theory]
    [MemberData(nameof(ExtensionsDataTest.PaginateData), MemberType = typeof(ExtensionsDataTest))]
    public void PaginateEnumerableTest(IEnumerable<string> list, int start, int count, IEnumerable<string> expectedList)
    {
        var result = list.Paginate(start, count).ToList();
        var expectedResult = expectedList.ToList();

        Assert.Equal(expectedResult.Count, result.Count);
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [MemberData(nameof(ExtensionsDataTest.PaginateData), MemberType = typeof(ExtensionsDataTest))]
    public async Task PaginateAsyncEnumerableTest(IEnumerable<string> list, int start, int count, IEnumerable<string> expectedList)
    {
        var result = (await list.PaginateAsync(start, count)).ToList();
        var expectedResult = expectedList.ToList();

        Assert.Equal(expectedResult.Count, result.Count);
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [MemberData(nameof(ExtensionsDataTest.PaginateData), MemberType = typeof(ExtensionsDataTest))]
    public void PaginateQueryableTest(IEnumerable<string> list, int start, int count, IEnumerable<string> expectedList)
    {
        var result = list.AsQueryable().Paginate(start, count).ToList();
        var expectedResult = expectedList.ToList();

        Assert.Equal(expectedResult.Count, result.Count);
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [MemberData(nameof(ExtensionsDataTest.PaginateData), MemberType = typeof(ExtensionsDataTest))]
    public async Task PaginateAsyncQueryableTest(IEnumerable<string> list, int start, int count, IEnumerable<string> expectedList)
    {
        var result = (await list.AsQueryable().PaginateAsync(start, count)).ToList();
        var expectedResult = expectedList.ToList();

        Assert.Equal(expectedResult.Count, result.Count);
        Assert.Equal(expectedResult, result);
    }
}