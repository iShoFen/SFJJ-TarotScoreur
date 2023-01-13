using Microsoft.EntityFrameworkCore;

namespace Tarot2B2Model;

internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
	public IQueryable<TEntity> Set => _dbSet;
	
	/// <summary>
	/// The database context
	/// </summary>
	private readonly DbContext _dbContext;
	
	/// <summary>
	/// The database set
	/// </summary>
	private readonly DbSet<TEntity> _dbSet;
	
	/// <summary>
	/// Initializes a new instance of GenericRepository
	/// </summary>
	/// <param name="dbContext">The database context</param>
	public GenericRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = _dbContext.Set<TEntity>();
	}
	
	public virtual async Task<TEntity> Insert(TEntity item)
		=> (await _dbSet.AddAsync(item)).Entity;


	public virtual async Task<bool> AddRange(params TEntity[] items)
	{
		await _dbSet.AddRangeAsync(items);

		return true;
	}

	public virtual async Task<TEntity> Update(TEntity item)
		=> (await Task.Run(() => _dbSet.Update(item))).Entity;


	// is { } == is TEntity
	public virtual async Task<bool> Delete(object id)
		=> await _dbSet.FindAsync(id) is { } item && await Delete(item);
	
	public virtual async Task<bool> Delete(TEntity item)
	{
		 await Task.Run(() => _dbSet.Remove(item));
		 
		 return true;
	}

	public virtual async Task<TEntity?> GetById(object id) 
		=> await _dbSet.FindAsync(id); 
	

	public virtual async Task<IEnumerable<TEntity>> GetItems(int start, int count)
		=> start <= 0 && count <= 0
			? await Task.Run(Enumerable.Empty<TEntity>)
			: await _dbSet.Skip((start -1) * count).Take(count).ToListAsync();

	public virtual async Task Clear()
		=> await Task.Run(() => _dbSet.RemoveRange(_dbSet));
	
	public virtual async Task<int> Count()
		=> await _dbSet.CountAsync();

	public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		=> await _dbContext.SaveChangesAsync(cancellationToken);

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	protected virtual void Dispose(bool disposing)
		=>_dbContext.Dispose();
	
}