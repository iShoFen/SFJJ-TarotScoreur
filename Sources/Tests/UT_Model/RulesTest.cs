using Model.Enums;
using Model.Rules;
using Model.Games;
using Model.Players;

namespace UT_Model;

public class RulesTest : IRules
{
    public int MinNbPlayers { get; }
    public int MaxNbPlayers { get; }
    public int MinNbPlayersForKing { get; }
    public int MaxNbKing { get; }
    public string Name => GetType().Name;
    public Validity IsGameValid(Game game)
    {
        throw new NotImplementedException();
    }

    public Validity IsHandValid(Hand hand, out bool isValid)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyDictionary<Player, int> GetHandScore(Hand hand)
    {
        throw new NotImplementedException();
    }
}