using Model.Enums;
using TarotDB.Enums;

namespace Tarot2B2Model.ExtensionsAndMappers;

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
    public static EnumsMapper<Biddings, BiddingsDb> BiddingMapper { get; } = new(
        (Biddings.Unknown, BiddingsDb.Unknown),
        (Biddings.Prise, BiddingsDb.Prise),
        (Biddings.Petite, BiddingsDb.Petite),
        (Biddings.Garde, BiddingsDb.Garde),
        (Biddings.GardeSansLeChien, BiddingsDb.GardeSansLeChien),
        (Biddings.GardeContreLeChien, BiddingsDb.GardeContreLeChien),
        (Biddings.Opponent, BiddingsDb.Opponent),
        (Biddings.King, BiddingsDb.King)
        );
    
    /// <summary>
    /// The mapper for the ChelemDB
    /// </summary>
    public static EnumsMapper<Chelem, ChelemDb> ChelemMapper { get; } = new(
        (Chelem.Unknown, ChelemDb.Unknown),
        (Chelem.Announced, ChelemDb.Announced),
        (Chelem.Success, ChelemDb.Success),
        (Chelem.Fail, ChelemDb.Fail),
        (Chelem.NotAnnouncedSuccess, ChelemDb.NotAnnouncedSuccess),
        (Chelem.AnnouncedSuccess, ChelemDb.AnnouncedSuccess),
        (Chelem.AnnouncedFail, ChelemDb.AnnouncedFail)
        );
        
    /// <summary>
    /// The mapper for the PetitResultsDb
    /// </summary>
    public static EnumsMapper<PetitResults, PetitResultsDb> PetitResultMapper { get; } = new(
        (PetitResults.Unknown, PetitResultsDb.Unknown),
        (PetitResults.Owned, PetitResultsDb.Owned),
        (PetitResults.NotOwned, PetitResultsDb.NotOwned),
        (PetitResults.Lost, PetitResultsDb.Lost),
        (PetitResults.AuBout, PetitResultsDb.AuBout),
        (PetitResults.AuBoutOwned, PetitResultsDb.AuBoutOwned),
        (PetitResults.LostAuBout, PetitResultsDb.LostAuBout)
        );
    
    /// <summary>
    /// The mapper for the PoigneeDb
    /// </summary>
    public static EnumsMapper<Poignee, PoigneeDb> PoigneeMapper { get; } = new(
        (Poignee.None, PoigneeDb.None),
        (Poignee.Simple, PoigneeDb.Simple),
        (Poignee.Double, PoigneeDb.Double),
        (Poignee.Triple, PoigneeDb.Triple)
        );
}