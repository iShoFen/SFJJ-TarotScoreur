using Model.Players;
using Utils;

namespace StubLib;

public partial class Stub
{
    public async Task<IEnumerable<Player>> GetPlayers(int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList.Paginate(start, count));
    }

    public async Task<Player?> GetPlayerById(ulong playerId)
        => await Task.FromResult(_playerList.FirstOrDefault(g => g.Id == playerId));

    public async Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern)
                        || p.NickName.Contains(pattern))
            .Paginate(start, count));
    }

    public async Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.NickName.Contains(pattern))
            .Paginate(start, count));
    }

    public async Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern))
            .Paginate(start, count));
    }
}