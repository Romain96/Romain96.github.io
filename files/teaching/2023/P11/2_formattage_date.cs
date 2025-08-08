// Auteur : Romain PERRIN
using System;

class Date
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
    * <summary>Affichage de la date formatée.</summary>
    * <param name="jour">Le numéro du jour.</param>
    * <param name="mois">Le numéro du mois.</param>
    * <param name="annee">Le numéro de l'année.</param>
    * <returns></returns>
    */
    public static void AfficheDateFormatee(int jour, int mois, int annee)
    {
        Console.WriteLine("La date est : " + jour + "/" + mois + "/" + annee + ".");
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    /**
    * <summary>Vérifie la validité d'un mois.</summary>
    * <param name="mois">Le numéro du mois.</param>
    * <returns>Vrai si <paramref name="mois"/> est dans [1,12], faux sinon.</returns>
    */
    public static bool ValiditeMois(int mois)
    {
        // valide dans l'absolu si entre 1 et 12
        if (mois >= 1 && mois <= 12)
        {
            return true;
        }
        // affichage de l'erreur
        Console.WriteLine("Erreur : le mois " + mois + " n'est pas entre 1 et 12.");
        return false;
    }

    /**
    * <summary>Vérifie la validité d'une année.</summary>
    * <param name="annee">Le numéro de l'année.</param>
    * <returns>Vrai si <paramref name="annee"/> est dans [1,2106], faux sinon.</returns>
    */
    public static bool ValiditeAnnee(int annee)
    {
        if (annee >= 1 && annee <= 2106)
        {
            return true;
        }
        // affichage de l'erreur
        Console.WriteLine("Erreur : l'année " + annee + " n'est pas entre 1 et 2106.");
        return false;
    }

    /**
    * <summary>Détermine si l'année est bissextile ou non.</summary>
    * <param name="annee">Le numéro de l'année.</param>
    * <returns>Vrai si <paramref name="annee"/> est bissextile, faux sinon.</returns>
    */
    public static bool EstBissextile(int annee)
    {
        // une année est bissextile si 
        // - elle est divisible par 4 mais pas par 100
        // ou
        // - si elle est divisible par 400
        if ((annee % 4 == 0 && annee % 100 != 0) || annee % 400 == 0)
        {
            return true;
        }
        return false;
    }

    /**
    * <summary>Retourne le nombre de jours d'un mois.</summary>
    * <param name="mois">Le numéro du mois.</param>
    * <param name="annee">Le numéro de l'année.</param>
    * <param name="bissextile">Si <paramref name="annee"/> est bissextile.</param>
    * <returns>Le nombre de jours dans <paramref name="mois"/> en tenant compte 
    * de <paramref name="annee"/> et de <paramref name="bissextile"/>.</returns>
    */
    public static int JoursDuMois(int mois, int annee, bool bissextile)
    {     
        // février -> 28 pour une année non bissextile, 29 sinon
        if (mois == 2)
        {
            if (bissextile)
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
        // janvier, mars, mai, juillet, août, octobre ou décembre -> 31 jours
        else if (mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12)
        {
            return 31;
        }
        // cas restants : avril, juin, septembre, novembre -> 30 jours
        else
        {
            return 30;
        }
    }

    /**
    * <summary>Vérifie que le jour est valide en fonction du mois.</summary>
    * <param name="jour">Le numéro du jour.</param>
    * <param name="nb_jours">Le nombre de jours dans le mois.</param>
    * <returns>Vrai si le <paramref name="jour"/> respecte le nombre de jours
    * <paramref name="nb_jours"/> du mois, faux sinon.</returns>
    */
    public static bool ValiditeJour(int jour, int nb_jours)
    {
        if (jour >= 0 && jour <= nb_jours)
        {
            return true;
        }
        // affichage de l'erreur
        Console.WriteLine("Erreur : le jour " + jour + " n'existe pas dans le mois, les jours valides sont [1," + nb_jours + "].");
        return false;
    }

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    static void Main()
    {
        // lire le jour, le mois et l'année
        int jour = LireEntier("Veuillez entrer le numéro du jour : ");
        int mois = LireEntier("Veuillez entrer le numéro du mois : ");
        int annee = LireEntier("Veuillez entrer le numéro de l'année : ");

        // vérifier la validité de l'année, si invalide on s'arrête
        if (!ValiditeAnnee(annee))
            return;

        // vérifier la validité du mois, si invalide on s'arrête
        if (!ValiditeMois(mois))
            return;

        // vérifier si l'année est bissextile
        bool est_bissextile = EstBissextile(annee);

        // calculer le nombre de jours du mois
        int nb_jours_du_mois = JoursDuMois(mois, annee, est_bissextile);
        
        // vérifier la validité du jour, si invalide on s'arrête
        if (!ValiditeJour(jour, nb_jours_du_mois))
            return;

        // afficher la date formatée
        AfficheDateFormatee(jour, mois, annee);
    }
}