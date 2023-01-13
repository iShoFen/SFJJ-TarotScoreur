namespace Tarot2B2Model;

public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
{
	/// <summary>
	/// Return the IQueryable of the entity
	/// </summary>
	IQueryable<TEntity> Set { get; }

	/// <summary>
	/// Insert a new entity
	/// </summary>
	/// <param name="item">The entity to insert </param>
	/// <returns> The inserted entity </returns>
	Task<TEntity> Insert(TEntity item);
	
	/// <summary>
	/// Add multiple entities 
	/// </summary>
	/// <param name="items"> The entities to add </param>
	/// <returns> True if the operation was successful, false otherwise </returns>
	Task<bool> AddRange(params TEntity[] items);
	
	/// <summary>
	/// Update an entity
	/// </summary>
	/// <param name="item"> The entity to update </param>
	/// <returns> The updated entity </returns>
	Task<TEntity> Update(TEntity item);
	
	/// <summary>
	/// Delete an entity
	/// </summary>
	/// <param name="id"> The id of the entity to delete</param>
	/// <returns> True if the operation was successful, false otherwise </returns>
	Task<bool> Delete(object id);
	
	/// <summary>
	/// Delete an entity
	/// </summary>
	/// <param name="item"> The entity to delete</param>
	/// <returns> True if the operation was successful, false otherwise </returns>
	Task<bool> Delete(TEntity item);
	
	/// <summary>
	/// Get an entity by id
	/// </summary>
	/// <param name="id"> The id of the entity to get </param>
	/// <returns> The entity </returns>
	Task<TEntity?> GetById(object id);
	
	/// <summary>
	/// Get all entities with paging
	/// </summary>
	/// <param name="start"> The index of the page </param>
	/// <param name="count"> The number of entities per page </param>
	/// <returns> The entities </returns>
	Task<IEnumerable<TEntity>> GetItems(int start, int count);

	/// <summary>
	/// Clear all entities
	/// </summary>
	Task Clear();
	
	/// <summary>
	/// Get the number of entities
	/// </summary>
	/// <returns> The number of entities </returns>
	Task<int> Count();

	/// <summary>
	/// Save the changes 
	/// </summary>
	/// <param name="cancellationToken"> The cancellation token </param>
	/// <returns> The number of affected entities </returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}