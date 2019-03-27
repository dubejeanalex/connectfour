using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Jeu
    {
        private char[,] tableau = new char[6, 7];
        private bool tour = true;
        private bool partieTermine = false;
        private Joueur j1 = new Joueur(true,"Joueur 1");
        private Joueur j2 = new Joueur(false, "Joueur 2");
        private int coupJoue = 0;

        /// <summary>
        /// Constructeur avec un parametre pour le jeu.
        /// </summary>
        /// <param name="jeu">Matrice du jeu </param>
        public Jeu(char[,] jeu)
        {

        }

        public char[,] Tableau { get => tableau; set => tableau = value;} // Accesseur.
        public bool Tour { get => tour; set => tour = value; } //Accesseur.
        public bool PartieTermine { get => partieTermine; set => partieTermine = value; } //Accesseur.
        public Joueur J1 { get => j1; set => j1 = value; } // Accesseur.
        public Joueur J2 { get => j2; set => j2 = value; } // Accesseur.
        public int CoupJoue { get => coupJoue; set => coupJoue = value; } //Accesseur.

        /// <summary>
        /// Méthode pour afficher le jeu.
        /// </summary>
        /// <param name="jeu">Tableau de jeu. </param>
        public void AfficherJeu(char[,] jeu)
        {
         //   if (partieTermine == false) ;
        //    { Console.Clear(); } // Permet d'effacer la console et afficher seulement le jeu en cours.}
                

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (jeu[i, j] == 'X') // Vérifie si il y a un jeton du joueur 1 et applique la mise en forme.
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|" + jeu[i, j] + "|");
                    }
                    else if (jeu[i, j] == 'O') // Vérifie si il y a un jeton du joueur 2 et applique la mise en forme.
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|" + jeu[i, j] + "|");
                    }
                    
                   else
                        Console.Write("|"+jeu[i, j]+"|");
                        Console.ResetColor();

                }
                Console.WriteLine();
            }
            Console.ResetColor();
        } // Fin méthode

        /// <summary>
        /// Méthode pour remplir le jeu. 
        /// </summary>
        /// <param name="jeu">Char[6,7] ou 6 est les ligne horizontales et 7 colonnes verticales.</param>
        /// <returns></returns>
        public char[,] RemplirJeu(char[,] jeu)
        {
            for (int i = 0; i < 6; i++) // 6 lignes.
            {
                for (int j = 0; j < 7; j++) // 7 Colonnes.
                {
                    jeu[i, j] = '0';
                }
            }
            return jeu;
        }

        /// <summary>
        /// Méthode pour changer le joueur.
        /// </summary>
        /// <param name="tour">Nombre de coup joués.</param>
        /// <returns></returns>
        public bool ChangerJoueur(int tour)
        {
            if (tour % 2 == 0) // Pair
            {
                j1.Tour = true;
            }
            else // impair
                j1.Tour = false;
            return j1.Tour;

        }
        /// <summary>
        /// C'est dans cette fonction que mon jeu s'exécute.
        /// </summary>
        /// <param name="jeu">Grille de jeu. </param>
        /// /// <param name="PartieTermine">Sert à la vérifier si la partie est terminée. </param>
        /// <returns></returns>
        public bool Jouer(char[,] jeu,bool PartieTermine)
        {
           
         
            while(partieTermine==false)
            {               
                char jeton = 'f'; // Valeure temporaire.
                AfficherJeu(jeu); // Fonction pou afficher jeu. 
                int choix = validerCoup(); // Fonction pour jouer et vérifier le coup.                                 
            
                    if (j1.Tour == true) // Vérification pour savoir quel jeton mettre. 
                    {
                        jeton = 'X'; // Joueur 1
                    }
                    else
                        jeton = 'O'; // Joueur 2

                    if (jeu[5, choix - 1] == '0')
                    {
                        jeu[5, choix - 1] = jeton;
                    }
                    else if (jeu[4, choix - 1] == '0')
                    {
                        jeu[4, choix - 1] = jeton;
                    }
                    else if (jeu[3, choix - 1] == '0')
                    {
                        jeu[3, choix - 1] = jeton;
                    }
                    else if (jeu[2, choix - 1] == '0')
                    {
                        jeu[2, choix - 1] = jeton;
                    }
                    else if (jeu[1, choix - 1] == '0')
                    {
                        jeu[1, choix - 1] = jeton;
                    }
                    else if (jeu[0, choix - 1] == '0')
                    {
                        jeu[0, choix - 1] = jeton;
                    }
                    else   // Ça veut dire que la colonne n'est pas disponible.
                    {
                    Console.WriteLine(" Veuillez choisir une autre colonne svp. La colonne:  "+ choix +" est déjà occupe.");
                    CoupJoue--;                            
                    } // Fin else
                    CoupJoue++; // Compteur qui fait augmenter les coups joués et permet d'alterner les joueurs.

               if(Gagner(jeu, partieTermine) == true) // Permet de vérifier si un joueur gagne.
                {
                    return true;
                }
                if (ChangerJoueur(coupJoue) == true)
                {
                    Console.WriteLine(" C'est au joueur 1 à jouer.");
                }
                else
                    Console.WriteLine("C'est au joueur 2 à joueur");
                ChangerJoueur(CoupJoue); // Alterne les joueurs 

            } // Fin while boucle de jeu

            return false;
                       
        } // Fin fonction jeu

        /// <summary>
        /// Fontion qui sert à faire jouer le  joueur et valider son coup.
        /// </summary>
        /// <returns></returns>
        public static int validerCoup()
        {
            int choix = 0;
            Console.WriteLine(" Veuillez choisir dans quelle colonne jouer. ");            
            
            string temp = Console.ReadLine(); // lecture en string du choix. 
            if (UnChiffre(temp) == true) //valider si on peut transformer temp en chiffre.
            {
                choix = int.Parse(temp);
            }// Fin if

            else // boucle jusqu'on aie une valeur en int. 
            {
                Console.WriteLine(" Veuillez entrer un chiffre de 1 à 6. Vous devez jouer autre chose ");
                temp = Console.ReadLine();
                while (UnChiffre(temp) == false)
                {

                    Console.WriteLine(" Veuillez entrer un chiffre de 1 à 6. Vous devez jouer autre chose ");
                    temp = Console.ReadLine();
                }
                choix = int.Parse(temp);
            } // Fin else          


            if (choix < 1 || choix > 7) // Erreur vous n'êtes pas dans le jeu.
            {
                Console.WriteLine("Vous êtes en dehors du jeu, veuillez choisir une autre colonne. "); 
                string temp2 = Console.ReadLine(); // Valeur temporaire pour prendre la réponse et éviter les erreurs                 
                while (choix < 1 || choix > 7) // Boucle pour obtenir un choix valide.
                {
                    Console.WriteLine("Vous êtes en dehors du jeu, veuillez choisir une autre colonne. ");
                    string choixString = Console.ReadLine();
                    if (UnChiffre(choixString) == true) //valider si on peut transformer temp en chiffre.
                    {
                        choix = int.Parse(choixString); // Donner la valeur valide à choix
                    }// Fin if
                    else // On reprend une autre reponse
                    {
                        Console.WriteLine("Vous êtes en dehors du jeu, veuillez choisir une autre colonne. ");
                        choixString = Console.ReadLine();
                    } // FIn else
                } //Fin while
            } // Fin if
            
            return choix;
        } // Fin fonction validerCoup
        public static bool Gagner(char[,] jeu,bool gagne)
        {
            int ind = 0;
            int indy = 5;                      

            for (int i = 0; i < 4; i++) // Verification horizontale.
            {
                for (int j = 0; j < 4; j++) // Boucle vérifier les 4 positions.
                {
                    if (jeu[indy, ind] == 'X' && jeu[indy, ind + 1] == 'X' && jeu[indy, ind + 2] == 'X' && jeu[indy, ind + 3] == 'X') // Conditions gagnantes joueur1.
                    {
                        gagne = true;
                        Console.WriteLine("Joueur 1 vous avez gagné horizontalement !!");
                        
                    }//fin if
                    else if (jeu[indy, ind] == 'O' && jeu[indy, ind + 1] == 'O' && jeu[indy, ind + 2] == 'O' && jeu[indy, ind + 3] == 'O') // Conditions gagnantes joueur2.
                    {
                        Console.WriteLine("Joueur 2 vous avez gagné horizontalement !!");
                        gagne = true;
                    }
                    ind++; // augmente x de 1. 
                } // Fin boucle.
                indy--; //Diminue y de 1. 
                ind = 0; // remise de mon indice.
            } // fin boucle verification horizontale.
            ind = 0; // remise valeur ind.
            indy = 5; // remise valeur indy.

            for (int i = 0; i < 3; i++) // Vérification des coups verticales.
            {
                for (int j = 0; j < 7; j++) // Boucle pour parcourir ind(X).
                {
                    if (jeu[indy, ind] == 'X' && jeu[indy - 1, ind] == 'X' && jeu[indy - 2, ind] == 'X' && jeu[indy - 3, ind] == 'X') // condition gagnante joueur 1
                    {
                        Console.WriteLine(" Joueur 1 vous avez gagné à la vertical !!");
                        gagne = true;
                    }
                    else if (jeu[indy, ind] == 'O' && jeu[indy - 1, ind] == 'O' && jeu[indy - 2, ind] == 'O' && jeu[indy - 3, ind] == 'O') // Condition gagnante joueur 2
                    {
                        Console.WriteLine(" Joueur 2 vous avez gagné à la vertical !!");
                        gagne = true;
                    }
                    ind++; // augmente ind(x).
                } // Fin boucle.
                ind = 0;//remise a 0 ind.
                indy--;
            } // Fin boucle vérification verticals.
            ind = 0; // Remise valeur ind.
            indy = 5;//remise valeur indy.
            for (int i = 0; i  <4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (jeu[indy, ind] == 'X' && jeu[indy-1, ind+1] == 'X' && jeu[indy-2, ind+2] == 'X' && jeu[indy- 3,ind+3] == 'X')//Condition gagnante joueur 1
                    {
                    Console.WriteLine(" Joueur 1 vous avez gagné en diagonale !! ");
                        gagne = true;
                    }//Fin si
                    else if (jeu[indy, ind] == 'O' && jeu[indy - 1, ind + 1] == 'O' && jeu[indy - 2, ind + 2] == 'O' && jeu[indy - 3, ind + 3] == 'O')// Cnndition gagnante joueur 2
                    {
                        Console.WriteLine(" Le joueur 2 vous avez gagné en diagonale !! ");
                        gagne = true;
                    }//fin si joueur 2.

                    ind++; // Augmente de 1 la position x. 
                }//Fin boucle
                ind = 0; // Compteur pour remettre ind à 0.
                indy--; // Diminue de 1 la position y.                      
            } // Fin for vérification diagonale en x+1y+1.
            ind = 6; // Remise valeur ind.
            indy = 5; // Remise valeur indy.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (jeu[indy, ind] == 'X' && jeu[indy -1, ind -1] == 'X' && jeu[indy - 2, ind - 2] == 'X' && jeu[indy - 3, ind - 3] == 'X') // Condition gagnante joueur 1.
                    {
                        Console.WriteLine(" Joueur 2 vous avez gagné en diagonale !! ");
                        gagne = true;

                    } // fin if
                    else if (jeu[indy, ind] == 'O' && jeu[indy - 1, ind - 1] == 'O' && jeu[indy - 2, ind - 2] == 'O' && jeu[indy - 3, ind - 3] == 'O') // Condition gagnante joueur 2.
                    {
                        Console.WriteLine(" Joueur 2 vous avez gagné en diagonale !! ");
                        gagne = true;
                    } // fin else if.
                    ind--;
                }//Fin boucle. 
                ind = 6;
                indy--;
            }//fin boulce verification diagonale en x-1y+1.
            
            return gagne; // Retour qui arrete la boucle s'il y a un gagnant.
        }
        /// <summary>
        /// Fonction qui permet de vérifier si le string entré se tranforme en int.
        /// </summary>
        /// <param name="nombre">choix du nombre en string.</param>
        /// <returns></returns>
        public static bool UnChiffre(string nombre)  // aider à partir du lien suivant : https://codes-sources.commentcamarche.net/forum/affich-207467-test-si-une-variable-est-numerique
        {
            try// Vérifie si on peut transformer nombre en int.
            {
                int.Parse(nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }


       
    }
}
