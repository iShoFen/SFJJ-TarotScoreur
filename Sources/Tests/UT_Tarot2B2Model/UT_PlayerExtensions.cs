using Model.Players;
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
        Mapper.Reset();
        var playerEntityToModel = playerEntity.ToModel();
        Assert.Equal(player, playerEntityToModel);
        //To force the mapper to be used
        Assert.Same(playerEntityToModel, playerEntity.ToModel());
        Mapper.Reset();
        Assert.NotSame(playerEntityToModel, playerEntity.ToModel());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayerAndPlayerEntity))]
    internal void TestPlayerToEntity(Player player, PlayerEntity playerEntity)
    {
        Mapper.Reset();
        var playerToEntity = player.ToEntity();
        Assert.Equal(playerEntity.Id, playerToEntity.Id );
        Assert.Equal(playerEntity.FirstName, playerToEntity.FirstName );
        Assert.Equal(playerEntity.LastName, playerToEntity.LastName );
        Assert.Equal(playerEntity.Nickname, playerToEntity.Nickname );
        Assert.Equal(playerEntity.Avatar, playerToEntity.Avatar );
        
        //To force the mapper to be used
        Assert.Same(playerToEntity, player.ToEntity());
        Mapper.Reset();
        Assert.NotSame(playerToEntity, player.ToEntity());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayersAndPlayerEntities))]
    internal void TestPlayerEntitiesToModels(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Mapper.Reset();
        var playerEntitiesToModels = playerEntities.ToModels().ToList();
        Assert.Equal(players, playerEntitiesToModels);
        //To force the mapper to be used
        var i = 0;
        foreach (var playerEntity in playerEntities)
        {
            Assert.Same(playerEntity.ToModel(), playerEntitiesToModels.ElementAt(i));
            ++i;
        }
        Mapper.Reset();
        i = 0;
        foreach (var playerEntity in playerEntities)
        {
            Assert.NotSame(playerEntity.ToModel(), playerEntitiesToModels.ElementAt(i));
            ++i;
        }
    }
    
    [Theory]
    [MemberData(nameof(Data_AddPlayersAndPlayerEntities))]
    internal void TestPlayersToEntities(List<Player> players, List<PlayerEntity> playerEntities)
    {
        Mapper.Reset();
        var playersToEntities = players.ToEntities().ToList();
        var i = 0;
        foreach (var playerToEntity in playersToEntities)
        {
            Assert.Equal(playerToEntity.Id, playerEntities[i].Id );
            Assert.Equal(playerToEntity.FirstName, playerEntities[i].FirstName );
            Assert.Equal(playerToEntity.LastName, playerEntities[i].LastName );
            Assert.Equal(playerToEntity.Nickname, playerEntities[i].Nickname );
            Assert.Equal(playerToEntity.Avatar, playerEntities[i].Avatar );
            ++i;
        }
        
        //To force the mapper to be used
        i = 0;
        foreach (var player in players)
        {
            Assert.Same(player.ToEntity(), playersToEntities.ElementAt(i));
            ++i;
        }
        Mapper.Reset();
        i = 0;
        foreach (var player in players)
        {
            Assert.NotSame(player.ToEntity(), playersToEntities.ElementAt(i));
            ++i;
        }
    }
    
}