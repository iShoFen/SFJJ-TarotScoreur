using Model;
using static TestUtils.DataManagers;

namespace UT_Loader;

public static class GroupTestData
{
    public static IEnumerable<object?[]> Data_TestGroupsByName()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object?[]
		    {
			    loader,
			    "Group 1",
			    new Group(1UL, "Group 1",
				    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    )
		    };
		    yield return new object?[]
		    {
			    loader,
			    "Group 2",
			    new Group(2UL, "Group 2",
				    new Player(2UL,"Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6")
			    )
		    };
		    yield return new object?[]
		    {
			    loader,
			    "Group2",
			    null
		    };
		    yield return new object?[]
		    {
			    loader,
			    "",
			    null
		    };
	    }
    }

    public static IEnumerable<object?[]> Data_TestLoadGroupsByPlayer()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object?[]
		    {
			    loader,
			    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
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
			    },
			    1,
			    10
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
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
			    },
			    1,
			    10
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
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
				    ),
			    },
			    2,
			    2
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
			    new Group[]
			    {
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
				    )
			    },
			    1,
			    4
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(18UL, "Jordane", "LEG", "BIGBRAIN", "avatar8"),
			    Array.Empty<Group>(),
			    1,
			    10
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
			    Array.Empty<Group>(),
			    1,
			    0
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
			    Array.Empty<Group>(),
			    0,
			    0
		    };
		    yield return new object?[]
		    {
			    loader,
			    new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"),
			    Array.Empty<Group>(),
			    0,
			    1
		    };
	    }
    }

    public static IEnumerable<object?[]> Data_TestLoadAllGroups()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object?[]
		    {
			    loader,
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
			    },
			    1,
			    12
		    };
		    yield return new object?[]
		    {
			    loader,
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
				    )
			    },
			    1,
			    10
		    };
		    yield return new object?[]
		    {
			    loader,
			    Array.Empty<Group>(),
			    1,
			    0
		    };
		    yield return new object?[]
		    {
			    loader,
			    Array.Empty<Group>(),
			    0,
			    0
		    };
		    yield return new object?[]
		    {
			    loader,
			    Array.Empty<Group>(),
			    0,
			    1
		    };
	    }
    }
}