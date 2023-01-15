using Microsoft.EntityFrameworkCore;
using Model.Players;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<IEnumerable<Group>> GetGroups(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        return Set<GroupEntity>()
            .Paginate(start, count)
            .Include(g => g.Players)
            .ToModels();
    }

    public async Task<Group?> GetGroupById(ulong groupId)
    {
        return (await Set<GroupEntity>()
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Id == groupId))
            ?.ToModel();
    }

    public async Task<IEnumerable<Group>> GetGroupsByName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        return Set<GroupEntity>()
            .Where(g => g.Name.Contains(pattern))
            .Paginate(start, count)
            .Include(g => g.Players)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<IEnumerable<Group>> GetGroupsByPlayer(ulong playerId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Group>());

        return (await Set<PlayerEntity>()
                   .Include(p => p.Groups)
                   .FirstOrDefaultAsync(p => p.Id == playerId))
               ?.Groups
               .ToModels()
               ?? new List<Group>();
    }
}