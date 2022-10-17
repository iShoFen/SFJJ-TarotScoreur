using Model;
using Model.games;
using StubLib;
using Xunit;

namespace UT_Stub;

public class UT_Stub
{
    /*========== Players test ==========*/
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
    public void TestLoadAllPlayer(int page, int pageSize, Player[] players)
    {
        var stub = new Stub();
        var playersFound = stub.LoadAllPlayer(page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count(), players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayersByFirstName(string firstName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstName(firstName, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByLastName(string lastName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByLastName(lastName, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByNickname(string nickname, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByNickname(nickname, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByFirstNameAndLastName(string firstName, string lastName, Player[] players, int page, 
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByFirstNameAndNickname(string firstName, string nickname, Player[] players, int page, 
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByLastNameAndNickname(string lastName, string nickname, Player[] players, int page, 
        int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayersByGroup(Group group, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayersByGroup(group, page, pageSize).Result.ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    /*========== End players test ==========*/
    
    
    /*========== Group test ==========*/
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public void TestLoadGroupsByName(string name, Group group)
    {
        var stub = new Stub();
        var groupFound = stub.LoadGroupsByName(name).Result;

        Assert.Equal(groupFound, group);
    }
    
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public void TestLoadGroupsByPlayer(Player player, Group[] groups, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = stub.LoadGroupsByPlayer(player, page,  pageSize).Result.ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }
    
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public void TestLoadAllGroups(Group[] groups, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = stub.LoadAllGroups(page,  pageSize).Result.ToList();

        Assert.Equal(groupFound.Count, groups.Length);
        Assert.Equal(groupFound, groups);
    }
    /*========== End group test ==========*/
    
    
    /*========== Rule test ==========*/
    [Theory]
    [MemberData(nameof(RuleTestData.Data_TestLoadRule), MemberType = typeof(RuleTestData))]
    public void TestLoadRule(string name, IRules rule)
    {
        var stub = new Stub();
        var ruleFound = stub.LoadRule(name).Result;

        Assert.Equal(ruleFound, rule);
    }
    
    [Theory]
    [MemberData(nameof(RuleTestData.Data_TestLoadAllRules), MemberType = typeof(RuleTestData))]
    public void TestLoadAllRules(IRules[] rules, int page, int pageSize)
    {
        var stub = new Stub();
        var rulesFound = stub.LoadAllRules(page, pageSize).Result.ToList();

        Assert.Equal(rulesFound.Count, rules.Length);
        Assert.Equal(rulesFound, rules);
    }
    /*========== End rule test ==========*/
    
    
    /*========== Hand test ==========*/
    [Theory]
    [MemberData(nameof(HandTestData.Data_TestLoadHandByGame), MemberType = typeof(HandTestData))]
    public void TestLoadHandByGame(Game game, List<KeyValuePair<int, Hand>> hands, int page, int pageSize)
    {
        var stub = new Stub();
        var handsFound = stub.LoadHandByGame(game, page, pageSize).Result.ToList();

        Assert.Equal(handsFound.Count, hands.Count);
        Assert.Equal(handsFound, hands);
    }
    /*========== End hand test ==========*/
    
    
    /*========== Game test ==========*/
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadAllGames), MemberType = typeof(GameTestData))]
    public void TestLoadAllGames(Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadAllGames(page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByGroup), MemberType = typeof(GameTestData))]
    public void TestLoadGameByGroup(Group group, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByGroup(group, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByPlayer), MemberType = typeof(GameTestData))]
    public void TestLoadGameByPlayer(Player player, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByPlayer(player, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.LoadGameByName), MemberType = typeof(GameTestData))]
    public void TestLoadGameByName(string name, Game? game)
    {
        var stub = new Stub();
        var gameFound = stub.LoadGameByName(name).Result;

        Assert.Equal(gameFound, game);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByStartDate), MemberType = typeof(GameTestData))]
    public void TestLoadGameByStartDate(DateTime startDate, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByStartDate(startDate, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByEndDate), MemberType = typeof(GameTestData))]
    public void TestLoadGameByEndDate(DateTime endDate, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByEndDate(endDate, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateInterval), MemberType = typeof(GameTestData))]
    public void TestLoadGameByDateInterval(DateTime startDate, DateTime endDate, Game[] games, int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByDateInterval(startDate, endDate, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndGroup), MemberType = typeof(GameTestData))]
    public void TestLoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate, Group group, Game[] games, 
        int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize).Result.ToList();
        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestLoadGameByDateIntervalAndPlayer), MemberType = typeof(GameTestData))]
    public void TestLoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate, Player player, Game[] games, 
        int page, int pageSize)
    {
        var stub = new Stub();
        var gamesFound = stub.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize).Result.ToList();

        Assert.Equal(gamesFound.Count, games.Length);
        Assert.Equal(gamesFound, games);
    }
}