// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice3
{
	// Fonction : RemplirPileEntiersAleatoires
	// Entrée :	- n : entier
	//			- min : entier
	//			- max : entier
	// Sortie :	Pile<entier>
	public static Stack<int> RemplirPileEntiersAleatoires(int n, int min, int max)
	{
		Random rand = new Random();
		Stack<int> entiers = new Stack<int>();
		
		for (int i = 0; i < n; i++)
		{
			entiers.Push(rand.Next(min, max + 1));
		}
		
		return entiers;
	}
	
	
	// Procédure : AfficherPileEntiers
	// Entrée :	- entiers : Pile<entier>
	// Sortie :	void
	public static void AfficherPileEntiers(Stack<int> entiers)
	{
		Console.Write("Pile : ");
		foreach (int entier in entiers)
		{
			Console.Write($"{entier} ");
		}
		Console.Write("\n");
	}
	
	
	// Procédure : SeparerEntiersPairsEtImpairs
	// Entrée :	- entiers : Pile<entier>
	//			- pilePaire : référence vers une Pile<entier>
	//			- pileImpaire : référence vers une Pile<entier>
	// Sortie :	void
	public static void SeparerEntiersPairsEtImpairs(Stack<int> entiers, ref Stack<int> pilePaire, ref Stack<int> pileImpaire)
	{
		while (entiers.Count > 0)
		{
			if (entiers.Peek() % 2 == 0)
			{
				pilePaire.Push(entiers.Pop());
			}
			else
			{
				pileImpaire.Push(entiers.Pop());
			}
		}
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		const int NOMBRE_ENTIERS = 100;
		const int ENTIER_MIN = 1;
		const int ENTIER_MAX = 100;
		Stack<int> entiers = RemplirPileEntiersAleatoires(NOMBRE_ENTIERS, ENTIER_MIN, ENTIER_MAX);
		
		Console.WriteLine($"Pile de {NOMBRE_ENTIERS} entiers alétoires entre {ENTIER_MIN} et {ENTIER_MAX} :");
		AfficherPileEntiers(entiers);
		
		Stack<int> pilePaire = new Stack<int>();
		Stack<int> pileImpaire = new Stack<int>();
		SeparerEntiersPairsEtImpairs(entiers, ref pilePaire, ref pileImpaire);
		Console.WriteLine($"Pile des entiers pairs :");
		AfficherPileEntiers(pilePaire);
		Console.WriteLine($"Pile des entiers impairs :");
		AfficherPileEntiers(pileImpaire);
	}
}
