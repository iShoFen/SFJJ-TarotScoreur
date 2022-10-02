using Model;
using Model.games;
using TarotDB;

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
    public static GameEntity ToEntity(this Game model) => new() 
    {
        Id = model.Id,
        Name = model.Name,
        Rules = model.Rules.Name,
        StartDate = model.StartDate,
        EndDate = model.EndDate,
        Players = model.Players.Select(p => p.ToEntity()).ToHashSet(),
        // Hands = 
    };

    /// <summary>
    /// Converts a GameEntity to a Game.
    /// </summary>
    /// <param name="entity"> The GameEntity </param>
    /// <returns> The Game </returns>
    public static Game ToModel(this GameEntity entity)
    {
        Game game = new(
            entity.Id, 
            entity.Name,
            RulesFactory.Create(entity.Name)!,
            entity.StartDate,
            entity.EndDate
        );
        game.AddPlayers(entity.Players.Select(p => p.ToModel()).ToArray());
        // game.AddHands()

        return game;
    }
}