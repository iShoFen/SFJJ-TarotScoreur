using TarotDB.Enums;

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
			PetitResultsDb.Lost,
			ChelemDb.Unknown,
			1UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			new[]
			{
				(BiddingsDb.Petite, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
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
			PetitResultsDb.AuBoutOwned,
			ChelemDb.Fail,
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
				(BiddingsDb.GardeContreLeChien, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.Simple),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
			}
		};
		yield return new object?[]
		{
			32UL,
			4,
			"FrenchTarotRules",
			new DateTime(2022, 09, 23),
			567,
			true,
			false,
			PetitResultsDb.Lost,
			ChelemDb.Unknown,
			10UL,
			new[]
			{
				(32UL, 9UL),
				(32UL, 10UL),
				(32UL, 11UL),
				(32UL, 12UL),
				(32UL, 13UL)
			},
			new[]
			{
				(BiddingsDb.GardeContreLeChien, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.King, PoigneeDb.None)
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
			PetitResultsDb.AuBoutOwned,
			ChelemDb.AnnouncedSuccess,
			1UL,
			new[]
			{
				(BiddingsDb.GardeContreLeChien, PoigneeDb.Triple),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
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
			PetitResultsDb.AuBoutOwned,
			ChelemDb.Fail,
			4UL,
			new[]
			{
				(BiddingsDb.GardeSansLeChien, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.Simple),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
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
			PetitResultsDb.Lost,
			ChelemDb.Unknown,
			10UL,
			new[]
			{
				(BiddingsDb.Garde, PoigneeDb.Double),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.King, PoigneeDb.None)
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
			PetitResultsDb.Lost,
			ChelemDb.Unknown,
			1UL,
			new[]
			{
				(BiddingsDb.Petite, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
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
			PetitResultsDb.LostAuBout,
			ChelemDb.Announced,
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
			PetitResultsDb.Lost,
			PetitResultsDb.Owned,
			ChelemDb.Unknown,
			ChelemDb.Success,
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
				(BiddingsDb.GardeContreLeChien, PoigneeDb.Triple),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
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
			PetitResultsDb.Lost,
			PetitResultsDb.NotOwned,
			ChelemDb.Unknown,
			ChelemDb.NotAnnouncedSuccess,
			1UL,
			1UL,
			new[]
			{
				(1UL, 1UL),
				(1UL, 2UL),
				(1UL, 3UL)
			},
			Array.Empty<(BiddingsDb, PoigneeDb)>()
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
			PetitResultsDb.Lost,
			PetitResultsDb.Owned,
			ChelemDb.Unknown,
			ChelemDb.Success,
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
				(BiddingsDb.GardeContreLeChien, PoigneeDb.Triple),
				(BiddingsDb.Opponent, PoigneeDb.None),
				(BiddingsDb.Opponent, PoigneeDb.None)
			}
		};
	}
}