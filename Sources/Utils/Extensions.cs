namespace Utils;

public static class Extensions
{
    public  static IQueryable<T> Paginate<T>(this IQueryable<T> list, int start, int count)
        => list.Skip((start - 1) * count).Take(count);

    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> list, int start, int count)
        => list.AsQueryable().Paginate(start, count);
}