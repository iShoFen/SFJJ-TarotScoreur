using Microsoft.EntityFrameworkCore;
using TarotDB;
using TarotDB.enums;

namespace StubContext;

/// <summary>
/// Stub context for testing
/// </summary>
internal class TarotDBContextStub : TarotDBContext
{
	/// <summary>
	/// Constructor with options
	/// </summary>
	/// <param name="options"> Options </param>
	public TarotDBContextStub(DbContextOptions<TarotDBContext> options) : base(options)
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
			"BON", "MAUVAIS", "MOYEN", "BELIN", "GOL", "PETIT", "SEBAT", "LEG", "LeChanteur", "PUECH",
			"LERICHE", "INFANTE", "SAURIN", "TABLETTE", "DU JARDIN", "SEBAT"
		};
		var nName = new[]
		{
			"JEBO", "JEMA", "KIKOU7", "FRIPOUILLE", "LOL", "THEGIANT", "SEBAT", "BIGBRAIN", "SS",
			"XXFRIPOUILLEXX", "JEMO", "KIKOU8", "FRIPOUILLE2", "LOL2", "THEGIANT2", "SEBAT2"
		};

		// Add players and increment their id and avatar
		var players = new List<PlayerEntity>();
		for (var i = 0UL; i < 16UL; ++i)
		{
			players.Add(new PlayerEntity
			{
				Id = i + 1UL, FirstName = fName[i], LastName = lName[i],
				Nickname = nName[i], Avatar = $"avatar{i + 1}"
			});
		}

		modelBuilder.Entity<PlayerEntity>().HasData(players);
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
			groups.Add(new GroupEntity {Id = i, Name = $"Group{i}"});
		}

		modelBuilder.Entity<GroupEntity>().HasData(groups);

		// Add players to groups (5 players per group)
		var playerGroup = new List<object>();
		for (var i = 1UL; i < 13UL; ++i)
		{
			for (var j = i; j < 6UL; ++j)
			{
				playerGroup.Add(new {GroupsId = i, PlayersId = j});
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
			new(2022, 09, 30), new(2022, 09, 30), new(2022, 09, 30)
		};
		
		var games = new List<GameEntity>();
		for (var i = 0UL; i < 10UL; ++i)
		{
			games.Add(new GameEntity
			{
				Id = i + 1UL, Name = $"Game{i + 1UL}", Rules = "FrenchTarotRules", StartDate = startDates[i],
				EndDate = endDates[i]
			});
		}

		modelBuilder.Entity<GameEntity>().HasData(games);

		AddPlayersGame(1UL, 3U, 3U, modelBuilder);
		AddPlayersGame(4UL, 3U, 4U, modelBuilder);
		AddPlayersGame(7UL, 4U, 5U, modelBuilder);
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
			    gamePlayer.Add(new {GamesId = gameId, PlayersId = playerId});
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
		    new(2022, 09, 30), new(2022, 09, 18), new(2022, 09, 25),
		    new(2022, 09, 29), new(2022, 09, 30)
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
		    PetitResultDB.Lost, PetitResultDB.Lost, PetitResultDB.Lost, PetitResultDB.Lost, PetitResultDB.AuBoutOwned,
		    PetitResultDB.Owned, PetitResultDB.LostAuBout, PetitResultDB.AuBoutOwned, PetitResultDB.Owned,
		    PetitResultDB.NotOwned, PetitResultDB.AuBoutOwned, PetitResultDB.AuBoutOwned, PetitResultDB.Lost,
		    PetitResultDB.Lost, PetitResultDB.Owned, PetitResultDB.LostAuBout, PetitResultDB.Lost, PetitResultDB.Owned,
		    PetitResultDB.Owned, PetitResultDB.LostAuBout, PetitResultDB.Lost, PetitResultDB.Owned, PetitResultDB.Lost,
		    PetitResultDB.Lost, PetitResultDB.LostAuBout, PetitResultDB.Owned, PetitResultDB.Lost, PetitResultDB.Lost,
		    PetitResultDB.LostAuBout, PetitResultDB.Lost, PetitResultDB.Owned, PetitResultDB.Lost
	    };
	    var chelems = new[]
	    {
		    ChelemDB.Unknown, ChelemDB.Announced, ChelemDB.Success, ChelemDB.Unknown, ChelemDB.AnnouncedSuccess,
		    ChelemDB.Success, ChelemDB.Unknown, ChelemDB.Success, ChelemDB.Success, ChelemDB.AnnouncedSuccess,
		    ChelemDB.Fail, ChelemDB.Success, ChelemDB.Unknown, ChelemDB.AnnouncedSuccess, ChelemDB.Success,
		    ChelemDB.Fail, ChelemDB.AnnouncedSuccess, ChelemDB.AnnouncedSuccess, ChelemDB.Unknown, ChelemDB.Unknown,
		    ChelemDB.AnnouncedSuccess, ChelemDB.Success, ChelemDB.Unknown, ChelemDB.Unknown, ChelemDB.AnnouncedSuccess,
		    ChelemDB.Success, ChelemDB.Unknown, ChelemDB.AnnouncedSuccess, ChelemDB.Unknown, ChelemDB.AnnouncedSuccess,
		    ChelemDB.Success, ChelemDB.Unknown
	    };
	    
	    // Number of hands per game
	    var nbHperG = new[]
	    {
		    3, 3, 3, 3, 3, 4, 3, 1, 5, 4
	    };
	    
	    var hands = new List<object>();
	    var gameId = 1UL;
	    var handId = 1UL;
	    var index = 0;
	    foreach (var nbId in nbHperG)
	    {
		    // Add nbId hands to a game 
		    for (var i = 0; i < nbId; ++i)
		    {
			    hands.Add(new
			    {
				    Id = handId, Number = i + 1, Rules = "FrenchTarotRules", Date = dates[index], TakerScore = scores[index],
				    TwentyOne = twentys[index], Excuse = excuses[index], Petit = petits[index], Chelem = chelems[index],
				    GameId = gameId
			    });
			    ++handId; ++index;
		    }
		    ++gameId;
	    }
	    modelBuilder.Entity<HandEntity>().HasData(hands);
	    
	    AddBiddings(modelBuilder,nbHperG);
    }

	/// <summary>
	/// Add biddings to the database
	/// </summary>
	/// <param name="modelBuilder"> Model builder </param>
	/// <param name="numGperH"> Number of games per hand </param>
    private static void AddBiddings(ModelBuilder modelBuilder, params int[] numGperH)
    {
	    var biddings = new[]
	    {
		    BiddingDB.Petite, BiddingDB.Petite, BiddingDB.Garde, BiddingDB.GardeSansLeChien,
		    BiddingDB.GardeContreLeChien, BiddingDB.Petite, BiddingDB.GardeSansLeChien, BiddingDB.GardeContreLeChien,
		    BiddingDB.Petite, BiddingDB.GardeSansLeChien, BiddingDB.GardeContreLeChien, BiddingDB.Petite,
		    BiddingDB.GardeSansLeChien, BiddingDB.GardeContreLeChien, BiddingDB.Petite, BiddingDB.GardeSansLeChien,
		    BiddingDB.GardeContreLeChien, BiddingDB.Petite, BiddingDB.GardeSansLeChien, BiddingDB.GardeSansLeChien,
		    BiddingDB.GardeSansLeChien, BiddingDB.Garde, BiddingDB.Petite, BiddingDB.GardeSansLeChien, BiddingDB.Garde,
		    BiddingDB.GardeSansLeChien, BiddingDB.Garde, BiddingDB.GardeSansLeChien, BiddingDB.Garde, BiddingDB.Garde,
		    BiddingDB.Petite, BiddingDB.GardeContreLeChien
	    };
	    var poignees = new[]
	    {
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.Simple, PoigneeDB.None, PoigneeDB.Simple, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.Double, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Triple,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Triple, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.Triple, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Triple,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.Triple, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Triple, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple,
		    PoigneeDB.None, PoigneeDB.Double, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.Triple, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.Simple,
		    PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None, PoigneeDB.None
	    };

	    var numPlayerperGame = new[]
	    {
		    3, 3, 3, 4, 4, 4, 5, 5, 5, 5
	    };

	    var bids = new List<BiddingPoigneeEntity>();
	    var handId = 1UL;
	    var index = 0;
	    var biddingIndex = 0;

	    // browse number of games per hand (numGperH) and number of players per game (nbPperG)
	    for (var gamePlayerIndex = 0; gamePlayerIndex < numGperH.Length; ++gamePlayerIndex)
	    {
		    // Add bidding for each hand
		    for (var i = 0;  i < numGperH[gamePlayerIndex]; ++i)
		    {
			    // Add player id for each hand (and return to the first player id for the next hand)
			    var playerId = Convert.ToUInt64(gamePlayerIndex + 1);
			    for (var j = 0; j < numPlayerperGame[gamePlayerIndex]; ++j)
			    {
				    // Add the taker bidding for first player, if 5 players the last one is a King and all the others are a Opponent
				    var bidding = j switch
				    {
					    0 => biddings[biddingIndex],
					    4 => BiddingDB.King,
					    _ => BiddingDB.Opponent
				    };

				    bids.Add(new BiddingPoigneeEntity
					    {Bidding = bidding, Poignee = poignees[index], HandId = handId, PlayerId = playerId});
				    
				    ++playerId; ++index;
			    }
			    ++handId; ++biddingIndex;
		    }
	    }
	    
	    modelBuilder.Entity<BiddingPoigneeEntity>().HasData(bids);
    }
}