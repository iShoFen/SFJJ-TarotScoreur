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
    }
}