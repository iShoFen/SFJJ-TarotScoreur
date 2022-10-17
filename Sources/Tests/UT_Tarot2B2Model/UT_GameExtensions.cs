using Model;
using Model.enums;
using Model.games;
using Tarot2B2Model;
using TarotDB;
using TarotDB.enums;
using TestUtils;
using Xunit;

namespace UT_Tarot2B2Model;

public class UT_GameExtensions
{
    public static IEnumerable<object[]> Data_AddGameAndGameEntity()
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

    public static IEnumerable<object[]> Data_AddGameWithPlayerAndGameEntity()
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

    public static IEnumerable<object[]> Data_AddGameAndGameEntityWithPlayerAndHands()
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
                        PetitResult.Owned, Chelem.Announced)
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
                        Petit = PetitResultDB.Owned,
                        Chelem = ChelemDB.Announced
                    }
                }

            }
        };
    }

    public static IEnumerable<object[]> Data_AddGamesAndGamesEntities()
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

    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntity))]
    internal void TestGameEntityToModel(Game game, GameEntity gameEntity)
    {
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To verify if the mapper work
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntity))]
    internal void TestGameToEntity(Game game, GameEntity gameEntity)
    {
        var gameToEntity = game.ToEntity();
        Assert.Equal(gameEntity.Id, gameToEntity.Id);
        Assert.Equal(gameEntity.Name, gameToEntity.Name);
        Assert.Equal(gameEntity.Rules, gameToEntity.Rules);
        Assert.Equal(gameEntity.StartDate, gameToEntity.StartDate);
        Assert.Equal(gameEntity.EndDate, gameToEntity.EndDate);


        //To verify if the mapper work
        Assert.Same(game.ToEntity(), gameToEntity);
    }

    [Theory]
    [MemberData(nameof(Data_AddGamesAndGamesEntities))]
    internal void TestGameEntitiesToModels(List<Game> games, List<GameEntity> gameEntities)
    {
        var gameEntitiesToModels = gameEntities.ToModels();
        Assert.Equal(games, gameEntitiesToModels);

        var i = 0;
        foreach (var game in gameEntitiesToModels)
        {
            Assert.Same(game, gameEntities[i].ToModel());
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(Data_AddGamesAndGamesEntities))]
    internal void TestGamesToEntities(List<Game> games, List<GameEntity> gameEntities)
    {
        var gameToEntities = games.ToEntities().ToList();
        var i = 0;
        foreach (var gameEntity in gameEntities)
        {
            Assert.Equal(gameEntity.Id, gameToEntities[i].Id);
            Assert.Equal(gameEntity.Rules, gameToEntities[i].Rules);
            Assert.Equal(gameEntity.Name, gameToEntities[i].Name);
            Assert.Equal(gameEntity.StartDate, gameToEntities[i].StartDate);
            Assert.Equal(gameEntity.EndDate, gameToEntities[i].EndDate);
            ++i;
        }

        i = 0;
        foreach (var gameEntity in gameToEntities)
        {
            Assert.Same(gameEntity, games[i].ToEntity());
            ++i;
        }


    }


    [Theory]
    [MemberData(nameof(Data_AddGameWithPlayerAndGameEntity))]
    internal void TestGameEntityToModelWithPlayers(Game game, GameEntity gameEntity)
    {
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To force the mapper to be used
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameWithPlayerAndGameEntity))]
    internal void TestGameToEntityWithPlayers(Game game, GameEntity gameEntity)
    {
        var gameToEntity = game.ToEntity();
        
        Assert.Equal(gameEntity.Id, gameToEntity.Id);
        Assert.Equal(gameEntity.Name, gameToEntity.Name);
        Assert.Equal(gameEntity.Rules, gameToEntity.Rules);
        Assert.Equal(gameEntity.StartDate, gameToEntity.StartDate);
        Assert.Equal(gameEntity.EndDate, gameToEntity.EndDate);
        
        var i = 0;
        var players = gameToEntity.Players.ToList();
        foreach (var player in gameEntity.Players)
        {
            Assert.Equal(player.Id, players[i].Id);
            Assert.Equal(player.FirstName, players[i].FirstName);
            Assert.Equal(player.LastName, players[i].LastName);
            Assert.Equal(player.Nickname, players[i].Nickname);
            Assert.Equal(player.Avatar, players[i].Avatar);
            i++;
        }

        //To force the mapper to be used
        Assert.Same(game.ToEntity(), gameToEntity);
    }


    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntityWithPlayerAndHands))]
    internal void TestGameEntityToModelWithPlayersAndHands(Game game, GameEntity gameEntity)
    {
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To force the mapper to be used
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntityWithPlayerAndHands))]
    internal void TestGameToEntityWithPlayersAndHands(Game game, GameEntity gameEntity)
    {
        var gameToEntity = game.ToEntity();
        Assert.Equal(gameEntity.Id, gameToEntity.Id);
        Assert.Equal(gameEntity.Name, gameToEntity.Name);
        Assert.Equal(gameEntity.Rules, gameToEntity.Rules);
        Assert.Equal(gameEntity.StartDate, gameToEntity.StartDate);
        Assert.Equal(gameEntity.EndDate, gameToEntity.EndDate);
        
        var i = 0;
        var players = gameToEntity.Players.ToList();
        foreach (var player in gameEntity.Players)
        {
            Assert.Equal(player.Id, players[i].Id);
            Assert.Equal(player.FirstName, players[i].FirstName);
            Assert.Equal(player.LastName, players[i].LastName);
            Assert.Equal(player.Nickname, players[i].Nickname);
            Assert.Equal(player.Avatar, players[i].Avatar);
            i++;
        }

        i = 0;
        var hands = gameToEntity.Hands.ToList();
        foreach (var hand in gameEntity.Hands)
        {
            Assert.Equal(hand.Id, hands[i].Id);
            Assert.Equal(hand.Number, hands[i].Number);
            Assert.Equal(hand.Rules, hands[i].Rules);
            Assert.Equal(hand.Date, hands[i].Date);
            Assert.Equal(hand.TakerScore, hands[i].TakerScore);
            Assert.Equal(hand.TwentyOne, hands[i].TwentyOne);
            Assert.Equal(hand.Excuse, hands[i].Excuse);
            Assert.Equal(hand.Petit, hands[i].Petit);
            Assert.Equal(hand.Chelem, hands[i].Chelem);
            i++;
        }

        //To force the mapper to be used
        Assert.Same(game.ToEntity(), gameToEntity);

    }
}