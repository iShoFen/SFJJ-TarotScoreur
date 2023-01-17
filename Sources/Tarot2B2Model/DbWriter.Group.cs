using Model.Players;

namespace Tarot2B2Model;

public partial class DbWriter
{
    // public async Task<Group?> SaveGroup(Group group)
    // {
    //     Mapper.Reset();
    //
    //     await using var context = InitContext();
    //     var groupEntity = group.ToEntity();
    //
    //     if (await context.Groups.FindAsync(group.Id) != null || group.Id != 0UL) return null;
    //     groupEntity.Players = groupEntity.Players.Select(p => context.Players.Find(p.Id)!).ToHashSet();
    //     var result = await context.AddAsync(groupEntity);
    //
    //     await context.SaveChangesAsync();
    //
    //     return result.Entity.ToModel();
    // }
    public async Task<Group?> InsertGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public async Task<Group?> UpdateGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteGroup(ulong groupId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteGroup(Group group)
    {
        throw new NotImplementedException();
    }
}