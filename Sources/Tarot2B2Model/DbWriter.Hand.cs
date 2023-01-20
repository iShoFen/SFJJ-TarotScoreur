using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<Hand?> InsertHand(Game game, Hand hand)
    {
        if (hand.Id != 0) return null;
        Mapper.Reset();

        var gameEntity = await UnitOfWork.Repository<GameEntity>().GetById(game.Id);
        if (gameEntity == null) return null;
        
        var handToInsert = hand.ToEntity();
        handToInsert.Game = gameEntity;

        var isValid = gameEntity.Hands.All(h => h.Number != handToInsert.Number);
        if (!isValid) return null;
        
        foreach (var biddingEntity in handToInsert.Biddings)
        {
            var playerEntity = await UnitOfWork.Repository<PlayerEntity>().GetById(biddingEntity.Player.Id);
            if (playerEntity == null) return null;
            biddingEntity.Player = playerEntity;
        }

        var result = await UnitOfWork.Repository<HandEntity>().Insert(handToInsert);

        await UnitOfWork.SaveChangesAsync();

        Mapper.Reset();
        return result.ToModel();
    }

    public async Task<Hand?> UpdateHand(Hand hand)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteHand(ulong handId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteHand(Hand hand)
    {
        throw new NotImplementedException();
    }
}