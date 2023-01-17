using System.Collections;
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
	

	public static IEnumerable<object[]> InsertData()
		=> GenericData.Data()
			.Select(item => new[] {item[0], item[1], item[2], GenericData.CreateEntity((Type) item[2], 1UL)});

	public static IEnumerable<object[]> AddRangeData()
		=> GenericData.Data()
			.Select(item => new[] {item[0], item[1], item[2], Array.Empty<object>()})
			.Concat(GenericData.Data()
				.Select(item => new[]
					{item[0], item[1], item[2], new List<object> {GenericData.CreateEntity((Type) item[2], 1UL)}}))
			.Concat(GenericData.Data()
				.Select(item => new[]
				{
					item[0], item[1], item[2],
					new List<object>
					{
						GenericData.CreateEntity((Type) item[2], 1UL),
						GenericData.CreateEntity((Type) item[2], 2UL),
						GenericData.CreateEntity((Type) item[2], 3UL)
					}
				}));

	public static IEnumerable<object[]> DeleteData()
		=> GenericData.Data()
			.Select(item => new[] {item[0], item[1], item[2], 
				GenericData.CreateEntity((Type) item[2], (Type) item[2] == typeof(UserEntity) ? 11UL : 1UL ), true})
			.Concat(GenericData.Data()
				.Select(item => new[]
					{item[0], item[1], item[2], GenericData.CreateEntity((Type) item[2], 150UL), false}));
	public static IEnumerable<object[]> GetItemsData()
		=> GenericData.Data().SelectMany(item => new[]
		{
			new[] {item[0], item[1], item[2], -1, 10, 0},
			new[] {item[0], item[1], item[2], 0, 10, 0},
			new[] {item[0], item[1], item[2], 1, -1, 0},
			new[] {item[0], item[1], item[2], 1, 0, 0},
			new[] {item[0], item[1], item[2], 150, 10, 0},
			new[] {item[0], item[1], item[2], 1, 1, 1},
			new[] {item[0], item[1], item[2], 1, 2, 2},
			new[] {item[0], item[1], item[2], 2, 1, 1}
		});

	public static IEnumerable<object[]> SaveChangesAsyncData()
		=> GenericData.Data()
			.Select(item => new[] {item[0], item[1], item[2], Array.Empty<object>()})
			.Concat(GenericData.Data()
				.Select(item => new[]
					{item[0], item[1], item[2], new List<object>
					{
						GenericData.CreateEntity((Type) item[2], (Type) item[2] == typeof(UserEntity) ? 11UL : 1UL )
					}}))
			.Concat(GenericData.Data()
				.Where(item => (Type) item[2] != typeof(UserEntity))
				.Select(item => new[]
				{
					item[0], item[1], item[2],
					new List<object>
					{
						GenericData.CreateEntity((Type) item[2], (Type) item[2] == typeof(UserEntity) ? 11UL : 1UL ),
						GenericData.CreateEntity((Type) item[2], (Type) item[2] == typeof(UserEntity) ? 12UL : 2UL ),
						GenericData.CreateEntity((Type) item[2], (Type) item[2] == typeof(UserEntity) ? 13UL : 3UL )
					}
				}));

			[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestConstructor(bool isValid, Type context, Type entity)
	{
		var constructor = context.GetConstructor(new[] {typeof(DbContextOptions<TarotDbContext>)});

		await using var dbContext = (TarotDbContextStub) constructor!.Invoke(new object?[] {InitDb()});
		await dbContext.Database.EnsureCreatedAsync();
		constructor = typeof(GenericRepository<>).MakeGenericType(entity)
			.GetConstructor(new[] {typeof(TarotDbContext)});

		object? repository = null;
		if (!isValid)
		{
			var exception =
				Assert.Throws<TargetInvocationException>(() => constructor!.Invoke(new object?[] {dbContext}));
			var innerException = exception.InnerException;
			Assert.IsType<ArgumentException>(innerException);
			Assert.Equal($"The type {entity.Name} is not a valid entity type for this context.",
				innerException.Message);
		}
		else
		{
			repository = constructor!.Invoke(new object?[] {dbContext});
		}

		Assert.True(repository != null == isValid);
	}

	private static async Task<Tuple<TarotDbContextStub, object>> CreateInstance(Type context, Type entity)
	{
		var constructor = context.GetConstructor(new[] {typeof(DbContextOptions<TarotDbContext>)});
		var dbContext = (TarotDbContextStub) constructor!.Invoke(new object?[] {InitDb()});
		await dbContext.Database.EnsureCreatedAsync();

		constructor = typeof(GenericRepository<>).MakeGenericType(entity)
			.GetConstructor(new[] {typeof(TarotDbContext)});
		var repository = constructor!.Invoke(new object?[] {dbContext});

		return new Tuple<TarotDbContextStub, object>(dbContext, repository);
	}

	[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestSet(bool isValid, Type context, Type entity)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entity);


		var set = repository.GetType().GetProperty("Set")!.GetValue(repository);

		var dbSet = dbContext.GetType().GetProperty(entity.Name.Replace("Entity", "s"))!.GetValue(dbContext);

		Assert.Equal(dbSet, set);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(InsertData))]
	public async Task TestInsert(bool isValid, Type context, Type entityType, object entity)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Insert")!;

		var result = (Task) method.Invoke(repository, new[] {entity})!;
		await result.ConfigureAwait(false);
		var resultEntity = result.GetType().GetProperty("Result")!.GetValue(result);

		Assert.Equal(entity, resultEntity);
		Assert.Equal(EntityState.Added, dbContext.Entry(entity).State);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(AddRangeData))]
	public async Task TestAddRange(bool isValid, Type context, Type entityType, IEnumerable<object> iObjectEntities)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var objectEntities = iObjectEntities.ToList();
		var entities = Array.CreateInstance(entityType, objectEntities.Count);
		var i = 0;
		foreach (var objectEntity in objectEntities)
		{
			entities.SetValue(objectEntity, i);
			++i;
		}

		var method = repository.GetType().GetMethod("AddRange")!;
		var result = (Task) method.Invoke(repository, new object?[] {entities})!;
		await result.ConfigureAwait(false);
		var resultBoolean = (bool) result.GetType().GetProperty("Result")!.GetValue(result)!;

		Assert.True(resultBoolean);
		Assert.Equal(entities.Length, dbContext.ChangeTracker.Entries().Count());

		foreach (var entity in entities)
		{
			Assert.Equal(EntityState.Added, dbContext.Entry(entity).State);
		}

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(InsertData))]
	public async Task TestUpdate(bool isValid, Type context, Type entityType, object entity)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Update")!;

		var result = (Task) method.Invoke(repository, new[] {entity})!;
		await result.ConfigureAwait(false);
		var resultEntity = result.GetType().GetProperty("Result")!.GetValue(result);

		Assert.Equal(entity, resultEntity);
		Assert.Equal(EntityState.Modified, dbContext.Entry(entity).State);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(DeleteData))]
	public async Task TestDeleteItem(bool isValid, Type context, Type entityType, object entity, bool isDeleted)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Delete", new[] {entityType})!;
		var result = await (Task<bool>) method.Invoke(repository, new[] {entity})!;

		Assert.True(result);
		Assert.Equal(EntityState.Deleted, dbContext.Entry(entity).State);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(DeleteData))]
	public async Task TestDeleteId(bool isValid, Type context, Type entityType, object entity, bool isDeleted)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Delete", new[] {typeof(ulong)})!;

		var result =
			await (Task<bool>) method.Invoke(repository, new[] {entity.GetType().GetProperty("Id")!.GetValue(entity)})!;

		Assert.Equal(isDeleted, result);

		if (isDeleted)
		{
			var dbSet = dbContext.GetType().GetProperty(entityType.Name.Replace("Entity", "s"))!.GetValue(dbContext)!;

			var findMethod = dbSet.GetType().GetMethod("Find", new[] {typeof(object?[])})!;
			var resultEntity = findMethod.Invoke(dbSet,
				new object?[] {new[] {entity.GetType().GetProperty("Id")!.GetValue(entity)}})!;
			Assert.Equal(EntityState.Deleted, dbContext.Entry(resultEntity).State);
		}
		else
		{
			Assert.Equal(EntityState.Detached, dbContext.Entry(entity).State);
		}

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(DeleteData))]
	public async Task TestGetById(bool isValid, Type context, Type entityType, object entity, bool isExists)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("GetById", new[] {typeof(ulong)})!;

		var result = (Task) method.Invoke(repository, new[] {entity.GetType().GetProperty("Id")!.GetValue(entity)})!;
		await result.ConfigureAwait(false);
		var resultEntity = result.GetType().GetProperty("Result")!.GetValue(result);

		Assert.Equal(isExists, resultEntity != null);

		if (isExists)
		{
			Assert.Equal(entity.GetType().GetProperty("Id"), resultEntity!.GetType().GetProperty("Id"));
		}

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(GetItemsData))]
	public async Task TestGetItems(bool isValid, Type context, Type entityType, int start, int count, int exceptedCount)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("GetItems", new[] {typeof(int), typeof(int)})!;

		var result = (Task) method.Invoke(repository, new object?[] {start, count})!;
		await result.ConfigureAwait(false);
		var resultEntities = (IEnumerable) result.GetType().GetProperty("Result")!.GetValue(result)!;

		Assert.Equal(exceptedCount, resultEntities.Cast<object>().Count());

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestClear(bool isValid, Type context, Type entityType)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Clear")!;
		method.Invoke(repository, null);
		var dbSet =
			(IEnumerable) dbContext.GetType().GetProperty(entityType.Name.Replace("Entity", "s"))!.GetValue(dbContext)!;
		foreach (var item in dbSet)
		{
			Assert.Equal(EntityState.Deleted, dbContext.Entry(item).State);
		}

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestCount(bool isValid, Type context, Type entityType)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Count")!;
		var result = await (Task<int>) method.Invoke(repository, null)!;

		var dbSet =
			(IEnumerable) dbContext.GetType().GetProperty(entityType.Name.Replace("Entity", "s"))!.GetValue(dbContext)!;
		Assert.Equal(dbSet.Cast<object>().Count(), result);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(SaveChangesAsyncData))]
	public async Task TestSaveChangesAsync(bool isValid, Type context, Type entityType, IEnumerable<object> iEntities)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var entities = iEntities.ToList();

		foreach (var entity in entities)
		{
			dbContext.Remove((await dbContext
				.FindAsync(entity.GetType(), entity.GetType().GetProperty("Id")!.GetValue(entity)))!);
		}

		var method = repository.GetType().GetMethod("SaveChangesAsync", new[] {typeof(CancellationToken)})!;
		var result = await (Task<int>) method.Invoke(repository, new object?[] {null})!;

		Assert.Equal(entities.Count, result);
	}

	[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestDispose(bool isValid, Type context, Type entityType)
	{
		if (!isValid) return;

		var (dbContext, repository) = await CreateInstance(context, entityType);

		var method = repository.GetType().GetMethod("Dispose")!;
		method.Invoke(repository, null);

		Assert.Throws<ObjectDisposedException>(() => dbContext.Database.EnsureDeleted());
	}
}