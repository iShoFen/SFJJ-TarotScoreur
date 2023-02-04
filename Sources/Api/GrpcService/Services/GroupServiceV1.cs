using Grpc.Core;
using GrpcService.Extensions;
using Model;
using Model.Players;

namespace GrpcService.Services;

/// <summary>
/// The group service for gRPC v1
/// </summary>
public class GroupServiceV1 : Group.GroupBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<GroupServiceV1> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public GroupServiceV1(Manager manager, ILogger<GroupServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;

        _logger.LogInformation("GroupServiceV1 created");
    }

    /// <summary>
    /// Get all groups with pagination
    /// </summary>
    /// <param name="request">The pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupsReply with groups</returns>
    public override async Task<GroupsReply> GetGroups(Pagination request, ServerCallContext context)
    {
        var groups = await _manager.GetGroups(request.Page, request.PageSize);
        _logger.LogInformation("All groups from {Page} page with {PageSize} size loaded",
                               request.Page,
                               request.PageSize
        );

        return groups.ToGroupsReply();
    }

    /// <summary>
    /// Get group by id
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupReply with group</returns>
    /// <exception cref="RpcException">If group not found</exception>
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

    /// <summary>
    /// Get all groups by name with pagination
    /// </summary>
    /// <param name="request">The pattern and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupsReply with groups</returns>
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

    /// <summary>
    /// Get all groups by player id with pagination
    /// </summary>
    /// <param name="request">The player id and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupsReply with groups</returns>
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

    /// <summary>
    /// Insert group
    /// </summary>
    /// <param name="request">The GroupInsertRequest</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupReply with the inserted group</returns>
    /// <exception cref="RpcException">If one player not found</exception>
    public override async Task<GroupReply> InsertGroup(GroupInsertRequest request, ServerCallContext context)
    {
        var players = new List<Player>();
        foreach (var requestPlayer in request.Players)
        {
            await _manager.GetUserById(requestPlayer).ContinueWith(task =>
            {
                if (task.Result != null)
                {
                    players.Add(task.Result);
                } 
                else
                {
                    _logger.LogWarning("Player with id {Id} not found", requestPlayer);
                    throw new RpcException(new Status(StatusCode.NotFound, "Player not found"));
                }
            });
        }
        
        var group = await _manager.InsertGroup(request.Name, players.ToArray());


        _logger.LogInformation("Group with id {Id} created", group!.Id);
        
        return group.ToGroupReply();
    }

    /// <summary>
    /// Update group
    /// </summary>
    /// <param name="request">The GroupUpdateRequest</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupReply with the updated group</returns>
    /// <exception cref="RpcException">If group not found or one player not found</exception>
    public override async Task<GroupReply> UpdateGroup(GroupUpdateRequest request, ServerCallContext context)
    {
        var group = request.ToGroup();
        foreach (var requestPlayer in request.Players)
        {
            await _manager.GetUserById(requestPlayer).ContinueWith(task =>
            {
                if (task.Result != null)
                {
                    group.AddPlayers(task.Result);
                } 
                else
                {
                    _logger.LogWarning("Player with id {Id} not found", requestPlayer);
                    throw new RpcException(new Status(StatusCode.NotFound, "Player not found"));
                }
            });
        }
        
        var updateGroup = await _manager.UpdateGroup(request.ToGroup());

        if (updateGroup == null)
        {
            _logger.LogWarning("Group not updated, at least one player not found");
            throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        }
        _logger.LogInformation("Group with id {Id} updated", updateGroup.Id);
        
        return updateGroup.ToGroupReply();
    }

    /// <summary>
    /// Delete group
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The BoolResponse with result</returns>
    /// <exception cref="RpcException">If group not found</exception>
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
