using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_UserEntity
{
    private DbContextOptions<TarotDBContext> InitTest()
    {
        // Connection must be opened to use In-Memory database
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return new DbContextOptionsBuilder<TarotDBContext>()
            .UseSqlite(connection)
            .Options;
    }

    [Fact]
    public async Task TestRead()
    {
        var options = InitTest();

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            await context.Users.AddAsync(new UserEntity
            {
            });

            await context.SaveChangesAsync();

            Assert.Equal(17, await context.Players.CountAsync());
        }
    }
}