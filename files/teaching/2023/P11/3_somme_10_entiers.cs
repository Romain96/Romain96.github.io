using System;

class Somme10
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

    // Procédure : afficher un entier dans le terminal
    // Paramètres :
    //  - msg (string): le message précédent le nombre
    //  - n (int): l'entier à afficher
    // Retourne : /
    public static void AfficherEntier(string msg, int n)
    {
        Console.WriteLine(msg + n);
    }

    // Fonction : demande 10 entiers et retourne la somme
    // Paramètres : /
    // Retourne : 
    //  - somme (int): la somme des 10 entiers
    public static int CalculerSomme()
    {
        int somme = 0;
        for(int i = 0; i < 10; i++)
        {
            // lire un entier depuis le terminal
            int nUser = LireEntier("Entrez un entier : ");
            // ajouter à la somme
            somme += nUser;
        }
        return somme;
    }
    
    static void Main()
    {
        // répéter 10 fois :
        //  - demander un entier
        int somme = CalculerSomme();
        // afficher la somme
        AfficherEntier("la somme vaut : ", somme);
    }
}