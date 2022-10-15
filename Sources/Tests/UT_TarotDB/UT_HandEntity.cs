using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using TarotDB.enums;
using Xunit;
using static UT_TarotDB.TestInitializer;

namespace UT_TarotDB;

public class UT_HandEntity
{
	[Theory]
	[MemberData(nameof(HandEntityTestData.Data_TestRead), MemberType = typeof(HandEntityTestData))]
	internal async Task TestRead(ulong id, int expNumber, string expRules, DateTime expDate, int expTakerScore,
		bool? expTwentyOne, bool? expExcuse, PetitResultDB expPetit, ChelemDB expChelem, ulong expGameId,
		IEnumerable<(ulong, ulong)> iExpBiddingsId, IEnumerable<(BiddingDB, PoigneeDB)> iExpBiddings)
	{
		var expBiddingsId = iExpBiddingsId.ToArray();
		var expBiddings = iExpBiddings.ToArray();
		await using var context = new TarotDBContextStub(InitDB());

		await context.Database.EnsureCreatedAsync();
		var hand = await context.Hands
			.Include(ha => ha.Game)
			.Include(ha => ha.Biddings)
			.ThenInclude(bi => bi.Player)
			.FirstOrDefaultAsync(ha => ha.Id == id);

		Assert.NotNull(hand);

		Assert.Equal(id, hand!.Id);
		Assert.Equal(expNumber, hand.Number);
		Assert.Equal(expRules, hand.Rules);
		Assert.Equal(expDate, hand.Date);
		Assert.Equal(expTakerScore, hand.TakerScore);
		Assert.Equal(expTwentyOne, hand.TwentyOne);
		Assert.Equal(expExcuse, hand.Excuse);
		Assert.Equal(expPetit, hand.Petit);
		Assert.Equal(expChelem, hand.Chelem);
		Assert.Equal(await context.Games.FindAsync(expGameId), hand.Game);

		Assert.Equal(expBiddingsId.Length, hand.Biddings.Count);
		for (var i = 0; i < expBiddingsId.Length; ++i)
		{
			var bidding =
				(await context.FindAsync<BiddingPoigneeEntity>(expBiddingsId[i].Item1, expBiddingsId[i].Item2))!;
			var player = (await context.Players.FindAsync(bidding.Player.Id))!;
			Assert.Single(hand.Biddings.Where(bi =>
				bi.Bidding == expBiddings[i].Item1 && bi.Poignee == expBiddings[i].Item2 && bi.Equals(bidding) &&
				bi.Player.Equals(player) && player.Biddings.Contains(bi) && bi.Hand.Equals(hand)));
		}
	}

	[Theory]
	[MemberData(nameof(HandEntityTestData.Data_TestAdd), MemberType = typeof(HandEntityTestData))]
	internal async Task TestAdd(bool isValid, ulong id, int number, string rules, DateTime date, int takerScore,
		bool? twentyOne, bool? excuse, PetitResultDB petit, ChelemDB chelem, ulong gameId,
		params (BiddingDB, PoigneeDB)[] biddings)
	{
		var options = InitDB();
		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = new HandEntity
			{
				Id = id,
				Number = number,
				Rules = rules,
				Date = date,
				TakerScore = takerScore,
				TwentyOne = twentyOne,
				Excuse = excuse,
				Petit = petit,
				Chelem = chelem,
				Game = (await context.Games
					.Include(ga => ga.Players)
					.SingleOrDefaultAsync(ga => ga.Id == gameId))!
			};

			var players = hand.Game.Players.ToArray();
			for (var i = 0; i < biddings.Length; ++i)
			{
				var bidding = new BiddingPoigneeEntity
				{
					Bidding = biddings[i].Item1,
					Poignee = biddings[i].Item2,
					Player = players[i],
					Hand = hand
				};
				hand.Biddings.Add(bidding);
			}

			await context.Hands.AddAsync(hand);

			if (!isValid)
			{
				var error = await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
				Assert.Contains("UNIQUE constraint failed: Hands.Id", error.InnerException!.Message);

				return;
			}
			
			await context.SaveChangesAsync();
		}

		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = await context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefaultAsync(ha => ha.Game.Id == gameId && ha.Number == number);
			
			Assert.NotNull(hand);
			Assert.NotEqual(0UL, hand!.Id);
			Assert.Equal(number, hand.Number);
			Assert.Equal(rules, hand.Rules);
			Assert.Equal(date, hand.Date);
			Assert.Equal(takerScore, hand.TakerScore);
			Assert.Equal(twentyOne, hand.TwentyOne);
			Assert.Equal(excuse, hand.Excuse);
			Assert.Equal(petit, hand.Petit);
			Assert.Equal(chelem, hand.Chelem);
			Assert.Equal(await context.Games.FindAsync(gameId), hand.Game);
			Assert.Equal(biddings.Length, hand.Biddings.Count);
			
