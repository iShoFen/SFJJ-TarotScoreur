using Model.Enums;
using Tarot2B2Model;
using TarotDB.Enums;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace UT_Tarot2B2Model;

public class UT_EnumExtensions
{
    [Fact]
    internal void Test_BiddingsToEntity()
    {
        var i = 0;
        foreach (Biddings bidding in Enum.GetValues(typeof(Biddings)))
        {
            Assert.Equal(bidding.ToEntity(), Enum.GetValues(typeof(BiddingsDb)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_BiddingsToModel()
    {
        var i = 0;
        foreach (BiddingsDb bidding in Enum.GetValues(typeof(BiddingsDb)))
        {
            Assert.Equal(bidding.ToModel(), Enum.GetValues(typeof(Biddings)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_ChelemToEntity()
    {
        var i = 0;
        foreach (Chelem chelem in Enum.GetValues(typeof(Chelem)))
        {
            Assert.Equal(chelem.ToEntity(), Enum.GetValues(typeof(ChelemDb)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_ChelemToModel()
    {
        var i = 0;
        foreach (ChelemDb chelem in Enum.GetValues(typeof(ChelemDb)))
        {
            Assert.Equal(chelem.ToModel(), Enum.GetValues(typeof(Chelem)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_PetitResultToEntity()
    {
        var i = 0;
        foreach (PetitResults petitResult in Enum.GetValues(typeof(PetitResults)))
        {
            Assert.Equal(petitResult.ToEntity(), Enum.GetValues(typeof(PetitResultsDb)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_PetitResultToModel()
    {
        var i = 0;
        foreach (PetitResultsDb petitResult in Enum.GetValues(typeof(PetitResultsDb)))
        {
            Assert.Equal(petitResult.ToModel(), Enum.GetValues(typeof(PetitResults)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_PoigneeToEntity()
    {
        var i = 0;
        foreach (Poignee poignee in Enum.GetValues(typeof(Poignee)))
        {
            Assert.Equal(poignee.ToEntity(), Enum.GetValues(typeof(PoigneeDb)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_PoigneeToModel()
    {
        var i = 0;
        foreach (PoigneeDb poignee in Enum.GetValues(typeof(PoigneeDb)))
        {
            Assert.Equal(poignee.ToModel(), Enum.GetValues(typeof(Poignee)).GetValue(i));
            ++i;
        }
    }
}