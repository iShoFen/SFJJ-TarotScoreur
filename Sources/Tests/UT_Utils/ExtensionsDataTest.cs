namespace UT_Utils;

public class ExtensionsDataTest
{
    public static IEnumerable<object?[]> PaginateData()
    {
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            1,
            10,
            Enumerable.Range(0, 10).Select(i => $"Item {i}")
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            2,
            10,
            Enumerable.Range(10, 10).Select(i => $"Item {i}")
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            13,
            8,
            Enumerable.Range(96, 4).Select(i => $"Item {i}")
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            0,
            10,
            Enumerable.Empty<string>()
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            1,
            0,
            Enumerable.Empty<string>()
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            0,
            0,
            Enumerable.Empty<string>()
        };
        yield return new object?[]
        {
            Enumerable.Range(0, 100).Select(i => $"Item {i}"),
            int.MaxValue,
            int.MaxValue,
            Enumerable.Empty<string>()
        };
    }
}