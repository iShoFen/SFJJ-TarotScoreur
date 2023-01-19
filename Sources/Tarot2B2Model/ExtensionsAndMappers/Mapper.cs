using Model.Games;
using Model.Players;
using TarotDB;

namespace Tarot2B2Model.ExtensionsAndMappers;

/// <summary>
/// A generic Mapper for Model to Database Entities
/// </summary>
/// <typeparam name="TModel"> The Model Type </typeparam>
/// <typeparam name="TEntity"> The Database Entity Type </typeparam>
internal class Mapper<TModel, TEntity> where TModel : class
    where TEntity : class
{
    /// <summary>
    /// The Model to Entity Mapping
    /// </summary>
    private readonly HashSet<Tuple<TModel, TEntity>> _mapper = new();

    /// <summary>
    /// Reset the Mapper (call when the connection with the database is closed)
    /// </summary>
    public void Reset() => _mapper.Clear();

    /// <summary>
    /// Get the Model from the Entity
    /// </summary>
    /// <param name="entity"> The Entity </param>
    /// <returns> The Model </returns>
    public TModel? GetModel(TEntity entity) => _mapper.FirstOrDefault(x => x.Item2 == entity)?.Item1;

    /// <summary>
    /// Get the Entity from the Model
    /// </summary>
    /// <param name="model"> The Model </param>
    /// <returns> The Entity </returns>
    public TEntity? GetEntity(TModel model) => _mapper.FirstOrDefault(x => x.Item1 == model)?.Item2;

    /// <summary>
    /// Map the Model to the Entity
    /// </summary>
    /// <param name="model"> The Model </param>
    /// <param name="entity"> The Entity </param>
    /// <returns></returns>
    public bool Map(TModel model, TEntity entity) => _mapper.Add(Tuple.Create(model, entity));
}

/// <summary>
/// A static class to hold the Mappers
/// </summary>
internal static class Mapper
{
    /// <summary>
    /// The Mapper for the Hand
    /// </summary>
    public static Mapper<Hand, HandEntity> HandsMapper { get; } = new();

    /// <summary>
    /// The Mapper for the Game
    /// </summary>
    public static Mapper<Game, GameEntity> GamesMapper { get; } = new();

    /// <summary>
    /// The Mapper for the Player
    /// </summary>
    public static Mapper<Player, PlayerEntity> PlayersMapper { get; } = new();

    /// <summary>
    /// The Mapper for the User
    /// </summary>
    public static Mapper<User, UserEntity> UsersMapper { get; } = new();

    /// <summary>
    /// The Mapper for the Group
    /// </summary>
    public static Mapper<Group, GroupEntity> GroupsMapper { get; } = new();

    /// <summary>
    /// Reset all the Mappers (call when the connection with the database is closed)
    /// </summary>
    public static void Reset()
    {
        HandsMapper.Reset();
        GamesMapper.Reset();
        PlayersMapper.Reset();
        UsersMapper.Reset();
        GroupsMapper.Reset();
        
    }
}