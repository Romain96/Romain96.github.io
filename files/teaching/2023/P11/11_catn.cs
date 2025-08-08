// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;

class FichiersExercice1
{
    // Procédure : affichage d'une chaine de caractères dans le terminal
    // Paramètres :
    //  - chaine (string): chaine de caractères à afficher
    // Retourne : rien
    public static void AfficherChaine(string chaine)
    {
        Console.WriteLine(chaine);
    }

    // Procédure : lecture d'une chaine de caractères depuis le terminal
    // Paramètres :
    //  - msg (string): chaine de caractères à afficher
    // Retourne :
    //  - chaine (string): chaine lue depuis le terminal
    public static string LireChaine(string msg)
    {
        Console.Write(msg);
        string chaine = Console.ReadLine();
        return chaine;
    }

    // Fonction : lecture d'une chaine de caractères d'un ficher texte
    // Paramètres :
    //  - chemin (string): chemin vers le ficher à ouvrir
    // Retourne :
    //  - texte (string): contenu textuel du fichier passé en paramètre
    // Pré-conditions :
    //  - `chemin` doit être un chemin de fichier valide
    public static string[] LireFichier(string chemin)
    {
        string[] texte = File.ReadAllLines(chemin);
        return texte;
    }


    // Fonction : affichage de chaque ligne d'un fichier texte précédé du numéro de ligne
    // Paramètres :
    //  - chemin (string): chemin vers le fichier à lire
    // Retourne : rien
    public static void CatN(string chemin)
    {
        // lecture du fichier
        if (File.Exists(chemin))
        {
            string[] texte = LireFichier(chemin);
            // affichage de chaque ligne + numéro de ligne
            for (int i = 0; i < texte.Length; i++)
            {
                AfficherChaine($"{i+1} : {texte[i]}");
            }
        }
        else
        {
            AfficherChaine($"Le fichier spécifié n'existe pas {chemin}");
        }
    }

    // Fonction principale
    static void Main()
    {
        string u_chemin = LireChaine("Fichier à lire : ");
        CatN(u_chemin);
    }
}