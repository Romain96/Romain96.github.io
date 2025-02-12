// Auteur : Romain PERRIN
using System;

class TestAge
{
    //-------------------------------------------------------------------------
    //                            PROCEDURES
    //-------------------------------------------------------------------------

    /**
    * <summary>Procédure de lecture d'un entier depuis le terminal.</summary>
    * <param name="msg">Le message à afficher à l'utilisateur.</param>
    * <returns>L'entier lu et convertit depuis le terminal.</returns>
    */
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        return int.Parse(Console.ReadLine());
    }

    /**
    * <summary>Affichage d'un message textuel contenant un nombre entier sur le terminal.</summary>
    * <param name="prefixe">Le message préfixant <paramref name="nb"/>.</param>
    * <param name="nb">Le nombre entier à afficher après <paramref name="prefixe"/></param>
    * <param name="suffixe">Le message suffixant <paramref name="nb"/>.</param>
    * <returns></returns>
    */
    public static void AfficherEntier(string prefixe, int nb, string suffixe)
    {
        Console.WriteLine(prefixe + nb + suffixe);
    }

    /**
    * <summary>Affichage d'un message textuel sur le terminal.</summary>
    * <param name="msg">Le message à afficher.</param>
    * <returns></returns>
    */
    public static void AfficherTexte(string msg)
    {
        Console.WriteLine(msg);
    }

    /**
    * <summary>Procédure testant l'age entré par l'utilisateur est valide.</summary>
    * <param name="age">L'age de l'utilisateur.</param>
    * <returns>Vrai si <paramref name="age"/> est dans [0,130], faux sinon.</returns>
    */
    public static bool AgeValide(int age)
    {
        if (age >= 0 && age <= 130)
        {
            return true;
        }
        return false;
    }

    /**
    * <summary>Procédure testant si un utilisateur est mineur ou majeur.</summary>
    * <param name="age">L'age de l'utilisateur ([0, 130]).</param>
    * <returns>Vrai si l'utilisateur est majeur (<paramref name="age"/> >= 18), faux sinon.</returns>
    */
    public static bool EstMajeur(int age)
    {
        if (age >= 18)
        {
            return true;
        }
        return false;
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------

    static void Main()
    {
        // Lire l'age depuis la console
        int age_utilisateur = LireEntier("Veuillez entrer votre age : ");

        // teste si l'age rentré est valide
        if (AgeValide(age_utilisateur))
        {
            // teste si l'utilisateur est majeur
            // affiche majeur ou mineur
            if (EstMajeur(age_utilisateur))
            {
                AfficherTexte("Vous êtes majeur(e) !");
            }
            else
            {
                AfficherTexte("Vous êtes mineur(e) !");
            }
        }
        else
        {
            // affiche que l'age est invalide
            AfficherEntier("Désolé, ", age_utilisateur, " n'est pas un age valide !");
        }

    }
}