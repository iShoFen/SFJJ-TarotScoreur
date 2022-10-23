using Model;
using TarotDB;

namespace Tarot2B2Model;

static class UserExtensions
{
    /// <summary>
    /// Converts a User to a UserEntity thanks to extension method
    /// </summary>
    /// <param name="user">User to convert into a UserEntity</param>
    /// <returns>UserEntity converted</returns>
    public static UserEntity ToEntity(this User user)
    {
        var userEntity = Mapper.UsersMapper.GetEntity(user);
        if (userEntity is not null) return userEntity;
        userEntity = new UserEntity
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Nickname = user.NickName,
            Avatar = user.Avatar,
            Email = user.Email,
            Password = user.Password
        };

        Mapper.UsersMapper.Map(user, userEntity);

        return userEntity;
    }

    /// <summary>
    /// Converts UserEntity to User thanks to extension method
    /// </summary>
    /// <param name="entity">UserEntity to convert into User</param>
    /// <returns>User converted</returns>
    public static User ToModel(this UserEntity entity)
    {
        var userModel = Mapper.UsersMapper.GetModel(entity);
        if (userModel is not null) return userModel;
        userModel = new User(entity.Id, entity.FirstName, entity.LastName, entity.Nickname, entity.Avatar, entity.Email, entity.Password);
        
        Mapper.UsersMapper.Map(userModel, entity);

        return userModel;
    }

    /// <summary>
    /// Converts a collection of User to a collection of UserEntity thanks to extension method
    /// </summary>
    /// <param name="entities">Collection of User to convert</param>
    /// <returns>Collection of UserEntity converted</returns>
    public static IEnumerable<UserEntity> ToEntities(this IEnumerable<User> entities)
        => entities.Select(e => e.ToEntity());

    /// <summary>
    /// Converts a collection of UserEntity to a collection of User thanks to extension method
    /// </summary>
    /// <param name="entities">Collection of UserEntity to convert</param>
    /// <returns>Collection of User converted</returns>
    public static IEnumerable<User> ToModels(this IEnumerable<UserEntity> entities)
        => entities.Select(e => e.ToModel());
}