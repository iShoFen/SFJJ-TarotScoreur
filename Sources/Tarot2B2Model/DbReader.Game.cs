using Microsoft.EntityFrameworkCore;
using Model.Games;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<IEnumerable<Game>> GetGames(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        await using var context = GetContext();
        return context.Games
            .Skip((start - 1) * count)
            .Include(g => g.Players)
            .Include(g => g.Hands)
            .Take(count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<Game?> GetGameById(ulong gameId)
    {
        await using var context = GetContext();
        return context.Games.FirstOrDefault(g => g.Id == gameId)?.ToModel();
    }

    public async Task<IEnumerable<Game>> GetGamesByName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        await using var context = GetContext();
        return context.Games
            .Where(g => g.Name.Contains(pattern))
            .Paginate(start, count)
            .ToModels();
    }

    public async Task<IEnumerable<Game>> GetGamesByPlayer(ulong playerId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        await using var context = GetContext();
        return context.Players
                   .Include(p => p.Games)
                   .FirstOrDefault(p => p.Id == playerId)
                   ?.Games
                   .Paginate(start, count)
                   .ToModels()
               ?? new List<Game>();
    }

    public async Task<IEnumerable<Game>> GetGamesByDate(DateTime startDate, DateTime endDate, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        await using var context = GetContext();
        return context.Games
            .Where(g => g.StartDate.CompareTo(startDate) >= 0
                        && endDate.CompareTo(g.EndDate) >= 0)
            .Paginate(start, count)
            .ToModels();
    }
}