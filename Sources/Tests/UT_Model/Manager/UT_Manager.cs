using Microsoft.EntityFrameworkCore;
using Model.Rules;
using Model.Data;
using Model.Enums;
using Model.Games;
using Model.Players;
using StubLib;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Model.Manager;

public class UT_Manager
{
 //    /*========== Constructor test ==========*/
 //    
 //    [Fact]
 //    public void ConstructorTest()
 //    {
 //        var manager = new Model.Manager(new DbReader(), new DbWriter());
 //        Assert.NotNull(manager);
 //    }
 //    
 //    /*========== Set Manager Reader/Writer test ==========*/
 //    [Fact]
 //    public void SetManagerReaderTest()
 //    {
 //        var manager = new Model.Manager(new DbReader(), new DbWriter());
 //        manager.SetReader(new DbReader());
 //        Assert.NotNull(manager);
 //    }
 //    
 //    [Fact]
 //    public void SetManagerWriterTest()
 //    {
 //        var manager = new Model.Manager(new DbReader(), new DbWriter());
 //        manager.SetWriter(new DbWriter());
 //        Assert.NotNull(manager);
 //    }
 //    
 //    /*========== Players test ==========*/
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadAllPlayer(IReader reader, int page, int pageSize, Player[] players)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadAllPlayer(page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayersByFirstName(IReader reader, string firstName, Player[] players, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByFirstName(firstName, page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayerByLastName(IReader reader, string lastName, Player[] players, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByLastName(lastName, page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayerByNickname(IReader reader, string nickname, Player[] players, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByNickname(nickname, page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayerByFirstNameAndLastName(IReader reader, string firstName, string lastName, Player[] players,
 //        int page,
 //        int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize))?.ToList() ?? new List<Player>();
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayerByFirstNameAndNickname(IReader reader, string firstName, string nickname, Player[] players,
 //        int page,
 //        int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayerByLastNameAndNickname(IReader reader, string lastName, string nickname, Player[] players, int page,
 //        int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
 //    public async Task TestLoadPlayersByGroup(IReader reader, Group group, Player[] players, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var playersFound = (await manager.LoadPlayersByGroup(group))?.ToList() ?? new List<Player>();
 //
 //        Assert.Equal(playersFound.Count, players.Length);
 //        Assert.Equal(playersFound, players);
 //    }
 //    /*========== End players test ==========*/
 //
 //
 //    /*========== Group test ==========*/
 //    [Theory]
 //    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
 //    public async Task TestLoadGroupsByName(IReader reader, string name, Group group)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var groupFound = (await manager.LoadGroupsByName(name));
 //
 //        Assert.Equal(groupFound, group);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
 //    public async Task TestLoadGroupsByPlayer(IReader reader, Player player, Group[] groups, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var groupFound = (await manager.LoadGroupsByPlayer(player, page, pageSize))?.ToList() ?? new List<Group>();
 //
 //        Assert.Equal(groupFound.Count, groups.Length);
 //        Assert.Equal(groupFound, groups);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
 //    public async Task TestLoadAllGroups(IReader reader, Group[] groups, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var groupFound = (await manager.LoadAllGroups(page, pageSize))?.ToList() ?? new List<Group>();
 //
 //        Assert.Equal(groupFound.Count, groups.Length);
 //        Assert.Equal(groupFound, groups);
 //    }
 //    /*========== End group test ==========*/
 //
 //
 //    /*========== Rule test ==========*/
 //    [Theory]
 //    [MemberData(nameof(RuleTestData.Data_TestLoadRule), MemberType = typeof(RuleTestData))]
 //    public async Task TestLoadRule(string name, IRules rule)
 //    {
 //        var stub = new Stub();
 //        var ruleFound = await stub.LoadRule(name);
 //
 //        Assert.Equal(ruleFound, rule);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(RuleTestData.Data_TestLoadAllRules), MemberType = typeof(RuleTestData))]
 //    public async Task TestLoadAllRules(IRules[] rules, int page, int pageSize)
 //    {
 //        var stub = new Stub();
 //        var rulesFound = (await stub.LoadAllRules(page, pageSize)).ToList();
 //
 //        Assert.Equal(rulesFound.Count, rules.Length);
 //        Assert.Equal(rulesFound, rules);
 //    }
 //    /*========== End rule test ==========*/
 //
 //
 //    /*========== Hand test ==========*/
 //    [Theory]
 //    [MemberData(nameof(HandTestData.Data_TestLoadHandByGame), MemberType = typeof(HandTestData))]
 //    public async Task TestLoadHandByGame(IReader reader, Game game, List<KeyValuePair<int, Hand>> hands, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var handsFound = (await manager.LoadHandByGame(game, page, pageSize))?.ToList() ?? new List<KeyValuePair<int, Hand>>();
 //
 //        Assert.Equal(handsFound.Count, hands.Count);
 //        Assert.Equal(handsFound, hands);
 //    }
 //
 //    [Fact]
 //    public void TestCreateHand()
 //    {
 //        var manager = new Model.Manager(new DbReader(), new DbWriter());
 //        var hand = new Hand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
 //            false, true, PetitResults.Lost, Chelem.Unknown,
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
 //                (Biddings.Garde, Poignee.Simple)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(
 //                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
 //                (Biddings.Opponent, Poignee.None)));
 //        var handCreateByManager = manager.CreateHand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
 //            false, true, PetitResults.Lost, Chelem.Unknown,
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
 //                (Biddings.Garde, Poignee.Simple)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(
 //                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
 //                (Biddings.Opponent, Poignee.None)),
 //            new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
 //                (Biddings.Opponent, Poignee.None)));
 //        
 //        Assert.Equal(hand, handCreateByManager);
 //    }
 //    
 //    /*========== End hand test ==========*/
 //
 //
 //    /*========== Game test ==========*/
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadAllGames(IReader reader, Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
 //        var gamesFound = (await manager.LoadAllGames(page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByGroup(IReader reader, Group group, Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByGroup(group, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByPlayer(IReader reader, Player player, Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByPlayer(player, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByName(IReader reader, string name, Game? game)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gameFound = await manager.LoadGameByName(name);
 //
 //        Assert.Equal(gameFound, game);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByStartDate(IReader reader, DateTime startDate, Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByStartDate(startDate, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByEndDate(IReader reader, DateTime endDate, Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByEndDate(endDate, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByDateInterval(IReader reader, DateTime startDate, DateTime endDate, Game[] games, int page,
 //        int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByDateInterval(startDate, endDate, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByDateIntervalAndGroup(IReader reader, DateTime startDate, DateTime endDate, Group group,
 //        Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound = (await manager.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize))
 //            ?.ToList() ?? new List<Game>();
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //
 //    [Theory]
 //    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
 //    public async Task TestLoadGameByDateIntervalAndPlayer(IReader reader, DateTime startDate, DateTime endDate, Player player,
 //        Game[] games, int page, int pageSize)
 //    {
 //        var manager = new Model.Manager(reader, new DbWriter());
	//     var gamesFound =
 //            (await manager.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize))?.ToList() ?? new List<Game>();
 //
 //        Assert.Equal(gamesFound.Count, games.Length);
 //        Assert.Equal(gamesFound, games);
 //    }
 //    
 //    	[Theory]
	// [MemberData(nameof(SaverTestData.Data_TestSavePlayer), MemberType = typeof(SaverTestData))]
	// internal async Task TestSavePlayer(IWriter writer, Player player, Player? expPlayer, PlayerEntity? expEntity)
	// {
 //        var manager = new Model.Manager(new DbReader(), writer);
	// 	var result = await manager.SavePlayer(player);
	// 	Assert.Equal(expPlayer, result);
 //
	// 	if (expEntity != null)
	// 	{
	// 		if (writer is not DbWriter dbSaver) return;
 //
	// 		await using var context =
	// 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
	// 		var entity = await context.Players
	// 			.Include(p => p.Games)
	// 			.Include(p => p.Groups)
	// 			.Include(p => p.Biddings)
	// 			.FirstOrDefaultAsync(p => p.Id == expEntity.Id);
 //
 //
	// 		Assert.NotNull(entity);
	// 		Assert.Equal(expEntity.Id, entity.Id);
	// 		Assert.Equal(expEntity.FirstName, entity.FirstName);
	// 		Assert.Equal(expEntity.LastName, entity.LastName);
	// 		Assert.Equal(expEntity.Nickname, entity.Nickname);
	// 		Assert.Equal(expEntity.Avatar, entity.Avatar);
	// 	}
	// }
 //
	// [Theory]
	// [MemberData(nameof(SaverTestData.Data_TestSaveGroup), MemberType = typeof(SaverTestData))]
	// internal async Task TestSaveGroup(IWriter writer, Group group, Group? expGroup, GroupEntity? expEntity)
 //    {
 //        var manager = new Model.Manager(new DbReader(), writer);
	// 	var result = await manager.SaveGroup(group);
	// 	Assert.Equal(expGroup, result);
 //
	// 	if (expEntity != null)
	// 	{
	// 		if (writer is not DbWriter dbSaver) return;
 //
	// 		await using var context =
	// 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
	// 		var entity = await context.Groups
	// 			.Include(g => g.Players)
	// 			.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
	// 		
	// 		Assert.NotNull(entity);
	// 		Assert.Equal(expEntity.Id, entity.Id);
	// 		Assert.Equal(expEntity.Name, entity.Name);
	// 	}
	// }
 //
	// [Theory]
	// [MemberData(nameof(SaverTestData.Data_TestSaveGame), MemberType = typeof(SaverTestData))]
	// internal async Task TestSaveGame(IWriter writer, Game game, Game? expGame, GameEntity? expEntity)
	// {
 //        var manager = new Model.Manager(new DbReader(), writer);
	// 	var result = await manager.SaveGame(game);
	// 	Assert.Equal(expGame, result);
 //
	// 	if (expEntity != null)
	// 	{
	// 		if (writer is not DbWriter dbSaver) return;
 //
	// 		await using var context =
	// 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
	// 		var entity = await context.Games
	// 			.Include(g => g.Players)
	// 			.Include(g => g.Hands)
	// 			.Include(g => g.Players)
	// 			.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
	// 		
	// 		Assert.NotNull(entity);
	// 		Assert.Equal(expEntity.Id, entity.Id);
	// 		Assert.Equal(expEntity.Name, entity.Name);
	// 		Assert.Equal(expEntity.Rules, entity.Rules);
	// 		Assert.Equal(expEntity.StartDate, entity.StartDate);
	// 		Assert.Equal(expEntity.EndDate, entity.EndDate);
	// 	}
	// }
}