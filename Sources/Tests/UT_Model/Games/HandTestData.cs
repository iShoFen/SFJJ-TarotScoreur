using System.Globalization;
using Model.Rules;
using Model.Enums;
using Model.Players;
using Model.Games;

namespace UT_Model.Games;

public static class HandTestData
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
            PetitResults.Unknown,
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
            PetitResults.Owned,
            Chelem.Announced,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))
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
            PetitResults.Unknown,
            Chelem.Unknown,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double)
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
            PetitResults.Unknown,
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
            PetitResults.Unknown,
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
            PetitResults.Unknown,
            Chelem.Unknown,
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))
        };
    }

    public static IEnumerable<object[]> Data_TestAddBidding()
    {
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now, 45, null, null, PetitResults.Unknown, Chelem.Unknown),
            new Player("Florent", "Marques", "Flo", ""),
            Biddings.Unknown,
            Poignee.None
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Player("Jordan", "Artzet", "Jojo", ""),
            Biddings.King,
            Poignee.Double
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Player("Florent", "Marques", "Flo", ""),
            Biddings.Unknown,
            Poignee.None
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))),
            new Player("Jordan", "Artzet", "Jojo", ""),
            Biddings.Unknown,
            Poignee.None
        };
    }

    public static IEnumerable<object[]> Data_TestAddBiddings()
    {
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now, 45, null, null, PetitResults.Unknown, Chelem.Unknown),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now, 45, null, null, PetitResults.Unknown, Chelem.Unknown),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))
        };
        yield return new object[]
        {
            true,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double),
                [new Player("Samuel", "Sirven", "Sam", "")] = (Biddings.GardeContreLeChien, Poignee.None),
                [new Player("Julien", "Themes", "Juju", "")] = (Biddings.Opponent, Poignee.None)
            },
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(new Player("Julien", "Themes", "Juju", ""), (Biddings.Opponent, Poignee.None))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None)
            },
            new Hand(1, new FrenchTarotRules(), DateTime.Now, 45, null, null, PetitResults.Unknown, Chelem.Unknown),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double)
            },
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
            KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))
        };
        yield return new object[]
        {
            false,
            new Dictionary<Player, (Biddings, Poignee)>
            {
                [new Player("Florent", "Marques", "Flo", "")] = (Biddings.Unknown, Poignee.None),
                [new Player("Jordan", "Artzet", "Jojo", "")] = (Biddings.King, Poignee.Double)
            },
            new Hand(1, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)),
                KeyValuePair.Create(new Player("Jordan", "Artzet", "Jojo", ""), (Biddings.King, Poignee.Double))),
            KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))
        };
    }

    public static IEnumerable<object[]> Data_TestHashCode()
    {
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(45L, 25, new FrenchTarotRules(), DateTime.MaxValue, 25, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
        yield return new object[]
        {
            true,
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.MaxValue, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 0, true, true, PetitResults.Owned, Chelem.Fail,
                KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", "  "), (Biddings.Petite, Poignee.Simple)))
        };
        yield return new object[]
        {
            true,
            new Hand(1L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(32L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            true,
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(0L, 32, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(2L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(32L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };

        yield return new object[]
        {
            false,
            new Hand(0L, 2, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(0L, 32, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
    }
    
    public static IEnumerable<object?[]> Data_TestEquals()
    {
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost,
                Chelem.Announced),
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            true,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(45L, 25, new FrenchTarotRules(), DateTime.MaxValue, 25, null, null, PetitResults.Unknown, Chelem.Unknown)
        };
        yield return new object[]
        {
            true,
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.MaxValue, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.MaxValue, 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None)))
        };
        yield return new object?[]
        {
            false,
            new Hand(1, new FrenchTarotRules(), DateTime.Now, 45, null, null, PetitResults.Unknown, Chelem.Unknown),
            null,
        };
        yield return new object[]
        {
            false,
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(45L, 0, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Now, 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 0, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, true, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, true, PetitResults.Lost, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Owned, Chelem.Announced)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Fail)
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.GardeContreLeChien, Poignee.Double)))
        };
        yield return new object[]
        {
            false,
            new Hand(45L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Florent", "Marques", "Flo", ""), (Biddings.Unknown, Poignee.None))),
            new Hand(0L, 1, new FrenchTarotRules(), DateTime.Parse("12/12/2022", CultureInfo.InvariantCulture), 45, false, false, PetitResults.Lost, Chelem.Announced,
                KeyValuePair.Create(new Player("Samuel", "Sirven", "Sam", ""), (Biddings.Unknown, Poignee.None)))
        };
    }
}