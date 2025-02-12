// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExercicePourDebuter2
{
    // Fonction : génère une chaine de caractères à partir d'un dictionnaire
    // Paramètres :
    //  - dico (Dictionary<string, List<int>>): dictionnaire contenant des joueurs et leurs buts marqués par match
    // Retourne :
    //  - chaine (string): chaine contenant les données de `dico`
    public static string ToString2(Dictionary<string, List<int>> dico)
    {
        string chaine = "----------------------------------------\n";
        chaine += "Statistiques des buts :\n";
        string buts = "absent";
        foreach (KeyValuePair<string, List<int>> kvp in dico)
        {
            chaine += $"Buts de {kvp.Key} : ";
            for (int i = 0; i < kvp.Value.Count - 1; i++)
            {
                buts = "absent";
                if (kvp.Value[i] >= 0)
                    buts = kvp.Value[i].ToString();
                chaine += $"{buts} au match {i + 1}, ";
            }
            buts = "absent";
            if (kvp.Value[kvp.Value.Count - 1] >= 0)
                    buts = kvp.Value[kvp.Value.Count - 1].ToString();
            chaine += $"{buts} au match {kvp.Value.Count}\n";
        }
        chaine += "----------------------------------------";
        return chaine;
    }

    // Fonction : calcule le nombre de buts marqués pendant un match
    // Paramètres :
    //  - dico (Dictionary<string, List<int>>): dictionnaire contenant des joueurs et leurs buts marqués
    // Retourne :
    //  - total (int): le nombre de buts marqués par les joueurs de `dico`
    public static int CalculNbButsTotal2(Dictionary<string, List<int>> dico)
    {
        int total = 0;
        foreach (KeyValuePair<string, List<int>> kvp in dico)
        {
            foreach (int buts in kvp.Value)
            {
                if (buts != -1)
                {
                    total += buts;
                }
            }
        } 
        return total;
    }

    // Fonction : retourne le joueur ayant marqué le plus de buts
    // Paramètres :
    //  - dico (Dictionary<string, List<int>>): dictionnaire contenant des joueurs et leurs buts marqués
    // Retourne :
    //  - meilleurJoueur (string): le nom du joueur ayant marqué le plus de buts
    // Précondition :
    //  - `dico` ne doit pas être vide
    public static string CalculMeilleurJoueur(Dictionary<string, List<int>> dico)
    {
        string meilleurJoueur = "N/A";
        int MeilleurButs = 0;
        foreach (KeyValuePair<string, List<int>> kvp in dico)
        {
            int total = 0;
            foreach (int buts in kvp.Value)
            {
                if (buts != -1)
                {
                    total += buts;
                }
            }
            if (total > MeilleurButs)
            {
                meilleurJoueur = kvp.Key;
                MeilleurButs = total;
            }
        } 
        return meilleurJoueur;
    }

    // Fonction : retourne la liste des joueurs absents
    // Parameètres :
    //  - dico (Dictionary<string, List<int>>): dictionnaire contenant des joueurs et leurs buts marqués
    // Retourne :
    //  - absents (List<string>): liste des joueurs absents à tous les matches de la saison
    public static List<string> CalculJoueursAbsents(Dictionary<string, List<int>> dico)
    {
        List<string> absents = new List<string>();
        foreach (KeyValuePair<string, List<int>> kvp in dico)
        {
            bool absent = true;
            foreach (int buts in kvp.Value)
            {
                if (buts != -1)
                {
                    absent = false;
                }
            }
            if (absent)
            {
                absents.Add(kvp.Key);
            }
        } 
        return absents;
    }
    
    // Procédure : affichage d'une liste de chaines de caractères dans la console
    // Paramètres :
    //  - liste (List<string>): liste de chaines
    // Retourne : rien
    public static void AfficherListe(List<string> liste)
    {
        foreach (string elt in liste)
        {
            Console.WriteLine($"{elt}");
        }
    }

    static void Main()
    {
        // 1 - création de la table
        Dictionary<string, List<int>> d = new Dictionary<string, List<int>>();

        // 2 - ajout des éléments (TryAdd vérifie l'existence de la clef)
        d.TryAdd("Lise", new List<int>() {2, 8, -1, 0});
        d.TryAdd("Fab", new List<int>() {18, -1, -1, -1});
        d.TryAdd("Tom", new List<int>() {2, 2, 0, 0});
        d.TryAdd("Léa", new List<int>() {-1, -1, -1, -1});
        d.TryAdd("Sam", new List<int>() {-1, -1, -1, -1});

        // 3 - affichage dans une chaine
        Console.WriteLine(ToString2(d));

        // 4 - nombre total de buts
        Console.WriteLine($"Nombre total de buts marqués : {CalculNbButsTotal2(d)}");

        // 5 - recherche du meilleur joueur
        Console.WriteLine($"Le meilleur joueur est {CalculMeilleurJoueur(d)}");

        // 6 - recherche des joueurs absents
        Console.WriteLine("Les joueurs absents sont : ");
        AfficherListe(CalculJoueursAbsents(d));
    }
}