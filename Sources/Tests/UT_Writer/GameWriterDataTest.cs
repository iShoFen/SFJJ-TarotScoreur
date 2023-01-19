using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;

namespace UT_Writer;

using static TestUtils.DataManagers;
using static TestUtils.GameTestUtils;

internal static class GameWriterDataTest
{
    public static IEnumerable<object?[]> InsertGameData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>()),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>())
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    Array.Empty<Player>()),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    Array.Empty<Player>())
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4")),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"))
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(8UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>()),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithPlayersAndHands(0UL,
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
                        new(0UL,
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
                ),
                CreateGameWithPlayersAndHands(11UL,
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
                        new(33UL,
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
                writer.Get(),
                CreateGameWithPlayersAndHands(0UL,
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
                        new(0UL,
                            1,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 30),
                            567,
                            true,
                            false,
                            PetitResults.Lost,
                            Chelem.Unknown
                        ),
                        new(23UL,
                            2,
                            new FrenchTarotRules(),
                            new DateTime(2022, 09, 30),
                            567,
                            true,
                            false,
                            PetitResults.Lost,
                            Chelem.Unknown
                        )
                    }
                ),
                CreateGameWithPlayersAndHands(11UL,
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
                        new(33UL,
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
        }
    }

    public static IEnumerable<object?[]> UpdateGameData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithPlayersAndHands(1UL,
                    "Ma partie mise à jour",
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 10),
                    new DateTime(2023, 01, 15),
                    new Player[]
                    {
                        new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        new(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
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
                        )
                    }
                ),
                CreateGameWithPlayersAndHands(1UL,
                    "Ma partie mise à jour",
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 10),
                    new DateTime(2023, 01, 15),
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
                writer.Get(),
                CreateGameWithPlayersAndHands(0UL,
                    "Ma partie mise à jour",
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 10),
                    new DateTime(2023, 01, 15),
                    new Player[]
                    {
                        new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        new(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
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
                        ),
                        new(0UL,
                            3,
                            new FrenchTarotRules(),
                            new DateTime(2023, 01, 12),
                            233,
                            false,
                            false,
                            PetitResults.Lost,
                            Chelem.Success
                        )
                    }
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithPlayersAndHands(100UL,
                    "Ma partie mise à jour",
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 10),
                    new DateTime(2023, 01, 15),
                    new Player[]
                    {
                        new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        new(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        new(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
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
                        ),
                        new(0UL,
                            3,
                            new FrenchTarotRules(),
                            new DateTime(2023, 01, 12),
                            233,
                            false,
                            false,
                            PetitResults.Lost,
                            Chelem.Success
                        )
                    }
                ),
                null
            };
        }
    }

    public static IEnumerable<object?[]> DeleteGameWithObjectData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
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
                ),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithPlayersAndHands(0UL,
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
                ),
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithPlayersAndHands(50UL,
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
                ),
                false
            };
            yield return new object?[]
            {
                writer.Get(),
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
                ),
                true
            };
        }
    }

    public static IEnumerable<object?[]> DeleteGameWithIdData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                4UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                8UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                0UL,
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                20UL,
                false
            };
        }
    }
}