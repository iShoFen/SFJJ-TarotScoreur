namespace Utils;

public static class Extensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> list, int start, int count)
    {
        var skipNumber = (start - 1) * count;
        if (start > 1 && skipNumber < count) return Enumerable.Empty<T>().AsQueryable();

        return list.Skip(skipNumber).Take(count);
    }

    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> list, int start, int count)
        => list.AsQueryable().Paginate(start, count);

    public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> list, int start, int count)
        => await Task.Run(() => list.Paginate(start, count));

    public static async Task<IEnumerable<T>> PaginateAsync<T>(this IEnumerable<T> list, int start, int count)
        => await Task.Run(() => list.AsQueryable().Paginate(start, count));
}
