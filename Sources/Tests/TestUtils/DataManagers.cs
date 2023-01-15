using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;

namespace TestUtils;

internal static class DataManagers
{
    public static readonly IReaderForTest[] Loaders =
    {
        // new StubForTest(),
        new DbReaderForTest()
    };

    public static readonly IWriter[] Savers =
    {
        new DbWriter(typeof(TarotDbContextStub), "DataSource=:memory:")
    };
}