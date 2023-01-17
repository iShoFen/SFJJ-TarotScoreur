using Model.Rules;
using Model.Games;
using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

public static class GameTestData
{
    private static Game CreateGameWithPlayers(Game game, IEnumerable<Player> players)
    {
        foreach (var player in players)
        {
            game.AddPlayer(player);
        }

        return game;
    }
        
    /*
    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    new Game(2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    new Game(3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    new Game(4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    new Game(5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    new Game(6UL, "Game 6", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)
    new Game(7UL, "Game 7", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)
    new Game(8UL, "Game 8", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)
    new Game(9UL, "Game 9", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)
    new Game(10UL, "Game 10", new FrenchTarotRules(),new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)
    */

    public static IEnumerable<object[]> Data_TestLoadAllGames()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                1,
                10,
                new Game[]
                {
                    new(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(6UL, "Game 6", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new(7UL, "Game 7", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new(8UL, "Game 8", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new(9UL, "Game 9", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new(10UL, "Game 10", new FrenchTarotRules(), new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
                }
            };
            yield return new object[]
            {
                loader.Get(),
                2,
                5,
                new Game[]
                {
                new(6UL, "Game 6", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                new(7UL, "Game 7", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                new(8UL, "Game 8", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                new(9UL, "Game 9", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                new(10UL, "Game 10", new FrenchTarotRules(),new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
                
                }
            };
            
            yield return new object[]
            {
                loader.Get(),
                int.MaxValue,
                int.MaxValue,
                Array.Empty<Game>()
            };
            
            yield return new object[]
            {
                loader.Get(),
                int.MinValue,
                int.MinValue,
                Array.Empty<Game>()
            };
            
            yield return new object[]
            {
                loader.Get(),
                0,
                0,
                Array.Empty<Game>()
            };
            
                        
            yield return new object[]
            {
                loader.Get(),
                -1,
                -1,
                Array.Empty<Game>()
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByGroup()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new Group(9UL, "Group 9",
                    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                ),
                new[]
                {
                    CreateGameWithPlayers(
                        new Game(9UL, "Game 9", new FrenchTarotRules(), new DateTime(2022, 09, 21),
                            new DateTime(2022, 09, 30)),
                        new[]
                        {
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                            new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                        }),
                    CreateGameWithPlayers(
                        new Game(10UL, "Game 10", new FrenchTarotRules(),
                            new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                        new[]
                        {
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                            new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                        })
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new Group(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(2UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(3UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(4UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<Game>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new Group(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(2UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(3UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(4UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<Game>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new Group(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(2UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(3UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(4UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<Game>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new Group(1458UL, "Group 1458",
                    new Player(16UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(17UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(18UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(19UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(20UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<Game>(),
                1,
                2
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByPlayer()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                new[]
                {
                    CreateGameWithPlayers(
                        new Game(7UL, "Game 7", new FrenchTarotRules(),
                            new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                        new[]
                        {
                            new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                            new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11")
                        }),
                    CreateGameWithPlayers(
                        new Game(8UL, "Game 8", new FrenchTarotRules(),
                            new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                        new[]
                        {
                            new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                        }),
                    CreateGameWithPlayers(
                        new Game(9UL, "Game 9", new FrenchTarotRules(),
                            new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                        new[]
                        {
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                            new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                        }),
                    CreateGameWithPlayers(
                        new Game(10UL, "Game 10", new FrenchTarotRules(),
                            new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                        new[]
                        {
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                            new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                        })
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                new[]
                {
                    CreateGameWithPlayers(
                        new Game(10UL, "Game 10", new FrenchTarotRules(),
                            new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)),
                        new[]
                        {
                            new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                            new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                            new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                            new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                            new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                        })
                },
                2,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                0,
                1
            };
        }
    }

    public static IEnumerable<object?[]> LoadGameByName()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
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
                loader.Get(),
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
                    })
            };
            yield return new object?[]
            {
                loader.Get(),
                "",
                null
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByStartDate()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 18),
                new[]
                {
                    new Game(10UL, "Game 10", new FrenchTarotRules(), new DateTime(2022, 09, 18),
                        new DateTime(2022, 09, 23))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new[]
                {
                    new Game(1UL, "Game 1", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), null),
                    new Game(2UL, "Game 2", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), null),
                    new Game(3UL, "Game 3", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), null),
                    new Game(4UL, "Game 4", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), null),
                    new Game(5UL, "Game 5", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), null),
                    new Game(6UL, "Game 6", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new Game(7UL, "Game 7", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new Game(8UL, "Game 8", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new Game(9UL, "Game 9", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 01),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 01),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 01),
                Array.Empty<object>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2002, 09, 01),
                Array.Empty<object>(),
                1,
                10
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByEndDate()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
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
                loader.Get(),
                new DateTime(2022, 09, 29),
                new[]
                {
                    new Game(6UL, "Game 6", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                    new Game(7UL, "Game 7", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 25))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2002, 09, 25),
                Array.Empty<object>(),
                1,
                10
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByDateInterval()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
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
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 30),
                new[]
                {
                    new Game(6UL, "Game 6", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new Game(7UL, "Game 7", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new Game(8UL, "Game 8", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new Game(9UL, "Game 9", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                Array.Empty<object>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2002, 09, 21),
                new DateTime(2002, 09, 25),
                Array.Empty<object>(),
                1,
                10
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByDateIntervalAndGroup()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 08, 01),
                new DateTime(2022, 10, 01),
                new Group(9UL, "Group 9",
                    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")
                ),
                new[]
                {
                    new Game(9UL, "Game 9", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)),
                    new Game(10UL, "Game 10", new FrenchTarotRules(),
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Group(1UL, "Group 1",
                    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Group(1UL, "Group 1",
                    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Group(1UL, "Group 1",
                    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
                ),
                Array.Empty<object>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2002, 09, 21),
                new DateTime(2002, 09, 25),
                new Group(1UL, "Group 1",
                    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player(5UL, "Albert", "GOL", "LOLA", "avatar1")
                ),
                Array.Empty<object>(),
                1,
                10
            };
        }
    }

    public static IEnumerable<object[]> Data_TestLoadGameByDateIntervalAndPlayer()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 08, 01),
                new DateTime(2022, 10, 01),
                new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                new[]
                {
                    new Game(6UL, "Game 6", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new Game(7UL, "Game 7", new FrenchTarotRules(),
                        new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new Game(8UL, "Game 8", new FrenchTarotRules(),
                        new DateTime(2022, 09, 18), new DateTime(2022, 09, 30))
                },
                1,
                10
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                1,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                0,
                0
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 25),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                0,
                1
            };
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2002, 09, 21),
                new DateTime(2002, 09, 25),
                new Player("Jean", "BON", "JEBO", "avatar1"),
                Array.Empty<object>(),
                1,
                10
            };
        }
    }
}