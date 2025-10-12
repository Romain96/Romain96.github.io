// Auteur : Romain PERRIN

using System;

class Exercice3
{
	// Fonction : SommeLigne
	// Entrée : - tab : tableau2D d'entiers
	//			- ligne : entier
	// Type de sortie : entier
	public static int SommeLigne(int[,] tab, int ligne)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(1); i++)
		{
			somme += tab[ligne, i];
		}
		return somme;
	}
	
	// Fonction : SommeColonne
	// Entrée : - tab : tableau2D d'entiers
	//			- colonne : entier
	// Type de sortie : entier
	public static int SommeColonne(int[,] tab, int colonne)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i, colonne];
		}
		return somme;
	}
	
	// Fonction : SommeDiagonale1
	// Entrée : - tab : tableau2D d'entiers
	// Type de sortie : entier
	public static int SommeDiagonale1(int[,] tab)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i,i];
		}
		return somme;
	}
	
	// Fonction : SommeDiagonale2
	// Entrée : - tab : tableau2D d'entiers
	// Type de sortie : entier
	public static int SommeDiagonale2(int[,] tab)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i,  tab.GetLength(0) - 1 - i];
		}
		return somme;
	}
	
	// Fonction : VerifierCarreMagique
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : booléen
	public static bool VerifierCarreMagique(int[,] tab)
	{
		// vérification des diagonales
		int somme = SommeDiagonale1(tab);
		if (SommeDiagonale2(tab) != somme)
		{
			return false;
		}
		
		// vérification des lignes
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			if (SommeLigne(tab, i) != somme)
			{
				return false;
			}
		}
		
		// vérification des colonnes
		for (int i = 0; i < tab.GetLength(1); i++)
		{
			if (SommeColonne(tab, i) != somme)
			{
				return false;
			}
		}
		
		// tous les tests sont passés, c'est un carré magique !
		return true;
	}
	
	// Fonction : InitTab
	// Entrée :	- estMagique : booléen
	// Type de sortie : tableau 2D d'entiers
	public static int[,] InitTab(bool estMagique)
	{
		int[,] tab = new int[3,3] {{2, 7, 6}, {9, 5, 1}, {4, 3, 8}};
		if (!estMagique)
		{
			tab[1,1] = 7;	// n'est plus magique
		}
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
	
	public static void Main()
	{
		int[,] tab1 = InitTab(true);
		int[,] tab2 = InitTab(false);
		Console.WriteLine("Tableau 1");
		AfficherTableau2D(tab1);
		Console.WriteLine($"Le tableau est magique : {VerifierCarreMagique(tab1)}");
		Console.WriteLine("Tableau 2");
		AfficherTableau2D(tab2);
		Console.WriteLine($"Le tableau est magique : {VerifierCarreMagique(tab2)}");
	}
}
