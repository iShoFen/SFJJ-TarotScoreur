using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using TestUtils;
using Xunit;

namespace UT_TarotDB;

public class UT_PlayerEntity
{
    [Fact]
    public async Task TestRead()
    {
        var options = TestInitializer.InitDb();

        await using var context = new TarotDbContextStub(options);
        await context.Database.EnsureCreatedAsync();
        Assert.Equal(16, await context.Players.CountAsync());

        var julien = await context.Players.FindAsync(6UL);
        Assert.Equal("Julien", julien?.FirstName);
        Assert.Equal("PETIT", julien?.LastName);
        Assert.Equal("THEGIANT", julien?.Nickname);
        Assert.Equal("avatar6", julien?.Avatar);

        var playersWith_ne = context.Players.Where(p => p.FirstName.Contains("ne"));
        Assert.Equal(3, await playersWith_ne.CountAsync());
    }

    [Theory]
    [MemberData(nameof(PlayerEntityTestData.Data_TestAdd), MemberType = typeof(PlayerEntityTestData))]
    internal async Task TestAdd(bool isValid, int initialPlayersCount, string firstname, string lastname,
        string nickname, string avatar, IEnumerable<ulong> iHandIds, IEnumerable<GameEntity> iGames,
        IEnumerable<GroupEntity> iGroups)
    {
        var handIds = iHandIds.ToHashSet();
        var games = iGames.ToHashSet();
        var groups = iGroups.ToHashSet();
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var player = new PlayerEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar,
                Games = games.Select(g => g.Id == 0 ? g : context.Games.Find(g.Id)!).ToHashSet(),
                Groups = groups.Select(g => g.Id == 0 ? g : context.Groups.Find(g.Id)!).ToHashSet()
            };

            var bids = new List<BiddingPoigneeEntity>();
            foreach (var handId in handIds)
            {
                bids.Add(new BiddingPoigneeEntity
                {
                    Player = player,
                    HandId = handId
                });
            }            
            player.Biddings = bids; 
            
            await context.Players.AddAsync(player);

            if (isValid)
            {
                await context.SaveChangesAsync();
            }
            else
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(async () => await context.SaveChangesAsync());
            }
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            if (isValid)
            {
                Assert.Equal(initialPlayersCount + 1, await context.Players.CountAsync());
                var player = await context.Players
                    .Include(p => p.Biddings)
                    .ThenInclude(bp => bp.Hand)
                    .Include(p => p.Games)
                    .Include(p => p.Groups)
                    .FirstOrDefaultAsync(p => p.FirstName == firstname
                                              && p.LastName == lastname
                                              && p.Nickname == nickname
                                              && p.Avatar == avatar);
                Assert.NotNull(player);
                Assert.Equal(firstname, player.FirstName);
                Assert.Equal(lastname, player.LastName);
                Assert.Equal(nickname, player.Nickname);
                Assert.Equal(avatar, player.Avatar);
                foreach (var bp in player.Biddings)
                {
                    Assert.Contains(bp.HandId, handIds);
                    Assert.Equal(player.Id, bp.PlayerId);
                }
                Assert.All(games, g => Assert.Contains(context.Games.Find(g.Id), player.Games));
                Assert.All(groups, g => Assert.Contains(context.Groups.Find(g.Id), player.Groups));
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
        string newFirstname, string newLastname, string newNickname, string newAvatar)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

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
        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);

            var playersAfter = context.Players.Where(p => p.FirstName == newFirstname
                                                          && p.LastName == newLastname
                                                          && p.Nickname == newNickname
                                                          && p.Avatar == newAvatar);

            Assert.Equal(1, await players.CountAsync());
            Assert.Equal(0, await playersAfter.CountAsync());

            var player = players.Single();
            playerId = player.Id;
            player.FirstName = newFirstname;
            player.LastName = newLastname;
            player.Nickname = newNickname;
            player.Avatar = newAvatar;

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);

            var playersAfter = context.Players
                .Include(p => p.Biddings)
                .Include(p => p.Games)
                .Include(p => p.Groups)
                .Where(p => p.FirstName == newFirstname
                            && p.LastName == newLastname
                            && p.Nickname == newNickname
                            && p.Avatar == newAvatar);

            Assert.Equal(0, await players.CountAsync());
            Assert.Equal(1, await playersAfter.CountAsync());
            Assert.Equal(playerId, playersAfter.Single().Id);

            var player = await playersAfter.FirstOrDefaultAsync();
            Assert.NotNull(player);
            Assert.Equal(newFirstname, player.FirstName);
            Assert.Equal(newLastname, player.LastName);
            Assert.Equal(newNickname, player.Nickname);
            Assert.Equal(newAvatar, player.Avatar);
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
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

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

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var players = context.Players
                .Include(p => p.Biddings)
                .Include(p => p.Games)
                .Include(p => p.Groups)
                .Where(p => p.FirstName == firstname
                            && p.LastName == lastname
                            && p.Nickname == nickname
                            && p.Avatar == avatar);

            Assert.Equal(1, await players.CountAsync());

            var player = players.Single();
            playerId = player.Id;
            context.Players.Remove(player);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var players = context.Players.Where(p => p.FirstName == firstname
                                                     && p.LastName == lastname
                                                     && p.Nickname == nickname
                                                     && p.Avatar == avatar);

            Assert.Equal(0, await players.CountAsync());
            Assert.Null(await context.Players.FindAsync(playerId));
        }
    }

    [Theory]
    [InlineData(1UL)]
    [InlineData(13UL)]
    public async Task TestGamesBiddingsGroups(ulong id)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var player = await context.Players
                .Include(p => p.Biddings)
                .Include(p => p.Games)
                .Include(p => p.Groups)
                .FirstOrDefaultAsync(p => p.Id == id);

            Assert.NotNull(player);
            Assert.All(player.Biddings, bp => Assert.Equal(bp.Player, player));
            Assert.All(player.Games, g => Assert.Contains(player, g.Players));
            Assert.All(player.Groups, g => Assert.Contains(player, g.Players));
        }
    }
}