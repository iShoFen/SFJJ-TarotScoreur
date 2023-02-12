using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;
using TarotDB;
using TarotDB.Enums;
using TestUtils;

namespace UT_Tarot2B2Model.Extensions.DataTest;

internal static class GameExtensionsDataTest
{
    public static IEnumerable<object[]> GameAndGameEntity()
    {
        yield return new object[]
        {
            new Game(1UL, "Game1", RulesFactory.Rules["FrenchTarotRules"], new DateTime(2022, 09, 21), null),
            new GameEntity
            {
                Id = 1UL,
                Name = "Game1",
                Rules = new FrenchTarotRules().Name,
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null
            }
        };
    }

    public static IEnumerable<object[]> GameAndGameEntityWithPlayer()
    {
        yield return new object[]
        {
            GameTestUtils.CreateGameWithIdAndPlayers(1UL, "Game1", RulesFactory.Rules["FrenchTarotRules"],
                new DateTime(2022, 09, 21), null,
                new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")
            ),
            new GameEntity
            {
                Id = 1UL,
                Name = "Game1",
                Rules = new FrenchTarotRules().Name,
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Players = new List<PlayerEntity>
                {
                    new PlayerEntity
                    {
                        Id = 0UL,
                        FirstName = "Jean",
                        LastName = "BON",
                        Nickname = "JEBO",
                        Avatar = "avatar1"
                    },
                    new PlayerEntity
                    {
                        Id = 1UL,
                        FirstName = "Pierre",
                        LastName = "DURAND",
                        Nickname = "PIER",
                        Avatar = "avatar2"
                    },
                    new PlayerEntity
                    {
                        Id = 2UL,
                        FirstName = "Paul",
                        LastName = "MARTIN",
                        Nickname = "PAUL",
                        Avatar = "avatar3"
                    }
                }
            }
        };
    }
    
    public static IEnumerable<object[]> GameAndGameEntityWithPlayerAndHands()
    {
        yield return new object[]
        {
            GameTestUtils.CreateGameWithPlayersAndHands(1UL, "Game1", RulesFactory.Rules["FrenchTarotRules"],
                new DateTime(2022, 09, 21), null,
                new[]
                {
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")
                },
                new[]
                {
                    new Hand(1L, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 25, true, true,
                        PetitResults.Owned, Chelem.Announced)
                }

            ),
            new GameEntity
            {
                Id = 1UL,
                Name = "Game1",
                Rules = new FrenchTarotRules().Name,
                StartDate = new DateTime(2022, 09, 21),
                EndDate = null,
                Players = new List<PlayerEntity>
                {
                    new PlayerEntity
                    {
                        Id = 0UL,
                        FirstName = "Jean",
                        LastName = "BON",
                        Nickname = "JEBO",
                        Avatar = "avatar1"
                    },
                    new PlayerEntity
                    {
                        Id = 1UL,
                        FirstName = "Pierre",
                        LastName = "DURAND",
                        Nickname = "PIER",
                        Avatar = "avatar2"
                    },
                    new PlayerEntity
                    {
                        Id = 2UL,
                        FirstName = "Paul",
                        LastName = "MARTIN",
                        Nickname = "PAUL",
                        Avatar = "avatar3"
                    }
                },
                Hands = new List<HandEntity>
                {
                    new HandEntity
                    {
                        Id = 1L,
                        Number = 1,
                        Rules = new FrenchTarotRules().Name,
                        Date = new DateTime(2022, 09, 21),
                        TakerScore = 25,
                        TwentyOne = true,
                        Excuse = true,
                        Petit = PetitResultsDb.Owned,
                        Chelem = ChelemDb.Announced
                    }
                }

            }
        };
    }

    public static IEnumerable<object[]> GamesAndGameEntities()
    {
        yield return new object[]
        {
            new List<Game>
            {
                new (1UL, "Game1", RulesFactory.Rules["FrenchTarotRules"], new DateTime(2022, 09, 21), null),
                new (2UL, "Game2", RulesFactory.Rules["FrenchTarotRules"], new DateTime(2022, 09, 21), null),
                new (3UL, "Game3", RulesFactory.Rules["FrenchTarotRules"], new DateTime(2022, 09, 21), null)
            },
            new List<GameEntity>
            {
                new GameEntity
                {
                    Id = 1UL,
                    Name = "Game1",
                    Rules = new FrenchTarotRules().Name,
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new GameEntity
                {
                    Id = 2UL,
                    Name = "Game2",
                    Rules = new FrenchTarotRules().Name,
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                },
                new GameEntity
                {
                    Id = 3UL,
                    Name = "Game3",
                    Rules = new FrenchTarotRules().Name,
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = null
                }
            }

        };
    }
}