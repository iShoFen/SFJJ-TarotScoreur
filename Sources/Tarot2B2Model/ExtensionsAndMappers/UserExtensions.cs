using Model.Players;
using TarotDB;

namespace Tarot2B2Model.ExtensionsAndMappers;

internal static class UserExtensions
{
    /// <summary>
    /// Converts a User to a UserEntity thanks to extension method.
    /// </summary>
    /// <param name="model">User to convert into a UserEntity</param>
    /// <returns>UserEntity converted</returns>
    public static UserEntity ToEntity(this User model)
    {
        var entity = Mapper.UsersMapper.GetEntity(model);
        if (entity is not null) return entity;

        entity = new UserEntity
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Nickname = model.NickName,
            Avatar = model.Avatar,
            Email = model.Email,
            Password = model.Password
        };

        Mapper.UsersMapper.Map(model, entity);

        return entity;
    }

    /// <summary>
    /// Converts UserEntity to User thanks to extension method.
    /// </summary>
    /// <param name="entity">UserEntity to convert into User</param>
    /// <returns>User converted</returns>
    public static User ToModel(this UserEntity entity)
    {
        var model = Mapper.UsersMapper.GetModel(entity);
        if (model is not null) return model;

        model = new User(entity.Id, entity.FirstName, entity.LastName, entity.Nickname, entity.Avatar, entity.Email,
            entity.Password);

        Mapper.UsersMapper.Map(model, entity);

        return model;
    }

    /// <summary>
    /// Converts a collection of User to a collection of UserEntity thanks to extension method.
    /// </summary>
    /// <param name="entities">Collection of User to convert</param>
    /// <returns>Collection of UserEntity converted</returns>
    public static IEnumerable<UserEntity> ToEntities(this IEnumerable<User> entities) => entities.Select(ToEntity);

    /// <summary>
    /// Converts a collection of UserEntity to a collection of User thanks to extension method
    /// </summary>
    /// <param name="entities">Collection of UserEntity to convert</param>
    /// <returns>Collection of User converted</returns>
    public static IEnumerable<User> ToModels(this IEnumerable<UserEntity> entities) => entities.Select(ToModel);
}