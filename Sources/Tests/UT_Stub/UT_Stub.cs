using Model;
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
        var playersFound = stub.LoadAllPlayer(page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayersByFirstName(string firstName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstName(firstName, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByLastName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByLastName(string lastName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByLastName(lastName, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByNickname(string nickname, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByNickname(nickname, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByFirstNameAndLastName(string firstName, string lastName, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByFirstNameAndNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByFirstNameAndNickname(string firstName, string nickname, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerByLastNameAndNickname), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayerByLastNameAndNickname(string lastName, string nickname, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players);
    }
    
    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByGroup), MemberType = typeof(PlayerTestData))]
    public void TestLoadPlayersByGroup(Group group, Player[] players, int page, int pageSize)
    {
        var stub = new Stub();
        var playersFound = stub.LoadPlayersByGroup(group, page, pageSize).ToList();

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
        var groupFound = stub.LoadGroupsByName(name);

        Assert.Equal(groupFound, group);
    }
    
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public void TestLoadGroupsByPlayer(Player player, Group[] group, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = stub.LoadGroupsByPlayer(player, page,  pageSize).ToList();

        Assert.Equal(groupFound.Count, group.Length);
        Assert.Equal(groupFound, group);
    }
    
    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public void TestLoadAllGroups(Group[] group, int page, int pageSize)
    {
        var stub = new Stub();
        var groupFound = stub.LoadAllGroups(page,  pageSize).ToList();

        Assert.Equal(groupFound.Count, group.Length);
        Assert.Equal(groupFound, group);
    }
}