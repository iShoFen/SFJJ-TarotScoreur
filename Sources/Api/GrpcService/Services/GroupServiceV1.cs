using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

public class GroupServiceV1 : Group.GroupBase
{
    private readonly Manager _manager;

    public GroupServiceV1(Manager manager)
    {
        _manager = manager;
    }

    public override async Task<GroupsReply> GetGroups(Pagination request, ServerCallContext context)
    {
        var groups = await _manager.GetGroups(request.Page, request.PageSize);
        
        return groups.ToGroupsReply();
    }

    public override async Task<GroupReply> GetGroup(IdRequest request, ServerCallContext context)
    {
        var group = await _manager.GetGroupById(request.Id);
        
        if (group == null) throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        
        return group.ToGroupReply();
    }

    public override async Task<GroupsReply> GetGroupsByName(GroupPatternRequest request, ServerCallContext context)
    {
        var groups = await _manager.GetGroupsByName(request.Pattern, request.Pagination.Page, request.Pagination.PageSize);
        
        return groups.ToGroupsReply();
    }

    public override async Task<GroupsReply> GetGroupsByPlayer(GroupPlayerRequest request, ServerCallContext context)
    {
        var groups = await _manager.GetGroupsByPlayer(request.PlayerId, request.Pagination.Page, request.Pagination.PageSize);
        
        return groups.ToGroupsReply();
    }

    public override async Task<GroupReply> InsertGroup(GroupRequest request, ServerCallContext context)
    {
        var group = await _manager.InsertGroup(request.Name, request.Players.ToUsers().ToArray());

        if (group == null) throw new RpcException(new Status(StatusCode.Aborted, "Group not created, at least one player not found"));
        
        return group.ToGroupReply();
    }

    public override async Task<GroupReply> UpdateGroup(GroupReply request, ServerCallContext context)
    {
        var group = await _manager.UpdateGroup(request.ToGroup());
        
        if (group == null) throw new RpcException(new Status(StatusCode.NotFound, "Group not found"));
        
        return group.ToGroupReply();
    }

    public override async Task<BoolResponse> DeleteGroup(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteGroup(request.Id);
        
        return new BoolResponse { Result = result };
    }
}