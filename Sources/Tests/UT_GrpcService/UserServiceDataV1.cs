using GrpcService;

namespace UT_GrpcService;

public static class UserServiceDataV1
{
    public static IEnumerable<object?[]> Data_TestAllUsers()
    {
        yield return new object?[]
        {
            1,
            10,
            new UsersReply
            {
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
        };

        yield return new object?[]
        {
            2, 10, new UsersReply()
        };

        yield return new object?[]
        {
            1,
            4,
            new UsersReply
            {
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
                    }
                }
            }
        };

        yield return new object?[]
        {
            0, 10, new UsersReply()
        };

        yield return new object?[]
        {
            0, 0, new UsersReply()
        };

        yield return new object?[]
        {
            2, 0, new UsersReply()
        };
    }

    public static IEnumerable<object?[]> Data_TestUserById()
    {
        yield return new object?[]
        {
            11UL,
            new UserReply
            {
                Id = 11UL,
                FirstName = "Jeanne",
                LastName = "LERICHE",
                Nickname = "JEMAA",
                Avatar = "avatar11"
            }
        };

        yield return new object?[]
        {
            0UL, null
        };

        yield return new object?[]
        {
            6UL, null
        };

        yield return new object?[]
        {
            55UL, null
        };
    }

    public static IEnumerable<object[]> Data_TestUsersByPattern()
    {
        yield return new object[]
        {
            "AN",
            1,
            10,
            new UsersReply
            {
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
                        Id = 15UL,
                        FirstName = "Eliaz",
                        LastName = "DU JARDIN",
                        Nickname = "THEGIANTE",
                        Avatar = "avatar15"
                    }
                }
            }
        };

        yield return new object[]
        {
            "Toto", 1, 10, new UsersReply()
        };

        yield return new object[]
        {
            "Toto", 2, 10, new UsersReply()
        };

        yield return new object[]
        {
            "AN", 2, 10, new UsersReply()
        };

        yield return new object[]
        {
            "",
            1,
            10,
            new UsersReply
            {
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
        };

        yield return new object[]
        {
            "M",
            1,
            10,
            new UsersReply
            {
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
                        Id = 14UL,
                        FirstName = "Marine",
                        LastName = "TABLETTE",
                        Nickname = "LOLO",
                        Avatar = "avatar14"
                    }
                }
            }
        };

        yield return new object[]
        {
            "Jea", 0, 10, new UsersReply()
        };

        yield return new object[]
        {
            "Jea", 2, 0, new UsersReply()
        };

        yield return new object[]
        {
            "Jea", 0, 0, new UsersReply()
        };
    }

    public static IEnumerable<object[]> Data_TestUsersByNickname()
    {
        yield return new object[]
        {
            "JEBO", 1, 10, new UsersReply()
        };

        yield return new object[]
        {
            "THEGIANT",
            1,
            10,
            new UsersReply
            {
                Users =
                {
                    new UserReply
                    {
                        Id = 15UL,
                        FirstName = "Eliaz",
                        LastName = "DU JARDIN",
                        Nickname = "THEGIANTE",
                        Avatar = "avatar15"
                    }
                }
            }

        };

        yield return new object[]
        {
            "TOTO", 1, 10, new UsersReply()
        };

        yield return new object[]
        {
            "JEMA", 0, 10, new UsersReply()
        };

        yield return new object[]
        {
            "KIKOU7", 1, 0, new UsersReply()
        };

        yield return new object[]
        {
            "LOLO", 0, 0, new UsersReply()
        };

        yield return new object[]
        {
            "",
            1,
            10,
            new UsersReply
            {
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
        };
    }

    public static IEnumerable<object[]> Data_TestUsersByFirstNameAndLastName()
    {
        yield return new object[]
        {
            "J",
            1,
            10,
            new UsersReply
            {
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
                        Id = 15UL,
                        FirstName = "Eliaz",
                        LastName = "DU JARDIN",
                        Nickname = "THEGIANTE",
                        Avatar = "avatar15"
                    }
                }
            }
        };

        yield return new object[]
        {
            "J", 2, 10, new UsersReply()
        };

        yield return new object[]
        {
            "M",
            1,
            10,
            new UsersReply
            {
                Users =
                {
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
        };

        yield return new object[]
        {
            "Jeanne", 0, 10, new UsersReply()
        };

        yield return new object[]
        {
            "Jeanne", 1, 0, new UsersReply()
        };

        yield return new object[]
        {
            "Jeanne", 0, 0, new UsersReply()
        };

        yield return new object[]
        {
            "",
            1,
            10,
            new UsersReply
            {
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
        };
    }
    
    public static IEnumerable<object[]> InsertUserData()
    {
        yield return new object[]
        {
            new UserInsertRequest
            {
                FirstName = "Pedro",
                LastName = "Machin",
                Nickname = "Pema",
                Avatar = "avatar28",
                Email = "email",
                Password = "password"
            },
            new UserReply
            {
                Id = 17UL,
                FirstName = "Pedro",
                LastName = "Machin",
                Nickname = "Pema",
                Avatar = "avatar28"
            }
        };
    }
    
    public static IEnumerable<object?[]> UpdateUserData()
    {
        yield return new object?[]
        {
            new UserUpdateRequest
            {
                Id = 14UL,
                FirstName = "Pedro",
                LastName = "Machin",
                Nickname = "Pema",
                Avatar = "avatar28",
                Email = "email",
                Password = "password"
            },
            new UserReply
            {
                Id = 14UL,
                FirstName = "Pedro",
                LastName = "Machin",
                Nickname = "Pema",
                Avatar = "avatar28"
            }
        };
        yield return new object?[]
        {
            new UserUpdateRequest
            {
                Id = 6UL,
                FirstName = "Pedro",
                LastName = "Machin",
                Nickname = "Pema",
                Avatar = "avatar28",
                Email = "email",
                Password = "password"
            },
            null
        };
        yield return new object?[]
        {
            new UserUpdateRequest
            {
                Id = 50UL,
                FirstName = "Anne",
                LastName = "PETIT",
                Nickname = "FRIPOUILLES",
                Avatar = "avatar13",
                Email = "email",
                Password = "password"
            },
            null
        };
        yield return new object?[]
        {
            new UserUpdateRequest
            {
                Id = 0UL,
                FirstName = "Anne",
                LastName = "PETIT",
                Nickname = "FRIPOUILLES",
                Avatar = "avatar13",
                Email = "email",
                Password = "password"
            },
            null
        };
    }
    
    public static IEnumerable<object?[]> DeleteUserData()
    {
        yield return new object?[]
        {
            3UL,
            false
        };
        yield return new object?[]
        {
            14UL,
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
