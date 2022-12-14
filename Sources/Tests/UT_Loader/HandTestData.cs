using Model.Rules;
using Model.Enums;
using Model.Games;
using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Loader;

public static class HandTestData
{
    public static IEnumerable<object[]> Data_TestLoadHandByGame()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
			    new List<KeyValuePair<int, Hand>>
			    {
				    new(1, new Hand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
					    false, true, PetitResults.Lost, Chelem.Unknown,
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
						    (Biddings.Garde, Poignee.Simple)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(
						    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
						    (Biddings.Opponent, Poignee.None)))),

				    new(2, new Hand(2UL, 2, new FrenchTarotRules(), new DateTime(2022, 09, 22), 256,
					    true, true, PetitResults.Lost, Chelem.AnnouncedSuccess,
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
						    (Biddings.Petite, Poignee.Simple)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(
						    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
						    (Biddings.Opponent, Poignee.None)))),
				    new(3, new Hand(3UL, 3, new FrenchTarotRules(), new DateTime(2022, 09, 23), 151,
					    false, false, PetitResults.Lost, Chelem.Success,
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
						    (Biddings.Garde, Poignee.Simple)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(
						    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
						    (Biddings.Opponent, Poignee.None))))
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
			    new List<KeyValuePair<int, Hand>>(),
			    0,
			    1
		    };
		    yield return new object[]
		    {
			    loader,
			    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
			    new List<KeyValuePair<int, Hand>>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
			    new List<KeyValuePair<int, Hand>>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    new Game(1UL, "Game 1", new FrenchTarotRules(), new DateTime(2022, 09, 01), null),
			    new List<KeyValuePair<int, Hand>>
			    {
				    new(1, new Hand(1UL, 1, new FrenchTarotRules(), new DateTime(2022, 09, 21), 210,
					    false, true, PetitResults.Lost, Chelem.Unknown,
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
						    (Biddings.Garde, Poignee.Simple)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(
						    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
						    (Biddings.Opponent, Poignee.None)))),

				    new(2, new Hand(2UL, 2, new FrenchTarotRules(), new DateTime(2022, 09, 22), 256,
					    true, true, PetitResults.Lost, Chelem.AnnouncedSuccess,
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "BON", "JEBO", "avatar1"),
						    (Biddings.Petite, Poignee.Simple)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(
						    new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						    (Biddings.Opponent, Poignee.None)),
					    new KeyValuePair<Player, (Biddings, Poignee)>(new Player("Albert", "GOL", "LOLA", "avatar1"),
						    (Biddings.Opponent, Poignee.None))))
			    },
			    1,
			    2
		    };
	    }
    }
}