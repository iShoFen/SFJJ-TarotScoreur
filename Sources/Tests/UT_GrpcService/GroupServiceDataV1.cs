using GrpcService;

namespace UT_GrpcService;

public static class GroupServiceDataV1
{
    public static IEnumerable<object[]> Data_TestGroupsByName()
	{
        yield return new object[]
		{
			"Group 1",
			1,
			1,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    }
                }
            }
        };

		yield return new object[]
		{
			"Group",
			2,
			2,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 3UL,
                        Name = "Group 3",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 4UL,
                        Name = "Group 4",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            }
                        }
                    }
                }
            }
        };

        yield return new object[]
        {
            "1",
            1,
            10,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 10UL,
                        Name = "Group 10",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 11UL,
                        Name = "Group 11",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            },
                            new UserReply
                            {
                                Id = 15UL,
                                FirstName = "Eliaz",
                                LastName = "DU JARDIN",
                                Nickname = "THEGIANTE",
                                Avatar = "avatar15"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 12UL,
                        Name = "Group 12",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            },
                            new UserReply
                            {
                                Id = 15UL,
                                FirstName = "Eliaz",
                                LastName = "DU JARDIN",
                                Nickname = "THEGIANTE",
                                Avatar = "avatar15"
                            },
                            new UserReply
                            {
                                Id = 16UL,
                                FirstName = "Alizee",
                                LastName = "SEBAT",
                                Nickname = "SEBAT",
                                Avatar = "avatar16"
                            }
                        }
                    }
                }
            }
        };

		yield return new object[]
		{
            "",
			1,
			2,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 2UL,
                        Name = "Group 2",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            }
                        }
                    }
                }
            }
        };

		yield return new object[]
		{
            "Group",
			int.MinValue,
			int.MinValue,
			new GroupsReply()
		};

		yield return new object[]
		{
            "Group",
			-1,
			-1,
			new GroupsReply()
		};

		yield return new object[]
		{
            "Group",
			0,
			0,
            new GroupsReply()
        };
    }
    
    public static IEnumerable<object[]> Data_TestGetGroupsByUser()
    {
        yield return new object[]
		{
			2UL,
			1,
			10,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 2UL,
                        Name = "Group 2",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            }
                        }
                    }
                }
            }
        };
		
		yield return new object[]
		{
			5UL,
			1,
			10,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 2UL,
                        Name = "Group 2",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 3UL,
                        Name = "Group 3",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 4UL,
                        Name = "Group 4",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 5UL,
                        Name = "Group 5",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            }
                        }
                    }
                }
            }
        };
		yield return new object[]
		{
			5UL,
			2,
			2,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 3UL,
                        Name = "Group 3",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 4UL,
                        Name = "Group 4",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            }
                        }
                    }
                }
            }
        };
		
		yield return new object[]
		{
			950UL,
			1,
			10,
			new GroupsReply()
		};
		
		yield return new object[]
		{
			2UL,
			0,
			0,
			new GroupsReply()
		};
		
		yield return new object[]
		{
			2UL,
			-1,
			-1,
			new GroupsReply()
		};
		
		yield return new object[]
		{
			2UL,
			int.MinValue,
			int.MinValue,
			new GroupsReply()
		};
    }
    
    public static IEnumerable<object[]> Data_TestLoadAllGroups()
    {
        yield return new object[]
		{
            1,
			12,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 1UL,
                        Name = "Group 1",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 1UL,
                                FirstName = "Jean",
                                LastName = "BON",
                                Nickname = "JEBO",
                                Avatar = "avatar1"
                            },
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 2UL,
                        Name = "Group 2",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 2UL,
                                FirstName = "Jean",
                                LastName = "MAUVAIS",
                                Nickname = "JEMA",
                                Avatar = "avatar2"
                            },
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 3UL,
                        Name = "Group 3",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 3UL,
                                FirstName = "Jean",
                                LastName = "MOYEN",
                                Nickname = "KIKOU7",
                                Avatar = "avatar3"
                            },
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 4UL,
                        Name = "Group 4",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 4UL,
                                FirstName = "Michel",
                                LastName = "BELIN",
                                Nickname = "FRIPOUILLE",
                                Avatar = "avatar4"
                            },
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 5UL,
                        Name = "Group 5",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 5UL,
                                FirstName = "Albert",
                                LastName = "GOL",
                                Nickname = "LOLA",
                                Avatar = "avatar5"
                            },
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 6UL,
                        Name = "Group 6",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 7UL,
                        Name = "Group 7",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 8UL,
                        Name = "Group 8",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 9UL,
                        Name = "Group 9",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 10UL,
                        Name = "Group 10",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 11UL,
                        Name = "Group 11",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            },
                            new UserReply
                            {
                                Id = 15UL,
                                FirstName = "Eliaz",
                                LastName = "DU JARDIN",
                                Nickname = "THEGIANTE",
                                Avatar = "avatar15"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 12UL,
                        Name = "Group 12",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            },
                            new UserReply
                            {
                                Id = 15UL,
                                FirstName = "Eliaz",
                                LastName = "DU JARDIN",
                                Nickname = "THEGIANTE",
                                Avatar = "avatar15"
                            },
                            new UserReply
                            {
                                Id = 16UL,
                                FirstName = "Alizee",
                                LastName = "SEBAT",
                                Nickname = "SEBAT",
                                Avatar = "avatar16"
                            }
                        }
                    }
                }
            }
        };
		
		yield return new object[]
		{
            2,
			5,
			new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 6UL,
                        Name = "Group 6",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 7UL,
                        Name = "Group 7",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 8UL,
                        Name = "Group 8",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 9UL,
                        Name = "Group 9",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            }
                        }
                    },
                    new GroupReply
                    {
                        Id = 10UL,
                        Name = "Group 10",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            },
                            new UserReply
                            {
                                Id = 11UL,
                                FirstName = "Jeanne",
                                LastName = "LERICHE",
                                Nickname = "JEMAA",
                                Avatar = "avatar11"
                            },
                            new UserReply
                            {
                                Id = 12UL,
                                FirstName = "Jules",
                                LastName = "INFANTE",
                                Nickname = "KIKOU77",
                                Avatar = "avatar12"
                            },
                            new UserReply
                            {
                                Id = 13UL,
                                FirstName = "Anne",
                                LastName = "PETIT",
                                Nickname = "FRIPOUILLES",
                                Avatar = "avatar13"
                            },
                            new UserReply
                            {
                                Id = 14UL,
                                FirstName = "Marine",
                                LastName = "TABLETTE",
                                Nickname = "LOLO",
                                Avatar = "avatar14"
                            }
                        }
                    }
                }
            }
		};
		
		yield return new object[]
		{
            6,
			1,
            new GroupsReply
            {
                Groups =
                {
                    new GroupReply
                    {
                        Id = 6UL,
                        Name = "Group 6",
                        Users =
                        {
                            new UserReply
                            {
                                Id = 6UL,
                                FirstName = "Julien",
                                LastName = "PETIT",
                                Nickname = "THEGIANT",
                                Avatar = "avatar6"
                            },
                            new UserReply
                            {
                                Id = 7UL,
                                FirstName = "Simon",
                                LastName = "SEBAT",
                                Nickname = "SEBATA",
                                Avatar = "avatar7"
                            },
                            new UserReply
                            {
                                Id = 8UL,
                                FirstName = "Jordan",
                                LastName = "LEG",
                                Nickname = "BIGBRAIN",
                                Avatar = "avatar8"
                            },
                            new UserReply
                            {
                                Id = 9UL,
                                FirstName = "Samuel",
                                LastName = "LE CHANTEUR",
                                Nickname = "LOL",
                                Avatar = "avatar9"
                            },
                            new UserReply
                            {
                                Id = 10UL,
                                FirstName = "Brigitte",
                                LastName = "PUECH",
                                Nickname = "XXFRIPOUILLEXX",
                                Avatar = "avatar10"
                            }
                        }
                    }
                }
            }
        };
		
		yield return new object[]
		{
            0,
			0,
			new GroupsReply()
		};

		yield return new object[]
		{
            -1,
			-1,
			new GroupsReply()
		};
		
		yield return new object[]
		{
            int.MinValue,
			int.MinValue,
			new GroupsReply()
		};
    }
    
    public static IEnumerable<object?[]> Data_TestGetGroupById()
    {
        yield return new object?[]
        {
            1UL,
            new GroupReply
            {
                Id = 1UL,
                Name = "Group 1",
                Users =
                {
                    new UserReply
                    {
                        Id = 1UL,
                        FirstName = "Jean",
                        LastName = "BON",
                        Nickname = "JEBO",
                        Avatar = "avatar1"
                    },
                    new UserReply
                    {
                        Id = 2UL,
                        FirstName = "Jean",
                        LastName = "MAUVAIS",
                        Nickname = "JEMA",
                        Avatar = "avatar2"
                    },
                    new UserReply
                    {
                        Id = 3UL,
                        FirstName = "Jean",
                        LastName = "MOYEN",
                        Nickname = "KIKOU7",
                        Avatar = "avatar3"
                    },
                    new UserReply
                    {
                        Id = 4UL,
                        FirstName = "Michel",
                        LastName = "BELIN",
                        Nickname = "FRIPOUILLE",
                        Avatar = "avatar4"
                    },
                    new UserReply
                    {
                        Id = 5UL,
                        FirstName = "Albert",
                        LastName = "GOL",
                        Nickname = "LOLA",
                        Avatar = "avatar5"
                    }
                }
            }
        };
		
        yield return new object?[]
        {
            2UL,
            new GroupReply
            {
                Id = 2UL,
                Name = "Group 2",
                Users =
                {
                    new UserReply
                    {
                        Id = 2UL,
                        FirstName = "Jean",
                        LastName = "MAUVAIS",
                        Nickname = "JEMA",
                        Avatar = "avatar2"
                    },
                    new UserReply
                    {
                        Id = 3UL,
                        FirstName = "Jean",
                        LastName = "MOYEN",
                        Nickname = "KIKOU7",
                        Avatar = "avatar3"
                    },
                    new UserReply
                    {
                        Id = 4UL,
                        FirstName = "Michel",
                        LastName = "BELIN",
                        Nickname = "FRIPOUILLE",
                        Avatar = "avatar4"
                    },
                    new UserReply
                    {
                        Id = 5UL,
                        FirstName = "Albert",
                        LastName = "GOL",
                        Nickname = "LOLA",
                        Avatar = "avatar5"
                    },
                    new UserReply
                    {
                        Id = 6UL,
                        FirstName = "Julien",
                        LastName = "PETIT",
                        Nickname = "THEGIANT",
                        Avatar = "avatar6"
                    }
                }
            }
        };
		
        yield return new object?[]
        {
            0UL,
            null
        };
		
        yield return new object?[]
        {
            ulong.MaxValue,
            null
        };
    }
    
    public static IEnumerable<object?[]> InsertGroupData()
    {
        yield return new object?[]
        {
            new GroupInsertRequest
            {
                Name = "Group 13",
                Users =
                {
                    16UL
                }
            },
            new GroupReply
            {
                Id = 13UL,
                Name = "Group 13",
                Users =
                {
                    new UserReply
                    {
                        Id = 16UL,
                        FirstName = "Alizee",
                        LastName = "SEBAT",
                        Nickname = "SEBAT",
                        Avatar = "avatar16"
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GroupInsertRequest
            {
                Name = "Group 13"
            },
            new GroupReply
            {
                Id = 13UL,
                Name = "Group 13",
            },
            -1
        };

        yield return new object?[]
        {
            new GroupInsertRequest
            {
                Name = "Group 13",
                Users =
                {
                    15UL,
                    2UL,
                    16UL
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new GroupInsertRequest
            {
                Name = "Group 13",
                Users =
                {
                    25UL
                }
            },
            null,
            0
        };
    }
    
    public static IEnumerable<object?[]> UpdateGroupData()
    {
        yield return new object?[]
        {
            new GroupUpdateRequest
            {
                Id = 5UL,
                Name = "Group 13",
                Users =
                {
                    16UL
                }
            },
            new GroupReply
            {
                Id = 5UL,
                Name = "Group 13",
                Users =
                {
                    new UserReply
                    {
                        Id = 16UL,
                        FirstName = "Alizee",
                        LastName = "SEBAT",
                        Nickname = "SEBAT",
                        Avatar = "avatar16"
                    }
                }
            },
            -1
        };
        yield return new object?[]
        {
            new GroupUpdateRequest
            {
                Id = 4UL,
                Name = "Group 13"
            },
            new GroupReply
            {
                Id = 4UL,
                Name = "Group 13"
            },
            -1
        };
        yield return new object?[]
        {
            new GroupUpdateRequest
            {
                Id = 4UL,
                Name = "Group 13",
                Users =
                {
                    15UL,
                    2UL,
                    16UL
                }
            },
            null,
            1
        };
        yield return new object?[]
        {
            new GroupUpdateRequest
            {
                Id = 20UL,
                Name = "Group 13",
            },
            null,
            -1
        };
    }
    
    public static IEnumerable<object?[]> DeleteGroupData()
    {
        yield return new object?[]
        {
            3UL,
            true
        };
        yield return new object?[]
        {
            12UL,
            true
        };
        yield return new object?[]
        {
            0UL,
            false
        };
        yield return new object?[]
        {
            100UL,
            false
        };
    }
}
