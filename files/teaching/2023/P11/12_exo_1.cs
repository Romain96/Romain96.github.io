// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExercicePourDebuter1
{
    // Fonction : génère une chaine de caractères à partir d'un dictionnaire
    // Paramètres :
    //  - dico (Dictionary<string, int>): dictionnaire contenant des joueurs et leurs nombre de buts marqués
    // Retourne :
    //  - chaine (string): chaine contenant les données de `dico`
    public static string ToString1(Dictionary<string, int> dico)
    {
        string chaine = "----------------------------------------\n";
        chaine += "Statistiques des buts :\n";
        foreach (KeyValuePair<string, int> kvp in dico)
        {
            chaine += $"{kvp.Key} a marqué {kvp.Value} buts\n";
        }
        chaine += "----------------------------------------";
        return chaine;
    }

    // Fonction : calcule le nombre de buts marqués pendant un match
    // Paramètres :
    //  - dico (Dictionary<string, int>): dictionnaire contenant des joueurs et leurs nombre de buts marqués
    // Retourne :
    //  - total (int): le nombre de buts marqués par les joueurs de `dico`
    public static int CalculNbButsTotal1(Dictionary<string, int> dico)
    {
        int total = 0;
        foreach (KeyValuePair<string, int> kvp in dico)
        {
            total += kvp.Value;
        } 
        return total;
    }

    // Procédure : inversion de deux valeurs étant données deux clef valides
    // Paramètres :
    //  - dico (Dictionary<string, int>): dictionnaire contenant des joueurs et leurs nombre de buts marqués
    //  - clef1 (string): clef de recherche 1
    //  - clef2 (string): clef de recherche 2
    // Retourne : rien
    public static void Inverse(Dictionary<string, int> dico, string clef1, string clef2)
    {
        int val1;
        int val2;
        if (dico.TryGetValue(clef1, out val1) && dico.TryGetValue(clef2, out val2))
        {
            dico[clef1] = val2;
            dico[clef2] = val1;
        }
    }

    static void Main()
    {
        // 1 - création de la table
        Dictionary<string, int> d = new Dictionary<string, int>();

        // 2 - ajout des éléments (TryAdd vérifie l'existence de la clef)
        d.TryAdd("Lise", 15);
        d.TryAdd("Fab", 30);
        d.TryAdd("Tom", 2);
        d.TryAdd("Léa", 8);
        d.TryAdd("Sam", 0);

        // 3 - affichage dans une chaine
        Console.WriteLine(ToString1(d));

        // 4 - nombre total de buts
        Console.WriteLine($"Nombre total de buts marqués : {CalculNbButsTotal1(d)}");

        // 5 - inversion de deux valeurs
        Console.WriteLine("Après inversion du nombre de buts de Sam et Lise :");
        Inverse(d, "Sam", "Lise");
        Console.WriteLine(ToString1(d));

        // 6 - suppression des valeurs de la table
        d.Clear();
        Console.WriteLine("Après suppression des éléments : ");
        Console.WriteLine(ToString1(d));
    }
}