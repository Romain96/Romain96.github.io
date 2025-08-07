// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceCribleEratothene
{
	// Fonction : SaisirEntier
	// Entrée :		- texte : chaîne de caractères
	// Local :		/
	// Sortie :		- entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}

	// Procédure : AfficherListe
	// Entrée :		- liste : liste d'entiers
	// Local :		/ 
	// Sortie :		void
	public static void AfficherListe(List<int> liste)
	{
		Console.Write("Liste : ");
		for (int i = 0; i < liste.Count - 1; i++)
		{
			Console.Write($"{liste[i]} ");
		}
		Console.Write($"{liste[liste.Count - 1]}\n");
	}

	// Fonction : CreerListeNombresPremierCribleEratothene
	// Entrée :		- n : entier
	// Local !		/
	// Sortie :		- premiers : liste d'entiers
	public static List<int> CreerListeNombresPremierCribleEratothene(int n)
	{
		List<int> premiers = new List<int>();
		bool[] aConserver = new bool[n + 1];
		for (int i = 0; i < n + 1; i++)
		{
			aConserver[i] = true;
		}		

		for (int i = 2; i * i < n + 1; i++)
		{
			if (aConserver[i])
			{
				for (int j = i * i; j < n + 1; j += i)
				{
					aConserver[j] = false;	// suppression de j
				}
			}
		}

		// création de la liste
		for (int i = 2; i < n + 1; i++)
		{
			if (aConserver[i])
			{
				premiers.Add(i);
			}
		}

		return premiers;
	}

	// Fonction : CompterNombresPremiersInferieurs
	// Entrée :		- n : entier
	// Local :		- premiers : liste d'entiers
	// Sortie :		- entier
	public static int CompterNombresPremiersInferieurs(int n)
	{
		List<int> premiers = CreerListeNombresPremierCribleEratothene(n);
		return premiers.Count;
	}

	// Procédure : AfficherNombresPremiersInferieurs
	// Entrée :		- n : entier
	// Local :		- premiers : liste d'entiers
	// Sortie :		void
	public static void AfficherNombresPremiersInferieurs(int n)
	{
		List<int> premiers = CreerListeNombresPremierCribleEratothene(n);
		Console.Write($"Nombres premiers inférieurs à {n} : ");
		for (int i = 0; i < premiers.Count - 1; i++)
		{
			Console.Write($"{premiers[i]} ");
		}
		if (premiers.Count > 0)
		{
			Console.Write($"{premiers[premiers.Count - 1]}\n");
		}
		else
		{
			Console.Write("\n");
		}
	}

	public static void Main()
	{
		int n = SaisirEntier("Entrer un entier strictement positif : ");
		Console.Write($"Construction de liste des nombres premiers jusqu'à {n}.");
		AfficherListe(CreerListeNombresPremierCribleEratothene(n));
		Console.WriteLine($"Il y a {CompterNombresPremiersInferieurs(n)} nombres premiers inférieurs à {n}.");
		AfficherNombresPremiersInferieurs(n);
	}
}