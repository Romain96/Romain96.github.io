// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-2
using System;

class RP2
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

    // Fonction : inverse une chaine de caractères
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : une nouvelle chaine de même longueur que 'chaine' mais inversée
    public static string InverserChaine(string chaine)
    {
        string inverse = "";
        for (int i = chaine.Length - 1; i >= 0; i--)
            inverse += chaine[i];
        return inverse;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères à inverser: ");
        // inverse la chaine
        string inverse = InverserChaine(chaine);
        // affiche la chaine inversée
        AfficheChaine(inverse);
    }
}