// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 6
using System;

class Palindrome
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

    // Fonction : teste si une chaine est un palindrome
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : true si 'chaine' est un palindrome, false sinon
    public static bool EstPalindrome(string chaine)
    {
        int longueur = chaine.Length;
        int demi_longueur = longueur / 2;   // division entière, ne tient pas compte du caractère central quand longueur est impaire
        for (int i = 0; i < demi_longueur; i++)
        {
            // i-ème caractère en partant du début = i
            // i-ème caractère en partant de la fin = longueur - i - 1
            if (chaine[i] != chaine[longueur - i - 1])
                return false;
        }
        // à ce stade la chaine est un palindrome
        return true;
    }

    static void Main()
    {
        // demander une chaine et un caractère
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // tester si la chaine est un palindrome
        bool palin = EstPalindrome(chaine);
        // afficher le résultat
        if (palin)
            AfficheChaine(chaine + " est un palindrome.");
        else
            AfficheChaine(chaine + " n'est pas un palindrome.");
    }
}