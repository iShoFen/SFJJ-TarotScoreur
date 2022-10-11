using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using TarotDB;
using TarotDB.enums;

namespace StubContext;

internal class TarotDBContextStub : TarotDBContext
{
	public TarotDBContextStub(DbContextOptions<TarotDBContext> options) : base(options) { }
	
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

    private static void AddGroups(ModelBuilder modelBuilder)
    {
	    var groups = new List<GroupEntity>();
	    for (var i = 1UL; i < 13UL; ++i)
	    {
		    groups.Add(new GroupEntity {Id = i, Name = $"Group{i}"});
	    }

	    modelBuilder.Entity<GroupEntity>().HasData(groups);

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

    private static void AddGames(ModelBuilder modelBuilder)
    {
	    modelBuilder.Entity<GameEntity>().HasData(
		    new GameEntity
			    {Id = 1UL, Name = "Game1", Rules = "FrenchTarotRules", StartDate = DateTime.Now},
		    new GameEntity
			    {Id = 2UL, Name = "Game2", Rules = "FrenchTarotRules", StartDate = DateTime.Now},
		    new GameEntity
			    {Id = 3UL, Name = "Game3", Rules = "FrenchTarotRules", StartDate = DateTime.Now},
		    new GameEntity
			    {Id = 4UL, Name = "Game4", Rules = "FrenchTarotRules", StartDate = DateTime.Now},
		    new GameEntity
			    {Id = 5UL, Name = "Game5", Rules = "FrenchTarotRules", StartDate = DateTime.Now},
		    new GameEntity
		    {
			    Id = 6UL, Name = "Game13", Rules = "FrenchTarotRules", StartDate = new DateTime(2022, 09, 21),
			    EndDate = new DateTime(2022, 09, 25)
		    },
		    new GameEntity
		    {
			    Id = 7UL, Name = "Game14", Rules = "FrenchTarotRules", StartDate = new DateTime(2022, 09, 21),
			    EndDate = new DateTime(2022, 09, 25)
		    },
		    new GameEntity
		    {
			    Id = 8UL, Name = "Game15", Rules = "FrenchTarotRules", StartDate = new DateTime(2022, 09, 21),
			    EndDate = new DateTime(2022, 09, 25)
		    },
		    new GameEntity
		    {
			    Id = 9UL, Name = "Game16", Rules = "FrenchTarotRules", StartDate = new DateTime(2022, 09, 21),
			    EndDate = new DateTime(2022, 09, 25)
		    },
		    new GameEntity
		    {
			    Id = 10UL, Name = "Game17", Rules = "FrenchTarotRules", StartDate = new DateTime(2022, 09, 18),
			    EndDate = new DateTime(2022, 09, 23)
		    });

	    AddPlayersGame(1UL, 3UL, 3UL, modelBuilder);
	    AddPlayersGame(4UL, 3UL, 4UL, modelBuilder);
	    AddPlayersGame(7UL, 4UL, 5UL, modelBuilder);
    }

    private static void AddPlayersGame(ulong startG, ulong nbG, ulong nbP, ModelBuilder modelBuilder)
    {
	    var gamePlayer = new List<object>();
	    for (var i = startG; i < nbG + 1UL; ++i)
	    {
		    for (var j = i; j < nbP + 1UL; ++j)
		    {
			    gamePlayer.Add(new {GamesId = i, PlayersId = j});
		    }
	    }

	    modelBuilder.Entity("GameEntityPlayerEntity").HasData(gamePlayer);
    }

    private static void AddHands(ModelBuilder modelBuilder)
    {
	    var dates = new DateTime[]
	    {
		    new(2022, 09, 21), new(2022, 09, 22), 
		    new(2022, 09, 23), new(2022, 09, 21), 
		    new(2022, 09, 21), new(2022, 09, 21), 
		    new(2022, 09, 21), new(2022, 09, 27),
		    new(2022, 09, 30), new(2022, 09, 16),
		    new(2022, 09, 21), new(2022, 09, 28), 
		    new(2022, 09, 21), new(2022, 09, 21), 
		    new(2022, 09, 25), new(2022, 09, 21),
		    new(2022, 09, 25), new(2022, 09, 27), 
		    new(2022, 09, 29), new(2022, 09, 21),
		    new(2022, 09, 21), new(2022, 09, 29),
		    new(2022, 09, 30), new(2022, 09, 21),
		    new(2022, 09, 25), new(2022, 09, 27), 
		    new(2022, 09, 29), new(2022, 09, 30), 
		    new(2022, 09, 21), new(2022, 09, 25),
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
	    var nbHperG = new[]
	    {
		    3, 3, 3, 3, 3, 4, 3, 1, 5, 4
	    };
	    
	    var hands = new List<object>();
	    var gId = 1UL;
	    var hId = 1UL;
	    var index = 0;
	    foreach (var nbId in nbHperG)
	    {
		    for (var i = 0; i < nbId; ++i)
		    {
			    hands.Add(new
			    {
				    Id = hId, Number = i, Rules = "FrenchTarotRules", Date = dates[index], TakerScore = scores[index],
				    TwentyOne = twentys[index], Excuse = excuses[index], Petit = petits[index], Chelem = chelems[index],
				    GameId = gId
			    });
			    ++hId; ++index;
		    }
		    ++gId;
	    }
	    modelBuilder.Entity<HandEntity>().HasData(hands);
	    
	    AddBiddings(modelBuilder,nbHperG);
    }

    private static void AddBiddings(ModelBuilder modelBuilder, params int[] nbGperH)
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

	    var nbPperG = new[]
	    {
		    3, 3, 3, 4, 4, 4, 5, 5, 5, 5
	    };

	    var bids = new List<BiddingPoigneeEntity>();
	    var hId = 1UL;
	    var index = 0;
	    var biddingIndex = 0;

	    for (var gpIndex = 0; gpIndex < nbGperH.Length; ++gpIndex)
	    {
		    for (var i = 0;  i < nbGperH[gpIndex]; ++i)
		    {
			    var pId = Convert.ToUInt64(gpIndex + 1);
			    for (var j = 0; j < nbPperG[gpIndex]; ++j)
			    {
				    var bidding = j switch
				    {
					    0 => biddings[biddingIndex],
					    4 => BiddingDB.King,
					    _ => BiddingDB.Opponent
				    };

				    bids.Add(new BiddingPoigneeEntity
					    {Bidding = bidding, Poignee = poignees[index], HandId = hId, PlayerId = pId});
				    
				    ++pId; ++index;
			    }
			    ++hId; ++biddingIndex;
		    }
	    }
	    
	    modelBuilder.Entity<BiddingPoigneeEntity>().HasData(bids);
    }
}