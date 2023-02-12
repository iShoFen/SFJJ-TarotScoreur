using Microsoft.EntityFrameworkCore;
using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using Utils;

namespace Tarot2B2Model;

/// <summary>
/// The database Reader manager
/// </summary>
public partial class DbReader
{
    public async Task<IEnumerable<Player>> GetPlayers(int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        Mapper.Reset();
        return (await _unitOfWork.Repository<PlayerEntity>().GetItems(start, count)).ToModels();
    }

    public async Task<Player?> GetPlayerById(ulong playerId)
    {
        Mapper.Reset();
        return (await Repository<PlayerEntity>().GetById(playerId))?.ToModel();
    }

    public async Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        Mapper.Reset();
        return Set<PlayerEntity>()
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern)
                        || p.Nickname.Contains(pattern))
            .Paginate(start, count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        Mapper.Reset();
        return Set<PlayerEntity>()
            .Where(p => p.Nickname.Contains(pattern))
            .Paginate(start, count)
            .AsEnumerable()
            .ToModels();
    }

    public async Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<Player>());

        Mapper.Reset();
        return Set<PlayerEntity>()
            .Where(p => p.FirstName.Contains(pattern)
                        || p.LastName.Contains(pattern))
            .Paginate(start, count)
            .AsEnumerable()
            .ToModels();
    }
}