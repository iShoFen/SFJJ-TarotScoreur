using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;
using TarotDB;

namespace TestUtils;

internal static class DataManagers
{
    private static DbContextOptions<TarotDbContext> GetOptions()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        return new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
    }

    public static readonly IReader[] Loaders =
    {
        // new Stub(),
        new DbReader(new UnitOfWork(new TarotDbContextStub(GetOptions())))
    };

    public static readonly IWriter[] Savers =
    {
        new DbWriter(typeof(TarotDbContextStub), "DataSource=:memory:")
    };
}