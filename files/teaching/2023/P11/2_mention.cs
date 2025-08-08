// Auteur : Romain PERRIN
using System;

class Mention
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
    * <summary>Affichage d'un message textuel contenant un nombre réel sur le terminal.</summary>
    * <param name="prefixe">Le message préfixant <paramref name="nb"/>.</param>
    * <param name="nb">Le nombre réel à afficher après <paramref name="prefixe"/></param>
    * <param name="suffixe">Le message suffixant <paramref name="nb"/> .</param>
    * <returns></returns>
    */
    public static void AfficherDouble(string prefixe, double nb, string suffixe)
    {
        Console.WriteLine(prefixe + nb + suffixe);
    }

    /**
    * <summary>Procédure d'affichage dans le terminal de la mention en fonction de la note /20.</summary>
    * <param name="note">La note /20.</param>
    * <returns></returns>
    */
    public static void AfficherMention(double note)
    {
        // Mentions :
        // moyenne < 10       -> pas de mention
        // 10 <= moyenne < 12 -> passable
        // 12 <= moyenne < 14 -> assez bien
        // 14 <= moyenne < 16 -> bien
        // moyenne >= 16      -> très bien
        if (note < 10.0)
        {
            AfficherDouble("Avec la note de ", note, ", vous n'obtenez aucune mention.");
        }
        else if (note >= 10 && note < 12)
        {
            AfficherDouble("Avec la note de ", note, ", vous obtenez la mention passable.");
        }
        else if (note >= 12 && note < 14)
        {
            AfficherDouble("Avec la note de ", note, ", vous obtenez la mention assez bien.");
        }
        else if (note >= 14 && note < 16)
        {
            AfficherDouble("Avec la note de ", note, ", vous obtenez la bien.");
        }
        else
        {
            AfficherDouble("Avec la note de ", note, ", vous obtenez la mention très bien.");
        }
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    static void Main()
    {
        // lire la note depuis le terminal
        double note_utilisateur = LireDouble("Veuillez entre votre note : ");

        // afficher la mention correspondant à la note
        AfficherMention(note_utilisateur);
    }
}