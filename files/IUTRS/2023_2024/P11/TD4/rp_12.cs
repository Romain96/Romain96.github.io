// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-12
using System;

class RP12
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

    // Fonction : inverse la casse d'un caractère
    // Paramètres :
    //  - c (char): un caractère à traiter
    // Retourne : le caractère 'c' dont la casse a été inversée
    public static char InverseCasse(char c)
    {
        char c_bis = char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c);
        //if char.IsLower(c)
        //    c_bis = char.ToLower(c);
        //else
        //    c_bis = char.ToUpper(c);
        return c_bis;
    }

    // Fonction : inverse la casse de tous les caractères d'une chaine
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : une nouvelle chaine de même longueur que 'chaine'
    public static string InverseCasseChaine(string chaine)
    {
        string res = "";
        for (int i = 0; i < chaine.Length; i++)
            res += InverseCasse(chaine[i]);
        return res;
    }
    
    static void Main()
    {
        // demander une chaine
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // inverser la casse
        string inverse = InverseCasseChaine(chaine);
        // afficher le résultat
        AfficheChaine(inverse);
    }
}