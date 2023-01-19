using Microsoft.EntityFrameworkCore;
using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;

namespace TestUtils;

internal interface IWriterForTest
{
    IWriter Get();
    (IWriter, DbContext) GetAll();
}

internal class DbWriterForTest : IWriterForTest
{
    public IWriter Get() => new DbWriter(new UnitOfWork(new TarotDbContextStub(TestInitializer.InitDb())));
    public (IWriter, DbContext) GetAll()
    {
        var context = new TarotDbContextStub(TestInitializer.InitDb());
        var writer = new DbWriter(new UnitOfWork(context));
        return (writer, context);
    }
}