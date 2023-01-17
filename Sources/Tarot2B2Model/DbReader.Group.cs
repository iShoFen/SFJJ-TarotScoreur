using Microsoft.EntityFrameworkCore;
using Model.Players;
using TarotDB;
using Utils;

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

        return (await Set<GroupEntity>()
		        .Where(g => g.Players.Any(p => p.Id == playerId))
		        .Paginate(start, count)	                
		        .Include(g => g.Players)
		        .ToListAsync())
	        .ToModels();
    }
}