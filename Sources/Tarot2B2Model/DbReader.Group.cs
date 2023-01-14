using Microsoft.EntityFrameworkCore;
using Model.Players;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<IEnumerable<Group>> GetGroups(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        await using var context = GetContext();
        return context.Groups
            .Skip((start - 1) * count)
            .Include(g => g.Players)
            .Take(count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<Group?> GetGroupById(ulong groupId)
    {
        await using var context = GetContext();
        return context.Groups
            .Include(g => g.Players)
            .FirstOrDefault(g => g.Id == groupId)
            ?.ToModel();
    }

    public async Task<IEnumerable<Group>> GetGroupsByName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        await using var context = GetContext();
        return context.Groups
            .Where(g => g.Name.Contains(pattern))
            .Skip((start - 1) * count)
            .Include(g => g.Players)
            .Take(count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<IEnumerable<Group>> GetGroupsByPlayer(ulong playerId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        await using var context = GetContext();
        return context.Players
                   .Include(p => p.Groups)
                   .FirstOrDefault(p => p.Id == playerId)
                   ?.Groups
                   .ToModels()
               ?? new List<Group>();
    }
}