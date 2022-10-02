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
        foreach (var props in typeof(EnumsMapper).GetProperties())
        {
            if (props.PropertyType == typeof(EnumsMapper<TModel, TEntity>))
            {
                return (props.GetValue(null) as EnumsMapper<TModel, TEntity>)!.GetEntity(model);
            }
        }

        return default!;
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
        foreach (var props in typeof(EnumsMapper).GetProperties())
        {
            if (props.PropertyType == typeof(EnumsMapper<TModel, TEntity>))
            {
                return (props.GetValue(null) as EnumsMapper<TModel, TEntity>)!.GetModel(entity);
            }
        }

        return default!;
    }
    
    /// <summary>
    /// Bidding version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.Bidding ToEntity(this Model.enums.Bidding model) 
        => ToEntity<Model.enums.Bidding, TarotDB.enums.Bidding>(model);
    
    /// <summary>
    /// Chelem version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.Chelem ToEntity(this Model.enums.Chelem model)
        => ToEntity<Model.enums.Chelem, TarotDB.enums.Chelem>(model);
    
    /// <summary>
    /// PetitResult version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.PetitResult ToEntity(this Model.enums.PetitResult model)
        => ToEntity<Model.enums.PetitResult, TarotDB.enums.PetitResult>(model);

    /// <summary>
    /// Poignee version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.Poignee ToEntity(this Model.enums.Poignee model)
        => ToEntity<Model.enums.Poignee, TarotDB.enums.Poignee>(model);
    /// <summary>
    /// Bidding version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Bidding ToModel(this TarotDB.enums.Bidding entity) 
        => ToModel<Model.enums.Bidding, TarotDB.enums.Bidding>(entity);
    
    /// <summary>
    /// Chelem version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Chelem ToModel(this TarotDB.enums.Chelem entity) 
        => ToModel<Model.enums.Chelem, TarotDB.enums.Chelem>(entity);
    
    /// <summary>
    /// PetitResult version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.PetitResult ToModel(this TarotDB.enums.PetitResult entity) 
        => ToModel<Model.enums.PetitResult, TarotDB.enums.PetitResult>(entity);
    
    /// <summary>
    /// Poignee version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Poignee ToModel(this TarotDB.enums.Poignee entity) 
        => ToModel<Model.enums.Poignee, TarotDB.enums.Poignee>(entity);
}