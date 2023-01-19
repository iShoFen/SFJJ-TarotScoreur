using Model.Enums;
using Model.Rules;
using Model.Games;
using Model.Players;
using static TestUtils.DataManagers;
using static TestUtils.GameTestUtils;

namespace UT_Reader;

public static class GameTestData
{
// 1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    public static IEnumerable<object[]> Data_TestGetGames()
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
                    new(10UL, "Game 10", new FrenchTarotRules(), new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
                }
            };

            yield return new object[]
            {
                loader.Get(), int.MaxValue, int.MaxValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), int.MinValue, int.MinValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), 0, 0, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), -1, -1, Array.Empty<Game>()
            };
        }
    }

    public static IEnumerable<object[]> Data_TestGetGameByPlayer()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                9UL,
                1,
                6,
                new Game[]
                {
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
                3UL,
                2,
                1,
                new Game[]
                {
                    new(2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                }
            };

            yield return new object[]
            {
                loader.Get(), ulong.MaxValue, 1, 10, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), 1UL, int.MaxValue, int.MaxValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), 1UL, int.MinValue, int.MinValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), 1UL, 0, 0, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), 1UL, -1, -1, Array.Empty<Game>()
            };
        }
    }

    public static IEnumerable<object[]> GetGameByName()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "Game 1",
                1,
                10,
                new Game[]
                {
                    new(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(10UL, "Game 10", new FrenchTarotRules(), new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
                }
            };

            yield return new object[]
            {
                loader.Get(),
                "Game",
                3,
                2,
                new Game[]
                {
                    new(5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 21), null),
                    new(6UL, "Game 6", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                }
            };

            yield return new object[]
            {
                loader.Get(),
                "",
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
                loader.Get(), "Game1", 1, 10, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), "Game 1", int.MaxValue, int.MaxValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), "Game 1", int.MinValue, int.MinValue, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), "Game 1", 0, 0, Array.Empty<Game>()
            };

            yield return new object[]
            {
                loader.Get(), "Game 1", -1, -1, Array.Empty<Game>()
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestGetGameByDate()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 29),
                1,
                10,
                new Game[]
                {
                    new(6UL, "Game 6", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)),
                    new(7UL, "Game 7", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29))
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                null,
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
                    new(9UL, "Game 9", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 30))
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 22),
                1,
                10,
                Array.Empty<Game>()
            };
            yield return new object?[]
            {
                loader.Get(),
                new DateTime(2022, 09, 23),
                new DateTime(2022, 09, 26),
                1,
                10,
                Array.Empty<Game>()
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestGetGameById()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                1UL,
                CreateGameWithPlayersAndHands(1UL,
                    "Game 1",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new Player[]
                    {
                        new(1UL, "Jean", "BON", "JEBO", "avatar1"),
                        new(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                        new(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3")
                    },
                    new Hand[]
                    {
                        new(1UL,
                            1,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 21),
                            210,
                            false,
                            true,
                            PetitResults.Lost,
                            Chelem.Unknown
                        ),
                        new(2UL,
                            2,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 22),
                            256,
                            true,
                            true,
                            PetitResults.Lost,
                            Chelem.AnnouncedSuccess
                        ),
                        new(3UL,
                            3,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 23),
                            151,
                            false,
                            false,
                            PetitResults.Lost,
                            Chelem.Success
                        )
                    }
                )
            };

            yield return new object?[]
            {
                loader.Get(),
                8UL,
                CreateGameWithPlayersAndHands(8UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    new DateTime(2022, 09, 30),
                    new Player[]
                    {
                        new(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                    },
                    new Hand[]
                    {
                        new(23UL,
                            1,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 30),
                            567,
                            true,
                            false,
                            PetitResults.Lost,
                            Chelem.Unknown
                        )
                    }
                )
            };

            yield return new object?[]
            {
                loader.Get(), 0UL, null
            };

            yield return new object?[]
            {
                loader.Get(), ulong.MaxValue, null
            };
        }
    }
}