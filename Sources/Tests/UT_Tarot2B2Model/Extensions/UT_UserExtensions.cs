using Model.Players;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using UT_Tarot2B2Model.Extensions.DataTest;
using Xunit;

namespace UT_Tarot2B2Model.Extensions;

public class UT_UserExtensions
{
    [Theory]
    [MemberData(nameof(UserExtensionsDataTest.UserAndUserEntity), MemberType = typeof(UserExtensionsDataTest))]
    internal void TestUserEntityToModel(User user, UserEntity userEntity)
    {
        Mapper.Reset();
        var model = userEntity.ToModel();
        Assert.Equal(user, model, User.UserFullComparer);

        // To force the mapper to be used
        Assert.Same(userEntity.ToModel(), model);
        Mapper.Reset();
        Assert.NotSame(userEntity.ToModel(), model);
    }

    [Theory]
    [MemberData(nameof(UserExtensionsDataTest.UserAndUserEntity), MemberType = typeof(UserExtensionsDataTest))]
    internal void TestUserToEntity(User user, UserEntity userEntity)
    {
        Mapper.Reset();
        var entity = user.ToEntity();

        Assert.Equal(userEntity.Id, entity.Id);
        Assert.Equal(userEntity.FirstName, entity.FirstName);
        Assert.Equal(userEntity.LastName, entity.LastName);
        Assert.Equal(userEntity.Nickname, entity.Nickname);
        Assert.Equal(userEntity.Avatar, entity.Avatar);
        Assert.Equal(userEntity.Email, entity.Email);
        Assert.Equal(userEntity.Password, entity.Password);
        
        Assert.Same(entity, user.ToEntity());
        Mapper.Reset();
        Assert.NotSame(entity, user.ToEntity());
    }

    [Theory]
    [MemberData(nameof(UserExtensionsDataTest.UsersAndUserEntities), MemberType = typeof(UserExtensionsDataTest))]
    internal void TestUserEntitiesToModels(List<User> users, List<UserEntity> userEntities)
    {
        Mapper.Reset();
        var models = userEntities.ToModels().ToList();
        Assert.Equal(users, models, User.UserFullComparer);

        //To force the mapper to be used
        var i = 0;
        foreach (var userEntity in userEntities)
        {
            Assert.Same(userEntity.ToModel(), models.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var userEntity in userEntities)
        {
            Assert.NotSame(userEntity.ToModel(), models.ElementAt(i));
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(UserExtensionsDataTest.UsersAndUserEntities), MemberType = typeof(UserExtensionsDataTest))]
    internal void TestUsersToEntities(List<User> users, List<UserEntity> userEntities)
    {
        Mapper.Reset();
        var entities = users.ToEntities().ToList();
        var i = 0;
        foreach (var entity in entities)
        {
            Assert.Equal(entity.Id, userEntities.ElementAt(i).Id);
            Assert.Equal(entity.FirstName, userEntities.ElementAt(i).FirstName);
            Assert.Equal(entity.LastName, userEntities.ElementAt(i).LastName);
            Assert.Equal(entity.Nickname, userEntities.ElementAt(i).Nickname);
            Assert.Equal(entity.Avatar, userEntities.ElementAt(i).Avatar);
            Assert.Equal(entity.Email, userEntities.ElementAt(i).Email);
            Assert.Equal(entity.Password, userEntities.ElementAt(i).Password);
            ++i;
        }

        //To force the mapper to be used
        i = 0;
        foreach (var user in users)
        {
            Assert.Same(user.ToEntity(), entities.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var user in users)
        {
            Assert.NotSame(user.ToEntity(), entities.ElementAt(i));
            ++i;
        }
    }
}