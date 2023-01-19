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

        var groupFound = await UnitOfWork.Repository<GameEntity>().GetById(game.Id);
        if (groupFound != null) return null;

        var result = await UnitOfWork.Repository<GameEntity>().Insert(game.ToEntity());

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Game?> UpdateGame(Game game)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteGame(ulong gameId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteGame(Game game)
    {
        throw new NotImplementedException();
    }
}