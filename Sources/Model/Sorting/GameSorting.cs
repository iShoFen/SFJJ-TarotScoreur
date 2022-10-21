using Model.games;

namespace Model.Sorting;

public static class GameSorting
{
    public static IEnumerable<Game> SortByAscendingName(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => string.Compare(game1.Name, game2.Name, StringComparison.Ordinal));
    
    public static IEnumerable<Game> SortByDescendingName(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => string.Compare(game2.Name, game1.Name, StringComparison.Ordinal));

    public static IEnumerable<Game> SortByAscendingStartDate(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => game1.StartDate.CompareTo(game2.StartDate));
    
    public static IEnumerable<Game> SortByDescendingStartDate(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => game2.StartDate.CompareTo(game1.StartDate));
    
    public static IEnumerable<Game> SortByAscendingEndDate(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => Nullable.Compare(game1.EndDate, game2.EndDate));
    
    public static IEnumerable<Game> SortByDescendingEndDate(IEnumerable<Game> data)
        => Sorting.Sort(data, (game1, game2) => Nullable.Compare(game2.EndDate, game1.EndDate));
}
