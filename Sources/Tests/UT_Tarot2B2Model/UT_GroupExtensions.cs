using Model;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Tarot2B2Model;
public class UT_GroupExtensions
{
    public static IEnumerable<object[]> Data_AddGroupAndGroupEntity()
    {
        yield return new object[]
        {
            new Group(1UL,"Group1",
                new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
            new GroupEntity
            { 
                Id = 1UL,
                Name = "Group1",
                Players = new List<PlayerEntity>
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
                    }
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_AddGroupsAndGroupEntities()
    {
        yield return new object[]
        {
            new List<Group>()
            {
                new Group(1UL, "Group1",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
                new Group(2UL, "Group2",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
                new Group(3UL, "Group3",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
            },
            new List<GroupEntity>()
            {
                new GroupEntity
                {
                    Id = 1UL,
                    Name = "Group1",
                    Players = new List<PlayerEntity>
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
                        }
                    }
                },
                new GroupEntity
                {
                    Id = 2UL,
                    Name = "Group2",
                    Players = new List<PlayerEntity>
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
                        }
                    }
                },
                new GroupEntity
                {
                    Id = 3UL,
                    Name = "Group3",
                    Players = new List<PlayerEntity>
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
                        }
                    }
                }
            }
        };
    }

    [Theory] 
    [MemberData(nameof(Data_AddGroupAndGroupEntity))] 
    internal void TestGroupEntityToModel(Group group, GroupEntity groupEntity)
    {
        var groupEntityToModel = groupEntity.ToModel();
        Assert.Equal(group, groupEntityToModel);
        //Use the mapper
        Assert.Same(groupEntity.ToModel(), groupEntityToModel);

    }

    [Theory]
    [MemberData(nameof(Data_AddGroupAndGroupEntity))]
    internal void TestGroupToEntity(Group group, GroupEntity groupEntity)
    {
        var groupToEntity = group.ToEntity();
        Assert.Equal(groupEntity.Id, groupToEntity.Id);
        Assert.Equal(groupEntity.Name, groupToEntity.Name);
        var i = 0;
        foreach (var player in group.Players)
        {
            Assert.Equal(player.Id, groupToEntity.Players.ElementAt(i).Id);
            Assert.Equal(player.FirstName, groupToEntity.Players.ElementAt(i).FirstName);
            Assert.Equal(player.LastName, groupToEntity.Players.ElementAt(i).LastName);
            Assert.Equal(player.NickName, groupToEntity.Players.ElementAt(i).Nickname);
            Assert.Equal(player.Avatar, groupToEntity.Players.ElementAt(i).Avatar);
            i++;
        }
        //Use the mapper
        Assert.Same(group.ToEntity(), groupToEntity);
    }

    [Theory]
    [MemberData(nameof(Data_AddGroupsAndGroupEntities))]
    internal void TestGroupEntitiesToModels(List<Group> groups, List<GroupEntity> groupEntities)
    {
        var groupEntitiesToModels = groupEntities.ToModels();
        Assert.Equal(groups, groupEntitiesToModels);
        //Use the mapper
        var i = 0;
        foreach (var groupEntity in groupEntities)
        {
            Assert.Same(groupEntity.ToModel(), groupEntitiesToModels.ElementAt(i));
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(Data_AddGroupsAndGroupEntities))]
    internal void TestGroupsToEntities(List<Group> groups, List<GroupEntity> groupEntities)
    {
        var groupsToEntities = groups.ToEntities().ToList();
        Assert.Equal(groupEntities.Count, groupsToEntities.Count);
        var i = 0;
        foreach (var group in groups)
        {
            Assert.Equal(group.Id, groupsToEntities.ElementAt(i).Id);
            Assert.Equal(group.Name, groupsToEntities.ElementAt(i).Name);
            var j = 0;
            foreach (var player in group.Players)
            {
                Assert.Equal(player.Id, groupsToEntities.ElementAt(i).Players.ElementAt(j).Id);
                Assert.Equal(player.FirstName, groupsToEntities.ElementAt(i).Players.ElementAt(j).FirstName);
                Assert.Equal(player.LastName, groupsToEntities.ElementAt(i).Players.ElementAt(j).LastName);
                Assert.Equal(player.NickName, groupsToEntities.ElementAt(i).Players.ElementAt(j).Nickname);
                Assert.Equal(player.Avatar, groupsToEntities.ElementAt(i).Players.ElementAt(j).Avatar);
                ++j;
            }
            ++i;
        }
        //Use the mapper
        i = 0;
        foreach (var group in groups)
        {
            Assert.Same(group.ToEntity(), groupsToEntities.ElementAt(i));
            ++i;
        }
    }
}
