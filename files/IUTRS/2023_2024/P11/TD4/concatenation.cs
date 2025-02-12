// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 2
using System;

class Concatenation
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

    // Fonction : concatène deux chaines de caractères
    // Paramètres :
    //  - chaine1 (string): une première chaine de caractères
    //  - chaine2 (string): une seconde chaine de caractères
    // Retourne : la longueur de la chaine de caractères 'chaine'
    public static string ConcatenationChaine(string chaine1, string chaine2)
    {
        // l'opérateur de concaténation '+' peut être utilisé entre deux chaines
        return chaine1 + chaine2;
    }

    static void Main()
    {
        // demander deux chaines de caractères
        string chaine1 = LireChaine("Entrez une première chaine de caractères : ");
        string chaine2 = LireChaine("Entrez une seconde chaine de caractères : ");
        // concaténer les deux chaines
        string conc = ConcatenationChaine(chaine1, chaine2);
        // afficher la concaténation
        AfficheChaine("La concaténation des deux chaines est : " + conc);
    }
}