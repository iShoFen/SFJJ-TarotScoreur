using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.enums;
using Model.games;
using StubLib;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Model.Manager;

public class UT_Manager

{
    /*========== Constructor test ==========*/
    
    [Fact]
    public void ConstructorTest()
    {
        var manager = new Model.Manager(new DbLoader(), new DbSaver());
        Assert.NotNull(manager);
    }
    
    /*========== Set DataManager test ==========*/
    [Fact]
    public void SetDataManagerTest()
    {
        var manager = new Model.Manager(new DbLoader(), new DbSaver());
        manager.SetDataManager(new DbLoader(), new DbSaver());
        Assert.NotNull(manager);
    }
    /*========== Players test ==========*/
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadAllPlayer(ILoader loader, int page, int pageSize, Player[] players)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadAllPlayer(page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByFirstName(ILoader loader, string firstName, Player[] players, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByFirstName(firstName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastName(ILoader loader, string lastName, Player[] players, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByLastName(lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByNickname(ILoader loader, string nickname, Player[] players, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByNickname(nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndLastName(ILoader loader, string firstName, string lastName, Player[] players,
        int page,
        int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndNickname(ILoader loader, string firstName, string nickname, Player[] players,
        int page,
        int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastNameAndNickname(ILoader loader, string lastName, string nickname, Player[] players, int page,
        int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByGroup(ILoader loader, Group group, Player[] players, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var playersFound = (await manager.LoadPlayersByGroup(group, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    /*========== End players test ==========*/


    /*========== Group test ==========*/
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByName(ILoader loader, string name, Group group)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var groupFound = (await manager.LoadGroupsByName(name));

        Assert.Equal(groupFound, group);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByPlayer(ILoader loader, Player player, Group[] groups, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var groupFound = (await manager.LoadGroupsByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public async Task TestLoadAllGroups(ILoader loader, Group[] groups, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var groupFound = (await manager.LoadAllGroups(page, pageSize)).ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }
    /*========== End group test ==========*/


    /*========== Rule test ==========*/
    [Theory]
    [MemberData(nameof(RuleTestData.Data_TestLoadRule), MemberType = typeof(RuleTestData))]
    public async Task TestLoadRule(string name, IRules rule)
    {
        var stub = new Stub();
        var ruleFound = await stub.LoadRule(name);

        Assert.Equal(ruleFound, rule);
    }

    [Theory]
    [MemberData(nameof(RuleTestData.Data_TestLoadAllRules), MemberType = typeof(RuleTestData))]
    public async Task TestLoadAllRules(IRules[] rules, int page, int pageSize)
    {
        var stub = new Stub();
        var rulesFound = (await stub.LoadAllRules(page, pageSize)).ToList();

        Assert.Equal(rulesFound.Count, rules.Length);
        Assert.Equal(rulesFound, rules);
    }
    /*========== End rule test ==========*/


    /*========== Hand test ==========*/
    [Theory]
    [MemberData(nameof(HandTestData.Data_TestLoadHandByGame), MemberType = typeof(HandTestData))]
    public async Task TestLoadHandByGame(ILoader loader, Game game, List<KeyValuePair<int, Hand>> hands, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var handsFound = (await manager.LoadHandByGame(game, page, pageSize)).ToList();

        Assert.Equal(handsFound.Count, hands.Count);
        Assert.Equal(handsFound, hands);
    }

    [Fact]
    public void TestCreateHand()
    {
        var manager = new Model.Manager(new DbLoader(), new DbSaver());
        var hand = new Hand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
            false, true, PetitResult.Lost, Chelem.Unknown,
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
                (Bidding.Garde, Poignee.Simple)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
                (Bidding.Opponent, Poignee.None)));
        var handCreateByManager = manager.CreateHand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
            false, true, PetitResult.Lost, Chelem.Unknown,
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
                (Bidding.Garde, Poignee.Simple)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                (Bidding.Opponent, Poignee.None)),
            new KeyValuePair<Player, (Bidding, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
                (Bidding.Opponent, Poignee.None)));
        
        Assert.Equal(hand, handCreateByManager);
    }
    
    /*========== End hand test ==========*/


    /*========== Game test ==========*/
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
    public async Task TestLoadAllGames(ILoader loader, Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
        var gamesFound = (await manager.LoadAllGames(page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByGroup(ILoader loader, Group group, Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByGroup(group, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByPlayer(ILoader loader, Player player, Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByName(ILoader loader, string name, Game? game)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gameFound = await manager.LoadGameByName(name);

        Assert.Equal(gameFound, game);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByStartDate(ILoader loader, DateTime startDate, Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByStartDate(startDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByEndDate(ILoader loader, DateTime endDate, Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByEndDate(endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateInterval(ILoader loader, DateTime startDate, DateTime endDate, Game[] games, int page,
        int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByDateInterval(startDate, endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndGroup(ILoader loader, DateTime startDate, DateTime endDate, Group group,
        Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound = (await manager.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize))
            .ToList();
        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndPlayer(ILoader loader, DateTime startDate, DateTime endDate, Player player,
        Game[] games, int page, int pageSize)
    {
        var manager = new Model.Manager(loader, new DbSaver());
	    var gamesFound =
            (await manager.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSavePlayer), MemberType = typeof(SaverTestData))]
	internal async Task TestSavePlayer(ISaver saver, Player player, Player? expPlayer, PlayerEntity? expEntity)
	{
        var manager = new Model.Manager(new DbLoader(), saver);
		var result = await manager.SavePlayer(player);
		Assert.Equal(expPlayer, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Players
				.Include(p => p.Games)
				.Include(p => p.Groups)
				.Include(p => p.Biddings)
				.FirstOrDefaultAsync(p => p.Id == expEntity.Id);


			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.FirstName, entity.FirstName);
			Assert.Equal(expEntity.LastName, entity.LastName);
			Assert.Equal(expEntity.Nickname, entity.Nickname);
			Assert.Equal(expEntity.Avatar, entity.Avatar);
		}
	}

	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSaveGroup), MemberType = typeof(SaverTestData))]
	internal async Task TestSaveGroup(ISaver saver, Group group, Group? expGroup, GroupEntity? expEntity)
    {
        var manager = new Model.Manager(new DbLoader(), saver);
		var result = await manager.SaveGroup(group);
		Assert.Equal(expGroup, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Groups
				.Include(g => g.Players)
				.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
			
			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.Name, entity.Name);
		}
	}

	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSaveGame), MemberType = typeof(SaverTestData))]
	internal async Task TestSaveGame(ISaver saver, Game game, Game? expGame, GameEntity? expEntity)
	{
        var manager = new Model.Manager(new DbLoader(), saver);
		var result = await manager.SaveGame(game);
		Assert.Equal(expGame, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Games
				.Include(g => g.Players)
				.Include(g => g.Hands)
				.Include(g => g.Players)
				.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
			
			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.Name, entity.Name);
			Assert.Equal(expEntity.Rules, entity.Rules);
			Assert.Equal(expEntity.StartDate, entity.StartDate);
			Assert.Equal(expEntity.EndDate, entity.EndDate);
		}
	}
}