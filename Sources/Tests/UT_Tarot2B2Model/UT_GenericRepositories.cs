using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StubContext;
using Tarot2B2Model;
using TarotDB;
using Xunit;
using static TestUtils.TestInitializer;

namespace UT_Tarot2B2Model;

public class UT_GenericRepositories
{
    private static readonly IEnumerable<Tuple<Type, bool>> TarotDbContextEntities = new[]
    {
        Tuple.Create(typeof(PlayerEntity), true),
        Tuple.Create(typeof(UserEntity), true),
        Tuple.Create(typeof(GroupEntity), true),
        Tuple.Create(typeof(GameEntity), true),
        Tuple.Create(typeof(HandEntity), true),
        Tuple.Create(typeof(TestEntity), false)
    };

    // for test an other context : create a new IEnumerable<Tuple<Type, bool>> with the entities you want to test
    // and use .Concat and .Select with your new List and new TarotDbContext
    public static IEnumerable<object[]> Data()
        => TarotDbContextEntities
            .Select(item => new object[] { typeof(TarotDbContextStub), item.Item1, item.Item2 });

    [Theory]
    [MemberData(nameof(Data))]
    public async Task TestConstructor(Type context, Type entity, bool isValid)
    {
        var constructor = context.GetConstructor(new[] { typeof(DbContextOptions<TarotDbContext>) });

        await using var dbContext = (TarotDbContextStub)constructor!.Invoke(new object?[] { InitDb() });
        await dbContext.Database.EnsureCreatedAsync();
        constructor = typeof(GenericRepository<>).MakeGenericType(entity)
            .GetConstructor(new[] { typeof(TarotDbContext) });

        object? repository = null;
        if (!isValid)
        {
            var exception =
                Assert.Throws<TargetInvocationException>(() => constructor!.Invoke(new object?[] { dbContext }));
            var innerException = exception.InnerException;
            Assert.IsType<ArgumentException>(innerException);
            Assert.Equal($"The type {entity.Name} is not a valid entity type for this context.",
                innerException.Message);
        }
        else
        {
            repository = constructor!.Invoke(new object?[] { dbContext });
        }

        Assert.True(repository != null == isValid);
    }

    private async Task<object> CreateInstance(Type context, Type entity)
    {
        var constructor = context.GetConstructor(new[] { typeof(DbContextOptions<TarotDbContext>) });
        var dbContext = (TarotDbContextStub)constructor!.Invoke(new object?[] { InitDb() });
        await dbContext.Database.EnsureCreatedAsync();

        constructor = typeof(GenericRepository<>).MakeGenericType(entity)
            .GetConstructor(new[] { typeof(TarotDbContext) });
        return constructor!.Invoke(new object?[] { dbContext });
    }

    [Theory]
    [MemberData(nameof(Data))]
    internal async Task TestSet(Type context, Type entity, bool isValid)
    {
        if (!isValid) return;

        var constructor = context.GetConstructor(new[] { typeof(DbContextOptions<TarotDbContext>) });
        await using var dbContext = (TarotDbContextStub)constructor!.Invoke(new object?[] { InitDb() });
        await dbContext.Database.EnsureCreatedAsync();

        constructor = typeof(GenericRepository<>).MakeGenericType(entity)
            .GetConstructor(new[] { typeof(TarotDbContext) });
        var repository = constructor!.Invoke(new object?[] { dbContext });

        var set = repository.GetType().GetProperty("Set")!.GetValue(repository);
        var dbSet = dbContext.GetType().GetProperty(entity.Name.Replace("Entity", "s"),
            BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(dbContext);

        Assert.Equal(dbSet, set);
    }
}