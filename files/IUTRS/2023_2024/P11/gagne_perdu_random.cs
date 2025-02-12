// Auteur : Romain PERRIN

using System;
using static System.Random;

class GagnePerduRandom
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
    * <summary>Génère la borne inférieure d'un intervalle de taille <paramref name="taille"/>.</summary>
    * <param name="taille">La taille de l'intervalle.</param>
    * <param name="min">La valeur minimum assignable à la borne inférieure.</param>
    * <param name="max">La valeur maximale assignable à la borne supérieure.</param>
    * <returns>La borne inférieure de l'intervalle dans [<paramref name="min"/>,
    * <paramref name="max"/>-<paramref name="taille"/>]</returns>
    */
    public static int GenererBorneInferieure(int taille, int min, int max)
    {
        // instanciation d'un nouvel object de type Random
        // vous verrez ça plus tard avec le paradigme orienté objets !
        Random rnd = new Random();
        int borne_inf = rnd.Next(min, max - taille);
        return borne_inf;
    }

    /**
    * <summary>Génère la borne supérieure d'un intervalle de taille <paramref name="taille"/>.</summary>
    * <param name="borne_inf">La borne inférieure générée.</param>
    * <param name="taille">La taille de l'intervalle.</param>
    * <returns>La borne supérieure de l'intervalle de borne inférieure <paramref name="borne_inf"/>
    * et de taille <paramref name="taille"/>.</returns>
    */
    public static int GenererBorneSuperieure(int borne_inf, int taille)
    {
        return borne_inf + taille;
    }

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
        // constantes : valeur minimum et maximum des bornes, taille de l'intervalle
        const int MIN_BORNE_INFERIEURE = 0;
        const int MAX_BORNE_INFERIEURE = 100;
        const int TAILLE_INTERVALLE = 10;

        // générer les bornes de l'intervalle
        int borne_inf = GenererBorneInferieure(TAILLE_INTERVALLE, MIN_BORNE_INFERIEURE, MAX_BORNE_INFERIEURE);
        int borne_sup = GenererBorneSuperieure(borne_inf, TAILLE_INTERVALLE);

        // lire un entier depuis le terminal
        int nombre = LireEntier("Veuillez entrer un nombre entier : ");

        // tester s'il appartient à l'intervalle [borne_inf,borne_sup]
        // afficher gagné ou perdu dans le terminal
        if (AppartenanceIntervalle(nombre, borne_inf, borne_sup))
        {
            AfficherTexte("C'est gagné :)");
        }
        else
        {
            AfficherTexte("C'est perdu :(");
        }
        
    }   
}