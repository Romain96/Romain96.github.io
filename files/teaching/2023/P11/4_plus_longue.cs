// Auteur : Romain PERRIN
// Feuille d'exercice sur les chaines de caractères, exercice 3
using System;

class PlusLongue
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
        return chaine.Length;
    }

    // Fonction : retourne la plus petite de deux chaines de caractères selon l'ordre alphabétique
    // Paramètres :
    //  - chaine1 (string): une première chaine de caractères
    //  - chaine2 (string): une seconde chaine de caractères
    // Retourne : la plus petite chaine selon l'ordre alphabatique
    // Note : chaine1 et chaine2 doivent avoir la même longueur
    public static string PlusPetiteChaineOrdreAlphabetique(string chaine1, string chaine2)
    {
        int longueur = LongueurChaine(chaine1);
        int index = 0;
        while (index < longueur)
        {
            if (chaine1[index] < chaine2[index])
                return chaine1;
            if (chaine1[index] > chaine2[index])
                return chaine2;
            index++;
        }
        // à ce stade les deux chaines sont identiques, on peut retourner celle qu'on veut !
        return chaine1;
    }

    // Fonction : retourne la plus longue de deux chaines de caractères données
    // Paramètres :
    //  - chaine1 (string): une première chaine de caractères
    //  - chaine2 (string): une seconde chaine de caractères
    // Retourne : la plus longue chaine entre 'chaine1' et 'chaine2'
    // En cas d'égalite de longueur, retourne la plus petite selon l'ordre alphabétique
    public static string PlusLongueChaine(string chaine1, string chaine2)
    {
        int longueur1 = LongueurChaine(chaine1);
        int longueur2 = LongueurChaine(chaine2);

        if (longueur1 > longueur2)
            return chaine1;
        else if (longueur1 < longueur2)
            return chaine2;
        else
            return PlusPetiteChaineOrdreAlphabetique(chaine1, chaine2);
    }

    static void Main()
    {
        // demander deux chaines de caractères
        string chaine1 = LireChaine("Entrez une première chaine de caractères : ");
        string chaine2 = LireChaine("Entrez une seconde chaine de caractères : ");
        // calculer la plus longuer des deux chaines
        string longue = PlusLongueChaine(chaine1, chaine2);
        // afficher la plus longue chaine
        AfficheChaine("La plus longue chaine est : " + longue);
    }
}