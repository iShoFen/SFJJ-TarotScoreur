using Model.Players;
using TarotDB;

namespace UT_Tarot2B2Model.Extensions.DataTest;

internal static class GroupExtensionsDataTest
{
    public static IEnumerable<object[]> GroupAndGroupEntity()
    {
        yield return new object[]
        {
            new Group(1UL, "Group1",
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

    public static IEnumerable<object[]> GroupsAndGroupEntities()
    {
        yield return new object[]
        {
            new List<Group>
            {
                new(1UL, "Group1",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
                new(2UL, "Group2",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
                new(3UL, "Group3",
                    new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
                    new Player(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                    new Player(2UL, "Paul", "MARTIN", "PAUL", "avatar3")),
            },
            new List<GroupEntity>
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
                new()
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
}