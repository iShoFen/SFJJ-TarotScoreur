using Model.Players;

namespace UT_Writer;

using static TestUtils.DataManagers;

public static class GroupWriterDataTest
{
    public static IEnumerable<object?[]> InsertGroupData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Group("Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                ),
                new Group(13UL,
                    "Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group("Group 13"),
                new Group(13UL, "Group 13")
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(50UL, "Group 51"),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group("Group 13",
                          new Player(25UL, "Michel", "SARDOU", "coucou", "avatar25")
                ),
                null
            };
        }
    }

    public static IEnumerable<object?[]> UpdateGroupData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Group(5UL, "Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                ),
                new Group(5UL,
                    "Group 13",
                    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(4UL, "Group 13"),
                new Group(4UL, "Group 13")
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(20UL, "Group 21"),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(0UL, "Group 21"),
                null
            };
        }
    }

    public static IEnumerable<object?[]> DeleteGroupWithObjectData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Group(6UL, "Group 7"),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(2UL, "Group 3"),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(0UL, "Group 1"),
                false,
            };
            yield return new object?[]
            {
                writer.Get(),
                new Group(100UL, "Group 101"),
                false
            };
        }
    }

    public static IEnumerable<object?[]> DeleteGroupWithIdData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                3UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                12UL,
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                0UL,
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                100UL,
                false
            };
        }
    }
}