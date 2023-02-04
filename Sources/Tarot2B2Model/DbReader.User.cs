using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using Utils;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<IEnumerable<User>> GetUsers(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<User>());

        Mapper.Reset();
        return (await _unitOfWork.Repository<UserEntity>().GetItems(start, count)).ToModels();
    }

    public async Task<User?> GetUserById(ulong userId)
    {
        Mapper.Reset();
        return (await Repository<UserEntity>().GetById(userId))?.ToModel();
    }

    public async Task<IEnumerable<User>> GetUsersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<User>());

        Mapper.Reset();
        return Set<UserEntity>()
               .Where(p => p.FirstName.Contains(pattern)
                           || p.LastName.Contains(pattern)
                           || p.Nickname.Contains(pattern))
               .Paginate(start, count)
               .AsEnumerable()
               .ToModels();
    }

    public async Task<IEnumerable<User>> GetUsersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<User>());

        Mapper.Reset();
        return Set<UserEntity>()
               .Where(p => p.Nickname.Contains(pattern))
               .Paginate(start, count)
               .AsEnumerable()
               .ToModels();
    }

    public async Task<IEnumerable<User>> GetUsersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<User>());

        Mapper.Reset();
        return Set<UserEntity>()
               .Where(p => p.FirstName.Contains(pattern)
                           || p.LastName.Contains(pattern))
               .Paginate(start, count)
               .AsEnumerable()
               .ToModels();
    }
}
