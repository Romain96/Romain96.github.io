// Auteur : Romain PERRIN

using System;

class Exercice3
{
	// Fonction : InitialierTableauEntiersAleatoires
	// Entrée :	- taille : entier (taille du tableau)
	//			- min : entier (valeur min des entiers à générer)
	//			- max : entier (valeur max des entiers à générer)
	// Sortie :	tableau 1D de taille entiers
	public static int[] InitialierTableauEntiersAleatoires(int taille, int min, int max)
	{
		int[] tab = new int[taille];
		
		Random gen = new Random();
		
		for (int i = 0; i < taille; i++)
		{
			tab[i] = gen.Next(min, max + 1);
		}
		
		return tab;
	}
	
	
	// Procédure : AfficherTableau
	// Entrée :	tab : tableau 1D d'entiers
	// Sortie : void
	public static void AfficherTableau(int[] tab)
	{
		Console.Write("tableau 1D [ ");
		foreach (int entier in tab)
		{
			Console.Write(entier + " ");
		}
		Console.WriteLine("]");
	}
	
	
	// Fonction : CalculerMoyenne
	// Entrée :	- tab : tableau 1D d'entiers
	// Sortie :	réel (moyenne de tab)
	public static double CalculerMoyenne(int[] tab)
	{
		double moyenne = 0.0;
		
		foreach (int entier in tab)
		{
			moyenne += entier;
		}
		
		return moyenne / tab.Length;
	}
	
	
	// Fonction : CalculerMin
	// Entrée :	- tab : tableau 1D d'entiers
	// Sortie :	entier (valeur min de tab)
	public static int CalculerMin(int[] tab)
	{
		int min = tab[0];
		
		foreach (int entier in tab)
		{
			if (entier < min)
			{
				min = entier;
			}
		}
		
		return min;
	}
	
	
	// Fonction : CalculerMax
	// Entrée :	- tab : tableau 1D d'entiers
	// Sortie :	entier (valeur max de tab)
	public static int CalculerMax(int[] tab)
	{
		int max = tab[0];
		
		foreach (int entier in tab)
		{
			if (entier > max)
			{
				max = entier;
			}
		}
		
		return max;
	}
	
	
	public static void Main()
	{
		const int TAILLE = 20;
		const int MIN = 0;
		const int MAX = 50;
		
		// générer et afficher un tableau aléatoire
		int[] tab = InitialierTableauEntiersAleatoires(TAILLE, MIN, MAX);
		AfficherTableau(tab);
		
		// calculer et afficher la moyenne, le minimum et le maximum
		Console.WriteLine("La moyenne vaut " + CalculerMoyenne(tab));
		Console.WriteLine("Le minimum est " + CalculerMin(tab));
		Console.WriteLine("Le maximum est " + CalculerMax(tab));
	}
}
