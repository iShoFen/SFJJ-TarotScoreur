using Grpc.Core;
using Model.Data;

namespace GrpcService.Services;

public class GroupService : Group.GroupBase
{
    private readonly IReader _reader;

    public GroupService(IReader reader)
    {
        _reader = reader;
    }

    public override async Task<GroupReply> GetGroup(GroupIdRequest request, ServerCallContext context)
    {
        var group = await _reader.GetGroupById(request.Id);
        return await Task.FromResult(new GroupReply
        {
            Id = group.Id
        });
    }

    public override async Task<GroupsReply> GetGroups(Pagination request, ServerCallContext context)
    {
        var groups = await _reader.GetGroups(request.Page, request.PageSize);

        var groupReplies = groups.Select(g => new GroupReply
        {
            Id = g.Id
        });
        
        var reply = new GroupsReply();
        reply.Groups.AddRange(groupReplies);
        
        return await Task.FromResult(reply);
    }
}