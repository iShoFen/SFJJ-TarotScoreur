using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using TestUtils;
using Xunit;

namespace UT_TarotDB;

public class UT_GameEntity
{
    [Theory]
    [MemberData(nameof(GameEntityTestData.Data_TestRead), MemberType = typeof(GameEntityTestData))]
    public async Task TestRead(ulong expId, string expName, string expRules, DateTime expStartDate,
        DateTime? expEndDate, IEnumerable<ulong> expPlayers, IEnumerable<ulong> expHands)
    {
        await using var context = new TarotDbContextStub(TestInitializer.InitDb());
        await context.Database.EnsureCreatedAsync();

        var game = await context.Games
            .Include(ga => ga.Players)
            .Include(ga => ga.Hands)
            .SingleOrDefaultAsync(ga => ga.Id == expId);

        Assert.Equal(expId, game!.Id);
        Assert.Equal(expRules, game.Rules);
        Assert.Equal(expName, game.Name);
        Assert.Equal(expStartDate, game.StartDate);
        Assert.Equal(expEndDate, game.EndDate);

        foreach (var playerId in expPlayers)
        {
            Assert.Single(
                game.Players.Where(pl => pl.Equals(context.Players.Find(playerId)) && pl.Games.Contains(game)));
        }

        foreach (var hand in expHands)
        {
            Assert.Single(game.Hands.Where(ha => ha.Equals(context.Hands.Find(hand)) && ha.Game.Equals(game)));
        }
    }

    [Theory]
    [MemberData(nameof(GameEntityTestData.Data_TestAdd), MemberType = typeof(GameEntityTestData))]
    internal async Task TestAdd(bool isValid, ulong id, string name, string rules, DateTime startDate,
        DateTime? endDate, IEnumerable<PlayerEntity> iPlayers, IEnumerable<HandEntity> iHands)
    {
        var players = iPlayers.ToHashSet();
        var hands = iHands.ToHashSet();
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var game = new GameEntity
            {
                Id = id,
                Name = name,
                Rules = rules,
                StartDate = startDate,
                EndDate = endDate,
                Players = players.Select(pl => pl.Id == 0 ? pl : context.Players.Find(pl.Id)!).ToHashSet(),
                Hands = hands.Select(ha => ha.Id == 0 ? ha : context.Hands.Find(ha.Id)!).ToHashSet()
            };

            await context.Games.AddAsync(game);

            if (!isValid)
            {
                var error = await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
                Assert.Contains("UNIQUE constraint failed: Games.Id", error.InnerException!.Message);

                return;
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var game = await context.Games
                .Include(ga => ga.Players)
                .Include(ga => ga.Hands)
                .SingleOrDefaultAsync(ga => ga.Name == name);

            Assert.NotNull(game);
            Assert.NotEqual(0UL, game!.Id);
            Assert.Equal(name, game.Name);
            Assert.Equal(rules, game.Rules);
            Assert.Equal(startDate, game.StartDate);
            Assert.Equal(endDate, game.EndDate);
            Assert.Equal(players.Count, game.Players.Count);
            Assert.Equal(hands.Count, game.Hands.Count);

            foreach (var player in game.Players)
            {
                Assert.Contains(game, player.Games);
                Assert.Contains(player, context.Players);
            }

            foreach (var hand in game.Hands)
            {
                Assert.Equal(hand.Game.Id, game.Id);
                Assert.Contains(hand, context.Hands);
            }
        }
    }

