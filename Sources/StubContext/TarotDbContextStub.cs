using Microsoft.EntityFrameworkCore;
using TarotDB;
using TarotDB.Enums;

namespace StubContext;

/// <summary>
/// Stub context for testing
/// </summary>
public class TarotDbContextStub : TarotDbContext
{
    /// <summary>
    /// Default constructor
    /// </summary>
    public TarotDbContextStub()
    {
    }

    /// <summary>
    /// Constructor with options
    /// </summary>
    /// <param name="options"> Options </param>
    public TarotDbContextStub(DbContextOptions<TarotDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(@"Data Source=TarotStub.db", b => b.MigrationsAssembly("TarotDB"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AddPlayers(modelBuilder);
        AddGroups(modelBuilder);
        AddGames(modelBuilder);
        AddHands(modelBuilder);
    }

    /// <summary>
    /// Add players to the context
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    private static void AddPlayers(ModelBuilder modelBuilder)
    {
        var fName = new[]
        {
            "Jean", "Jean", "Jean", "Michel", "Albert", "Julien", "Simon", "Jordan", "Samuel", "Brigitte",
            "Jeanne", "Jules", "Anne", "Marine", "Eliaz", "Alizee"
        };
        var lName = new[]
        {
            "BON", "MAUVAIS", "MOYEN", "BELIN", "GOL", "PETIT", "SEBAT", "LEG", "LE CHANTEUR", "PUECH",
            "LERICHE", "INFANTE", "PETIT", "TABLETTE", "DU JARDIN", "SEBAT"
        };
        var nName = new[]
        {
            "JEBO", "JEMA", "KIKOU7", "FRIPOUILLE", "LOLA", "THEGIANT", "SEBATA", "BIGBRAIN", "LOL",
            "XXFRIPOUILLEXX", "JEMAA", "KIKOU77", "FRIPOUILLES", "LOLO", "THEGIANTE", "SEBAT"
        };

        // Add players and increment their id and avatar
        var players = new List<PlayerEntity>();
        for (var i = 0UL; i < 10UL; ++i)
        {
            players.Add(new PlayerEntity
            {
                Id = i + 1UL, FirstName = fName[i], LastName = lName[i],
                Nickname = nName[i], Avatar = $"avatar{i + 1}"
            });
        }

        var users = new List<UserEntity>();
        for (var i = 10UL; i < 16UL; ++i)
        {
            users.Add(new UserEntity
            {
                Id = i + 1UL, FirstName = fName[i], LastName = lName[i],
                Nickname = nName[i], Avatar = $"avatar{i + 1}",
                Email = $"email{i + 1}", Password = $"password{i + 1}"
            });
        }

        modelBuilder.Entity<PlayerEntity>().HasData(players);
        modelBuilder.Entity<UserEntity>().HasData(users);
    }

    /// <summary>
    /// Add groups to the context
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    private static void AddGroups(ModelBuilder modelBuilder)
    {
        var groups = new List<GroupEntity>();
        for (var i = 1UL; i < 13UL; ++i)
        {
            groups.Add(new GroupEntity { Id = i, Name = $"Group {i}" });
        }

        modelBuilder.Entity<GroupEntity>().HasData(groups);

        // Add players to groups (5 players per group)
        var playerGroup = new List<object>();
        for (var i = 1UL; i <= Convert.ToUInt64(groups.Count); ++i)
        {
            for (var j = i; j < i + 5UL; ++j)
            {
                playerGroup.Add(new { GroupsId = i, PlayersId = j });
            }
        }

        modelBuilder.Entity("GroupEntityPlayerEntity").HasData(playerGroup);
    }

    /// <summary>
    /// Add games to the context
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    private static void AddGames(ModelBuilder modelBuilder)
    {
        var startDates = new[]
        {
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 21),
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 18)
        };

        var endDates = new DateTime?[]
        {
            null, null, null, null, null, new(2022, 09, 29), new(2022, 09, 29),
            new(2022, 09, 30), new(2022, 09, 30), new(2022, 09, 23)
        };

        var games = new List<GameEntity>();
        for (var i = 0UL; i < 10UL; ++i)
        {
            games.Add(new GameEntity
            {
                Id = i + 1UL, Name = $"Game {i + 1UL}", Rules = "FrenchTarotRules", StartDate = startDates[i],
                EndDate = endDates[i]
            });
        }

        modelBuilder.Entity<GameEntity>().HasData(games);
        
        AddPlayersGame(1UL, 3U, 3U, modelBuilder);
        AddPlayersGame(4UL, 3U, 4U, modelBuilder);
        AddPlayersGame(7UL, 3U, 5U, modelBuilder);

        var gamePlayers = new object[]
        {
	        new { GamesId = 10UL, PlayersId = 9UL },
	        new { GamesId = 10UL, PlayersId = 10UL },
	        new { GamesId = 10UL, PlayersId = 11UL },
	        new { GamesId = 10UL, PlayersId = 12UL },
	        new { GamesId = 10UL, PlayersId = 13UL }
        };
        modelBuilder.Entity("GameEntityPlayerEntity").HasData(gamePlayers);
    }

