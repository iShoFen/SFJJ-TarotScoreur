using RestController.DTOs;
using RestController.DTOs.Games;

namespace UT_RestController;

public class GameControllerDataV1
{

    public static IEnumerable<object[]> Data_TestGetGames()
    {
        yield return new object[]
        {
            1,
            10,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 2UL,
                    Name = "Game 2",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 3UL,
                    Name = "Game 3",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 4UL,
                    Name = "Game 4",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 5UL,
                    Name = "Game 5",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            2,
            5,
            new List<GameDTO>
            {
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            int.MaxValue,
            int.MaxValue,
            new List<GameDTO>()
        };

        yield return new object[]
        {
            1,
            0,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 2UL,
                    Name = "Game 2",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 3UL,
                    Name = "Game 3",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 4UL,
                    Name = "Game 4",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 5UL,
                    Name = "Game 5",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            0,
            1,
            new List<GameDTO>()
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                }

            }
        };

        yield return new object[]
        {
            0,
            0,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 2UL,
                    Name = "Game 2",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 3UL,
                    Name = "Game 3",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 4UL,
                    Name = "Game 4",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 5UL,
                    Name = "Game 5",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            -1,
            1,
            new List<GameDTO>()
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                }

            }
        };

        yield return new object[]
        {
            1,
            -1,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 2UL,
                    Name = "Game 2",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 3UL,
                    Name = "Game 3",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 4UL,
                    Name = "Game 4",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 5UL,
                    Name = "Game 5",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            -1,
            -1,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 2UL,
                    Name = "Game 2",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 3UL,
                    Name = "Game 3",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 4UL,
                    Name = "Game 4",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 5UL,
                    Name = "Game 5",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new()
                {
                    Id = 6UL,
                    Name = "Game 6",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };

        yield return new object[]
        {
            1,
            1,
            new List<GameDTO>
            {
                new()
                {
                    Id = 1UL,
                    Name = "Game 1",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestGetGameById()
    {
        yield return new object[]
        {
            1,
            new GameDetailDTO()
            {
                Id = 1UL,
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = { 1, 2, 3 },
                Hands = { 1, 2, 3 }
                
            }
        };

        yield return new object[]
        {
            2,
            new GameDetailDTO
            {
                Id = 2UL,
                Name = "Game 2",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = { 2, 3, 4 },
                Hands = { 4, 5, 6 }
            }
        };

        yield return new object[]
        {
            3,
            new GameDetailDTO
            {
                Id = 3UL,
                Name = "Game 3",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = { 3, 4, 5 },
                Hands = { 7, 8, 9 }
            }
        };

        yield return new object[]
        {
            4,
            new GameDetailDTO
            {
                Id = 4UL,
                Name = "Game 4",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = { 4, 5, 6, 7 },
                Hands = { 10, 11, 12 }
            }
        };

        yield return new object[]
        {
            5,
            new GameDetailDTO
            {
                Id = 5UL,
                Name = "Game 5",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = { 5, 6, 7, 8 },
                Hands = { 13, 14, 15 }
            }
        };

        yield return new object[]
        {
            6,
            new GameDetailDTO
            {
                Id = 6UL,
                Name = "Game 6",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = new DateTime(2022, 09, 29),
                Users = { 6, 7, 8, 9 },
                Hands = { 16, 17, 18, 19 }
            }
        };

    }

    public static IEnumerable<object[]> Data_TestGetUsersByGameId()
    {
        yield return new object[]
        {
            1,
            new List<UserDTO>
            {
                new()
                {
                    Id = 1UL,
                    FirstName = "Jean",
                    LastName = "BON",
                    Nickname = "JEBO",
                    Avatar = "avatar1",
                },
                new()
                {
                    Id = 2UL,
                    FirstName = "Jean",
                    LastName = "MAUVAIS",
                    Nickname = "JEMA",
                    Avatar = "avatar2",
                },
                new()
                {
                    Id = 3UL,
                    FirstName = "Jean",
                    LastName = "MOYEN",
                    Nickname = "KIKOU7",
                    Avatar = "avatar3",
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestPostGame()
    {
        yield return new object[]
        {
            new GameInsertRequest()
            {   
                Name = "Game Inserted for test",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 02, 11),
                EndDate = null,
                Users = { 11, 12, 13 }
            },   
            new GameDetailDTO()
            {   
                Id = 11UL,
                Name = "Game Inserted for test",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 02, 11),
                EndDate = null,
                Users = { 11, 12, 13 },
                Hands = new List<ulong>()
            }
        };
    }
    
    public static IEnumerable<object[]> Data_TestPutGame()
    {
        yield return new object[]
        {
            1,
            new GameUpdateRequest()
            {
                Id = 1UL,
                Name = "Game Updated for test",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 02, 11),
                EndDate = null,
            },
            new GameDetailDTO()
            {
                Id = 1UL,
                Name = "Game Updated for test",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 02, 11),
                EndDate = null,
                Users = {1, 2, 3},
                Hands = {1, 2, 3}
            }
        };
    }
    
    public static IEnumerable<object[]> Data_TestDeleteGame()
    {
        yield return new object[]
        {
            1,
            new GameDetailDTO()
            {
                Id = 1UL,
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Users = {1, 2, 3},
                Hands = {1, 2, 3}
            }
        };
    }

}