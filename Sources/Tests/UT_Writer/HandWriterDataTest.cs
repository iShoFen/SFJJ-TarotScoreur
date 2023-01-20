using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;

namespace UT_Writer;

using static TestUtils.DataManagers;
using static TestUtils.GameTestUtils;

internal static class HandWriterDataTest
{
    public static IEnumerable<object?[]> InsertHandData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(10UL, "Game 10", new FrenchTarotRules(),
                    new DateTime(2022, 09, 18), new DateTime(2022, 09, 23),
                    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13")),
                new Hand(1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                ),
                new Hand(33UL,
                    1,
                    new FrenchTarotRules(),
                    new DateTime(2023, 01, 19),
                    156,
                    false,
                    false,
                    PetitResults.AuBout,
                    Chelem.AnnouncedFail
                )
            };
        }
    }

    public static IEnumerable<object?[]> UpdateHandData()
    {
        yield return new object?[]
        {
        };
    }

    public static IEnumerable<object?[]> DeleteHandWithObjectData()
    {
        yield return new object?[]
        {
        };
    }

    public static IEnumerable<object?[]> DeleteHandWithIdData()
    {
        yield return new object?[]
        {
        };
    }
}