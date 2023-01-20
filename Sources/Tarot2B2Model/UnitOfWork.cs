using Microsoft.EntityFrameworkCore;

namespace Tarot2B2Model;

public class UnitOfWork : IUnitOfWork
{
    public DbContext Context { get; }

    /// <summary>
    /// Initializes a new instance of UnitOfWork
    /// </summary>
    /// <param name="dbContext"> The DbContext to use </param>
    /// <param name="noTracking"> Whether to use NoTracking queries </param>
    public UnitOfWork(DbContext dbContext, bool noTracking = true)
    {
        Context = dbContext;
        Context.Database.EnsureCreated();

        if (noTracking) Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public void SetTracking(bool tracking)
    {
        Context.ChangeTracker.QueryTrackingBehavior = tracking 
            ? QueryTrackingBehavior.TrackAll 
            : QueryTrackingBehavior.NoTracking;
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        => new GenericRepository<TEntity>(Context);

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await Context.SaveChangesAsync(cancellationToken);

        Context.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Detached).ToList()
            .ForEach(e => e.State = EntityState.Detached);

        return result;
    }

    public virtual async Task RejectChangesAsync()
    {
        await Task.Run(() =>
        {
            foreach (var entry in Context.ChangeTracker.Entries()
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
            Context.Dispose();
        }
    }
}