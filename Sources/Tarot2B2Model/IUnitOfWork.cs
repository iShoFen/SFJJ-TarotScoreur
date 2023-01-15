namespace Tarot2B2Model;

public interface IUnitOfWork : IDisposable
{
	/// <summary>
	/// Return the repository for the specified type
	/// </summary>
	/// <typeparam name="TEntity"> The type of the entity </typeparam>
	/// <returns> The repository </returns>
	IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
	
	/// <summary>
	/// Save pending changes to the database
	/// </summary>
	/// <param name="cancellationToken"> The cancellation token </param>
	/// <returns> The number of objects written to the underlying database </returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	
	/// <summary>
	/// Reject pending changes to the database
	/// </summary>
	Task RejectChangesAsync();
}