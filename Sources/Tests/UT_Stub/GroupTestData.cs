using Model;

namespace UT_Stub;

public static class GroupTestData
{
    public static IEnumerable<object?[]> Data_TestGroupsByName()
    {
        yield return new object?[]
        {
            "Group 1",
            new Group(1UL, "Group 1",
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            )
        };
        yield return new object?[]
        {
            "Group 2",
            new Group(2UL, "Group 2",
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1"),
                new Player("Julien", "PETIT", "THEGIANT", "avatar2")
            )
        };
        yield return new object?[]
        {
            "Group2",
            null
        };
        yield return new object?[]
        {
            "",
            null
        };
    }

    public static IEnumerable<object?[]> Data_TestLoadGroupsByPlayer()
    {
        yield return new object?[]
        {
            new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
            new Group[]
            {
                new(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2")
                )
            },
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Albert", "GOL", "LOLA", "avatar1"),
            new Group[]
            {
                new(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new(3UL, "Group 3",
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
            },
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Albert", "GOL", "LOLA", "avatar1"),
            new Group[]
            {
                new(3UL, "Group 3",
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1")
                )
            },
            2,
            2
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]
            {
                new(4UL, "Group 4",
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(6UL, "Group 6",
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new(7UL, "Group 7",
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                )
            },
            1,
            4
        };
        yield return new object?[]
        {
            new Player("Jordane", "LEG", "BIGBRAIN", "avatar1"),
            Array.Empty<Group>(),
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            Array.Empty<Group>(),
            1,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            Array.Empty<Group>(),
            0,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            Array.Empty<Group>(),
            0,
            1
        };
    }

    public static IEnumerable<object?[]> Data_TestLoadAllGroups()
    {
        yield return new object?[]
        {
            new Group[]
            {
                new(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new(3UL, "Group 3",
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(6UL, "Group 16",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(7UL, "Group 7",
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new(8UL, "Group 8",
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                ),
                new(9UL, "Group 9",
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3")
                ),
                new(10UL, "Group 10",
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                ),
                new(11UL, "Group 11",
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                    new Player("Marine", "TABLETTE", "LOLO", "avatar1")
                ),
                new(12UL, "Group 12",
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                    new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                    new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
                )
            },
            1,
            12
        };
        yield return new object?[]
        {
            new Group[]
            {
                new(1UL, "Group 1",
                    new Player("Jean", "BON", "JEBO", "avatar1"),
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new(3UL, "Group 3",
                    new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(6UL, "Group 16",
                    new Player("Albert", "GOL", "LOLA", "avatar1"),
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(7UL, "Group 7",
                    new Player("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new(8UL, "Group 8",
                    new Player("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                ),
                new(9UL, "Group 9",
                    new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3")
                ),
                new(10UL, "Group 10",
                    new Player("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                )
            },
            1,
            10
        };
        yield return new object?[]
        {
            Array.Empty<Group>(),
            1,
            0
        };
        yield return new object?[]
        {
            Array.Empty<Group>(),
            0,
            0
        };
        yield return new object?[]
        {
            Array.Empty<Group>(),
            0,
            1
        };
    }
}