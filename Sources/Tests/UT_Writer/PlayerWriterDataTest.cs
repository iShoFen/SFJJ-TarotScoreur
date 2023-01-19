using Model.Players;
using TarotDB;

namespace UT_Writer;

using static TestUtils.DataManagers;

internal static class PlayerWriterDataTest
{
    public static IEnumerable<object?[]> Data_TestInsertPlayer()
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
}