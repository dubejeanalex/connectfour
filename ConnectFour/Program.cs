using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Media; // Décommenter pour utiliser cet librairie pour ajouter des sons. (info trouvé https://stackoverflow.com/questions/34116886/how-to-play-background-music-in-a-c-sharp-console-application)
//  SoundPlayer player = new SoundPlayer(); // Creer le lecteur de son  // à utiliser dans le main
// player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Alarm01.wav"; // Chemin pour faire jouer la musique // à utiliser dans le main 
// player.Play(); // le lecteur lis la musique // à utiliser dans le main 
namespace ConnectFour

{
    public class Program
    {
        public static void Main(string[] args)
        {

            JouerEnfin();                    
            Console.ReadKey();
        }
        /// <summary>
        /// Fonction qui permet d'exécuter jeu dans le main
        /// </summary>
        public static void JouerEnfin()
        {
            //Déclaration des variables.

            char[,] tabjeu = new char[6, 7]; // tableau 6 ligne et 7 colonnes.
            Jeu matrice = new Jeu(tabjeu); 
            matrice.PartieTermine = false;
            bool rejouer = true;

            while (rejouer == true) // Boucle qui permet de rejouer.
            {
                matrice.RemplirJeu(tabjeu); // Fonction qui initialise mon jeu 
                matrice.Jouer(tabjeu, matrice.PartieTermine); // Fonction qui fait tourner le jeu retourne un bool
                matrice.AfficherJeu(tabjeu);
                Console.ReadKey();
                Console.WriteLine(" Pour jouer une autre partie écrivez oui. ");
                string nouvellePartie = Console.ReadLine();
                nouvellePartie = nouvellePartie.ToUpper(); // Éviter erreur quand est entrez en minuscule

                if (nouvellePartie == "OUI") // Vérifie si e joueur a entrer oui pour jouer une autre partie.
                {
                    rejouer = true;
                    Console.WriteLine("Vous avez choisi de jouer une partie.");
                }
                else 
                {
                    rejouer = false;
                    Console.WriteLine(" Merci d'avoir joueé à mon jeu puissance 4 !! ");
                }
                
            } // Fin while
        }// Fin fonction JouerEnfin



    }
}
