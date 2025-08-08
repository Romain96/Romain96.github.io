// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP5 (2023/09/29)
using System;

class TriangleIsocele
{
    // Procédure : lire un entier depuis le terminal
    // Paramètres :
    //  - msg (string): le message à afficher à l'utilisateur
    // Retourne :
    //  - n (int): l'entier lu et converti depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        int n = int.Parse(Console.ReadLine());
        return n;
    }

    // Procédure : afficher une chaîne dans le terminal
    // Paramètres :
    //  - str (string): chaîne à afficher
    // Retourne : /
    public static void AfficherChaine(string str)
    {
        Console.WriteLine(str);
    }

    // Fonction : génère une chaîne de n fois la chaîne str
    // Paramètres :
    //  - n (int): le nombre de fois que str sera répérée
    //  - str (string): la chaîne de base à répérer
    // Retourne :
    //  - rep (string) : une chaîne de longueur n*longueur(str)
    public static string GenererRepetition(int n, string str)
    {
        string rep = "";
        for (int i = 0; i < n; i++)
            rep = rep + str;
        return rep;
    }

    // Fonction : calcule et affiche un triangle isocèle
    // composé d'étoiles de hauteur h dans le terminal
    // Paramètres :
    //  - h (int): hauteur du triangle
    // Retourne : /
    public static void AfficherTriangleIsocele(int h)
    {
        // pour chaque ligne entre 0 et h-1 :
        int nbEtoiles = 0;
        for (int ligne = 0; ligne < h; ligne++)
        {
            // calculer la longueur d'une ligne
            int longueur = 1 + 2*(h-1);
            //  - calculer le nombre d'étoiles
            //  nb étoiles = 1 + ligne * 2
            nbEtoiles = 1 + 2 * ligne;
            //  - générer la chaîne d'étoiles
            string chaineEtoiles = GenererRepetition(nbEtoiles, "*");
            // - calculer le nombre d'espaces
            // longueur - nbEtoiles
            int nbEspaces = longueur - nbEtoiles;
            // générer une chaîne d'espaces (demi)
            string chaineEspaces = GenererRepetition(nbEspaces / 2, " ");
            // combiner les espaces et les étoiles
            string chaine = chaineEspaces + chaineEtoiles + chaineEspaces;
            //  - afficher la chaîne dans le term<inal
            AfficherChaine(chaine);
        }
    }
    static void Main()
    {
        // demander la hauteur du triangle (= nombre de lignes à afficher)
        int hauteur = LireEntier("Entrez la hauteur du triangle : ");
        AfficherTriangleIsocele(hauteur);
    }
}