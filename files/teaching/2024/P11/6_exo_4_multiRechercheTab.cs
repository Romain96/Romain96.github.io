// Auteur : Romain PERRIN

using System;

class Exercice3MultiRechercheTableau
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

	// Procédure : AfficherApparitionsEntiersEntreBornesDansTableau1D
	// Principe : compter le nombre d'apparitions d'un entier donné dans un tableau d'entiers (0 si non présent)
	// Entrée :		- tab : tableau 1D d'entiers
	//				- borneInf : entier
	//				- borneSup : entier
	// Local :		- i : entier
	// Sortie :		void
	public static void AfficherApparitionsEntiersEntreBornesDansTableau1D(int[] tab, int borneInf, int borneSup)
	{
		int nApparitions = 0;
		for (int i = borneInf; i <= borneSup; i++)
		{
			nApparitions = CompterApparitionsEntierDansTableau1D(tab, i);
			if (nApparitions > 0)
			{
				AfficherChaine($"Le nombre {i} apparait {nApparitions} fois dans le tableau.\n");
			}
			else
			{
				AfficherChaine($"Le nombre {i} n'apparait pas dans le tableau (nApparitions = {nApparitions}).\n");
			}
		}
	}

	// Procédure principale
	public static void Main()
	{
		// définir un tableau et 1 non trié, saisir deux entiers (bornes inf et sup de recher), appeler la procédure de recherche

		int[] tableau = new int[10]{1,2,3,4,2,5,6,7,1,2};
		AfficherTableauEntier1D(tableau);

		AfficherChaine("Saisir la borne inférieure de recherche : ");
		int borneInfUtilisateur = SaisirEntier();

		AfficherChaine("Saisir la borne supérieure de recherche : ");
		int borneSupUtilisateur = SaisirEntier();

		AfficherChaine($"Compter les apparitions des entiers entre {borneInfUtilisateur} et {borneSupUtilisateur} dans le tableau :\n");
		AfficherApparitionsEntiersEntreBornesDansTableau1D(tableau, borneInfUtilisateur, borneSupUtilisateur);
	}
}