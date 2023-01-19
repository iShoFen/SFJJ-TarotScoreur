using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using UT_Tarot2B2Model.Extensions.DataTest;
using Xunit;

namespace UT_Tarot2B2Model.Extensions;

public class UT_GameExtensions
{
    [Theory]
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntity), MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntity), MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GamesAndGameEntities), MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GamesAndGameEntities), MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntityWithPlayer),
        MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntityWithPlayer),
        MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntityWithPlayerAndHands),
        MemberType = typeof(GameExtensionsDataTest))]
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
    [MemberData(nameof(GameExtensionsDataTest.GameAndGameEntityWithPlayerAndHands),
        MemberType = typeof(GameExtensionsDataTest))]
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