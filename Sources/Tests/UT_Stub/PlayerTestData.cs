using Model;

namespace UT_Stub;

internal static  class PlayerTestData
{
    
    public static IEnumerable<Object[]> Data_TestPlayersByLastName()
    {
        yield return new Object[]
        {
            "BON",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new Object[]
        {
            "PETIT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                new ("Anne", "PETIT", "FRIPOUILLES", "avatar4")
            },
            1,
            10,
        };
        yield return new Object[]
        {
            "GOL",
            new Player[]{},
            0,
            10,
        };
        yield return new Object[]
        {
            "TABLETTE",
            new Player[]{},
            1,
            0,
        };
        yield return new Object[]
        {
            "LE CHANTEUR",
            new Player[]{},
            0,
            0,
        };
        yield return new Object[]
        {
            "",
            new Player[]{},
            0,
            0,
        };
    }
    
    public static IEnumerable<Object[]> Data_TestPlayersByFirstName()
    {
        yield return new Object[]
        {
            "Jean",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3")
            },
            1,
            10
        };
        yield return new Object[]
        {
            "Simon",
            new Player[]
            {
                new ("Simon", "SEBAT", "SEBATA", "avatar1")
            },
            1,
            10,
        };
        yield return new Object[]
        {
            "Samuel",
            new Player[]{},
            0,
            10,
        };
        yield return new Object[]
        {
            "Marine",
            new Player[]{},
            1,
            0,
        };
        yield return new Object[]
        {
            "Alizee",
            new Player[]{},
            0,
            0,
        };
        yield return new Object[]
        {
            "",
            new Player[]{},
            0,
            0,
        };
    }
    
    public static IEnumerable<Object[]> Data_TestPlayersByNickname()
    {
        yield return new Object[]
        {
            "JEBO",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new Object[]
        {
            "THEGIANT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
            },
            1,
            10,
        };
        yield return new Object[]
        {
            "JEMAA",
            new Player[]{},
            0,
            10,
        };
        yield return new Object[]
        {
            "KIKOU7",
            new Player[]{},
            1,
            0,
        };
        yield return new Object[]
        {
            "LOLO",
            new Player[]{},
            0,
            0,
        };
        yield return new Object[]
        {
            "",
            new Player[]{},
            0,
            0,
        };
    }
    
    public static IEnumerable<object[]> Data_TestAllPlayers()
    {
        yield return new Object[]
        {
            1,
            10,
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new ("Albert", "GOL", "LOLA", "avatar1"),
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
                new ("Samuel", "LE CHANTEUR", "LOL", "avatar1"),
                new ("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1")
            }
        };
        yield return new Object[]
        {
            2,
            10,
            new Player[]
            {
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2"),
                new Player("Alizee", "SEBAT", "SEBAT", "avatar1")
            }
        };
        yield return new Object[]
        {
            2,
            4,
            new Player[]
            {
                new ("Albert", "GOL", "LOLA", "avatar1"),
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
                new ("Simon", "SEBAT", "SEBATA", "avatar1"),
                new ("Jordan", "LEG", "BIGBRAIN", "avatar1"),
            }
        };
        yield return new Object[]
        {
            1,
            4,
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
            }
        };
        yield return new Object[]
        {
            0,
            10,
            new Player[]{}
        };
        yield return new Object[]
        {
            0,
            0,
            new Player[]{}
        };
        yield return new Object[]
        {
            2,
            0,
            new Player[]{}
        };
        /*yield return new Object[]
        {
            1,
            10,
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
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
                new Player("Alizee", "SEBAT", "SEBAT", "avatar1")
            }
        };*/
    }
}