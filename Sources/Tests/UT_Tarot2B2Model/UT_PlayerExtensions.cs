using Model;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Tarot2B2Model;

public class UT_PlayerExtensions
{
    public static IEnumerable<object[]> Data_AddPlayerAndPlayerEntity()
    {
        yield return new object[]
        {
            new Player(0UL,"Jean", "BON", "JEBO", "avatar1"),
            new PlayerEntity
            {
                Id = 0UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1"
            }
        };
    }

    public static IEnumerable<object[]> Data_AddPlayersAndPlayerEntities()
    {
        yield return new object[]
        {
            new List<Player>
            {
                new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3"),
                new Player(3UL, "Jacques", "DUPONT", "JACQ", "avatar4"),
                new Player(4UL, "Marie", "DUPONT", "MARI", "avatar5"),
                new Player(5UL, "Jeanne", "DUPONT", "JEAN", "avatar6"),
            },
            new List<PlayerEntity>
            {
                new PlayerEntity
                {
                    Id = 0UL,
                    FirstName = "Jean",
                    LastName = "BON",
                    Nickname = "JEBO",
                    Avatar = "avatar1"
                },
                new PlayerEntity
                {
                    Id = 1UL,
                    FirstName = "Pierre",
                    LastName = "DURAND",
                    Nickname = "PIER",
                    Avatar = "avatar2"
                },
                new PlayerEntity
                {
                    Id = 2UL,
                    FirstName = "Paul",
                    LastName = "MARTIN",
                    Nickname = "PAUL",
                    Avatar = "avatar3"
                },
                new PlayerEntity
                {
                    Id = 3UL,
                    FirstName = "Jacques",
                    LastName = "DUPONT",
                    Nickname = "JACQ",
                    Avatar = "avatar4"
                },
                new PlayerEntity
                {
                    Id = 4UL,
                    FirstName = "Marie",
                    LastName = "DUPONT",
                    Nickname = "MARI",
                    Avatar = "avatar5"
                },
                new PlayerEntity
                {
                    Id = 5UL,
                    FirstName = "Jeanne",
                    LastName = "DUPONT",
                    Nickname = "JEAN",
                    Avatar = "avatar6"
                }
            }
        };
    }

    [Theory]
    [MemberData(nameof(Data_AddPlayerAndPlayerEntity))]
    internal void TestPlayerEntityToModel(Player player, PlayerEntity playerEntity)
    {
        var playerEntityToModel = playerEntity.ToModel();
        Assert.Equal(player, playerEntityToModel);
        //To force the mapper to be used
        Assert.Same(playerEntityToModel, playerEntity.ToModel());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayerAndPlayerEntity))]
    internal void TestPlayerToEntity(Player player, PlayerEntity playerEntity)
    {
        Assert.Equal(playerEntity.Id, player.ToEntity().Id );
        Assert.Equal(playerEntity.FirstName, player.ToEntity().FirstName );
        Assert.Equal(playerEntity.LastName, player.ToEntity().LastName );
        Assert.Equal(playerEntity.Nickname, player.ToEntity().Nickname );
        Assert.Equal(playerEntity.Avatar, player.ToEntity().Avatar );
        
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayersAndPlayerEntities))]
    internal void TestPlayerEntitiesToModels(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Assert.Equal(players, playerEntities.ToModels());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayersAndPlayerEntities))]
    internal void TestPlayersToEntities(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Assert.Equal(players.Count, playerEntities.Count);
        var i = 0;
        foreach (var playerToEntity in players.ToEntities())
        {
            Assert.Equal(playerToEntity.Id, playerEntities[i].Id );
            Assert.Equal(playerToEntity.FirstName, playerEntities[i].FirstName );
            Assert.Equal(playerToEntity.LastName, playerEntities[i].LastName );
            Assert.Equal(playerToEntity.Nickname, playerEntities[i].Nickname );
            Assert.Equal(playerToEntity.Avatar, playerEntities[i].Avatar );
            ++i;
        }
    }
    
}