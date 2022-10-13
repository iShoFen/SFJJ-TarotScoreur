using Model;

namespace UT_Stub;

public class GroupTestData
{
    public static IEnumerable<object?[]> Data_TestGroupsByName()
    {
        yield return new object?[]
        {
            "Group 1",
            new Group (1UL, "Group 1",
                new("Jean", "BON", "JEBO", "avatar1"),
                new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new("Albert", "GOL", "LOLA", "avatar1")
            )
        };
        yield return new object?[]
        {
            "Group 2",
            new Group (2UL, "Group 2",
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new ("Albert", "GOL", "LOLA", "avatar1"),
                new ("Julien", "PETIT", "THEGIANT", "avatar2")
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
                new (1UL, "Group 1",
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1")
                ),
                new (2UL, "Group 2",
                    new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2")
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
                new (1UL, "Group 1",
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1")
                ),
                new (2UL, "Group 2",
                    new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new (3UL, "Group 3",
                    new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new (4UL, "Group 4",
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new (5UL, "Group 5",
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new ("Samuel", "LE CHANTEUR", "LOL", "avatar1")
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
                new (3UL, "Group 3",
                    new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new (4UL, "Group 4",
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1")
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
                new (4UL, "Group 4",
                    new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new (5UL, "Group 5",
                    new ("Albert", "GOL", "LOLA", "avatar1"),
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new ("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new (6UL, "Group 6",
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new (7UL, "Group 7",
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                )
            },
            1,
            4
        };
        yield return new object?[]
        {
            new Player("Jordane", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]{},
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]{},
            1,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]{},
            0,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]{},
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
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new(3UL, "Group 3",
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(6UL, "Group 16",
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(7UL, "Group 7",
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new(8UL, "Group 8",
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                ),
                new(9UL, "Group 9",
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3")
                ),
                new(10UL, "Group 10",
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                ),
                new(11UL, "Group 11",
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                    new("Marine", "TABLETTE", "LOLO", "avatar1")
                ),
                new(12UL, "Group 12",
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                    new("Marine", "TABLETTE", "LOLO", "avatar1"),
                    new("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
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
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1")
                ),
                new(2UL, "Group 2",
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2")
                ),
                new(3UL, "Group 3",
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1")
                ),
                new(4UL, "Group 4",
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1")
                ),
                new(5UL, "Group 5",
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(6UL, "Group 16",
                    new("Albert", "GOL", "LOLA", "avatar1"),
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1")
                ),
                new(7UL, "Group 7",
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                ),
                new(8UL, "Group 8",
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar2")
                ),
                new(9UL, "Group 9",
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3")
                ),
                new(10UL, "Group 10",
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                    new("Jules", "INFANTE", "KIKOU77", "avatar3"),
                    new("Anne", "PETIT", "FRIPOUILLES", "avatar4")
                )
            },
            1,
            10
        };
        yield return new object?[]
        {
            new Group[] { },
            1,
            0
        };
        yield return new object?[]
        {
            new Group[] { },
            0,
            0
        };
        yield return new object?[]
        {
            new Group[] { },
            0,
            1
        };
    }
}