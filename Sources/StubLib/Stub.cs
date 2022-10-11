﻿using Model;
using Model.data;
using Model.enums;
using Model.games;

namespace StubLib;

public class Stub : ILoader
{
    private readonly List<Game> _gameList = new();
    private readonly List<Player> _playerList = new();
    private readonly List<Group> _groupList = new();
    private readonly List<IRules> _rulesList = new();
    private readonly List<Hand> _handList = new();

    /// <summary>
    /// Constructor for the stub
    /// </summary>
    public Stub()
    {
        SetGameList();
        SetPlayerList();
        SetGroupList();
        SetRuleList();
        SetHandList();
    }

    /// <summary>
    /// Method to set the game list
    /// </summary>
    private void SetGameList()
    {
        _gameList.Add(new Game(1UL, "Game 1", _rulesList[0], DateTime.Now, null));
        _gameList.Add(new Game(2UL, "Game 2", _rulesList[0], DateTime.Now, null));
        _gameList.Add(new Game(3UL, "Game 3", _rulesList[0], DateTime.Now, null));
        _gameList.Add(new Game(4UL, "Game 4", _rulesList[0], DateTime.Now, null));
        _gameList.Add(new Game(5UL, "Game 5", _rulesList[0], DateTime.Now, null));
        _gameList.Add(new Game(6UL, "Game 13", _rulesList[0], new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)));
        _gameList.Add(new Game(7UL, "Game 14", _rulesList[0], new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)));
        _gameList.Add(new Game(8UL, "Game 15", _rulesList[0], new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)));
        _gameList.Add(new Game(9UL, "Game 16", _rulesList[0], new DateTime(2022, 09, 21), new DateTime(2022, 09, 25)));
        _gameList.Add(new Game(10UL, "Game 17", _rulesList[0], new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)));
    }

    /// <summary>
    /// Method to set the player list
    /// </summary>
    private void SetPlayerList()
    {
        _playerList.Add(new Player("Jean", "BON", "JEBO", "avatar1"));
        _playerList.Add(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"));
        _playerList.Add(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"));
        _playerList.Add(new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"));
        _playerList.Add(new Player("Albert", "GOL", "LOL", "avatar1"));
        _playerList.Add(new Player("Julien", "PETIT", "THEGIANT", "avatar2"));
        _playerList.Add(new Player("Simon", "SEBAT", "SEBAT", "avatar1"));
        _playerList.Add(new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"));
        _playerList.Add(new Player("Samuel", "LeChanteur", "SS", "avatar1"));
        _playerList.Add(new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"));
        _playerList.Add(new Player("Jeanne", "LERICHE", "JEMA", "avatar2"));
        _playerList.Add(new Player("Jules", "INFANTE", "KIKOU7", "avatar3"));
        _playerList.Add(new Player("Anne", "SAURIN", "FRIPOUILLE", "avatar4"));
        _playerList.Add(new Player("Marine", "TABLETTE", "LOL", "avatar1"));
        _playerList.Add(new Player("Eliaz", "DU JARDIN", "THEGIANT", "avatar2"));
        _playerList.Add(new Player("Alizee", "SEBAT", "SEBAT", "avatar1"));
    }

    /// <summary>
    /// Method to set the group list
    /// </summary>
    private void SetGroupList()
    {
        _groupList.Add(new Group(1UL, "Group 1", _playerList[0], _playerList[1], _playerList[2], _playerList[3],
            _playerList[4]));
        _groupList.Add(new Group(2UL, "Group 2", _playerList[1], _playerList[2], _playerList[3], _playerList[4],
            _playerList[5]));
        _groupList.Add(new Group(3UL, "Group 3", _playerList[2], _playerList[3], _playerList[4], _playerList[5],
            _playerList[6]));
        _groupList.Add(new Group(4UL, "Group 4", _playerList[3], _playerList[4], _playerList[5], _playerList[6],
            _playerList[7]));
        _groupList.Add(new Group(5UL, "Group 5", _playerList[4], _playerList[5], _playerList[6], _playerList[7],
            _playerList[8]));
        _groupList.Add(new Group(6UL, "Group 6", _playerList[5], _playerList[6], _playerList[7], _playerList[8],
            _playerList[9]));
        _groupList.Add(new Group(7UL, "Group 7", _playerList[6], _playerList[7], _playerList[8], _playerList[9],
            _playerList[10]));
        _groupList.Add(new Group(8UL, "Group 8", _playerList[7], _playerList[8], _playerList[9], _playerList[10],
            _playerList[11]));
        _groupList.Add(new Group(9UL, "Group 9", _playerList[8], _playerList[9], _playerList[10], _playerList[11],
            _playerList[12]));
        _groupList.Add(new Group(10UL, "Group 10", _playerList[9], _playerList[10], _playerList[11], _playerList[12],
            _playerList[13]));
        _groupList.Add(new Group(11UL, "Group 11", _playerList[10], _playerList[11], _playerList[12], _playerList[13],
            _playerList[14]));
        _groupList.Add(new Group(12UL, "Group 12", _playerList[11], _playerList[12], _playerList[13], _playerList[14],
            _playerList[15]));
    }

    /// <summary>
    /// Method to set the rule list
    /// </summary>
    private void SetRuleList()
    {
        _rulesList.Add(new FrenchTarotRules());
    }

    /// <summary>
    /// Method to set the hand list
    /// </summary>
    private void SetHandList()
    {
        _handList.Add(new Hand(1UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 210, false, true, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(2UL, 2, _rulesList[0], new DateTime(2022, 09, 22), 256, true, true, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(3UL, 3, _rulesList[0], new DateTime(2022, 09, 23), 151, false, false, PetitResult.Lost,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[0].AddHand(_handList[0]);
        _gameList[0].AddHand(_handList[1]);
        _gameList[0].AddHand(_handList[2]);

        _handList.Add(new Hand(4UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, false, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(5UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 256, false, true, PetitResult.AuBout,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(6UL, 3, _rulesList[0], new DateTime(2022, 09, 21), 151, true, false, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[1].AddHand(_handList[3]);
        _gameList[1].AddHand(_handList[4]);
        _gameList[1].AddHand(_handList[5]);

        _handList.Add(new Hand(7UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, true, true,
            PetitResult.LostAuBout,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(8UL, 2, _rulesList[0], new DateTime(2022, 09, 27), 256, false, true, PetitResult.AuBout,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(9UL, 3, _rulesList[0], new DateTime(2022, 09, 30), 654, false, false, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[2].AddHand(_handList[6]);
        _gameList[2].AddHand(_handList[7]);
        _gameList[2].AddHand(_handList[8]);

        _handList.Add(new Hand(10UL, 1, _rulesList[0], new DateTime(2022, 09, 16), 567, false, false,
            PetitResult.NotOwned,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(11UL, 2, _rulesList[0], new DateTime(2022, 09, 28), 365, false, true, PetitResult.AuBout,
            Chelem.Fail, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(12UL, 3, _rulesList[0], new DateTime(2022, 09, 21), 151, true, false, PetitResult.AuBout,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[3].AddHand(_handList[9]);
        _gameList[3].AddHand(_handList[10]);
        _gameList[3].AddHand(_handList[11]);

        _handList.Add(new Hand(13UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, true, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(14UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567, false, false, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(15UL, 3, _rulesList[0], new DateTime(2022, 09, 21), 151, true, true, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[4].AddHand(_handList[12]);
        _gameList[4].AddHand(_handList[13]);
        _gameList[4].AddHand(_handList[14]);

        _handList.Add(new Hand(16UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 873, false, true,
            PetitResult.LostAuBout,
            Chelem.Fail, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(17UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567, true, false, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(18UL, 3, _rulesList[0], new DateTime(2022, 09, 27), 356, true, true, PetitResult.Owned,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(19UL, 4, _rulesList[0], new DateTime(2022, 09, 29), 151, true, false, PetitResult.Owned,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[5].AddHand(_handList[15]);
        _gameList[5].AddHand(_handList[16]);
        _gameList[5].AddHand(_handList[17]);
        _gameList[5].AddHand(_handList[18]);

        _handList.Add(new Hand(20UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, false, true,
            PetitResult.LostAuBout,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(21UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 826, false, false, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(22UL, 3, _rulesList[0], new DateTime(2022, 09, 29), 745, true, true, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(23UL, 1, _rulesList[0], new DateTime(2022, 09, 30), 567, true, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[6].AddHand(_handList[19]);
        _gameList[6].AddHand(_handList[20]);
        _gameList[6].AddHand(_handList[21]);
        _gameList[6].AddHand(_handList[22]);

        _handList.Add(new Hand(24UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, false, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(25UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567, false, true,
            PetitResult.LostAuBout,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(26UL, 3, _rulesList[0], new DateTime(2022, 09, 29), 567, true, true, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[7].AddHand(_handList[23]);
        _gameList[7].AddHand(_handList[24]);
        _gameList[7].AddHand(_handList[25]);

        _handList.Add(new Hand(27UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, true, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(28UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567, false, false, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[8].AddHand(_handList[26]);
        _gameList[8].AddHand(_handList[27]);

        _handList.Add(new Hand(29UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567, false, true,
            PetitResult.LostAuBout,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(30UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567, true, false, PetitResult.Lost,
            Chelem.AnnouncedSuccess, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(31UL, 3, _rulesList[0], new DateTime(2022, 09, 29), 567, true, true, PetitResult.Owned,
            Chelem.Success, new KeyValuePair<Player, (Bidding, Poignee)>()));
        _handList.Add(new Hand(32UL, 1, _rulesList[0], new DateTime(2022, 09, 30), 567, true, false, PetitResult.Lost,
            Chelem.Unknown, new KeyValuePair<Player, (Bidding, Poignee)>()));

        _gameList[9].AddHand(_handList[28]);
        _gameList[9].AddHand(_handList[29]);
        _gameList[9].AddHand(_handList[30]);
        _gameList[9].AddHand(_handList[31]);
    }

    /*========== Games ==========*/
    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public async Task<Game?> LoadGameByName(string name)
        => await Task.FromResult(_gameList.FirstOrDefault(game => name.Equals(game.Name)));

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
        => await Task.FromResult(_gameList
            .Where(game => game.Players.Contains(player))
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
        => await Task.FromResult( _gameList
            .Where(game => game.StartDate == startDate)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
        => await Task.FromResult(_gameList
            .Where(game => game.EndDate == endDate)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page, int pageSize)
        => await Task.FromResult(_gameList
            .Where(game => game.StartDate >= startDate && game.EndDate <= endDate)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate, Group group, int page,
        int pageSize)
        => await Task.FromResult(_gameList
            .Where(game => game.StartDate >= startDate && game.EndDate <= endDate && game.Players.Any(p => group.Players.Contains(p)))
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate, Player player,
        int page, int pageSize)
        => await Task.FromResult(_gameList
            .Where(game => game.StartDate >= startDate && game.EndDate <= endDate && game.Players.Contains(player))
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
        => await Task.FromResult(_gameList
            .Where(g => g.Players.Any(p => group.Players.Contains(p)))
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
        => await Task.FromResult(_gameList.Skip((page - 1) * pageSize).Take(pageSize));
    /*========== End Games ==========*/


    /*========== Players ==========*/
    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page, int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.LastName == lastName && player.NickName == nickname)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by firstname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.FirstName == firstName && player.NickName == nickname)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.FirstName == firstName && player.LastName == lastName)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.NickName == nickname)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.LastName == lastName)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => player.FirstName == firstName)
            .Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
        => await Task.FromResult(_playerList.Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
        => await Task.FromResult(_playerList
            .Where(player => group.Players.Contains(player))
            .Skip((page - 1) * pageSize).Take(pageSize));
    /*========== End Players ==========*/


    /*========== Groups ==========*/
    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public async Task<Group?> LoadGroupsByName(string name) 
        => await Task.FromResult(_groupList.FirstOrDefault(g => g.Name == name));

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
        => await Task.FromResult(_groupList.Skip((page - 1) * pageSize).Take(pageSize));

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
        => await Task.FromResult(_groupList.Where(g => g.Players.Contains(player)).Skip((page - 1) * pageSize).Take(pageSize));
    /*========== End Groups ==========*/


    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    public async Task<IRules?> LoadRule(string name) 
        => await Task.FromResult(_rulesList.FirstOrDefault(r => r.Name.Equals(name)));

    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of rules</returns>
    public async Task<IEnumerable<IRules>> LoadAllRules(int page, int pageSize)
        => await Task.FromResult( _rulesList.Skip((page - 1) * pageSize).Take(pageSize));
    /*========== End Rules ==========*/


    /*========== Hand ==========*/
    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
        => await Task.FromResult(_gameList.First(g => g.Equals(game)).Hands.Skip((page - 1) * pageSize).Take(pageSize));
    /*========== End hand ==========*/
}