    [Theory]
    [MemberData(nameof(GameEntityTestData.Data_TestUpdate), MemberType = typeof(GameEntityTestData))]
    internal async Task TestUpdate(bool isValid, ulong id, ulong newId, string name, string newName, string rules,
        string newRules, DateTime startDate, DateTime newStartDate, DateTime? endDate, DateTime? newEndDate,
        IEnumerable<PlayerEntity> players, IEnumerable<PlayerEntity> iPlayersToRemove, IEnumerable<HandEntity> hands,
        IEnumerable<HandEntity> iHandsToRemove)
    {
        var options = TestInitializer.InitDb();
        var playersToRemove = iPlayersToRemove.ToList();
        var handsToRemove = iHandsToRemove.ToList();
        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var game = await context.Games
                .Include(ga => ga.Players)
                .Include(ga => ga.Hands)
                .SingleOrDefaultAsync(ga => ga.Id == id);

            Assert.NotNull(game);
            Assert.Equal(name, game!.Name);
            Assert.Equal(rules, game.Rules);
            Assert.Equal(startDate, game.StartDate);
            Assert.Equal(endDate, game.EndDate);
            Assert.True(players.All(pl => game.Players.Contains(context.Players.Find(pl.Id)!)));
            Assert.True(hands.All(ha => game.Hands.Contains(context.Hands.Find(ha.Id)!)));

            game.Id = newId;
            game.Name = newName;
            game.Rules = newRules;
            game.StartDate = newStartDate;
            game.EndDate = newEndDate;

            foreach (var player in playersToRemove)
            {
                game.Players.Remove((await context.Players.FindAsync(player.Id))!);
            }

            foreach (var hand in handsToRemove)
            {
                game.Hands.Remove((await context.Hands.FindAsync(hand.Id))!);
            }

            if (!isValid)
            {
                var error = await Assert.ThrowsAsync<InvalidOperationException>(() => context.SaveChangesAsync());
                Assert.Contains("The property 'GameEntity.Id' is part of a key", error.Message);

                return;
            }

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var game = await context.Games
                .Include(ga => ga.Players)
                .Include(ga => ga.Hands)
                .SingleOrDefaultAsync(ga => ga.Id == newId);

            Assert.NotNull(game);
            Assert.Equal(newId, game!.Id);
            Assert.Equal(newName, game.Name);
            Assert.Equal(newRules, game.Rules);
            Assert.Equal(newStartDate, game.StartDate);
            Assert.Equal(newEndDate, game.EndDate);

            PlayerEntity? player;
            Assert.True(playersToRemove.All(pl =>
                (player = context.Players.Find(pl.Id)) != null
                && !game.Players.Contains(player)));

            Assert.True(handsToRemove.All(ha => context.Hands.Find(ha.Id) == null));
        }
    }

    [Fact]
    public async Task TestDelete()
    {
        var options = TestInitializer.InitDb();
        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            var game = await context.Games
                .Include(ga => ga.Players)
                .Include(ga => ga.Hands)
                .SingleOrDefaultAsync(ga => ga.Id == 1UL);

            Assert.NotNull(game);
            Assert.Equal("Game1", game!.Name);
            Assert.Equal("FrenchTarotRules", game.Rules);
            Assert.Equal(new DateTime(2022, 09, 21), game.StartDate);
            Assert.Null(game.EndDate);
            Assert.Contains(await context.Players.FindAsync(1UL), game.Players);
            Assert.Contains(await context.Players.FindAsync(2UL), game.Players);
            Assert.Contains(await context.Players.FindAsync(3UL), game.Players);
            Assert.Contains(await context.Hands.FindAsync(1UL), game.Hands);
            Assert.Contains(await context.Hands.FindAsync(2UL), game.Hands);
            Assert.Contains(await context.Hands.FindAsync(3UL), game.Hands);

            context.Games.Remove(game);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDbContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            Assert.Null(await context.Games.FindAsync(1UL));

            Assert.NotNull(await context.Players.FindAsync(1UL));
            Assert.NotNull(await context.Players.FindAsync(2UL));
            Assert.NotNull(await context.Players.FindAsync(3UL));

            Assert.Null(await context.Hands.FindAsync(1UL));
            Assert.Null(await context.Hands.FindAsync(2UL));
            Assert.Null(await context.Hands.FindAsync(3UL));
        }
    }
}