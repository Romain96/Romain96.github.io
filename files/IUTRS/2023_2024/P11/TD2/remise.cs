// Auteur : Romain PERRIN
using System;

class PrixRemise
{
    //-------------------------------------------------------------------------
    //                            PROCEDURES
    //-------------------------------------------------------------------------

    /**
    * <summary>Procédure de lecture d'un nombre réel depuis le terminal.</summary>
    * <param name="msg">Le message à afficher à l'utilisateur.</param>
    * <returns>Le nombre réel lu et convertit en double depuis le terminal.</returns>
    */
    public static double LireDouble(string msg)
    {
        Console.Write(msg);
        return double.Parse(Console.ReadLine());
    }

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
    * <summary>Affichage de la remise sur le terminal.</summary>
    * <param name="prixHT">Le prix HT.</param>
    * <param name="code_remise">Le code de remise.</param>
    * <param name="prixTTC">Le prix TTC.</param>
    * <returns></returns>
    */
    public static void AfficherRemise(double prixHT, int code_remise, double prixTTC)
    {
        Console.WriteLine("Avec le code de remise " + code_remise + ", le prix HT de " + prixHT + " euros passe à " + prixTTC + " euros.");
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    /**
    * <summary>Calcule le pourcentage de la remise en fonction du code.</summary>
    * <param name="code_remise">Nombre entier indiquant le code de remise ({0,1,2}).</param>
    * <returns>Le pourcentage de remise en fonction de <paramref name="code_remise"/>.</returns>
    */
    public static double CalculTauxRemise(int code_remise)
    {
        // 0 -> pas de remise
        // 1 -> -15%
        // 2 -> -25%
        if (code_remise <= 0)
        {
            return 0.0;
        }
        else if (code_remise == 1)
        {
            return 0.15;
        }
        else
        {
            // code 2 ou plus = code 2
            return 0.25;
        }
    }

    /**
    * <summary>Calcule le prix TTC en fonction du prix HT et du code de remise.</summary>
    * <param name="prixHT">Le prix hors taxes.</param>
    * <param name="code_remise">Nombre entier indiquant le code de remise ({0,1,2}).</param>
    * <returns>Le prix TTC en fonction de <paramref name="prixHT"/> et <paramref name="code_remise"/>.</returns>
    */
    public static double CalculPrixTTC(double prixHT, int code_remise)
    {
        // calculer le montant de la remise
        double taux_remise = CalculTauxRemise(code_remise);

        // calculer le prixTTC en retirant la remise
        double prixTTC = prixHT * (1 - taux_remise);

        return prixTTC;
    }


    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    static void Main()
    {
        // lire le prixHT depuis le terminal
        double prixHT = LireDouble("Veuillez entrer le prix HT : ");

        // lire le code de remise depuis le terminal
        int code_remise = LireEntier("Veuillez entrer le code de remise : ");

        // calculer le prixTTC
        double prixTTC = CalculPrixTTC(prixHT, code_remise);

        // afficher le prixTTC
        AfficherRemise(prixHT, code_remise, prixTTC);
    }
}