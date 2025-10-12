// Auteur : Romain PERRIN

using System;

class Exercice1
{
	// Fonction : InitTab
	// Entrée :	/
	// Type de sortie  : tableau 2D d'entiers
	public static int[,] InitTab()
	{
		int[,] tab = new int[10, 10] {
			{52, 17, 54, 5, 99, 81, 79, 90, 39, 46},
			{91, 77, 90, 76, 72, 31, 38, 10, 82, 62},
			{48, 18, 13, 38, 2, 85, 67, 18, 67, 28},
			{14, 65, 9, 76, 56, 86, 84, 10, 75, 16},
			{18, 87, 17, 65, 98, 88, 45, 31, 14, 21},
			{38, 55, 76, 75, 10, 33, 3, 16, 3, 14},
			{14, 61, 23, 11, 31, 25, 68, 14, 19, 85},
			{47, 27, 35, 66, 43, 61, 1, 48, 39, 13},
			{40, 36, 3, 46, 89, 59, 89, 33, 65, 22},
			{83, 67, 6, 61, 2, 57, 64, 5, 34, 73}
		};
		return tab;
	}
	
	// Procédure : AfficherTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : void
	public static void AfficherTableau2D(int[,] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				Console.Write($"{tab[i,j]} ");
			}
			Console.Write("\n");
		}
	}
	
	// Fonction : CalculerMinTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : entier
	public static int CalculerMinTableau2D(int[,] tab)
	{
		int min = tab[0,0];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] < min)
				{
					min = tab[i,j];
				}
			}
		}
		return min;
	}
	
	// Fonction : CalculerMaxTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : entier
	public static int CalculerMaxTableau2D(int[,] tab)
	{
		int max = tab[0,0];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] > max)
				{
					max = tab[i,j];
				}
			}
		}
		return max;
	}
	
	// Fonction : CalculerMoyenneTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : réel
	public static float CalculerMoyenneTableau2D(int[,] tab)
	{
		float moyenne = 0.0f;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				moyenne += tab[i,j];
			}
		}
		moyenne = moyenne / (tab.GetLength(0) * tab.GetLength(1));
		return moyenne;
	}
	
	// Fonction : CalculerMoyenneLigneTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	//			- ligne : entier
	// Type de sortie : réel
	public static float CalculerMoyenneLigneTableau2D(int[,] tab, int ligne)
	{
		float moyenneLigne = 0.0f;
		for (int i = 0; i < tab.GetLength(1); i++)
		{
			moyenneLigne += tab[ligne, i];
		}
		moyenneLigne = moyenneLigne / tab.GetLength(1);
		return moyenneLigne;
	}
	
	// Procédure : AfficherMoyenneLignesTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : void
	public static void AfficherMoyenneLignesTableau2D(int[,] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
		Console.WriteLine($"La moyenne de la ligne {i+1} est : {CalculerMoyenneLigneTableau2D(tab, i)}");
		}
	}
	
	public static void Main()
	{
		int[,] tab = InitTab();
		AfficherTableau2D(tab);
		Console.WriteLine($"La valeur min est : {CalculerMinTableau2D(tab)}");
		Console.WriteLine($"La valeur max est : {CalculerMaxTableau2D(tab)}");
		Console.WriteLine($"La valeur moyenne est : {CalculerMoyenneTableau2D(tab)}");
		AfficherMoyenneLignesTableau2D(tab);
	}
}
