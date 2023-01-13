namespace Tarot2B2Model;

public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
{
	IQueryable<TEntity> Set { get; }

	Task<TEntity> Insert(TEntity item);
	
	Task<TEntity> Update(TEntity item);
	
	Task<TEntity> Update(object id, TEntity item);
	
	Task<bool> Delete(object id);
	
	Task<bool> Delete(TEntity item);
	
	Task<TEntity> FindById(object id);
	
	
}