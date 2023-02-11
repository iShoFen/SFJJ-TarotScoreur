using RestController.DTOs;

namespace UT_RestController;

public class GroupsControllerDataV1
{
    public static IEnumerable<object[]> Data_TestGetGroups()
    {
        yield return new object[]
        {
            1,
            10,
            new List<GroupDTO>()
            {
                new()
                {   
                    Id = 1,
                    Name = "Group 1",
                    Users = { 1, 2, 3, 4, 5 }
                },
                new()
                {   
                    Id = 2,
                    Name = "Group 2",
                    Users = { 2, 3, 4, 5, 6 }
                },
                new()
                {   
                    Id = 3,
                    Name = "Group 3",
                    Users = { 3, 4, 5, 6, 7 }
                },
                new()
                {   
                    Id = 4,
                    Name = "Group 4",
                    Users = { 4, 5, 6, 7, 8 }
                },
                new()
                {   
                    Id = 5,
                    Name = "Group 5",
                    Users = { 5, 6, 7, 8, 9 }
                },
                new()
                {   
                    Id = 6,
                    Name = "Group 6",
                    Users = { 6, 7, 8, 9, 10 }
                },
                new()
                {   
                    Id = 7,
                    Name = "Group 7",
                    Users = { 7, 8, 9, 10, 11 }
                },
                new()
                {   
                    Id = 8,
                    Name = "Group 8",
                    Users = { 8, 9, 10, 11, 12 }
                },
                new()
                {   
                    Id = 9,
                    Name = "Group 9",
                    Users = { 9, 10, 11, 12, 13 }
                },
                new()
                {   
                    Id = 10,
                    Name = "Group 10",
                    Users = { 10, 11, 12, 13, 14 }
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestGetGroupById()
    {   
        yield return new object[]
        {
            1,
            new GroupDTO()
            {
                Id = 1,
                Name = "Group 1",
                Users = { 1, 2, 3, 4, 5 }
            }
        };
    }
    
    public static IEnumerable<object[]> Data_TestGetGroupUsers()
    {
        yield return new object[]
        {
            11UL,
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
                }
            }
        };
    }

    public static IEnumerable<object[]> Data_TestGetGroupUserById()
    {
        yield return new object[]
        {
            11UL,
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