// Auteur : Romain PERRIN

using System;

class GagnePerdu
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
    * <summary>Affichage d'un message textuel sur le terminal.</summary>
    * <param name="msg">Le message à afficher.</param>
    * <returns></returns>
    */
    public static void AfficherTexte(string msg)
    {
        Console.WriteLine(msg);
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    /**
    * <summary>Teste si un nombre est entre deux bornes données.</summary>
    * <param name="n">Le nombre entier à tester.</param>
    * <param name="borne_inf">La borne inférieure de l'intervalle.</param>
    * <param name="borne_sup">La borne supérieure de l'intervalle.</param>
    * <returns>Vrai si <paramref name="n"/> est dans 
    * [<paramref name="borne_inf"/>,<paramref name="borne_sup"/>],
    * faux sinon.</returns>
    */
    public static bool AppartenanceIntervalle(int n, int borne_inf, int borne_sup)
    {
        if (n >= borne_inf && n <= borne_sup)
        {
            return true;
        }
        return false;
    }

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    static void Main()
    {
        // constantes : intervalle = [12, 24]
        const int BORNE_INFERIEURE = 12;
        const int BORNE_SUPERIEURE = 24;

        // lire un entier depuis le terminal
        int nombre = LireEntier("Veuillez entrer un nombre entier : ");

        // tester s'il appartient à l'intervalle [borne_inf,borne_sup]
        // afficher gagné ou perdu dans le terminal
        if (AppartenanceIntervalle(nombre, BORNE_INFERIEURE, BORNE_SUPERIEURE))
        {
            AfficherTexte("C'est gagné :)");
        }
        else
        {
            AfficherTexte("C'est perdu :(");
        }
        
    }   
}