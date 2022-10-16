using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;

namespace FT_TarotDBStub;

internal class Program
{
    public static void Main()
    {
        var connection = new SqliteConnection("DataSource=:memory:");

        connection.Open();

        var options = new DbContextOptionsBuilder<TarotDBContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            var groups = context.Groups.Include(g => g.Players).ToList();
        }
    }
}