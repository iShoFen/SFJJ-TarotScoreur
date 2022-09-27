using Model;
using Xunit;

namespace UT_Model;

public class UT_RulesFactory
{
    [Fact]
    public void TestConstructor()
    {
        Assert.NotEmpty(RulesFactory.Rules);
    }
    
    [InlineData(true, "FrenchTarotRules")]
    [InlineData(false, "EnglishTarotRules")]
    [InlineData(false, "")]
    [InlineData(false, "          ")]
    [InlineData(false, null)]
    [Theory]
    public void TestCreate(bool expected, string rulesName)
    {
        var rules = RulesFactory.Create(rulesName);
        Assert.Equal(expected, rules != null);
    }
}