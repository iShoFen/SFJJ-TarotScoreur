using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using TarotDB.Enums;
using TestUtils;
using Xunit;

namespace UT_TarotDB;

public class UT_HandEntity
{
	[Theory]
	[MemberData(nameof(HandEntityTestData.Data_TestRead), MemberType = typeof(HandEntityTestData))]
	internal async Task TestRead(ulong id, int expNumber, string expRules, DateTime expDate, int expTakerScore,
		bool? expTwentyOne, bool? expExcuse, PetitResultsDb expPetit, ChelemDb expChelem, ulong expGameId,
		IEnumerable<(ulong, ulong)> iExpBiddingsId, IEnumerable<(BiddingsDb, PoigneeDb)> iExpBiddings)
	{
		var expBiddingIds = iExpBiddingsId.ToArray();
		var expBiddings = iExpBiddings.ToArray();
		await using var context = new TarotDbContextStub(TestInitializer.InitDb());

		await context.Database.EnsureCreatedAsync();
		var hand = await context.Hands
			.Include(ha => ha.Game)
			.Include(ha => ha.Biddings)
			.ThenInclude(bi => bi.Player)
			.FirstOrDefaultAsync(ha => ha.Id == id);

		Assert.NotNull(hand);

		Assert.Equal(id, hand.Id);
		Assert.Equal(expNumber, hand.Number);
		Assert.Equal(expRules, hand.Rules);
		Assert.Equal(expDate, hand.Date);
		Assert.Equal(expTakerScore, hand.TakerScore);
		Assert.Equal(expTwentyOne, hand.TwentyOne);
		Assert.Equal(expExcuse, hand.Excuse);
		Assert.Equal(expPetit, hand.Petit);
		Assert.Equal(expChelem, hand.Chelem);
		Assert.Equal(await context.Games.FindAsync(expGameId), hand.Game);

		Assert.Equal(expBiddingIds.Length, hand.Biddings.Count);
		for (var i = 0; i < expBiddingIds.Length; ++i)
		{
			var bidding = 
				(await context.FindAsync<BiddingPoigneeEntity>(expBiddingIds[i].Item1, expBiddingIds[i].Item2))!;
			var player = (await context.Players.FindAsync(bidding.Player.Id))!;
			Assert.Single(hand.Biddings.Where(bi =>
				bi.Biddings == expBiddings[i].Item1 && bi.Poignee == expBiddings[i].Item2 && bi.Player.Equals(player) &&
				bi.PlayerId == player.Id && player.Biddings.Contains(bi) && bi.Hand.Equals(hand) &&
				bi.HandId == hand.Id && hand.Biddings.Contains(bi) && bi.Equals(bidding)));
		}
	}

	[Theory]
	[MemberData(nameof(HandEntityTestData.Data_TestAdd), MemberType = typeof(HandEntityTestData))]
	internal async Task TestAdd(bool isValid, ulong id, int number, string rules, DateTime date, int takerScore,
		bool? twentyOne, bool? excuse, PetitResultsDb petit, ChelemDb chelem, ulong gameId,
		params (BiddingsDb, PoigneeDb)[] biddings)
	{
		var options = TestInitializer.InitDb();
		await using (var context = new TarotDbContextStub(options))
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

			var myBiddings = new List<BiddingPoigneeEntity>();
			var players = hand.Game.Players.ToArray();
			for (var i = 0; i < biddings.Length; ++i)
			{
				var bidding = new BiddingPoigneeEntity
				{
					Biddings = biddings[i].Item1,
					Poignee = biddings[i].Item2,
					Player = players[i],
					Hand = hand
				};
				myBiddings.Add(bidding);
			}
			hand.Biddings = myBiddings;

			await context.Hands.AddAsync(hand);

			if (!isValid)
			{
				var error = await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
				Assert.Contains("UNIQUE constraint failed: Hands.Id", error.InnerException!.Message);

				return;
			}
			
			await context.SaveChangesAsync();
		}

