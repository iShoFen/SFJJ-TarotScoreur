using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;

namespace UT_Model.Manager;

using static TestUtils.DataManagers;
using static TestUtils.GameTestUtils;

public class GameInsertData
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
                    null,
                    Array.Empty<Player>()),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    null,
                    Array.Empty<Player>())
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(0UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    null,
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4")),
                CreateGameWithIdAndPlayers(11UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19),
                    null,
                    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
                    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
                    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"))
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(8UL, "Game 1", new FrenchTarotRules(), new DateTime(2023, 01, 19), null,
                    Array.Empty<Player>()),
                null
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(
                    0UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                ),
                CreateGameWithIdAndPlayers(
                    11UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(
                    0UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                ),
                CreateGameWithIdAndPlayers(
                    11UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
                    new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                )
            };
            yield return new object?[]
            {
                writer.Get(),
                CreateGameWithIdAndPlayers(
                    0UL,
                    "Game 8",
                    new FrenchTarotRules(),
                    new DateTime(2022, 09, 21),
                    null,
                    new(25UL, "Michel", "SARDOU", "coucou", "avatar25"),
                    new(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
                    new(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
                    new(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
                    new(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
                ),
                null
            };
        }
    }
}
