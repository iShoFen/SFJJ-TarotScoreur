using System.Collections.ObjectModel;
using Xunit;
using Model;
using Model.enums;

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

    public static IEnumerable<object[]> Data_addHandsToTestValidity()
    {
        yield return new object[]
        {
            true,
            new Hand
                (
                    1L,
                    1,
                    new FrenchTarotRules(),
                    DateTime.Now,
                    40,
                    true,
                    true,
                    PetitResult.Lost,
                    Chelem.Unknown,
                    KeyValuePair.Create(
                        new Player(1, "toto", "tata0", "toto", ""),
                        (Bidding.Petite, Poignee.Simple)),
                    KeyValuePair.Create(
                        new Player(2, "tata", "tata", "tata", ""),
                        (Bidding.Opponent, Poignee.None)),
                    KeyValuePair.Create(
                        new Player(3, "tutu", "tutu", "tutu", ""),
                        (Bidding.Opponent, Poignee.None)),
                    KeyValuePair.Create(
                        new Player(4,"titi","titi","titi",""),
                        (Bidding.Opponent, Poignee.None)),
                    KeyValuePair.Create(
                        new Player(5,"tete","tete","tete","tete"),
                        (Bidding.King, Poignee.None))
                )
        };
        //This hand isn't valid because the player 2's bidding is unknown
        yield return new object[]
        {
            false,
            new Hand
            (
                2L,
                2,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.King, Poignee.None))
            )
        };
        //This hand isn't valid because there is 2 kings
        yield return new object[]
        {
            false,
            new Hand
            (
                3L,
                3,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.King, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.King, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.Opponent, Poignee.None))
            )
        };
        //This hand isn't valid because there is no taker
        yield return new object[]
        {
            false,
            new Hand
            (
                4L,
                4,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Opponent, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.King, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.Opponent, Poignee.None))
            )
        };
        yield return new object[]
        {
            true,
            new Hand
            (
                5L,
                5,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Garde, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.King, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.Opponent, Poignee.None))
            )
        };
        //This hand isn't valid because the Chelem cannot be success if the taker don't have 91 points
        yield return new object[]
        {
            false,
            new Hand
            (
                6L,
                6,
                new FrenchTarotRules(),
                DateTime.Now,
                88,
                true,
                true,
                PetitResult.Owned,
                Chelem.Success,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.King, Poignee.None))
            )
        };
        //This hand isn't valid because the taker have a score grower than 91 points
        yield return new object[]
        {
            false,
            new Hand
            (
                7L,
                7,
                new FrenchTarotRules(),
                DateTime.Now,
                96,
                true,
                true,
                PetitResult.Owned,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.King, Poignee.None))
            )
        };
        //This hand isn't valid because the taker have a negative score
        yield return new object[]
        {
            false,
            new Hand
            (
                8L,
                8,
                new FrenchTarotRules(),
                DateTime.Now,
                -42,
                true,
                true,
                PetitResult.Owned,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata0", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", "tete"),
                    (Bidding.King, Poignee.None))
            )
        };
    }

    public static IEnumerable<object[]> Data_AddHandsToTestScoreValidity()
    {
        //Taker lost bidding with a Poignee
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = -92,
                [new Player(2, "tata", "tata", "tata", "")] = 46,
                [new Player(3, "tutu", "tutu", "tutu", "")] = 46,
                [new Player(4, "titi", "titi", "titi", "")] = 46,
                [new Player(5, "tete", "tete", "tete", "")] = -46
                
            },
            new Hand
            (
                1L,
                1,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //Taker lost bidding with a Poignee and against an other Poignee
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = -132,
                [new Player(2, "tata", "tata", "tata", "")] = 66,
                [new Player(3, "tutu", "tutu", "tutu", "")] = 66,
                [new Player(4, "titi", "titi", "titi", "")] = 66,
                [new Player(5, "tete", "tete", "tete", "")] = -66
                
            },
            new Hand
            (
                2L,
                2,
                new FrenchTarotRules(),
                DateTime.Now,
                40,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.Simple)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //Taker won bidding "Garde" against a Poignee "Double"
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 236,
                [new Player(2, "tata", "tata", "tata", "")] = -118,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -118,
                [new Player(4, "titi", "titi", "titi", "")] = -118,
                [new Player(5, "tete", "tete", "tete", "")] = 118
                
            },
            new Hand
            (
                3L,
                3,
                new FrenchTarotRules(),
                DateTime.Now,
                60,
                true,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Garde, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.Double)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //Taker won bidding "GardeSansLeChien"
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 200,
                [new Player(2, "tata", "tata", "tata", "")] = -100,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -100,
                [new Player(4, "titi", "titi", "titi", "")] = -100,
                [new Player(5, "tete", "tete", "tete", "")] = 100
                
            },
            new Hand
            (
                4L,
                4,
                new FrenchTarotRules(),
                DateTime.Now,
                51,
                false,
                true,
                PetitResult.Lost,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.GardeSansLeChien, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //Not Announced Chelem
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 560,
                [new Player(2, "tata", "tata", "tata", "")] = -280,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -280,
                [new Player(4, "titi", "titi", "titi", "")] = -280,
                [new Player(5, "tete", "tete", "tete", "")] = 280
                
            },
            new Hand
            (
                5L,
                5,
                new FrenchTarotRules(),
                DateTime.Now,
                91,
                true,
                true,
                PetitResult.Owned,
                Chelem.Success,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //This hand isn't valid because the taker did a Chelem but have a score of 88.
        yield return new object[]
        {
            false,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 560,
                [new Player(2, "tata", "tata", "tata", "")] = -280,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -280,
                [new Player(4, "titi", "titi", "titi", "")] = -280,
                [new Player(5, "tete", "tete", "tete", "")] = 280
                
            },
            new Hand
            (
                6L,
                6,
                new FrenchTarotRules(),
                DateTime.Now,
                87,
                true,
                true,
                PetitResult.Owned,
                Chelem.Success,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        //Petit was AuBout
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = 580,
                [new Player(2, "tata", "tata", "tata", "")] = -290,
                [new Player(3, "tutu", "tutu", "tutu", "")] = -290,
                [new Player(4, "titi", "titi", "titi", "")] = -290,
                [new Player(5, "tete", "tete", "tete", "")] = 290
                
            },
            new Hand
            (
                7L,
                7,
                new FrenchTarotRules(),
                DateTime.Now,
                91,
                true,
                true,
                PetitResult.AuBoutOwned,
                Chelem.Success,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
        yield return new object[]
        {
            true,
            new Dictionary<Player,int>
            {
                [new Player(1, "toto", "tata", "toto", "")] = -74,
                [new Player(2, "tata", "tata", "tata", "")] = 37,
                [new Player(3, "tutu", "tutu", "tutu", "")] = 37,
                [new Player(4, "titi", "titi", "titi", "")] = 37,
                [new Player(5, "tete", "tete", "tete", "")] = -37
                
            },
            new Hand
            (
                8L,
                8,
                new FrenchTarotRules(),
                DateTime.Now,
                54,
                false,
                false,
                PetitResult.LostAuBout,
                Chelem.Unknown,
                KeyValuePair.Create(
                    new Player(1, "toto", "tata", "toto", ""),
                    (Bidding.Petite, Poignee.None)),
                KeyValuePair.Create(
                    new Player(2, "tata", "tata", "tata", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(3, "tutu", "tutu", "tutu", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(4, "titi", "titi", "titi", ""),
                    (Bidding.Opponent, Poignee.None)),
                KeyValuePair.Create(
                    new Player(5, "tete", "tete", "tete", ""),
                    (Bidding.King, Poignee.None))
            )

        };
    }

    public static IEnumerable<object?[]> Data_AddRulesTestEquals()
    {
        yield return new object[]
        {
            true,
            new FrenchTarotRules(),
            new FrenchTarotRules()
        };
        yield return new object[]
        {
            false,
            new FrenchTarotRules(),
            new RulesTest()
        };
        var a = new FrenchTarotRules();
        yield return new object[]
        {
            true,
            a,
            a
        };
        yield return new object?[]
        {
            false,
            a,
            null
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
    
    [Theory]
    [MemberData(nameof(Data_addHandsToTestValidity))]
    public void Test_IsHandValid(bool expectedResult,
        Hand hand)
    {
        var result = hand.IsValid();
        Assert.Equal(expectedResult,result);
    }
    
    [Theory]
    [MemberData(nameof(Data_AddHandsToTestScoreValidity))]
    public void Test_IsScoreValid(bool valid, Dictionary<Player,int> expectedScores,
        Hand hand)
    {
        if (valid)
        {
            var result = hand.getScores();
            Assert.Equal(expectedScores.Values,result.Values);
        }
        else
        {
            Assert.Throws<ArgumentException>(() => hand.getScores());
        }

    }

    [Fact]
    public void Test_HashCode()
    {
        Assert.Equal(new FrenchTarotRules().GetHashCode(),new FrenchTarotRules().GetHashCode());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddRulesTestEquals))]
    public void Test_Equals(bool expectedResult, IRules a, IRules b)
    {
        Assert.Equal(expectedResult,a.Equals(b));
    }
}