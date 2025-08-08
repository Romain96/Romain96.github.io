// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice PG-1
using System;

class PG1
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

    // Fonction : AtoI transforme une chaine de caractères en entier (sans int.Parse)
    // Paramètres :
    //  - chaine (string): chaine de caractères
    // Retourne : un entier
    // Note : ignore les caractères non numériques ex : 12sd3 retourne 123
    public static int AtoI(string chaine)
    {
        int b = 1; // base 1, 10, 100...
        int n = 0; // nombre à construire
        for (int i = chaine.Length - 1; i >= 0; i--)
        {
            // traitement seulement si numérique
            if (chaine[i] >= '0' && chaine[i] <= '9')
            {
                // base * le caractère converti en entier
                n = n + (b * ((int)chaine[i] - 48));  // chiffre 0 = code 48 dans la table ASCII
                b = b * 10;
            }
        }
        return n;
    }
    
    static void Main()
    {
        // demande une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // converti en entier
        int n = AtoI(chaine);
        // affiche le résultat
        AfficheChaine("AtoI(\"" + chaine + "\") = " + n);
    }
}