using TarotDB;
using TarotDB.Enums;

namespace UT_TarotDB;

internal static class BiddingPoigneeEntityTestData
{
    public static IEnumerable<object?[]> CompareData()
    {
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 0, PlayerId = 0 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 0, PlayerId = 0 },
            false
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            true
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 0, PlayerId = 2 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            false
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 0 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            false
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 0, PlayerId = 2 },
            false
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 0 },
            false
        };
        yield return new object?[]
        {
            null,
            null,
            false
        };
        yield return new object?[]
        {
            null,
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 0 },
            false
        };
        yield return new object?[]
        {
            new BiddingPoigneeEntity
                { Biddings = BiddingsDb.Prise, Poignee = PoigneeDb.None, HandId = 1, PlayerId = 2 },
            null,
            false
        };
    }
}