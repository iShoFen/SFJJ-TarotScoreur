using Model;
using Model.games;
using TarotDB;
using static Tarot2B2Model.Mapper;

namespace Tarot2B2Model;

/// <summary>
/// Extension methods for the Game and GameEntity classes.
/// </summary>
internal static class GameExtensions
{
    /// <summary>
    /// Converts a Game to a GameEntity.
    /// </summary>
    /// <param name="model"> The Game </param>
    /// <returns> The GameEntity </returns>
    public static GameEntity ToEntity(this Game model)
    {
        var gameEntity = GamesMapper.GetEntity(model);
        
        if (gameEntity is not null) return gameEntity;
        gameEntity = new GameEntity() 
        {
            Id = model.Id,
            Name = model.Name,
            Rules = model.Rules.Name,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Players = model.Players.Select(p => p.ToEntity()).ToHashSet(),
            Hands = model.Hands.Select(kv => kv.Value.ToEntity()).ToHashSet()
        };

        GamesMapper.Map(model, gameEntity);
        
        return gameEntity;
    }

    /// <summary>
    /// Converts a GameEntity to a Game.
    /// </summary>
    /// <param name="entity"> The GameEntity </param>
    /// <returns> The Game </returns>
    public static Game ToModel(this GameEntity entity)
    {
        var game = GamesMapper.GetModel(entity);
        
        if (game is not null) return game;
        game = new Game(
            entity.Id, 
            entity.Name,
            RulesFactory.Create(entity.Name)!,
            entity.StartDate,
            entity.EndDate
        );
        game.AddPlayers(entity.Players.Select(p => p.ToModel()).ToArray());
        game.AddHands(entity.Hands.Select(h => h.ToModel()).ToArray());
        
        GamesMapper.Map(game, entity);

        return game;
    }
    
    /// <summary>
    /// Converts a collections of Game to a collection of GameEntity
    /// </summary>
    /// <param name="models"> The collection of Game </param>
    /// <returns> The collection of GameEntity </returns>
    public static IEnumerable<GameEntity> ToEntities(this IEnumerable<Game> models) => models.Select(m => m.ToEntity());
    
    /// <summary>
    /// Converts a collections of GameEntity to a collection of Game
    /// </summary>
    /// <param name="entities"> The collection of GameEntity </param>
    /// <returns> The collection of Game </returns>
    public static IEnumerable<Game> ToModels(this IEnumerable<GameEntity> entities) => entities.Select(e => e.ToModel());
}