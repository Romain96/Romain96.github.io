// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 4
using System;

class NbOccurrences
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
    // Note : la chaine lue ne doit pas être vide, retourne un espace le cas echéant
    public static char LireCaractere(string msg)
    {
        Console.Write(msg);
        string input = Console.ReadLine();
        if (input.Length > 0)
            return input[0];
        else
            return ' ';
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : compte le nombre d'occurrences d'un caractère dans une chaine
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    //  - cible (char): un caractère à compter dans 'chaine'
    // Retourne : le nombre d'occurrences de 'cible' dans 'chaine
    public static int CompterOccurrences(string chaine, char cible)
    {
        int occurrences = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (chaine[i] == cible)
                occurrences++;
        }
        return occurrences;
    }

    static void Main()
    {
        // demander une chaine et un caractère cible
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        char cible = LireCaractere("Entrez un caractère dont le nombre d'occurrences est recherché : ");
        // calculer le nombre d'occurrences de cible dans chaine
        int nb = CompterOccurrences(chaine, cible);
        // afficher le nombre d'occurrences
        AfficheChaine("Il y a " + nb + " occurrences de " + cible + " dans " + chaine);
    }
}