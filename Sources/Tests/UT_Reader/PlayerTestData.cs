using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

internal static class PlayerTestData
{
    public static IEnumerable<object?[]> Data_TestAllPlayers()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar5"),
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Simon", "SEBAT", "SEBATA", "avatar7"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                2,
                10,
                new[]
                {
                    new Player("Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new Player("Jules", "INFANTE", "KIKOU77", "avatar12"),
                    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                    new Player("Marine", "TABLETTE", "LOLO", "avatar14"),
                    new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"),
                    new Player("Alizee", "SEBAT", "SEBAT", "avatar16")
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                2,
                4,
                new Player[]
                {
                    new("Albert", "GOL", "LOLA", "avatar5"),
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Simon", "SEBAT", "SEBATA", "avatar7"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                1,
                4,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                0,
                10,
                Array.Empty<Player>()
            };
            yield return new object?[]
            {
                loader.Get(),
                0,
                0,
                Array.Empty<Player>()
            };
            yield return new object?[]
            {
                loader.Get(),
                2,
                0,
                Array.Empty<Player>()
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestPlayerById()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                1UL,
                new Player(1, "Jean", "BON", "JEBO", "avatar1")
            };
            yield return new object?[]
            {
                loader.Get(),
                0UL,
                null
            };
            yield return new object?[]
            {
                loader.Get(),
                55UL,
                null
            };
        }
    }

    public static IEnumerable<object[]> Data_TestPlayersByPattern()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar11"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Toto",
                1,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Toto",
                2,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                2,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar5"),
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Simon", "SEBAT", "SEBATA", "avatar7"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "M",
                1,
                10,
                new Player[]
                {
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new("Marine", "TABLETTE", "LOLO", "avatar14")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                0,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                2,
                0,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                0,
                0,
                Array.Empty<Player>()
            };
        }
    }

    public static IEnumerable<object[]> Data_TestPlayersByNickname()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "JEBO",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "THEGIANT",
                1,
                10,
                new Player[]
                {
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "TOTO",
                1,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "JEMA",
                0,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "KIKOU7",
                1,
                0,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "LOLO",
                0,
                0,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar5"),
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Simon", "SEBAT", "SEBATA", "avatar7"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
                }
            };
        }
    }

    public static IEnumerable<object[]> Data_TestPlayersByFirstNameAndLastName()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "Je",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Jeanne", "LERICHE", "JEMAA", "avatar11")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Je",
                2,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "M",
                1,
                10,
                new Player[]
                {
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Marine", "TABLETTE", "LOLO", "avatar14")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                0,
                10,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                1,
                0,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                0,
                0,
                Array.Empty<Player>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new Player[]
                {
                    new("Jean", "BON", "JEBO", "avatar1"),
                    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
                    new("Albert", "GOL", "LOLA", "avatar5"),
                    new("Julien", "PETIT", "THEGIANT", "avatar6"),
                    new("Simon", "SEBAT", "SEBATA", "avatar7"),
                    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new("Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
                }
            };
        }
    }
}