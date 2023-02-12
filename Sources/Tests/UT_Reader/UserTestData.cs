using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

public static class UserTestData
{
    public static IEnumerable<object?[]> Data_TestAllUsers()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email13", "password13"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                    new(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16", "email16", "password16")
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                2,
                10,
                Array.Empty<User>()
            };
            yield return new object?[]
            {
                loader.Get(),
                1,
                4,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email13", "password13"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14")
                }
            };
            yield return new object?[]
            {
                loader.Get(),
                0,
                10,
                Array.Empty<User>()
            };
            yield return new object?[]
            {
                loader.Get(),
                0,
                0,
                Array.Empty<User>()
            };
            yield return new object?[]
            {
                loader.Get(),
                2,
                0,
                Array.Empty<User>()
            };
        }
    }

    public static IEnumerable<object?[]> Data_TestUserById()
    {
        foreach (var loader in Loaders)
        {
            yield return new object?[]
            {
                loader.Get(),
                11UL,
                new User(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11")
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
                6UL,
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

    public static IEnumerable<object[]> Data_TestUsersByPattern()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "AN",
                1,
                10,
                new User[]
                {
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Toto",
                1,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Toto",
                2,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "AN",
                2,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email13", "password13"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                    new(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16", "email16", "password16")
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "M",
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                0,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                2,
                0,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jea",
                0,
                0,
                Array.Empty<User>()
            };
        }
    }

    public static IEnumerable<object[]> Data_TestUsersByNickname()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "JEBO",
                1,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "THEGIANT",
                1,
                10,
                new User[]
                {
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "TOTO",
                1,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "JEMA",
                0,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "KIKOU7",
                1,
                0,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "LOLO",
                0,
                0,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email13", "password13"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                    new(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16", "email16", "password16")
                }
            };
        }
    }

    public static IEnumerable<object[]> Data_TestUsersByFirstNameAndLastName()
    {
        foreach (var loader in Loaders)
        {
            yield return new object[]
            {
                loader.Get(),
                "J",
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "J",
                2,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "M",
                1,
                10,
                new User[]
                {
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                }
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                0,
                10,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                1,
                0,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "Jeanne",
                0,
                0,
                Array.Empty<User>()
            };
            yield return new object[]
            {
                loader.Get(),
                "",
                1,
                10,
                new User[]
                {
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11", "email11", "password11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12", "email12", "password12"),
                    new(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email13", "password13"),
                    new(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email14", "password14"),
                    new(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15", "email15", "password15"),
                    new(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16", "email16", "password16")
                }
            };
        }
    }
}