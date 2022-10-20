using Model;

namespace UT_Stub;

public static class RuleTestData
{
    public static IEnumerable<object[]> Data_TestLoadRule()
    {
        yield return new object[]
        {
            "FrenchTarotRules",
            new FrenchTarotRules()
        };
    }

    public static IEnumerable<object[]> Data_TestLoadAllRules()
    {
        yield return new object[]
        {
            new IRules[]
            {
                new FrenchTarotRules()
            },
            1,
            10
        };
        yield return new object[]
        {
            Array.Empty<IRules>(),
            1,
            0
        };
        yield return new object[]
        {
            Array.Empty<IRules>(),
            0,
            0
        };
        yield return new object[]
        {
            Array.Empty<IRules>(),
            0,
            1
        };
    }
}