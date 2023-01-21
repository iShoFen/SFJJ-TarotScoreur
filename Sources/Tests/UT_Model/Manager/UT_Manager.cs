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
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(UT_Writer.PlayerWriterDataTest.InsertPlayerData), MemberType = typeof(UT_Writer.PlayerWriterDataTest))]
    public async Task PlayerInsertTest(IWriter writer, Player player, Player? expectedPlayer)
    {
        if (player.Id != 0) return;

        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.InsertPlayer(player.FirstName, player.LastName, player.NickName, player.Avatar);

        if (expectedPlayer is null) Assert.Null(result);
        else Assert.Equal(expectedPlayer, result!, Player.PlayerFullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.PlayerWriterDataTest.UpdatePlayerData), MemberType = typeof(UT_Writer.PlayerWriterDataTest))]
    public async Task PlayerUpdateTest(IWriter writer, Player player, Player? expectedPlayer)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);

        var result = await manager.UpdatePlayer(player);

        if (expectedPlayer is null) Assert.Null(result);
        else Assert.Equal(expectedPlayer, result!, Player.PlayerFullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.PlayerWriterDataTest.DeletePlayerWithObjectData), MemberType = typeof(UT_Writer.PlayerWriterDataTest))]
    public async Task PlayerDeleteWithObjectTest(IWriter writer, Player player, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);

        var result = await manager.DeletePlayer(player);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.PlayerWriterDataTest.DeletePlayerWithIdData), MemberType = typeof(UT_Writer.PlayerWriterDataTest))]
    public async Task PlayerDeleteWithIdTest(IWriter writer, ulong playerId, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeletePlayer(playerId);
        
        Assert.Equal(expectedResult, result);
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
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(UT_Writer.GroupWriterDataTest.InsertGroupData), MemberType = typeof(UT_Writer.GroupWriterDataTest))]
    public async Task GroupInsertTest(IWriter writer, Group group, Group? expectedGroup)
    {
        if (group.Id != 0) return;
        
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.InsertGroup(group.Name, group.Players.ToArray());

        if (expectedGroup is null) Assert.Null(result);
        else Assert.Equal(expectedGroup, result!, Group.GroupFullComparer);
    }
    
    [Theory]
    [MemberData(nameof(UT_Writer.GroupWriterDataTest.UpdateGroupData), MemberType = typeof(UT_Writer.GroupWriterDataTest))]
    public async Task GroupUpdateTest(IWriter writer, Group group, Group? expectedGroup)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.UpdateGroup(group);

        if (expectedGroup is null) Assert.Null(result);
        else Assert.Equal(expectedGroup, result!, Group.GroupFullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.GroupWriterDataTest.DeleteGroupWithObjectData), MemberType = typeof(UT_Writer.GroupWriterDataTest))]
    public async Task GroupDeleteWithObjectTest(IWriter writer, Group group, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteGroup(group);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.GroupWriterDataTest.DeleteGroupWithIdData), MemberType = typeof(UT_Writer.GroupWriterDataTest))]
    public async Task GroupDeleteWithIdTest(IWriter writer, ulong groupId, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteGroup(groupId);
        
        Assert.Equal(expectedResult, result);
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
    
    #region Writer
    
    [Theory]
    [MemberData(nameof(UT_Writer.HandWriterDataTest.InsertHandData), MemberType = typeof(UT_Writer.HandWriterDataTest))]
    public async Task HandInsertTest(IWriter writer, ulong gameId, Hand hand, Hand? expectedHand)
    {
        if (hand.Id != 0) return;
        
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result =
            await manager.InsertHand(gameId,
                                     hand.Number,
                                     hand.Rules,
                                     hand.Date,
                                     hand.TakerScore,
                                     hand.TwentyOne,
                                     hand.Excuse,
                                     hand.Petit,
                                     hand.Chelem,
                                     hand.Biddings.ToArray()
            );

        if (expectedHand is null) Assert.Null(result);
        else Assert.Equal(expectedHand, result!, Hand.FullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.HandWriterDataTest.UpdateHandData), MemberType = typeof(UT_Writer.HandWriterDataTest))]
    public async Task HandUpdateTest(IWriter writer, Hand hand, Hand? expectedHand)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.UpdateHand(hand);

        if (expectedHand is null) Assert.Null(result);
        else Assert.Equal(expectedHand, result!, Hand.FullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.HandWriterDataTest.DeleteHandWithObjectData), MemberType = typeof(UT_Writer.HandWriterDataTest))]
    public async Task HandDeleteWithObjectTest(IWriter writer, Hand hand, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteHand(hand);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.HandWriterDataTest.DeleteHandWithIdData), MemberType = typeof(UT_Writer.HandWriterDataTest))]
    public async Task HandDeleteWithIdTest(IWriter writer, ulong handId, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteHand(handId);
        
        Assert.Equal(expectedResult, result);
    }
    
    #endregion
    
    #endregion
    
    #region Game
    
    #region Reader
    
    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGames), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGames(IReader reader, int start, int count, Game[] games)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var gamesFound = (await manager.GetGames(start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameByPlayer), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameByPlayer(IReader reader, ulong playerId, int start, int count, Game[] games)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var gamesFound = (await manager.GetGamesByPlayer(playerId, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.GetGameByName), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameByName(IReader reader, string name, int start, int count, Game[] game)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var gameFound = (await manager.GetGamesByName(name, start, count)).ToList();

        Assert.Equal(game.Length, gameFound.Count);
        Assert.Equal(game, gameFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameByDate), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGamesByDate(IReader reader, DateTime startDate, DateTime? endDate, int start, int count,
        Game[] games)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var gamesFound = (await manager.GetGamesByDate(startDate, endDate, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(UT_Reader.GameTestData.Data_TestGetGameById), MemberType = typeof(UT_Reader.GameTestData))]
    public async Task TestGetGameById(IReader reader, ulong gameId, Game? game)
    {
        Model.Manager manager = new(reader, Writers[0].Get());
        var gameFound = await manager.GetGameById(gameId);

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

    #region Writer
    
    [Theory]
    [MemberData(nameof(GameInsertData.InsertGameData), MemberType = typeof(GameInsertData))]
    public async Task GameInsertTest(IWriter writer, Game game, Game? expectedGame)
    {
        if (game.Id != 0) return;
        
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.InsertGame(game.Name, game.Rules, game.StartDate, game.Players.ToArray());

        if (expectedGame is null) Assert.Null(result);
        else Assert.Equal(expectedGame, result!, Game.FullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.GameWriterDataTest.UpdateGameData), MemberType = typeof(UT_Writer.GameWriterDataTest))]
    public async Task GameUpdateTest(IWriter writer, Game game, Game? expectedGame)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.UpdateGame(game);

        if (expectedGame is null) Assert.Null(result);
        else Assert.Equal(expectedGame, result!, Game.FullComparer);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.GameWriterDataTest.DeleteGameWithObjectData), MemberType = typeof(UT_Writer.GameWriterDataTest))]
    public async Task GameDeleteWithObjectTest(IWriter writer, Game game, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteGame(game);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(UT_Writer.GameWriterDataTest.DeleteGameWithIdData), MemberType = typeof(UT_Writer.GameWriterDataTest))]
    public async Task GameDeleteWithIdTest(IWriter writer, ulong gameId, bool expectedResult)
    {
        Model.Manager manager = new(Loaders[0].Get(), writer);
        var result = await manager.DeleteGame(gameId);
        
        Assert.Equal(expectedResult, result);
    }
    
    #endregion
    
    #endregion
}
