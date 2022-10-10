using System.Security.AccessControl;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_PlayerEntity
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
            Assert.Equal(16, await context.Players.CountAsync());

            var julien = await context.Players.FindAsync((ulong)6);
            Assert.Equal("Julien", julien?.FirstName);
            Assert.Equal("PETIT", julien?.LastName);
            Assert.Equal("THEGIANT", julien?.Nickname);
            Assert.Equal("avatar2", julien?.Avatar);

            var playersWith_ne = context.Players.Where(p => p.FirstName.Contains("ne"));
            Assert.Equal(3, await playersWith_ne.CountAsync());
        }
    }

    [Theory]
    [InlineData(true, 16, "Florent", "MARQUES", "Flo", "avatar1")]
    [InlineData(true, 16, "", "MARQUES", "Flo", "avatar1")]
    [InlineData(true, 16, "Florent", "", "Flo", "avatar1")]
    [InlineData(true, 16, "Florent", "MARQUES", "", "avatar1")]
    [InlineData(true, 16, "Florent", "MARQUES", "Flo", "")]
    [InlineData(true, 16, "", "", "Flo", "avatar1")]
    [InlineData(true, 16, "", "MARQUES", "", "avatar1")]
    [InlineData(true, 16, "", "MARQUES", "Flo", "")]
    [InlineData(true, 16, "Florent", "", "", "avatar1")]
    [InlineData(true, 16, "Florent", "", "Flo", "")]
    [InlineData(true, 16, "Florent", "MARQUES", "", "")]
    [InlineData(false, 16, null, "MARQUES", "Flo", "avatar1")]
    [InlineData(false, 16, "Florent", null, "Flo", "avatar1")]
    [InlineData(false, 16, "Florent", "MARQUES", null, "avatar1")]
    [InlineData(false, 16, "Florent", "MARQUES", "Flo", null)]
    [InlineData(false, 16, null, null, "Flo", "avatar1")]
    [InlineData(false, 16, null, "MARQUES", null, "avatar1")]
    [InlineData(false, 16, null, "MARQUES", "Flo", null)]
    [InlineData(false, 16, "Florent", null, null, "avatar1")]
    [InlineData(false, 16, "Florent", null, "Flo", null)]
    [InlineData(false, 16, "Florent", "MARQUES", null, null)]
    [InlineData(false, 16, "    ", null, "Flo", "avatar1")]
    [InlineData(false, 16, null, "MARQUES", "    ", "avatar1")]
    [InlineData(false, 16, "Florent", "    ", null, "avatar1")]
    public async Task TestAdd(bool isValid, int initialPlayersCount, string firstname, string lastname,
        string nickname,
        string avatar)
    {
        var options = InitTest();

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            await context.Players.AddAsync(new PlayerEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar
            });

            if (isValid)
            {
                await context.SaveChangesAsync();
            }
            else
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(async () => await context.SaveChangesAsync());
            }
        }

        using (var context = new TarotDBContextStub(options))
        {
            if (isValid)
            {
                Assert.Equal(initialPlayersCount + 1, await context.Players.CountAsync());
                Assert.Equal(1, await context.Players.Where(p => p.FirstName == firstname
                                                                 && p.LastName == lastname
                                                                 && p.Nickname == nickname
                                                                 && p.Avatar == avatar).CountAsync());
            }
            else
            {
                Assert.Equal(initialPlayersCount, await context.Players.CountAsync());
            }
        }
    }

    [Theory]
    [InlineData("Florent", "Marques", "Flo", "avatar", "Samuel", "Sirven", "Sam", "mon avatar")]
    [InlineData("", "", "Flo", "avatar", "Samuel", "Sirven", "Sam", "mon avatar")]
    [InlineData("Florent", "Marques", "Flo", "avatar", "", "", "Sam", "mon avatar")]
    public async Task TestUpdate(string firstname, string lastname, string nickname, string avatar,
        string firstname2, string lastname2, string nickname2, string avatar2)
    {
        var options = InitTest();

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            await context.Players.AddAsync(new PlayerEntity()
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar
            });

            await context.SaveChangesAsync();
        }

        ulong playerId;
        using (var context = new TarotDBContextStub(options))
        {
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);

            var playersAfter = context.Players.Where(p => p.FirstName == firstname2
                                                          && p.LastName == lastname2
                                                          && p.Nickname == nickname2
                                                          && p.Avatar == avatar2);

            Assert.Equal(1, await players.CountAsync());
            Assert.Equal(0, await playersAfter.CountAsync());

            var player = players.Single();
            playerId = player.Id;
            player.FirstName = firstname2;
            player.LastName = lastname2;
            player.Nickname = nickname2;
            player.Avatar = avatar2;

            await context.SaveChangesAsync();
        }

        using (var context = new TarotDBContextStub(options))
        {
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);

            var playersAfter = context.Players.Where(p => p.FirstName == firstname2
                                                          && p.LastName == lastname2
                                                          && p.Nickname == nickname2
                                                          && p.Avatar == avatar2);

            Assert.Equal(0, await players.CountAsync());
            Assert.Equal(1, await playersAfter.CountAsync());
            Assert.Equal(playerId, playersAfter.Single().Id);
        }
    }

    [Theory]
    [InlineData("Florent", "Marques", "Flo", "avatar")]
    [InlineData("", "Marques", "Flo", "avatar")]
    [InlineData("Florent", "", "Flo", "avatar")]
    [InlineData("Florent", "Marques", "", "avatar")]
    [InlineData("Florent", "Marques", "Flo", "")]
    [InlineData("", "", "Flo", "avatar")]
    [InlineData("", "Marques", "", "avatar")]
    [InlineData("", "Marques", "Flo", "")]
    [InlineData("Florent", "", "", "avatar")]
    [InlineData("Florent", "", "Flo", "")]
    [InlineData("Florent", "Marques", "", "")]
    [InlineData("     ", "Marques", "Flo", "avatar")]
    [InlineData("Florent", "     ", "Flo", "avatar")]
    [InlineData("Florent", "Marques", "    ", "avatar")]
    [InlineData("Florent", "Marques", "Flo", "    ")]
    [InlineData("    ", "    ", "    ", "avatar")]

    public async Task TestDelete(string firstname, string lastname, string nickname, string avatar)
    {
        var options = InitTest();

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            await context.Players.AddAsync(new PlayerEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar
            });

            await context.SaveChangesAsync();
        }

        ulong playerId;

        using (var context = new TarotDBContextStub(options))
        {
            var players = context.Players.Where(p => p.FirstName == firstname
                                       && p.LastName == lastname
                                       && p.Nickname == nickname
                                       && p.Avatar == avatar);
            
            Assert.Equal(1, await players.CountAsync());

            var player = players.Single();
            playerId = player.Id;
            context.Players.Remove(player);
            await context.SaveChangesAsync();
        }

        using (var context = new TarotDBContextStub(options))
        {
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);
            
            Assert.Equal(0, await players.CountAsync());         
            Assert.Null(await context.Players.FindAsync(playerId));
        }
    }
}