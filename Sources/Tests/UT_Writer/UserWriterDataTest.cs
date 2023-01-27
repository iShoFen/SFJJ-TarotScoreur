using Model.Players;

namespace UT_Writer;

using static TestUtils.DataManagers;

public static class UserWriterDataTest
{
    public static IEnumerable<object?[]> InsertUserData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new User("Pedro", "Machin", "Pema", "avatar28", "email", "password"),
                new User(17UL, "Pedro", "Machin", "Pema", "avatar28", "email", "password")
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(6UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email", "password"),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email", "password"),
                null
            };
            yield return new object?[]
            {
                writer.Get(), 
                new User(50UL, "Pedro", "Machin", "Pema", "avatar28", "email", "password"), 
                null
            };
        }
    }
    
    public static IEnumerable<object?[]> UpdateUserData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new User(14UL , "Pedro", "Machin", "Pema", "avatar28", "email", "password"),
                new User(14UL, "Pedro", "Machin", "Pema", "avatar28", "email", "password")
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(6UL , "Pedro", "Machin", "Pema", "avatar28", "email", "password"),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(50UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email", "password"),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(0UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13", "email", "password"),
                null
            };
        }
    }
    
    public static IEnumerable<object?[]> DeleteUserWithObjectData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new User(6UL, "Julien", "PETIT", "THEGIANT", "avatar6", "email", "password"),
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(14UL, "Marine", "TABLETTE", "LOLO", "avatar14", "email", "password"),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(50UL, "Ce", "texte", "n'est pas", "utilisé", "email", "password"),
                false,
            };
            yield return new object?[]
            {
                writer.Get(), 
                new User(0UL, "Ce", "texte", "n'est pas", "utilisé", "email", "password"),
                false
            };
        }
    }
    
    public static IEnumerable<object?[]> DeleteUserWithIdData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                3UL,
                false
            };
            yield return new object?[]
            {
                writer.Get(),
                14UL,
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