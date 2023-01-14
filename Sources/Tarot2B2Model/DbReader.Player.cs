using Microsoft.EntityFrameworkCore;
using Model.Players;
using Model.Data;

namespace Tarot2B2Model;

/// <summary>
/// The database Reader manager
/// </summary>
public partial class DbReader : IReader
{
    public async Task<IEnumerable<Player>> GetPlayers(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        await using var context = GetContext();
        return context.Players.Paginate(start, count).ToModels();
    }

    public async Task<Player?> GetPlayerById(ulong playerId)
    {
        await using var context = GetContext();
        return (await context.Players.FindAsync(playerId))?.ToModel();
    }

    public async Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        await using var context = GetContext();
        return context.Players
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern)
                        || p.Nickname.Contains(pattern))
            .Paginate(start, count)
            .ToModels();
    }

    public async Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        await using var context = GetContext();
        return context.Players
            .Where(p => p.Nickname.Contains(pattern))
            .Paginate(start, count)
            .ToModels();
    }

    public async Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        await using var context = GetContext();
        return context.Players
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern))
            .Paginate(start, count)
            .ToModels();
    }

    public async Task<IEnumerable<Player>> GetPlayersByGroup(ulong groupId)
    {
        await using var context = GetContext();
        return context.Groups
                   .Include(g => g.Players)
                   .FirstOrDefault(g => g.Id == groupId)
                   ?.Players
                   .ToModels()
               ?? new List<Player>();
    }
}