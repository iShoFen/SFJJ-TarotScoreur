using Model.Data;

namespace Tarot2B2Model;

/// <summary>
/// The database Loader manager
/// </summary>
public partial class DbWriter : IWriter
{
    /// <summary>
    /// UnitOfWork for processing with data.
    /// </summary>
    private IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Instantiate a DbWriter with IUnitIOfWork implementation.
    /// </summary>
    /// <param name="unitOfWork">Implementation of IUnitOfWork to use</param>
    public DbWriter(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        unitOfWork.SetTracking(true);
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
            UnitOfWork.Dispose();
        }
    }
}