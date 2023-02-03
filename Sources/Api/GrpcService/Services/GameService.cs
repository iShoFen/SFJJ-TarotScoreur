using Grpc.Core;
using GrpcService.extensions;
using GrpcService.Extensions;
using Model;
using Model.Players;
using Model.Rules;

namespace GrpcService.Services;

public class GameService : Game.GameBase
{
    private readonly Manager _manager;
    private readonly ILogger<GameService> _logger;

    public GameService(Manager manager, ILogger<GameService> logger)
    {
        _manager = manager;
        _logger = logger;
    }

    public override async Task<GamesReply> GetGames(Pagination request, ServerCallContext context)
    {
        var games = await _manager.GetGames(request.Page, request.PageSize);
        _logger.Log(LogLevel.Information, $"{nameof(GetGames)}({request.Page}, {request.PageSize})");
        return games.ToGamesReply();
    }

    public override async Task<GameReply> GetGame(IdRequest request, ServerCallContext context)
    {
        var game = await _manager.GetGameById(request.Id);

        if (game == null)
        {
            _logger.Log(LogLevel.Warning, $"Game with id {request.Id} was not found");
            throw new RpcException(new Status(StatusCode.NotFound, "Game not found"));
        }

        _logger.Log(LogLevel.Information, $"Game with id:{request.Id} was found");
        return game.ToGameReply();
    }

    public override async Task<GamesReply> GetGamesByName(GamePatternRequest request, ServerCallContext context)
    {
        var games =
            (await _manager.GetGamesByName(request.Pattern, request.Pagination.Page, request.Pagination.PageSize))
            .ToList();
        _logger.Log(LogLevel.Information, $"{games.Count} games were retrieved with the pattern {request.Pattern}");
        return games.ToGamesReply();
    }

    public override async Task<GamesReply> GetGamesByPlayer(GamePlayerRequest request, ServerCallContext context)
    {
        var games = (await _manager.GetGamesByPlayer(request.PlayerId, request.Pagination.Page,
                request.Pagination.PageSize))
            .ToList();
        _logger.Log(LogLevel.Information, $"{games.Count} games were retrieved with the player id {request.PlayerId}");
        return games.ToGamesReply();
    }

    public override async Task<GamesReply> GetGamesByDate(GameDateRequest request, ServerCallContext context)
    {
        var games = (await _manager.GetGamesByDate(request.StartDate.ToDateTime(), request.EndDate.ToDateTime(),
                request.Pagination.Page,
                request.Pagination.PageSize))
            .ToList();
        _logger.Log(LogLevel.Information,
            $"{games.Count} games were retrieved with the start date ({request.StartDate}) and end date ({request.EndDate})");
        return games.ToGamesReply();
    }

    public override async Task<GameReply> InsertGame(GameInsertRequest request, ServerCallContext context)
    {
        var players = new List<Player>();
        foreach (var playerId in request.Players)
        {
            var player = await _manager.GetPlayerById(playerId);

            if (player == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"The user with id {playerId} does not exist"));

            players.Add(player);
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.Log(LogLevel.Warning, $"Rules {request.Rules} does not correspond to any rules");
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"Rules {request.Rules} does not correspond to any rules"));
        }

        try
        {
            var game = (await _manager.InsertGame(request.Name, rules, request.StartDate.ToDateTime(),
                players.ToArray()))!;

            _logger.Log(LogLevel.Information, $"The game with id {game.Id} has been successfully inserted");
            return game.ToGameReply();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Warning, $"An error occurred while inserting the new game with request {request}");
            throw new RpcException(new Status(StatusCode.Internal, $"An error occurred while inserted the game"));
        }
    }

    public override async Task<GameReply> UpdateGame(GameReply request, ServerCallContext context)
    {
        var convertedGame = request.ToGame();
        if (convertedGame is null)
        {
            _logger.Log(LogLevel.Warning, $"Converted game from request {request} is null");
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                "The arguments passed cannot be used to update the game"));
        }

        var game = await _manager.UpdateGame(convertedGame);

        if (game is not null) return game.ToGameReply();

        _logger.Log(LogLevel.Warning, $"An error occurred while updating the game with request {request}");
        throw new RpcException(new Status(StatusCode.Aborted,
            $"An error occurred while updating the game with {request.Id}"));
    }

    public override async Task<BoolResponse> DeleteGame(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteGame(request.Id);
        if (result)
        {
            _logger.Log(LogLevel.Information, $"Game with id {request.Id} was successfully deleted");
        }
        else
        {
            _logger.Log(LogLevel.Warning, $"Game with id {request.Id} was not deleted");
        }

        return new BoolResponse { Result = result };
    }
}