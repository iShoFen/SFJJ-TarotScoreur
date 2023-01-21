using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<Player?> InsertPlayer(Player player)
    {
        if (player.Id != 0) return null;
        Mapper.Reset();

        var result = await UnitOfWork.Repository<PlayerEntity>().Insert(player.ToEntity());

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Player?> UpdatePlayer(Player player)
    {
        Mapper.Reset();
        var playerToUpdate = await UnitOfWork.Repository<PlayerEntity>().GetById(player.Id);
        if (playerToUpdate == null) return null;

        var playerEntitySource = player.ToEntity();

        foreach (var property in typeof(PlayerEntity).GetProperties()
                     .Where(p => p.Name != nameof(PlayerEntity.Id)))
        {
            property.SetValue(playerToUpdate, property.GetValue(playerEntitySource));
        }

        var result = await UnitOfWork.Repository<PlayerEntity>().Update(playerToUpdate);

        await UnitOfWork.SaveChangesAsync();

        return result.ToModel();
    }

    public async Task<bool> DeletePlayer(ulong playerId)
    {
        var result = await UnitOfWork.Repository<PlayerEntity>().Delete(playerId);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }

    public async Task<bool> DeletePlayer(Player player) => await DeletePlayer(player.Id);
}