    /// <summary>
    /// Add players to a game
    /// </summary>
    /// <param name="gameId"> The first game id </param>
    /// <param name="nbG"> The number of games </param>
    /// <param name="nbP"> The number of players per game </param>
    /// <param name="modelBuilder"> Model builder </param>
    private static void AddPlayersGame(ulong gameId, uint nbG, uint nbP, ModelBuilder modelBuilder)
    {
        // Add players nbP Players to nbG games
        var gamePlayer = new List<object>();
        for (var i = 0; i < nbG; ++i)
        {
            var playerId = gameId;
            for (var j = 0; j < nbP; ++j)
            {
                gamePlayer.Add(new { GamesId = gameId, PlayersId = playerId });
                ++playerId;
            }

            ++gameId;
        }

        modelBuilder.Entity("GameEntityPlayerEntity").HasData(gamePlayer);
    }

    /// <summary>
    /// Add hands to the context
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    private static void AddHands(ModelBuilder modelBuilder)
    {
        var dates = new DateTime[]
        {
            new(2022, 09, 21), new(2022, 09, 22), new(2022, 09, 23),
            new(2022, 09, 21), new(2022, 09, 21), new(2022, 09, 21),
            new(2022, 09, 21), new(2022, 09, 27), new(2022, 09, 30),
            new(2022, 09, 16), new(2022, 09, 21), new(2022, 09, 28),
            new(2022, 09, 21), new(2022, 09, 21), new(2022, 09, 25),
            new(2022, 09, 21), new(2022, 09, 25), new(2022, 09, 27),
            new(2022, 09, 29), new(2022, 09, 21), new(2022, 09, 21),
            new(2022, 09, 29), new(2022, 09, 30), new(2022, 09, 21),
            new(2022, 09, 25), new(2022, 09, 27), new(2022, 09, 29),
            new(2022, 09, 30), new(2022, 09, 18), new(2022, 09, 21),
            new(2022, 09, 22), new(2022, 09, 23)
        };

        var scores = new[]
        {
            210, 256, 151, 561, 256, 151, 567, 256, 654, 567, 365, 151, 567, 567, 151, 873, 567, 151, 567, 567, 826,
            745, 567, 567, 567, 567, 567, 567, 567, 567, 567, 567
        };
        var twentys = new[]
        {
            false, true, false, false, false, true, true, false, false, false, false, true, true, false, true, false,
            true, true, true, false, false, true, true, false, false, true, true, false, false, true, true, true
        };
        var excuses = new[]
        {
            true, true, false, false, true, false, true, true, false, false, true, false, false, false, true, true,
            false, true, false, false, false, true, false, false, true, true, false, false, true, false, true, false
        };
        var petits = new[]
        {
            PetitResultsDb.Lost, PetitResultsDb.Lost, PetitResultsDb.Lost, PetitResultsDb.Lost, PetitResultsDb.AuBoutOwned,
            PetitResultsDb.Owned, PetitResultsDb.LostAuBout, PetitResultsDb.AuBoutOwned, PetitResultsDb.Owned,
            PetitResultsDb.NotOwned, PetitResultsDb.AuBoutOwned, PetitResultsDb.AuBoutOwned, PetitResultsDb.Lost,
            PetitResultsDb.Lost, PetitResultsDb.Owned, PetitResultsDb.LostAuBout, PetitResultsDb.Lost, PetitResultsDb.Owned,
            PetitResultsDb.Owned, PetitResultsDb.LostAuBout, PetitResultsDb.Lost, PetitResultsDb.Owned, PetitResultsDb.Lost,
            PetitResultsDb.Lost, PetitResultsDb.LostAuBout, PetitResultsDb.Owned, PetitResultsDb.Lost, PetitResultsDb.Lost,
            PetitResultsDb.LostAuBout, PetitResultsDb.Lost, PetitResultsDb.Owned, PetitResultsDb.Lost
        };
        var chelems = new[]
        {
            ChelemDb.Unknown, ChelemDb.Announced, ChelemDb.Success, ChelemDb.Unknown, ChelemDb.AnnouncedSuccess,
            ChelemDb.Success, ChelemDb.Unknown, ChelemDb.Success, ChelemDb.Success, ChelemDb.AnnouncedSuccess,
            ChelemDb.Fail, ChelemDb.Success, ChelemDb.Unknown, ChelemDb.AnnouncedSuccess, ChelemDb.Success,
            ChelemDb.Fail, ChelemDb.AnnouncedSuccess, ChelemDb.AnnouncedSuccess, ChelemDb.Unknown, ChelemDb.Unknown,
            ChelemDb.AnnouncedSuccess, ChelemDb.Success, ChelemDb.Unknown, ChelemDb.Unknown, ChelemDb.AnnouncedSuccess,
            ChelemDb.Success, ChelemDb.Unknown, ChelemDb.AnnouncedSuccess, ChelemDb.Unknown, ChelemDb.AnnouncedSuccess,
            ChelemDb.Success, ChelemDb.Unknown
        };

        // Number of hands per game
        var nbHPerG = new[]
        {
            3, 3, 3, 3, 3, 4,  3, 1, 5, 4
        };

        var hands = new List<object>();
        var gameId = 1UL;
        var handId = 1UL;
        var index = 0;
        foreach (var nbId in nbHPerG)
        {
            // Add nbId hands to a game 
            for (var i = 0; i < nbId; ++i)
            {
                hands.Add(new
                {
                    Id = handId, Number = i + 1, Rules = "FrenchTarotRules", Date = dates[index],
                    TakerScore = scores[index],
                    TwentyOne = twentys[index], Excuse = excuses[index], Petit = petits[index], Chelem = chelems[index],
                    GameId = gameId
                });
                ++handId;
                ++index;
            }

            ++gameId;
        }

        modelBuilder.Entity<HandEntity>().HasData(hands);

        AddBiddings(modelBuilder, nbHPerG);
    }

