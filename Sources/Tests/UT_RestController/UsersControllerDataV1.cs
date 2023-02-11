using RestController.DTOs;

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
}