using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Tarot2B2Model;
using TarotDB;
using Xunit;

namespace UT_Tarot2B2Model;

public class UT_UserExtension
{
    public static IEnumerable<object[]> Data_AddUserAndUserEntity()
    {
        yield return new object[]
        {
            new User(0UL,"Jean", "BON", "JEBO", "avatar1", "user1@gmail.com", "password1"),
            new UserEntity
            {
                Id = 0UL,
                FirstName = "Jean",
                LastName = "BON",
                Nickname = "JEBO",
                Avatar = "avatar1",
                Email = "user1@gmail.com",
                Password = "password1"
            }
        };
    }

    public static IEnumerable<object[]> Data_AddUsersAndUserEntities()
    {
        yield return new object[]
        {
            new List<User>
            {
                new (0UL,"Jean","BON","JEBO","avatar1","user1@gmail.com","password1"),
                new (1UL, "Michel", "Sardou", "MichelSardou", "avatar2", "michel.sardou@gmail.com", "michelSardou47"),
                new (2UL, "Brigitte", "Bardot", "BrigitteBardot", "avatar3", "brigitte.bardot@orange.fr", "sauverLesAnimaux22")
                
            },
            new List<UserEntity>
            {
                new()
                {
                    Id = 0UL,
                    FirstName = "Jean",
                    LastName = "BON",
                    Nickname = "JEBO",
                    Avatar = "avatar1",
                    Email = "user1@gmail.com",
                    Password = "password1"
                },
                new()
                {
                    Id = 1UL,
                    FirstName = "Michel",
                    LastName = "Sardou",
                    Nickname = "MichelSardou",
                    Avatar = "avatar2",
                    Email = "michel.sardou@gmail.com",
                    Password = "michelSardou47"

                },
                new()
                {
                    Id = 2UL,
                    FirstName = "Brigitte",
                    LastName = "Bardot",
                    Nickname = "BrigitteBardot",
                    Avatar = "avatar3",
                    Email = "brigitte.bardot@orange.fr",
                    Password = "sauverLesAnimaux22"
                }
            }
        };
    }



    [Theory]
    [MemberData(nameof(Data_AddUserAndUserEntity))]
    internal void TestUserEntityToModel(User user, UserEntity userEntity)
    {
        var userEntityToModel = userEntity.ToModel();
        Assert.Equal(user, userEntityToModel);

        Assert.Same(userEntity.ToModel(), userEntityToModel);
    }


    [Theory]
    [MemberData(nameof(Data_AddUserAndUserEntity))]
    internal void TestUserToEntity(User user, UserEntity userEntity)
    {
        var userToEntity = user.ToEntity();
        Assert.Equal(userEntity.Id, userToEntity.Id);
        Assert.Equal(userEntity.FirstName, userToEntity.FirstName);
        Assert.Equal(userEntity.LastName, userToEntity.LastName);
        Assert.Equal(userEntity.Nickname, userToEntity.Nickname);
        Assert.Equal(userEntity.Avatar, userToEntity.Avatar);
        Assert.Equal(userEntity.Email, userToEntity.Email);
        Assert.Equal(userEntity.Password, userToEntity.Password);

        Assert.Same(userToEntity, user.ToEntity());
    }

    [Theory]
    [MemberData(nameof(Data_AddUsersAndUserEntities))]
    internal void TestUserEntitiesToModel(List<User> users, List<UserEntity> userEntities)
    {
        var userEntitiesToModel = userEntities.ToModels().ToList();
        Assert.Equal(users,userEntitiesToModel);

        var i = 0;
        foreach (var userEntity in userEntities)
        {
            Assert.Same(userEntity.ToModel(), userEntitiesToModel[i]);
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(Data_AddUsersAndUserEntities))]
    internal void TestUserToEntities(List<User> users, List<UserEntity> userEntities)
    {
        var userToEntities = users.ToEntities().ToList();
        var i = 0;
        foreach (var userEntity in userToEntities)
        {
            Assert.Equal(userEntity.Id, userEntities[i].Id);
            Assert.Equal(userEntity.FirstName, userEntities[i].FirstName);
            Assert.Equal(userEntity.LastName, userEntities[i].LastName);
            Assert.Equal(userEntity.Nickname, userEntities[i].Nickname);
            Assert.Equal(userEntity.Avatar, userEntities[i].Avatar);
            Assert.Equal(userEntity.Email, userEntities[i].Email);
            Assert.Equal(userEntity.Password, userEntities[i].Password);
            ++i;
        }

        i = 0;
        foreach (var user in users)
        {
            Assert.Same(user.ToEntity(), userToEntities[i]);
            ++i;
        }

    }

}

