using Model.Games;
using Tarot2B2Model.ExtensionsAndMappers;
using TarotDB;
using UT_Tarot2B2Model.Extensions.DataTest;
using Xunit;

namespace UT_Tarot2B2Model.Extensions;

public class UT_HandExtensions
{

    [Theory]
    [MemberData(nameof(HandExtensionsDataTest.HandAndHandEntity), MemberType = typeof(HandExtensionsDataTest))]
    internal void TestHandEntityToModel(Hand hand, HandEntity handEntity)
    {
        Mapper.Reset();
        var result = handEntity.ToModel();
        Assert.Equal(hand, result);

        Assert.Same(handEntity.ToModel(), result);
        Mapper.Reset();
        Assert.NotSame(handEntity.ToModel(), actual: result);
    }

    [Theory]
    [MemberData(nameof(HandExtensionsDataTest.HandAndHandEntity), MemberType = typeof(HandExtensionsDataTest))]
    internal void TestHandToEntity(Hand hand, HandEntity handEntity)
    {
        Mapper.Reset();
        var result = hand.ToEntity();
        Assert.Equal(handEntity.Id, result.Id);
        Assert.Equal(handEntity.Rules, result.Rules);
        Assert.Equal(handEntity.Date, result.Date);
        Assert.Equal(handEntity.TakerScore, result.TakerScore);
        Assert.Equal(handEntity.TwentyOne, result.TwentyOne);
        Assert.Equal(handEntity.Excuse, result.Excuse);
        Assert.Equal(handEntity.Petit, result.Petit);
        Assert.Equal(handEntity.Chelem, result.Chelem);
        var i = 0;
        foreach (var biddingPoigneeEntity in handEntity.Biddings)
        {
            Assert.Equal(biddingPoigneeEntity.Player.Id, result.Biddings.ElementAt(i).Player.Id);
            Assert.Equal(biddingPoigneeEntity.Player.FirstName, result.Biddings.ElementAt(i).Player.FirstName);
            Assert.Equal(biddingPoigneeEntity.Player.LastName, result.Biddings.ElementAt(i).Player.LastName);
            Assert.Equal(biddingPoigneeEntity.Player.Nickname, result.Biddings.ElementAt(i).Player.Nickname);
            Assert.Equal(biddingPoigneeEntity.Player.Avatar, result.Biddings.ElementAt(i).Player.Avatar);
            Assert.Equal(biddingPoigneeEntity.Biddings, result.Biddings.ElementAt(i).Biddings);
            Assert.Equal(biddingPoigneeEntity.Poignee, result.Biddings.ElementAt(i).Poignee);
            ++i;
        }

        Assert.Same(result, hand.ToEntity());
        Mapper.Reset();
        Assert.NotSame(result, hand.ToEntity());
    }

    [Theory]
    [MemberData(nameof(HandExtensionsDataTest.HandsAndHandEntities), MemberType = typeof(HandExtensionsDataTest))]
    internal void TestHandsEntitiesToModels(List<Hand> hands, List<HandEntity> handsEntities)
    {
        Mapper.Reset();
        var result = handsEntities.ToModels().ToList();
        Assert.Equal(hands, result);
        var i = 0;
        foreach (var handEntity in handsEntities)
        {
            Assert.Same(handEntity.ToModel(), result.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var handEntity in handsEntities)
        {
            Assert.NotSame(handEntity.ToModel(), result.ElementAt(i));
            ++i;
        }
    }

    [Theory]
    [MemberData(nameof(HandExtensionsDataTest.HandsAndHandEntities), MemberType = typeof(HandExtensionsDataTest))]
    internal void TestHandsToEntities(List<Hand> hands, List<HandEntity> handsEntities)
    {
        Mapper.Reset();
        var result = hands.ToEntities().ToList();
        var i = 0;
        foreach (var handEntity in handsEntities)
        {
            Assert.Equal(handEntity.Id, result.ElementAt(i).Id);
            Assert.Equal(handEntity.Rules, result.ElementAt(i).Rules);
            Assert.Equal(handEntity.Date, result.ElementAt(i).Date);
            Assert.Equal(handEntity.TakerScore, result.ElementAt(i).TakerScore);
            Assert.Equal(handEntity.TwentyOne, result.ElementAt(i).TwentyOne);
            Assert.Equal(handEntity.Excuse, result.ElementAt(i).Excuse);
            Assert.Equal(handEntity.Petit, result.ElementAt(i).Petit);
            Assert.Equal(handEntity.Chelem, result.ElementAt(i).Chelem);
            ++i;
        }

        i = 0;
        foreach (var hand in hands)
        {
            Assert.Same(hand.ToEntity(), result.ElementAt(i));
            ++i;
        }

        Mapper.Reset();
        i = 0;
        foreach (var hand in hands)
        {
            Assert.NotSame(hand.ToEntity(), result.ElementAt(i));
            ++i;
        }
    }
}