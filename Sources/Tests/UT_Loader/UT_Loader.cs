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
    public async Task TestLoadPlayersByFirstName(string firstName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByFirstName(firstName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastName(string lastName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByLastName(lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByNickname(string nickname, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByNickname(nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndLastName(string firstName, string lastName, Player[] players,
        int page,
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByFirstNameAndNickname(string firstName, string nickname, Player[] players,
        int page,
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayerByLastNameAndNickname(string lastName, string nickname, Player[] players, int page,
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public async Task TestLoadPlayersByGroup(Group group, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = (await stub.LoadPlayersByGroup(group, page, pageSize)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    /*========== End players test ==========*/


    /*========== Group test ==========*/
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByName(string name, Group group)
    {
        var stub = new Stub();
        var groupFound = await stub.LoadGroupsByName(name);

        Assert.Equal(groupFound, group);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public async Task TestLoadGroupsByPlayer(Player player, Group[] groups, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = (await stub.LoadGroupsByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public async Task TestLoadAllGroups(Group[] groups, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = (await stub.LoadAllGroups(page, pageSize)).ToList();

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
    public async Task TestLoadHandByGame(Game game, List<KeyValuePair<int, Hand>> hands, int page, int pageSize)
    {
        var stub = new Stub();
        var handsFound = (await stub.LoadHandByGame(game, page, pageSize)).ToList();

        Assert.Equal(handsFound.Count, hands.Count);
        Assert.Equal(handsFound, hands);
    }
    /*========== End hand test ==========*/


    /*========== Game test ==========*/
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
    public async Task TestLoadAllGames(Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadAllGames(page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByGroup(Group group, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByGroup(group, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByPlayer(Player player, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByPlayer(player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByName(string name, Game? game)
    {
        var stub = new Stub();
        var gameFound = await stub.LoadGameByName(name);

        Assert.Equal(gameFound, game);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByStartDate(DateTime startDate, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByStartDate(startDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByEndDate(DateTime endDate, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByEndDate(endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateInterval(DateTime startDate, DateTime endDate, Game[] games, int page,
        int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByDateInterval(startDate, endDate, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate, Group group,
        Game[] games,
        int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = (await stub.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize))
            .ToList();
        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
    public async Task TestLoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate, Player player,
        Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound =
            (await stub.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize)).ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
}