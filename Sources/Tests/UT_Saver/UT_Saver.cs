using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Saver;

public class UT_Saver
{
	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSavePlayer), MemberType = typeof(SaverTestData))]
	internal async Task TestSavePlayer(ISaver saver, Player player, Player? expPlayer, PlayerEntity? expEntity)
	{
		var result = await saver.SavePlayer(player);
		Assert.Equal(expPlayer, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Players
				.Include(p => p.Games)
				.Include(p => p.Groups)
				.Include(p => p.Biddings)
				.FirstOrDefaultAsync(p => p.Id == expEntity.Id);


			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.FirstName, entity.FirstName);
			Assert.Equal(expEntity.LastName, entity.LastName);
			Assert.Equal(expEntity.Nickname, entity.Nickname);
			Assert.Equal(expEntity.Avatar, entity.Avatar);
		}
	}

	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSaveGroup), MemberType = typeof(SaverTestData))]
	internal async Task TestSaveGroup(ISaver saver, Group group, Group? expGroup, GroupEntity? expEntity)
	{
		var result = await saver.SaveGroup(group);
		Assert.Equal(expGroup, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Groups
				.Include(g => g.Players)
				.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
			
			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.Name, entity.Name);
		}
	}

	[Theory]
	[MemberData(nameof(SaverTestData.Data_TestSaveGame), MemberType = typeof(SaverTestData))]
	internal async Task TestSaveGame(ISaver saver, Game game, Game? expGame, GameEntity? expEntity)
	{
		var result = await saver.SaveGame(game);
		Assert.Equal(expGame, result);

		if (expEntity != null)
		{
			if (saver is not DbSaver dbSaver) return;

			await using var context =
				(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
			var entity = await context.Games
				.Include(g => g.Players)
				.Include(g => g.Hands)
				.Include(g => g.Players)
				.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
			
			Assert.NotNull(entity);
			Assert.Equal(expEntity.Id, entity!.Id);
			Assert.Equal(expEntity.Name, entity.Name);
			Assert.Equal(expEntity.Rules, entity.Rules);
			Assert.Equal(expEntity.StartDate, entity.StartDate);
			Assert.Equal(expEntity.EndDate, entity.EndDate);
		}
	}
}