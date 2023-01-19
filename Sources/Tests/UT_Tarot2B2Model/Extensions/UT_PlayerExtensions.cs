using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using UT_Tarot2B2Model.Extensions.DataTest;
using Xunit;

namespace UT_Tarot2B2Model.Extensions;

public class UT_PlayerExtensions
{
    [Theory]
    [MemberData(nameof(PlayerExtensionsDataTest.PlayerAndPlayerEntity), MemberType = typeof(PlayerExtensionsDataTest))]
    internal void TestPlayerEntityToModel(Player player, PlayerEntity playerEntity)
    {
        Mapper.Reset();
        var model = playerEntity.ToModel();
        Assert.Equal(player, model, Player.PlayerFullComparer);

        // To force the mapper to be used
        Assert.Same(model, playerEntity.ToModel());
        Mapper.Reset();
        Assert.NotSame(model, playerEntity.ToModel());
    }

    [Theory]
    [MemberData(nameof(PlayerExtensionsDataTest.PlayerAndPlayerEntity), MemberType = typeof(PlayerExtensionsDataTest))]
    internal void TestPlayerToEntity(Player player, PlayerEntity playerEntity)
    {
        Mapper.Reset();
        var entity = player.ToEntity();

        Assert.Equal(playerEntity.Id, entity.Id);
        Assert.Equal(playerEntity.FirstName, entity.FirstName);
        Assert.Equal(playerEntity.LastName, entity.LastName);
        Assert.Equal(playerEntity.Nickname, entity.Nickname);
        Assert.Equal(playerEntity.Avatar, entity.Avatar);

        // To force the mapper to be used
        Assert.Same(entity, player.ToEntity());
        Mapper.Reset();
        Assert.NotSame(entity, player.ToEntity());
    }

    [Theory]
    [MemberData(nameof(PlayerExtensionsDataTest.PlayersAndPlayerEntities),
        MemberType = typeof(PlayerExtensionsDataTest))]
    internal void TestPlayerEntitiesToModels(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Mapper.Reset();
        var models = playerEntities.ToModels().ToList();
        Assert.Equal(players, models, Player.PlayerFullComparer);

        // To force the mapper to be used
        var i = 0;
        foreach (var playerEntity in playerEntities)
        {
            Assert.Same(playerEntity.ToModel(), models.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var playerEntity in playerEntities)
        {
            Assert.NotSame(playerEntity.ToModel(), models.ElementAt(i));
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(PlayerExtensionsDataTest.PlayersAndPlayerEntities),
        MemberType = typeof(PlayerExtensionsDataTest))]
    internal void TestPlayersToEntities(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Mapper.Reset();
        var entities = players.ToEntities().ToList();
        var i = 0;
        foreach (var playerToEntity in entities)
        {
            Assert.Equal(playerToEntity.Id, playerEntities[i].Id);
            Assert.Equal(playerToEntity.FirstName, playerEntities[i].FirstName);
            Assert.Equal(playerToEntity.LastName, playerEntities[i].LastName);
            Assert.Equal(playerToEntity.Nickname, playerEntities[i].Nickname);
            Assert.Equal(playerToEntity.Avatar, playerEntities[i].Avatar);
            ++i;
        }

        // To force the mapper to be used
        i = 0;
        foreach (var player in players)
        {
            Assert.Same(player.ToEntity(), entities.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var player in players)
        {
            Assert.NotSame(player.ToEntity(), entities.ElementAt(i));
            ++i;
        }
    }
}