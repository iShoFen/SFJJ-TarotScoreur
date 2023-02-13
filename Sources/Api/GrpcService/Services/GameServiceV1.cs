using Grpc.Core;
using GrpcService.Extensions;
using Model;
using Model.Players;
using Model.Rules;

namespace GrpcService.Services;

/// <summary>
/// The game service for gRPC v1
/// </summary>
public class GameServiceV1 : Game.GameBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<GameServiceV1> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public GameServiceV1(Manager manager, ILogger<GameServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;
        _logger.LogInformation("GameServiceV1 created");
    }

    /// <summary>
    /// Get all games with pagination
    /// </summary>
    /// <param name="request">The pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GamesReply with games</returns>
    public override async Task<GamesReply> GetGames(Pagination request, ServerCallContext context)
    {
        var games = (await _manager.GetGames(request.Page, request.PageSize)).ToList(); 
        _logger.LogInformation("{GamesCount} games from {Page} page with {PageSize} size retrieved", 
                               games.Count,
                               request.Page,
                               request.PageSize
        );
        
        return games.ToGamesReply();
    }

    /// <summary>
    /// Get game by id
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GameReply with game</returns>
    /// <exception cref="RpcException">If game not found</exception>
    public override async Task<GameReplyDetails> GetGame(IdRequest request, ServerCallContext context)
    {
        var game = await _manager.GetGameById(request.Id);

        if (game is null)
        {
            _logger.LogWarning("Game with id {Id} was not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Game with id {request.Id} not found"));
        }

        _logger.LogInformation("Game with id {Id} retrieved", request.Id);
        return game.ToGameReplyDetails();
    }

    /// <summary>
    /// Get games by name
    /// </summary>
    /// <param name="request">The name pattern</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GamesReply with games</returns>
    public override async Task<GamesReply> GetGamesByName(GamePatternRequest request, ServerCallContext context)
    {
        var games = (await _manager.GetGamesByName(request.Pattern,
                                                   request.Pagination.Page,
                                                   request.Pagination.PageSize
        )).ToList();

        _logger.LogInformation("{GamesCount} games retrieved by name pattern {Pattern}",
                               games.Count,
                               request.Pattern
        );

        return games.ToGamesReply();
    }

    /// <summary>
    /// Get games by player
    /// </summary>
    /// <param name="request">The player id and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GamesReply with games</returns>
    public override async Task<GamesReply> GetGamesByPlayer(GamePlayerRequest request, ServerCallContext context)
    {
        var games = (await _manager.GetGamesByPlayer(request.PlayerId,
                                                     request.Pagination.Page,
                                                     request.Pagination.PageSize
            ))
            .ToList();

        _logger.LogInformation("{GamesCount} games retrieved for player with id {PlayerId}",
                               games.Count,
                               request.PlayerId
        );

        return games.ToGamesReply();
    }

    /// <summary>
    /// Get games by date
    /// </summary>
    /// <param name="request">The start date, end date and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GamesReply with games</returns>
    public override async Task<GamesReply> GetGamesByDate(GameDateRequest request, ServerCallContext context)
    {
        var games = (await _manager.GetGamesByDate(request.StartDate.ToDateTime(),
                                                   request.EndDate?.ToDateTime(),
                                                   request.Pagination.Page,
                                                   request.Pagination.PageSize
            ))
            .ToList();

        _logger.LogInformation("{GamesCount} games retrieved from {StartDate} to {EndDate}",
                               games.Count,
                               request.StartDate,
                               request.EndDate
        );

        return games.ToGamesReply();
    }

    /// <summary>
    /// Insert a game
    /// </summary>
    /// <param name="request">The game to insert</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GameReply with the inserted game</returns>
    /// <exception cref="RpcException">If the user does not exist</exception>
    public override async Task<GameReplyDetails> InsertGame(GameInsertRequest request, ServerCallContext context)
    {
        var players = new List<Player>();
        foreach (var playerId in request.Players)
        {
            var player = await _manager.GetPlayerById(playerId);

            if (player == null)
            {
                _logger.LogWarning("User with id {Id} not found, game cannot be inserted", playerId);
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"User with id {playerId} not found, game cannot be inserted"));
            }
            players.Add(player);
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.LogWarning("Rules {Rules} does not correspond to any rules, game cannot be inserted", request.Rules);
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"Rules {request.Rules} does not correspond to any rules, game cannot be inserted"));
        }
        
        var game = (await _manager.InsertGame(request.Name, rules, request.StartDate.ToDateTime(), players.ToArray()))!;
        _logger.LogInformation("Game with id {Id} inserted", game.Id);
        
        return game.ToGameReplyDetails();
    }

    /// <summary>
    /// Update a game
    /// </summary>
    /// <param name="request">The game to update</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GameReply with the updated game</returns>
    /// <exception cref="RpcException">If the game does not exist</exception>
    public override async Task<GameReplyDetails> UpdateGame(GameReplyDetails request, ServerCallContext context)
    {
        var convertedGame = request.ToGame();
        if (convertedGame is null)
        {
            _logger.LogWarning("Rules {Rules} does not correspond to any rules, game cannot be updated", request.Rules);
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"Rules {request.Rules} does not correspond to any rules, game cannot be updated"));
        }

        var game = await _manager.UpdateGame(convertedGame);

        if (game is null)
        {
            _logger.LogWarning("Game with id {Id} not found, it cannot be updated", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Game with id {request.Id} not found, it cannot be updated"));
        }
        _logger.LogInformation("Game with id {Id} updated", game.Id);
        
        return game.ToGameReplyDetails();
    }

    /// <summary>
    /// Delete a game
    /// </summary>
    /// <param name="request">The game id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The BoolResponse with the result</returns>
    /// <exception cref="RpcException">If the game does not exist</exception>
    public override async Task<BoolResponse> DeleteGame(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteGame(request.Id);
        if (!result)
        {
            _logger.LogWarning("Game with id {Id} not found, the game cannot be deleted", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Game with id {request.Id} not found, it cannot be deleted"));
        }
        _logger.LogInformation("Game with id {Id} deleted", request.Id);
        
        return new BoolResponse { Result = result };
    }
}