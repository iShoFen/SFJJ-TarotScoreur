using Model.Data;
using Model.Games;
using Model.Players;
using Xunit;
using static TestUtils.DataManagers;

namespace UT_Model.Manager;

public class UT_Manager
{
    public static IEnumerable<object[]> Data_TestConstructor()
        => Loaders.SelectMany(reader => Writers.Select(writer => new object[] {reader.Get(), writer.Get()}));

    public static IEnumerable<object[]> Data_TestReader()
        => Loaders.Select(reader => new object[] {reader.Get()});

    public static IEnumerable<object[]> Data_TestWriter()
        => Writers.Select(writer => new object[] {writer.Get()});

    [Theory]
    [MemberData(nameof(Data_TestConstructor))]
    public void ConstructorTest(IReader reader, IWriter writer)
    {
        var manager = new Model.Manager(reader, writer);
        Assert.NotNull(manager);
    }

    [Theory]
    [MemberData(nameof(Data_TestReader))]
    public void SetManagerReaderTest(IReader reader)
    {
        var manager = new Model.Manager(Loaders[0].Get(), Writers[0].Get());
        manager.SetReader(reader);
        Assert.NotNull(manager);
    }

    [Theory]
    [MemberData(nameof(Data_TestWriter))]
    public void SetManagerWriterTest(IWriter writer)
    {
        var manager = new Model.Manager(Loaders[0].Get(), Writers[0].Get());
        manager.SetWriter(writer);
        Assert.NotNull(manager);
    }

    #region Player
    
    #region Reader
    
    [Theory]
    [MemberData(nameof(UT_Reader.PlayerTestData.Data_TestAllPlayers), MemberType = typeof(UT_Reader.PlayerTestData))]
    public async Task TestGetPlayers(IReader reader, int start, int count, Player[] players)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var playersFound = (await manager.GetPlayers(start, count)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.PlayerTestData.Data_TestPlayerById), MemberType = typeof(UT_Reader.PlayerTestData))]
    public async Task TestGetPlayerById(IReader reader, ulong playerId, Player? expectedPlayer)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var playerFound = await manager.GetPlayerById(playerId);

        if (expectedPlayer is null)
        {
            Assert.Null(playerFound);
        }
        else
        {
            Assert.Equal(expectedPlayer, playerFound, Player.PlayerFullComparer!);
        }

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.PlayerTestData.Data_TestPlayersByPattern),
                MemberType = typeof(UT_Reader.PlayerTestData)
    )]
    public async Task TestGetPlayersByPattern(
        IReader reader,
        string pattern,
        int start,
        int count,
        Player[] expectedPlayers
    )
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var foundPlayers = (await manager.GetPlayersByPattern(pattern, start, count)).ToList();
        Assert.Equal(expectedPlayers.Length, foundPlayers.Count);
        Assert.Equal(expectedPlayers, foundPlayers, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.PlayerTestData.Data_TestPlayersByNickname),
                MemberType = typeof(UT_Reader.PlayerTestData)
    )]
    public async Task TestGetPlayersByNickname(
        IReader reader,
        string nickname,
        int start,
        int count,
        Player[] expectedPlayers
    )
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var playersFound = (await manager.GetPlayersByNickname(nickname, start, count)).ToList();

        Assert.Equal(expectedPlayers.Length, playersFound.Count);
        Assert.Equal(expectedPlayers, playersFound, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.PlayerTestData.Data_TestPlayersByFirstNameAndLastName),
                MemberType = typeof(UT_Reader.PlayerTestData)
    )]
    public async Task TestGetPlayerByFirstNameAndLastName(
        IReader reader,
        string pattern,
        int start,
        int count,
        Player[] expectedPlayers
    )
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var playersFound = (await manager.GetPlayersByFirstNameAndLastName(pattern, start, count)).ToList();

        Assert.Equal(expectedPlayers.Length, playersFound.Count);
        Assert.Equal(expectedPlayers, playersFound, Player.PlayerFullComparer);

        reader.Dispose();
    }
    
    #endregion
    
    #endregion
    
    #region Group

    #region Reader

    [Theory]
    [MemberData(nameof(UT_Reader.GroupTestData.Data_TestGroupsByName), MemberType = typeof(UT_Reader.GroupTestData))]
    public async Task TestGetGroupsByName(IReader reader, string pattern, int start, int count, Group[] groups)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var groupFound = (await manager.GetGroupsByName(pattern, start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GroupTestData.Data_TestGetGroupsByPlayer), MemberType = typeof(UT_Reader.GroupTestData))]
    public async Task TestGetGroupsByPlayer(IReader reader, ulong playerId, int start, int count, Group[] groups)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var groupFound = (await manager.GetGroupsByPlayer(playerId, start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(UT_Reader.GroupTestData))]
    public async Task TestGetGroups(IReader reader, int start, int count, Group[] groups)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var groupFound = (await manager.GetGroups(start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GroupTestData.Data_TestGetGroupById), MemberType = typeof(UT_Reader.GroupTestData))]
    public async Task TestGetGroupById(IReader reader, ulong groupId, Group? group)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var groupFound = await manager.GetGroupById(groupId);

        if (group is null)
        {
            Assert.Null(groupFound);
        }
        else
        {
            Assert.Equal(group, groupFound, Group.GroupFullComparer!);
        }

        reader.Dispose();
    }
    
    #endregion
    
    #endregion
    
    #region Hand

    #region Reader

    [Theory]
    [MemberData(nameof(UT_Reader.HandTestData.Data_TestGetHandById), MemberType = typeof(UT_Reader.HandTestData))]
    public async Task TestGetHandById(IReader reader, ulong handId, Hand? expectedHand)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var handFound = await manager.GetHandById(handId);

        if (expectedHand is null)
        {
            Assert.Null(handFound);
        }
        else
        {
            Assert.Equal(expectedHand, handFound!, Hand.FullComparer);
        }
    }

    #endregion
    
    #endregion
    
    #region Game
    
    
    #region Reader
    
    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGames), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGames(IReader reader, int start, int count, Game[] games)
    {
        var gamesFound = (await reader.GetGames(start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameByPlayer), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameByPlayer(IReader reader, ulong playerId, int start, int count, Game[] games)
    {
        var gamesFound = (await reader.GetGamesByPlayer(playerId, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.GetGameByName), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameByName(IReader reader, string name, int start, int count, Game[] game)
    {
        var gameFound = (await reader.GetGamesByName(name, start, count)).ToList();

        Assert.Equal(game.Length, gameFound.Count);
        Assert.Equal(game, gameFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameByDate), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGamesByDate(IReader reader, DateTime startDate, DateTime? endDate, int start, int count,
        Game[] games)
    {
        var gamesFound = (await reader.GetGamesByDate(startDate, endDate, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameById), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameById(IReader reader, ulong gameId, Game? game)
    {
        var gameFound = await reader.GetGameById(gameId);

        if (game is null)
        {
            Assert.Null(gameFound);
        }
        else
        {
            Assert.Equal(game, gameFound, Game.FullComparer!);
        }

        reader.Dispose();
    }
    
    #endregion
    
    #endregion
}
