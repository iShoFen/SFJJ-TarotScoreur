using Model.Players;
using TarotDB;

namespace UT_Tarot2B2Model.Extensions.DataTest;

internal static class UserExtensionsDataTest
{
    public static IEnumerable<object[]> UserAndUserEntity()
    {
        yield return new object[]
        {
            new User(0UL, "Jean", "BON", "JEBO", "avatar1", "email", "password"),
            new UserEntity
            {
                Id = 0UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1",
                Email = "email",
                Password = "password"
            }
        };
        yield return new object[]
        {
            new User(3UL, "Jean", "BON", "JEBO", "avatar1", "email", "password"),
            new UserEntity
            {
                Id = 3UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1",
                Email = "email",
                Password = "password"
            }
        };
    }

    public static IEnumerable<object[]> UsersAndUserEntities()
    {
        yield return new object[]
        {
            new List<User>
            {
                new (0UL,"Jean","BON","JEBO","avatar1","user1@gmail.com","password1"),
                new (1UL, "Michel", "Sardou", "MichelSardou", "avatar2", "michel.sardou@gmail.com", "michelSardou47"),
                new (2UL, "Brigitte", "Bardot", "BrigitteBardot", "avatar3", "brigitte.bardot@orange.fr", "sauverLesAnimaux22")
                
            },
            new List<UserEntity>
            {
                new()
                {
                    Id = 0UL,
                    FirstName = "Jean",
                    LastName = "BON",
                    Nickname = "JEBO",
                    Avatar = "avatar1",
                    Email = "user1@gmail.com",
                    Password = "password1"
                },
                new()
                {
                    Id = 1UL,
                    FirstName = "Michel",
                    LastName = "Sardou",
                    Nickname = "MichelSardou",
                    Avatar = "avatar2",
                    Email = "michel.sardou@gmail.com",
                    Password = "michelSardou47"

                },
                new()
                {
                    Id = 2UL,
                    FirstName = "Brigitte",
                    LastName = "Bardot",
                    Nickname = "BrigitteBardot",
                    Avatar = "avatar3",
                    Email = "brigitte.bardot@orange.fr",
                    Password = "sauverLesAnimaux22"
                }
            }
        };
        yield return new object[]
        {
            new List<User>(),
            new List<UserEntity>()
        };
    }
}