    /// <summary>
    /// Add biddings to the database
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    /// <param name="numGPerH"> Number of games per hand </param>
    private static void AddBiddings(ModelBuilder modelBuilder, params int[] numGPerH)
    {
        var biddings = new[]
        {
            BiddingsDb.Petite, BiddingsDb.Petite, BiddingsDb.Garde, BiddingsDb.GardeSansLeChien,
            BiddingsDb.GardeContreLeChien, BiddingsDb.Petite, BiddingsDb.GardeSansLeChien, BiddingsDb.GardeContreLeChien,
            BiddingsDb.Petite, BiddingsDb.GardeSansLeChien, BiddingsDb.GardeContreLeChien, BiddingsDb.Petite,
            BiddingsDb.GardeSansLeChien, BiddingsDb.GardeContreLeChien, BiddingsDb.Petite, BiddingsDb.GardeSansLeChien,
            BiddingsDb.GardeContreLeChien, BiddingsDb.Petite, BiddingsDb.GardeSansLeChien, BiddingsDb.GardeSansLeChien,
            BiddingsDb.GardeSansLeChien, BiddingsDb.Garde, BiddingsDb.Petite, BiddingsDb.GardeSansLeChien, BiddingsDb.Garde,
            BiddingsDb.GardeSansLeChien, BiddingsDb.Garde, BiddingsDb.GardeSansLeChien, BiddingsDb.Garde, BiddingsDb.Garde,
            BiddingsDb.Petite, BiddingsDb.GardeContreLeChien
        };
        
        var poignees = new[]
        {
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.Simple, PoigneeDb.None, PoigneeDb.Simple, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.Double, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Triple,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Triple, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.Triple, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Triple,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.Triple, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Triple, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple,
	        PoigneeDb.None, PoigneeDb.Double, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.Triple, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.Simple,
	        PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None, PoigneeDb.None
        };

        var numPlayerPerGame = new[]
        {
            3, 3, 3, 4, 4, 4, 5, 5, 5, 5
        };

        var bids = new List<BiddingPoigneeEntity>();
        var handId = 1UL;
        var index = 0;
        var biddingIndex = 0;

        // browse number of games per hand (numGPerH) and number of players per game (nbPperG)
        for (var gamePlayerIndex = 0; gamePlayerIndex < numGPerH.Length - 1; ++gamePlayerIndex)
        {
            // Add bidding for each hand
            for (var i = 0; i < numGPerH[gamePlayerIndex]; ++i)
            {
                // Add player id for each hand (and return to the first player id for the next hand)
                var playerId = Convert.ToUInt64(gamePlayerIndex + 1);
                for (var j = 0; j < numPlayerPerGame[gamePlayerIndex]; ++j)
                {
                    // Add the taker bidding for first player, if 5 players the last one is a King and all the others are a Opponent
                    var bidding = j switch
                    {
                        0 => biddings[biddingIndex],
                        4 => BiddingsDb.King,
                        _ => BiddingsDb.Opponent
                    };

                    bids.Add(new BiddingPoigneeEntity
                        { Biddings = bidding, Poignee = poignees[index], HandId = handId, PlayerId = playerId });

                    ++playerId;
                    ++index;
                }

                ++handId;
                ++biddingIndex;
            }
        }
        
        for (var i = 0; i < numGPerH[^1]; ++i)
        {
	        // Add player id for each hand (and return to the first player id for the next hand)
	        var playerId = 9UL;
	        for (var j = 0; j < numPlayerPerGame[^1]; ++j)
	        {
		        // Add the taker bidding for first player, if 5 players the last one is a King and all the others are a Opponent
		        var bidding = j switch
		        {
			        0 => biddings[biddingIndex],
			        4 => BiddingsDb.King,
			        _ => BiddingsDb.Opponent
		        };

		        bids.Add(new BiddingPoigneeEntity
			        { Biddings = bidding, Poignee = poignees[index], HandId = handId, PlayerId = playerId });

		        ++playerId;
		        ++index;
	        }

	        ++handId;
	        ++biddingIndex;
        }

        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(bids);
    }
}