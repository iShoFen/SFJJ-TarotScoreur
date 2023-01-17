using Model.Players;
using TarotDB;

namespace Tarot2B2Model.ExtensionsAndMappers;

internal static class PlayerExtension
{
    /// <summary>
    /// Converts a Player to a PlayerEntity thanks to extension method
    /// </summary>
    /// <param name="player">Player to convert into PlayerEntity</param>
    /// <returns>PlayerEntity converted</returns>
    public static PlayerEntity ToEntity(this Player player)
    {
        var playerEntity = Mapper.PlayersMapper.GetEntity(player);
        if (playerEntity is not null) return playerEntity;
        playerEntity = new PlayerEntity
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Nickname = player.NickName,
            Avatar = player.Avatar
        };

        return playerEntity;
    }

    /// <summary>
    /// Converts a PlayerEntity to a Player thanks to extension method
    /// </summary>
    /// <param name="playerEntity">PlayerEntity to convert into Player</param>
    /// <returns>Player converted</returns>
    public static Player ToModel(this PlayerEntity playerEntity)
    {
        var playerModel = Mapper.PlayersMapper.GetModel(playerEntity);
        if (playerModel is not null) return playerModel;
        playerModel = new Player(playerEntity.Id, playerEntity.FirstName, playerEntity.LastName, playerEntity.Nickname,
            playerEntity.Avatar);

        return playerModel;
    }

    /// <summary>
    /// Converts a collection of Player to a collection of PlayerEntity thanks to extension method
    /// </summary>
    /// <param name="players">Collection of Player to convert</param>
    /// <returns>Collection of PlayerEntity converted</returns>
    public static IEnumerable<PlayerEntity> ToEntities(this IEnumerable<Player> players)
        => players.Select(e => e.ToEntity());

    /// <summary>
    /// Converts a collection of PlayerEntity to a collection of Player thanks to extension method
    /// </summary>
    /// <param name="players">Collection of PlayerEntity to convert</param>
    /// <returns>Collection of Player converted</returns>
    public static IEnumerable<Player> ToModels(this IEnumerable<PlayerEntity> players)
        => players.Select(e => e.ToModel());

    /// <summary>
    /// Converts a Player to a PlayerEntity and map the result in Mapper thanks to extension method.
    /// </summary>
    /// <param name="player">Player to convert and map</param>
    /// <returns>PlayerEntity converted</returns>
    public static PlayerEntity MapToEntity(this Player player)
    {
        var playerEntity = Mapper.PlayersMapper.GetEntity(player);
        if (playerEntity is not null) return playerEntity;

        playerEntity = player.ToEntity();
        Mapper.PlayersMapper.Map(player, playerEntity);
        return playerEntity;
    }

    /// <summary>
    /// Converts a PlayerEntity to a Player and map the result in Mapper thanks to extension method.
    /// </summary>
    /// <param name="entity">PlayerEntity to convert and map</param>
    /// <returns>Player converted</returns>
    public static Player MapToModel(this PlayerEntity entity)
    {
        var player = Mapper.PlayersMapper.GetModel(entity);
        if (player is not null) return player;

        player = entity.ToModel();
        Mapper.PlayersMapper.Map(player, entity);
        return player;
    }

    /// <summary>
    /// Converts a collection of PlayerEntity to a collection of Player
    /// and map the result in Mapper thanks to extension method.
    /// </summary>
    /// <param name="players">Collection of PlayerEntity to convert and map</param>
    /// <returns>Collection of Player converted</returns>
    public static IEnumerable<PlayerEntity> MapToEntities(this IEnumerable<Player> players)
        => players.Select(e => e.MapToEntity());

    /// <summary>
    /// Converts a collection of PlayerEntity to a collection of Player
    /// and map the result in Mapper thanks to extension method.
    /// </summary>
    /// <param name="players">Collection of PlayerEntity to convert</param>
    /// <returns>Collection of Player converted</returns>
    public static IEnumerable<Player> MapToModels(this IEnumerable<PlayerEntity> players)
        => players.Select(e => e.MapToModel());
}