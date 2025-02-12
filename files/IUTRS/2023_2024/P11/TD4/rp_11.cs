// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-11
using System;

class RP11
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

    // Fonction : compte le nombre d'occurrences d'un caractères dans une chaine
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

    // Fonction : détermine le caractère ayant le plus grand nombre d'occurrences dans une chaine
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le caractère ayant le plus grand nombre d'occurrences dans 'chaine'
    // Note : en cas d'égalite, le caractère le plus petit (alphabétique) est retourné
    // Note : la chaine ne doit pas être vide
    public static char PlusGrandNombreOccurrences(string chaine)
    {
        char plus_frequent = (char)255;   // caractère 255 dans le code ASCII
        int occurrences = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            int occurrences_i = CompterOccurrences(chaine, chaine[i]);
            if (occurrences_i > occurrences)
            {
                plus_frequent = chaine[i];
                occurrences = occurrences_i;
            }
            else if (occurrences_i == occurrences)
            {
                // ordre alphabétique
                if (chaine[i] < plus_frequent)
                    plus_frequent = chaine[i];
                    occurrences = occurrences_i;
            }
        }
        return plus_frequent;
    }
    
    static void Main()
    {
        // demander une chaine
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // déterminer le caractère le plus fréquent
        char plus_frequent = PlusGrandNombreOccurrences(chaine);
        // afficher le caractère
        AfficheChaine(
            "Le caractère '" + plus_frequent + "' (code ASCII " + (int)plus_frequent + 
            ") est le plus fréquent dans la chaine \"" + chaine + "\"."
        );
    }
}