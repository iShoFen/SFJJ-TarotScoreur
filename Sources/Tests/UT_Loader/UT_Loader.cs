using Model.Rules;
using Model.Data;
using Model.Games;
using Model.Players;
using StubLib;
using Xunit;

namespace UT_Loader;

public class UT_Loader
{
    /*========== Players test ==========*/
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadAllPlayer(IReader reader, int page, int pageSize, Player[] players)
    {
        var playersFound = (await reader.LoadAllPlayer(page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByFirstName(IReader reader, string firstName, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByFirstName(firstName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastName(IReader reader, string lastName, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByLastName(lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByNickname(IReader reader, string nickname, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByNickname(nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndLastName(IReader reader, string firstName, string lastName, Player[] players,
        int page,
        int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndNickname(IReader reader, string firstName, string nickname, Player[] players,
        int page,
        int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastNameAndNickname(IReader reader, string lastName, string nickname, Player[] players, int page,
        int pageSize)
    {
	    var playersFound = (await reader.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByGroup(IReader reader, Group group, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await reader.LoadPlayersByGroup(group, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    /*========== End players test ==========*/


    /*========== Group test ==========*/
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByName(IReader reader, string name, Group group)
    {
	    var groupFound = await reader.LoadGroupsByName(name);

        Assert.Equal(groupFound, group);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByPlayer(IReader reader, Player player, Group[] groups, int page, int pageSize)
    {
	    var groupFound = (await reader.LoadGroupsByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public async Task TestLoadAllGroups(IReader reader, Group[] groups, int page, int pageSize)
    {
	    var groupFound = (await reader.LoadAllGroups(page, pageSize)).ToList();

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
    public async Task TestLoadHandByGame(IReader reader, Game game, List<KeyValuePair<int, Hand>> hands, int page, int pageSize)
    {
	    var handsFound = (await reader.LoadHandByGame(game, page, pageSize)).ToList();

        Assert.Equal(handsFound.Count, hands.Count);
        Assert.Equal(handsFound, hands);
    }
    /*========== End hand test ==========*/


    /*========== Game test ==========*/
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
    public async Task TestLoadAllGames(IReader reader, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadAllGames(page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByGroup(IReader reader, Group group, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByGroup(group, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByPlayer(IReader reader, Player player, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByName(IReader reader, string name, Game? game)
    {
	    var gameFound = await reader.LoadGameByName(name);

        Assert.Equal(gameFound, game);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByStartDate(IReader reader, DateTime startDate, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByStartDate(startDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByEndDate(IReader reader, DateTime endDate, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByEndDate(endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateInterval(IReader reader, DateTime startDate, DateTime endDate, Game[] games, int page,
        int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByDateInterval(startDate, endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndGroup(IReader reader, DateTime startDate, DateTime endDate, Group group,
        Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await reader.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize))
            .ToList();
        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndPlayer(IReader reader, DateTime startDate, DateTime endDate, Player player,
        Game[] games, int page, int pageSize)
    {
	    var gamesFound =
            (await reader.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
}