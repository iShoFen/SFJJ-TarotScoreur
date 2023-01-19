using Model.Games;
using Model.Players;
using Model.Rules;

namespace UT_Writer;

using static TestUtils.DataManagers;
using static TestUtils.GameTestUtils;

internal static class GameWriterDataTest
{
    public static IEnumerable<object?[]> InsertGameData()
    {
        foreach (var writer in Writers)
        {
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>()),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>())
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    Array.Empty<Player>()),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    Array.Empty<Player>())
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4")),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    new DateTime(2023, 02, 10),
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"))
            };
        }
    }
}