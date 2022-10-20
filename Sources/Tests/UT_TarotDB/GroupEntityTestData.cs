using TarotDB;

namespace UT_TarotDB;

public static class GroupEntityTestData
{
    public static IEnumerable<object?[]> Data_TestAdd()
    {
        yield return new object?[]
        {
            true,
            "NewGroup1",
            Array.Empty<PlayerEntity>(),
            0
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity
                {
                    Id = 13UL
                }
            },
            4
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" }
            },
            3
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity { Id = 4UL },
                new UserEntity { Id = 12UL },
                new PlayerEntity { Id = 6UL },
                new UserEntity { Id = 13UL }
            },
            4
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity { Id = 4UL },
                new UserEntity { Id = 12UL },
                new PlayerEntity { Id = 6UL },
                new UserEntity { Id = 13UL },
                new UserEntity { Id = 13UL }
            },
            4
        };
        yield return new object?[]
        {
            false,
            null,
            new[]
            {
                new PlayerEntity { Id = 4UL },
                new UserEntity { Id = 12UL },
                new PlayerEntity { Id = 6UL },
                new UserEntity { Id = 13UL }
            },
            4
        };
    }

    public static IEnumerable<object?[]> Data_TestUpdateName()
    {
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity
                {
                    Id = 13UL
                }
            },
            "NewGroup1Updated"
        };
        yield return new object?[]
        {
            false,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity
                {
                    Id = 13UL
                }
            },
            null
        };
    }

    public static IEnumerable<object?[]> Data_TestAddPlayers()
    {
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity { Id = 13UL }
            },
            5,
            new PlayerEntity
                { FirstName = "Toto", LastName = "Titi", Nickname = "Tutu", Avatar = "tata" }
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity { Id = 13UL }
            },
            5,
            new PlayerEntity { Id = 12UL }
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity { Id = 13UL }
            },
            6,
            new UserEntity { Id = 12UL },
            new PlayerEntity
                { FirstName = "Toto", LastName = "Titi", Nickname = "Tutu", Avatar = "tata" }
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity { Id = 13UL }
            },
            6,
            new PlayerEntity
                { FirstName = "Toto1", LastName = "Titi1", Nickname = "Tutu1", Avatar = "tata1" },
            new PlayerEntity
                { FirstName = "Toto2", LastName = "Titi2", Nickname = "Tutu2", Avatar = "tata2" }
        };
        yield return new object?[]
        {
            true,
            "NewGroup1",
            new[]
            {
                new PlayerEntity
                {
                    FirstName = "Michel", LastName = "Polnareff", Nickname = "michmich",
                    Avatar = "Player1"
                },
                new UserEntity
                {
                    FirstName = "Jean", LastName = "Michel", Nickname = "jeanmich",
                    Avatar = "Player2", Email = "Email", Password = "Password"
                },
                new PlayerEntity
                    { FirstName = "Jean", LastName = "Paul", Nickname = "jeanpaul", Avatar = "Player3" },
                new PlayerEntity { Id = 13UL }
            },
            6,
            new PlayerEntity { Id = 6UL },
            new UserEntity { Id = 11UL }
        };
    }

    public static IEnumerable<object?[]> Data_TestRemovePlayers()
    {
        yield return new object?[]
        {
            "NewGroup1",
            new[]
            {
                new PlayerEntity { Id = 6UL },
                new PlayerEntity { Id = 8UL },
                new PlayerEntity { Id = 13UL },
                new PlayerEntity { Id = 15UL }
            },
            3,
            new PlayerEntity { Id = 6UL }
        };
        yield return new object?[]
        {
            "NewGroup1",
            new[]
            {
                new PlayerEntity { Id = 6UL },
                new PlayerEntity { Id = 8UL },
                new PlayerEntity { Id = 13UL },
                new PlayerEntity { Id = 15UL }
            },
            2,
            new PlayerEntity { Id = 8UL },
            new PlayerEntity { Id = 6UL }
        };
        yield return new object?[]
        {
            "NewGroup1",
            new[]
            {
                new PlayerEntity { Id = 6UL },
                new PlayerEntity { Id = 8UL },
                new PlayerEntity { Id = 13UL },
                new PlayerEntity { Id = 15UL }
            },
            4,
            new PlayerEntity { Id = 4UL }
        };
    }
}