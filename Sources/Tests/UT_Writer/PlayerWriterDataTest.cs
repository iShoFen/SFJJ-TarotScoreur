using Model.Players;
using TarotDB;

namespace UT_Writer;

using static TestUtils.DataManagers;

internal static class PlayerWriterDataTest
{
    public static IEnumerable<object?[]> InsertPlayerData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Player("Pedro", "Machin", "Pema", "avatar28"),
                new Player(17UL, "Pedro", "Machin", "Pema", "avatar28")
            };
            yield return new object?[]
            {
                writer.Get(),
                new User("Pedro", "Machin", "Pema", "avatar28", "email", "password"),
                new Player(17UL, "Pedro", "Machin", "Pema", "avatar28")
            };
            yield return new object?[]
            {
                writer.Get(),
                new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                null,
            };
            yield return new object?[]
            {
                writer.Get(), 
                new Player(17UL, "Pedro", "Machin", "Pema", "avatar28"), 
                null
            };
        }
    }
    
    public static IEnumerable<object?[]> UpdatePlayerData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Player(14UL , "Pedro", "Machin", "Pema", "avatar28"),
                new Player(14UL, "Pedro", "Machin", "Pema", "avatar28")
            };
            yield return new object?[]
            {
                writer.Get(),
                new User(14UL, "Pedro", "Machin", "Pema", "avatar28", "email", "password"),
                new Player(17UL, "Pedro", "Machin", "Pema", "avatar28")
            };
            yield return new object?[]
            {
                writer.Get(),
                new Player(50UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
                null,
            };
            yield return new object?[]
            {
                writer.Get(), 
                new Player(28UL, "Pedro", "Machin", "Pema", "avatar28"), 
                null
            };
        }
    }
    
    public static IEnumerable<object?[]> DeletePlayerWithObjectData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"),
                true
            };
            yield return new object?[]
            {
                writer.Get(),
                new Player(50UL, "Ce", "texte", "n'est pas", "utilisé"),
                false,
            };
            yield return new object?[]
            {
                writer.Get(), 
                new Player(0UL, "Ce", "texte", "n'est pas", "utilisé"),
                false
            };
        }
    }
    
    public static IEnumerable<object?[]> DeletePlayerWithIdData()
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