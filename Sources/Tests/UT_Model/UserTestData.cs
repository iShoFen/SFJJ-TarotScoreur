using Model.Players;

namespace UT_Model;

public class UserTestData
{
    public static IEnumerable<object?[]> Data_TestEquals()
    {
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "mail", "mdp")
        };

        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "email", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "password")
        };
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(2, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(2, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            true,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            true,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            null
        };
        var u = new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password");
        yield return new object?[]
        {
            true,
            u,
            u
        };
        yield return new object?[]
        {
            false,
            u,
            new object()
        };
    }

    public static IEnumerable<object?[]> Data_TestEqualsWithUser()
    {
        User u = new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password");
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            null
        };
    }

    public static IEnumerable<object?[]> Data_TestFullComparer()
    {
        var u = new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password");
        yield return new object?[]
        {
            true,
            u,
            u
        };
        yield return new object?[]
        {
            false,
            u,
            null
        };
        yield return new object?[]
        {
            false,
            null,
            u
        };
        yield return new object?[]
        {
            false,
            null,
            null
        };
        yield return new object?[]
        {
            false,
            u,
            new UserTest(0, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
    }

    public static IEnumerable<object?[]> Data_TestHashCode()
    {
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            true,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(0, "Florent", "Marques", "Flo", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "password")
        };
        yield return new object?[]
        {
            false,
            new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(2, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            new User(2, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        yield return new object?[]
        {
            true,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            true,
            new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password"),
            new User(4, "Samuel", "Sirven", "Sam", "avatar", "mail", "mdp")
        };
        User u = new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password");
        yield return new object?[]
        {
            true,
            u,
            u
        };
    }

    internal class UserTest : User
    {
        public UserTest(string firstName, string lastName, string nickName, string avatar, string email, string password) : base(firstName, lastName, nickName, avatar, email, password)
        {
        }

        public UserTest(ulong id, string firstName, string lastName, string nickName, string avatar, string email, string password) : base(id, firstName, lastName, nickName, avatar, email, password)
        {
        }
    }
}