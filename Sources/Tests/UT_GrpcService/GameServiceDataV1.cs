using GrpcService;

namespace UT_GrpcService;

public class GameServiceDataV1
{
    public static IEnumerable<object[]> Data_TestGetGames()
    {
        yield return new object[]
        {
            1,
            10,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 1UL,
                        Name = "Game 1",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 2UL,
                        Name = "Game 2",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 3UL,
                        Name = "Game 3",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 4UL,
                        Name = "Game 4",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 5UL,
                        Name = "Game 5",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 7UL,
                        Name = "Game 7",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 8UL,
                        Name = "Game 8",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 9UL,
                        Name = "Game 9",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 10UL,
                        Name = "Game 10",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 18).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 23).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            2,
            5,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 7UL,
                        Name = "Game 7",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 8UL,
                        Name = "Game 8",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 9UL,
                        Name = "Game 9",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 10UL,
                        Name = "Game 10",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 18).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 23).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            int.MaxValue, int.MaxValue, new GamesReply()
        };

        yield return new object[]
        {
            int.MinValue, int.MinValue, new GamesReply()
        };

        yield return new object[]
        {
            0, 0, new GamesReply()
        };

        yield return new object[]
        {
            -1, -1, new GamesReply()
        };
    }

    public static IEnumerable<object[]> Data_TestGetGameByPlayer()
    {
        yield return new object[]
        {
            9UL,
            1,
            6,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 7UL,
                        Name = "Game 7",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 8UL,
                        Name = "Game 8",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 9UL,
                        Name = "Game 9",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 10UL,
                        Name = "Game 10",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 18).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 23).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            3UL,
            2,
            1,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 2UL,
                        Name = "Game 2",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            ulong.MaxValue, 1, 10, new GamesReply()
        };

        yield return new object[]
        {
            1UL, int.MaxValue, int.MaxValue, new GamesReply()
        };

        yield return new object[]
        {
            1UL, int.MinValue, int.MinValue, new GamesReply()
        };

        yield return new object[]
        {
            1UL, 0, 0, new GamesReply()
        };

        yield return new object[]
        {
            1UL, -1, -1, new GamesReply()
        };
    }

    public static IEnumerable<object[]> GetGameByName()
    {
        yield return new object[]
        {
            "Game 1",
            1,
            10,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 1UL,
                        Name = "Game 1",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 10UL,
                        Name = "Game 10",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 18).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 23).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            "Game",
            3,
            2,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 5UL,
                        Name = "Game 5",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            "",
            1,
            10,
            new GamesReply
            {
                Games =
                {
                    new GameReply
                    {
                        Id = 1UL,
                        Name = "Game 1",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 2UL,
                        Name = "Game 2",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 3UL,
                        Name = "Game 3",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 4UL,
                        Name = "Game 4",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 5UL,
                        Name = "Game 5",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 7UL,
                        Name = "Game 7",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 8UL,
                        Name = "Game 8",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 9UL,
                        Name = "Game 9",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 10UL,
                        Name = "Game 10",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 18).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 23).ToTimestamp()
                    }
                }
            }
        };

        yield return new object[]
        {
            "Game1", 1, 10, new GamesReply()
        };

        yield return new object[]
        {
            "Game 1", int.MaxValue, int.MaxValue,  new GamesReply()
        };

        yield return new object[]
        {
            "Game 1", int.MinValue, int.MinValue,  new GamesReply()
        };

        yield return new object[]
        {
            "Game 1", 0, 0,  new GamesReply()
        };

        yield return new object[]
        {
            "Game 1", -1, -1,  new GamesReply()
        };
    }
    
    public static IEnumerable<object?[]> Data_TestGetGameByDate()
    {
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 29),
             1,
             10,
             new GamesReply
             {
                 Games =
                 {
                     new GameReply
                     {
                         Id = 6UL,
                         Name = "Game 6",
                         Rules = "FrenchTarotRules",
                         StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                         EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                     },
                     new GameReply
                     {
                         Id = 7UL,
                         Name = "Game 7",
                         Rules = "FrenchTarotRules",
                         StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                         EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                     }
                 }
             }
         };

         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             null,
             1,
             10,
             new GamesReply
             {
                 Games =
                 {
                     new GameReply
                    {
                        Id = 1UL,
                        Name = "Game 1",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 2UL,
                        Name = "Game 2",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 3UL,
                        Name = "Game 3",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 4UL,
                        Name = "Game 4",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 5UL,
                        Name = "Game 5",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = null
                    },
                    new GameReply
                    {
                        Id = 6UL,
                        Name = "Game 6",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 7UL,
                        Name = "Game 7",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 29).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 8UL,
                        Name = "Game 8",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    },
                    new GameReply
                    {
                        Id = 9UL,
                        Name = "Game 9",
                        Rules = "FrenchTarotRules",
                        StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                        EndDate = new DateTime(2022, 09, 30).ToTimestamp()
                    }
                 }
             }
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 22),
             1,
             10,
             new GamesReply()
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 23),
             new DateTime(2022, 09, 26),
             1,
             10,
             new GamesReply()
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 29),
             0,
             0,
             new GamesReply()
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 29),
             -1,
             -1,
             new GamesReply()
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 29),
             int.MaxValue,
             int.MaxValue,
             new GamesReply()
         };
         yield return new object?[]
         {
             new DateTime(2022, 09, 21),
             new DateTime(2022, 09, 29),
             int.MinValue,
             int.MinValue,
             new GamesReply()
         };
    }
    
    public static IEnumerable<object?[]> Data_TestGetGameById()
    {
        yield return new object?[]
        {
            1UL,
            new GameReplyDetails
            {
                Id = 1UL,
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                EndDate = null,
                Players =
                {
                    new[]
                    {
                        1UL, 2UL, 3UL
                    }
                },
                Hands =
                {
                    new[]
                    {
                        1UL, 2UL, 3UL
                    }
                }
            }
        };

        yield return new object?[]
        {
            8UL,
            new GameReplyDetails
            {
                Id = 8UL,
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                EndDate = new DateTime(2022, 09, 30).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        8UL, 9UL, 10UL, 11UL, 12UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        23UL
                    }
                }
            }
        };

        yield return new object?[]
        {
            0UL, null
        };

        yield return new object?[]
        {
            ulong.MaxValue, null
        };
    }
    
    public static IEnumerable<object?[]> InsertGameData()
    {
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp()
            },
            new GameReplyDetails
            {
                Id = 11UL,
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                EndDate = null
            },
            -1
        };
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 19).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        2UL, 3UL, 4UL
                    }
                }
            },
            new GameReplyDetails
            {
                Id = 11UL,
                Name = "Game 1",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 19).ToTimestamp(),
                EndDate = null,
                Players =
                {
                    new []
                    {
                        2UL, 3UL, 4UL
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        8UL, 9UL, 10UL, 11UL, 12UL
                    }
                }
            },
            new GameReplyDetails
            {
                Id = 11UL,
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                EndDate = null,
                Players =
                {
                    new []
                    {
                        8UL, 9UL, 10UL, 11UL, 12UL
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        8UL, 9UL, 10UL, 11UL, 12UL
                    }
                }
            },
            new GameReplyDetails
            {
                Id = 11UL,
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                EndDate = null,
                Players =
                {
                    new []
                    {
                        8UL, 9UL, 10UL, 11UL, 12UL
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 8",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        25UL, 9UL, 10UL, 11UL, 12UL
                    }
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new GameInsertRequest
            {
                Name = "Game 8",
                Rules = "MyRules",
                StartDate = new DateTime(2022, 09, 21).ToTimestamp()
            },
            null,
            2
        };
    }
    
    public static IEnumerable<object?[]> UpdateGameData()
    {
        yield return new object?[]
        {
            new GameReplyDetails
            {
                Id = 1UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 10).ToTimestamp(),
                EndDate = new DateTime(2023, 01, 15).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        4UL, 5UL, 6UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        1UL, 2UL
                    }
                }
            },
            new GameReplyDetails
            {
                Id = 1UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 10).ToTimestamp(),
                EndDate = new DateTime(2023, 01, 15).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        1UL, 2UL, 3UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        1UL, 2UL, 3UL
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GameReplyDetails
            {
                Id = 1UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 08).ToTimestamp(),
                EndDate = null
            },
            new GameReplyDetails
            {
                Id = 1UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 08).ToTimestamp(),
                EndDate = null,
                Players =
                {
                    new []
                    {
                        1UL, 2UL, 3UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        1UL, 2UL, 3UL
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
           new GameReplyDetails
           {
               Id = 0UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 10).ToTimestamp(),
                EndDate = new DateTime(2023, 01, 15).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        4UL, 5UL, 6UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        1UL, 2UL
                    }
                }
           },
           null,
           2
        };
        yield return new object?[]
        {
            new GameReplyDetails
            {
                Id = 100UL,
                Name = "Ma partie mise à jour",
                Rules = "FrenchTarotRules",
                StartDate = new DateTime(2023, 01, 10).ToTimestamp(),
                EndDate = new DateTime(2023, 01, 15).ToTimestamp(),
                Players =
                {
                    new []
                    {
                        4UL, 5UL, 6UL
                    }
                },
                Hands =
                {
                    new []
                    {
                        1UL, 2UL
                    }
                }
            },
            null,
            2
        };
        yield return new object?[]
        {
            new GameReplyDetails
            {
                Id = 100UL,
                Name = "Ma partie mise à jour",
                Rules = "MyRules",
                StartDate = new DateTime(2023, 01, 10).ToTimestamp(),
                EndDate = new DateTime(2023, 01, 15).ToTimestamp(),
            },
            null,
            1
        };
    }
    
    public static IEnumerable<object?[]> DeleteGameData()
    {
        yield return new object?[]
        {
            4UL,
            true
        };
        yield return new object?[]
        {
            8UL,
            true
        };
        yield return new object?[]
        {
            0UL,
            false
        };
        yield return new object?[]
        {
            20UL,
            false
        };
    }
}
