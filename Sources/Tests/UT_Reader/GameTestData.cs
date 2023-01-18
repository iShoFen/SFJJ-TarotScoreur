using Model.Enums;
using Model.Rules;
using Model.Games;
using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

public static class GameTestData
{
// 1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 21), null)
    private static Game CreateGameWithPlayersAndHands(
        ulong id,
        string name,
        IRules rules,
        DateTime startDate,
        DateTime? endate,
        IEnumerable<Player> players,
        IEnumerable<Hand> hands
    )
    {
        var game = new Game(id, name, rules, startDate, endate);
        foreach (var player in players)
        {
            game.AddPlayer(player);
        }

        foreach (var hand in hands)
        {
            game.AddHand(hand);
        }

        return game;
    }

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

    public static IEnumerable<object[]> Data_TestGetGameByDate()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                new DateTime(2022, 09, 21),
                new DateTime(2022, 09, 29),
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
                    new(7UL, "Game 7", new FrenchTarotRules(), new DateTime(2022, 09, 21), new DateTime(2022, 09, 29))
                }
            };
        }
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

    /*_playerList.Add(new Player(1UL, "Jean", "BON", "JEBO", "avatar1"));
    _playerList.Add(new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"));
    _playerList.Add(new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"));
    _playerList.Add(new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"));
    _playerList.Add(new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"));
    _playerList.Add(new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"));
    _playerList.Add(new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"));
    _playerList.Add(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"));
    _playerList.Add(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"));
    _playerList.Add(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"));
    _playerList.Add(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"));
    _playerList.Add(new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"));
    _playerList.Add(new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"));
    _playerList.Add(new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"));
    _playerList.Add(new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"));
    _playerList.Add(new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16"));*/

    /*        _handList.Add(new Hand(23UL, 4, _rulesList[0], new DateTime(2022, 09, 30), 567,
            true, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[7], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[1], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[1], (Biddings.King, Poignee.None))));*/

    // The hands for the game 8

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
