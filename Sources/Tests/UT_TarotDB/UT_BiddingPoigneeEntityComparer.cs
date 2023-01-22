using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_BiddingPoigneeEntityComparer
{
    [Theory]
    [MemberData(nameof(BiddingPoigneeEntityTestData.CompareData), MemberType = typeof(BiddingPoigneeEntityTestData))]
    internal void CompareObjectTest(BiddingPoigneeEntity? bpe1, BiddingPoigneeEntity? bpe2, bool isEqual)
    {
        var result = BiddingPoigneeEntity.Comparer.Equals(bpe1, bpe2);

        Assert.Equal(isEqual, result);
    }
}