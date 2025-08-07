// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
{
	// Procédure : affiche une liste d'entiers
	// Entrée :		- liste (List<int>): liste d'entiers
	// Local :		/
	// Sortie :		void
	public static void AfficherListe(List<int> liste)
	{
		Console.Write("");
		foreach (int n in liste)
		{
			Console.Write($"{n}".PadRight(5, ' '));
		}
		Console.Write("\n");
	}

	// Fonction : construit une liste de nv valeurs entières distinces
	// Précondition : np > 0, nv > 0
	// Entrée :		- np : entier
	//				- nv : entier
	// Local :		- indicePileCourante, sommetPileCourante, i, indicePile : entiers
	// Sortie :		- entiers : liste d'entiers
	public static List<int> ConstruireListeEntiersDistincts(int nv, int np)
	{
		// création d'un tableau de np piles
		Stack<int>[] tp = new Stack<int>[np];
		// création de np piles vides
		for (int i = 0; i < np; i++)
		{
			tp[i] = new Stack<int>();
		}

		// parcours des entiers de 1 à nv
		int indicePileCourante = 0;
		int sommetPileCourante = 0;
		for (int entier = 1; entier <= nv; entier++)
		{
			if (tp[indicePileCourante].Count > 0)
			{
				sommetPileCourante = tp[indicePileCourante].Peek();
			}
			tp[indicePileCourante].Push(entier + sommetPileCourante);
			indicePileCourante = (indicePileCourante + 1) % np;
		}

		// extraction des valeurs dans une liste
		List<int> entiers = new List<int>();
		for (int indicePile = 0; indicePile < np; indicePile++)
		{
			while (tp[indicePile].Count > 0)
			{
				entiers.Add(tp[indicePile].Pop());
			}
		}
		return entiers;
	}

	static void Main()
	{
		Console.WriteLine("Génération avec nv = 12 et np = 5");
		List<int> liste1 = ConstruireListeEntiersDistincts(12, 5);
		AfficherListe(liste1);

		Console.WriteLine("Génération avec nv = 12 et np = 3");
		List<int> liste2 = ConstruireListeEntiersDistincts(12, 3);
		AfficherListe(liste2);
	}
}