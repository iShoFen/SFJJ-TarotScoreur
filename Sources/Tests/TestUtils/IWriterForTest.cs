using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;

namespace TestUtils;

internal interface IWriterForTest
{
    IWriter Get();
}

internal class DbWriterForTest : IWriterForTest
{
    public IWriter Get() => new DbWriter(new UnitOfWork(new TarotDbContextStub(TestInitializer.InitDb())));
}