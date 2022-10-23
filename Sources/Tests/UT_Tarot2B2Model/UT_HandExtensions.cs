using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.enums;
using Model.games;
using Tarot2B2Model;
using TarotDB;
using TarotDB.enums;
using Xunit;


namespace UT_Tarot2B2Model;
public class UT_HandExtensions
{

    public static IEnumerable<object[]> Data_AddHandAndHandEntity()
    {
        yield return new object[]
        {
            new Hand(1UL,
                1,
                new FrenchTarotRules(),
                new DateTime(2022, 09, 21),
                22,
                true,
                true,
                PetitResult.Lost,
                Chelem.Announced, 
                KeyValuePair.Create(
                    new Player(0UL,"Player1", "1Player", "1P1", "avatar1") , (Bidding.Garde, Poignee.None)
            )), 
            new HandEntity
            {
                Id = 1,
                Rules = "FrenchTarotRules",
                Date = new DateTime(2022, 09, 21),
                TakerScore = 22,
                TwentyOne = true,
                Excuse = true,
                Petit = PetitResultDB.Lost,
                Chelem = ChelemDB.Announced,
                Biddings = new List<BiddingPoigneeEntity>()
                {
                    new BiddingPoigneeEntity
                    {
                        Player = new PlayerEntity
                        {
                            Id = 0UL,
                            FirstName = "Player1",
                            LastName = "1Player",
                            Nickname = "1P1",
                            Avatar = "avatar1"
                        
                        },
                        Bidding = BiddingDB.Garde,
                        Poignee = PoigneeDB.None
                    },
                }
            }

        };
    }

    public static IEnumerable<object[]> Data_AddHandsAndHandsEntities()
    {
        yield return new object[]
        {
            new List<Hand>()
            {
                new (1UL, 1, new FrenchTarotRules(),new DateTime(2022, 09, 21),22,true,true,PetitResult.Lost,Chelem.Announced),
                new (2UL, 2, new FrenchTarotRules(),new DateTime(2022, 09, 21),44,false,true,PetitResult.Lost,Chelem.Unknown),
                new (3UL, 3, new FrenchTarotRules(),new DateTime(2022, 09, 21),69,true,true,PetitResult.AuBoutOwned,Chelem.NotAnnouncedSuccess)
                
            },
            new List<HandEntity>()
            {
                new()
                {
                    Id = 1UL,
                    Number = 1,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 22,
                    TwentyOne = true,
                    Excuse = true,
                    Petit = PetitResultDB.Lost,
                    Chelem = ChelemDB.Announced
                },
                new()
                {
                    Id = 2UL,
                    Number = 2,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 44,
                    TwentyOne = false,
                    Excuse = true,
                    Petit = PetitResultDB.Lost,
                    Chelem = ChelemDB.Unknown
                },
                new()
                {
                    Id = 3UL,
                    Number = 3,
                    Rules = "FrenchTarotRules",
                    Date = new DateTime(2022, 09, 21),
                    TakerScore = 69,
                    TwentyOne = true,
                    Excuse = true,
                    Petit = PetitResultDB.AuBoutOwned,
                    Chelem = ChelemDB.NotAnnouncedSuccess
                }
            }
        };
    }

    [Theory]
    [MemberData(nameof(Data_AddHandAndHandEntity))]
    internal void TestHandEntityToModel(Hand hand, HandEntity handEntity)
    {
        Mapper.Reset();
        var result = handEntity.ToModel();
        Assert.Equal(hand,result);

        Assert.Same(handEntity.ToModel(), result);
        Mapper.Reset();
        Assert.NotSame(handEntity.ToModel(), actual: result);
    }

    [Theory]
    [MemberData(nameof(Data_AddHandAndHandEntity))]
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
            Assert.Equal(biddingPoigneeEntity.Bidding, result.Biddings.ElementAt(i).Bidding);
            Assert.Equal(biddingPoigneeEntity.Poignee, result.Biddings.ElementAt(i).Poignee);
            ++i;
        }
        Assert.Same(result,hand.ToEntity());
        Mapper.Reset();
        Assert.NotSame(result, hand.ToEntity());
    }
    
    [Theory]
    [MemberData(nameof(Data_AddHandsAndHandsEntities))]
    internal void TestHandsEntitiesToModels(List<Hand> hands, List<HandEntity> handsEntities)
    {
        Mapper.Reset();
        var result = handsEntities.ToModels().ToList();
        Assert.Equal(hands,result);
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
    [MemberData(nameof(Data_AddHandsAndHandsEntities))]
    internal void TestHandsToEntities(List<Hand> hands, List<HandEntity> handsEntities)
    {
        Mapper.Reset();
        var result = hands.ToEntities().ToList();
        var i = 0;
        foreach (var handEntity in handsEntities)
        {
            Assert.Equal(handEntity.Id,result.ElementAt(i).Id);
            Assert.Equal(handEntity.Rules,result.ElementAt(i).Rules);
            Assert.Equal(handEntity.Date,result.ElementAt(i).Date);
            Assert.Equal(handEntity.TakerScore,result.ElementAt(i).TakerScore);
            Assert.Equal(handEntity.TwentyOne,result.ElementAt(i).TwentyOne);
            Assert.Equal(handEntity.Excuse,result.ElementAt(i).Excuse);
            Assert.Equal(handEntity.Petit,result.ElementAt(i).Petit);
            Assert.Equal(handEntity.Chelem,result.ElementAt(i).Chelem);
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
