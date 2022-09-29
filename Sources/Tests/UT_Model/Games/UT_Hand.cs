using Model;
using Model.enums;
using Model.games;
using Xunit;

namespace UT_Model.Games;

public class UT_Hand
{
    [Theory]
    [MemberData(nameof(HandTestData.Data_TestFullConstructor), MemberType = typeof(HandTestData))]
    public void TestFullConstructor(bool isValid, ulong expId, int expHandNumber, IRules? expRules, DateTime expDate,
        int expTakerScore, bool? expTwentyOne, bool? expExcuse, PetitResult expPetit, Chelem expChelem,
        params KeyValuePair<Player, (Bidding, Poignee)>[] expBiddings)
    {
        if (expRules is null || expDate == default)
        {
            Assert.ThrowsAny<ArgumentException>(() => new Hand(expId, expHandNumber, expRules!, expDate, expTakerScore,
                expTwentyOne, expExcuse, expPetit, expChelem, expBiddings));
        }
        else
        {
            Hand hand = new(expId, expHandNumber, expRules, expDate, expTakerScore, expTwentyOne, expExcuse, expPetit,
                expChelem, expBiddings);
            Assert.Equal(expId, hand.Id);
            Assert.Equal(expHandNumber, hand.Number);
            Assert.Equal(expRules, hand.Rules);
            Assert.Equal(expDate, hand.Date);
            Assert.Equal(expTakerScore, hand.TakerScore);
            Assert.Equal(expTwentyOne, hand.TwentyOne);
            Assert.Equal(expExcuse, hand.Excuse);
            Assert.Equal(expPetit, hand.Petit);
            Assert.Equal(expChelem, hand.Chelem);
            if (isValid) Assert.Equal(expBiddings, hand.Biddings);
            else Assert.NotEqual(expBiddings, hand.Biddings);
        }
    }

    [Fact]
    public void TestConstructor()
    {
        const ulong expId = 0L;
        const int expNum = 1;
        var expRules = new FrenchTarotRules();
        var expDate = DateTime.Now;
        const int expTakerScore = 0;
        bool? expTwentyOne = null;
        bool? expExcuse = null;
        var expPetit = PetitResult.Unknown;
        var expChelem = Chelem.Unknown;
        Hand hand = new(expNum, expRules, expDate, expTakerScore, expTwentyOne, expExcuse, expPetit, expChelem);

        Assert.Equal(expId, hand.Id);
        Assert.Equal(expNum, hand.Number);
        Assert.Equal(expRules, hand.Rules);
        Assert.Equal(expDate, hand.Date);
        Assert.Equal(expTakerScore, hand.TakerScore);
        Assert.Equal(expTwentyOne, hand.TwentyOne);
        Assert.Equal(expExcuse, hand.Excuse);
        Assert.Equal(expPetit, hand.Petit);
        Assert.Equal(expChelem, hand.Chelem);
        Assert.Empty(hand.Biddings);
    }

    [Theory]
    [MemberData(nameof(HandTestData.Data_TestAddBidding), MemberType = typeof(HandTestData))]
    public void TestAddBidding(bool expResult, IEnumerable<KeyValuePair<Player, (Bidding, Poignee)>> expBiddings,
        Hand hand, Player player, Bidding bidding, Poignee poignee)
    {
        Assert.Equal(expResult, hand.AddBidding(player, bidding, poignee));
        Assert.Equal(expBiddings, hand.Biddings);
    }

    [Theory]
    [MemberData(nameof(HandTestData.Data_TestAddBiddings), MemberType = typeof(HandTestData))]
    public void TestAddBiddings(bool expResult, IEnumerable<KeyValuePair<Player, (Bidding, Poignee)>> expBiddings,
        Hand hand, params KeyValuePair<Player, (Bidding, Poignee)>[] biddings)
    {
        Assert.Equal(expResult, hand.AddBiddings(biddings));
        Assert.Equal(expBiddings, hand.Biddings);
    }

    [Theory]
    [MemberData(nameof(HandTestData.Data_TestHashCode), MemberType = typeof(HandTestData))]
    public void TestHashCode(bool expResult, Hand hand1, Hand hand2) => Assert.Equal(expResult, hand1.GetHashCode() == hand2.GetHashCode());

    [Theory]
    [MemberData(nameof(HandTestData.Data_TestEquals), MemberType = typeof(HandTestData))]
    public void TestEquals(bool expResult, Hand hand1, object? hand2) =>
        Assert.Equal(expResult, hand1.Equals(hand2));

    [Fact]
    public void TestEquals_Null_Type_Ref()
    {
        Hand hand = new(1, new FrenchTarotRules(), DateTime.Now, 0, null, null, PetitResult.Unknown, Chelem.Unknown);
        Assert.False(Hand.FullComparer.Equals(hand, null));
        Assert.False(Hand.FullComparer.Equals(null, hand));
        Assert.False(hand!.Equals(new object()));
        Assert.True(hand!.Equals(hand as object));
    }
}