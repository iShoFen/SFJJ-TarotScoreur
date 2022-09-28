namespace Model.Ranking;

/// <summary>
/// Generic Ranking class with 2 template type
/// </summary>
/// <typeparam name="T">generic input type for the ranking</typeparam>
public abstract class Ranking<T>
{
    /// <summary>
    /// name of this Ranking
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// game type of this GameType
    /// </summary>
    public GameType GameType { get; }

    /// <summary>
    /// set of datas to apply the ranking
    /// </summary>
    protected readonly List<T> _datas = new();

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="name">name of this Ranking</param>
    /// <param name="gameType">game type of this Ranking</param>
    /// <param name="datas">datas of this Ranking</param>
    protected Ranking(string name, GameType gameType, params T[] datas)
    {
        Name = name;
        GameType = gameType;
        AddRankingData(datas);
    }

    /// <summary>
    /// adds T data to the data of the ranking
    /// </summary>
    /// <param name="rankingDatas">data to add</param>
    public void AddRankingData(params T[] rankingDatas)
    {
        _datas.AddRange(rankingDatas);
    }

    public abstract IEnumerable<T> SortByAscendingScore();
    public abstract IEnumerable<T> SortByDescendingScore();
    public abstract IEnumerable<T> SortByAscendingDate();
    public abstract IEnumerable<T> SortByDescendingDate();
    public abstract IEnumerable<T> SortByAscendingDateRange(DateTime startDate, DateTime endDate);
    public abstract IEnumerable<T> SortByDescendingDateRange(DateTime startDate, DateTime endDate);
    public abstract IEnumerable<T> SortByAscendingWin();
    public abstract IEnumerable<T> SortByDescendingWin();
    public abstract IEnumerable<T> SortByAscendingLoss();
    public abstract IEnumerable<T> SortByDescendingLoss();
    
    protected IEnumerable<T> GenericSort(Comparison<T> comparison)
    {
        var sortedData = new List<T>(_datas);
        sortedData.Sort(comparison);
        return sortedData;
    }
}