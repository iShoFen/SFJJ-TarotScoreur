using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.games;

namespace Model
{
    public interface IRules
    {
        /// <summary>
        /// Minimun of players needed to play a game with these rules
        /// </summary>
        int MinNbPlayers { get; }
        /// <summary>
        /// Maximum number of player to play a game with these rules
        /// </summary>
        int MaxNbPlayers { get; }
        int MinNbPlayersForKing { get; }
        int MaxNbKing { get; }
        /// <summary>
        /// Name of these rules
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Vérifie que la partie est valide
        /// </summary>
        /// <param name="game">Partie qui est vérifiée</param>
        /// <returns></returns>
        public Validity IsGameValid(Game game);
        /// <summary>
        /// Vérifie que la manche est valide
        /// </summary>
        /// <param name="hand">Manche qui est vérifiée</param>
        /// <returns></returns>
        public Validity IsHandValid(Hand hand, out bool isValid);
        /// <summary>
        /// Calculer et récupérer le score d'une manche
        /// </summary>
        /// <param name="hand">Manche sur laquelle le score est calculé</param>
        /// <returns></returns>
        public IReadOnlyDictionary<Player,int> GetHandScore(Hand hand);

        

    }
}
