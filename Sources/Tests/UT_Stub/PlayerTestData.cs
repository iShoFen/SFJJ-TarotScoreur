using Model;
using Model.games;

namespace UT_Stub;

internal static class PlayerTestData
{
    
    public static IEnumerable<object[]> Data_TestPlayersByLastName()
    {
        yield return new object[]
        {
            "BON",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
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
        yield return new object[]
        {
            "GOL",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "TABLETTE",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "LE CHANTEUR",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayersByFirstName()
    {
        yield return new object[]
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
        yield return new object[]
        {
            "Simon",
            new Player[]
            {
                new ("Simon", "SEBAT", "SEBATA", "avatar1")
            },
            1,
            10,
        };
        yield return new object[]
        {
            "Samuel",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "Marine",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "Alizee",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayersByNickname()
    {
        yield return new object[]
        {
            "JEBO",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            "THEGIANT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
            },
            1,
            10,
        };
        yield return new object[]
        {
            "JEMAA",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "KIKOU7",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "LOLO",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestAllPlayers()
    {
        yield return new object[]
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
        yield return new object[]
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
        yield return new object[]
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
        yield return new object[]
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
        yield return new object[]
        {
            0,
            10,
            Array.Empty<Player>()
        };
        yield return new object[]
        {
            0,
            0,
            Array.Empty<Player>()
        };
        yield return new object[]
        {
            2,
            0,
            Array.Empty<Player>()
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayersByFirstNameAndLastName()
    {
        yield return new object[]
        {
            "Jean",
            "BON",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            "Julien",
            "PETIT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
            },
            1,
            10,
        };
        yield return new object[]
        {
            "Jeanne",
            "LERICHE",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "Eliaz",
            "DU JARDIN",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "Simon",
            "SEBAT",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            "SEBAT",
            Array.Empty<Player>(),
            1,
            10,
        };
        yield return new object[]
        {
            "Alizee",
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayerByFirstNameAndNickname()
    {
        yield return new object[]
        {
            "Jean",
            "JEBO",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            "Julien",
            "THEGIANT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
            },
            1,
            10,
        };
        yield return new object[]
        {
            "Jeanne",
            "JEMAA",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "Eliaz",
            "THEGIANTE",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "Simon",
            "SEBATA",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            "SEBAT",
            Array.Empty<Player>(),
            1,
            10,
        };
        yield return new object[]
        {
            "Alizee",
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayerByLastNameAndNickname()
    {
        yield return new object[]
        {
            "BON",
            "JEBO",
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            "PETIT",
            "THEGIANT",
            new Player[]
            {
                new ("Julien", "PETIT", "THEGIANT", "avatar2"),
            },
            1,
            10,
        };
        yield return new object[]
        {
            "LERICHE",
            "JEMAA",
            Array.Empty<Player>(),
            0,
            10,
        };
        yield return new object[]
        {
            "DU JARDIN",
            "THEGIANTE",
            Array.Empty<Player>(),
            1,
            0,
        };
        yield return new object[]
        {
            "SEBAT",
            "SEBATA",
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            "",
            "SEBAT",
            Array.Empty<Player>(),
            1,
            10,
        };
        yield return new object[]
        {
            "SEBAT",
            "",
            Array.Empty<Player>(),
            1,
            10,
        };
    }
    
    public static IEnumerable<object[]> Data_TestPlayersByGroup()
    {
        yield return new object[]
        {
            new Group(1UL, "Group 1", 
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
                ),
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new ("Albert", "GOL", "LOLA", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            new Group(1UL, "Group 1", 
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4")
            },
            1,
            4
        };
        yield return new object[]
        {
            new Group(1UL, "Group 1", 
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            new Player[]
            {
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new ("Albert", "GOL", "LOLA", "avatar1")
            },
            2,
            3
        };
        yield return new object[]
        {
            new Group(1UL, "Group 1", 
                new Player("Jean", "BON", "JEBO", "avatar1"),
                new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new Player("Albert", "GOL", "LOLA", "avatar1")
            ),
            new Player[]
            {
                new ("Jean", "BON", "JEBO", "avatar1"),
                new ("Jean", "MAUVAIS", "JEMA", "avatar2"),
                new ("Jean", "MOYEN", "KIKOU7", "avatar3"),
                new ("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                new ("Albert", "GOL", "LOLA", "avatar1")
            },
            1,
            10
        };
        yield return new object[]
        {
            new Group(3UL, "Group 3", 
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            ),
            new Player[]
            {
                new ("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new ("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new ("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new ("Marine", "TABLETTE", "LOLO", "avatar1"),
                new ("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            },
            1,
            5
        };
        yield return new object[]
        {
            new Group(3UL, "Group 3", 
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            ),
            new Player[]
            {
                new ("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            },
            2,
            4
        };
        yield return new object[]
        {
            new Group(3UL, "Group 3", 
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            ),
            Array.Empty<Player>(),
            0,
            1,
        };
        yield return new object[]
        {
            new Group(3UL, "Group 3", 
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            ),
            Array.Empty<Player>(),
            0,
            0,
        };
        yield return new object[]
        {
            new Group(3UL, "Group 3", 
                new Player("Jeanne", "LERICHE", "JEMAA", "avatar2"),
                new Player("Jules", "INFANTE", "KIKOU77", "avatar3"),
                new Player("Anne", "PETIT", "FRIPOUILLES", "avatar4"),
                new Player("Marine", "TABLETTE", "LOLO", "avatar1"),
                new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar2")
            ),
            Array.Empty<Player>(),
            1,
            0,
        };
    }
}