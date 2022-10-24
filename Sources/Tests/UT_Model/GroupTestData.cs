using Model;

namespace UT_Model;

internal static class GroupTestData
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
                new("Florent", "Marques", "Flo", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar"),
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
                new("Florent", "Marques", "Flo", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar"),
            },
            new Player[]
            {
                new("Florent", "Marques", "Flo", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar"),
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
            new[]
            {
                new Player("Florent", "Marques", "Flo", "avatar")
            },
            new[]
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
            new Group("partie", new Player("Jordan", "Artzet", "Jo", "avatar")),
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

    public static IEnumerable<object?[]> Data_TestEquals()
    {
        yield return new object?[]
        {
            true,
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(4, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(3, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(4, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(4, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        Group g = new Group(0, "partie2",
            new("Florent", "Marques", "Flo", "avatar"),
            new("Samuel", "Sirven", "Sam", "avatar"),
            new("Julien", "Theme", "Ju", "avatar"),
            new("Jordan", "Artzet", "Jo", "avatar")
        );
        yield return new object?[]
        {
            false,
            g,
            null
        };
        yield return new object?[]
        {
            true,
            g,
            g
        };
        yield return new object?[]
        {
            false,
            g,
            3
        };
    }

    public static IEnumerable<object?[]> Data_TestEqualsWithGroup()
    {
        yield return new object?[]
        {
            true,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
    }

    public static IEnumerable<object?[]> Data_TestHashCode()
    {
        yield return new object?[]
        {
            true,
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(0, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(3, "partie",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(4, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            true,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(4, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
        yield return new object?[]
        {
            false,
            new Group(4, "partie1",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            ),
            new Group(0, "partie2",
                new("Florent", "Marques", "Flo", "avatar"),
                new("Samuel", "Sirven", "Sam", "avatar"),
                new("Julien", "Theme", "Ju", "avatar"),
                new("Jordan", "Artzet", "Jo", "avatar")
            )
        };
    }

    public static IEnumerable<object?[]> Data_TestFullComparer()
    {
        var g = new Group(4, "partie",
            new Player("Florent", "Marques", "Flo", "avatar"),
            new Player("Samuel", "Sirven", "Sam", "avatar"),
            new Player("Julien", "Theme", "Ju", "avatar"),
            new Player("Jordan", "Artzet", "Jo", "avatar")
        );
        yield return new object?[]
        {
            true,
            g,
            g
        };
        yield return new object?[]
        {
            false,
            null,
            g
        };
        yield return new object?[]
        {
            false,
            g,
            null
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
            g,
            new GroupTest(4, "partie",
                new Player("Florent", "Marques", "Flo", "avatar"),
                new Player("Samuel", "Sirven", "Sam", "avatar"),
                new Player("Julien", "Theme", "Ju", "avatar"),
                new Player("Jordan", "Artzet", "Jo", "avatar"))
        };
    }

    internal class GroupTest : Group
    {
        public GroupTest(string name, params Player[] players) : base(name, players)
        {
        }

        public GroupTest(ulong id, string name, params Player[] players) : base(id, name, players)
        {
        }
    }
}