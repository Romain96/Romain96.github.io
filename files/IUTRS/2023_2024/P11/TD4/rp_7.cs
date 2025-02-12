// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-7
using System;

class RP7
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

    // Fonction : calcule le nombre d'occurrences d'une sous-chaine dans une autre chaine
    // Paramètres :
    //  - chaine_base (string): une chaine de caractères dans laquelle effectuer la recherche
    //  - chaine_recherche (string): 
    // Retourne : la longueur de la chaine 'chaine'
    public static int CompterOccurrencesSousChaine(string chaine_base, string chaine_recherche)
    {
        int occurrences = 0;
        int indice = 0;
        // parcourir les caractères de la chaine_base
        while (indice < chaine_base.Length)
        {
            // si le caractère courant est identique au premier caractère de chaine_rechercher
            if (chaine_base[indice] == chaine_recherche[0])
            {
                // tester si chaine_recherche est contenue dans chaine_base à partir de cet indice
                int indice_sous_chaine = 0;
                bool est_sous_chaine = true;
                while (indice_sous_chaine < chaine_recherche.Length && est_sous_chaine)
                {
                    if (chaine_recherche[indice_sous_chaine] != chaine_base[indice + indice_sous_chaine])
                        est_sous_chaine = false;
                    indice_sous_chaine++;
                }
                // si c'est une sous chaine alors compter +1 et mettre à jour indice à indice + chaine_recherche.Length
                if (est_sous_chaine)
                {
                    occurrences++;
                    indice += chaine_recherche.Length;
                }
                // sinon mettre à jour indice à la position actuelle de indice_sous_chaine
                else
                {
                    indice += indice_sous_chaine;
                }
            }
            // sinon avancer d'un caractère
            else
                indice++;
        }
        return occurrences;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine_de_base = LireChaine("Entrez une chaine de caractères : ");
        // demander une sous-chaine de caractères à rechercher
        string chaine_a_rechercher = LireChaine("Entrez une chaine de caractères à rechercher dans la précédente : ");
        // calculer la longueur de chaine
        int occurrences = CompterOccurrencesSousChaine(chaine_de_base, chaine_a_rechercher);
        // afficher la longueur
        AfficheChaine("Il y a " + occurrences + " occurence de \"" + chaine_a_rechercher + "\" dans \"" + chaine_de_base + "\".");
    }
}