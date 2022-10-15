using TarotDB;
using TarotDB.enums;

namespace UT_TarotDB;

public static class GameEntityTestData
{
    public static IEnumerable<object?[]> Data_TestRead()
    {
        yield return new object?[]
        {
            1UL,
            "Game1",
            "FrenchTarotRules",
            new DateTime(2022, 09, 21),
            null,
            new[]
            {
                1UL, 2UL, 3UL
            },
            new[]
            {
                1UL, 2UL, 3UL
            }
        };
        yield return new object?[]
        {
	        6UL,
	        "Game6",
	        "FrenchTarotRules",
	        new DateTime(2022, 09, 21),
	        new DateTime(2022, 09, 29),
	        new[]
	        {
		        6UL, 7UL, 8UL, 9UL
	        },
	        new[]
	        {
		        16UL, 17UL, 18UL, 19UL
	        }
        };
        yield return new object?[]
        {
	        9UL,
	        "Game9",
	        "FrenchTarotRules",
	        new DateTime(2022, 09, 21),
	        new DateTime(2022, 09, 30),
	        new[]
	        {
		        9UL, 10UL, 11UL, 12UL, 13UL
	        },
	        new[]
	        {
		        24UL, 25UL, 26UL, 27UL, 28UL
	        }
        };
    }
    
    public static IEnumerable<object?[]> Data_TestAdd()
    {
        yield return new object?[]
        {
	        true, 
	        0UL,
            "Game11",
            "FrenchTarotRules",
            new DateTime(2022, 10, 10),
            null,
            new[]
            {
                new PlayerEntity {FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich", Avatar = "Player1"},
                new PlayerEntity {FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich", Avatar = "Player2"},
                new PlayerEntity {FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3"}
            },
            Array.Empty<HandEntity>()
        };
        yield return new object?[]
        {
	        true,
	        0UL,
            "Game12",
            "FrenchTarotRules",
            new DateTime(2022, 10, 10),
            null,
            new[]
            {
                new PlayerEntity {Id = 14UL},
                new PlayerEntity {Id = 15UL},
                new PlayerEntity {Id = 16UL}
            },
            Array.Empty<HandEntity>()
        };
        yield return new object?[]
        {
	        true,
	        0UL,
            "Game13",
            "FrenchTarotRules",
            new DateTime(2022, 10, 10),
            new DateTime(2022, 10, 20),
            new[]
            {
                new PlayerEntity {Id = 14UL},
                new PlayerEntity {Id = 15UL},
                new PlayerEntity {Id = 16UL}
            },
            new[]
            {
                new HandEntity
                {
                    Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 10, 10), TakerScore = 80,
                    TwentyOne = false, Excuse = true, Petit = PetitResultDB.Lost, Chelem = ChelemDB.Success
                },
                new HandEntity
                {
                    Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 10, 20), TakerScore = 155,
                    TwentyOne = true, Excuse = true, Petit = PetitResultDB.AuBoutOwned, Chelem = ChelemDB.Fail
                }
            }
        };
        yield return new object?[]
        {
	        false,
	        1UL,
	        "Game1",
	        "FrenchTarotRules",
	        new DateTime(2022, 09, 21),
	        null,
	        new[]
	        {
		        new PlayerEntity {Id = 1UL},
		        new PlayerEntity {Id = 2UL},
		        new PlayerEntity {Id = 3UL}
	        },
	        new[]
	        {
		        new HandEntity {Id = 1UL},
		        new HandEntity {Id = 2UL},
		        new HandEntity {Id = 3UL}
	        }
        };
        yield return new object?[]
        {
	        false,
	        1UL,
	        "Game13",
	        "FrenchTarotRules",
	        new DateTime(2022, 10, 10),
	        new DateTime(2022, 10, 20),
	        new[]
	        {
		        new PlayerEntity {Id = 14UL},
		        new PlayerEntity {Id = 15UL},
		        new PlayerEntity {Id = 16UL}
	        },
	        new[]
	        {
		        new HandEntity
		        {
			        Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 10, 10), TakerScore = 80,
			        TwentyOne = false, Excuse = true, Petit = PetitResultDB.Lost, Chelem = ChelemDB.Success
		        },
		        new HandEntity
		        {
			        Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 10, 20), TakerScore = 155,
			        TwentyOne = true, Excuse = true, Petit = PetitResultDB.AuBoutOwned, Chelem = ChelemDB.Fail
		        }
	        }
        };
    }
    
    public static IEnumerable<object?[]> Data_TestUpdate()
    {
        yield return new object?[]
        {
	        true, 
	        1UL,
	        1UL,
	        "Game1",
            "TestGame",
            "FrenchTarotRules",
            "TestRules",
            new DateTime(2022, 09, 21),
            new DateTime(2022, 10, 10),
            null,
            new DateTime(2022, 10, 13),
            new[]
			{
				new PlayerEntity {Id = 1UL},
				new PlayerEntity {Id = 2UL},
				new PlayerEntity {Id = 3UL}
			},
            new[]
            {
	            new PlayerEntity {Id = 1UL}
            },
            new[]
			{
	            new HandEntity {Id = 1UL},
	            new HandEntity {Id = 2UL},
	            new HandEntity {Id = 3UL}
			},
            new[]
            {
	            new HandEntity {Id = 1UL}
            }
        };
        yield return new object?[]
        {
	        false,
	        1UL,
	        2UL,
	        "Game1",
            "TestGame2",
            "FrenchTarotRules",
            "TestRules2",
            new DateTime(2022, 09, 21),
            new DateTime(2022, 10, 10),
            null,
            null,
            new[]
            {
	            new PlayerEntity {Id = 1UL},
	            new PlayerEntity {Id = 2UL},
	            new PlayerEntity {Id = 3UL}
			},
            Array.Empty<PlayerEntity>(),
            new[]
			{
	            new HandEntity {Id = 1UL},
	            new HandEntity {Id = 2UL},
	            new HandEntity {Id = 3UL}
	        },
            Array.Empty<HandEntity>()
        };
    }
}