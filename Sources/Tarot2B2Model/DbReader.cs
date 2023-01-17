using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Games;
using TarotDB;
using Utils;

namespace Tarot2B2Model;

public partial class DbReader : IReader
{
    private readonly IUnitOfWork _unitOfWork;

    public DbReader(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private IQueryable<TEntity> Set<TEntity>() where TEntity : class => _unitOfWork.Repository<TEntity>().Set;

    private IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class =>
        _unitOfWork.Repository<TEntity>();

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