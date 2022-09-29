using Model;
using TarotDB;

namespace Tarot2B2Model;

static class PlayerExtension
{
    public static PlayerEntity ToEntity(this Player player)
    {
        return new PlayerEntity()
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Nickname = player.NickName,
            Avatar = player.Avatar
        };
    }
    
    public static Player ToModel(this PlayerEntity playerEntity)
    {
        return new Player(playerEntity.Id, playerEntity.FirstName, playerEntity.LastName, playerEntity.Nickname,
            playerEntity.Avatar);
    }

    public static IEnumerable<PlayerEntity> ToEntities(this IEnumerable<Player> entities)
        => entities.Select(e => e.ToEntity());

    public static IEnumerable<Player> ToEntities(this IEnumerable<PlayerEntity> entities)
        => entities.Select(e => e.ToModel());
}