// Auteur : Romain PERRIN

using System;

class Exercice8
{  
	// Fonction : InitTab
    // Sortie : tableau 1D de 6 entiers
    public static int[] InitTab()
    {
       int[] tab = new int[] {2, 6, 1, 4, 5, 3};
	   return tab;
    }
	
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
	
	// Procédure : TriBulles
    // Entrée : - tab : tableau 1D d'entiers
    // Sortie : void
    public static void TriBulles(int[] tab)
    {
		int temp;
		for (int i = tab.Length - 1; i > 0; i--)
		{
			for (int j = 0; j < i; j++)
			{
				if (tab[j + 1] < tab[j])
				{
					temp = tab[j + 1];
					tab[j + 1] = tab[j];
					tab[j] = temp;
				}
			}
		}
	}
	
    public static void Main()
    {
		int[] tab = InitTab();
		Console.WriteLine("Avant le tri à bulles");
		AfficherTableauEntier(tab);
		TriBulles(tab);
		Console.WriteLine("Après le tri à bulles");
		AfficherTableauEntier(tab);
    }
}
