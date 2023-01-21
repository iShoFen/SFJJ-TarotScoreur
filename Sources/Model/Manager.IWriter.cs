using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;
using NLog;

namespace Model;

public partial class Manager
{
    #region Player

    /// <summary>
    /// Insert a new player.
    /// </summary>
    /// <param name="firstName">The first name of the player</param>
    /// <param name="lastName">The last name of the player</param>
    /// <param name="nickName">The nick name of the player</param>
    /// <param name="avatar">The avatar of the player</param>
    /// <returns>The player inserted or null if the player has an id not equals to 0</returns>
    public async Task<Player> InsertPlayer(string firstName, string lastName, string nickName, string avatar)
    {
        Player playerToInsert = new (firstName, lastName, nickName, avatar);
        
        var result =  (await _writer.InsertPlayer(playerToInsert))!;

        _logger.Info("Player {Player} inserted", result);
        
        return result;
    }

    /// <summary>
    /// Update a player.
    /// </summary>
    /// <param name="player">Player to update</param>
    /// <returns>Player updated or null if the player does not exist</returns>
    public async Task<Player?> UpdatePlayer(Player player)
    {
        var result = await _writer.UpdatePlayer(player);

        if (result is null) _logger.Error("Error while updating player {Player}", player);
        else _logger.Info("Player {Player} updated", result);
        
        return result;
    }

    /// <summary>
    /// Delete a player with id.
    /// </summary>
    /// <param name="playerId">Id of the player to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeletePlayer(ulong playerId)
    {
        var result = await _writer.DeletePlayer(playerId);

        if (result) _logger.Info("Player {PlayerId} deleted", playerId);
        else _logger.Error("Error while deleting player {PlayerId}", playerId);
        
        return result;
    }

    /// <summary>
    /// Delete a player with object.
    /// </summary>
    /// <param name="player">Player to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeletePlayer(Player player)
    {
        var result = await _writer.DeletePlayer(player);

        if (result) _logger.Info("Player {Player} deleted", player);
        else _logger.Error("Error while deleting player {Player}", player);
        
        return result;
    }
    
    #endregion
    
    #region Group
    
    /// <summary>
    /// Insert a new group.
    /// </summary>
    /// <param name="name">The name of the group</param>
    /// <param name="players">The players of the group</param>
    /// <returns>The inserted group or null if the player has an id not equals to 0</returns>
    public async Task<Group?> InsertGroup(string name, params Player[] players)
    {
        Group groupToInsert = new(name, players);

        var result = await _writer.InsertGroup(groupToInsert);
        
        if (result is null) _logger.Error("Error while inserting group {Group}", groupToInsert);
        else _logger.Info("Group {Group} inserted", result);
        
        return result;
    }

    /// <summary>
    /// Update a group.
    /// </summary>
    /// <param name="group">Group to update</param>
    /// <returns>Group updated or null if the group does not exist</returns>
    public async Task<Group?> UpdateGroup(Group group)
    {
        var result = await _writer.UpdateGroup(group);
        
        if (result is null) _logger.Error("Error while updating group {Group}", group);
        else _logger.Info("Group {Group} updated", result);
        
        return result;
    }

    /// <summary>
    /// Delete a group with id.
    /// </summary>
    /// <param name="groupId">Id of the group to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeleteGroup(ulong groupId)
    {
        var result = await _writer.DeleteGroup(groupId);
        
        if (result) _logger.Info("Group {GroupId} deleted", groupId);
        else _logger.Error("Error while deleting group {GroupId}", groupId);
        
        return result;
    }

    /// <summary>
    /// Delete a player with object.
    /// </summary>
    /// <param name="group">Group to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeleteGroup(Group group)
    {
        var result = await _writer.DeleteGroup(group);
        
        if (result) _logger.Info("Group {Group} deleted", group);
        else _logger.Error("Error while deleting group {Group}", group);
        
        return result;
    }
    
    #endregion

    #region Hand

