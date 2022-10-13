using Model;

namespace UT_Stub;

public static class RuleTestData
{
    public static IEnumerable<Object[]> Data_TestLoadRule()
    {
        yield return new Object[]
        {
            "FrenchTarotRules",
            new FrenchTarotRules()
        };
    }
    
    public static IEnumerable<Object[]> Data_TestLoadAllRules()
    {
        yield return new Object[]
        {
            new IRules[]
            {
                new FrenchTarotRules()
            },
            1,
            10
        };
        yield return new Object[]
        {
            new IRules[] {},
            1,
            0
        };
        yield return new Object[]
        {
            new IRules[] {},
            0,
            0
        };
        yield return new Object[]
        {
            new IRules[] {},
            0,
            1
        };
    }

}