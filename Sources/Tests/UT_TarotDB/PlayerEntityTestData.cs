using TarotDB;
using TarotDB.enums;

namespace UT_TarotDB;

public class PlayerEntityTestData
{
    public static IEnumerable<object?[]> Data_TestAdd()
    {
        yield return new object?[]
        {
            true, 16, "Florent", "MARQUES", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "MARQUES", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "", "MARQUES", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "MARQUES", "", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "MARQUES", "Flo", "",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "", "", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "", "MARQUES", "", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "", "MARQUES", "Flo", "",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "", "", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "", "Flo", "",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            true, 16, "Florent", "MARQUES", "", "",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, null, "MARQUES", "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", null, "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", "MARQUES", null, "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", "MARQUES", "Flo", null,
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, null, null, "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, null, "MARQUES", null, "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, null, "MARQUES", "Flo", null,
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", null, null, "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", null, "Flo", null,
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", "MARQUES", null, null,
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "    ", null, "Flo", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, null, "MARQUES", "    ", "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
        yield return new object?[]
        {
            false, 16, "Florent", "    ", null, "avatar1",
            new []
            {
                1UL,
                2UL
            },
            new GameEntity[]
            {
                new() { Id = 6UL },
                new() { Id = 3UL }
            },
            new GroupEntity[]
            {
                new() { Id = 12UL },
                new() { Id = 4UL }
            }
        };
    }
}