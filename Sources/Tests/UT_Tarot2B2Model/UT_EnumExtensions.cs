using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.enums;
using Tarot2B2Model;
using TarotDB.enums;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace UT_Tarot2B2Model;

public class UT_EnumExtensions
{
    [Fact]
    internal void Test_BiddingsToEntity()
    {
        var i = 0;
        foreach (Bidding bidding in Enum.GetValues(typeof(Bidding)))
        {
            Assert.Equal(bidding.ToEntity(), Enum.GetValues(typeof(BiddingDB)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_BiddingsToModel()
    {
        var i = 0;
        foreach (BiddingDB bidding in Enum.GetValues(typeof(BiddingDB)))
        {
            Assert.Equal(bidding.ToModel(), Enum.GetValues(typeof(Bidding)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_ChelemToEntity()
    {
        var i = 0;
        foreach (Chelem chelem in Enum.GetValues(typeof(Chelem)))
        {
            Assert.Equal(chelem.ToEntity(), Enum.GetValues(typeof(ChelemDB)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_ChelemToModel()
    {
        var i = 0;
        foreach (ChelemDB chelem in Enum.GetValues(typeof(ChelemDB)))
        {
            Assert.Equal(chelem.ToModel(), Enum.GetValues(typeof(Chelem)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_PetitResultToEntity()
    {
        var i = 0;
        foreach (PetitResult petitResult in Enum.GetValues(typeof(PetitResult)))
        {
            Assert.Equal(petitResult.ToEntity(), Enum.GetValues(typeof(PetitResultDB)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_PetitResultToModel()
    {
        var i = 0;
        foreach (PetitResultDB petitResult in Enum.GetValues(typeof(PetitResultDB)))
        {
            Assert.Equal(petitResult.ToModel(), Enum.GetValues(typeof(PetitResult)).GetValue(i));
            ++i;
        }
    }

    [Fact]
    internal void Test_PoigneeToEntity()
    {
        var i = 0;
        foreach (Poignee poignee in Enum.GetValues(typeof(Poignee)))
        {
            Assert.Equal(poignee.ToEntity(), Enum.GetValues(typeof(PoigneeDB)).GetValue(i));
            ++i;
        }
    }
    
    [Fact]
    internal void Test_PoigneeToModel()
    {
        var i = 0;
        foreach (PoigneeDB poignee in Enum.GetValues(typeof(PoigneeDB)))
        {
            Assert.Equal(poignee.ToModel(), Enum.GetValues(typeof(Poignee)).GetValue(i));
            ++i;
        }
    }
}