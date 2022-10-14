using Model;
using Model.games;

namespace UT_Stub;

public static class GameTestData
{
    public static IEnumerable<object[]> Data_TestLoadAllGames()
    {
        yield return new object[]
        {
            new Game[]
            {
                new (1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                new (2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 02), null),
                new (3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 03), null),
                new (4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 04), null),
                new (5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 05), null),
                new (6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
            },
            1,
            10
        };
        yield return new object[]
        {
            new []
            {
                CreateGameWithPlayers(
                    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 02), null),
                    new[]
                    {
                        new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                        new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                        new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                        new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 03), null),
                    new[]
                    {
                        new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                        new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                        new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                    }),
                CreateGameWithPlayers(
                    new Game(4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 04), null),
                    new[]
                    {
                        new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                        new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2"),
                        new Player("Alizee", "SEBAT", "SEBAT", "avatar1"),
                        new Player("Jean", "BON", "JEBO", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 05), null),
                    new[]
                    {
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                        new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                        new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                        new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                    })
            },
            1,
            5
        };
        yield return new object[]
        {
            new[]
            {
                CreateGameWithPlayers(
                    new Game(6UL, "Game 6", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Alizee", "SEBAT", "SEBAT", "avatar1"),
                        new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                        new Player("Jules", "INFANTE", "KIKOU77", "avatar3")
                    }),
                CreateGameWithPlayers(
                    new Game(7UL, "Game 7", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Albert", "GOL", "LOLA", "avatar1"),
                        new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                        new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                        new Player("Alizee", "SEBAT", "SEBAT", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2")
                    }),
                CreateGameWithPlayers(
                    new Game(8UL, "Game 8", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                        new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                        new Player("Jules", "INFANTE", "KIKOU77", "avatar3")
                    }),
                CreateGameWithPlayers(
                    new Game(9UL, "Game 9", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Albert", "GOL", "LOLA", "avatar1"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(10UL, "Game 10", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    })
            },
            2,
            5
        };
        yield return new object[]
        {
            Array.Empty<Game>(),
            1,
            0
        };
        yield return new object[]
        {
            Array.Empty<Game>(),
            0,
            0
        };
        yield return new object[]
        {
            Array.Empty<Game>(),
            0,
            1
        };
    }

    private static Game CreateGameWithPlayers(Game game, Player[] players)
    {
        foreach (var player in players)
        {
            game.AddPlayer(player);
        }

        return game;
    }

    public static IEnumerable<object[]> Data_TestLoadGameByGroup()
    {
        yield return new object[]
        {
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            new[]
            {
                CreateGameWithPlayers(
                    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(10UL, "Game 10", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    })
            },
            1,
            10
        };
        yield return new object[]
        {
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<Game>(),
            1,
            0
        };
        yield return new Object[]
        {
            new Group(1UL, "Group 1",
                new("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<Game>(),
            0,
            0
        };
        yield return new Object[]
        {
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<Game>(),
            0,
            1
        };
        yield return new Object[]
        {
            new Group(1458UL, "Group 1458",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<Game>(),
            1,
            0
        };
    }

    public static IEnumerable<object[]> Data_TestLoadGameByPlayer()
    {
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            new[]
            {
                CreateGameWithPlayers(
                    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(6UL, "Game 6", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Alizee", "SEBAT", "SEBAT", "avatar1"),
                        new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                        new Player("Jules", "INFANTE", "KIKOU77", "avatar3")
                    }),
                CreateGameWithPlayers(
                    new Game(9UL, "Game 9", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Albert", "GOL", "LOLA", "avatar1"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(10UL, "Game 10", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    })
            },
            1,
            10
        };
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            new[]
            {
                CreateGameWithPlayers(
                    new Game(9UL, "Game 9", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Albert", "GOL", "LOLA", "avatar1"),
                        new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                    }),
                CreateGameWithPlayers(
                    new Game(10UL, "Game 10", new FrenchTarotRules(), 
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                    new[]
                    {
                        new Player("Jean", "BON", "JEBO", "avatar1"),
                        new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                        new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new Player("Albert", "GOL", "LOLA", "avatar1")
                    })
            },
            2,
            2
        };
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            0,
            1
        };
    }

    public static IEnumerable<object[]> LoadGameByName()
    {
        yield return new object[]
        {
            "Game 10",
            CreateGameWithPlayers(
                new Game(10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                new[]
                {
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                })
            
        };
        yield return new object[]
        {
            "Game 1",
            CreateGameWithPlayers(
                new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                new[]
                {
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                }),
        };
        yield return new object[]
        {
            "",
            null
        };
    }

    public static IEnumerable<object[]> Data_TestLoadGameByStartDate()
    {
        yield return new object[]
        {
            new DateTime(2022, 09, 01),
            new[]
            {
                new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new[]
            {
                new Game(6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 01),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 01),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 01),
            Array.Empty<object>(),
            0,
            1
        };
        yield return new object[]
        {
            new DateTime(2002, 09, 01),
            Array.Empty<object>(),
            1,
            10
        };
    }
    
    public static IEnumerable<object[]> Data_TestLoadGameByEndDate()
    {
        yield return new object[]
        {
            new DateTime(2022, 09, 23),
            new[]
            {
                new Game(10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 25),
            new[]
            {
                new Game(6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            0,
            1
        };
        yield return new object[]
        {
            new DateTime(2002, 09, 25),
            Array.Empty<object>(),
            1,
            10
        };
    }

    public static IEnumerable<object[]> Data_TestLoadGameByDateInterval()
    {
        yield return new object[]
        {
            new DateTime(2022, 09, 01),
            new DateTime(2022, 09, 23),
            new[]
            {
                new Game(10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new[]
            {
                new Game(6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            Array.Empty<object>(),
            0,
            1
        };
        yield return new object[]
        {
            new DateTime(2002, 09, 21),
            new DateTime(2002, 09, 25),
            Array.Empty<object>(),
            1,
            10
        };
    }
    
    public static IEnumerable<object[]> Data_TestLoadGameByDateIntervalAndGroup()
    {
        yield return new object[]
        {
            new DateTime(2022, 08, 01),
            new DateTime(2022, 10, 01),
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            new[]
            {
                new Game(6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<object>(),
            0,
            1
        };
        yield return new object[]
        {
            new DateTime(2002, 09, 21),
            new DateTime(2002, 09, 25),
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            Array.Empty<object>(),
            1,
            10
        };
    }
    
    public static IEnumerable<object[]> Data_TestLoadGameByDateIntervalAndPlayer()
    {
        yield return new object[]
        {
            new DateTime(2022, 08, 01),
            new DateTime(2022, 10, 01),
            new Player("Jean", "BON", "JEBO", "avatar1"),
            new[]
            {
                new Game(6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new Game(10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
            },
            1,
            10
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            1,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            0,
            0
        };
        yield return new object[]
        {
            new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 25),
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            0,
            1
        };
        yield return new object[]
        {
            new DateTime(2002, 09, 21),
            new DateTime(2002, 09, 25),
            new Player("Jean", "BON", "JEBO", "avatar1"),
            Array.Empty<object>(),
            1,
            10
        };
    }
}