namespace Tarot2B2Model;

internal static class Tarot2B2ModelUtils
{
    internal static IQueryable<T> Paginate<T>(this IQueryable<T> list, int start, int count)
        => list.Skip((start - 1) * count).Take(count);

    internal static IEnumerable<T> Paginate<T>(this IEnumerable<T> list, int start, int count)
        => list.AsQueryable().Paginate(start, count);
}