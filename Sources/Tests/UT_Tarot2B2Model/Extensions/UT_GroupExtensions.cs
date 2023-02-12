using Model.Players;
using Tarot2B2Model;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using UT_Tarot2B2Model.Extensions.DataTest;
using Xunit;

namespace UT_Tarot2B2Model.Extensions;

public class UT_GroupExtensions
{

    [Theory] 
    [MemberData(nameof(GroupExtensionsDataTest.GroupAndGroupEntity), MemberType = typeof(GroupExtensionsDataTest))]
    internal void TestGroupEntityToModel(Group group, GroupEntity groupEntity)
    {
        Mapper.Reset();
        var groupEntityToModel = groupEntity.ToModel();
        Assert.Equal(group, groupEntityToModel);
        //Use the mapper
        Assert.Same(groupEntity.ToModel(), groupEntityToModel);
        Mapper.Reset();
        Assert.NotSame(groupEntity.ToModel(), groupEntityToModel);

    }

    [Theory]
    [MemberData(nameof(GroupExtensionsDataTest.GroupAndGroupEntity), MemberType = typeof(GroupExtensionsDataTest))]
    internal void TestGroupToEntity(Group group, GroupEntity groupEntity)
    {
        Mapper.Reset();
        var groupToEntity = group.ToEntity();
        Assert.Equal(groupEntity.Id, groupToEntity.Id);
        Assert.Equal(groupEntity.Name, groupToEntity.Name);
        var i = 0;
        foreach (var player in group.Players)
        {
            Assert.Equal(player.Id, groupToEntity.Players.ElementAt(i).Id);
            Assert.Equal(player.FirstName, groupToEntity.Players.ElementAt(i).FirstName);
            Assert.Equal(player.LastName, groupToEntity.Players.ElementAt(i).LastName);
            Assert.Equal(player.NickName, groupToEntity.Players.ElementAt(i).Nickname);
            Assert.Equal(player.Avatar, groupToEntity.Players.ElementAt(i).Avatar);
            i++;
        }
        //Use the mapper
        Assert.Same(group.ToEntity(), groupToEntity);
        Mapper.Reset();
        Assert.NotSame(group.ToEntity(), groupToEntity);
    }

    [Theory]
    [MemberData(nameof(GroupExtensionsDataTest.GroupsAndGroupEntities), MemberType = typeof(GroupExtensionsDataTest))]
    internal void TestGroupEntitiesToModels(List<Group> groups, List<GroupEntity> groupEntities)
    {
        Mapper.Reset();
        var groupEntitiesToModels = groupEntities.ToModels().ToList();
        Assert.Equal(groups, groupEntitiesToModels);
        //Use the mapper
        var i = 0;
        foreach (var groupEntity in groupEntities)
        {
            Assert.Same(groupEntity.ToModel(), groupEntitiesToModels.ElementAt(i));
            ++i;
        }
        
        Mapper.Reset();
        i = 0;
        foreach (var groupEntity in groupEntities)
        {
            Assert.NotSame(groupEntity.ToModel(), groupEntitiesToModels.ElementAt(i));
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(GroupExtensionsDataTest.GroupsAndGroupEntities), MemberType = typeof(GroupExtensionsDataTest))]
    internal void TestGroupsToEntities(List<Group> groups, List<GroupEntity> groupEntities)
    {
        Mapper.Reset();
        var groupsToEntities = groups.ToEntities().ToList();
        Assert.Equal(groupEntities.Count, groupsToEntities.Count);
        var i = 0;
        foreach (var group in groups)
        {
            Assert.Equal(group.Id, groupsToEntities.ElementAt(i).Id);
            Assert.Equal(group.Name, groupsToEntities.ElementAt(i).Name);
            var j = 0;
            foreach (var player in group.Players)
            {
                Assert.Equal(player.Id, groupsToEntities.ElementAt(i).Players.ElementAt(j).Id);
                Assert.Equal(player.FirstName, groupsToEntities.ElementAt(i).Players.ElementAt(j).FirstName);
                Assert.Equal(player.LastName, groupsToEntities.ElementAt(i).Players.ElementAt(j).LastName);
                Assert.Equal(player.NickName, groupsToEntities.ElementAt(i).Players.ElementAt(j).Nickname);
                Assert.Equal(player.Avatar, groupsToEntities.ElementAt(i).Players.ElementAt(j).Avatar);
                ++j;
            }
            ++i;
        }
        //Use the mapper
        i = 0;
        foreach (var group in groups)
        {
            Assert.Same(group.ToEntity(), groupsToEntities.ElementAt(i));
            ++i;
        }
        
        Mapper.Reset();
        i = 0;
        foreach (var group in groups)
        {
            Assert.NotSame(group.ToEntity(), groupsToEntities.ElementAt(i));
            ++i;
        }
    }
}
