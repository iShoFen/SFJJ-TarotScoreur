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
        unitOfWork.SetTracking(false);
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