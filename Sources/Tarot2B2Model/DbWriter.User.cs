using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<User?> InsertUser(User user)
    {
        if (user.Id != 0) return null;
        Mapper.Reset();

        var result = await UnitOfWork.Repository<UserEntity>().Insert(user.ToEntity());

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<User?> UpdateUser(User user)
    {
        Mapper.Reset();
        var userToUpdate = await UnitOfWork.Repository<UserEntity>().GetById(user.Id);
        if (userToUpdate == null) return null;

        var userEntitySource = user.ToEntity();

        foreach (var property in typeof(UserEntity).GetProperties()
                                                     .Where(p => p.Name != nameof(UserEntity.Id)))
        {
            property.SetValue(userToUpdate, property.GetValue(userEntitySource));
        }

        var result = await UnitOfWork.Repository<UserEntity>().Update(userToUpdate);

        await UnitOfWork.SaveChangesAsync();

        return result.ToModel();
    }

    public async Task<bool> DeleteUser(ulong userId)
    {
        var result = await UnitOfWork.Repository<UserEntity>().Delete(userId);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }

    public async Task<bool> DeleteUser(User user) => await DeleteUser(user.Id);
}