    /// <summary>
    /// Insert a new hand.
    /// </summary>
    /// <param name="gameId">The id of the game</param>
    /// <param name="number">The number of the hand</param>
    /// <param name="rules">The Rules of the game applied to this hand </param>
    /// <param name="date">The date of the hand</param>
    /// <param name="takerScore">The score of the taker</param>
    /// <param name="twentyOne">Indicates if the taker as the twenty one oudler</param>
    /// <param name="excuse">Indicates if the taker as the excuse oudler</param>
    /// <param name="petit">Indicates the state of the Petit related to the taker</param>
    /// <param name="chelem">Indicates the state of the Chelem related to the taker</param>
    /// <param name="biddings">Players bidding details</param>
    /// <returns>The inserted hand or null of the hand has an id not equals to 0</returns>
    public async Task<Hand?> InsertHand(
        ulong gameId,
        int number,
        IRules rules,
        DateTime date,
        int takerScore,
        bool? twentyOne,
        bool? excuse,
        PetitResults petit,
        Chelem chelem,
        params KeyValuePair<Player, (Biddings, Poignee)>[] biddings
    )
    {
        var hand = new Hand(number, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings);
        var result = await _writer.InsertHand(gameId, hand);

        if (result is null) _logger.Error("Error while inserting hand {Hand}", hand);
        else _logger.Info("Hand {Hand} inserted", result);

        return result;
    }

    /// <summary>
    /// Update a hand.
    /// </summary>
    /// <param name="hand">Hand to update</param>
    /// <returns>Hand updated or null if it does not exist</returns>
    public async Task<Hand?> UpdateHand(Hand hand)
    {
        var result = await _writer.UpdateHand(hand);
        
        if (result is null) _logger.Error("Error while updating hand {Hand}", hand);
        else _logger.Info("Hand {Hand} updated", result);
        
        return result;
    }

    /// <summary>
    /// Delete a hand with id.
    /// </summary>
    /// <param name="handId">Id of the hand to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeleteHand(ulong handId)
    {
        var result = await _writer.DeleteHand(handId);
        
        if (result) _logger.Info("Hand {HandId} deleted", handId);
        else _logger.Error("Error while deleting hand {HandId}", handId);
        
        return result;
    }

    /// <summary>
    /// Delete a hand with object.
    /// </summary>
    /// <param name="hand">Hand to delete</param>
    /// <returns>True id deleted otherwise false</returns>
    public async Task<bool> DeleteHand(Hand hand)
    {
        var result = await _writer.DeleteHand(hand);
        
        if (result) _logger.Info("Hand {Hand} deleted", hand);
        else _logger.Error("Error while deleting hand {Hand}", hand);
        
        return result;
    }
    
    #endregion
    
    #region Game

    /// <summary>
    /// Insert a new game.
    /// </summary>
    /// <param name="name">The name of the game</param>
    /// <param name="rules">The rules of the game</param>
    /// <param name="startDate">The start date of the game</param>
    /// <param name="players">The players of the game</param>
    /// <returns>The inserted game or null if the game has an id not equals to 0</returns>
    public async Task<Game?> InsertGame(string name, IRules rules, DateTime startDate, params Player[] players)
    {
        Game gameToInsert = new(name, rules, startDate);
        gameToInsert.AddPlayers(players);
        
        var result = await _writer.InsertGame(gameToInsert);
        
        if (result is null) _logger.Error("Error while inserting game {Game}", gameToInsert);
        else _logger.Info("Game {Game} inserted", result);
        
        return result;
    }

    /// <summary>
    /// Update a game.
    /// </summary>
    /// <param name="game">Game to update</param>
    /// <returns>Game updated or null if the player does not exist</returns>
    public async Task<Game?> UpdateGame(Game game)
    {
        var result = await _writer.UpdateGame(game);
        
        if (result is null) _logger.Error("Error while updating game {Game}", game);
        else _logger.Info("Game {Game} updated", result);
        
        return result;
    }

    /// <summary>
    /// Delete a game with id.
    /// </summary>
    /// <param name="gameId">Id of the game to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeleteGame(ulong gameId)
    {
        var result = await _writer.DeleteGame(gameId);
        
        if (result) _logger.Info("Game {GameId} deleted", gameId);
        else _logger.Error("Error while deleting game {GameId}", gameId);
        
        return result;
    }

    /// <summary>
    /// Delete a game with object.
    /// </summary>
    /// <param name="game">Game to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    public async Task<bool> DeleteGame(Game game)
    {
        var result = await _writer.DeleteGame(game);
        
        if (result) _logger.Info("Game {Game} deleted", game);
        else _logger.Error("Error while deleting game {Game}", game);
        
        return result;
    }
    
    #endregion
}