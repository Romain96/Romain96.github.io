// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-6
using System;

class RP6
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

    // Procédure : lit un caractère depuis le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : le premier caractère de la chaine lue depuis le terminal
    // Note : retourne un espace si la chaine lue est vide
    public static char LireCaractere(string msg)
    {
        Console.Write(msg);
        string input = Console.ReadLine();
        if (input.Length == 0)
            return ' ';
        return input[0];
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : insère une chaine de caractères à une position dans un autre chaine (avec méthodes de string)
    // Paramètres :
    //  - chaine_base (string): une chaine de caractères dans laquelle réaliser une insertion
    //  - chaine_inserer (string): une chaine de caractères à insérer dans 'chaine_base'
    //  - cible (char): un caractère cible après la première occurrence duquel 'chaine_inserer' sera insérée dans 'chaine_base'
    // Retourne : une nouvelle chaine de longueur 'chaine_base' + 'chaine_inserer'
    public static string InsererChaineApresOccurenceCaractere(string chaine_base, string chaine_inserer, char cible)
    {
        // IndexOf retourne la première occurrence d'un caractère
        // IndexOf(caractère, position de départ, longueur de recherche)
        int indice = chaine_base.IndexOf(cible, 0, chaine_base.Length);
        return chaine_base.Substring(0, indice + 1) + chaine_inserer + chaine_base.Substring(indice + 1);
    }

    // Fonction : recherche l'indice de la première occurrence d'un caractère dans une chaine
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    //  - cible (char): un caractère
    // Retourne : l'indice de la première occurrence de 'cible' dans 'chaine'
    // Note : retourne -1 si 'cible' n'existe pas dans 'chaine'
    public static int RechercherPremiereOccurrence(string chaine, char cible)
    {
        int indice = 0;
        while (indice < chaine.Length)
        {
            if (chaine[indice] == cible)
                return indice;
            indice++;
        }
        return -1;
    }

    // Fonction : insère une chaine de caractères à une position dans un autre chaine (sans méthodes de string)
    // Paramètres :
    //  - chaine_base (string): une chaine de caractères dans laquelle réaliser une insertion
    //  - chaine_inserer (string): une chaine de caractères à insérer dans 'chaine_base'
    //  - cible (char): un caractère cible après la première occurrence duquel 'chaine_inserer' sera insérée dans 'chaine_base'
    // Retourne : une nouvelle chaine de longueur 'chaine_base' + 'chaine_inserer'
    // Note : si 'cible' n'existe pas dans 'chaine_base' alors 'chaine_inserer' est concaténée à 'chaine_base'
    public static string InsererChaineApresOccurenceCaractereAlt(string chaine_base, string chaine_inserer, char cible)
    {
        int indice = RechercherPremiereOccurrence(chaine_base, cible);

        if (indice < 0)
            return chaine_base + chaine_inserer;

        string res = "";
        for (int i = 0; i <= indice; i++)
            res += chaine_base[i];
        res += chaine_inserer;
        for (int i = indice + 1; i < chaine_base.Length; i++)
            res += chaine_base[i];
        return res;
    }

    static void Main()
    {
        // demander une chaine de caractères
        string chaine_de_base = LireChaine("Entrez une chaine de caractères : ");
        // demander une chaine de caractères à insérer et un caractère à rechercher
        string chaine_a_inserer = LireChaine("Entrez une chaine de caractères à insérer : ");
        char caractere_a_rechercher = LireCaractere("Entrez un caractère après lequel insérer la chaine : ");
        // insérer chaine_a_inserer dans chaine_de_base après la première occurrence de caractere_a_rechercher
        string chaine_finale = InsererChaineApresOccurenceCaractere(chaine_de_base, chaine_a_inserer, caractere_a_rechercher);
        string chaine_finale_alt = InsererChaineApresOccurenceCaractereAlt(chaine_de_base, chaine_a_inserer, caractere_a_rechercher);
        // afficher la chaine
        AfficheChaine("Méthode 1 (IndexOf et Substring) : " + chaine_finale);
        AfficheChaine("Méthode 2 (sans IndexOf ni Substring) : " + chaine_finale_alt);
    }
}