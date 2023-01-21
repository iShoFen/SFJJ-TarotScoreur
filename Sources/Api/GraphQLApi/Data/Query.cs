using DTOs;

namespace GraphQLApi.Data;

public class Query
{
    public IEnumerable<UserDTO> GetUsers() => new List<UserDTO>()
    {
        new UserDTO
        {
            FirstName = "Florent",
            LastName = "Marques"
        },
        new UserDTO
        {
            FirstName = "Samuel",
            LastName = "Sirven"
        },
    };
}