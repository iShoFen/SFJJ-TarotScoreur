namespace Model;

public abstract class Ranking<T>
{
    public string Name { get; protected set; }
    
    public GameType GameType { get; protected set; }

    protected readonly List<T> _datas = new();

    protected Ranking(string name, GameType gameType, IEnumerable<T> data)
    {
        Name = name;
        GameType = gameType;
        _datas.AddRange(data);
    }

    public abstract IEnumerable<T> SortByAscendingScore();
    public abstract IEnumerable<T> SortByDescendingScore();
    public abstract IEnumerable<T> SortByAscendingDate();
    public abstract IEnumerable<T> SortByDescendingDate();
    public abstract IEnumerable<T> SortByDateRange(DateTime startDate, DateTime endDate);
    public abstract IEnumerable<T> SortByWin();
    public abstract IEnumerable<T> SortByLoss();
}