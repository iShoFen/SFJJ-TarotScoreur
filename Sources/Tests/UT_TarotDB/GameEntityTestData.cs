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
    
}