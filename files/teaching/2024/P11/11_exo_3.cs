// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceFusionListes
{
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
		if (liste.Count > 0)
		{
			Console.Write($"{liste[liste.Count - 1]}\n");
		}
		else
		{
			Console.Write("{}\n");
		}
	}

	// Fonction : FusionListesTriees
	// Précondition : liste1 et liste2 sont triées dans l'ordre croissant
	// Entrée :		- liste1 : liste d'entiers
	//				- liste2 : liste d'entiers
	// Local :		/
	// Sortie :		- listeTriee : liste d'entiers
	public static List<int> FusionListesTriees(List<int> liste1, List<int> liste2)
	{
		List<int> listeTriee = new List<int>();

		// deux listes vides -> liste vide
		if (liste1.Count == 0 && liste2.Count == 0)
		{
			return listeTriee;
		}
		// une liste vide -> retourner un copie de la seconde liste
		if (liste1.Count == 0)
		{
			listeTriee = liste2.GetRange(0, liste2.Count);
			return listeTriee;
		}
		if (liste2.Count == 0)
		{
			listeTriee = liste1.GetRange(0, liste1.Count);
			return listeTriee;
		}
		// sinon fusion de la tête de la liste ayant la plus petite valeur à chaque itération
		int indice1 = 0;
		int indice2 = 0;
		while (indice1 < liste1.Count && indice2 < liste2.Count)
		{
			// insertion de la tête de liste1
			if (liste1[indice1] < liste2[indice2])
			{
				listeTriee.Add(liste1[indice1]);
				indice1++;
			}
			// insertion de la tête de liste2
			else
			{
				listeTriee.Add(liste2[indice2]);
				indice2++;
			}
		}
		// une des deux listes est arrivée au bout, on copie le reste de la liste restante en fin de listeTriee
		if (indice1 < liste1.Count)
		{
			for (int i = indice1; i < liste1.Count; i++)
			{
				listeTriee.Add(liste1[i]);
			}
		}
		if (indice2 < liste2.Count)
		{
			for (int i = indice2; i < liste2.Count; i++)
			{
				listeTriee.Add(liste2[i]);
			}
		}
		return listeTriee;
	}

	// Fonction : TriInsertionListe
	// Entrée :		- liste : liste d'entiers
	// Local :		- valeur, indice : entier
	//				- stop : booléen
	// Sortie :		- listeTriee : liste d'entiers
	public static List<int> TriInsertionListe(List<int> liste)
	{
		List<int> listeTriee = new List<int>();
		if (liste.Count == 0)
		{
			return listeTriee;
		}
		listeTriee.Add(liste[0]);
		for (int i = 1; i < liste.Count; i++)
		{
			int valeur = liste[i];
			int indice = 0;	// indice d'insertion
			bool stop = false;
			while (indice < listeTriee.Count && !stop)
			{
				Console.WriteLine($"{indice}");
				if (listeTriee[indice] >= valeur)
				{
					listeTriee.Insert(indice, valeur);
					stop = true;
				}
				indice++;
			}
			// si non insérée, alors ajoute en fin
			if (!stop)
			{
				listeTriee.Add(valeur);
			}
		}
		return listeTriee;
	}

	public static void Main()
	{
		List<int> l1 = new List<int> {0, 1, 5, 9, 12};	// liste triée 1
		List<int> l2 = new List<int> {2, 3, 4, 6, 7, 8, 10, 11, 13, 14, 15};	// liste triée 2
		Console.WriteLine("Liste 1 :");
		AfficherListe(l1);
		Console.WriteLine("Liste 2 :");
		AfficherListe(l2);
		Console.WriteLine("Fusion :");
		AfficherListe(FusionListesTriees(l1, l2));
		AfficherListe(TriInsertionListe(new List<int>{2,1,3,5,4}));
	}
}