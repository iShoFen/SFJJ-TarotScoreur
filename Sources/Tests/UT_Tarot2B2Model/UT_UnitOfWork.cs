using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StubContext;
using Tarot2B2Model;
using TarotDB;
using Xunit;
using static TestUtils.TestInitializer;

namespace UT_Tarot2B2Model;

public class UT_UnitOfWork
{

	public static IEnumerable<object[]> ContextsData()
	{
		yield return new object[] { typeof(TarotDbContextStub) };
	}

	public static IEnumerable<object[]> ConstructorData()
		=> ContextsData().Select(x => x[0]).Select(c => new[] {c, true})
			.Concat( ContextsData().Select(x => x[0]).Select(c => new[] {c, false}));

	public static IEnumerable<object?[]> ChangesAsyncData()
		=> GenericData.Data()
			.Select(item => new[] {item[0], item[1], Array.Empty<object?>(), false})
			.Concat(GenericData.Data()
				.Select(item => new[]
				{
					item[0], item[1],
					new[]
					{
						GenericData.CreateEntity((Type) item[2], (Type) item[2] != typeof(UserEntity) ? 1UL : 11UL),
						GenericData.CreateEntity((Type) item[2], (Type) item[2] != typeof(UserEntity) ? 2UL : 12UL),
						GenericData.CreateEntity((Type) item[2], 500UL)
					},
					(Type) item[2] == typeof(HandEntity)
				}));


	private static async Task<TarotDbContextStub> CreateDbInstance(Type context)
	{
		var constructor = context.GetConstructor(new[] {typeof(DbContextOptions<TarotDbContext>)});
		var dbContext = (TarotDbContextStub) constructor!.Invoke(new object?[] {InitDb()});
		await dbContext.Database.EnsureCreatedAsync();

		return dbContext;
	}

	[Theory]
	[MemberData(nameof(ConstructorData))]
	public async Task TestConstructor(Type contextType, bool noTracking)
	{
		var dbContext = await CreateDbInstance(contextType);
		var unitOfWork = new UnitOfWork(dbContext, noTracking);
		Assert.NotNull(unitOfWork);
		Assert.True(noTracking
			? dbContext.ChangeTracker.QueryTrackingBehavior == QueryTrackingBehavior.NoTracking
			: dbContext.ChangeTracker.QueryTrackingBehavior == QueryTrackingBehavior.TrackAll);

		await dbContext.Database.EnsureDeletedAsync();
		await dbContext.DisposeAsync();
	}

	[Theory]
	[MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
	public async Task TestRepository(bool isValid, Type context, Type entityType)
	{
		if (!isValid) return;

		var dbContext = await CreateDbInstance(context);
		var unitOfWork = new UnitOfWork(dbContext);

		var method = unitOfWork.GetType().GetMethod(nameof(UnitOfWork.Repository))!.MakeGenericMethod(entityType);
		var repository = method.Invoke(unitOfWork, null);

		Assert.NotNull(repository);
		Assert.IsType(typeof(GenericRepository<>).MakeGenericType(entityType), repository);
	}


	private static async Task<(object?, object?, object?)> ChangesAsyncDataToParams(DbContext dbContext, IEnumerable<object> iEntites, bool asForeignKey)
	{

		var entities = iEntites.ToList();
		object? addedEntity = null;
		object? modifiedEntity = null;
		object? deletedEntity = null;
		
		if (entities.Count > 0)
		{
			var entity = entities[0];
			deletedEntity = await dbContext.FindAsync(
				entity.GetType(), entity.GetType().GetProperty("Id")!.GetValue(entity));
			dbContext.Remove(deletedEntity!);
			
			if (!asForeignKey)
			{
				entity = entities[1];
				modifiedEntity = await dbContext.FindAsync(
					entity.GetType(), entity.GetType().GetProperty("Id")!.GetValue(entity));
				dbContext.Update(modifiedEntity!);
				
				addedEntity = entities[2];
				dbContext.Add(addedEntity);
			}
		}
		
		return (addedEntity, modifiedEntity, deletedEntity);
	}
	
	[Theory]
	[MemberData(nameof(ChangesAsyncData))]
	public async Task TestSavesChangesAsync(bool isValid, Type context, IEnumerable<object> iEntities,
		bool asForeignKey)
	{
		if (!isValid) return;

		var entities = iEntities.ToList();
		
		var dbContext = await CreateDbInstance(context);
		var unitOfWork = new UnitOfWork(dbContext);
		
		var (addedEntity, modifiedEntity, deletedEntity) = await ChangesAsyncDataToParams(dbContext, entities, asForeignKey);
		
		await unitOfWork.SaveChangesAsync();

		if (entities.Count > 0)
		{
			if (!asForeignKey)
			{
				Assert.True(dbContext.Entry(addedEntity!).State == EntityState.Detached);
				Assert.True(dbContext.Entry(modifiedEntity!).State == EntityState.Detached);
			}
		
			Assert.True(dbContext.Entry(deletedEntity!).State == EntityState.Detached);
		
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
	}
	
	[Theory]
	[MemberData(nameof(ChangesAsyncData))]
	public async Task TestRejectChangesAsync(bool isValid, Type context, IEnumerable<object> iEntities,
		bool asForeignKey)
	{
		if (!isValid) return;

		var entities = iEntities.ToList();
		
		var dbContext = await CreateDbInstance(context);
		var unitOfWork = new UnitOfWork(dbContext);
		
		var (addedEntity, modifiedEntity, deletedEntity) = await ChangesAsyncDataToParams(dbContext, entities, asForeignKey);
		
		await unitOfWork.RejectChangesAsync();

		if (entities.Count > 0)
		{
			if (!asForeignKey)
			{
				Assert.True(dbContext.Entry(addedEntity!).State == EntityState.Detached);
				Assert.True(dbContext.Entry(modifiedEntity!).State == EntityState.Unchanged);
			}
		
			Assert.True(dbContext.Entry(deletedEntity!).State == EntityState.Unchanged);
		
			await dbContext.Database.EnsureDeletedAsync();
			await dbContext.DisposeAsync();
		}
	}
	
	[Theory]
	[MemberData(nameof(ContextsData))]
	public async Task TestDispose(Type context)
	{
		var dbContext = await CreateDbInstance(context);
		var unitOfWork = new UnitOfWork(dbContext);
		unitOfWork.Dispose();
		
		Assert.Throws<ObjectDisposedException>(() => dbContext.Database.EnsureDeleted());
	}

}