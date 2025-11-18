// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice1
{
	// Procédure : AfficherListeEntiers
	// Entrée :	- l : liste d'entiers
	// Sortie :	void
	public static void AfficherListeEntiers(List<int> l)
	{
		Console.Write("List<int> : { ");
		foreach (int v in l)
		{
			Console.Write($"{v} ");
		}
		Console.WriteLine("}");
	}

	// Procédure : AfficherListeEntiersEnvers
	// Entrée :	- l : liste d'entiers
	// Sortie :	void
	public static void AfficherListeEntiersEnvers(List<int> l)
	{
		Console.Write("List<int> (reverse) : { ");
		for (int i = l.Count - 1; i >= 0; i--)
		{
			Console.Write($"{l[i]} ");
		}
		Console.WriteLine("}");
	}

	// Procédure : TrierListeEntiersCroissant
	// Entrée :	l : liste d'entiers
	// Sortie :	void
	public static void TrierListeEntiersCroissant(List<int> l)
	{
		l.Sort();
	}

	// Procédure : TrierListeEntiersDecroissant
	// Entrée :	- l : liste d'entiers
	// Sortie :	void
	public static void TrierListeEntiersDecroissant(List<int> l)
	{
		l.Sort();	// ordre croissant
		l.Reverse();	// inversion = ordre décroissant
	}

	// Fonction : RemplirListEntier
	// Entrée :	- size : entier
	// 		- min : entier
	// 		- max : entier
	// Sortie :	liste de size entiers entre min et max
	public static List<int> RemplirListeEntiers(int size, int min, int max)
	{
		Random rand = new Random();
		List<int> l = new List<int>();
		for (int i = 0; i < size; i++)
		{
			l.Add(rand.Next(min, max + 1));
		}
		return l;
	}

	public static void Main()
	{
		const int SIZE = 100;
		const int MIN = 1;
		const int MAX = 100;
		List<int> l = RemplirListeEntiers(SIZE, MIN, MAX);
		// a)
		AfficherListeEntiers(l);
		// b)
		AfficherListeEntiersEnvers(l);
		// c)
		TrierListeEntiersCroissant(l);
		AfficherListeEntiers(l);
		// d)
		TrierListeEntiersDecroissant(l);
		AfficherListeEntiers(l);
	}
}
