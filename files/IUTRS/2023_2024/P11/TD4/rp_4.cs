// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-4
using System;

class RP4
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

    // Fonction : détermine si un caractère est une lettre
    // Paramètres :
    //  - c (char): le caractère à tester
    // Retourne : vrai si 'c' est une lettre, faux sinon
    // Note : ne tient pas compte de la casse
    public static bool EstLettre(char c)
    {
        if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            return true;
        return false;
    }

    // Fonction : détermine si un caractère est un chiffre
    // Paramètres :
    //  - c (char): le caractère à tester
    // Retourne : vrai si 'c' est un chiffre, faux sinon
    public static bool EstChiffre(char c)
    {
        if (c >= '0' && c <= '9')
            return true;
        return false;
    }

    // Fonction : détermine si un caractère est une caractère spécial
    // Paramètres :
    //  - c (char): le caractère à tester
    // Retourne : vrai si 'c' est un caractère spécial (ni lettre ni chiffre), faux sinon
    public static bool EstCaractereSpecial(char c)
    {
        // ni une lettre, ni un chiffre
        if (!EstLettre(c) && !EstChiffre(c))
            return true;
        return false;
    }

    // Fonction : compte le nombre de lettre d'une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de lettres dans 'chaine'
    public static int CompterLettres(string chaine)
    {
        int lettres = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstLettre(chaine[i]))
                lettres++;
        }
        return lettres;
    }

    // Fonction : compte le nombre de chiffres d'une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de chiffres dans 'chaine'
    public static int CompterChiffres(string chaine)
    {
        int chiffres = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstChiffre(chaine[i]))
                chiffres++;
        }
        return chiffres;
    }

    // Fonction : compte le nombre de caracctères spéciaux d'une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : le nombre de caractères spéciaux dans 'chaine'
    public static int CompterCaractresSpeciaux(string chaine)
    {
        int speciaux = 0;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstCaractereSpecial(chaine[i]))
                speciaux++;
        }
        return speciaux;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // calculer le nombre de lettre, de chiffres et de caractères spéciaux
        int lettres = CompterLettres(chaine);
        int chiffres = CompterChiffres(chaine);
        int speciaux = CompterCaractresSpeciaux(chaine);
        // afficher le nombre de lettres, chiffres et caractères spéciaux
        AfficheChaine(
            "La chaine \"" + chaine + "\" contient :\n" + 
            lettres + " lettres\n" + 
            chiffres + " chiffres\n" + 
            speciaux + " caractères spéciaux"
        );
    }
}