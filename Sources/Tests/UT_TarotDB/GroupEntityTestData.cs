using TarotDB;

namespace UT_TarotDB;

public static class GroupEntityTestData
{
    public static IEnumerable<object?> Data_TestAdd()
    {
        yield return new object?[]
        {
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
            }
        };
    }
}