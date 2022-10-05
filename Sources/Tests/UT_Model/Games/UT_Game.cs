using Model;
using Model.enums;
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
            Game game = new (expId, expName, expRules!, expStartDate, expEndDate);
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
            Assert.Equal(exHand.Key, exHand.Value.Number);
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
            Assert.Equal(exHand.Key, exHand.Value.Number);
            Assert.Equal(exHand.Value, game.Hands[exHand.Key]);
        }
    }

    [Fact]
    public void TestGetScores()
    {
        Game game = new ("Test", new FrenchTarotRules(), DateTime.Now);
        game.AddHand(new Hand(1, new FrenchTarotRules(), DateTime.Now, 40, true, true, PetitResult.Lost, Chelem.Unknown,
            KeyValuePair.Create(new Player(1UL, "toto", "tata", "toto", ""), (Bidding.Petite, Poignee.Simple)),
            KeyValuePair.Create(new Player(2UL, "titi", "tata", "titi", ""), (Bidding.Opponent, Poignee.None)),
            KeyValuePair.Create(new Player(3UL, "tutu", "tata", "tutu", ""), (Bidding.Opponent, Poignee.None)),
            KeyValuePair.Create(new Player(4UL, "tete", "tata", "tete", ""), (Bidding.Opponent, Poignee.None)),
            KeyValuePair.Create(new Player(5UL, "tata", "tata", "tata", ""), (Bidding.King, Poignee.None))));
        game.AddHand(new Hand(2, new FrenchTarotRules(), DateTime.Now, 60, true, true, PetitResult.Lost, Chelem.Unknown,
            KeyValuePair.Create(new Player(1UL, "toto", "tata", "toto", ""), (Bidding.Garde, Poignee.None)),
            KeyValuePair.Create(new Player(2UL, "titi", "tata", "titi", ""), (Bidding.Opponent, Poignee.None)),
            KeyValuePair.Create(new Player(3UL, "tutu", "tata", "tutu", ""), (Bidding.Opponent, Poignee.None)),
            KeyValuePair.Create(new Player(4UL, "tete", "tata", "tete", ""), (Bidding.Opponent, Poignee.Double)),
            KeyValuePair.Create(new Player(5UL, "tata", "tata", "tata", ""), (Bidding.King, Poignee.None))));

        IEnumerable<IReadOnlyDictionary<Player, int>> scores = new[]
        {
            new Dictionary<Player, int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = -92,
                [new Player(2, "tata", "tata", "tata", "")] = 46,
                [new Player(3, "tutu", "tutu", "tutu", "")] = 46,
                [new Player(4, "titi", "titi", "titi", "")] = 46,
                [new Player(5, "tete", "tete", "tete", "")] = -46

            },
            new Dictionary<Player, int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 236,
                [new Player(2, "tata", "tata", "tata", "")] = -118,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -118,
                [new Player(4, "titi", "titi", "titi", "")] = -118,
                [new Player(5, "tete", "tete", "tete", "")] = 118
            }
        };
        
        Assert.Equal(scores, game.GetScores());
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
