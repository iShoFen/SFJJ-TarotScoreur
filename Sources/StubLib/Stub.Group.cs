using Model.Players;
using Utils;

namespace StubLib;

public partial class Stub
{
    public async Task<IEnumerable<Group>> GetGroups(int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Group>();
        return await Task.FromResult(_groupList.Paginate(start, count));
    }

    public async Task<Group?> GetGroupById(ulong groupId)
        => await Task.FromResult(_groupList.FirstOrDefault(g => g.Id == groupId));

    public async Task<IEnumerable<Group>> GetGroupsByName(string pattern, int start, int count)
        => await Task.FromResult(_groupList.Where(g => g.Name.Contains(pattern)).Paginate(start, count));

    public async Task<IEnumerable<Group>> GetGroupsByPlayer(ulong playerId, int start, int count)
    {
        if (start == 0 || count == 0) return new List<Group>();
        return await Task.FromResult(_groupList
            .Where(g => g.Players.Any(p => p.Id == playerId))
            .Paginate(start, count));
    }
}