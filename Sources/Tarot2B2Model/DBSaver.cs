using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DBSaver : ISaver
{
    public void SavePlayer(Player player)
    {
        using(var context = new TarotDBContext())
        {
            context.Players.Add(player.ToEntity());
            context.SaveChanges();
        }
    }

    public void SaveGame(Game game)
    {
        using(var context = new TarotDBContext())
        {
            context.Games.Add(game.ToEntity());
            context.SaveChanges();
        }
    }

    public void SaveGroup(Group group)
    {
        using(var context = new TarotDBContext())
        {
            context.Groups.Add(group.ToEntity());
            context.SaveChanges();
        }    
    }
}