// Auteur : Romain PERRIN
// Feuille d'exercice supplémentaires sur les chaines de caractères, exercice PG-2
using System;

class PG2
{
    // Procédure : lit un entier depuis le terminal
    // Paramètres :
    //  - msg (string): message textuel à afficher à l'utilisateur
    // Retourne : un entier lu depuis le terminal
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        return int.Parse(Console.ReadLine());
    }

    // Procédure : affiche une chaine de caractères dans le terminal
    // Paramètres :
    //  - msg (string): la chaine à afficher
    // Retourne : /
    public static void AfficheChaine(string msg)
    {
        Console.WriteLine(msg);
    }

    // Fonction : détermine le nombre de chiffres dans un nombre entier
    // Paramètres:
    //  - n (int): entier
    // Retourne : le nombre de chiffres de 'n'
    public static int NombreDeChiffres(int n)
    {
        // on commence à 1 car un nombre ne peut avoir moins d'un chiffre !
        int chiffres = 1;
        int res = n / 10;
        // divisions entières successives par 10 jusqu'à obtenir 0
        while (res / 10 != 0)
        {
            chiffres++;
            res = res / 10;
        }
        return chiffres;
    }

    // Fonction : ItoA transforme un entier en chaine de caractères (sans ToString)
    // Paramètres :
    //  - n (int): un entier
    // Retourne : une chaine
    public static string ItoA(int n)
    {
        string chaine = "";
        int chiffres = NombreDeChiffres(n);
        int b = (int)Math.Pow(10, chiffres); // base 10 exposant le nombre de chiffres du nombre
        for (int i = 0; i <= chiffres; i++)
        {
            int chiffre = n / b; // chiffre courant dans le nombre
            n = n % b;  // reste de la division du nombre par la base courante
            char cc = (char)(chiffre + 48); // cast de l'entier en caractère + 48 (code ASCII du chiffre 0)
            chaine = chaine + cc;   // concaténation de la chaine avec le chiffre courant
            b = b / 10; // diminution d'un ordre de grandeur
        }
        return chaine;
    }
    
    static void Main()
    {
        // demande une chaine de caractères
        int n = LireEntier("Entrez un entier : ");
        // converti en entier
        string chaine = ItoA(n);
        // affiche le résultat
        AfficheChaine("AtoI (" + n + ") = " + chaine);
    }
}