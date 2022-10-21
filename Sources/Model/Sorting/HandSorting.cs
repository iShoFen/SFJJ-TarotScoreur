namespace Model.Sorting;

public static class HandSorting
{
    public static IDictionary<Player, int> SortByAscendingPoints(IDictionary<Player, int> data)
        => Sorting.SortByValue(data, (x, y) => x - y).ToDictionary(x => x.Key, x => x.Value);
    // => data.OrderBy(pair => pair.Value).ToDictionary(x => x.Key, x => x.Value);

    public static IDictionary<Player, int> SortByDescendingPoints(IDictionary<Player, int> data)
        => Sorting.SortByValue(data, (x, y) => y - x).ToDictionary(x => x.Key, x => x.Value);
    // => data.OrderByDescending(pair => pair.Value).ToDictionary(x => x.Key, x => x.Value);
}