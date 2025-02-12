// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP5 (2023/09/29)
using System;
class Factorielle
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

    // Procédure : afficher une chaîne dans le terminal
    // Paramètres :
    //  - str (string): chaîne à afficher
    // Retourne : /
    public static void AfficherChaine(string str)
    {
        Console.WriteLine(str);
    }

    // Fonction : calcule la factorielle d'un entier n
    // Paramètres :
    //  - n (int): l'entier n pour lequel calculer n!
    // Retourne :
    //  - fact (int): n!
    public static int CalculerFactorielle(int n)
    {
        if (n < 1)
            AfficherChaine("Vous êtes stupide !");

        int fact = 1;
        for (int i = 2; i <= n; i+=1)
            fact *= i;
        return fact;
    }

    // Fonction : calcule la probabilité de trouver le podium dans l'ordre
    // Paramètres :
    //  - n (int): le nombre de chevaux
    //  - p (int): la taille du podium
    // Retourne :
    //  - proba (double): n! / (n-p)!
    public static double CalculerProbaPodiumOrdre(int n, int p)
    {
        double proba = CalculerFactorielle(n);
        proba = proba / CalculerFactorielle(n-p);
        return proba;
    }

    // Fonction : calcule la probabilité de trouver le podium dans le désordre
    // Paramètres :
    //  - n (int): le nombre de chevaux
    //  - p (int): la taille du podium
    // Retourne :
    //  - proba (double): n! / (p!*(n-p)!)
    public static double CalculerProbaPodiumDesordre(int n, int p)
    {
        double proba = CalculerFactorielle(n);
        proba = proba / (CalculerFactorielle(p) * CalculerFactorielle(n-p));
        return proba;
    }
    static void Main()
    {
        // demander deux entiers n (chevaux) et p (podium)
        int n = LireEntier("Entrez le nombre de chevaux : ");
        int p = LireEntier("Entrez la taille du podium : ");
        // calculer la probabilité de gagner dans l'ordre
        double pOrdre = CalculerProbaPodiumOrdre(n, p);
        // calculer la probabilité de gagner dans le désordre
        double pDesordre = CalculerProbaPodiumDesordre(n, p);
        // afficher les deux probas
        AfficherChaine(
            "La probabilité de trouver un podium de taille " 
            + p + " parmi " + n + " chevaux dans l'ordre est de " 
            + pOrdre + " (" + 1.0/pOrdre + ")"
        );
        AfficherChaine(
            "La probabilité de trouver un podium de taille " 
            + p + " parmi " + n + " chevaux dans le désordre est de " 
            + pDesordre + " (" + 1.0/pDesordre + ")"
        );
    }
}