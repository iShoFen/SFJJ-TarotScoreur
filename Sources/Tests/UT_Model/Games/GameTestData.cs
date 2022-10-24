using System.Globalization;
using Model.Rules;
using Model.Enums;
using Model.Games;
using Model.Players;
using TestUtils;

namespace UT_Model.Games;

public static class GameTestData
{
    public static IEnumerable<object?[]> Data_TestFullConstructor()
    {
        yield return new object?[]
        {
            true,
            ulong.MaxValue,
            "good",
            new FrenchTarotRules(),
            DateTime.Now,
            null
        };
        yield return new object?[]
        {
            true,
            null,
            "bad",
            new FrenchTarotRules(),
            DateTime.Now,
            DateTime.MaxValue
        };
        yield return new object?[]
        {
            false,
            2,
            null,
            new FrenchTarotRules(),
            DateTime.MinValue,
            DateTime.Now
        };
        yield return new object?[]
        {
            false,
            3,
            "bad",
            new FrenchTarotRules(),
            DateTime.Now,
            DateTime.MinValue
        };
        yield return new object?[]
        {
            false,
            4,
            "bad",
            new FrenchTarotRules(),
            null,
            DateTime.Now
        };
        yield return new object?[]
        {
            false,
            5,
            "bad",
            null,
            DateTime.MinValue,
            DateTime.Now
        };
    }

