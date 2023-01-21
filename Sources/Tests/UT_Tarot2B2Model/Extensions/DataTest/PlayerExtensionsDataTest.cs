using Model.Players;
using TarotDB;

namespace UT_Tarot2B2Model.Extensions.DataTest;

internal static class PlayerExtensionsDataTest
{
    public static IEnumerable<object[]> PlayerAndPlayerEntity()
    {
        yield return new object[]
        {
            new Player(0UL, "Jean", "BON", "JEBO", "avatar1"),
            new PlayerEntity
            {
                Id = 0UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1"
            }
        };
        yield return new object[]
        {
            new Player(3UL, "Jean", "BON", "JEBO", "avatar1"),
            new PlayerEntity
            {
                Id = 3UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1"
            }
        };
    }

    public static IEnumerable<object[]> PlayersAndPlayerEntities()
    {
        yield return new object[]
        {
            new List<Player>
            {
                new(0UL, "Jean", "BON", "JEBO", "avatar1"),
                new(1UL, "Pierre", "DURAND", "PIER", "avatar2"),
                new(2UL, "Paul", "MARTIN", "PAUL", "avatar3"),
                new(3UL, "Jacques", "DUPONT", "JACQ", "avatar4"),
                new(4UL, "Marie", "DUPONT", "MARI", "avatar5"),
                new(5UL, "Jeanne", "DUPONT", "JEAN", "avatar6")
            },
            new List<PlayerEntity>
            {
                new()
                {
                    Id = 0UL,
                    FirstName = "Jean",
                    LastName = "BON",
                    Nickname = "JEBO",
                    Avatar = "avatar1"
                },
                new()
                {
                    Id = 1UL,
                    FirstName = "Pierre",
                    LastName = "DURAND",
                    Nickname = "PIER",
                    Avatar = "avatar2"
                },
                new()
                {
                    Id = 2UL,
                    FirstName = "Paul",
                    LastName = "MARTIN",
                    Nickname = "PAUL",
                    Avatar = "avatar3"
                },
                new()
                {
                    Id = 3UL,
                    FirstName = "Jacques",
                    LastName = "DUPONT",
                    Nickname = "JACQ",
                    Avatar = "avatar4"
                },
                new()
                {
                    Id = 4UL,
                    FirstName = "Marie",
                    LastName = "DUPONT",
                    Nickname = "MARI",
                    Avatar = "avatar5"
                },
                new()
                {
                    Id = 5UL,
                    FirstName = "Jeanne",
                    LastName = "DUPONT",
                    Nickname = "JEAN",
                    Avatar = "avatar6"
                }
            }
        };
        yield return new object[]
        {
            new List<Player>(),
            new List<PlayerEntity>()
        };
    }
}