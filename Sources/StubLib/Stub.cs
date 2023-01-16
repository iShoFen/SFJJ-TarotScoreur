using Model.Rules;
using Model.Data;
using Model.Enums;
using Model.Games;
using Model.Players;
using Utils;

namespace StubLib;

public partial class Stub : IReader
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
        SetRuleList();
        SetPlayerList();
        SetGameList();
        SetGroupList();
        SetHandList();
    }

    /// <summary>
    /// Method to set the player list
    /// </summary>
    private void SetPlayerList()
    {
        _playerList.Add(new Player(1UL, "Jean", "BON", "JEBO", "avatar1"));
        _playerList.Add(new Player(2UL, "Jean", "MAUVAIS", "JEMA", "avatar2"));
        _playerList.Add(new Player(3UL, "Jean", "MOYEN", "KIKOU7", "avatar3"));
        _playerList.Add(new Player(4UL, "Michel", "BELIN", "FRIPOUILLE", "avatar4"));
        _playerList.Add(new Player(5UL, "Albert", "GOL", "LOLA", "avatar5"));
        _playerList.Add(new Player(6UL, "Julien", "PETIT", "THEGIANT", "avatar6"));
        _playerList.Add(new Player(7UL, "Simon", "SEBAT", "SEBATA", "avatar7"));
        _playerList.Add(new Player(8UL, "Jordan", "LEG", "BIGBRAIN", "avatar8"));
        _playerList.Add(new Player(9UL, "Samuel", "LE CHANTEUR", "LOL", "avatar9"));
        _playerList.Add(new Player(10UL, "Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar10"));
        _playerList.Add(new Player(11UL, "Jeanne", "LERICHE", "JEMAA", "avatar11"));
        _playerList.Add(new Player(12UL, "Jules", "INFANTE", "KIKOU77", "avatar12"));
        _playerList.Add(new Player(13UL, "Anne", "PETIT", "FRIPOUILLES", "avatar13"));
        _playerList.Add(new Player(14UL, "Marine", "TABLETTE", "LOLO", "avatar14"));
        _playerList.Add(new Player(15UL, "Eliaz", "DU JARDIN", "THEGIANTE", "avatar15"));
        _playerList.Add(new Player(16UL, "Alizee", "SEBAT", "SEBAT", "avatar16"));
    }

    /// <summary>
    /// Method to set the game list
    /// </summary>
    private void SetGameList()
    {
        _gameList.Add(new Game(1UL, "Game 1", _rulesList[0], new DateTime(2022, 09, 21), null));
        _gameList.Add(new Game(2UL, "Game 2", _rulesList[0], new DateTime(2022, 09, 21), null));
        _gameList.Add(new Game(3UL, "Game 3", _rulesList[0], new DateTime(2022, 09, 21), null));
        _gameList.Add(new Game(4UL, "Game 4", _rulesList[0], new DateTime(2022, 09, 21), null));
        _gameList.Add(new Game(5UL, "Game 5", _rulesList[0], new DateTime(2022, 09, 21), null));
        _gameList.Add(new Game(6UL, "Game 6", _rulesList[0],
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)));
        _gameList.Add(new Game(7UL, "Game 7", _rulesList[0],
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 29)));
        _gameList.Add(new Game(8UL, "Game 8", _rulesList[0],
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)));
        _gameList.Add(new Game(9UL, "Game 9", _rulesList[0],
            new DateTime(2022, 09, 21), new DateTime(2022, 09, 30)));
        _gameList.Add(new Game(10UL, "Game 10", _rulesList[0],
            new DateTime(2022, 09, 18), new DateTime(2022, 09, 23)));

        _gameList[0].AddPlayer(_playerList[0]);
        _gameList[0].AddPlayer(_playerList[1]);
        _gameList[0].AddPlayer(_playerList[2]);

        _gameList[1].AddPlayer(_playerList[1]);
        _gameList[1].AddPlayer(_playerList[2]);
        _gameList[1].AddPlayer(_playerList[3]);

        _gameList[2].AddPlayer(_playerList[2]);
        _gameList[2].AddPlayer(_playerList[3]);
        _gameList[2].AddPlayer(_playerList[4]);

        _gameList[3].AddPlayer(_playerList[3]);
        _gameList[3].AddPlayer(_playerList[4]);
        _gameList[3].AddPlayer(_playerList[5]);
        _gameList[3].AddPlayer(_playerList[6]);

        _gameList[4].AddPlayer(_playerList[4]);
        _gameList[4].AddPlayer(_playerList[5]);
        _gameList[4].AddPlayer(_playerList[6]);
        _gameList[4].AddPlayer(_playerList[7]);

        _gameList[5].AddPlayer(_playerList[5]);
        _gameList[5].AddPlayer(_playerList[6]);
        _gameList[5].AddPlayer(_playerList[7]);
        _gameList[5].AddPlayer(_playerList[8]);

        _gameList[6].AddPlayer(_playerList[6]);
        _gameList[6].AddPlayer(_playerList[7]);
        _gameList[6].AddPlayer(_playerList[8]);
        _gameList[6].AddPlayer(_playerList[9]);
        _gameList[6].AddPlayer(_playerList[10]);

        _gameList[7].AddPlayer(_playerList[7]);
        _gameList[7].AddPlayer(_playerList[8]);
        _gameList[7].AddPlayer(_playerList[9]);
        _gameList[7].AddPlayer(_playerList[10]);
        _gameList[7].AddPlayer(_playerList[11]);

        _gameList[8].AddPlayer(_playerList[8]);
        _gameList[8].AddPlayer(_playerList[9]);
        _gameList[8].AddPlayer(_playerList[10]);
        _gameList[8].AddPlayer(_playerList[11]);
        _gameList[8].AddPlayer(_playerList[12]);

        _gameList[9].AddPlayer(_playerList[8]);
        _gameList[9].AddPlayer(_playerList[9]);
        _gameList[9].AddPlayer(_playerList[10]);
        _gameList[9].AddPlayer(_playerList[11]);
        _gameList[9].AddPlayer(_playerList[12]);
    }

    /// <summary>
    /// Method to set the group list
    /// </summary>
    private void SetGroupList()
    {
        var j = 1UL;
        for (var i = 0; i < 12; i++)
        {
            _groupList.Add(new Group(j, "Group " + (i + 1), _playerList[i],
                _playerList[i + 1], _playerList[i + 2], _playerList[i + 3], _playerList[i + 4]));
            ++j;
        }
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
        _handList.Add(new Hand(1UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 210,
            false, true, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[0], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[1], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(2UL, 2, _rulesList[0], new DateTime(2022, 09, 22), 256,
            true, true, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[0], (Biddings.Petite, Poignee.Simple)),
            KeyValuePair.Create(_playerList[1], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(3UL, 3, _rulesList[0], new DateTime(2022, 09, 23), 151,
            false, false, PetitResults.Lost, Chelem.Success,
            KeyValuePair.Create(_playerList[0], (Biddings.Garde, Poignee.Simple)),
            KeyValuePair.Create(_playerList[1], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.Simple))));

        _gameList[0].AddHand(_handList[0]);
        _gameList[0].AddHand(_handList[1]);
        _gameList[0].AddHand(_handList[2]);

        _handList.Add(new Hand(4UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567,
            false, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[1], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(5UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 256,
            false, true, PetitResults.AuBoutOwned, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[1], (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.Double)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(6UL, 3, _rulesList[0], new DateTime(2022, 09, 21), 151,
            true, false, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[1], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[2], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.Triple))));

        _gameList[1].AddHand(_handList[3]);
        _gameList[1].AddHand(_handList[4]);
        _gameList[1].AddHand(_handList[5]);

        _handList.Add(new Hand(7UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567,
            true, true, PetitResults.LostAuBout, Chelem.Unknown,
            KeyValuePair.Create(_playerList[2], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(8UL, 2, _rulesList[0], new DateTime(2022, 09, 27), 256,
            false, true, PetitResults.AuBoutOwned, Chelem.Success,
            KeyValuePair.Create(_playerList[2], (Biddings.GardeContreLeChien, Poignee.Triple)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(9UL, 3, _rulesList[0], new DateTime(2022, 09, 30), 654,
            false, false, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[2], (Biddings.Petite, Poignee.Triple)),
            KeyValuePair.Create(_playerList[3], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.None))));

        _gameList[2].AddHand(_handList[6]);
        _gameList[2].AddHand(_handList[7]);
        _gameList[2].AddHand(_handList[8]);

        _handList.Add(new Hand(10UL, 1, _rulesList[0], new DateTime(2022, 09, 16), 567,
            false, false, PetitResults.NotOwned, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[3], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(11UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 365,
            false, true, PetitResults.AuBoutOwned, Chelem.Fail,
            KeyValuePair.Create(_playerList[3], (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.Simple)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(12UL, 3, _rulesList[0], new DateTime(2022, 09, 28), 151,
            true, false, PetitResults.AuBoutOwned, Chelem.Success,
            KeyValuePair.Create(_playerList[3], (Biddings.Petite, Poignee.Triple)),
            KeyValuePair.Create(_playerList[4], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None))));

        _gameList[3].AddHand(_handList[9]);
        _gameList[3].AddHand(_handList[10]);
        _gameList[3].AddHand(_handList[11]);

        _handList.Add(new Hand(13UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567,
            true, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[4], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(14UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 567,
            false, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[4], (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(15UL, 3, _rulesList[0], new DateTime(2022, 09, 25), 151,
            true, true, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[4], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[5], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None))));

        _gameList[4].AddHand(_handList[12]);
        _gameList[4].AddHand(_handList[13]);
        _gameList[4].AddHand(_handList[14]);

        _handList.Add(new Hand(16UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 873,
            false, true, PetitResults.LostAuBout, Chelem.Fail,
            KeyValuePair.Create(_playerList[5], (Biddings.GardeSansLeChien, Poignee.Simple)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(17UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567,
            true, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[5], (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(18UL, 3, _rulesList[0], new DateTime(2022, 09, 27), 356,
            true, true, PetitResults.Owned, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[5], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.Triple)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None))));
        _handList.Add(new Hand(19UL, 4, _rulesList[0], new DateTime(2022, 09, 29), 151,
            true, false, PetitResults.Owned, Chelem.Unknown,
            KeyValuePair.Create(_playerList[5], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[6], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.Simple)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None))));

        _gameList[5].AddHand(_handList[15]);
        _gameList[5].AddHand(_handList[16]);
        _gameList[5].AddHand(_handList[17]);
        _gameList[5].AddHand(_handList[18]);

        _handList.Add(new Hand(20UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567,
            false, true, PetitResults.LostAuBout, Chelem.Unknown,
            KeyValuePair.Create(_playerList[6], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(21UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 826,
            false, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[6], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.Simple)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(22UL, 3, _rulesList[0], new DateTime(2022, 09, 29), 745,
            true, true, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[6], (Biddings.Garde, Poignee.Simple)),
            KeyValuePair.Create(_playerList[7], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.King, Poignee.None))));

        _gameList[6].AddHand(_handList[19]);
        _gameList[6].AddHand(_handList[20]);
        _gameList[6].AddHand(_handList[21]);

        _handList.Add(new Hand(23UL, 4, _rulesList[0], new DateTime(2022, 09, 30), 567,
            true, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[7], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[8], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[1], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[1], (Biddings.King, Poignee.None))));

        _gameList[7].AddHand(_handList[22]);

        _handList.Add(new Hand(24UL, 1, _rulesList[0], new DateTime(2022, 09, 21), 567,
            false, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[8], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(25UL, 2, _rulesList[0], new DateTime(2022, 09, 25), 567,
            false, true, PetitResults.LostAuBout, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[8], (Biddings.Garde, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.Triple)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(26UL, 3, _rulesList[0], new DateTime(2022, 09, 27), 567,
            true, true, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[8], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.Simple))));
        _handList.Add(new Hand(27UL, 1, _rulesList[0], new DateTime(2022, 09, 29), 567,
            true, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[8], (Biddings.Garde, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.Double)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(28UL, 2, _rulesList[0], new DateTime(2022, 09, 30), 567,
            false, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[8], (Biddings.GardeSansLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.Triple)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));

        _gameList[8].AddHand(_handList[23]);
        _gameList[8].AddHand(_handList[24]);
        _gameList[8].AddHand(_handList[25]);
        _gameList[8].AddHand(_handList[26]);
        _gameList[8].AddHand(_handList[27]);

        _handList.Add(new Hand(29UL, 1, _rulesList[0], new DateTime(2022, 09, 18), 567,
            false, true, PetitResults.LostAuBout, Chelem.Unknown,
            KeyValuePair.Create(_playerList[8], (Biddings.Garde, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(30UL, 2, _rulesList[0], new DateTime(2022, 09, 21), 567,
            true, false, PetitResults.Lost, Chelem.AnnouncedSuccess,
            KeyValuePair.Create(_playerList[8], (Biddings.Garde, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(31UL, 3, _rulesList[0], new DateTime(2022, 09, 22), 567,
            true, true, PetitResults.Owned, Chelem.Success,
            KeyValuePair.Create(_playerList[8], (Biddings.Petite, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.Simple)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));
        _handList.Add(new Hand(32UL, 4, _rulesList[0], new DateTime(2022, 09, 23), 567,
            true, false, PetitResults.Lost, Chelem.Unknown,
            KeyValuePair.Create(_playerList[8], (Biddings.GardeContreLeChien, Poignee.None)),
            KeyValuePair.Create(_playerList[9], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[10], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[11], (Biddings.Opponent, Poignee.None)),
            KeyValuePair.Create(_playerList[12], (Biddings.King, Poignee.None))));

        _gameList[9].AddHand(_handList[28]);
        _gameList[9].AddHand(_handList[29]);
        _gameList[9].AddHand(_handList[30]);
        _gameList[9].AddHand(_handList[31]);
    }

    public async Task<IEnumerable<KeyValuePair<int, Hand>>> GetHandsByGame(ulong gameId, int start, int count)
    {
        if (start == 0 || count == 0) return new List<KeyValuePair<int, Hand>>();
        return await Task.FromResult(
            _gameList.FirstOrDefault(g => g.Id == gameId)
                ?.Hands
                .AsEnumerable()
                .Paginate(start, count)
            ?? new List<KeyValuePair<int, Hand>>()
        );
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Method intentionally left empty.
    }
}