    public static IEnumerable<object[]> Data_TestAddPlayer()
    {
        yield return new object[]
        {
            true,
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Player("Florent", "Marques", "Flo", "images")
        };
        yield return new object[]
        {
            true,
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", ""),
                new("Samuel", "Sirven", "Sam", ""),
                new("Julien", "Themes", "Juju", "")
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
                new Player("Florent", "Marques", "Flo", ""), 
                new Player("Jordan", "Artzet", "Jo", ""),
                new Player("Samuel", "Sirven", "Sam", "")),
            new Player("Julien", "Themes", "Juju", "")
        };
        yield return new object[]
        {
            false,
            new[]
            {
                new Player("Florent", "Marques", "Flo", "images"),
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
                new Player("Florent", "Marques", "Flo", "images")),
            new Player("Florent", "Marques", "Flo", "images")
        };
        yield return new object[]
        {
            false,
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", ""),
                new("Samuel", "Sirven", "Sam", "")
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
                new Player("Florent", "Marques", "Flo", ""), 
                new Player("Jordan", "Artzet", "Jo", ""),
                new Player("Samuel", "Sirven", "Sam", "")),
            new Player("Jordan", "Artzet", "Jo", "")
        };
    }

    public static IEnumerable<object[]> Data_TestAddPlayers()
    {
        yield return new object[]
        {
            true,
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
            }
        };
        yield return new object[]
        {
            true,
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
                new("Jordan", "Artzet", "Jo", "")
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
                new("Jordan", "Artzet", "Jo", "")
            }
        };
        yield return new object[]
        {
            true,
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", ""),
                new("Samuel", "Sirven", "Sam", ""),
                new("Julien", "Themes", "Juju", "")
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
                new Player("Florent", "Marques", "Flo", ""),
                new Player("Jordan", "Artzet", "Jo", "")),
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", ""),
                new("Julien", "Themes", "Juju", "")
            }
        };
        yield return new object[]
        {
            false,
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images")
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "images"),
                new("Florent", "Marques", "Flo", "images")
            }
        };
        yield return new object[]
        {
            false,
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", "")
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
                new Player("Florent", "Marques", "Flo", ""),
                new Player("Jordan", "Artzet", "Jo", "")),
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", "")
            }
        };
        yield return new object[]
        {
            false,
            new Player[]
            {
                new("Florent", "Marques", "Flo", ""),
                new("Jordan", "Artzet", "Jo", "")
            },
            GameTestUtils.CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
                new Player("Florent", "Marques", "Flo", ""),
                new Player("Jordan", "Artzet", "Jo", "")),
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", ""),
                new("Jordan", "Artzet", "Jo", "")
            }
        };
    }

    public static IEnumerable<object[]> Data_TestAddHand()
    {
        yield return new object[]
        {
            true,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown))
            },
            new  Game("good", new FrenchTarotRules(), DateTime.Now),
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
        yield return new object[]
        {
            true,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
                KeyValuePair.Create(2, new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
                KeyValuePair.Create(3, new Hand(3L, 3, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            },
            GameTestUtils.CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now, 
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            new Hand(3L, 3, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
        yield return new object[]
        {
            false,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            },
            GameTestUtils.CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now,
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
        yield return new object[]
        {
            false,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
                KeyValuePair.Create(2, new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            },
            GameTestUtils.CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now,
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
    }
    
    public static IEnumerable<object[]> Data_TestAddHands()
    {
        yield return new object[]
        {
            true,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown))
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Hand[]
            {
                new (1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
            }
        };
        yield return new object[]
        {
            true,
            new[]
            {
                KeyValuePair.Create(1,
                    new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown)),
                KeyValuePair.Create(2,
                    new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown)),
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Hand[]
            {
                new(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
            }
        };
        yield return new object[]
        {
            true,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
                KeyValuePair.Create(2, new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
                KeyValuePair.Create(3, new Hand(3L, 3, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            },
            GameTestUtils.CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now, 
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            new Hand[]
            {
                new(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new(3L, 3, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
            }
        };
        yield return new object[]
        {
            false,
            new[]
            {
                KeyValuePair.Create(1, new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)),
            },
            new Game("good", new FrenchTarotRules(), DateTime.Now),
            new Hand[]
            {
                new(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
            }
        };
        yield return new object[]
        {
            false,
            new[]
            {
                KeyValuePair.Create(1,
                    new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown)),
                KeyValuePair.Create(2,
                    new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown)),
            },
            GameTestUtils.CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now,
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                    Chelem.Unknown),
                new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                    Chelem.Unknown)),
            new Hand[]
            {
                new(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown)
            }
        };
        yield return new object[]
        {
            false,
            new[]
            {
                KeyValuePair.Create(1,
                    new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown)),
                KeyValuePair.Create(2,
                    new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                        Chelem.Unknown))
            },
            GameTestUtils. CreateGameWithHands("good", new FrenchTarotRules(), DateTime.Now,
                new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                    Chelem.Unknown),
                new Hand(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown,
                    Chelem.Unknown)),
            new Hand[]
            {
                new(3L, 3, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
                new(2L, 2, new FrenchTarotRules(), DateTime.Now, 1, null, null, PetitResults.Unknown, Chelem.Unknown),
            }
        };
    }
    
    public static IEnumerable<object[]> Data_TestHashCode()
    {
        yield return new object[]
        {
            true,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null),
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null)
        };
        yield return new object[]
        {
            true,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null),
            new Game(45L, "bad", new FrenchTarotRules(), DateTime.Now, DateTime.MaxValue)
        };
        yield return new object[]
        {
            true,
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null, 
                new Player[] { new("Julien", "Theme", "JuJu", "")}, 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)}),
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/24/2022", CultureInfo.InvariantCulture), DateTime.MaxValue, 
                new Player[] { new("Samuel", "Sirven", "Sam", "  ")}, 
                new Hand[]{new(25L, 125, new FrenchTarotRules(), DateTime.Parse("12/24/2022", CultureInfo.InvariantCulture), 25, true, true, PetitResults.Owned, Chelem.Announced)})
        };
        yield return new object[]
        {
            true,
            new Game(1L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(32L, "bad", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue)
        };
        yield return new object[]
        {
            false,
            new Game(2L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(32L, "good", new FrenchTarotRules(), DateTime.Now, DateTime.MaxValue)
        };
    }

    public static IEnumerable<object?[]> Data_TestEquals()
    {
        yield return new object[]
        {
            true,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null),
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null)
        };
        yield return new object[]
        {
            true,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null),
            new Game(45L, "bad", new FrenchTarotRules(), DateTime.Now, DateTime.MaxValue)
        };
        yield return new object[]
        {
            true,
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue, 
                new Player[] { new("Julien", "Theme", "Nickname", "")}, 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)}),
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue, 
                new Player[] { new("Julien", "Theme", "Nickname", "")}, 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)})
        };
        yield return new object[]
        {
            false,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(0L, "bad", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue)
        };
        yield return new object[]
        {
            false,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(0L, "good", new FrenchTarotRules(), DateTime.Now, DateTime.MaxValue)
        };
        yield return new object[]
        {
            false,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.Parse("12/24/2022", CultureInfo.InvariantCulture))
        };
        yield return new object[]
        {
            false,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue),
            new Game(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null)
        };
        yield return new object[]
        {
            false,
            GameTestUtils.CreateGameWithPlayersAndHands(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), DateTime.MaxValue, 
                new Player[] { new("Julien", "Theme", "Nickname", "")}, 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)}),
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022"), DateTime.MaxValue, 
                Array.Empty<Player>(), 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)})
        };
        yield return new object[]
        {
            false,
            GameTestUtils.CreateGameWithPlayersAndHands(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null, 
                new Player[] { new("Julien", "Theme", "Nickname", "")}, 
                new Hand[]{new(1L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 1, null, null, PetitResults.Unknown, Chelem.Unknown)}),
            GameTestUtils.CreateGameWithPlayersAndHands(0L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null, 
                new Player[] { new("Julien", "Theme", "Nickname", "")}, 
                Array.Empty<Hand>())
        };
        yield return new object?[]
        {
            false,
            new Game(45L, "good", new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), null),
            null,
        };
    }
}