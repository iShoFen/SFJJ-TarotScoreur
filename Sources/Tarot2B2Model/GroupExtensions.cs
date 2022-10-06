using Model;
using TarotDB;

namespace Tarot2B2Model;

internal static class GroupExtensions
{
    /// <summary>
    /// Converts a Group to a GroupEntity thanks to extension method
    /// </summary>
    /// <param name="group">Group to convert into GroupEntity</param>
    /// <returns>GroupEntity converted</returns>
    public static GroupEntity ToEntity(this Group group)
    {
        var groupEntity = Mapper.GroupsMapper.GetEntity(group);
        if (groupEntity is not null) return groupEntity;
        groupEntity = new GroupEntity
        {
            Id = group.Id,
            Name = group.Name,
            Players = group.Players.ToEntities().ToHashSet()
        };

        Mapper.GroupsMapper.Map(group, groupEntity);

        return groupEntity;
    }

    /// <summary>
    /// Converts a PlayerEntity to a Player thanks to extension method
    /// </summary>
    /// <param name="groupEntity">GroupEntity to convert into Group</param>
    /// <returns>Group converted</returns>
    public static Group ToModel(this GroupEntity groupEntity)
    {
        var groupModel = Mapper.GroupsMapper.GetModel(groupEntity);
        if (groupModel is not null) return groupModel;
        groupModel = new Group(groupEntity.Id, groupEntity.Name, groupEntity.Players.ToModels().ToArray());

        Mapper.GroupsMapper.Map(groupModel, groupEntity);

        return groupModel;
    }

    /// <summary>
    /// Converts a collection of Group to a collection of GroupEntity thanks to extension method
    /// </summary>
    /// <param name="groups">Collection of Group to convert</param>
    /// <returns>Collection of GroupEntity converted</returns>
    public static IEnumerable<GroupEntity> ToEntities(this IEnumerable<Group> groups)
        => groups.Select(g => g.ToEntity());
    
    /// <summary>
    /// Converts a collection of GroupEntity to a collection of Group thanks to extension method
    /// </summary>
    /// <param name="entities">Collection of GroupEntity to convert</param>
    /// <returns>Collection of Group converted</returns>
    public static IEnumerable<Group> ToModels(this IEnumerable<GroupEntity> entities)
        => entities.Select(e => e.ToModel());
}