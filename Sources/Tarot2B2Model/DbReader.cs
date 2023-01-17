using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Games;
using TarotDB;
using Utils;

namespace Tarot2B2Model;

public partial class DbReader : IReader
{
    /// <summary>
    /// UnitOfWork for processing with data.
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Instantiate a DbReader with IUnitIOfWork implementation.
    /// </summary>
    /// <param name="unitOfWork">Implementation of IUnitOfWork to use</param>
    public DbReader(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<KeyValuePair<int, Hand>>> GetHandsByGame(ulong gameId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<KeyValuePair<int, Hand>>());

        Mapper.Reset();

        return (Set<GameEntity>()
                    .Where(g => g.Id == gameId)
                    .Include(g => g.Hands)
                    .FirstOrDefault()
                    ?.Hands
                ?? new List<HandEntity>())
            .Paginate(start, count)
            .ToModels()
            .ToDictionary(h => h.Number);
    }

    private IQueryable<TEntity> Set<TEntity>() where TEntity : class => _unitOfWork.Repository<TEntity>().Set;

    private IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        => _unitOfWork.Repository<TEntity>();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}