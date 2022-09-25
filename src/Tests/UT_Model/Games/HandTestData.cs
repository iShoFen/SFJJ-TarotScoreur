using Model;
using Model.enums;
using Model.games;

namespace UT_Model.Games;

public class HandTestData
{
    public static IEnumerable<object?[]> Data_TestFullConstructor()
    {
        yield return new object?[]
        {
            true,
            ulong.MinValue,
            1,
            new FrenchTarotRules(),
            DateTime.Now,
            45,
            null,
            null,
            PetitResult.Unknown,
            Chelem.Unknown
        };
        yield return new object?[]
        {
            true,
            ulong.MaxValue,
            1,
            new FrenchTarotRules(),
            DateTime.Now,
            45,
            false,
            true,
            PetitResult.Owned,
            Chelem.Announced,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))
        };
        yield return new object?[]
        {
            true,
            ulong.MaxValue,
            1,
            new FrenchTarotRules(),
            DateTime.Now,
            45,
            false,
            true,
            PetitResult.Unknown,
            Chelem.Unknown,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double)
            )
        };
        yield return new object?[]
        {
            false,
            ulong.MaxValue,
            1,
            null,
            DateTime.Now,
            45,
            false,
            true,
            PetitResult.Unknown,
            Chelem.Unknown,
        };
        yield return new object?[]
        {
            false,
            ulong.MaxValue,
            1,
            new FrenchTarotRules(),
            DateTime.MinValue,
            45,
            false,
            true,
            PetitResult.Unknown,
            Chelem.Unknown,
        };
        yield return new object?[]
        {
            false,
            ulong.MaxValue,
            1,
            new FrenchTarotRules(),
            DateTime.Now,
            45,
            false,
            true,
            PetitResult.Unknown,
            Chelem.Unknown,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))
        };
    }

    public static IEnumerable<object[]> Data_TestAddBidding()
    {
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now),
            new Player("Florent", "Marques", "Flo", ""),
            Bidding.Unknown,
            Poignee.None
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Player("Jordan", "Artzet", "Jojo", ""),
            Bidding.King,
            Poignee.Double
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Player("Florent", "Marques", "Flo", ""),
            Bidding.Unknown,
            Poignee.None
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))),
            new Player("Jordan", "Artzet", "Jojo", ""),
            Bidding.Unknown,
            Poignee.None
        };
    }

    public static IEnumerable<object[]> Data_TestAddBiddings()
    {
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double),
                [new Player("Samuel", "Sirven", "Sam", "")] = (Bidding.GardeContreLeChien, Poignee.None),
                [new Player("Julien", "Themes", "Juju", "")] = (Bidding.Opponent, Poignee.None)
            },
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Bidding.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(new Player("Julien", "Themes", "Juju", ""), (Bidding.Opponent, Poignee.None))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double)
            },
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Bidding, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Bidding.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Bidding.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Bidding.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Bidding.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))
        };
    }

    public static IEnumerable<object[]> Data_TestHashCode()
    {
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost,
                Chelem.Announced),
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Hand(45L, 25, new FrenchTarotRules(), DateTime.MaxValue, 25, null, null, PetitResult.Unknown,
                    Chelem.Unknown)
        };
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None)))
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 0, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022"), 45, false, false, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 0, false, false, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, true, false, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, true, PetitResult.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Owned, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Fail)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.GardeContreLeChien, Poignee.Double)))
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Bidding.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResult.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Bidding.Unknown, Poignee.None)))
        };
    }
    
    public static IEnumerable<object?[]> Data_TestEquals()
    {
        yield return new object?[]
        {
            false,
            new Hand(1, new FrenchTarotRules(), DateTime.Now),
            null,
        };
        foreach (var data in Data_TestHashCode())
        {
            yield return new[]
            {
                data[0],
                data[1],
                data[2]
            };
        }
    }
}