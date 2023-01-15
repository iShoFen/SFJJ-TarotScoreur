using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;

namespace TestUtils;

internal interface IReaderForTest
{
    IReader Get();
}

internal class DbReaderForTest: IReaderForTest
{
    public IReader Get() => new DbReader(new UnitOfWork(new TarotDbContextStub(TestInitializer.InitDb())));
}

// internal class StubForTest : IReaderForTest
// {
    // public IReader Get() => new Stub();
// }