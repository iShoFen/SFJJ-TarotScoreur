using Xunit;
using Model;

namespace UT_Model;


public class UT_IRules
{
    public static IEnumerable<object[]> Data_AddGamesWithFrenchTarotRules()
    {
        yield return new object[]
        {
            Validity.Valid,
            new Game
            (1,
                "Game1",
                DateTime.Now,
                null,
                new Player[]
                {
                    new Player(1, "toto", "tata0", "toto", ""),
                    new Player(2, "tata", "tata", "tata", ""),
                    new Player(3, "tutu", "tutu", "tutu", "")
                },
                new List<Hand>()
            ),
            new FrenchTarotRules(),
        };
        yield return new object[]
        {
            Validity.EnoughPlayers,
            new Game
            (2,
                "Game2",
                DateTime.Now,
                null,
                new Player[]
                {
                    new Player(1, "toto", "tata0", "toto", ""),
                    new Player(2, "tata", "tata", "tata", ""),
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    new Player(4,"titi","titi","titi",""),
                    new Player(5,"tete","tete","tete","tete")
                },
                new List<Hand>()
            ),
            new FrenchTarotRules()
        };
        yield return new object[]
        {
            Validity.NotEnoughPlayers,
            new Game
            (3,
                "Game3",
                DateTime.Now,
                null,
                new Player[]
                {
                    new Player(1, "toto", "tata0", "toto", ""),
                    new Player(2, "tata", "tata", "tata", "")
                },
                new List<Hand>()
            ),
            new FrenchTarotRules()
        };
    }
    [Theory]
    [MemberData(nameof(Data_AddGamesWithFrenchTarotRules))]
    public void Test_IsGameValid(Validity expectedResult,
        Game game,
        IRules rule)
    {
        var result = rule.IsGameValid(game);
        Assert.Equal(expectedResult,result);
    }
}