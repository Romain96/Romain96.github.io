// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice7
{
	// Procédure : TrierListeEntiersCroissant
	// Entrée :	- liste : Liste<entier>
	// Sortie :	void
	public static void TrierListeEntiersCroissant(List<int> liste)
	{
		// tri à bulles (why not)
		for (int i = 0; i < liste.Count; i++)
		{
			for (int j = 0; j < liste.Count - i - 1; j++)
			{
				if (liste[j + 1] < liste[j])
				{
					int tmp = liste[j];
					liste[j] = liste[j + 1];
					liste[j + 1] = tmp;
				}
			}
		}
	}
	
	// Procédure : AfficherPremierEtDernierElements
	// Entrée :	- entiers : Liste<entier>
	// Sortie :	void
	public static void AfficherPremierEtDernierElements(List<int> entiers)
	{
		if (entiers.Count > 0)
		{
			Console.WriteLine("Le premier élément de la liste est " + entiers[0]);
			Console.WriteLine("Le dernier élément de la liste est " + entiers[entiers.Count - 1]);
		}
		else
		{
			Console.WriteLine("La liste est vide !");
		}
	}
	
	
	// Procédure : TrierEtAfficherListeEntiers (procédure principale)
	// Entrée :	- entiers : Liste<entier>
	// Sortie :	void
	public static void TrierEtAfficherListeEntiers(List<int> entiers)
	{
		AfficherPremierEtDernierElements(entiers);
		Console.WriteLine("Tri de la liste par ordre croissant...");
		TrierListeEntiersCroissant(entiers);
		AfficherPremierEtDernierElements(entiers);
	}
	
	
	// Procédure : AfficherListeEntier
	// Entrée :	- entiers : Liste<entier>
	// Sortie :	void
	public static void AfficherListeEntier(List<int> entiers)
	{
		Console.Write("Liste<entier> { ");
		foreach (int entier in entiers)
		{
			Console.Write(entier + " ");
		}
		Console.WriteLine("}");
	}
	
	
	// Fonction : InitialiserListeEntiersAleatoires
	// Entrée :	- taille : entier (nombre d'éléments dans la liste)
	//			- min : entier (entier min dans la liste)
	//			- max : entier (entier max dans la liste)
	// Sortie :	Liste<entier>
	public static List<int> InitialiserListeEntiersAleatoires(int taille, int min, int max)
	{
		List<int> entiers = new List<int>();
		Random gen = new Random();
		
		for (int i = 0; i < taille; i++)
		{
			entiers.Add(gen.Next(min, max + 1));
		}
		
		return entiers;
	}
	
	
	public static void Main()
	{
		// créer une liste d'entiers aléatoires
		const int TAILLE = 10;
		const int MIN = 0;
		const int MAX = 100;
		List<int> entiers = InitialiserListeEntiersAleatoires(TAILLE, MIN, MAX);
		AfficherListeEntier(entiers);
		
		// tri et affichage
		TrierEtAfficherListeEntiers(entiers);
	}
}
