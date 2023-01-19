using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;
using TarotDB;
using TarotDB.Enums;

namespace UT_Tarot2B2Model.Extensions.DataTest;

internal static class HandExtensionsDataTest
{
    public static IEnumerable<object[]> HandAndHandEntity()
    {
        yield return new object[]
        {
            new Hand(1UL,
                1,
                new FrenchTarotRules(),
                new DateTime(2022, 09, 21),
                22,
                true,
                true,
                PetitResults.Lost,
                Chelem.Announced,
                KeyValuePair.Create(
                    new Player(0UL, "Player1", "1Player", "1P1", "avatar1"), (Biddings.Garde, Poignee.None)
                )),
            new HandEntity
            {
                Id = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21),
                TakerScore = 22,
                TwentyOne = true,
                Excuse = true,
                Petit = PetitResultsDb.Lost,
                Chelem = ChelemDb.Announced,
                Biddings = new List<BiddingPoigneeEntity>()
                {
                    new BiddingPoigneeEntity
                    {
                        Player = new PlayerEntity
                        {
                            Id = 0UL,
                            FirstName = "Player1",
                            LastName = "1Player",
                            Nickname = "1P1",
                            Avatar = "avatar1"
                        },
                        Biddings = BiddingsDb.Garde,
                        Poignee = PoigneeDb.None
                    },
                }
            }
        };
    }

    public static IEnumerable<object[]> HandsAndHandEntities()
    {
        yield return new object[]
        {
            new List<Hand>
            {
                new(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 22, true, true, PetitResults.Lost,
                    Chelem.Announced),
                new(2UL, 2, new FrenchTarotRules(), new DateTime(2022, 09, 21), 44, false, true, PetitResults.Lost,
                    Chelem.Unknown),
                new(3UL, 3, new FrenchTarotRules(), new DateTime(2022, 09, 21), 69, true, true,
                    PetitResults.AuBoutOwned, Chelem.NotAnnouncedSuccess)
            },
            new List<HandEntity>
            {
                new()
                {
                    Id = 1UL,
                    Number = 1,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 22,
                    TwentyOne = true,
                    Excuse = true,
                    Petit = PetitResultsDb.Lost,
                    Chelem = ChelemDb.Announced
                },
                new()
                {
                    Id = 2UL,
                    Number = 2,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 44,
                    TwentyOne = false,
                    Excuse = true,
                    Petit = PetitResultsDb.Lost,
                    Chelem = ChelemDb.Unknown
                },
                new()
                {
                    Id = 3UL,
                    Number = 3,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 69,
                    TwentyOne = true,
                    Excuse = true,
                    Petit = PetitResultsDb.AuBoutOwned,
                    Chelem = ChelemDb.NotAnnouncedSuccess
                }
            }
        };
    }
}