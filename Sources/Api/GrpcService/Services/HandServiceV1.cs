using Grpc.Core;
using GrpcService.Extensions;
using Model;
using Model.Enums;
using Model.Players;
using Model.Rules;

namespace GrpcService.Services;

public class HandServiceV1 : Hand.HandBase
{
    private readonly Manager _manager;
    private readonly ILogger<HandServiceV1> _logger;

    public HandServiceV1(Manager manager, ILogger<HandServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;
    }

    public override async Task<HandReply> GetHandById(IdRequest request, ServerCallContext context)
    {
        var hand = await _manager.GetHandById(request.Id);

        if (hand is null)
        {
            _logger.Log(LogLevel.Warning, $"Hand with id {request.Id} was not found");
            throw new RpcException(new Status(StatusCode.NotFound, $"Hand with id {request.Id} was not found"));
        }

        _logger.Log(LogLevel.Information, $"Hand with id:{request.Id} was found");
        return hand.ToHandReply();
    }

    public override async Task<HandReply> InsertHand(HandInsertRequest request, ServerCallContext context)
    {
        var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
        foreach (var userBiddingPoignee in request.Biddings)
        {
            var player = await _manager.GetPlayerById(userBiddingPoignee.PlayerId);

            if (player == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"The user with id {userBiddingPoignee.PlayerId} does not exist"));

            biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(player,
                (userBiddingPoignee.Bidding.ToModel(), userBiddingPoignee.Poignee.ToModel())));
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
            var hand = (await _manager.InsertHand(
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
            ))!;

            _logger.Log(LogLevel.Information, $"The hand with id {hand.Id} has been successfully inserted");
            return hand.ToHandReply();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Warning,
                $"An error occurred while inserting the new hand with request {request}\n{e.Message}");
            throw new RpcException(new Status(StatusCode.Internal, $"An error occurred while inserted the hand"));
        }
    }

    public override async Task<HandReply> UpdateHand(HandReply request, ServerCallContext context)
    {
        var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
        foreach (var userBiddingPoignee in request.Biddings)
        {
            var player = await _manager.GetPlayerById(userBiddingPoignee.PlayerId);

            if (player == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument,
                    $"The user with id {userBiddingPoignee.PlayerId} does not exist"));

            biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(player,
                (userBiddingPoignee.Bidding.ToModel(), userBiddingPoignee.Poignee.ToModel())));
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.Log(LogLevel.Warning, $"Rules {request.Rules} does not correspond to any rules");
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"Rules {request.Rules} does not correspond to any rules"));
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

        if (handResult is not null) return handResult.ToHandReply();

        _logger.Log(LogLevel.Warning, $"An error occurred while updating the hand with request {request}");
        throw new RpcException(new Status(StatusCode.Aborted,
            $"An error occurred while updating the hand with id {request.Id}"));
    }

    public override async Task<BoolResponse> DeleteHand(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteHand(request.Id);
        if (result)
        {
            _logger.Log(LogLevel.Information, $"Hand with id {request.Id} was successfully deleted");
        }
        else
        {
            _logger.Log(LogLevel.Warning, $"Hand with id {request.Id} was not deleted");
        }

        return new BoolResponse { Result = result };
    }
}