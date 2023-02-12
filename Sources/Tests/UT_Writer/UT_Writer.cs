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

    #region User

    [Theory]
    [MemberData(nameof(UserWriterDataTest.InsertUserData), MemberType = typeof(UserWriterDataTest))]
    public async Task UserInsertTest(IWriter writer, User user, User? expectedUser)
    {
        var result = await writer.InsertUser(user);

        if (expectedUser is null) Assert.Null(result);
        else Assert.Equal(expectedUser, result!, User.UserFullComparer);
    }

    [Theory]
    [MemberData(nameof(UserWriterDataTest.UpdateUserData), MemberType = typeof(UserWriterDataTest))]
    public async Task UserUpdateTest(IWriter writer, User user, User? expectedUser)
    {
        var result = await writer.UpdateUser(user);

        if (expectedUser is null) Assert.Null(result);
        else Assert.Equal(expectedUser, result!, User.UserFullComparer);
    }

    [Theory]
    [MemberData(nameof(UserWriterDataTest.DeleteUserWithObjectData), MemberType = typeof(UserWriterDataTest))]
    public async Task UserDeleteWithObjectTest(IWriter writer, User user, bool expectedResult)
    {
        var result = await writer.DeleteUser(user);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(UserWriterDataTest.DeleteUserWithIdData), MemberType = typeof(UserWriterDataTest))]
    public async Task UserDeleteWithIdTest(IWriter writer, ulong userId, bool expectedResult)
    {
        var result = await writer.DeleteUser(userId);
        
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

    [Theory]
    [MemberData(nameof(HandWriterDataTest.InsertHandData), MemberType = typeof(HandWriterDataTest))]
    public async Task HandInsertTest(IWriter writer, ulong gameId, Hand hand, Hand? expectedHand)
    {
        var result = await writer.InsertHand(gameId, hand);

        if (expectedHand is null) Assert.Null(result);
        else Assert.Equal(expectedHand, result!, Hand.FullComparer);
    }

    [Theory]
    [MemberData(nameof(HandWriterDataTest.UpdateHandData), MemberType = typeof(HandWriterDataTest))]
    public async Task HandUpdateTest(IWriter writer, Hand hand, Hand? expectedHand)
    {
        var result = await writer.UpdateHand(hand);

        if (expectedHand is null) Assert.Null(result);
        else Assert.Equal(expectedHand, result!, Hand.FullComparer);
    }

    [Theory]
    [MemberData(nameof(HandWriterDataTest.DeleteHandWithObjectData), MemberType = typeof(HandWriterDataTest))]
    public async Task HandDeleteWithObjectTest(IWriter writer, Hand hand, bool expectedResult)
    {
        var result = await writer.DeleteHand(hand);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(HandWriterDataTest.DeleteHandWithIdData), MemberType = typeof(HandWriterDataTest))]
    public async Task HandDeleteWithIdTest(IWriter writer, ulong handId, bool expectedResult)
    {
        var result = await writer.DeleteHand(handId);
        
        Assert.Equal(expectedResult, result);
    }

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

    [Theory]
    [MemberData(nameof(GameWriterDataTest.UpdateGameData), MemberType = typeof(GameWriterDataTest))]
    public async Task GameUpdateTest(IWriter writer, Game game, Game? expectedGame)
    {
        var result = await writer.UpdateGame(game);

        if (expectedGame is null) Assert.Null(result);
        else Assert.Equal(expectedGame, result!, Game.FullComparer);
    }

    [Theory]
    [MemberData(nameof(GameWriterDataTest.DeleteGameWithObjectData), MemberType = typeof(GameWriterDataTest))]
    public async Task GameDeleteWithObjectTest(IWriter writer, Game game, bool expectedResult)
    {
        var result = await writer.DeleteGame(game);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(GameWriterDataTest.DeleteGameWithIdData), MemberType = typeof(GameWriterDataTest))]
    public async Task GameDeleteWithIdTest(IWriter writer, ulong gameId, bool expectedResult)
    {
        var result = await writer.DeleteGame(gameId);
        
        Assert.Equal(expectedResult, result);
    }

    #endregion
}