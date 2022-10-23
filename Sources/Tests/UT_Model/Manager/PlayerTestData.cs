using Model.Players;
using static TestUtils.DataManagers;

namespace UT_Model.Manager;
internal static class PlayerTestData
{

	public static IEnumerable<object[]> Data_TestPlayersByLastName()
	{
		foreach (var loader in Loaders)
		{
			yield return new object[]
			{
				loader,
				"BON",
				new Player[]
				{
					new("Jean", "BON", "JEBO", "avatar1")
				},
				1,
				10
			};
			yield return new object[]
			{
				loader,
				"PETIT",
				new Player[]
				{
					new("Julien", "PETIT", "THEGIANT", "avatar6"),
					new("Anne", "PETIT", "FRIPOUILLES", "avatar13")
				},
				1,
				10
			};
			yield return new object[]
			{
				loader,
				"GOL",
				Array.Empty<Player>(),
				0,
				10
			};
			yield return new object[]
			{
				loader,
				"TABLETTE",
				Array.Empty<Player>(),
				1,
				0
			};
			yield return new object[]
			{
				loader,
				"LE CHANTEUR",
				Array.Empty<Player>(),
				0,
				0
			};
			yield return new object[]
			{
				loader,
				"",
				Array.Empty<Player>(),
				1,
				10
			};
		}
	}

	public static IEnumerable<object[]> Data_TestPlayersByFirstName()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    "Jean",
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1"),
				    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new("Jean", "MOYEN", "KIKOU7", "avatar3")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Simon",
			    new Player[]
			    {
				    new("Simon", "SEBAT", "SEBATA", "avatar7")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Samuel",
			    Array.Empty<Player>(),
			    0,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Marine",
			    Array.Empty<Player>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "Alizee",
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestPlayersByNickname()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    "JEBO",
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "THEGIANT",
			    new Player[]
			    {
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "JEMAA",
			    Array.Empty<Player>(),
			    0,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "KIKOU7",
			    Array.Empty<Player>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "LOLO",
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
	    }
    }

    public static IEnumerable<object?[]> Data_TestAllPlayers()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object?[]
		    {
			    loader,
			    1,
			    10,
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1"),
				    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new("Albert", "GOL", "LOLA", "avatar5"),
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
				    new("Simon", "SEBAT", "SEBATA", "avatar7"),
				    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
				    new("Samuel", "LE CHANTEUR", "LOL", "avatar9"),
				    new("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10")
			    }
		    };
		    yield return new object?[]
		    {
			    loader,
			    2,
			    10,
			    new[]
			    {
				    new Player("Jeanne", "LERICHE", "JEMAA", "avatar11"),
				    new Player("Jules", "INFANTE", "KIKOU77", "avatar12"),
				    new Player("Anne", "PETIT", "FRIPOUILLES", "avatar13"),
				    new Player("Marine", "TABLETTE", "LOLO", "avatar14"),
				    new Player("Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"),
				    new Player("Alizee", "SEBAT", "SEBAT", "avatar16")
			    }
		    };
		    yield return new object?[]
		    {
			    loader,
			    2,
			    4,
			    new Player[]
			    {
				    new("Albert", "GOL", "LOLA", "avatar5"),
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
				    new("Simon", "SEBAT", "SEBATA", "avatar7"),
				    new("Jordan", "LEG", "BIGBRAIN", "avatar8"),
			    }
		    };
		    yield return new object?[]
		    {
			    loader,
			    1,
			    4,
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1"),
				    new("Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new("Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new("Michel", "BELIN", "FRIPOUILLE", "avatar4"),
			    }
		    };
		    yield return new object?[]
		    {
			    loader,
			    0,
			    10,
			    Array.Empty<Player>()
		    };
		    yield return new object?[]
		    {
			    loader,
			    0,
			    0,
			    Array.Empty<Player>()
		    };
		    yield return new object?[]
		    {
			    loader,
			    2,
			    0,
			    Array.Empty<Player>()
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestPlayersByFirstNameAndLastName()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    "Jean",
			    "BON",
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Julien",
			    "PETIT",
			    new Player[]
			    {
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Jeanne",
			    "LERICHE",
			    Array.Empty<Player>(),
			    0,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Eliaz",
			    "DU JARDIN",
			    Array.Empty<Player>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "Simon",
			    "SEBAT",
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "",
			    "SEBAT",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Alizee",
			    "",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestPlayerByFirstNameAndNickname()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    "Jean",
			    "JEBO",
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Julien",
			    "THEGIANT",
			    new Player[]
			    {
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Jeanne",
			    "JEMAA",
			    Array.Empty<Player>(),
			    0,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Eliaz",
			    "THEGIANTE",
			    Array.Empty<Player>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "Simon",
			    "SEBATA",
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "",
			    "SEBAT",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "Alizee",
			    "",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestPlayerByLastNameAndNickname()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    "BON",
			    "JEBO",
			    new Player[]
			    {
				    new("Jean", "BON", "JEBO", "avatar1")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "PETIT",
			    "THEGIANT",
			    new Player[]
			    {
				    new("Julien", "PETIT", "THEGIANT", "avatar6"),
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "LERICHE",
			    "JEMAA",
			    Array.Empty<Player>(),
			    0,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "DU JARDIN",
			    "THEGIANTE",
			    Array.Empty<Player>(),
			    1,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "SEBAT",
			    "SEBATA",
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    "",
			    "SEBAT",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    "SEBAT",
			    "",
			    Array.Empty<Player>(),
			    1,
			    10
		    };
	    }
    }

    public static IEnumerable<object[]> Data_TestPlayersByGroup()
    {
	    foreach (var loader in Loaders)
	    {
		    yield return new object[]
		    {
			    loader,
			    new Group(1UL, "Group 1",
				    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    ),
			    new Player[]
			    {
				    new(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new(4UL,"Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    },
			    1,
			    10
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(1UL, "Group 1",
				    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    ),
			    new Player[]
			    {
				    new(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4")
			    },
			    1,
			    4
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(1UL, "Group 1",
				    new Player(1UL, "Jean", "BON", "JEBO", "avatar1"),
				    new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"),
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    ),
			    new Player[]
			    {
				    new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new(5UL, "Albert", "GOL", "LOLA", "avatar5")
			    },
			    2,
			    3
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(3UL, "Group 3",
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    ),
			    new Player[]
			    {
				    new(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    },
			    1,
			    5
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(3UL, "Group 3",
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    ),
			    new Player[]
			    {
				    new(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    },
			    2,
			    4
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(3UL, "Group 3",
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    ),
			    Array.Empty<Player>(),
			    0,
			    1
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(3UL, "Group 3",
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    ),
			    Array.Empty<Player>(),
			    0,
			    0
		    };
		    yield return new object[]
		    {
			    loader,
			    new Group(3UL, "Group 3",
				    new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"),
				    new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"),
				    new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"),
				    new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"),
				    new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7")
			    ),
			    Array.Empty<Player>(),
			    1,
			    0
		    };
	    }
    }
}