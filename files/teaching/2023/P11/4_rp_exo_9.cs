// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-9
using System;

class RP9
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

    // Fonction : détermine si un caractère donné est un séparateur de mots
    // Paramètres :
    //  - c (char): le caractère à tester
    // Retourne : true si 'c' est un séparateur, false sinon
    // Note : tous les caractères hors lettres et chiffres sont considérés comme séparateurs
    public static bool EstSeparateur(char c)
    {
        if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
            return false;
        return true;
    }

    // Fonction : compte le nombre de mots dans une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de mots dans 'chaine'
    public static int CompterMots(string chaine)
    {
        int mots = 0;
        bool dans_un_mot = false;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstSeparateur(chaine[i]))
            {
                if (dans_un_mot)
                    mots++;
                dans_un_mot = false;
            }
            // lettre ou chiffre
            else
            {
                dans_un_mot = true;
            }
        }
        if (dans_un_mot)
            mots++;
        return mots;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // calculer le nombre de mots
        int n = CompterMots(chaine);
        // afficher le nombre de mots
        AfficheChaine("Il y a " + n + " mots dans la chaine \"" + chaine + "\".");
    }
}