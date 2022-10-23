using Model.enums;
using TarotDB.enums;

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
    /// The mapper for the BiddingDB
    /// </summary>
    public static EnumsMapper<Bidding, BiddingDB> BiddingMapper { get; } = new(
        (Bidding.Unknown, BiddingDB.Unknown),
        (Bidding.Prise, BiddingDB.Prise),
        (Bidding.Petite, BiddingDB.Petite),
        (Bidding.Garde, BiddingDB.Garde),
        (Bidding.GardeSansLeChien, BiddingDB.GardeSansLeChien),
        (Bidding.GardeContreLeChien, BiddingDB.GardeContreLeChien),
        (Bidding.Opponent, BiddingDB.Opponent),
        (Bidding.King, BiddingDB.King)
        );
    
    /// <summary>
    /// The mapper for the ChelemDB
    /// </summary>
    public static EnumsMapper<Chelem, ChelemDB> ChelemMapper { get; } = new(
        (Chelem.Unknown, ChelemDB.Unknown),
        (Chelem.Announced, ChelemDB.Announced),
        (Chelem.Success, ChelemDB.Success),
        (Chelem.Fail, ChelemDB.Fail),
        (Chelem.NotAnnouncedSuccess, ChelemDB.NotAnnouncedSuccess),
        (Chelem.AnnouncedSuccess, ChelemDB.AnnouncedSuccess),
        (Chelem.AnnouncedFail, ChelemDB.AnnouncedFail)
        );
        
    /// <summary>
    /// The mapper for the PetitResultDB
    /// </summary>
    public static EnumsMapper<PetitResult, PetitResultDB> PetitResultMapper { get; } = new(
        (PetitResult.Unknown, PetitResultDB.Unknown),
        (PetitResult.Owned, PetitResultDB.Owned),
        (PetitResult.NotOwned, PetitResultDB.NotOwned),
        (PetitResult.Lost, PetitResultDB.Lost),
        (PetitResult.AuBout, PetitResultDB.AuBout),
        (PetitResult.AuBoutOwned, PetitResultDB.AuBoutOwned),
        (PetitResult.LostAuBout, PetitResultDB.LostAuBout)
        );
    
    /// <summary>
    /// The mapper for the PoigneeDB
    /// </summary>
    public static EnumsMapper<Poignee, PoigneeDB> PoigneeMapper { get; } = new(
        (Poignee.None, PoigneeDB.None),
        (Poignee.Simple, PoigneeDB.Simple),
        (Poignee.Double, PoigneeDB.Double),
        (Poignee.Triple, PoigneeDB.Triple)
        );
}