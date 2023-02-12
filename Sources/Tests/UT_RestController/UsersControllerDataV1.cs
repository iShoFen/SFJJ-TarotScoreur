using RestController.DTOs;
using RestController.DTOs.Games;

namespace UT_RestController;

public class UsersControllerDataV1
{
    //Method for data for test getUsers
    public static IEnumerable<object[]> Data_TestGetUsers()
    {
        yield return new object[]
        {
            1,
            10,
            new List<UserDTO>()
            {
                new()
                {
                    Id = 11UL,
                    FirstName = "Jeanne",
                    LastName = "LERICHE",
                    Nickname = "JEMAA",
                    Avatar = "avatar11",
                    Email = "email11"
                },
                new ()
                {
                    Id = 12UL,
                    FirstName = "Jules",
                    LastName = "INFANTE",
                    Nickname = "KIKOU77",
                    Avatar = "avatar12",
                    Email = "email12"
                },
                new()
                {
                    Id = 13UL,
                    FirstName = "Anne",
                    LastName = "PETIT",
                    Nickname = "FRIPOUILLES",
                    Avatar = "avatar13",
                    Email = "email13"
                },
                new()
                {
                    Id = 14UL,
                    FirstName = "Marine",
                    LastName = "TABLETTE",
                    Nickname = "LOLO",
                    Avatar = "avatar14",
                    Email = "email14"
                },
                new()
                {
                    Id = 15UL,
                    FirstName = "Eliaz",
                    LastName = "DU JARDIN",
                    Nickname = "THEGIANTE",
                    Avatar = "avatar15",
                    Email = "email15"
                },
                new()
                {
                    Id = 16UL,
                    FirstName = "Alizee",
                    LastName = "SEBAT",
                    Nickname = "SEBAT",
                    Avatar = "avatar16",
                    Email = "email16"
                }

            }
        };
    }
    
    //Method for data for test getUser
    public static IEnumerable<object[]> Data_TestGetUserById()
    {
        yield return new object[]
        {
            11UL,
            new UserDetailDTO()
            {
                Id = 11UL,
                FirstName = "Jeanne",
                LastName = "LERICHE",
                Nickname = "JEMAA",
                Avatar = "avatar11",
                Email = "email11",
                Games = {7, 8, 9, 10},
                Groups = {7 ,8, 9, 10, 11}
            }
        };
    }

    public static IEnumerable<object[]> Data_TestGetGamesByUserId()
    {
        yield return new object[]
        {
            11UL,
            new List<GameDTO>()
            {
                new()
                {
                    Id = 7UL,
                    Name = "Game 7",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 29)
                },
                new()
                {
                    Id = 8UL,
                    Name = "Game 8",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 9UL,
                    Name = "Game 9",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 21),
                    EndDate = new DateTime(2022, 09, 30)
                },
                new()
                {
                    Id = 10UL,
                    Name = "Game 10",
                    Rules = "FrenchTarotRules",
                    StartDate = new DateTime(2022, 09, 18),
                    EndDate = new DateTime(2022, 09, 23)
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestGetGroupsByUserId()
    {
        yield return new object[]
        {
            11UL,
            new List<GroupDTO>()
            {
                new()
                {
                    Id = 7UL,
                    Name = "Group 7",
                    Users = { 7, 8, 9, 10, 11 }
                },
                new()
                {
                    Id = 8UL,
                    Name = "Group 8",
                    Users = { 8, 9, 10, 11, 12 }
                },
                new()
                {
                    Id = 9UL,
                    Name = "Group 9",
                    Users = { 9, 10, 11, 12, 13 }
                },
                new()
                {
                    Id = 10UL,
                    Name = "Group 10",
                    Users = { 10, 11, 12, 13, 14 }
                },
                new()
                {
                    Id = 11UL,
                    Name = "Group 11",
                    Users = { 11, 12, 13, 14, 15 }
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestPostUser()
    {
        yield return new object[]
        {
            new UserInsertRequest()
            {
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Nickname = "NicknameTest",
                Avatar = "AvatarTest",
                Email = "EmailTest"
            },
            new UserDTO()
            {
                Id = 17UL,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Nickname = "NicknameTest",
                Avatar = "AvatarTest",
                Email = "EmailTest",
            }
        };
    }

    public static IEnumerable<object[]> Data_TestPutUser()
    {
        yield return new object[]
        {
            11UL,
            new UserUpdateRequest()
            {
                Id = 11UL,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Nickname = "NicknameTest",
                Avatar = "AvatarTest",
                Email = "EmailTest"
            },
            new UserDTO()
            {
                Id = 11UL,
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Nickname = "NicknameTest",
                Avatar = "AvatarTest",
                Email = "EmailTest",
            }
        };
    }


}