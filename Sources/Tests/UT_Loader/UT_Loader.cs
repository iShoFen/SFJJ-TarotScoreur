using Model;
using Model.data;
using Model.games;
using StubLib;
using Xunit;

namespace UT_Loader;

public class UT_Loader
{
    /*========== Players test ==========*/
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadAllPlayer(ILoader loader, int page, int pageSize, Player[] players)
    {
        var playersFound = (await loader.LoadAllPlayer(page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByFirstName(ILoader loader, string firstName, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByFirstName(firstName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastName(ILoader loader, string lastName, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByLastName(lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByNickname(ILoader loader, string nickname, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByNickname(nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndLastName(ILoader loader, string firstName, string lastName, Player[] players,
        int page,
        int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndNickname(ILoader loader, string firstName, string nickname, Player[] players,
        int page,
        int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastNameAndNickname(ILoader loader, string lastName, string nickname, Player[] players, int page,
        int pageSize)
    {
	    var playersFound = (await loader.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByGroup(ILoader loader, Group group, Player[] players, int page, int pageSize)
    {
	    var playersFound = (await loader.LoadPlayersByGroup(group, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    /*========== End players test ==========*/


    /*========== Group test ==========*/
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByName(ILoader loader, string name, Group group)
    {
	    var groupFound = await loader.LoadGroupsByName(name);

        Assert.Equal(groupFound, group);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByPlayer(ILoader loader, Player player, Group[] groups, int page, int pageSize)
    {
	    var groupFound = (await loader.LoadGroupsByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public async Task TestLoadAllGroups(ILoader loader, Group[] groups, int page, int pageSize)
    {
	    var groupFound = (await loader.LoadAllGroups(page, pageSize)).ToList();

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
	    var handsFound = (await loader.LoadHandByGame(game, page, pageSize)).ToList();

        Assert.Equal(handsFound.Count, hands.Count);
        Assert.Equal(handsFound, hands);
    }
    /*========== End hand test ==========*/


    /*========== Game test ==========*/
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
    public async Task TestLoadAllGames(ILoader loader, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadAllGames(page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByGroup(ILoader loader, Group group, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByGroup(group, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByPlayer(ILoader loader, Player player, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByName(ILoader loader, string name, Game? game)
    {
	    var gameFound = await loader.LoadGameByName(name);

        Assert.Equal(gameFound, game);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByStartDate(ILoader loader, DateTime startDate, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByStartDate(startDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByEndDate(ILoader loader, DateTime endDate, Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByEndDate(endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateInterval(ILoader loader, DateTime startDate, DateTime endDate, Game[] games, int page,
        int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByDateInterval(startDate, endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndGroup(ILoader loader, DateTime startDate, DateTime endDate, Group group,
        Game[] games, int page, int pageSize)
    {
	    var gamesFound = (await loader.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize))
            .ToList();
        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndPlayer(ILoader loader, DateTime startDate, DateTime endDate, Player player,
        Game[] games, int page, int pageSize)
    {
	    var gamesFound =
            (await loader.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
}