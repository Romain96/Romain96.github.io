// Auteur : Romain PERRIN

using System;

class Exercice3RechercheTableau
{
	// Procédure : AfficherChaine
	// Principe : Affiche un chaîne de caractères donnée dans la console
	// Précondition : /
	// Entrée :		- chaine : chaîne de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherChaine(string chaine)
	{
		Console.Write(chaine);
	}

	// Procédure : AfficherTableauEntier1D
	// Principe : Affiche un tableau d'entiers 1D dans la console
	// Précondition : /
	// Entrée :		- tab : tableau 1D d'entiers
	// Local :		- i : entier
	//				- j : entier
	// Sortie :		void
	public static void AfficherTableauEntier1D(int[] tab)
	{
		AfficherChaine("Tableau < ");
		for (int i = 0; i < tab.Length; i++)
		{
			AfficherChaine($"{tab[i]} ");
		}
		AfficherChaine(">\n");
	}

	// Fonction : SaisirEntier
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- n : entier
	public static int SaisirEntier()
	{
		return int.Parse(Console.ReadLine());
	}
	
	// Fonction : CompterApparitionsEntierDansTableau1D
	// Principe : compter le nombre d'apparitions d'un entier donné dans un tableau d'entiers (0 si non présent)
	// Entrée :		- tab : tableau 1D d'entiers
	//				- x : entier
	// Local :		- i : entier
	// Sortie :		- nApparitions : entier
	public static int CompterApparitionsEntierDansTableau1D(int[] tab, int x)
	{
		int nApparitions = 0;	// par défaut
		for (int i = 0 ; i < tab.Length; i++)
		{
			if (tab[i] == x)
			{
				nApparitions++;
			}
		}
		return nApparitions;
	}

	// Procédure principale
	public static void Main()
	{
		// définir un tableau et 1 non trié, saisir un entier, appeler la fonction de recherche et afficher le résultat

		int[] tableau = new int[10]{1,2,3,4,2,5,6,7,1,2};
		AfficherTableauEntier1D(tableau);

		AfficherChaine("Saisir un entier à rechercher : ");
		int xUtilisateur = SaisirEntier();

		int apparitions = CompterApparitionsEntierDansTableau1D(tableau, xUtilisateur);
		AfficherChaine($"L'entier {xUtilisateur} apparait {apparitions} fois dans le tableau.\n");

	}
}