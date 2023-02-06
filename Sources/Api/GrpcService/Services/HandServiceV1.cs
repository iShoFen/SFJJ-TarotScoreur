using Grpc.Core;
using GrpcService.Extensions;
using Model;
using Model.Enums;
using Model.Players;
using Model.Rules;

namespace GrpcService.Services;

/// <summary>
/// The hand service for gRPC v1
/// </summary>
public class HandServiceV1 : Hand.HandBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<HandServiceV1> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public HandServiceV1(Manager manager, ILogger<HandServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;
        _logger.LogInformation("HandServiceV1 created");
    }

    /// <summary>
    /// Get hand by id
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The HandReply with hand</returns>
    /// <exception cref="RpcException">If hand not found</exception>
    public override async Task<HandReply> GetHandById(IdRequest request, ServerCallContext context)
    {
        var hand = await _manager.GetHandById(request.Id);

        if (hand is null)
        {
            _logger.Log(LogLevel.Warning, "Hand with id {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Hand with id {request.Id} not found"));
        }

        _logger.Log(LogLevel.Information, "Hand with id {Id} retrieved", request.Id);
        return hand.ToHandReply();
    }

    /// <summary>
    /// Insert hand
    /// </summary>
    /// <param name="request">The hand to insert</param>
    /// <param name="context">The server call context</param>
    /// <returns>The HandReply with inserted hand</returns>
    /// <exception cref="RpcException">If user not found</exception>
    public override async Task<HandReply> InsertHand(HandInsertRequest request, ServerCallContext context)
    {
        var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
        foreach (var userBiddingPoignee in request.Biddings)
        {
            var player = await _manager.GetPlayerById(userBiddingPoignee.PlayerId);

            if (player == null)
            {                
                _logger.Log(LogLevel.Warning, "User with id {Id} not found, hand cannot be inserted", userBiddingPoignee.PlayerId);
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"User with id {userBiddingPoignee.PlayerId} not found, hand cannot be inserted"));
            }
            
            biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(player,
                (userBiddingPoignee.Bidding.ToModel(), userBiddingPoignee.Poignee.ToModel())));
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.Log(LogLevel.Warning, "Rules {RequestRules} does not correspond to any rules, hand cannot be inserted", request.Rules);
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"Rules {request.Rules} does not correspond to any rules, hand cannot be inserted"));
        }
        
        var hand = await _manager.InsertHand(
            request.GameId,
            request.Number,
            rules,
            request.Date.ToDateTime(),
            request.TakerScore,
            request.TwentyOne,
            request.Excuse,
            request.Petit.ToModel(),
            request.Chelem.ToModel(),
            biddings.ToArray()
        );

        if (hand is null)
        {
            _logger.Log(LogLevel.Warning, "Game with id {Id} not found, hand cannot be inserted", request.GameId);
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"Game with id {request.GameId} not found, hand cannot be inserted"));
        }

        _logger.Log(LogLevel.Information, "Hand with id {Id} inserted", hand.Id);
        return hand.ToHandReply();
    }

    /// <summary>
    /// Update hand
    /// </summary>
    /// <param name="request">The hand to update</param>
    /// <param name="context">The server call context</param>
    /// <returns>The HandReply with updated hand</returns>
    /// <exception cref="RpcException">If hand not found or rules not exist or hand not found</exception>
    public override async Task<HandReply> UpdateHand(HandReply request, ServerCallContext context)
    {
        var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
        foreach (var userBiddingPoignee in request.Biddings)
        {
            var player = await _manager.GetUserById(userBiddingPoignee.PlayerId);

            if (player == null)
            {
                _logger.Log(LogLevel.Warning, "User with id {Id} not found, hand cannot be updated", userBiddingPoignee.PlayerId);
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"User with id {userBiddingPoignee.PlayerId} not found, hand cannot be updated"));
            }
            
            biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(player,
                (userBiddingPoignee.Bidding.ToModel(), userBiddingPoignee.Poignee.ToModel())));
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.Log(LogLevel.Warning, "Rules {Rules} does not correspond to any rules, hand cannot be updated", request.Rules);
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"Rules {request.Rules} does not correspond to any rules, hand cannot be updated"));
        }

        var hand = new Model.Games.Hand(
            request.Id,
            request.Number,
            rules,
            request.Date.ToDateTime(),
            request.TakerScore,
            request.TwentyOne,
            request.Excuse,
            request.Petit.ToModel(),
            request.Chelem.ToModel(),
            biddings.ToArray()
        );

        var handResult = await _manager.UpdateHand(hand);

        if (handResult is null)
        {
            _logger.Log(LogLevel.Warning, "Hand with id {Id} not found, it cannot be updated", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Hand with id {request.Id} not found, it cannot be updated"));
        }
        _logger.Log(LogLevel.Information, "Hand with id {Id} updated", request.Id);
        
        return handResult.ToHandReply();
    }

    /// <summary>
    /// Delete hand
    /// </summary>
    /// <param name="request">The id of the hand to delete</param>
    /// <param name="context">The server call context</param>
    /// <returns>The BoolResponse with result of the deletion</returns>
    /// <exception cref="RpcException">If hand not found</exception>
    public override async Task<BoolResponse> DeleteHand(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteHand(request.Id);
        
        if (!result)
        {
            _logger.Log(LogLevel.Warning, "Hand with id {Id} not found, it cannot be deleted", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Hand with id {request.Id} not found, it cannot be deleted"));
        }
        _logger.Log(LogLevel.Information, "Hand with id {Id} deleted", request.Id);

        return new BoolResponse { Result = result };
    }
}