using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TarotDB;

namespace TestUtils;

internal static class TestInitializer
{
    public static DbContextOptions<TarotDbContext> InitDb()
    {
        // Connection must be opened to use In-Memory database
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return new DbContextOptionsBuilder<TarotDbContext>()
            .UseSqlite(connection)
            .Options;
    }
}