		await using (var context = new TarotDbContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = await context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefaultAsync(ha => ha.Game.Id == gameId && ha.Number == number);
			
			Assert.NotNull(hand);
			Assert.NotEqual(0UL, hand.Id);
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
			
			var expPlayers = hand.Game.Players.ToList();
			var handBiddings = hand.Biddings.ToList();
			for (var i = 0; i < biddings.Length; ++i)
			{
				Assert.Equal(biddings[i].Item1, handBiddings[i].Biddings);
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
		bool? newTwentyOne, bool? excuse, bool? newExcuse, PetitResultsDb petit, PetitResultsDb newPetit, ChelemDb chelem,
		ChelemDb newChelem,  ulong gameId, ulong newGameId, IEnumerable<(ulong, ulong)> iBiddingsId,
		IEnumerable<(BiddingsDb, PoigneeDb)> iNewBiddings)
	{
		var biddingsId = iBiddingsId.ToArray();
		var newBiddings = iNewBiddings.ToArray();
		
		var options = TestInitializer.InitDb();
		await using (var context = new TarotDbContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == id);
			
			Assert.NotNull(hand);
			Assert.Equal(id, hand.Id);
			Assert.Equal(number, hand.Number);
			Assert.Equal(rules, hand.Rules);
			Assert.Equal(date, hand.Date);
			Assert.Equal(takerScore, hand.TakerScore);
			Assert.Equal(twentyOne, hand.TwentyOne);
			Assert.Equal(excuse, hand.Excuse);
			Assert.Equal(petit, hand.Petit);
			Assert.Equal(chelem, hand.Chelem);
			Assert.Equal(await context.Games.FindAsync(gameId), hand.Game);
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
			hand.Game = await context.Games
				.Include(ga => ga.Players)
				.SingleAsync(ga => ga.Id == newGameId);

			var handBiddings = hand.Biddings.ToList();
			var players = hand.Game.Players.ToList();
			for (var i = 0; i < newBiddings.Length; ++i)
			{
				handBiddings[i].HandId = newId;
				handBiddings[i].PlayerId = players[i].Id;
				handBiddings[i].Biddings = newBiddings[i].Item1;
				handBiddings[i].Poignee = newBiddings[i].Item2;
			}
			
			if (!isValid)
			{
				var error = await Assert.ThrowsAsync<InvalidOperationException>(() => context.SaveChangesAsync());
				if (id != newId)
				{
					Assert.Contains("The property 'HandEntity.Id' is part of a key", error.Message);
				}
				else if (gameId != newGameId)
				{
					Assert.Contains("The property 'BiddingPoigneeEntity.PlayerId' is part of a key", error.Message);
				}

				return;
			}
			
			await context.SaveChangesAsync();
		}
		
		await using (var context = new TarotDbContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == newId);
			
			Assert.NotNull(hand);
			Assert.Equal(newId, hand.Id);
			Assert.Equal(newNumber, hand.Number);
			Assert.Equal(newRules, hand.Rules);
			Assert.Equal(newDate, hand.Date);
			Assert.Equal(newTakerScore, hand.TakerScore);
			Assert.Equal(newTwentyOne, hand.TwentyOne);
			Assert.Equal(newExcuse, hand.Excuse);
			Assert.Equal(newPetit, hand.Petit);
			Assert.Equal(newChelem, hand.Chelem);
			Assert.Equal(await context.Games.FindAsync(newGameId), hand.Game);
			Assert.Equal(newBiddings.Length, hand.Biddings.Count);
			
			var handBiddings = hand.Biddings.ToList();
			for (var i = 0; i < newBiddings.Length; ++i)
			{
				Assert.Equal(newBiddings[i].Item1, handBiddings[i].Biddings);
				Assert.Equal(newBiddings[i].Item2, handBiddings[i].Poignee);
			}
		}
	}

	[Fact]
	public async Task TestDelete()
	{
		var options = TestInitializer.InitDb();
		await using (var context = new TarotDbContextStub(options))
		{
			await context.Database.EnsureCreatedAsync();
			var hand = context.Hands
				.Include(ha => ha.Biddings)
				.Include(ha => ha.Game)
				.ThenInclude(ga => ga.Players)
				.SingleOrDefault(ha => ha.Id == 1UL);

			Assert.NotNull(hand);
			Assert.Equal(1UL, hand.Id);
			Assert.Equal(1, hand.Number);
			Assert.Equal("FrenchTarotRules", hand.Rules);
			Assert.Equal(new DateTime(2022, 09, 21), hand.Date);
			Assert.Equal(210, hand.TakerScore);
			Assert.Equal(false, hand.TwentyOne);
			Assert.Equal(true, hand.Excuse);
			Assert.Equal(PetitResultsDb.Lost, hand.Petit);
			Assert.Equal(ChelemDb.Unknown, hand.Chelem);
			Assert.Equal(await context.Games.FindAsync(1UL), hand.Game);

			Assert.Equal(3, hand.Biddings.Count);
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 1UL)!));
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 2UL)!));
			Assert.True(hand.Biddings.Contains(context.Find<BiddingPoigneeEntity>(1UL, 3UL)!));
			
			context.Remove(hand);
			await context.SaveChangesAsync();
		}
		
		await using (var context = new TarotDbContextStub(options))
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