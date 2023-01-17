using Model.Rules;
using Model.Enums;
using Model.Games;
using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

public static class HandTestData
{
    public static IEnumerable<object?[]> Data_TestGetHandById()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                29UL,
                new Hand(29UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 18), 567,
                    false, true, PetitResults.LostAuBout, Chelem.Unknown,
                    KeyValuePair.Create(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                        (Biddings.Garde, Poignee.None)),
                    KeyValuePair.Create(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                        (Biddings.King, Poignee.None)))
            };
            yield return new object?[]
            {
                loader.Get(),
                14UL,
                new Hand(14UL, 2, new FrenchTarotRules(), new DateTime(2022, 09, 21), 567,
                    false, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
                    KeyValuePair.Create(new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
                        (Biddings.GardeContreLeChien, Poignee.None)),
                    KeyValuePair.Create(new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
                        (Biddings.Opponent, Poignee.None)),
                    KeyValuePair.Create(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                        (Biddings.Opponent, Poignee.None)))
            };
            yield return new object?[]
            {
                loader.Get(),
                100UL,
                null
            };
            yield return new object?[]
            {
                loader.Get(),
                0UL,
                null
            };
        }
    }
}