// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP6 (2023/09/29)
using System;

class Premier
{
    // Précédures
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

    // Procédure : Affiche dans le terminal 'le nombre __ (n') est (pas) premier'
    // Paramètres :
    //  - nb (int) : le nombre entier testé
    //  - estPremier (bool): true si nb est premier, false sinon
    // Retourne : /
    public static void AffichePremier(int nb, bool estPremier)
    {
        if (estPremier)
            Console.WriteLine("Le nombre " + nb + " est premier.");
        else
            Console.WriteLine("Le nombre " + nb + " n'est pas premier.");
    }

    // Fonctions
    /// <summary>Teste si un nombre entier est premier.</summary>
    /// <param name="n">L'entier à tester.</param>
    /// <returns>true si <paramref name="n"/> est premier, false sinon.</returns>
    public static bool EstPremier(int n)
    {
        if (n <= 1)
            return false;

        // parcourir les nombres de 2 à n-1
        // vérifier si le modulo vaut 0
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    // Fonction : exercice 1 : demander un nombre et afficher s'il est premier
    // Paramètres : /
    // Retourne : /
    public static void Exercice1()
    {
        // lire un entier depuis le terminal
        int n = LireEntier("Entrez un nombre entier (> 0) :");
        // tester si le nombre est premier
        bool estPremier = EstPremier(n);
        // afficher le résultat
        AffichePremier(n, estPremier);
    }

    // Exercice 2 : demander deux bornes et afficher 
    // la liste des entiers premiers entre ces deux bornes
    // Paramètres : /
    // Retourne : /
    public static void Exercice2()
    {
        // lire la borne inférieure et la borne supérieure
        int inf = LireEntier("Entrez la borne inférieure : ");
        int sup = LireEntier("Entrez la borne supérieure : ");
        // parcourir les nombres de borne inférieure à supérieurs incluses
        for (int i = inf; i <= sup; i++)
        {
            // afficher les nombres premiers
            bool estPremier = EstPremier(i);
            if (estPremier)
                AffichePremier(i, estPremier);
        }
    }

    // Main
    static void Main()
    {
        Exercice1(); 
        Exercice2();        
    }
}