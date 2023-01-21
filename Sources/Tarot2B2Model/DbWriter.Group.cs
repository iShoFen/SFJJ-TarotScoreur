using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<Group?> InsertGroup(Group group)
    {
        if (group.Id != 0) return null;
        Mapper.Reset();

        var groupToInsert = group.ToEntity();
        
        List<PlayerEntity> players = new();
        foreach (var playerEntity in groupToInsert.Players)
        {
            var entity = await UnitOfWork.Repository<PlayerEntity>().GetById(playerEntity.Id);
            if (entity is null) return null;
            players.Add(entity);
        }
        groupToInsert.Players = players.ToHashSet();

        var result = await UnitOfWork.Repository<GroupEntity>().Insert(groupToInsert);

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Group?> UpdateGroup(Group group)
    {
        Mapper.Reset();
        var groupToUpdate = await UnitOfWork.Repository<GroupEntity>().GetById(group.Id);
        if (groupToUpdate == null) return null;

        var groupEntitySource = group.ToEntity();

        foreach (var property in typeof(GroupEntity).GetProperties()
                     .Where(p => p.CanWrite && p.Name != nameof(GroupEntity.Id)))
            property.SetValue(groupToUpdate, property.GetValue(groupEntitySource));

        groupToUpdate.Players =
            groupToUpdate.Players.Select(p => UnitOfWork.Repository<PlayerEntity>().GetById(p.Id).Result!).ToHashSet();

        var result = await UnitOfWork.Repository<GroupEntity>().Update(groupToUpdate);

        await UnitOfWork.SaveChangesAsync();

        return result.ToModel();
    }

    public async Task<bool> DeleteGroup(ulong groupId)
    {
        var result = await UnitOfWork.Repository<GroupEntity>().Delete(groupId);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }

    public async Task<bool> DeleteGroup(Group group) => await DeleteGroup(group.Id);
}