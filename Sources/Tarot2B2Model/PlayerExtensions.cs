using Model.Players;
using TarotDB;

namespace Tarot2B2Model;

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

        Mapper.PlayersMapper.Map(player, playerEntity);

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

        Mapper.PlayersMapper.Map(playerModel, playerEntity);

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
}