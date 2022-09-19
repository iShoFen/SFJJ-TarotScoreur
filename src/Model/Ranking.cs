namespace Model;

/// <summary>
/// Generic Ranking class with 2 template type
/// </summary>
/// <typeparam name="T">generic input type for the ranking</typeparam>
/// <typeparam name="U">generic output type for the ranking</typeparam>
public abstract class Ranking<T, U>
{
    /// <summary>
    /// name of this Ranking
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// game type of this GameType
    /// </summary>
    public GameType GameType { get; protected set; }

    /// <summary>
    /// set of datas to apply the ranking
    /// </summary>
    protected readonly HashSet<T> _datas = new();

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
        _datas.UnionWith(rankingDatas);
    }

    public abstract IEnumerable<U> SortByAscendingScore();
    public abstract IEnumerable<U> SortByDescendingScore();
    public abstract IEnumerable<U> SortByAscendingDate();
    public abstract IEnumerable<U> SortByDescendingDate();
    public abstract IEnumerable<U> SortByAscendingDateRange(DateTime startDate, DateTime endDate);
    public abstract IEnumerable<U> SortByDescendingDateRange(DateTime startDate, DateTime endDate);
    public abstract IEnumerable<U> SortByAscendingWin();
    public abstract IEnumerable<U> SortByDescendingWin();
    public abstract IEnumerable<U> SortByAscendingLoss();
    public abstract IEnumerable<U> SortByDescendingLoss();
}