using Model.Players;
using TarotDB;

namespace Tarot2B2Model.ExtensionsAndMappers;

internal static class GroupExtensions
{
    /// <summary>
    /// Converts a Group to a GroupEntity thanks to extension method.
    /// </summary>
    /// <param name="group">Group to convert into GroupEntity</param>
    /// <returns>GroupEntity converted</returns>
    public static GroupEntity ToEntity(this Group group)
    {
        var entity = Mapper.GroupsMapper.GetEntity(group);
        if (entity is not null) return entity;

        entity = new GroupEntity
        {
            Id = group.Id,
            Name = group.Name,
            Players = group.Players.ToEntities().ToHashSet()
        };

        Mapper.GroupsMapper.Map(group, entity);

        return entity;
    }

    /// <summary>
    /// Converts a GroupEntity to a Group thanks to extension method
    /// </summary>
    /// <param name="entity">GroupEntity to convert into Group</param>
    /// <returns>Group converted</returns>
    public static Group ToModel(this GroupEntity entity)
    {
        var model = Mapper.GroupsMapper.GetModel(entity);
        if (model is not null) return model;

        model = new Group(entity.Id, entity.Name, entity.Players.ToModels().ToArray());

        Mapper.GroupsMapper.Map(model, entity);

        return model;
    }

    /// <summary>
    /// Converts a collection of Group to a collection of GroupEntity thanks to extension method
    /// </summary>
    /// <param name="groups">Collection of Group to convert</param>
    /// <returns>Collection of GroupEntity converted</returns>
    public static IEnumerable<GroupEntity> ToEntities(this IEnumerable<Group> groups) =>
        groups.Select(g => g.ToEntity());

    /// <summary>
    /// Converts a collection of GroupEntity to a collection of Group thanks to extension method
    /// </summary>
    /// <param name="entities">Collection of GroupEntity to convert</param>
    /// <returns>Collection of Group converted</returns>
    public static IEnumerable<Group> ToModels(this IEnumerable<GroupEntity> entities) =>
        entities.Select(e => e.ToModel());
}