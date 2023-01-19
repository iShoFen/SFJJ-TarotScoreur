using Microsoft.EntityFrameworkCore;
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

        gameToInsert.Hands = gameToInsert.Hands.Where(h => h.Id == 0).ToHashSet();

        var result = await UnitOfWork.Repository<GameEntity>().Insert(gameToInsert);

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Game?> UpdateGame(Game game)
    {
        Mapper.Reset();
        var gameToUpdate = await UnitOfWork.Repository<GameEntity>()
            .Set
            .Include(g => g.Players)
            .Include(g => g.Hands)
            .FirstOrDefaultAsync(g => g.Id == game.Id);
        if (gameToUpdate == null) return null;

        var gameEntitySource = game.ToEntity();

        foreach (var property in typeof(GameEntity).GetProperties()
                     .Where(p => p is
                     {
                         CanWrite: true,
                         Name: not (nameof(GameEntity.Id)
                         or nameof(GameEntity.Players)
                         or nameof(GameEntity.Hands))
                     }))
        {
            property.SetValue(gameToUpdate, property.GetValue(gameEntitySource));
        }

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
        => await DeleteGame(game.Id);
}