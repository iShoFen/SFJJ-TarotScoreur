using Model.Data;
using Model.Players;
using Xunit;

namespace UT_Writer;

public class UT_Saver
{
    #region Player

    [Theory]
    [MemberData(nameof(PlayerWriterDataTest.Data_TestInsertPlayer), MemberType = typeof(PlayerWriterDataTest))]
    public async Task TestInsertPlayer(IWriter writer, Player player, Player? expectedPlayer)
    {
        var result = await writer.InsertPlayer(player);

        if (expectedPlayer is null) Assert.Null(result);
        else Assert.Equal(expectedPlayer, result!, Player.PlayerFullComparer);
    }

    #endregion

    #region Group

    #endregion

    #region Hand

    #endregion

    #region Game

    #endregion

    // [Theory]
    // [MemberData(nameof(SaverTestData.Data_TestSavePlayer), MemberType = typeof(SaverTestData))]
    // internal async Task TestSavePlayer(IWriter writer, Player player, Player? expPlayer, PlayerEntity? expEntity)
    // {
    // 	var result = await writer.InsertPlayer(player);
    // 	Assert.Equal(expPlayer, result);
    //
    // 	if (expEntity != null)
    // 	{
    // 		if (writer is not DbWriter dbSaver) return;
    //
    // 		await using var context =
    // 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
    // 		var entity = await context.Players
    // 			.Include(p => p.Games)
    // 			.Include(p => p.Groups)
    // 			.Include(p => p.Biddings)
    // 			.FirstOrDefaultAsync(p => p.Id == expEntity.Id);
    //
    //
    // 		Assert.NotNull(entity);
    // 		Assert.Equal(expEntity.Id, entity!.Id);
    // 		Assert.Equal(expEntity.FirstName, entity.FirstName);
    // 		Assert.Equal(expEntity.LastName, entity.LastName);
    // 		Assert.Equal(expEntity.Nickname, entity.Nickname);
    // 		Assert.Equal(expEntity.Avatar, entity.Avatar);
    // 	}
    // }
    
    // [Theory]
    // [MemberData(nameof(SaverTestData.Data_TestSaveGroup), MemberType = typeof(SaverTestData))]
    // internal async Task TestSaveGroup(IWriter writer, Group group, Group? expGroup, GroupEntity? expEntity)
    // {
    // 	var result = await writer.SaveGroup(group);
    // 	Assert.Equal(expGroup, result);
    //
    // 	if (expEntity != null)
    // 	{
    // 		if (writer is not DbWriter dbSaver) return;
    //
    // 		await using var context =
    // 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
    // 		var entity = await context.Groups
    // 			.Include(g => g.Players)
    // 			.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
    // 		
    // 		Assert.NotNull(entity);
    // 		Assert.Equal(expEntity.Id, entity!.Id);
    // 		Assert.Equal(expEntity.Name, entity.Name);
    // 		
    // 		var players = expEntity.Players.Select(p => context.Players.Find(p.Id)!).ToList();
    // 		foreach (var player in entity.Players)
    // 		{
    // 			Assert.Contains(player, players);
    // 		}
    // 	}
    // }
    //
    // [Theory]
    // [MemberData(nameof(SaverTestData.Data_TestSaveGame), MemberType = typeof(SaverTestData))]
    // internal async Task TestSaveGame(IWriter writer, Game game, Game? expGame, GameEntity? expEntity)
    // {
    // 	var result = await writer.SaveGame(game);
    // 	Assert.Equal(expGame, result);
    //
    // 	if (expEntity != null)
    // 	{
    // 		if (writer is not DbWriter dbSaver) return;
    //
    // 		await using var context =
    // 			(TarotDbContext) Activator.CreateInstance(dbSaver.DbContextType, dbSaver.Options)!;
    // 		var entity = await context.Games
    // 			.Include(g => g.Players)
    // 			.Include(g => g.Hands)
    // 			.Include(g => g.Players)
    // 			.FirstOrDefaultAsync(g => g.Id == expEntity.Id);
    // 		
    // 		Assert.NotNull(entity);
    // 		Assert.Equal(expEntity.Id, entity!.Id);
    // 		Assert.Equal(expEntity.Name, entity.Name);
    // 		Assert.Equal(expEntity.Rules, entity.Rules);
    // 		Assert.Equal(expEntity.StartDate, entity.StartDate);
    // 		Assert.Equal(expEntity.EndDate, entity.EndDate);
    // 	}
    // }
}