// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 1
using System;

class Longueur
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

    // Fonction : retourne la longueur d'une chaine de caractères donnée
    // Paramètres :
    //  - chaine (string): la chaine à traiter
    // Retourne : la longueur de la chaine de caractères 'chaine'
    public static int LongueurChaine(string chaine)
    {
        // utilisation de la propriété Length
        return chaine.Length;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine_a_tester = LireChaine("Entrez une chaine de caractères : ");
        // afficher la longueur
        AfficheChaine("La longueur de la chaine est " + LongueurChaine(chaine_a_tester));
    }
}