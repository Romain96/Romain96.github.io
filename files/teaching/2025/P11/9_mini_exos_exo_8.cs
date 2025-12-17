// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice8
{
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
	
	
	// Fonction : RechercherIndicePlusGrand
	// Entrée :	- entiers : Liste<entier>
	//			- n : entier
	// Sortie :	entier
	public static int RechercherIndicePlusGrand(List<int> entiers, int n)
	{
		int indice = 0;
		
		while (indice < entiers.Count)
		{
			if (entiers[indice] > n)
			{
				return indice;
			}
			else
			{
				indice++;
			}
		}
		
		return -1;	// erreur (toutes les valeurs sont inférieures ou égales à n
	}
	
	
	public static void Main()
	{
		// créer une liste d'entiers aléatoires
		const int TAILLE = 25;
		const int MIN = 0;
		const int MAX = 100;
		List<int> entiers = InitialiserListeEntiersAleatoires(TAILLE, MIN, MAX);
		AfficherListeEntier(entiers);
		
		// saisir un entier
		string saisie;
		int n;
		do
		{
			Console.Write("Saisir la valeur de n : ");
			saisie = Console.ReadLine();
		}
		while (saisie.Length < 1);
		n = int.Parse(saisie);
		
		Console.WriteLine("L'indice du premier entier > " + n + " est " + RechercherIndicePlusGrand(entiers, n));
	}
}
