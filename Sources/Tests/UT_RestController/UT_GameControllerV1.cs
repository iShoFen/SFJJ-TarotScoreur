using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestController.Controllers;
using RestController.DTOs;
using RestController.DTOs.Games;
using RestController.Filter;
using Xunit;

namespace UT_RestController;

public class UT_GameControllerV1
{
    [Fact]
    public void ConstructorTest()
    {
        var controller = new GamesController(RestUtils.CreateManager());

        Assert.NotNull(controller);
    }

    #region Reader


    [Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestGetGames), MemberType = typeof(GameControllerDataV1))]
    public async Task TestGetGames(int page, int pageSize, List<GameDTO> expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());

        var actual = await controller.GetGames(new PaginationFilter{ Page = page, Count = pageSize });
        
        var response = (actual as OkObjectResult)!.Value as List<GameDTO>;
        
        Assert.Equal(expected, response);
    }
    
    
    [Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestGetGameById), MemberType = typeof(GameControllerDataV1))]
    public async Task TestGetGameById(ulong id, GameDetailDTO expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());

        var actual = await controller.GetGame(id);
        
        var response = (actual as OkObjectResult).Value as GameDetailDTO;
        
        Assert.Equal(expected,response);
    }
    
    [Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestGetUsersByGameId), MemberType = typeof(GameControllerDataV1))]
    public async Task TestGetUsersByGameId(ulong id, List<UserDTO> expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());

        var actual = await controller.GetUsersByGameId(id);
        
        var response = (actual as OkObjectResult)!.Value as List<UserDTO>;
        
        Assert.Equal(expected, response);
    }
    

    #endregion

    #region Writer

    [Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestPostGame), MemberType = typeof(GameControllerDataV1))]
    public async Task TestPostGame(GameInsertRequest game, GameDetailDTO expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());

        var actual = await controller.PostGame(game);

        Debug.WriteLine(actual.ToString());
        var response = (actual as ObjectResult)!.Value as GameDetailDTO;
        
        Assert.Equal(expected, response);
    }
    
    [Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestPutGame), MemberType = typeof(GameControllerDataV1))]
    public async Task TestPutGame(ulong id, GameUpdateRequest game, GameDetailDTO expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());
        var old = (await controller.GetGame(id) as ObjectResult)!.Value as GameDetailDTO;
        var actual = (await controller.PutGame(id, game) as ObjectResult)!.Value as GameDetailDTO;


        Assert.NotEqual(expected, old);
        Assert.Equal(expected, actual);
    }

    /*[Theory]
    [MemberData(nameof(GameControllerDataV1.Data_TestDeleteGame), MemberType = typeof(GameControllerDataV1))]
    public async Task TestDeleteGame(ulong id, GameDetailDTO expected)
    {
        var controller = new GamesController(RestUtils.CreateManager());
        var old = (await controller.GetGame(id) as ObjectResult)!.Value as GameDetailDTO;

        await controller.DeleteGame(id);

        await controller.TryUpdateModelAsync(old);
        
        var actual = await controller.GetGame(id);
        
        Assert.True(actual == null);
    }*/

    #endregion
}