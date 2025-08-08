// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 5
using System;

class Suppression
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

    // Procédure : lit un caractère depuis le terminal
    // Paramètres :
    //  - msg (string): message textuel à afficher à l'utilisateur
    // Retourne : le premier caractère de la chaine lue depuis le terminal
    // Note : la chaine lue ne doit pas être vide, retourne le caractère null (ASCII 0) le cas echéant
    public static char LireCaractere(string msg)
    {
        Console.Write(msg);
        string input = Console.ReadLine();
        if (input.Length > 0)
            return input[0];
        else
            return (char)0;
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : supprime toutes les occurrences d'un caractère donné dans une chaine donnée
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    //  - cible (char): un caractère à supprimer dans 'chaine'
    // Retourne : la chaine 'chaine' dont toutes les occurrences de 'cible' ont été supprimées
    public static string SupprimerCaractere(string chaine, char cible)
    {
        string res = "";
        for (int i = 0; i < chaine.Length; i++)
        {
            if (chaine[i] != cible)
                res += chaine[i];
        }
        return res;
    }

    static void Main()
    {
        // demander une chaine et un caractère cible
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        char cible = LireCaractere("Entrez un caractère à supprimer : ");
        // supprimer toutes les occurrences de cible dans chaine
        string chaine_sans_cible = SupprimerCaractere(chaine, cible);
        // afficher la nouvelle chaine
        AfficheChaine(chaine_sans_cible);
    }
}