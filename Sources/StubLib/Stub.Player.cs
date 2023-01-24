using Model.Players;
using Utils;

namespace StubLib;

public partial class Stub
{
    public async Task<IEnumerable<Player>> GetPlayers(int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Paginate(start, count)
            .Select(p => new Player(p.Id,
                    p.FirstName,
                    p.LastName,
                    p.NickName,
                    p.Avatar
                )
            )
        );
    }

    public async Task<Player?> GetPlayerById(ulong playerId)
        => await Task.FromResult(_playerList.FirstOrDefault(p => p.Id == playerId));

    public async Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern)
                        || p.NickName.Contains(pattern))
            .Paginate(start, count)
            .Select(p => new Player(p.Id, p.FirstName, p.LastName, p.NickName, p.Avatar)));
    }

    public async Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.NickName.Contains(pattern))
            .Paginate(start, count)
            .Select(p => new Player(p.Id, p.FirstName, p.LastName, p.NickName, p.Avatar)));
    }

    public async Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<Player>();
        return await Task.FromResult(_playerList
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern))
            .Paginate(start, count)
            .Select(p => new Player(p.Id, p.FirstName, p.LastName, p.NickName, p.Avatar)));
    }
}