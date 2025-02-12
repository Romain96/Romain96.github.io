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

    // Fonction : remplacement d'une sous-chaine de caractères par une autre dans une chaine de caractères
    // Paramètres :
    //  - cible (string): la sous-chaine de caractère à remplacer
    //  - remplace (string): la sous-chaine de caractères à utiliser en remplacement de `cible`
    //  - chaine (string): la chaine de caractères dans laquelle effectuer le(s) remplacement(s)
    // Retourne :
    //  - res (chaine): chaine `chaine` dans laquelle toutes des occurrences de `cible` on été remplacées par `remplace`
    public static string RemplacerSousChaine(string cible, string remplace, string chaine)
    {
        string res = "";
        res = chaine.Replace(cible, remplace);
        return res;
    }

    // Fonction : lecture d'une chaine de caractères d'un ficher texte
    // Paramètres :
    //  - chemin (string): chemin vers le ficher à ouvrir
    // Retourne :
    //  - texte (string): contenu textuel du fichier passé en paramètre
    public static string LireFichier(string chemin)
    {
        string texte = "";
        // seulement si le chemin spécifié est valide
        if (File.Exists(chemin))
        {
            texte = File.ReadAllText(chemin);
        }
        else
        {
            AfficherChaine($"ERREUR - le chemin spécifié {chemin} n'est pas valide !");
        }
        return texte;
    }


    // Fonction : écriture d'une chaine de caractères dans un fichier texte
    // Paramètres :
    //  - chemin (string): chemin vers le ficher à ouvrir
    //  - texte (string): chaine de caractère contenant le texte à écrire dans le fichier `chemin`
    //  - ajout (bool): si vrai alors `texte` est ajouté au contenu de `chemin`, sinon le contenu est écrasé par `texte`
    // Retourne : rien
    public static void EcrireFichier(string chemin, string texte, bool ajout)
    {
        if (ajout)
        {
            File.AppendAllText(chemin, texte);
        }
        else
        {
            File.WriteAllText(chemin, texte);
        }
    }

    // Fonction principale
    static void Main()
    {
        string fichier_in = "in.txt";
        string fichier_out = "out.txt";
        string contenu = LireFichier(fichier_in);
        string sc_cible = LireChaine("Entrez la sous-chaine à remplacer : ");
        string sc_remplace = LireChaine("Entrez la sous-chaine de remplacement : ");
        string contenu_modifie = RemplacerSousChaine(sc_cible, sc_remplace, contenu);
        EcrireFichier(fichier_out, contenu_modifie, false);
    }
}