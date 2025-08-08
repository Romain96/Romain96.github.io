// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP6 (2023/09/29)
using System;

class SuiteHarmonique
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

    // Procédure : Affiche la valeur de la suite harmonique en n
    // Paramètres :
    //  - n (int) : un entier > 0
    //  - hn (double) : la valeur de la suite harmonique en n
    // Retourne : /
    public static void AfficheHarmonique(int n, double hn)
    {
        Console.WriteLine("Le suite harmonique H(" + n + ") = " + hn);
    }

    // Fonction : calcule la valeur de la suite harmonique en n
    // Paramètres :
    //   - n (int): entier strictement positif
    // Retourne :
    //  - hn (double): la valeur de H(n)
    public static double CalculerSuiteHarmonique(int n)
    {
        if (n < 1)
            return 0.0;

        // Somme pour i=1...n 1/i = 1 + 1/2 + ... + 1/n
        double somme = 0.0;
        for (int i = 1; i <= n; i++)
        {
            somme += 1.0/i;
        }
        return somme;
    }

    static void Main()
    {
        // lire un entier n
        int n = LireEntier("Entrez un entier > 0 : ");
        // calculer la valeur de la suite harmonique en n : H(n)
        double hn = CalculerSuiteHarmonique(n);
        // afficher le résultat
        AfficheHarmonique(n, hn);
    }
}