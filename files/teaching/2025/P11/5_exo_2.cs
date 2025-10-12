// Auteur : Romain PERRIN

using System;

class Exercice2
{
	// Fonction : InitTab
	// Entrée : /
	// Type de sortie : tableau 2D d'entiers de 10x10
	public static int[,] InitTab()
	{
		int[,] tab = new int[10,10];
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				tab[i,j] = 0;
			}
		}
		// des 1 dans chaque case de la première colonne
		for (int i = 0; i < 10; i++)
		{
			tab[i, 0] = 1;
		}
		return tab;
	}
	
	// Procédure : CalculerTrianglePascal
	// Entrée :	- tab : tableau 2D d'entiers (initialisé avec InitTab)
	// Type de sortie : void
	public static void CalculerTrianglePascal(int[,] tab)
	{
		for (int i = 1; i < tab.GetLength(0); i++)
		{
			for (int j = 1; j  < tab.GetLength(1); j++)
			{
				tab[i, j] = tab[i - 1, j - 1] + tab[i - 1, j];
			}
		}
	}
	
	// Procédure : AfficherTrianglePascal
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : void
	public static void AfficherTrianglePascal(int[,] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] != 0)
				{
					Console.Write($"{tab[i,j]}\t");
				}
				else
				{
					Console.Write("\t");
				}
			}
			Console.Write("\n");
		}
	}
	
	public static void Main()
	{
		int[,] tab = InitTab();
		CalculerTrianglePascal(tab);
		AfficherTrianglePascal(tab);
	}
}
