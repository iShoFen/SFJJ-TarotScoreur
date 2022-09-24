using Model;
using Model.games;

namespace UT_Model;

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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now, 
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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
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
            CreateGameWithPlayers("good", new FrenchTarotRules(), DateTime.Now,
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
        };
    }
    
    public static IEnumerable<object[]> Data_TestAddHands()
    {
        yield return new object[]
        {
        };
    }

    private static Game CreateGameWithPlayers(string name, IRules rules, DateTime date, params Player[] players)
    {
        var game = new Game(name, rules, date);
        game.AddPlayers(players);
        return game;
    }
}