using Model;
using Model.games;
using Xunit;

namespace UT_Model.Games;

public class UT_Game
{
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestFullConstructor), MemberType = typeof(GameTestData))]
    public void TestFullConstructor(bool isValid, ulong expId, string expName, IRules? expRules, DateTime expStartDate, DateTime? expEndDate)
    {
        if (isValid)
        {
            Game game = new (expId, expName, expRules, expStartDate, expEndDate);
            Assert.Equal(expId, game.Id);
            Assert.Equal(expName, game.Name);
            Assert.Equal(expRules, game.Rules);
            Assert.Equal(expStartDate, game.StartDate);
            Assert.Equal(expEndDate, game.EndDate);
            Assert.Empty(game.Players);
            Assert.Empty(game.Hands);
        }
        else
        {
            Assert.ThrowsAny<ArgumentException>(() => new Game(expId, expName, expRules!, expStartDate, expEndDate));
        }
    }
    
    [Fact]
    public void TestConstructor()
    {
        const ulong expId = 0;
        const string expName = "Test";
        IRules expRules = new FrenchTarotRules();
        var expStartDate = DateTime.Now;
        Game game = new (expName, expRules, expStartDate);
        
        Assert.Equal(expId, game.Id);
        Assert.Equal(expName, game.Name);
        Assert.Equal(expRules, game.Rules);
        Assert.Equal(expStartDate, game.StartDate);
        Assert.Null(game.EndDate);
        Assert.Empty(game.Players);
        Assert.Empty(game.Hands);
    } 
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestAddPlayer), MemberType = typeof(GameTestData))]
    public void TestAddPlayer(bool expResult, IEnumerable<Player> exPlayers, Game game, Player player)
    {
        Assert.Equal(expResult, game.AddPlayer(player));
        Assert.Equal(exPlayers, game.Players);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestAddPlayers), MemberType = typeof(GameTestData))]
    public void TestAddPlayers(bool expResult, IEnumerable<Player> exPlayers, Game game, IEnumerable<Player> players)
    {
        Assert.Equal(expResult, game.AddPlayers(players.ToArray()));
        Assert.Equal(exPlayers, game.Players);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestAddHand), MemberType = typeof(GameTestData))]
    public void TestAddHand(bool expResult, IEnumerable<KeyValuePair<int, Hand>> exHands, Game game, Hand hand)
    {
        Assert.Equal(expResult, game.AddHand(hand));
        foreach (var exHand in exHands)
        {
            Assert.Equal(exHand.Key, exHand.Value.HandNumber);
            Assert.Equal(exHand.Value, game.Hands[exHand.Key]);
        }
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestAddHands), MemberType = typeof(GameTestData))]
    public void TestAddHands(bool expResult, IEnumerable<KeyValuePair<int, Hand>> exHands, Game game, params Hand[] hands)
    {
        Assert.Equal(expResult, game.AddHands(hands));
        foreach (var exHand in exHands)
        {
            Assert.Equal(exHand.Key, exHand.Value.HandNumber);
            Assert.Equal(exHand.Value, game.Hands[exHand.Key]);
        }
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestHashCode), MemberType = typeof(GameTestData))]
    public void TestHashCode(bool expResult, Game game1, Game game2) =>
        Assert.Equal(expResult, game1.GetHashCode() == game2.GetHashCode());

    [Theory]
    [MemberData(nameof(GameTestData.Data_TestEquals), MemberType = typeof(GameTestData))]
    public void TestEquals(bool expResult, Game game, object? game2) =>
        Assert.Equal(expResult, game.Equals(game2));

    [Fact]
    public void TestEquals_Null_Type_Ref()
    {
        Game game = new("Test", new FrenchTarotRules(), DateTime.Now);
        Assert.False(Game.FullComparer.Equals(game, null));
        Assert.False(Game.FullComparer.Equals(null, game));
        Assert.False(game!.Equals(null));
        Assert.False(game!.Equals(new object()));
        Assert.True(game!.Equals(game as object));
    }
}
