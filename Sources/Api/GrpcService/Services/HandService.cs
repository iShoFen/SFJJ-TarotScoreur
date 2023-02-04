using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

public class HandService : Hand.HandBase
{
    private readonly Manager _manager;
    private readonly ILogger<HandService> _logger;

    public HandService(Manager manager, ILogger<HandService> logger)
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

    public override Task<HandReply> InsertHand(HandInsertRequest request, ServerCallContext context)
    {
        return base.InsertHand(request, context);
    }

    public override Task<HandReply> UpdateHand(HandUpdateRequest request, ServerCallContext context)
    {
        return base.UpdateHand(request, context);
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