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
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
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
        /*new ("Jean", "BON", "JEBO", "avatar1"),
        new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
        new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
        new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
        new ("Albert", "GOL", "LOLA", "avatar1"),
        new ("Julien", "PETIT", "THEGIANT", "avatar2"),
        new ("Simon", "SEBAT", "SEBATA", "avatar1"),
        new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
        new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
        new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
        new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
        new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
        new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
        new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
        new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2"),
        new Player("Alizee", "SEBAT", "SEBAT", "avatar1")*/
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
                new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new("Albert", "GOL", "LOLA", "avatar1"),
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
                )
            },
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]
            {
                new (2UL, "Group 2",
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                )
            },
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Jordane", "LEG", "BIGBRAIN", "avatar1"),
            null,
            1,
            10
        };
        yield return new object?[]
        {
            null,
            null,
            1,
            10
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]
            {
                new (2UL, "Group 2",
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                )
            },
            1,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]
            {
                new (2UL, "Group 2",
                    new("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                )
            },
            0,
            0
        };
        yield return new object?[]
        {
            new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            new Group[]
            {
                new (2UL, "Group 2",
                    new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                    new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                    new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                    new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                    new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
                )
            },
            0,
            1
        };
    }
}