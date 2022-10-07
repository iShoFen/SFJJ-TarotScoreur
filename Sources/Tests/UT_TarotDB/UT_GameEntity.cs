using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_GameEntity
{
    private static DbContextOptions<TarotDBContext> InitDB()

    {

        //connection must be opened to use In-memory database

        var connection = new SqliteConnection("DataSource=:memory:");

        connection.Open();

        var options = new DbContextOptionsBuilder<TarotDBContext>()

            .UseSqlite(connection)

            .Options;

        return options;
    }
    
    [Fact]
    public void Test1()
    {
        using (var context = new TarotDBContextStub(InitDB()))
        {
            var test = context.Database.EnsureCreated();
            Assert.True(test);
        }
    }
}