using Model.Enums;
using TarotDB.Enums;

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
    public static BiddingsDb ToEntity(this Biddings model) 
        => ToEntity<Biddings, BiddingsDb>(model);
    
    /// <summary>
    /// ChelemDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static ChelemDb ToEntity(this Chelem model)
        => ToEntity<Chelem, ChelemDb>(model);
    
    /// <summary>
    /// PetitResultsDb version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static PetitResultsDb ToEntity(this PetitResults model)
        => ToEntity<PetitResults, PetitResultsDb>(model);

    /// <summary>
    /// PoigneeDb version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static PoigneeDb ToEntity(this Poignee model)
        => ToEntity<Poignee, PoigneeDb>(model);
    /// <summary>
    /// BiddingDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Biddings ToModel(this BiddingsDb entity) 
        => ToModel<Biddings, BiddingsDb>(entity);
    
    /// <summary>
    /// ChelemDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Chelem ToModel(this ChelemDb entity) 
        => ToModel<Chelem, ChelemDb>(entity);
    
    /// <summary>
    /// PetitResultsDb version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static PetitResults ToModel(this PetitResultsDb entity) 
        => ToModel<PetitResults, PetitResultsDb>(entity);
    
    /// <summary>
    /// PoigneeDb version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Poignee ToModel(this PoigneeDb entity) 
        => ToModel<Poignee, PoigneeDb>(entity);
}