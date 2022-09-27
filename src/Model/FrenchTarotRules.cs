using Model.enums;
using Model.games;

namespace Model;

/// <summary>
/// The French Tarot Rules implementation.
/// </summary>
public class FrenchTarotRules : IRules
{
    /// <summary>
    /// Minimum number  of players needed to play a game with these rules
    /// </summary>
    public int MinNbPlayers => 3;

    /// <summary>
    /// Maximum number of players needed to play a game with these rules
    /// </summary>
    public int MaxNbPlayers => 5;

    /// <summary>
    /// Minimum number of players for call a king in a game with these rules
    /// </summary>
    public int MinNbPlayersForKing => 5;

    /// <summary>
    /// Maximum number of players called for king to play a game with these rules
    /// </summary>
    public int MaxNbKing => 1;

    /// <summary>
    /// Name of these rules
    /// </summary>
    public string Name => GetType().Name;

    /// <summary>
    /// Score required to win a game according to numbers of oudlers
    /// </summary>
    private readonly Dictionary<int, int> _oudlersPoints = new()
    {
        [0] = 56,
        [1] = 51,
        [2] = 41,
        [3] = 36
    };
    
    /// <summary>
    /// Multiplicators of of the different biddings
    /// </summary>
    private readonly Dictionary<Bidding, int> _multiplicators = new()
    {
        [Bidding.Petite] = 1,
        [Bidding.Garde] = 2,
        [Bidding.GardeSansLeChien] = 4,
        [Bidding.GardeContreLeChien] = 6,
    };

    /// <summary>
    /// The different bonus for the Poignee
    /// </summary>
    private readonly Dictionary<Poignee, int> _primesPoignee = new()
    {
        [Poignee.None] = 0,
        [Poignee.Simple] = 20,
        [Poignee.Double] = 30,
        [Poignee.Triple] = 40    
    };

    /// <summary>
    /// The different bonus for the Chelem
    /// </summary>
    private readonly Dictionary<Chelem, int> _primesChelem = new()
    {
        [Chelem.Unknown] = 0,
        [Chelem.Success] = 200,
        [Chelem.AnnouncedSuccess] = 400,
        [Chelem.AnnouncedFail] = -200
    };

    /// <summary>
    /// The Bonus for Petit au bout
    /// </summary>
    private const int PrimeAuBout = 10;

    /// <summary>
    /// Calculate the score for a hand
    /// </summary>
    /// <param name="hand"> Hand to calculate the score </param>
    /// <returns> The score of each player in the hand </returns>
    public IReadOnlyDictionary<Player,int> GetHandScore(Hand hand)
    {
        if (IsHandValid(hand, out _) != Validity.Valid) throw new ArgumentException("Hand is not valid");
        var neededScore = GetOudlersPoints(GetNumberOfOudlers(hand));
        var takerScore = hand.TakerScore;
            
        var score = GetTruePointOfTaker(takerScore,neededScore);
        score += GetPrimeAuBout(hand.Petit);
        score *= GetMultiplicator(hand.Biddings.Select(bidding => bidding.Value.Item1).ToList());
        if (score < 0) score -= GetPrimePoignee((hand.Biddings.Select(bidding => bidding.Value.Item2).ToList()));
        else score += GetPrimePoignee((hand.Biddings.Select(bidding => bidding.Value.Item2).ToList()));
        score += GetPrimeChelem(hand.Chelem);
        return GetAllPlayersScore(hand, score);
    }

    /// <summary>
    /// Get the score of each player in a hand
    /// </summary>
    /// <param name="hand"> Hand to calculate the score </param>
    /// <param name="takerScore"> Score of the taker </param>
    /// <returns> The score of each player in the hand </returns>
    private static IReadOnlyDictionary<Player, int> GetAllPlayersScore(Hand hand, int takerScore)
    {
        var scores = new Dictionary<Player, int>();
        foreach (var player in hand.Biddings)
        {
            if ((player.Value.Item1 & Bidding.Prise) == Bidding.Prise)
            {
                scores.Add(player.Key, hand.Biddings.Count == 5? takerScore * 2 : takerScore * (hand.Biddings.Count-1));
            }
            else if (player.Value.Item1 == Bidding.King)
            {
                scores.Add(player.Key, takerScore);
            }
            else scores.Add(player.Key, -takerScore);
        }

        return scores;
    }

    /// <summary>
    /// Get the bonus for petit au bout
    /// </summary>
    /// <param name="petitResult"> Result of the petit au bout </param>
    /// <returns> The bonus for petit au bout </returns>
    private static int GetPrimeAuBout(PetitResult petitResult)
    {
        return petitResult switch
        {
            PetitResult.AuBoutOwned => PrimeAuBout,
            PetitResult.LostAuBout => -PrimeAuBout,
            _ => 0
        };
    }
        
    /// <summary>
    /// Return the number of oudlers in the hand
    /// <param name="hand">Hand which is use</param>
    /// </summary>
    /// <returns>Number of oudlers</returns>
    private static int GetNumberOfOudlers(Hand hand)
    {
        var nbOudlers = 0;
        if(hand.TwentyOne == true) ++nbOudlers;
        if(hand.Excuse == true) ++nbOudlers;
        if((hand.Petit & PetitResult.Owned) == PetitResult.Owned) ++nbOudlers;
        return nbOudlers;
    }
    /// <summary>
    /// Return the number of points needed to win the hand
    /// </summary>
    /// <param name="nbOudlers">Number of oudlers</param>
    /// <returns>Needed point to win</returns>
    private int GetOudlersPoints(int nbOudlers)
    {
        return _oudlersPoints[nbOudlers];
    }

