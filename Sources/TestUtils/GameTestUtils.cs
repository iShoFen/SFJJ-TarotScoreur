using Model.Games;
using Model.Players;
using Model.Rules;

namespace TestUtils;

internal class GameTestUtils
{
    public static Game CreateGameWithIdAndPlayers(ulong id, string name, IRules rules, DateTime date, DateTime? endDate, params Player[] players)
    {
        var game = new Game(id, name, rules, date, endDate);
        game.AddPlayers(players);
        return game;
    }

    public static Game CreateGameWithPlayers(string name, IRules rules, DateTime date, params Player[] players)
    {
        var game = new Game(name, rules, date);
        game.AddPlayers(players);
        return game;
    }

    public static Game CreateGameWithHands(string name, IRules rules, DateTime date, params Hand[] hands)
    {
        var game = new Game(name, rules, date);
        game.AddHands(hands);
        return game;
    }

    public static Game CreateGameWithPlayersAndHands(ulong id, string name, IRules rules, DateTime startDate, DateTime? endDate, Player[] players, Hand[] hands)
    {
        var game = new Game(id, name, rules, startDate, endDate);
        game.AddPlayers(players);
        game.AddHands(hands);
        return game;
    }
}

