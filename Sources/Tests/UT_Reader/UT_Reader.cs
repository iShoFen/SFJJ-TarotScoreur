using Model.Data;
using Model.Games;
using Model.Players;
using Xunit;

namespace UT_Reader;

public class UT_Reader
{
    #region Player

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestAllPlayers), MemberType = typeof(PlayerTestData))]
    public async Task TestGetPlayers(IReader reader, int start, int count, Player[] players)
    {
        var playersFound = (await reader.GetPlayers(start, count)).ToList();

        Assert.Equal(playersFound.Count, players.Length);
        Assert.Equal(playersFound, players, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayerById), MemberType = typeof(PlayerTestData))]
    public async Task TestGetPlayerById(IReader reader, ulong playerId, Player? expectedPlayer)
    {
        var player = await reader.GetPlayerById(playerId);

        if (expectedPlayer is null)
        {
            Assert.Null(player);
        }
        else
        {
            Assert.Equal(expectedPlayer, player, Player.PlayerFullComparer!);
        }

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByPattern), MemberType = typeof(PlayerTestData))]
    public async Task TestGetPlayersByPattern(IReader reader, string pattern, int start, int count,
        Player[] expectedPlayers)
    {
        var foundPlayers = (await reader.GetPlayersByPattern(pattern, start, count)).ToList();
        Assert.Equal(expectedPlayers.Length, foundPlayers.Count);
        Assert.Equal(expectedPlayers, foundPlayers, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByNickname), MemberType = typeof(PlayerTestData))]
    public async Task TestGetPlayersByNickname(IReader reader, string nickname, int start, int count,
        Player[] expectedPlayers)
    {
        var playersFound = (await reader.GetPlayersByNickname(nickname, start, count)).ToList();

        Assert.Equal(expectedPlayers.Length, playersFound.Count);
        Assert.Equal(expectedPlayers, playersFound, Player.PlayerFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(PlayerTestData.Data_TestPlayersByFirstNameAndLastName), MemberType = typeof(PlayerTestData))]
    public async Task TestGetPlayerByFirstNameAndLastName(IReader reader, string pattern, int start, int count,
        Player[] expectedPlayers)
    {
        var playersFound = (await reader.GetPlayersByFirstNameAndLastName(pattern, start, count)).ToList();

        Assert.Equal(expectedPlayers.Length, playersFound.Count);
        Assert.Equal(expectedPlayers, playersFound, Player.PlayerFullComparer);

        reader.Dispose();
    }

    #endregion

    #region Group

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGroupsByName), MemberType = typeof(GroupTestData))]
    public async Task TestGetGroupsByName(IReader reader, string pattern, int start, int count, Group[] groups)
    {
        var groupFound = (await reader.GetGroupsByName(pattern, start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGetGroupsByPlayer), MemberType = typeof(GroupTestData))]
    public async Task TestGetGroupsByPlayer(IReader reader, ulong playerId, int start, int count, Group[] groups)
    {
        var groupFound = (await reader.GetGroupsByPlayer(playerId, start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestLoadAllGroups), MemberType = typeof(GroupTestData))]
    public async Task TestGetGroups(IReader reader, int start, int count, Group[] groups)
    {
        var groupFound = (await reader.GetGroups(start, count)).ToList();

        Assert.Equal(groups.Length, groupFound.Count);
        Assert.Equal(groups, groupFound, Group.GroupFullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestGetGroupById), MemberType = typeof(GroupTestData))]
    public async Task TestGetGroupById(IReader reader, ulong groupId, Group? group)
    {
        var groupFound = await reader.GetGroupById(groupId);

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

    #region Hand

    [Theory]
    [MemberData(nameof(HandTestData.Data_TestGetHandById), MemberType = typeof(HandTestData))]
    public async Task TestGetHandById(IReader reader, ulong handId, Hand? expectedHand)
    {
        var handFound = await reader.GetHandById(handId);

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

    #region Game

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestGetGames), MemberType = typeof(GameTestData))]
    public async Task TestGetGames(IReader reader, int start, int count, Game[] games)
    {
        var gamesFound = (await reader.GetGames(start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestGetGameByPlayer), MemberType = typeof(GameTestData))]
    public async Task TestGetGameByPlayer(IReader reader, ulong playerId, int start, int count, Game[] games)
    {
        var gamesFound = (await reader.GetGamesByPlayer(playerId, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GameTestData.GetGameByName), MemberType = typeof(GameTestData))]
    public async Task TestGetGameByName(IReader reader, string name, int start, int count, Game[] game)
    {
        var gameFound = (await reader.GetGamesByName(name, start, count)).ToList();

        Assert.Equal(game.Length, gameFound.Count);
        Assert.Equal(game, gameFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestGetGameByDate), MemberType = typeof(GameTestData))]
    public async Task TestGetGamesByDate(IReader reader, DateTime startDate, DateTime? endDate, int start, int count,
        Game[] games)
    {
        var gamesFound = (await reader.GetGamesByDate(startDate, endDate, start, count)).ToList();

        Assert.Equal(games.Length, gamesFound.Count);
        Assert.Equal(games, gamesFound, Game.FullComparer);

        reader.Dispose();
    }

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestGetGameById), MemberType = typeof(GameTestData))]
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
}