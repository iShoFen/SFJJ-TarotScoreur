using Model.Games;

namespace Tarot2B2Model;

public partial class DbWriter
{
    // public async Task<Game?> InsertGame(Game game)
    // {
    //     Mapper.Reset();
    //
    //     await using var context = InitContext();
    //     var gameEntity = game.ToEntity();
    //
    //     if (await context.Games.FindAsync(game.Id) != null || game.Id != 0UL) return null;
    //     var result = await context.AddAsync(gameEntity);
    //
    //     await context.SaveChangesAsync();
    //
    //     return result.Entity.ToModel();
    // }
    public async Task<Game?> InsertGame(Game game)
    {
        throw new NotImplementedException();
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