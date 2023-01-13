namespace Tarot2B2Model;

internal interface IUnitOfWork : IDisposable
{
	IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
}