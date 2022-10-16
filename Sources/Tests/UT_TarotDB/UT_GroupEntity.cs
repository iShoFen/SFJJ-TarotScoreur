using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_GroupEntity
{
    [Fact]
    public async Task TestRead()
    {
        var options = TestInitializer.InitDb();

        await using var context = new TarotDBContextStub(options);
        await context.Database.EnsureCreatedAsync();

        var group = await context.Groups
            .Include(g => g.Players)
            .FirstAsync(g => g.Id == 6UL);

        Assert.Equal("Group6", group.Name);
        Assert.Equal(5, group.Players.Count);
    }

    [Theory]
    [MemberData(nameof(GroupEntityTestData.Data_TestAdd), MemberType = typeof(GroupEntityTestData))]
    internal async Task TestAdd(bool isValid, string name, IEnumerable<PlayerEntity> players, int expectedPlayers)
    {
        var options = TestInitializer.InitDb();
        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            Assert.Empty(context.Groups.Where(g => g.Name == name));

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };

            Assert.Equal(expectedPlayers, group.Players.Count);
            await context.Groups.AddAsync(group);

            if (!isValid)
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(() => context.SaveChangesAsync());
                return;
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var fetchGroup = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);

            Assert.NotNull(fetchGroup);
            Assert.Equal(name, fetchGroup!.Name);
            Assert.All(fetchGroup.Players, p => Assert.Contains(p, context.Players));
            Assert.All(fetchGroup.Players, p => Assert.Contains(fetchGroup, p.Groups));
        }
    }

    [Theory]
    [MemberData(nameof(GroupEntityTestData.Data_TestUpdateName), MemberType = typeof(GroupEntityTestData))]
    internal async Task TestUpdateName(bool isValid, string name, IEnumerable<PlayerEntity> players, string newName)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };
            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var group = context.Groups.FirstOrDefault(g => g.Name == name);
            Assert.NotNull(group);

            group!.Name = newName;

            if (!isValid)
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(() => context.SaveChangesAsync());
                return;
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var group = context.Groups.FirstOrDefault(g => g.Name == newName);
            Assert.NotNull(group);
            await context.SaveChangesAsync();
        }
    }

    [Theory]
    [MemberData(nameof(GroupEntityTestData.Data_TestAddPlayers), MemberType = typeof(GroupEntityTestData))]
    internal async Task TestAddPlayer(bool isValid, string name, IEnumerable<PlayerEntity> players,
        int expectedPlayerCount, params PlayerEntity[] newPlayers)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };
            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var group = await context.Groups.Include(g => g.Players).FirstOrDefaultAsync(g => g.Name == name);
            Assert.NotNull(group);

            foreach (var p in newPlayers)
            {
                group!.Players.Add(p.Id == 0 ? p : (await context.Players.FindAsync(p.Id))!);
            }

            if (!isValid)
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(() => context.SaveChangesAsync());
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var group = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);
            Assert.NotNull(group);

            Assert.Equal(expectedPlayerCount, group!.Players.Count);
            Assert.All(group.Players, p => Assert.Contains(p, context.Players));
            Assert.All(group.Players, p => Assert.Contains(group, p.Groups));
        }
    }

    [Theory]
    [MemberData(nameof(GroupEntityTestData.Data_TestRemovePlayers), MemberType = typeof(GroupEntityTestData))]
    internal async Task TestRemovePlayers(string name, IEnumerable<PlayerEntity> players,
        int expectedPlayerCount, params PlayerEntity[] removePlayers)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };
            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);
            Assert.NotNull(group);

            var playersToRemove = removePlayers.Select(p => context.Players.Find(p.Id)!).ToHashSet();

            foreach (var removePlayer in playersToRemove)
            {
                group!.Players.Remove(removePlayer);
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);

            Assert.Equal(expectedPlayerCount, group!.Players.Count);
            Assert.All(group.Players, p => Assert.Contains(p, context.Players));
            Assert.All(group.Players, p => Assert.Contains(group, p.Groups));
        }
    }

    [Fact]
    internal async Task TestRemove()
    {
        var options = TestInitializer.InitDb();
        const string name = "NewGroup1";
        var players = new[]
        {
            new PlayerEntity { Id = 6UL },
            new PlayerEntity { Id = 8UL },
            new PlayerEntity { Id = 13UL },
            new PlayerEntity { Id = 15UL }
        };

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };
            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var groupToRemove = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);
            Assert.NotNull(groupToRemove);

            context.Groups.Remove(groupToRemove!);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var group = context.Groups
                .Include(g => g.Players)
                .FirstOrDefault(g => g.Name == name);
            
            Assert.Null(group);
            foreach (var player in players)
            {
                Assert.NotNull(await context.Players.FindAsync(player.Id));
            }
        }
    }
}