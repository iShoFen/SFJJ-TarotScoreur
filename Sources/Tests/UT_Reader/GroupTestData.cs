using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Reader;

public static class GroupTestData
{
	
	public static IEnumerable<object[]> Data_TestGroupsByName()
	{
		foreach (var loader in Loaders)
		{
			yield return new object[]
			{
				loader.Get(),
				"Group 1",
				1,
				1,
				new Group[]
				{
					new(1UL, "Group 1",
						new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
						new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
						new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"))
				}
			};

			yield return new object[]
			{
				loader.Get(),
				"Group",
				2,
				2,
				new Group[]
				{
					new(3UL, "Group 3",
						new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
						new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
						new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")),
					new(4UL, "Group 4",
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
						new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
						new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
						new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"))
				}
			};

			yield return new object[]
			{
				loader.Get(),
				"1",
				1,
				10,
				new Group[]
				{
					new(1UL, "Group 1",
						new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
						new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
						new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")),
					new(10UL, "Group 10",
						new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
						new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
						new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
						new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
						new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14")),
					new(11UL, "Group 11",
						new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
						new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
						new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
						new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"),
						new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15")),
					new(12UL, "Group 12",
						new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
						new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
						new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"),
						new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"),
                        new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16"))
				}
			};

			yield return new object[]
			{
				loader.Get(),
				"",
				1,
				2,
				new Group[]
				{
					new(1UL, "Group 1",
						new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
						new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
						new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")),
					new(2UL, "Group 2",
						new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
						new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
						new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
						new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
						new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"))
				}
			};

			yield return new object[]
			{
				loader.Get(),
				"Group",
				int.MinValue,
				int.MinValue,
				Array.Empty<Group>()
			};

			yield return new object[]
			{
				loader.Get(),
				"Group",
				-1,
				-1,
				Array.Empty<Group>()
			};

			yield return new object[]
			{
				loader.Get(),
				"Group",
				0,
				0,
				Array.Empty<Group>()

			};
		}
	}
	
	public static IEnumerable<object[]> Data_TestGetGroupsByPlayer()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader.Get(), 
			    2UL,
			    1,
			    10,
			    new Group[]
			    {
				    new(1UL, "Group 1",
					    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
					    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
				    ),
				    new(2UL, "Group 2",
					    new Player(2UL,"Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
				    )
			    }
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    5UL,
			    1,
			    10,
			    new Group[]
			    {
				    new(1UL, "Group 1",
					    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
					    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
				    ),
				    new(2UL, "Group 2",
					    new Player(2UL,"Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
				    ),
				    new(3UL, "Group 3",
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
				    ),
				    new(4UL, "Group 4",
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8")
				    ),
				    new(5UL, "Group 5",
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9")
				    )
			    }
		    };
		    yield return new object[]
		    {
			    loader.Get(),
			    5UL,
			    2,
			    2,
			    new Group[]
			    {
				    new(3UL, "Group 3",
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
				    ),
				    new(4UL, "Group 4",
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8")
				    )
			    }
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    950UL,
			    1,
			    10,
			    Array.Empty<Group>()
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    2UL,
			    0,
			    0,
			    Array.Empty<Group>()
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    2UL,
			    -1,
			    -1,
			    Array.Empty<Group>()
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    2UL,
			    int.MinValue,
			    int.MinValue,
			    Array.Empty<Group>()
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestLoadAllGroups()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader.Get(),
			    1,
			    12,
			    new Group[]
			    {
				    new(1UL, "Group 1",
					    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
					    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
				    ),
				    new(2UL, "Group 2",
					    new Player(2UL,"Jean", "MAUVAIS", "JEMA", "avatar2"),
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
				    ),
				    new(3UL, "Group 3",
					    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
				    ),
				    new(4UL, "Group 4",
					    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8")
				    ),
				    new(5UL, "Group 5",
					    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9")
				    ),
				    new(6UL, "Group 6",
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
				    ),
				    new(7UL, "Group 7",
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11")
				    ),
				    new(8UL, "Group 8",
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
				    ),
				    new(9UL, "Group 9",
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL,"Anne", "PETIT", "FRIPOUILLES", "avatar13")
				    ),
				    new(10UL, "Group 10",
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
					    new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14")
				    ),
				    new(11UL, "Group 11",
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
					    new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"),
					    new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15")
				    ),
				    new(12UL, "Group 12",
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
					    new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"),
					    new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"), 
					    new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16")
				    )
			    }
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    2,
			    5,
			    new Group[]
			    {
				    new(6UL, "Group 6",
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
				    ),
				    new(7UL, "Group 7",
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11")
				    ),
				    new(8UL, "Group 8",
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12")
				    ),
				    new(9UL, "Group 9",
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL,"Anne", "PETIT", "FRIPOUILLES", "avatar13")
				    ),
				    new(10UL, "Group 10",
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"),
					    new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"),
					    new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"),
					    new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"),
					    new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14")
				    )
			    }
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    6,
			    1,
			    new Group[]
			    {
				    new(6UL, "Group 6",
					    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
					    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"),
					    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
					    new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"),
					    new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
				    )
			    }
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    0,
			    0,
			    Array.Empty<Group>()
		    };

		    yield return new object[]
		    {
			    loader.Get(),
			    -1,
			    -1,
			    Array.Empty<Group>()
		    };
		    
		    yield return new object[]
		    {
			    loader.Get(),
			    int.MinValue,
			    int.MinValue,
			    Array.Empty<Group>()
		    };
	    }
    }

    public static IEnumerable<object?[]> Data_TestGetGroupById()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object?[]
		    {
			    loader.Get(),
			    1UL,
			    new Group(1UL, "Group 1",
				    new Player(1UL, "Julien", "PETIT", "THEGIANT", "avatar1"),
				    new Player(2UL, "Simon", "SEBAT", "SEBATA", "avatar2"),
				    new Player(3UL, "Jordan", "LEG", "BIGBRAIN", "avatar3"),
				    new Player(4UL, "Samuel", "LE CHANTEUR", "LOL", "avatar4"),
				    new Player(5UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar5")
			    )
		    };
		    
		    yield return new object?[]
		    {
			    loader.Get(),
			    2UL,
			    new Group(2UL, "Group 2",
				    new Player(2UL, "Simon", "SEBAT", "SEBATA", "avatar2"),
				    new Player(3UL, "Jordan", "LEG", "BIGBRAIN", "avatar3"),
				    new Player(4UL, "Samuel", "LE CHANTEUR", "LOL", "avatar4"),
				    new Player(5UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
			    )
		    };
		    
		    yield return new object?[]
		    {
			    loader.Get(),
			    0UL,
			    null
		    };
		    
		    yield return new object?[]
		    {
			    loader.Get(),
			    ulong.MaxValue,
			    null
		    };
	    }
    }
}