// Auteur : Romain PERRIN
using System;

class Maximum2
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
    * <summary>Affichage du maximum de deux nombres entiers dans le terminal.</summary>
    * <param name="a">Le premier nombre entier.</param>
    * <param name="b">Le second nombre entier.</param>
    * <param name="max">Le maximum de <paramref name="a"/> et <paramref name="b"/>.</param>
    * <returns></returns>
    */
    public static void AfficherMaximum(int a, int b, int max)
    {
        Console.WriteLine("Le maximum de " + a + " et de " + b + " est " + max + ".");
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    /**
    * <summary>Calcul du maximum entre deux nombres entiers.</summary>
    * <param name="a">Un premier nombre entier.</param>
    * <param name="b">Un second nombre entier.</param>
    * <returns>Le maximum entre <paramref name="a"/> et <paramref name="b"/>.</returns>
    */
    public static int Maximum(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        return b;
    }

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    static void Main()
    {
        // lire deux nombres entiers depuis le terminal
        int nombre_1 = LireEntier("Veuillez entrer un premier nombre entier : ");
        int nombre_2 = LireEntier("Veuillez entrer un second nombre entier : ");

        // calculer le maximum de ces deux nombres
        int max = Maximum(nombre_1, nombre_2);

        // afficher le résultat
        AfficherMaximum(nombre_1, nombre_2, max);
    }
}