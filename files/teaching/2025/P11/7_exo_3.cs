// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice3
{
	// Procédure : AfficherListeEntiers
	// Entrée :	- l : liste d'entiers
	// Sortie :	void
	public static void AfficherListeEntiers(List<int> l)
	{
		Console.Write("List<int> { ");
		foreach (int v in l)
		{
			Console.Write($"{v} ");
		}
		Console.WriteLine("}");
	}

	// Fonction : FusionerListesEntiers
	// Entrée :	- l1 : liste d'entiers
	// 		- l2 : liste d'entiers
	// Sortie :	liste d'entiers
	public static List<int> FusionnerListesEntiers(List<int> l1, List<int> l2)
	{
		List<int> res = new List<int>();

		int indice1 = 0;
		int indice2 = 0;

		// cas général : comparaison des deux prochaines valeurs à insérer, insertion de la plus petite
		while (indice1 < l1.Count && indice2 < l2.Count)
		{
			if (l1[indice1] < l2[indice2])
			{
				res.Add(l1[indice1]);
				indice1++;
			}
			else
			{
				res.Add(l2[indice2]);
				indice2++;
			}
		}

		// cas 1 : la liste l1 est vide, ajout de toutes les valeurs restantes de l2 dans res
		if (indice1 >= l1.Count)
		{
			for (; indice2 < l2.Count; indice2++)
			{
				res.Add(l2[indice2]);
			}
		}

		// cas 2 : la liste l2 est vide, ajout de toutes les valeurs restantes de l1 dans res 
		else if (indice2 >= l2.Count)
		{
			for (; indice1 < l1.Count; indice1++)
			{
				res.Add(l1[indice1]);
			}
		}

		return res;
	}

	public static void Main()
	{
		List<int> l1 = new List<int>() {2, 3, 4, 9};
		List<int> l2 = new List<int>() {1, 5, 6, 7, 8};
		AfficherListeEntiers(l1);
		AfficherListeEntiers(l2);
		
		List<int> l3 = FusionnerListesEntiers(l1, l2);
		AfficherListeEntiers(l3);
	}
}
