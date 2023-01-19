using Model.Data;
using Model.Games;
using Model.Players;
using Xunit;

namespace UT_Writer;

public class UT_Writer
{
    #region Player

    [Theory]
    [MemberData(nameof(PlayerWriterDataTest.InsertPlayerData), MemberType = typeof(PlayerWriterDataTest))]
    public async Task PlayerInsertTest(IWriter writer, Player player, Player? expectedPlayer)
    {
        var result = await writer.InsertPlayer(player);

        if (expectedPlayer is null) Assert.Null(result);
        else Assert.Equal(expectedPlayer, result!, Player.PlayerFullComparer);
    }

    [Theory]
    [MemberData(nameof(PlayerWriterDataTest.UpdatePlayerData), MemberType = typeof(PlayerWriterDataTest))]
    public async Task PlayerUpdateTest(IWriter writer, Player player, Player? expectedPlayer)
    {
        var result = await writer.UpdatePlayer(player);

        if (expectedPlayer is null) Assert.Null(result);
        else Assert.Equal(expectedPlayer, result!, Player.PlayerFullComparer);
    }

    [Theory]
    [MemberData(nameof(PlayerWriterDataTest.DeletePlayerWithObjectData), MemberType = typeof(PlayerWriterDataTest))]
    public async Task PlayerDeleteWithObjectTest(IWriter writer, Player player, bool expectedResult)
    {
        var result = await writer.DeletePlayer(player);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(PlayerWriterDataTest.DeletePlayerWithIdData), MemberType = typeof(PlayerWriterDataTest))]
    public async Task PlayerDeleteWithIdTest(IWriter writer, ulong playerId, bool expectedResult)
    {
        var result = await writer.DeletePlayer(playerId);
        
        Assert.Equal(expectedResult, result);
    }

    #endregion

    #region Group
    
    [Theory]
    [MemberData(nameof(GroupWriterDataTest.InsertGroupData), MemberType = typeof(GroupWriterDataTest))]
    public async Task GroupInsertTest(IWriter writer, Group group, Group? expectedGroup)
    {
        var result = await writer.InsertGroup(group);

        if (expectedGroup is null) Assert.Null(result);
        else Assert.Equal(expectedGroup, result!, Group.GroupFullComparer);
    }
    
    [Theory]
    [MemberData(nameof(GroupWriterDataTest.UpdateGroupData), MemberType = typeof(GroupWriterDataTest))]
    public async Task GroupUpdateTest(IWriter writer, Group group, Group? expectedGroup)
    {
        var result = await writer.UpdateGroup(group);

        if (expectedGroup is null) Assert.Null(result);
        else Assert.Equal(expectedGroup, result!, Group.GroupFullComparer);
    }

    [Theory]
    [MemberData(nameof(GroupWriterDataTest.DeleteGroupWithObjectData), MemberType = typeof(GroupWriterDataTest))]
    public async Task GroupDeleteWithObjectTest(IWriter writer, Group group, bool expectedResult)
    {
        var result = await writer.DeleteGroup(group);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(GroupWriterDataTest.DeleteGroupWithIdData), MemberType = typeof(GroupWriterDataTest))]
    public async Task GroupDeleteWithIdTest(IWriter writer, ulong groupId, bool expectedResult)
    {
        var result = await writer.DeleteGroup(groupId);
        
        Assert.Equal(expectedResult, result);
    }
    
    #endregion

    #region Hand

    #endregion

    #region Game
    
    [Theory]
    [MemberData(nameof(GameWriterDataTest.InsertGameData), MemberType = typeof(GameWriterDataTest))]
    public async Task GameInsertTest(IWriter writer, Game game, Game? expectedGame)
    {
        var result = await writer.InsertGame(game);

        if (expectedGame is null) Assert.Null(result);
        else Assert.Equal(expectedGame, result!, Game.FullComparer);
    }

    #endregion
}