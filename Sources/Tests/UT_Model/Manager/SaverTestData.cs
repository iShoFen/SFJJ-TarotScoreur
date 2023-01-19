using Model.Rules;
using Model.Games;
using Model.Players;
using TarotDB;
using static TestUtils.DataManagers;

namespace UT_Model.Manager;

public class SaverTestData

{
	public static IEnumerable<object?[]> Data_TestSavePlayer()
	{
		foreach (var saver in Writers)
		{

			yield return new object?[]
			{
				saver.Get(),
				new Player("Pedro", "Machin", "Pema", "avatar28"),
				new Player(17UL, "Pedro", "Machin", "Pema", "avatar28"),
				new PlayerEntity
				{
					Id = 17UL,
					FirstName = "Pedro",
					LastName = "Machin",
					Nickname = "Pema",
					Avatar = "avatar28"
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
				null,
				new PlayerEntity
				{
					Id = 13UL,
					FirstName = "Anne",
					LastName = "PETIT",
					Nickname = "FRIPOUILLES",
					Avatar = "avatar13"
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Player(17UL, "Pedro", "Machin", "Pema", "avatar28"),
				null,
				null
			};
		}
	}
	
	public static IEnumerable<object?[]> Data_TestSaveGroup()
	{
		foreach (var saver in Writers)
		{

			yield return new object?[]
			{
				saver.Get(),
				new Group("Group 13"),
				new Group(13UL, "Group 13"),
				new GroupEntity
				{
					Id = 13UL,
					Name = "Group 13"
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Group(12UL, "Group 12"),
				null,
				new GroupEntity
				{
					Id = 12UL,
					Name = "Group 12"
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Group(13UL, "Group 13"),
				null,
				null
			};
		}
	}
	
	public static IEnumerable<object?[]> Data_TestSaveGame()
	{
		foreach (var saver in Writers)
		{
			yield return new object?[]
			{
				saver.Get(),
				new Game("Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23)),
				new Game(11UL, "Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23), null),
				new GameEntity
				{
					Id = 11UL,
					Name = "Game 11",
					Rules = "FrenchTarotRules",
					StartDate = new DateTime(2022, 09, 23),
					EndDate = null
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Game(10UL, "Game 10", new FrenchTarotRules(), new DateTime(2022, 09, 18), 
					new DateTime(2022, 09, 23)),
				null,
				new GameEntity
				{
					Id = 10UL,
					Name = "Game 10",
					Rules = "FrenchTarotRules",
					StartDate = new DateTime(2022, 09, 18),
					EndDate = new DateTime(2022, 09, 23)
				}
			};
			yield return new object?[]
			{
				saver.Get(),
				new Game(11UL,"Game 11", new FrenchTarotRules(), new DateTime(2022, 09, 23), null),
				null,
				null
			};
		}
	} 
}