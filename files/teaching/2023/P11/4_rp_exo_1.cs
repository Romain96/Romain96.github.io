// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-1
using System;

class RP1
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

    // Fonction : calcule la longueur d'une chaine de caractères sans utiliser Length
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    // Retourne : la longueur de la chaine 'chaine'
    public static int Longueur(string chaine)
    {
        int longueur = 0;
        foreach(char c in chaine)
            longueur++;
        return longueur;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // calculer la longueur de chaine
        int longueur = Longueur(chaine);
        // afficher la longueur
        AfficheChaine("La longueur de la chaine \"" + chaine + "\" est " + longueur);
    }
}