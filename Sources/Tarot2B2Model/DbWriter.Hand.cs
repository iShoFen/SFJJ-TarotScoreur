using Microsoft.EntityFrameworkCore;
using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbWriter
{
    public async Task<Hand?> InsertHand(ulong gameId, Hand hand)
    {
        if (hand.Id != 0) return null;
        Mapper.Reset();

        var gameEntity = await UnitOfWork.Repository<GameEntity>()
            .Set
            .Include(g => g.Hands)
            .FirstOrDefaultAsync(g => g.Id == gameId);
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
        Mapper.Reset();

        var handToUpdate = await UnitOfWork.Repository<HandEntity>()
            .Set
            .Include(h => h.Biddings)
            .ThenInclude(b => b.Player)
            .FirstOrDefaultAsync(h => h.Id == hand.Id);
        if (handToUpdate == null) return null;

        var handEntitySource = hand.ToEntity();

        var biddingsToDelete = handToUpdate.Biddings.Except(handEntitySource.Biddings, BiddingPoigneeEntity.Comparer);

        var biddingsToAdd = handEntitySource.Biddings.Except(handToUpdate.Biddings, BiddingPoigneeEntity.Comparer);

        foreach (var bpe in handToUpdate.Biddings) UnitOfWork.Context.Entry(bpe).State = EntityState.Detached;
        foreach (var bpe in biddingsToDelete) UnitOfWork.Context.Entry(bpe).State = EntityState.Deleted;
        foreach (var bpe in biddingsToAdd) UnitOfWork.Context.Entry(bpe).State = EntityState.Added;

        foreach (var property in typeof(HandEntity).GetProperties()
                     .Where(p => p.Name != nameof(HandEntity.Id)))
        {
            property.SetValue(handToUpdate, property.GetValue(handEntitySource));
        }

        var result = await UnitOfWork.Repository<HandEntity>().Update(handToUpdate);

        await UnitOfWork.SaveChangesAsync();

        return result.ToModel();
    }

    public async Task<bool> DeleteHand(ulong handId)
    {
        var result = await UnitOfWork.Repository<HandEntity>().Delete(handId);

        if (result)
        {
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        await UnitOfWork.RejectChangesAsync();
        return false;
    }

    public async Task<bool> DeleteHand(Hand hand)
        => await DeleteHand(hand.Id);
}