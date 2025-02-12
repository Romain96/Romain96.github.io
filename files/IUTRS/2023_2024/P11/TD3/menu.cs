// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP6 (2023/09/29)
using System;

class Menu
{
    // Procédure : lire un entier depuis le terminal
    // Paramètres :
    //  - msg (string) : le message à afficher à l'utilisateur
    // Retourne : 
    //  - nb (int): l'entier lu et converti depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        int nb = int.Parse(Console.ReadLine());
        return nb;
    }

    // Procédure : Afficher un entier dans le terminal
    // Paramètres :
    //  - msg (string): le message à afficher avant n
    //  - n (int): l'entier à afficher
    // Retourne : /
    public static void AfficherEntier(string msg, int n)
    {
        Console.WriteLine(msg + n);
    }

    // Fonction : Effectue les actions en boucle jusqu'à interruption
    // Paramètres :
    //  - n (int): la valeur par défaut de n
    // Retourne : /
    public static void Menu(int n)
    {
        // Répéter à l'infini
        //  - Afficher n
        //  - Afficher un menu avec 4 options
        //      - 1 : +1
        //      - 2: *2
        //      - 3: -4
        //      - 4: quitter la boucle et le programme
        // effectuer l'action demandée
        bool continuer = true;
        while (continuer)
        {
            AfficherEntier("n = ", n);
            int choix = LireEntier("Entrez votre choix : ");

            if (choix == 1)
            {
                n += 1;
            }
            else if (choix == 2)
            {
                n *= 2;
            }
            else if (choix == 3)
            {
                n -= 4;
            }
            else if (choix == 4)
            {
                continuer = false;
            }
        }
    }
    static void Main()
    {
        // initialiser n = 0
        int n = 0;
        // Appeler la boucle infinie
        Menu(n);
    }
}