using Microsoft.EntityFrameworkCore;
using TarotDB;

namespace Tarot2B2Model;

internal class UnitOfWork : IUnitOfWork
{
	/// <summary>
	/// The database context
	/// </summary>
	private readonly TarotDbContext _dbContext;

	/// <summary>
	/// Initializes a new instance of UnitOfWork
	/// </summary>
	/// <param name="dbContext"> The DbContext to use </param>
	/// <param name="noTracking"> Whether to use NoTracking queries </param>
	public UnitOfWork(TarotDbContext dbContext, bool noTracking = true)
	{
		_dbContext = dbContext;
		
		if (noTracking) _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}
	
	public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
		=> new GenericRepository<TEntity>(_dbContext);

	public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		var result = await _dbContext.SaveChangesAsync(cancellationToken);
		
		_dbContext.ChangeTracker.Entries()
			.Where(e => e.State != EntityState.Detached).ToList()
			.ForEach(e => e.State = EntityState.Detached);	

		return result;
	}

	public virtual async Task RejectChangesAsync()
	{
		await Task.Run(() =>
		{
			foreach (var entry in _dbContext.ChangeTracker.Entries()
				.Where(e => e.State != EntityState.Unchanged))
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					
					case EntityState.Modified:
					case EntityState.Deleted:
						entry.Reload();
						break;
				}
			}
		});
	}
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_dbContext?.Dispose();
		}
	}
}