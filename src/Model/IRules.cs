using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRules
    {
        public int MinNbPlayers { get; }
        public int MaxNbPlayers { get; }
        public int MinNbPlayersForKing { get; }
        public int MaxNbKing { get; }
        public string Name { get; }

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
        public Validity IsHandValid(Hand hand);
        /// <summary>
        /// Calculer et récupérer le score d'une manche
        /// </summary>
        /// <param name="hand">Manche sur laquelle le score est calculé</param>
        /// <returns></returns>
        public int GetHandScore(Hand hand);

        

    }
}
