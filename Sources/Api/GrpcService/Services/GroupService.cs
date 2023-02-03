using Grpc.Core;
using Model;
using Model.Data;

namespace GrpcService.Services;

public class GroupService : Group.GroupBase
{
    private readonly Manager _manager;

    public GroupService(Manager manager)
    {
        _manager = manager;
    }
}