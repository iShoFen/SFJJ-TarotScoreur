namespace Tarot2B2Model;

/// <summary>
/// A generic mapper for Model enums to Database enums
/// </summary>
/// <typeparam name="TModel"> The model type </typeparam>
/// <typeparam name="TEntity"> The entity type </typeparam>
internal class EnumsMapper<TModel, TEntity> where TModel : Enum 
                                            where TEntity : Enum
{
    /// <summary>
    /// The Model to Entity mappping
    /// </summary>
    private readonly HashSet<(TModel, TEntity)> _mapper = new();

    /// <summary>
    /// Get the Model from the Entity
    /// </summary>
    /// <param name="entity"> The Entity </param>
    /// <returns> The Model </returns>
    public TModel GetModel(TEntity entity) => _mapper.FirstOrDefault(x => x.Item2.Equals(entity)).Item1;

    /// <summary>
    /// Get the Entity from the Model
    /// </summary>
    /// <param name="model"> The Model </param>
    /// <returns> The Entity </returns>
    public TEntity GetEntity(TModel model) => _mapper.FirstOrDefault(x => x.Item1.Equals(model))!.Item2;
    
    /// <summary>
    /// Constructor for the mapper (add all the enums mapping)
    /// </summary>
    /// <param name="tuples"> The mapping </param>
    public EnumsMapper(params (TModel, TEntity)[] tuples) => _mapper.UnionWith(tuples);
}

/// <summary>
/// A static class to hold the mappers
/// </summary>
internal static class EnumsMapper
{
    /// <summary>
    /// The mapper for the Bidding
    /// </summary>
    public static EnumsMapper<Model.enums.Bidding, TarotDB.enums.Bidding> BiddingMapper { get; } = new(
        (Model.enums.Bidding.Unknown, TarotDB.enums.Bidding.Unknown),
        (Model.enums.Bidding.Prise, TarotDB.enums.Bidding.Prise),
        (Model.enums.Bidding.Petite, TarotDB.enums.Bidding.Petite),
        (Model.enums.Bidding.Garde, TarotDB.enums.Bidding.Garde),
        (Model.enums.Bidding.GardeSansLeChien, TarotDB.enums.Bidding.GardeSansLeChien),
        (Model.enums.Bidding.GardeContreLeChien, TarotDB.enums.Bidding.GardeContreLeChien),
        (Model.enums.Bidding.Opponent, TarotDB.enums.Bidding.Opponent),
        (Model.enums.Bidding.King, TarotDB.enums.Bidding.King)
        );
    
    /// <summary>
    /// The mapper for the Chelem
    /// </summary>
    public static EnumsMapper<Model.enums.Chelem, TarotDB.enums.Chelem> ChelemMapper { get; } = new(
        (Model.enums.Chelem.Unknown, TarotDB.enums.Chelem.Unknown),
        (Model.enums.Chelem.Announced, TarotDB.enums.Chelem.Announced),
        (Model.enums.Chelem.Success, TarotDB.enums.Chelem.Success),
        (Model.enums.Chelem.Fail, TarotDB.enums.Chelem.Fail),
        (Model.enums.Chelem.NotAnnouncedSuccess, TarotDB.enums.Chelem.NotAnnouncedSuccess),
        (Model.enums.Chelem.AnnouncedSuccess, TarotDB.enums.Chelem.AnnouncedSuccess),
        (Model.enums.Chelem.AnnouncedFail, TarotDB.enums.Chelem.AnnouncedFail)
        );
        
    /// <summary>
    /// The mapper for the PetitResult
    /// </summary>
    public static EnumsMapper<Model.enums.PetitResult, TarotDB.enums.PetitResult> PetitResultMapper { get; } = new(
        (Model.enums.PetitResult.Unknown, TarotDB.enums.PetitResult.Unknown),
        (Model.enums.PetitResult.Owned, TarotDB.enums.PetitResult.Owned),
        (Model.enums.PetitResult.NotOwned, TarotDB.enums.PetitResult.NotOwned),
        (Model.enums.PetitResult.AuBout, TarotDB.enums.PetitResult.AuBout),
        (Model.enums.PetitResult.AuBoutOwned, TarotDB.enums.PetitResult.AuBoutOwned),
        (Model.enums.PetitResult.LostAuBout, TarotDB.enums.PetitResult.LostAuBout)
        );
    
    /// <summary>
    /// The mapper for the Poignee
    /// </summary>
    public static EnumsMapper<Model.enums.Poignee, TarotDB.enums.Poignee> PoigneeMapper { get; } = new(
        (Model.enums.Poignee.None, TarotDB.enums.Poignee.None),
        (Model.enums.Poignee.Simple, TarotDB.enums.Poignee.Simple),
        (Model.enums.Poignee.Double, TarotDB.enums.Poignee.Double),
        (Model.enums.Poignee.Triple, TarotDB.enums.Poignee.Triple)
        );
}