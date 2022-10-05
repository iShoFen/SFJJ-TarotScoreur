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
    /// BiddingDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.BiddingDB ToEntity(this Model.enums.Bidding model) 
        => ToEntity<Model.enums.Bidding, TarotDB.enums.BiddingDB>(model);
    
    /// <summary>
    /// ChelemDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.ChelemDB ToEntity(this Model.enums.Chelem model)
        => ToEntity<Model.enums.Chelem, TarotDB.enums.ChelemDB>(model);
    
    /// <summary>
    /// PetitResultDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.PetitResultDB ToEntity(this Model.enums.PetitResult model)
        => ToEntity<Model.enums.PetitResult, TarotDB.enums.PetitResultDB>(model);

    /// <summary>
    /// PoigneeDB version of ToEntity
    /// </summary>
    /// <param name="model"> The model </param>
    /// <returns> The entity </returns>
    public static TarotDB.enums.PoigneeDB ToEntity(this Model.enums.Poignee model)
        => ToEntity<Model.enums.Poignee, TarotDB.enums.PoigneeDB>(model);
    /// <summary>
    /// BiddingDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Bidding ToModel(this TarotDB.enums.BiddingDB entity) 
        => ToModel<Model.enums.Bidding, TarotDB.enums.BiddingDB>(entity);
    
    /// <summary>
    /// ChelemDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Chelem ToModel(this TarotDB.enums.ChelemDB entity) 
        => ToModel<Model.enums.Chelem, TarotDB.enums.ChelemDB>(entity);
    
    /// <summary>
    /// PetitResultDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.PetitResult ToModel(this TarotDB.enums.PetitResultDB entity) 
        => ToModel<Model.enums.PetitResult, TarotDB.enums.PetitResultDB>(entity);
    
    /// <summary>
    /// PoigneeDB version of ToModel
    /// </summary>
    /// <param name="entity"> The entity </param>
    /// <returns> The model </returns>
    public static Model.enums.Poignee ToModel(this TarotDB.enums.PoigneeDB entity) 
        => ToModel<Model.enums.Poignee, TarotDB.enums.PoigneeDB>(entity);
}