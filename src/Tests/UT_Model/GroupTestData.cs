using Model;

namespace UT_Model;

class GroupTestData
{
    public static IEnumerable<object?[]> Data_TestAddPlayer()
    {
        yield return new object?[]
        {
            true,
            new Group("partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            }
        };
        yield return new object?[]
        {
            true,
            new Group("partie"),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            new Player[]
            {
                new("Jordan", "Artzet", "Jo", "avatar")
            }
        };
        yield return new object?[]
{
            false,
            new Group("partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            }
        };
    }

    public static IEnumerable<object?[]> Data_TestAddPlayers()
    {
        yield return new object?[]
        {
            true,
            new Group("partie",
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            new Player[]
            {
                new Player("Florent", "Marques", "Flo", "avatar"),
                new Player("Jordan", "Artzet", "Jo", "avatar"),
            },
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            }
        };
        yield return new object?[]
        {
            true,
            new Group("partie"),
            new Player[]
            {
                new Player("Florent", "Marques", "Flo", "avatar"),
                new Player("Jordan", "Artzet", "Jo", "avatar"),
            },
            new Player[]
            {
                new Player("Florent", "Marques", "Flo", "avatar"),
                new Player("Jordan", "Artzet", "Jo", "avatar"),
            }
        };
        yield return new object?[]
{
            true,
            new Group("partie"),
            Array.Empty<Player>(),
            Array.Empty<Player>()
        };
        yield return new object?[]
{
            true,
            new Group("partie"),
            new Player[]
            {
                new Player("Florent", "Marques", "Flo", "avatar")
            },
            new Player[]
            {
                new Player("Florent", "Marques", "Flo", "avatar")
            }
        };
        yield return new object?[]
        {
            true,
            new Group("partie",
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            Array.Empty<Player>(),
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
        yield return new object?[]
        {
            false,
            new Group("partie"),
            new Player[]
            {
                new("Julien", "Theme", "Ju", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            },
            new Player[]
            {
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
        yield return new object?[]
        {
            false,
            new Group("partie",
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            },
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
        yield return new object?[]
        {
            false,
            new Group("partie",
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            },
            new Player[]
            {
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
    }

    public static IEnumerable<object?[]> Data_TestRemovePlayer()
    {
        yield return new object?[]
        {
            false,
            new Group("partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
        yield return new object?[]
        {
            false,
            new Group("partie"),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            Array.Empty<Player>()
        };
        yield return new object?[]
{
            true,
            new Group("partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar")
            }
        };
        yield return new object?[]
{
            true,
            new Group("partie",new Player("Jordan", "Artzet", "Jo", "avatar")),
            new Player("Jordan", "Artzet", "Jo", "avatar"),
            Array.Empty<Player>()
        };
    }

    public static IEnumerable<object?[]> Data_TestClearPlayers()
    {
        yield return new object?[]
        {
            new Group("partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            new Group("partie",
                new Player("Florent", "Marques", "Flo", "avatar"))
        };

        yield return new object?[]
        {
            new Group("partie")
        };
    }


}
