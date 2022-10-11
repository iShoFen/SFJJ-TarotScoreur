namespace UT_TarotDB;

public static class GameEntityTestData
{
	public static IEnumerable<object?[]> Data_TestRead()
	{
		yield return new object?[]
		{
			1UL,
			"Game1",
			"FrenchTarotRules",
			new DateTime(2022, 09, 21),
			null,
			new[]
			{
				1UL, 2UL, 3UL
			},
			new[]
			{
				1UL, 2UL, 3UL
			}
		};
		// Id = hId, Number = i, Rules = "FrenchTarotRules", Date = dates[index], TakerScore = scores[index],
		// TwentyOne = twentys[index], Excuse = excuses[index], Petit = petits[index], Chelem = chelems[index],
		// GameId = gId
		// new(2022, 09, 21), new(2022, 09, 22), new(2022, 09, 23),
		//  210, 256, 151,
		//  false, true, false
		// true, true, false
		//  PetitResultDB.Lost, PetitResultDB.Lost, PetitResultDB.Lost
		//  ChelemDB.Unknown, ChelemDB.Announced, ChelemDB.Success
	}
}