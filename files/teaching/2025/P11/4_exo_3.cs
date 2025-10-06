// Auteur : Romain PERRIN

using System;

class Exercice3
{
    // Procédure : AfficherTableauEntier
    // Entrée : - tab : tableau 1D d'entiers
    // Sortie : void
    public static void AfficherTableauEntier(int[] tab)
    {
        Console.Write("tableau d'entiers : { ");
        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write($"{tab[i]} ");
        }
        Console.WriteLine("}");
    }
    
    // Procédure : InitialiserTableauSuiteFibonacci
    // Entrée : - tab : tableau 1D d'entiers
    // Sortie : void
    public static void InitialiserTableauSuiteFibonacci(int[] tab)
    {
		for (int i = 2; i < tab.Length; i++)
		{
			tab[i] = tab[i - 1] + tab[i - 2];
		}
    }
    
    public static void Main()
    {
        int[] tab = new int[20];
        tab[0] = 0;
        tab[1] = 1;
		Console.WriteLine("Tableau initialisé avant procédure Fibonacci");
		AfficherTableauEntier(tab);
		InitialiserTableauSuiteFibonacci(tab);
		Console.WriteLine("Tableau initialisé après procédure Fibonacci");
		AfficherTableauEntier(tab);
    }
}
