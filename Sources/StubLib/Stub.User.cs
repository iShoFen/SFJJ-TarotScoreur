using Model.Players;
using Utils;

namespace StubLib;

public partial class Stub
{
    public async Task<IEnumerable<User>> GetUsers(int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<User>();
        return await Task.FromResult(_playerList
            .Where(p => p is User)
            .Paginate(start, count)
            .Select(p => (User)p)
        );
    }

    public async Task<User?> GetUserById(ulong userId)
        => await Task.FromResult(_playerList.FirstOrDefault(p => p.Id == userId)) as User;

    public async Task<IEnumerable<User>> GetUsersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<User>();
        return await Task.FromResult(_playerList
            .Where(p => p is User
                        && (p.FirstName.Contains(pattern)
                            || p.LastName.Contains(pattern)
                            || p.NickName.Contains(pattern)))
            .Paginate(start, count).Select(p => (User)p));
    }

    public async Task<IEnumerable<User>> GetUsersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<User>();
        return await Task.FromResult(_playerList
            .Where(p => p is User && p.NickName.Contains(pattern))
            .Paginate(start, count).Select(p => (User)p));
    }

    public async Task<IEnumerable<User>> GetUsersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return new List<User>();
        return await Task.FromResult(_playerList
            .Where(p => p is User
                        && (p.FirstName.Contains(pattern)
                            || p.LastName.Contains(pattern)))
            .Paginate(start, count).Select(p => (User)p));
    }
}