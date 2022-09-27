using Model;

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
        User u = new User(4, "Florent", "Marques", "Flo", "avatar", "email", "password");
        yield return new object?[]
        {
            true,
            u,
            u
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
        User u = new User(0, "Florent", "Marques", "Flo", "avatar", "email", "password");
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
}