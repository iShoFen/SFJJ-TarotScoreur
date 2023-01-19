using Model.Data;
using NLog;

namespace Model;

public partial class Manager
{
    /// <summary>
    /// IReader from read methods (select)
    /// </summary>
    private IReader _reader;

    /// <summary>
    /// IWriter for write methods (create, update, delete)
    /// </summary>
    private IWriter _writer;

    /// <summary>
    /// 
    /// </summary>
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Instantiate a new Manager with IReader and IWriter interfaces 
    /// </summary>
    /// <param name="reader">IReader to use in the Manager</param>
    /// <param name="writer">IWriter to use in the Manager</param>
    public Manager(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
        _logger.Info("Instantiate Manager");
    }

    /// <summary>
    /// Set the new Reader to use when read methods (select) are called.
    /// </summary>
    /// <param name="reader">New reader</param>
    /// <returns>Instance of Manager for chaining methods</returns>
    public Manager SetReader(IReader reader)
    {
        _reader = reader;
        _logger.Info("Set Loader in DataManager");
        return this;
    }

    /// <summary>
    /// Set the new Writer to use when write methods (create, update, delete) are called.
    /// </summary>
    /// <param name="writer">New writer</param>
    /// <returns>Instance of Manager for chaining methods</returns>
    public Manager SetWriter(IWriter writer)
    {
        _writer = writer;
        _logger.Info("Set Saver in DataManager");
        return this;
    }
}