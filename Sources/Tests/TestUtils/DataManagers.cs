namespace TestUtils;

internal static class DataManagers
{
    public static readonly IReaderForTest[] Loaders =
    {
        new StubForTest(),
        new DbReaderForTest()
    };

    public static readonly IWriterForTest[] Writers =
    {
        new DbWriterForTest()
    };
}