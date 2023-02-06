using Grpc.Core;
using GrpcService.Extensions;
using Model;
using Model.Players;

namespace GrpcService.Services;

// Cause online DB only have Users, not Players and the API only allow to add Users
// Not test has been done to reject group with Players

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
        var groups = (await _manager.GetGroups(request.Page, request.PageSize)).ToList();
        _logger.LogInformation("{GroupsCount} groups from {Page} page with {PageSize} size loaded",
                               groups.Count,
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
            throw new RpcException(new Status(StatusCode.NotFound, $"Group with id {request.Id} not found"));
        }
        _logger.LogInformation("Group with id {Id} retrieved", request.Id);
        
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
            (await _manager.GetGroupsByName(request.Pattern, request.Pagination.Page, request.Pagination.PageSize))
            .ToList();
        
        _logger.LogInformation("{GroupsCount} groups with pattern {Pattern} from {Page} page with {PageSize} size retrieved",
                               groups.Count,
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return groups.ToGroupsReply();
    }

    /// <summary>
    /// Get all groups by user id with pagination
    /// </summary>
    /// <param name="request">The user id and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The GroupsReply with groups</returns>
    public override async Task<GroupsReply> GetGroupsByUser(GroupUserRequest request, ServerCallContext context)
    {
        var groups =
            (await _manager.GetGroupsByPlayer(request.UserId, request.Pagination.Page, request.Pagination.PageSize))
            .ToList();

        _logger.LogInformation("{GroupsCount} groups with user id {UserId} from {Page} page with {PageSize} size retrieved",
                               groups.Count,
                               request.UserId,
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
    /// <exception cref="RpcException">If one user not found</exception>
    public override async Task<GroupReply> InsertGroup(GroupInsertRequest request, ServerCallContext context)
    {
        var players = new List<Player>();
        foreach (var userId in request.Users)
        {
            await _manager.GetUserById(userId).ContinueWith(task =>
            {
                if (task.Result != null)
                {
                    players.Add(task.Result);
                } 
                else
                {
                    _logger.LogWarning("User with id {Id} not found, group not created", userId);
                    throw new RpcException(new Status(StatusCode.NotFound, $"User with id {userId} not found"));
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
    /// <exception cref="RpcException">If group not found or one user not found</exception>
    public override async Task<GroupReply> UpdateGroup(GroupUpdateRequest request, ServerCallContext context)
    {
        var group = request.ToGroup();
        foreach (var userId in request.Users)
        {
            await _manager.GetUserById(userId).ContinueWith(task =>
            {
                if (task.Result != null)
                {
                    group.AddPlayers(task.Result);
                } 
                else
                {
                    _logger.LogWarning("User with id {Id} not found, it can't be added to group", userId);
                    throw new RpcException(new Status(StatusCode.NotFound, $"User with id {userId} not found, so it can't be added to group"));
                }
            });
        }
        
        var updateGroup = await _manager.UpdateGroup(group);

        if (updateGroup == null)
        {
            _logger.LogWarning("Group with id {Id} not found, it can't be updated", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Group with id {request.Id} not found, so it can't be updated"));
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
            _logger.LogWarning("Group with id {Id} not found, it can't be deleted", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"Group with id {request.Id} not found, so it can't be deleted"));
        }
        _logger.LogInformation("Group with id {Id} deleted", request.Id);
        
        return new BoolResponse
        {
            Result = result
        };
    }
}
