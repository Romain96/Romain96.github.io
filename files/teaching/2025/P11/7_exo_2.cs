// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
{
	// Fonction : GenererListePremiersErathostene
	// Entrée :	- n : entier
	// Sortie :	liste d'entiers
	public static List<int> GenererListePremiersErathostene(int n)
	{
		List<int> l = new List<int>();
		
		for (int i = 2; i <= n; i++)
		{
			l.Add(i);
		}

		int size = l.Count;
		for (int i = 0; i < size; i++)
		{
			for (int j = i + 1; j < size; j++)
			{
				if (l[j] % l[i] == 0)
				{
					l.Remove(l[j]);
					size--;
				}
			}
		}

		return l;
	}

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

	public static void Main()
	{
		int max;
		string saisie;

		do
		{
			do
			{
				Console.Clear();
				Console.Write("Saisir la valeur maximale (> 0) : ");
				saisie = Console.ReadLine();
			}
			while (saisie.Length < 1);
			max = int.Parse(saisie);
		}
		while (max < 1);

		List<int> premiers = GenererListePremiersErathostene(max);
		AfficherListeEntiers(premiers);
	}
}
