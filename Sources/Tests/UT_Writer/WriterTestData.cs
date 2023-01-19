using Model.Rules;
using Model.Games;
using Model.Players;
using TarotDB;

namespace UT_Writer;

using static TestUtils.DataManagers;

public class WriterTestData
{
    public static IEnumerable<object?[]> Data_TestSavePlayer()
    {
        foreach (var saver in Writers)
        {
            yield return new object?[]
            {
                saver,
                new Player("Pedro", "Machin", "Pema", "avatar28"),
                new Player(17UL, "Pedro", "Machin", "Pema", "avatar28"),
                new PlayerEntity
                {
                    Id = 17UL,
                    FirstName = "Pedro",
                    LastName = "Machin",
                    Nickname = "Pema",
                    Avatar = "avatar28"
                }
            };

            yield return new object?[]
            {
                saver,
                new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                null,
                new PlayerEntity
                {
                    Id = 13UL,
                    FirstName = "Anne",
                    LastName = "PETIT",
                    Nickname = "FRIPOUILLES",
                    Avatar = "avatar13"
                }
            };

            yield return new object?[]
            {
                saver, new Player(17UL, "Pedro", "Machin", "Pema", "avatar28"), null, null
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestSaveGroup()
    {
        foreach (var saver in Writers)
        {
            yield return new object?[]
            {
                saver,
                new Group("Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                ),
                new Group(13UL,
                    "Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                ),
                new GroupEntity
                {
                    Id = 13UL,
                    Name = "Group 13",
                    Players = new List<PlayerEntity>
                    {
                        new()
                        {
                            Id = 16UL,
                            FirstName = "Alizee",
                            LastName = "SEBAT",
                            Nickname = "SEBAT",
                            Avatar = "avatar16"
                        }
                    }
                }
            };

            yield return new object?[]
            {
                saver,
                new Group(12UL, "Group 12"),
                null,
                new GroupEntity
                {
                    Id = 12UL,
                    Name = "Group 12",
                    Players = new List<PlayerEntity>
                    {
                        new()
                        {
                            Id = 12UL,
                            FirstName = "Jules",
                            LastName = "INFANTE",
                            Nickname = "KIKOU77",
                            Avatar = "avatar12"
                        },
                        new()
                        {
                            Id = 13UL,
                            FirstName = "Anne",
                            LastName = "PETIT",
                            Nickname = "FRIPOUILLES",
                            Avatar = "avatar13"
                        },
                        new()
                        {
                            Id = 14UL,
                            FirstName = "Marine",
                            LastName = "TABLETTE",
                            Nickname = "LOLO",
                            Avatar = "avatar14"
                        },
                        new()
                        {
                            Id = 15UL,
                            FirstName = "Eliaz",
                            LastName = "DU JARDIN",
                            Nickname = "THEGIANTE",
                            Avatar = "avatar15"
                        },
                        new()
                        {
                            Id = 16UL,
                            FirstName = "Alizee",
                            LastName = "SEBAT",
                            Nickname = "SEBAT",
                            Avatar = "avatar16"
                        }
                    }

                    /*_playerList.Add(new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"));
                    _playerList.Add(new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"));
                    _playerList.Add(new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"));
                    _playerList.Add(new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"));
                    _playerList.Add(new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16"));*/
                }
            };

            yield return new object?[]
            {
                saver, new Group(13UL, "Group 13"), null, null
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestSaveGame()
    {
        foreach (var saver in Writers)
        {
            yield return new object?[]
            {
                saver,
                new Game("Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23)),
                new Game(11UL, "Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23), null),
                new GameEntity
                {
                    Id = 11UL,
                    Name = "Game 11",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 23),
                    EndDate = null
                }
            };

            yield return new object?[]
            {
                saver,
                new Game(10UL,
                    "Game 10",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 18),
                    new DateTime(2022, 09, 23)
                ),
                null,
                new GameEntity
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            };

            yield return new object?[]
            {
                saver, new Game(11UL, "Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23), null), null, null
            };
        }
    }
}
