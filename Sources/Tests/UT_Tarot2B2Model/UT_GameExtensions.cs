using Model.Rules;
using Model.Enums;
using Model.Games;
using Model.Players;
using Tarot2B2Model;
using TarotDB;
using TarotDB.Enums;
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
        Mapper.Reset();
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To verify if the mapper work
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntity))]
    internal void TestGameToEntity(Game game, GameEntity gameEntity)
    {
        Mapper.Reset();
        var gameToEntity = game.ToEntity();
        Assert.Equal(gameEntity.Id, gameToEntity.Id);
        Assert.Equal(gameEntity.Name, gameToEntity.Name);
        Assert.Equal(gameEntity.Rules, gameToEntity.Rules);
        Assert.Equal(gameEntity.StartDate, gameToEntity.StartDate);
        Assert.Equal(gameEntity.EndDate, gameToEntity.EndDate);


        //To verify if the mapper work
        Assert.Same(game.ToEntity(), gameToEntity);
        
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(game.ToEntity(), gameToEntity);
    }

    [Theory]
    [MemberData(nameof(Data_AddGamesAndGamesEntities))]
    internal void TestGameEntitiesToModels(List<Game> games, List<GameEntity> gameEntities)
    {
        Mapper.Reset();
        var gameEntitiesToModels = gameEntities.ToModels().ToList();
        Assert.Equal(games, gameEntitiesToModels);

        var i = 0;
        foreach (var game in gameEntitiesToModels)
        {
            Assert.Same(game, gameEntities.ElementAt(i).ToModel());
            ++i;
        }
        //to verify if the mapper reset work
        Mapper.Reset();
        i = 0;
        foreach (var game in gameEntitiesToModels)
        {
            Assert.NotSame(game, gameEntities.ElementAt(i).ToModel());
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(Data_AddGamesAndGamesEntities))]
    internal void TestGamesToEntities(List<Game> games, List<GameEntity> gameEntities)
    {
        Mapper.Reset();
        var gameToEntities = games.ToEntities().ToList();
        var i = 0;
        foreach (var gameEntity in gameEntities)
        {
            Assert.Equal(gameEntity.Id, gameToEntities.ElementAt(i).Id);
            Assert.Equal(gameEntity.Rules, gameToEntities.ElementAt(i).Rules);
            Assert.Equal(gameEntity.Name, gameToEntities.ElementAt(i).Name);
            Assert.Equal(gameEntity.StartDate, gameToEntities.ElementAt(i).StartDate);
            Assert.Equal(gameEntity.EndDate, gameToEntities.ElementAt(i).EndDate);
            ++i;
        }

        i = 0;
        foreach (var gameEntity in gameToEntities)
        {
            Assert.Same(gameEntity, games.ElementAt(i).ToEntity());
            ++i;
        }
        
        //to verify if the mapper reset work
        Mapper.Reset();
        i = 0;
        foreach (var gameEntity in gameToEntities)
        {
            Assert.NotSame(gameEntity, games.ElementAt(i).ToEntity());
            ++i;
        }

    }


    [Theory]
    [MemberData(nameof(Data_AddGameWithPlayerAndGameEntity))]
    internal void TestGameEntityToModelWithPlayers(Game game, GameEntity gameEntity)
    {
        Mapper.Reset();
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To force the mapper to be used
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameWithPlayerAndGameEntity))]
    internal void TestGameToEntityWithPlayers(Game game, GameEntity gameEntity)
    {
        Mapper.Reset();
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
            Assert.Equal(player.Id, players.ElementAt(i).Id);
            Assert.Equal(player.FirstName, players.ElementAt(i).FirstName);
            Assert.Equal(player.LastName, players.ElementAt(i).LastName);
            Assert.Equal(player.Nickname, players.ElementAt(i).Nickname);
            Assert.Equal(player.Avatar, players.ElementAt(i).Avatar);
            i++;
        }

        //To force the mapper to be used
        Assert.Same(game.ToEntity(), gameToEntity);
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(game.ToEntity(), gameToEntity);
    }


    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntityWithPlayerAndHands))]
    internal void TestGameEntityToModelWithPlayersAndHands(Game game, GameEntity gameEntity)
    {
        Mapper.Reset();
        var gameEntityToModel = gameEntity.ToModel();
        Assert.Equal(game, gameEntityToModel);

        //To force the mapper to be used
        Assert.Same(gameEntity.ToModel(), gameEntityToModel);
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(gameEntity.ToModel(), gameEntityToModel);
    }

    [Theory]
    [MemberData(nameof(Data_AddGameAndGameEntityWithPlayerAndHands))]
    internal void TestGameToEntityWithPlayersAndHands(Game game, GameEntity gameEntity)
    {
        Mapper.Reset();
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
            Assert.Equal(player.Id, players.ElementAt(i).Id);
            Assert.Equal(player.FirstName, players.ElementAt(i).FirstName);
            Assert.Equal(player.LastName, players.ElementAt(i).LastName);
            Assert.Equal(player.Nickname, players.ElementAt(i).Nickname);
            Assert.Equal(player.Avatar, players.ElementAt(i).Avatar);
            i++;
        }

        i = 0;
        var hands = gameToEntity.Hands.ToList();
        foreach (var hand in gameEntity.Hands)
        {
            Assert.Equal(hand.Id, hands.ElementAt(i).Id);
            Assert.Equal(hand.Number, hands.ElementAt(i).Number);
            Assert.Equal(hand.Rules, hands.ElementAt(i).Rules);
            Assert.Equal(hand.Date, hands.ElementAt(i).Date);
            Assert.Equal(hand.TakerScore, hands.ElementAt(i).TakerScore);
            Assert.Equal(hand.TwentyOne, hands.ElementAt(i).TwentyOne);
            Assert.Equal(hand.Excuse, hands.ElementAt(i).Excuse);
            Assert.Equal(hand.Petit, hands.ElementAt(i).Petit);
            Assert.Equal(hand.Chelem, hands.ElementAt(i).Chelem);
            i++;
        }

        //To force the mapper to be used
        Assert.Same(game.ToEntity(), gameToEntity);
        //to verify if the mapper reset work
        Mapper.Reset();
        Assert.NotSame(game.ToEntity(), gameToEntity);
        

    }
}