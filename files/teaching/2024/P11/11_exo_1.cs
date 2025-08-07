// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceListeEntiers
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

	// Fonction : CreerListeFibonacci
	// Entrée :		- n : entier
	// Local !		/
	// Sortie :		- liste : liste d'entiers
	public static List<int> CreerListeFibonacci(int n)
	{
		// cas d'arrêt 1 : liste vide
		if (n < 0)
		{
			return new List<int>();
		}
		List<int> liste = new List<int>();
		// cas d'arrêt 2 : liste de 1 élément
		if (n == 0)
		{
			liste.Add(0);
			return liste;
		}
		// cas général : liste de 2+ éléments
		liste.Add(0);	// Fibonacci(0)
		liste.Add(1);	// Fibonacci(1)
		for (int i = 2; i < n; i++)
		{
			// Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)
			liste.Add(liste[liste.Count - 1] + liste[liste.Count - 2]);
		}
		return liste;
	}

	// Fonction : RechercheIndicePremiereApparitionTrie
	// Entrée :		- liste : liste d'entiers
	//				- val : entier
	// Local :		/
	// Sortie :		- indice : entier
	public static int RechercheIndicePremiereApparitionTrie(List<int> liste, int val)
	{
		for (int i = 0; i < liste.Count; i++)
		{
			// première apparition trouvée -> arrêt sur i
			if (liste[i] == val)
			{
				return i;
			}
			// liste triée et élément courant supérieur -> arrêt car val n'est pas présente dans liste
			else if (liste[i] > val)
			{
				return -1;
			}
		}
		// fin de la liste, élément non trouvé
		return -1;
	}

	// Fonction : RechercheIndicePremiereApparitionNonTrie
	// Entrée :		- liste : liste d'entiers
	//				- val : entier
	// Local :		/
	// Sortie :		- indice : entier
	public static int RechercheIndicePremiereApparitionNonTrie(List<int> liste, int val)
	{
		for (int i = 0; i < liste.Count; i++)
		{
			// première apparition trouvée -> arrêt sur i
			if (liste[i] == val)
			{
				return i;
			}
		}
		// fin de la liste, élément non trouvé
		return -1;
	}

	// Fonction : RecherchePlusGrandeMonotonieCroissante
	// Entrée :		- liste : liste d'entiers
	// Local :		- 
	// Sortie : 	- monotonie : liste d'entiers
	public static List<int> RecherchePlusGrandeMonotonieCroissante(List<int> liste)
	{
		int debut = 0;
		int indice = 1;
		int tailleMax = 1;
		int taille = 1;
		List<int> monotonie = new List<int>();
		if (liste.Count == 0)
		{
			return monotonie;
		}
		while (debut < liste.Count)
		{
			indice = debut + 1;
			taille = 1;
			while (indice < liste.Count && liste[indice] >= liste[indice - 1])
			{
				indice++;
				taille++;
			}
			if (taille > tailleMax)
			{
				monotonie = liste.GetRange(debut, taille);	// comme Substring mais pour les listes :)
			}
			debut = debut + taille;
		}

		return monotonie;
	}

	public static void Main()
	{
		// liste d'entiers initialisée directement
		List<int> Lint1 = new List<int> {3, 4, 2, 6, 12, 15, 9, 5, 2};
		AfficherListe(Lint1);

		// liste d'entiers initialisée avec une boucle de saisie
		List<int> Lint2 = new List<int>();
		Console.WriteLine("Entrer 10 entiers pour former une liste).");
		for (int i = 0; i < 10; i++)
		{
			int n = SaisirEntier($"Entrer le {i+1}e entier : ");
			Lint2.Add(n);
		}
		AfficherListe(Lint2);
	
		// liste Fibonacci
		Console.WriteLine("Liste Fibonacci(0-9).");
		List<int> LFibo = CreerListeFibonacci(10);
		AfficherListe(LFibo);

		// Recherche de A = 5 et B = 8 (Fibonacci est triée -> recherche triée, l'autre liste pas nécessairement -> recherche non triée)
		Console.WriteLine($"Recherche de la valeur A = 5 dans LFibo : {RechercheIndicePremiereApparitionTrie(LFibo, 5)}.");
		Console.WriteLine($"Recherche de la valeur B = 8 dans LFibo : {RechercheIndicePremiereApparitionTrie(LFibo, 8)}.");
		Console.WriteLine($"Recherche de la valeur A = 5 dans Lint2 : {RechercheIndicePremiereApparitionNonTrie(Lint2, 5)}.");
		Console.WriteLine($"Recherche de la valeur B = 8 dans Lint2 : {RechercheIndicePremiereApparitionNonTrie(Lint2, 8)}.");

		// plus grande monotonie croissante dans Lint
		Console.WriteLine("Lint1 : ");
		AfficherListe(Lint1);
		Console.Write($"Recherche de la plus grande monotonie croissante dans Lint1 : ");
		AfficherListe(RecherchePlusGrandeMonotonieCroissante(Lint1));
	}
}