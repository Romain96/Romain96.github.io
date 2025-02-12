// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice RP-10
using System;

class RP10
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

    // Fonction : détermine si un caractère est un séparateur de mots
    // Paramètres :
    //  - c (char): le caractère à tester
    // Retourne : true si 'c' est un séparateur, false sinon
    // Note : tous les caractères hors lettres et chiffres sont considérés comme séparateurs
    public static bool EstSeparateur(char c)
    {
        if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
            return false;
        return true;
    }

    // Fonction : construit une chaine en alternant les mots en majuscules et minuscules
    // Paramètres :
    //  - chaine (string): une chaine de caractères
    //  - commencer_par_majuscule (bool): true pour commencer par une majuscule, false sinon
    // Retourne : une nouvelle chaine de même longueur que 'chaine'
    public static string AlternerMajusculesMinuscules(string chaine, bool commencer_par_majuscule)
    {
        string res = "";
        bool dans_un_mot = false;
        bool premier_caractere = true;
        int indice_sous_chaine = 0;
        bool majuscules = commencer_par_majuscule;
        for (int i = 0; i < chaine.Length; i++)
        {
            if (EstSeparateur(chaine[i]))
            {
                // extraire la sous-chaine, mettre en maj/min, concaténer
                if (dans_un_mot)
                {
                    string sous_chaine = chaine.Substring(indice_sous_chaine, i - indice_sous_chaine);
                    if (majuscules)
                    {
                        sous_chaine = sous_chaine.ToUpper();
                        majuscules = false;
                    }
                    else
                    {
                        sous_chaine = sous_chaine.ToLower();
                        majuscules = true;
                    }
                    res = res + sous_chaine;
                }
                premier_caractere = true;
                dans_un_mot = false;
                res = res + chaine[i];
            }
            else
            {
                if (premier_caractere)
                {
                    indice_sous_chaine = i;
                    premier_caractere = false;
                }
                dans_un_mot = true;
            }
        }
        if (dans_un_mot)
        {
            string sous_chaine = chaine.Substring(indice_sous_chaine, chaine.Length - indice_sous_chaine);
            if (majuscules)
            {
                sous_chaine = sous_chaine.ToUpper();
                majuscules = false;
            }
            else
            {
                sous_chaine = sous_chaine.ToLower();
                majuscules = true;
            }
            res = res + sous_chaine;
        }
        return res;
    }
    static void Main()
    {
        // demander une chaine de caractères
        string chaine = LireChaine("Entrez une chaine de caractères : ");
        // mettre un mot sur deux en majuscules et une sur deux en minuscules
        // commencer par les majuscules
        string chaine_maj = AlternerMajusculesMinuscules(chaine, true);
        // commencer par les minuscules
        string chaine_min = AlternerMajusculesMinuscules(chaine, false);
        // afficher la nouvelle chaine
        AfficheChaine("Avec les majuscules d'abord : " + chaine_maj);
        AfficheChaine("Avec les minuscules d'abord : " + chaine_min);
    }
}