namespace Model.Sorting;

public static class Sorting
{
    public static IEnumerable<T> Sort<T>(IEnumerable<T> data, Comparison<T> comparison)
    {
        var sortedData = new List<T>(data);
        sortedData.Sort(comparison);
        return sortedData;
    }

    public static IEnumerable<KeyValuePair<TKey, TValue>> SortByKey<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> data, Func<TKey, TKey, int> comparer)
    {
        var list = data.ToList();
        list.Sort((x, y) => comparer(x.Key, y.Key));
        return list;
    }

    public static IEnumerable<KeyValuePair<TKey, TValue>> SortByValue<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, Func<TValue, TValue, int> comparer)
    {
        var list = source.ToList();
        list.Sort((x, y) => comparer(x.Value, y.Value));
        return list;
    }
}