using Model.enums;
using TarotDB.enums;

namespace Tarot2B2Model;

/// <summary>
/// A static class to hold all extension methods for the enums in the model
/// </summary>
internal static class EnumsExtensions
{
    /// <summary>
    /// Generic method to get the entity from the model
    /// </summary>
    /// <param name="model"> The model </param>
    /// <typeparam name="TModel"> The model type </typeparam>
    /// <typeparam name="TEntity"> The entity type </typeparam>
    /// <returns> The entity </returns>
    private static TEntity ToEntity<TModel, TEntity>(this TModel model) where TModel : Enum 
                                                                       where TEntity : Enum
    {
	    TEntity result = default!;
	    foreach (var props in typeof(EnumsMapper).GetProperties())
        {
            if (props.PropertyType == typeof(EnumsMapper<TModel, TEntity>))
            {
                result = (props.GetValue(null) as EnumsMapper<TModel, TEntity>)!.GetEntity(model);
            }
        }

        return result;
    }
    
    /// <summary>
    /// Generic method to get the model from the entity
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <typeparam name="TModel"> The model type </typeparam>
    /// <typeparam name="TEntity"> The entity type </typeparam>
    /// <returns> The model </returns>
    private static TModel ToModel<TModel, TEntity>(this TEntity entity) where TModel : Enum 
        where TEntity : Enum
    {
	    TModel result = default!;
        foreach (var props in typeof(EnumsMapper).GetProperties())
        {
            if (props.PropertyType == typeof(EnumsMapper<TModel, TEntity>))
            {
                result = (props.GetValue(null) as EnumsMapper<TModel, TEntity>)!.GetModel(entity);
            }
        }

        return result;
    }
    
    /// <summary>
    /// BiddingDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static BiddingDB ToEntity(this Bidding model) 
        => ToEntity<Bidding, BiddingDB>(model);
    
    /// <summary>
    /// ChelemDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static ChelemDB ToEntity(this Chelem model)
        => ToEntity<Chelem, ChelemDB>(model);
    
    /// <summary>
    /// PetitResultDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static PetitResultDB ToEntity(this PetitResult model)
        => ToEntity<PetitResult, PetitResultDB>(model);

    /// <summary>
    /// PoigneeDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static PoigneeDB ToEntity(this Poignee model)
        => ToEntity<Poignee, PoigneeDB>(model);
    /// <summary>
    /// BiddingDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Bidding ToModel(this BiddingDB entity) 
        => ToModel<Bidding, BiddingDB>(entity);
    
    /// <summary>
    /// ChelemDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Chelem ToModel(this ChelemDB entity) 
        => ToModel<Chelem, ChelemDB>(entity);
    
    /// <summary>
    /// PetitResultDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static PetitResult ToModel(this PetitResultDB entity) 
        => ToModel<PetitResult, PetitResultDB>(entity);
    
    /// <summary>
    /// PoigneeDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Poignee ToModel(this PoigneeDB entity) 
        => ToModel<Poignee, PoigneeDB>(entity);
}