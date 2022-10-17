using TarotDB.enums;

namespace UT_TarotDB;

public static class HandEntityTestData
{
	public static IEnumerable<object?[]> Data_TestRead()
	{
		yield return new object?[]
		{
			1UL,
			1,
			"FrenchTarotRules",
			new DateTime(2022, 09, 21),
			210,
			false,
			true,
			PetitResultDB.Lost,
			ChelemDB.Unknown,
			1UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			new[]
			{
				(BiddingDB.Petite, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			11UL,
			2,
			"FrenchTarotRules",
			new DateTime(2022, 09, 21),
			365,
			false,
			true,
			PetitResultDB.AuBoutOwned,
			ChelemDB.Fail,
			4UL,
			new[]
			{
				(11UL, 4UL),
				(11UL, 5UL),
				(11UL, 6UL),
				(11UL, 7UL)
			},
			new[]
			{
				(BiddingDB.GardeContreLeChien, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.Simple),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			32UL,
			4,
			"FrenchTarotRules",
			new DateTime(2022, 09, 30),
			567,
			true,
			false,
			PetitResultDB.Lost,
			ChelemDB.Unknown,
			10UL,
			new[]
			{
				(32UL, 10UL),
				(32UL, 11UL),
				(32UL, 12UL),
				(32UL, 13UL),
				(32UL, 14UL)
			},
			new[]
			{
				(BiddingDB.GardeContreLeChien, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.King, PoigneeDB.None)
			}
		};
	}
	
	public static IEnumerable<object?[]> Data_TestAdd()
	{
		yield return new object?[]
		{
			true,
			0UL,
			4,
			"FrenchTarotRules",
			new DateTime(2022, 09, 26),
			456,
			true,
			true,
			PetitResultDB.AuBoutOwned,
			ChelemDB.AnnouncedSuccess,
			1UL,
			new[]
			{
				(BiddingDB.GardeContreLeChien, PoigneeDB.Triple),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			true,
			0UL,
			4,
			"FrenchTarotRules",
			new DateTime(2022, 09, 28),
			365,
			false,
			true,
			PetitResultDB.AuBoutOwned,
			ChelemDB.Fail,
			4UL,
			new[]
			{
				(BiddingDB.GardeSansLeChien, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.Simple),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			true,
			0UL,
			5,
			"FrenchTarotRules",
			new DateTime(2022, 09, 30),
			567,
			true,
			false,
			PetitResultDB.Lost,
			ChelemDB.Unknown,
			10UL,
			new[]
			{
				(BiddingDB.Garde, PoigneeDB.Double),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.King, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			false,
			1UL,
			1,
			"FrenchTarotRules",
			new DateTime(2022, 09, 21),
			210,
			false,
			true,
			PetitResultDB.Lost,
			ChelemDB.Unknown,
			1UL,
			new[]
			{
				(BiddingDB.Petite, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			false,
			1UL,
			4,
			"FrenchTarotRules",
			new DateTime(2022, 10, 21),
			540,
			null,
			null,
			PetitResultDB.LostAuBout,
			ChelemDB.Announced,
			4UL
		};
	}

	public static IEnumerable<object?[]> Data_TestUpdate()
	{
		yield return new object?[]
		{
			true,
			1UL,
			1UL,
			1,
			4,
			"FrenchTarotRules",
			"TestRules",
			new DateTime(2022, 09, 21),
			new DateTime(2022, 10, 22),
			210, 
			512,
			false,
			true,
			true,
			null,
			PetitResultDB.Lost,
			PetitResultDB.Owned,
			ChelemDB.Unknown,
			ChelemDB.Success,
			1UL,
			1UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			new[]
			{
				(BiddingDB.GardeContreLeChien, PoigneeDB.Triple),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
		yield return new object?[]
		{
			false,
			1UL,
			2UL,
			1,
			5,
			"FrenchTarotRules",
			"TestRules2",
			new DateTime(2022, 09, 21),
			new DateTime(2022, 10, 24),
			210, 
			350,
			false,
			null,
			true,
			null,
			PetitResultDB.Lost,
			PetitResultDB.NotOwned,
			ChelemDB.Unknown,
			ChelemDB.NotAnnouncedSuccess,
			1UL,
			1UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			Array.Empty<(BiddingDB, PoigneeDB)>()
		};
		yield return new object?[]
		{
			false,
			1UL,
			1UL,
			1,
			4,
			"FrenchTarotRules",
			"TestRules",
			new DateTime(2022, 09, 21),
			new DateTime(2022, 10, 22),
			210, 
			512,
			false,
			true,
			true,
			null,
			PetitResultDB.Lost,
			PetitResultDB.Owned,
			ChelemDB.Unknown,
			ChelemDB.Success,
			1UL,
			2UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			new[]
			{
				(BiddingDB.GardeContreLeChien, PoigneeDB.Triple),
				(BiddingDB.Opponent, PoigneeDB.None),
				(BiddingDB.Opponent, PoigneeDB.None)
			}
		};
	}
}