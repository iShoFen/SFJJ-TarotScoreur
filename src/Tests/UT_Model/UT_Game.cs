using Model;
using Model.games;
using Xunit;

namespace UT_Model;

public class UT_Game
{
    
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestFullConstructor), MemberType = typeof(GameTestData))]
    public void TestFullConstructor(bool isValid, ulong expId, string expName, IRules expRules, DateTime expStartDate, DateTime? expEndDate)
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
            Assert.ThrowsAny<ArgumentException>(() => new Game(expId, expName, expRules, expStartDate, expEndDate));
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
    
    /*[Theory]
    [MemberData(nameof(GameTestData.Data_TestAddHand), MemberType = typeof(GameTestData))]
    public void TestAddHand(bool expResult, IEnumerable<KeyValuePair<int, Hand>> exHands, Game game, Hand hand)
    {
        Assert.Equal(expResult, game.AddHand(hand));
        Assert.Equal(exHands, game.Hands);
    }
    
    [Theory]
    [MemberData(nameof(GameTestData.Data_TestAddHands), MemberType = typeof(GameTestData))]
    public void TestAddHands(bool expResult, IEnumerable<KeyValuePair<int, Hand>> exHands, Game game, IEnumerable<Hand> hands)
    {
        Assert.Equal(expResult, game.AddHands(hands.ToArray()));
        Assert.Equal(exHands, game.Hands);
    }*/
}
