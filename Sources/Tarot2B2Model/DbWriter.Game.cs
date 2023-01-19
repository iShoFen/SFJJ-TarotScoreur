using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<Game?> InsertGame(Game game)
    {
        if (game.Id != 0) return null;
        Mapper.Reset();

        var gameToInsert = game.ToEntity();
        gameToInsert.Players =
            gameToInsert.Players.Select(p => UnitOfWork.Repository<PlayerEntity>().GetById(p.Id).Result!)
                .ToHashSet();

        gameToInsert.Hands = gameToInsert.Hands
            .Select(h => UnitOfWork.Repository<HandEntity>().GetById(h.Id).Result!).ToHashSet();

        var result = await UnitOfWork.Repository<GameEntity>().Insert(gameToInsert);

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Game?> UpdateGame(Game game)
    {
        Mapper.Reset();
        var gameToUpdate = await UnitOfWork.Repository<GameEntity>().GetById(game.Id);
        if (gameToUpdate == null) return null;

        var gameEntitySource = game.ToEntity();

        foreach (var property in typeof(GameEntity).GetProperties()
                     .Where(p => p.CanWrite && p.Name != nameof(GameEntity.Id)))
        {
            property.SetValue(gameToUpdate, property.GetValue(gameEntitySource));
        }

        gameToUpdate.Players =
            gameToUpdate.Players.Select(p => UnitOfWork.Repository<PlayerEntity>().GetById(p.Id).Result!)
                .ToHashSet();

        gameToUpdate.Hands = gameToUpdate.Hands
            .Select(h => UnitOfWork.Repository<HandEntity>().GetById(h.Id).Result!).ToHashSet();

        var result = await UnitOfWork.Repository<GameEntity>().Update(gameToUpdate);

        await UnitOfWork.SaveChangesAsync();

        return result.ToModel();
    }

    public async Task<bool> DeleteGame(ulong gameId)
    {
        var result = await UnitOfWork.Repository<GameEntity>().Delete(gameId);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }

    public async Task<bool> DeleteGame(Game game)
    {
        var gameToDelete = await UnitOfWork.Repository<GameEntity>().GetById(game.Id);
        if (gameToDelete == null) return false;

        var result = await UnitOfWork.Repository<GameEntity>().Delete(gameToDelete);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }
}