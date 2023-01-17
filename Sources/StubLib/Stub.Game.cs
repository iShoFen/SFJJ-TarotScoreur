using Model.Games;
using Utils;

namespace StubLib;

public partial class Stub
{
	public async Task<IEnumerable<Game>> GetGames(int start, int count)
	{
		if (start <= 0 || count <= 0) return new List<Game>();
		return await Task.FromResult(_gameList
			.Paginate(start, count)
			.Select(game => new Game(game.Id, game.Name, game.Rules, game.StartDate, game.EndDate)));
	}

    public async Task<Game?> GetGameById(ulong gameId)
		=> await Task.FromResult(_gameList.FirstOrDefault(g => g.Id == gameId));

	public async Task<IEnumerable<Game>> GetGamesByName(string pattern, int start, int count)
		=> await Task.FromResult(_gameList
			.Where(g => g.Name.Contains(pattern))
			.Paginate(start, count)
			.Select(game => new Game(game.Id, game.Name, game.Rules, game.StartDate, game.EndDate)));

	public async Task<IEnumerable<Game>> GetGamesByPlayer(ulong playerId, int start, int count)
	{
		if (start <= 0 || count <= 0) return new List<Game>();
		return await Task.FromResult(_gameList
			.Where(g => g.Players.Any(p => p.Id == playerId))
			.Paginate(start, count)
			.Select(game => new Game(game.Id, game.Name, game.Rules, game.StartDate, game.EndDate)));
	}

	public async Task<IEnumerable<Game>> GetGamesByDate(DateTime startDate, DateTime endDate, int start, int count)
	{
		if (start <= 0 || count <= 0) return new List<Game>();
		return await Task.FromResult(_gameList
			.Where(g => g.StartDate.CompareTo(startDate) >= 0 
			            && endDate.CompareTo(g.EndDate) >= 0)
			.Paginate(start, count)
			.Select(game => new Game(game.Id, game.Name, game.Rules, game.StartDate, game.EndDate)));
	}
}