    /// <summary>
    ///  Get the score of the taker according to the needed score
    /// </summary>
    /// <param name="takerScore"> Score of the taker </param>
    /// <param name="neededScore"> Score needed to win </param>
    /// <returns> The true score of the taker </returns>
    private static int GetTruePointOfTaker(int takerScore, int neededScore)
    {
        int score;
        if (takerScore >= neededScore) score = 25 + (takerScore - neededScore);
        else score = -25 - (neededScore - takerScore);
        return score;
    }
    /// <summary>
    /// Return the multiplicator of the taker bidding
    /// </summary>
    /// <param name="biddings"> List of biddings in the hand</param>
    /// <returns> The multiplicator of the taker bidding </returns>
    private int GetMultiplicator(IEnumerable<Bidding> biddings)
    {
        var multiplicator = 0;
        foreach (var bidding in biddings.Where(bidding => (bidding & Bidding.Prise) == Bidding.Prise))
        {
            multiplicator = _multiplicators[bidding];
        }

        return multiplicator;
    }
     
    /// <summary>
    /// Get the bonus for the poignee
    /// </summary>
    /// <param name="poignees"> List of poignees in the hand </param>
    /// <returns> The bonus for the poignee </returns>
    private int GetPrimePoignee(IEnumerable<Poignee> poignees) => poignees.Sum(poignee => _primesPoignee[poignee]);

    /// <summary>
    /// Get the bonus for the Chelem
    /// </summary>
    /// <param name="chelem"> Chelem in the hand </param>
    /// <returns> The bonus for the Chelem </returns>
    private int GetPrimeChelem(Chelem chelem) => _primesChelem[chelem];

    /// <summary>
    /// Check is the game is valid
    /// </summary>
    /// <param name="game"> Game to check </param>
    /// <returns> The validity of the game </returns>
    public Validity IsGameValid(Game game)
    {
        if (game.Players.Count < MinNbPlayers) return Validity.NotEnoughPlayers;
        return game.Players.Count >= MaxNbPlayers ? Validity.EnoughPlayers : Validity.Valid;
    }
    
    /// <summary>
    /// Check if the hand is valid
    /// </summary>
    /// <param name="hand"> Hand to check </param>
    /// <param name="isValid"> Boolean to know if the hand is valid </param>
    /// <returns> The validity of the hand </returns>
    public Validity IsHandValid(Hand hand, out bool isValid)
    {
        isValid = false;
        var biddings = hand.Biddings.Select(bidding => bidding.Value.Item1).ToList();

        var valid = IsTakerScoreValid(hand.TakerScore);
        if (valid != Validity.Valid) return valid;
            
        valid = IsPlayersBiddingValid(biddings);
        if (valid != Validity.Valid) return valid;
            
        valid = IsChelemValid(hand);
        if (valid != Validity.Valid) return valid;
            
        isValid = true;
        return valid;
    }
    
    /// <summary>
    /// Verify if the taker score is valid
    /// </summary>
    /// <param name="takerScore"> The taker score </param>
    /// <returns> Validity.Valid if the taker score is valid
    /// Validity.TakerNegativeScore if the taker score is negative
    /// Validity.TakerTooMany point if the taker score is grower than 91 </returns>
    private static Validity IsTakerScoreValid(int takerScore)
    {
        if (takerScore < 0) return Validity.TakerNegativeScore;
        return takerScore > 91 ? Validity.TakerTooManyPoints : Validity.Valid;
    }
        
    /// <summary>
    ///  Check if the biddings are valid
    /// </summary>
    /// <param name="iBiddings"> List of biddings </param>
    /// <returns> The validity of the biddings </returns>
    private Validity IsPlayersBiddingValid(IEnumerable<Bidding> iBiddings)
    {
        int nbKing = 0, nbTaker=0;
        var biddings = iBiddings.ToList();
            
        foreach (var bidding in biddings)
        {
            if (bidding == Bidding.King) ++nbKing;
            if((bidding & Bidding.Prise) == Bidding.Prise) ++nbTaker;
            if (bidding == Bidding.Unknown) return Validity.PlayerShallHaveBidding;
        }

        if (nbKing > MaxNbKing || (biddings.Count < 5 && nbKing > 0)) return Validity.TooManyKing;
        if (nbTaker == 0) return Validity.NoTaker;
        return Validity.Valid;
    }

    /// <summary>
    /// Check if the chelem is valid
    /// </summary>
    /// <param name="hand"> Hand to check </param>
    /// <returns> The validity of the chelem </returns>
    private static Validity IsChelemValid(Hand hand)
    {
        if (hand.Chelem is Chelem.Success or Chelem.AnnouncedSuccess &&
            hand.TakerScore != 91) return Validity.InvalidChelem;
        
        return Validity.Valid;
    }

    /// <summary>
    /// Check if two IRules are equals
    /// </summary>
    /// <param name="other"> The other IRules </param>
    /// <returns> True if the two IRules are equals, false otherwise </returns>
    public virtual bool Equals(IRules? other) => other != null && other.GetType() == GetType();
    
    /// <summary>
    /// Check if two objects are equals
    /// </summary>
    /// <param name="obj"> The other object </param>
    /// <returns> True if the two objects are equals, false otherwise </returns>
    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(obj, null)) return false;
        if(ReferenceEquals(this, obj)) return true;

        return GetType() == obj.GetType() && Equals(obj as FrenchTarotRules);
    }
        
    /// <summary>
    /// Get the hash code of the object
    /// </summary>
    /// <returns> The hash code of the object </returns>
    public override int GetHashCode() => GetType().Name.GetHashCode();
}