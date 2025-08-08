using System;

class Bornes
{
    // Procédure : affiche un entier dans le terminal
    // Paramètres :
    //  - n (int): l'entier à afficher
    // Retourne : /
    public static void AfficherEntier(int n)
    {
        Console.WriteLine("" + n);
    }

    // Fonction : affiche les nombres entiers entre deux bornes (incluses)*
    // Paramètres :
    //  - inf (int): borne inférieure
    //  - sup (int): borne supérieure
    // Retourne : /
    public static void AfficherEntiersEntreBornes(int inf, int sup)
    {
        for (int i = inf; i <= sup; i++)
            AfficherEntier(i);
    }
    static void Main()
    {
        // déclarer deux bornes 12 et 24
        const int INF = 12;
        const int SUP = 24;
        // appeler une fonction affichant les nombres de inf à sup
        AfficherEntiersEntreBornes(INF, SUP);
    }
}