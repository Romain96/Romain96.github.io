// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-5
using System;

class RP5
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

    // Procédure : lit un entier depuis le terminal
    // Paramètres :
    //  - msg (string): message textuel à afficher à l'utilisateur
    // Retourne : un entier lu et converti depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        return int.Parse(Console.ReadLine());
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : insère une chaine de caractères à une position dans un autre chaine
    // Paramètres :
    //  - chaine_base (string): une chaine de caractères dans laquelle réaliser une insertion
    //  - chaine_inserer (string): une chaine de caractères à insérer dans 'chaine_base'
    //  - indice (int): un indice dans 'chaine_base', position où insérer 'chaine_inserer' dans 'chaine_base'
    // Retourne : une nouvelle chaine de longueur 'chaine_base' + 'chaine_inserer'
    // Note : si l'indice est négatif alors 'chaine_base' est concaténée à 'chaine_inserer'
    // Note : si l'indice excède la longueur de 'chaine_base' alors 'chaine_inserer' est concaténée à 'chaine_base'
    public static string InsererChaineIndice(string chaine_base, string chaine_inserer, int indice)
    {
        int longueur = chaine_base.Length;
        if (indice < 0)
            return chaine_inserer + chaine_base;
        else if (indice >= longueur)
            return chaine_base + chaine_inserer;
        else
            return chaine_base.Substring(0, indice) + chaine_inserer + chaine_base.Substring(indice);
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine_de_base = LireChaine("Entrez une chaine de caractères : ");
        // demander une chaine de caractères à insérer et une position d'insertion
        string chaine_a_inserer = LireChaine("Entrez une chaine de caractères à insérer : ");
        int position_insertion = LireEntier("Entrez l'indice auquel insérer la chaine précédente : ");
        // insérer chaine_a_inserer dans chaine_de_base à position_insertion
        string chaine_finale = InsererChaineIndice(chaine_de_base, chaine_a_inserer, position_insertion);
        // afficher le nombre de lettres, chiffres et caractères spéciaux
        AfficheChaine(chaine_finale);
    }
}