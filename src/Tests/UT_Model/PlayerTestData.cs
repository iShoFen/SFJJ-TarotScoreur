using Model;

namespace UT_Model;

internal static class PlayerTestData
{
    public static IEnumerable<object[]> Data_TestHashCode()
    {
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "Flo", ""),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "", "", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "", ""),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };

        yield return new object[]
        {
            false,
            new Player(2, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            false,
            new Player(2, "", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };

        yield return new object[]
        {
            true,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            false,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Samuel", "Sirven", "Sam", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Florent", "MARQUES", "Flo", "monAvatar")
        };

        Player p = new(0, "Florent", "MARQUES", "Flo", "avatar");
        yield return new object[]
        {
            true,
            p,
            p
        };
    }

    public static IEnumerable<object?[]> Data_TestEquals()
    {

        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "Flo", ""),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "", "", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            true,
            new Player(3, "Florent", "MARQUES", "", ""),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };

        yield return new object[]
        {
            false,
            new Player(2, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            false,
            new Player(2, "", "MARQUES", "Flo", "avatar"),
            new Player(3, "Florent", "MARQUES", "Flo", "avatar")
        };

        yield return new object[]
        {
            true,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object[]
        {
            false,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Samuel", "Sirven", "Sam", "avatar")
        };
        yield return new object[]
        {
            false,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Florent", "MARQUES", "Flo", "monAvatar")
        };

        Player p = new(0, "Florent", "MARQUES", "Flo", "avatar");
        yield return new object[]
        {
            true,
            p,
            p
        };
        yield return new object?[]
        {
            false,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            null
        };
        yield return new object?[]
        {
            false,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            3
        };
    }

    public static IEnumerable<object?[]> Data_TestEqualsWithPlayer()
    {
        yield return new object?[]
        {
            true,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(0, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object?[]
        {
            true,
            new Player(0, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(2, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object?[]
        {
            false,
            new Player(4, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(2, "Florent", "MARQUES", "Flo", "avatar")
        };
        yield return new object?[]
        {
            true,
            new Player(4, "Florent", "MARQUES", "Flo", "avatar"),
            new Player(4, "Samuel", "Sirven", "Sam", "avatar")
        };
    }

    public static IEnumerable<object?[]> Data_TestFullComparer()
    {
        Player p = new Player(4, "Florent", "MARQUES", "Flo", "avatar");
        yield return new object?[]
        {
            true,
            p,
            p
        };
        yield return new object?[]
        {
            false,
            null,
            p
        };
        yield return new object?[]
        {
            false,
            p,
            null
        };
        yield return new object?[]
        {
            false,
            new Player(4, "Florent", "MARQUES", "Flo", "avatar"),
            new User( "Florent", "MARQUES", "Flo", "avatar", "email", "password")
        };
        yield return new object?[]
        {
            false,
            null,
            null
        };
    }
}
