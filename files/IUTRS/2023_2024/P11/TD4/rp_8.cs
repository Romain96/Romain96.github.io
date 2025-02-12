// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-8
using System;

class RP8
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

    // Fonction : extrait une sous-chaine dans une chaine (Substring)
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    //  - indice (int): l'indice du premier caractère à extraire
    //  - longueur (int): le nombre de caractères à extraire à partir de 'indice'
    // Retourne : une sous-chaine extraite de 'chaine' de longueur 'longueur' à partir du caractère à l'indice 'indice'
    // Note : si 'indice' est négatif, la sous-chaine est extraite depuis l'indice 0
    // Note : si 'indice' est supérieur à la longueur de 'chaine' alors une chaine vide est retournée
    public static string ExtraireSousChaine(string chaine, int indice, int longueur)
    {
        int extraction = indice;
        int indice_max = indice + longueur;
        string sous_chaine = "";

        // on remène l'indice de départ à 0 s'il est strictement négatif
        if (indice < 0)
            extraction = 0;
            indice_max = longueur;
        
        // on ramène l'indice de départ à la fin s'il excède la longueur de la chaine
        if (indice >= chaine.Length)
            return sous_chaine;
        
        // on ramène l'indice max à la longueur de la chaine s'il excède cette longueur
        if (indice_max >= chaine.Length)
            indice_max = chaine.Length - 1;

        for (int i = extraction; i <= indice_max; i++)
        {
            sous_chaine += chaine[i];
            extraction++;
        }
        return sous_chaine;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine_de_base = LireChaine("Entrez une chaine de caractères : ");
        // demander un indice d'extraction et une longueur de sous-chaine
        int indice_extraction = LireEntier("Entrez l'indice du premier caractère à extraire : ");
        int longueur_sous_chaine = LireEntier("Entrez la longueur de la sous-chaine à extraire : ");
        // extraire la sous-chaine dans chaine_de_base
        string chaine_extraite = ExtraireSousChaine(chaine_de_base, indice_extraction, longueur_sous_chaine);
        // afficher la longueur
        AfficheChaine("La sous-chaine extraite est \"" + chaine_extraite + "\".");
    }
}