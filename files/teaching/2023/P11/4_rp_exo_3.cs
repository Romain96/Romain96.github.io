// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-3
using System;

class RP3
{

    // Procédure : lit une chaine de caractères depuis le terminal
    // Paramètres :
    //  - msg (string): message textuel à afficher à l'utilisateur
    // Retourne : une chaîne de caractères lue depuis le terminal
    public static string LireChaine(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine();
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : teste si un caractère est une voyelle
    // Paramètres :
    //  - c (char): un caractère
    // Retourne : true si 'c' est une voyelle, false sinon
    public static bool EstVoyelle(char c)
    {
        if (
            c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y' ||
            c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'Y'
        )
            return true;
        return false;
    }

    // Fonction : teste si un caractère est une consonne
    // Paramètres :
    //  - c (char): un caractère
    // Retourne : true si 'c' est une consonne, false sinon
    public static bool EstConsonne(char c)
    {
        // si c est entre 'a' et 'z' (majuscules ou minuscules) et n'est pas une voyelle alors c'est une consonne
        if (((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))  && !EstVoyelle(c))
            return true;
        return false;
    }

    // Fonction : compte le nombre de voyelles d'une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de voyelles dans 'chaine'
    public static int CompterVoyelles(string chaine)
    {
        int voyelles = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstVoyelle(chaine[i]))
                voyelles++;
        }
        return voyelles;
    }

    // Fonction : compte le nombre de consonnes d'une chaine de caractères donnée
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de consonnes dans 'chaine'
    public static int CompterConsonnes(string chaine)
    {
        int consonnes = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstConsonne(chaine[i]))
                consonnes++;
        }
        return consonnes;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // calculer le nombre de voyelles et de consonnes
        int voyelles = CompterVoyelles(chaine);
        int consonnes = CompterConsonnes(chaine);
        // afficher le nombre de voyelles et de consonnes
        AfficheChaine("La chaine \"" + chaine + "\" contient " + voyelles + " voyelles et " + consonnes + " consonnes.");
    }
}