			var expPlayers = hand.Game.Players.ToArray();
			var handBiddings = hand.Biddings.ToArray();
			for (var i = 0; i < biddings.Length; ++i)
			{
				Assert.Equal(biddings[i].Item1, handBiddings[i].Bidding);
				Assert.Equal(biddings[i].Item2, handBiddings[i].Poignee);
				Assert.Equal(await context.Players.FindAsync(expPlayers[i].Id), handBiddings[i].Player);
				Assert.Equal(hand, handBiddings[i].Hand);
			}
		}
	}

	[Theory]
	[MemberData(nameof(HandEntityTestData.Data_TestUpdate), MemberType = typeof(HandEntityTestData))]
	internal async Task TestUpdate(bool isValid, ulong id, ulong newId, int number, int newNumber, string rules,
		string newRules, DateTime date, DateTime newDate, int takerScore, int newTakerScore, bool? twentyOne,
		bool? newTwentyOne, bool? excuse, bool? newExcuse, PetitResultDB petit, PetitResultDB newPetit, ChelemDB chelem,
		ChelemDB newChelem, IEnumerable<(ulong, ulong)> iBiddingsId,
		IEnumerable<(BiddingDB, PoigneeDB)> iNewBiddings)
	{
		var biddingsId = iBiddingsId.ToArray();
		var newBiddings = iNewBiddings.ToArray();
		
		var options = InitDB();
		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == id);
			
			Assert.NotNull(hand);
			Assert.Equal(id, hand!.Id);
			Assert.Equal(number, hand.Number);
			Assert.Equal(rules, hand.Rules);
			Assert.Equal(date, hand.Date);
			Assert.Equal(takerScore, hand.TakerScore);
			Assert.Equal(twentyOne, hand.TwentyOne);
			Assert.Equal(excuse, hand.Excuse);
			Assert.Equal(petit, hand.Petit);
			Assert.Equal(chelem, hand.Chelem);
			Assert.Equal(biddingsId.Length, hand.Biddings.Count);
			Assert.True(biddingsId.All(bi => 
				hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(bi.Item1, bi.Item2)!)));

			hand.Id = newId;
			hand.Number = newNumber;
			hand.Rules = newRules;
			hand.Date = newDate;
			hand.TakerScore = newTakerScore;
			hand.TwentyOne = newTwentyOne;
			hand.Excuse = newExcuse;
			hand.Petit = newPetit;
			hand.Chelem = newChelem;

			var handBiddings = hand.Biddings.ToArray();
			for (var i = 0; i < newBiddings.Length; ++i)
			{
				handBiddings[i].Bidding = newBiddings[i].Item1;
				handBiddings[i].Poignee = newBiddings[i].Item2;
			}
			
			if (!isValid)
			{
				var error = await Assert.ThrowsAsync<InvalidOperationException>(() =>  context.SaveChangesAsync());
				Assert.Contains("The property 'HandEntity.Id' is part of a key", error.Message);

				return;
			}
			
			await context.SaveChangesAsync();
		}
		
		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == newId);
			
			Assert.NotNull(hand);
			Assert.Equal(newId, hand!.Id);
			Assert.Equal(newNumber, hand.Number);
			Assert.Equal(newRules, hand.Rules);
			Assert.Equal(newDate, hand.Date);
			Assert.Equal(newTakerScore, hand.TakerScore);
			Assert.Equal(newTwentyOne, hand.TwentyOne);
			Assert.Equal(newExcuse, hand.Excuse);
			Assert.Equal(newPetit, hand.Petit);
			Assert.Equal(newChelem, hand.Chelem);
			Assert.Equal(newBiddings.Length, hand.Biddings.Count);
			
			var handBiddings = hand.Biddings.ToArray();
			for (var i = 0; i < newBiddings.Length; ++i)
			{
				Assert.Equal(newBiddings[i].Item1, handBiddings[i].Bidding);
				Assert.Equal(newBiddings[i].Item2, handBiddings[i].Poignee);
			}
		}
	}

	[Fact]
	public async Task TestDelete()
	{
		var options = InitDB();
		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == 1UL);

			Assert.NotNull(hand);
			Assert.Equal(1UL, hand!.Id);
			Assert.Equal(1, hand.Number);
			Assert.Equal("FrenchTarotRules", hand.Rules);
			Assert.Equal(new DateTime(2022, 09, 21), hand.Date);
			Assert.Equal(210, hand.TakerScore);
			Assert.Equal(false, hand.TwentyOne);
			Assert.Equal(true, hand.Excuse);
			Assert.Equal(PetitResultDB.Lost, hand.Petit);
			Assert.Equal(ChelemDB.Unknown, hand.Chelem);
			Assert.Equal(await context.Games.FindAsync(1UL), hand.Game);

			Assert.Equal(3, hand.Biddings.Count);
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 1UL)!));
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 2UL)!));
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 3UL)!));
			
			context.Remove(hand);
			await context.SaveChangesAsync();
		}
		
		await using (var context = new TarotDBContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == 1UL);

			Assert.Null(hand);
			Assert.Null(await context.FindAsync<BiddingPoigneeEntity>(1UL, 1UL));
			Assert.Null(await context.FindAsync<BiddingPoigneeEntity>(1UL, 2UL));
			Assert.Null(await context.FindAsync<BiddingPoigneeEntity>(1UL, 3UL));
			
			Assert.NotNull(await context.Games.FindAsync(1UL));
			Assert.NotNull(await context.Players.FindAsync(1UL));
			Assert.NotNull(await context.Players.FindAsync(2UL));
			Assert.NotNull(await context.Players.FindAsync(3UL));
		}
	}
}