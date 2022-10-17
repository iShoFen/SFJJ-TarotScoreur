using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TarotDB;

namespace UT_TarotDB;

internal static class TestInitializer
{
    public static DbContextOptions<TarotDBContext> InitDb()
    {
        // Connection must be opened to use In-Memory database
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return new DbContextOptionsBuilder<TarotDBContext>()
            .UseSqlite(connection)
            .Options;
    }
}