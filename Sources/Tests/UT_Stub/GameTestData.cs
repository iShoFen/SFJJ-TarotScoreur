using Model;
using Model.games;

namespace UT_Stub;

public static class GameTestData
{
    public static IEnumerable<Object[]> Data_TestLoadAllGames()
    {
        yield return new Object[]
        {
            new Game[]
            {
                new (1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                new (2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 02), null),
                new (3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 03), null),
                new (4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 04), null),
                new (5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 05), null),
                new (6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
            },
            1,
            10
        };
        yield return new Object[]
        {
            new Game[]
            {
                new (1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
                new (2UL, "Game 2", new FrenchTarotRules(), new DateTime(2022, 09, 02), null),
                new (3UL, "Game 3", new FrenchTarotRules(), new DateTime(2022, 09, 03), null),
                new (4UL, "Game 4", new FrenchTarotRules(), new DateTime(2022, 09, 04), null),
                new (5UL, "Game 5", new FrenchTarotRules(), new DateTime(2022, 09, 05), null),
            },
            1,
            5
        };
        yield return new Object[]
        {
            new Game[]
            {
                new (6UL, "Game 6", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (7UL, "Game 7", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (8UL, "Game 8", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (9UL, "Game 9", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)),
                new (10UL, "Game 10", new FrenchTarotRules(), 
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23))
            },
            2,
            5
        };
        yield return new Object[]
        {
            new Game[] {},
            1,
            0
        };
        yield return new Object[]
        {
            new Game[] {},
            0,
            0
        };
        yield return new Object[]
        {
            new Game[] {},
            0,
            1
        };
    }
}