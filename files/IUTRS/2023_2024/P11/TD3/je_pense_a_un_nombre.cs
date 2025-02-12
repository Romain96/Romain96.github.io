// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP5 (2023/09/29)
using System;
class JePenseAUnNombre
{
    // Procédure : lire un entier depuis le terminal
    // Paramètres :
    //  - msg (string): le message à afficher à l'utilisateur
    // Retourne :
    //  - n (int): l'entier lu et converti depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        int n = int.Parse(Console.ReadLine());
        return n;
    }

    // Procédure : afficher une chaîne dans le terminal
    // Paramètres :
    //  - str (string): chaîne à afficher
    // Retourne : /
    public static void AfficherChaine(string str)
    {
        Console.WriteLine(str);
    }

    // Fonction : demande à l'utilisateur de trouver un nombre
    // Paramètres :
    //  - n (int): le nombre à trouver (0-100)
    // Retrourne :
    //  - tentatives (int): le nombre de tentatives utilisées
    public static int TrouverLeNombre(int n)
    {
        int tentatives = 1;
        int choix = LireEntier("Trouvez le nombre... ");
        while (choix != n)
        {
            if (choix < n)
                AfficherChaine("Plus grand !");
            else
                AfficherChaine("Plus petit !");
            choix = LireEntier("Trouvez le nombre... ");
            tentatives++;           
        }
        return tentatives;
    }
    static void Main()
    {
        // choisir un entier alétoire entre 0 et 100
        Random rnd = new Random();
        int n = rnd.Next(100);
        // Tant que l'utilisateur n'a pas trouvé le nombre
        //  - demande un nombre (0-100)
        int tentatives = TrouverLeNombre(n);
        AfficherChaine("Tentatives : " + tentatives);
    }
}