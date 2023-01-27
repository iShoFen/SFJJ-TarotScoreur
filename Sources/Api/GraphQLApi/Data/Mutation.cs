using DTOs;

namespace GraphQLApi.Data;

public class Mutation
{
    public async Task<UserDTO> AddUser(string firstName, string lastName)
    {
        return await Task.FromResult(new UserDTO
        {
            FirstName = firstName,
            LastName = lastName
        });
    }
    
    public async Task<GameDTO> AddGame(long id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException("Toto");
    }
}