using Model.Games;
using Model.Rules;
using TarotDB;

namespace Tarot2B2Model.ExtensionsAndMappers;

/// <summary>
/// Extension methods for the Hand and HandEntity classes.
/// </summary>
internal static class HandExtensions
{
    /// <summary>
    /// Converts a Hand to a HandEntity.
    /// </summary>
    /// <param name="model"> The Hand </param>
    /// <returns> The HandEntity </returns>
    public static HandEntity ToEntity(this Hand model)
    {
        var entity = Mapper.HandsMapper.GetEntity(model);

        if (entity is not null) return entity;
        entity = new HandEntity
        {
            Id = model.Id,
            Number = model.Number,
            Rules = model.Rules.Name,
            Date = model.Date,
            TakerScore = model.TakerScore,
            TwentyOne = model.TwentyOne,
            Excuse = model.Excuse,
            Petit = model.Petit.ToEntity(),
            Chelem = model.Chelem.ToEntity()
        };

        entity.Biddings = model.Biddings.Select(kv => new BiddingPoigneeEntity
        {
            Biddings = kv.Value.Item1.ToEntity(),
            Poignee = kv.Value.Item2.ToEntity(),
            Hand = entity,
            Player = kv.Key.ToEntity()
        }).ToHashSet();

        Mapper.HandsMapper.Map(model, entity);

        return entity;
    }

    /// <summary>
    /// Converts a HandEntity to a Hand.
    /// </summary>
    /// <param name="entity"> The HandEntity </param>
    /// <returns> The Hand </returns>
    public static Hand ToModel(this HandEntity entity)
    {
        var hand = Mapper.HandsMapper.GetModel(entity);

        if (hand is not null) return hand;
        hand = new Hand(
            entity.Id,
            entity.Number,
            RulesFactory.Create(entity.Rules)!,
            entity.Date,
            entity.TakerScore,
            entity.TwentyOne,
            entity.Excuse,
            entity.Petit.ToModel(),
            entity.Chelem.ToModel(),
            entity.Biddings.ToDictionary(
                bidding => bidding.Player.ToModel(),
                bidding => (bidding.Biddings.ToModel(), bidding.Poignee.ToModel())
            ).ToArray()
        );

        Mapper.HandsMapper.Map(hand, entity);

        return hand;
    }

    /// <summary>
    /// Converts a collections of Hand to a collections of HandEntity.
    /// </summary>
    /// <param name="models"> The collections of Hand </param>
    /// <returns> The collections of HandEntity </returns>
    public static IEnumerable<HandEntity> ToEntities(this IEnumerable<Hand> models) => models.Select(ToEntity);

    /// <summary>
    /// Converts a collections of HandEntity to a collections of Hand.
    /// </summary>
    /// <param name="entities"> The collections of HandEntity </param>
    /// <returns> The collections of Hand </returns>
    public static IEnumerable<Hand> ToModels(this IEnumerable<HandEntity> entities) => entities.Select(ToModel);
}