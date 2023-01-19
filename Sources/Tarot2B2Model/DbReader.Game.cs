using Microsoft.EntityFrameworkCore;
using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using Utils;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<IEnumerable<Game>> GetGames(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        Mapper.Reset();
        return (await _unitOfWork.Repository<GameEntity>().GetItems(start, count)).ToModels();
    }

    public async Task<Game?> GetGameById(ulong gameId)
    {
        Mapper.Reset();
        return (await Set<GameEntity>()
                .Include(g => g.Players)
                .Include(g => g.Hands)
                .FirstOrDefaultAsync(g => g.Id == gameId))
            ?.ToModel();
    }

    public async Task<IEnumerable<Game>> GetGamesByName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        Mapper.Reset();
        return Set<GameEntity>()
            .Where(g => g.Name.Contains(pattern))
            .Paginate(start, count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<IEnumerable<Game>> GetGamesByPlayer(ulong playerId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        Mapper.Reset();
        var games = Set<PlayerEntity>()
                        .Include(p => p.Games)
                        .FirstOrDefault(p => p.Id == playerId)
                        ?.Games
                        .Paginate(start, count)
                        .ToList()
                    ?? new List<GameEntity>();
        games.ForEach(g => g.Players.Clear());

        return games.ToModels();
    }

    public async Task<IEnumerable<Game>> GetGamesByDate(DateTime startDate, DateTime? endDate, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Game>());

        Mapper.Reset();
        return Set<GameEntity>()
            .Where(g => g.StartDate.CompareTo(startDate) >= 0
                        && (endDate == null
                            || (g.EndDate != null
                                && g.EndDate.Value.CompareTo(endDate.Value) <= 0)))
            .Paginate(start, count)
            .AsEnumerable()
            .ToModels();
    }
}