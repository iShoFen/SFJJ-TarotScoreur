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
}