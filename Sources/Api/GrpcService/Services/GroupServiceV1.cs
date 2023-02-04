using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

public class GroupServiceV1 : Group.GroupBase
{
    private readonly Manager _manager;
    private readonly ILogger<GroupServiceV1> _logger;

    public GroupServiceV1(Manager manager, ILogger<GroupServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;

        _logger.LogInformation("GroupServiceV1 created");
    }

    public override async Task<GroupsReply> GetGroups(Pagination request, ServerCallContext context)
    {
        var groups = await _manager.GetGroups(request.Page, request.PageSize);
        _logger.LogInformation("All groups from {Page} page with {PageSize} size loaded",
                               request.Page,
                               request.PageSize
        );

        return groups.ToGroupsReply();
    }

    public override async Task<GroupReply> GetGroup(IdRequest request, ServerCallContext context)
    {
        var group = await _manager.GetGroupById(request.Id);

        if (group == null)
        {
            _logger.LogWarning("Group with id {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        }
        _logger.LogInformation("Group with id {Id} loaded", request.Id);
        
        return group.ToGroupReply();
    }

    public override async Task<GroupsReply> GetGroupsByName(GroupPatternRequest request, ServerCallContext context)
    {
        var groups =
            await _manager.GetGroupsByName(request.Pattern, request.Pagination.Page, request.Pagination.PageSize);
        _logger.LogInformation("Groups with pattern {Pattern} from {Page} page with {PageSize} size loaded",
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return groups.ToGroupsReply();
    }

    public override async Task<GroupsReply> GetGroupsByPlayer(GroupPlayerRequest request, ServerCallContext context)
    {
        var groups =
            await _manager.GetGroupsByPlayer(request.PlayerId, request.Pagination.Page, request.Pagination.PageSize);

        _logger.LogInformation("Groups with player id {PlayerId} from {Page} page with {PageSize} size loaded",
                               request.PlayerId,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return groups.ToGroupsReply();
    }

    public override async Task<GroupReply> InsertGroup(GroupRequest request, ServerCallContext context)
    {
        var group = await _manager.InsertGroup(request.Name, request.Players.ToUsers().ToArray());

        if (group == null)
        {
            _logger.LogWarning("Group not created, at least one player not found");
            throw new RpcException(new Status(StatusCode.Aborted, "Group not created, at least one player not found"));
        }
        _logger.LogInformation("Group with id {Id} created", group.Id);
        
        return group.ToGroupReply();
    }

    public override async Task<GroupReply> UpdateGroup(GroupReply request, ServerCallContext context)
    {
        var group = await _manager.UpdateGroup(request.ToGroup());

        if (group == null)
        {
            _logger.LogWarning("Group not updated, at least one player not found");
            throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        }
        _logger.LogInformation("Group with id {Id} updated", group.Id);
        
        return group.ToGroupReply();
    }

    public override async Task<BoolResponse> DeleteGroup(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteGroup(request.Id);
        
        if(!result)
        {
            _logger.LogWarning("Group with id {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        }
        _logger.LogInformation("Group with id {Id} deleted", request.Id);
        
        return new BoolResponse
        {
            Result = result
        };
    }
}
