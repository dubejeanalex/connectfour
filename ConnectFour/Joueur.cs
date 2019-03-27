using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Joueur
    {
        bool tour = true;
        string nom = "";

        /// <summary>
        /// Constructeur avec le nom du joueur et son tour. 
        /// </summary>
        /// <param name="tour">bool  qui permet d'alterner le tour des joueurs.</param>
        /// <param name="nom">Nom que le joueur aura.</param>
        public Joueur(bool tour,string nom)

        {

        }

        public string Nom { get => nom; set => nom = value; } // Accesseur
        public bool Tour { get => tour; set => tour = value; } // Accesseur
    }
}
