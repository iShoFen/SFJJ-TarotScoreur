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

    [Theory]
    [MemberData(nameof(GameEntityTestData.Data_TestRead), MemberType = typeof(GameEntityTestData))]
    public async Task TestRead(ulong expId, string expName, string expRules, DateTime expStartDate,
	    DateTime? expEndDate, IEnumerable<ulong> expPlayers, IEnumerable<ulong> expHands)
    {
	    await using var context = new TarotDBContextStub(InitDB());
	    await context.Database.EnsureCreatedAsync();
	    
	    var game = await context.Games.Include(ga => ga.Players)
		    .Include(ga => ga.Hands).ThenInclude(ha => ha.Biddings)
		    .SingleOrDefaultAsync(ga => ga.Id == expId);
		    
	    Assert.Equal(expId, game!.Id);
	    Assert.Equal(expRules, game.Rules);
	    Assert.Equal(expName, game.Name);
	    Assert.Equal(expStartDate, game.StartDate);
	    Assert.Equal(expEndDate, game.EndDate);

	    foreach (var player in expPlayers)
	    {
		    Assert.Single(game.Players.Where(pl => pl.Id == player 
		                                           && pl.Equals(context.Players.Find(player))
		                                           && pl.Games.Contains(game)));
	    }
		    
	    foreach (var hand in expHands)
	    {
		    Assert.Single(game.Hands.Where(ha => ha.Id == hand 
		                                         && ha.Equals(context.Hands.Find(hand))
		                                         && ha.Game.Equals(game)));
	    }
    }
    
    [Theory]
    [MemberData(nameof(GameEntityTestData.Data_TestAdd), MemberType = typeof(GameEntityTestData))]
    internal async Task TestAdd(string name, string rules, DateTime startDate,
        DateTime? endDate, IEnumerable<PlayerEntity> iPlayers, IEnumerable<HandEntity> iHands)
    {
        var players = iPlayers.ToHashSet();
        var hands = iHands.ToHashSet();
        var options = InitDB();
        
        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            Assert.Empty(context.Games.Where(ga => ga.Name == name));
            
            var game = new GameEntity
            {
                Name = name,
                Rules = rules,
                StartDate = startDate,
                EndDate = endDate,
                Players = players.Select(pl => pl.Id == 0 ? pl : context.Players.Find(pl.Id)!).ToHashSet(),
                Hands = hands
            };
            
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            
            var game = await context.Games
                .Include(ga => ga.Players)
                .Include(ga => ga.Hands)
                .SingleOrDefaultAsync(ga => ga.Name == name);
            
            Assert.NotNull(game);
            Assert.Equal(name, game!.Name);
            Assert.Equal(rules, game.Rules);
            Assert.Equal(startDate, game.StartDate);
            Assert.Equal(endDate, game.EndDate);
            Assert.Equal(players.Count, game.Players.Count);
            
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
}