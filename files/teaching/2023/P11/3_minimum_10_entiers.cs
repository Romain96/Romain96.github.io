// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP5 (2023/09/29)
using System;

class Minimum10
{
    // Procédure : lire un entier depuis le terminal
    // Paramètres :
    //  - msg (string): le message à afficher à l'utilisateur
    // Retourne :
    //  - n (int): l'entier lu et converti depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        int n = int.Parse(Console.ReadLine());
        return n;
    }

    // Procédure : afficher un entier dans le terminal
    // Paramètres :
    //  - msg (string): le message précédent le nombre
    //  - n (int): l'entier à afficher
    // Retourne : /
    public static void AfficherEntier(string msg, int n)
    {
        Console.WriteLine(msg + n);
    }

    // Fonction : demande 10 entiers et retourne le minimum
    // Paramètres : /
    // Retourne : 
    //  - somme (int): le minimum des 10 entiers
    public static int CalculerMinimum()
    {
        int minimum = LireEntier("Entrez un entier : ");
        for(int i = 0; i < 9; i++)
        {
            // lire un entier depuis le terminal
            int nUser = LireEntier("Entrez un entier : ");
            // tester si nUser est le nouveau minimum*
            if (nUser < minimum)
                minimum = nUser;
        }
        return minimum;
    }
    
    static void Main()
    {
        // répéter 10 fois :
        //  - demander un entier
        int min = CalculerMinimum();
        // afficher la somme
        AfficherEntier("le minimum vaut : ", min);
    }
}