using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;

namespace UT_Writer;

using static TestUtils.DataManagers;

internal static class HandWriterDataTest
{
    public static IEnumerable<object?[]> InsertHandData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    0UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                new Hand(33UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    0UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail,
                    KeyValuePair.Create(new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                        (Biddings.Petite, Poignee.Simple)),
                    KeyValuePair.Create(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        (Biddings.King, Poignee.None))
                ),
                new Hand(
                    33UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail,
                    KeyValuePair.Create(new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                        (Biddings.Petite, Poignee.Simple)),
                    KeyValuePair.Create(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        (Biddings.King, Poignee.None))
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    0UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail,
                    KeyValuePair.Create(new Player(0UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                        (Biddings.Petite, Poignee.Simple)),
                    KeyValuePair.Create(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        (Biddings.King, Poignee.None))
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    0UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail,
                    KeyValuePair.Create(new Player(50UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                        (Biddings.Petite, Poignee.Simple)),
                    KeyValuePair.Create(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        (Biddings.King, Poignee.None))
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    20UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                10UL,
                new Hand(
                    50UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                50UL,
                new Hand(
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                0UL,
                new Hand(
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                1UL,
                new Hand(
                    0UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
        }
    }

    public static IEnumerable<object?[]> UpdateHandData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    0UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    100UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    3UL,
                    6,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    60,
                    true,
                    false,
                    PetitResults.Owned,
                    Chelem.Announced),
                new Hand(
                    3UL,
                    6,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    60,
                    true,
                    false,
                    PetitResults.Owned,
                    Chelem.Announced)
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(6UL,
                    3,
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    151,
                    true,
                    false,
                    PetitResults.Owned,
                    Chelem.Success,
                    KeyValuePair.Create(new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        (Biddings.Opponent, Poignee.Triple)),
                    KeyValuePair.Create(new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        (Biddings.King, Poignee.Simple)),
                    KeyValuePair.Create(new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
                        (Biddings.Opponent, Poignee.Triple))),
                new Hand(6UL,
                    3,
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    151,
                    true,
                    false,
                    PetitResults.Owned,
                    Chelem.Success,
                    KeyValuePair.Create(new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                        (Biddings.Opponent, Poignee.Triple)),
                    KeyValuePair.Create(new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        (Biddings.King, Poignee.Simple)),
                    KeyValuePair.Create(new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
                        (Biddings.Opponent, Poignee.Triple)))
            };
        }
    }

    public static IEnumerable<object?[]> DeleteHandWithObjectData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    23UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    32UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    0UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                new Hand(
                    50UL,
                    5,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                false
            };
        }
    }

    public static IEnumerable<object?[]> DeleteHandWithIdData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                23UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                32UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                0UL,
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                50UL,
                false
            };
        }
    }
}