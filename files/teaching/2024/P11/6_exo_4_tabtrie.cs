// Auteur : Romain PERRIN

using System;

class Exercice3TestTableauTrie
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
	
	// Fonction : VerifierTableauTrie
	// Principe : vérifie que le tableau en entrée est trié dans l'ordre croissant
	// Entrée :		- tab : tableau 1D d'entiers
	// Local :		- i : entier
	//				- 
	// Sortie :		- trie : booléen
	public static bool VerifierTableauTrie(int[] tab)
	{
		bool trie = true;	// par défaut
		// parcours du tableau seulement si plus d'une case (sinon il est forcément trié)
		if (tab.Length > 1)
		{
			for (int i = 1 ; i < tab.Length && trie == true; i++)
			{
				if (tab[i] < tab[i-1])
				{
					trie = false;
				}
			}
		}
		return trie;
	}

	// Procédure principale
	public static void Main()
	{
		// définir deux tableau 1 trié et 1 non trié, appeler la fonction de test sur chacun et afficher les deux résultats

		int[] tabTrie = new int[10]{1,2,3,4,5,6,7,8,9,10};
		AfficherChaine("Avec un tableau trié :\n");
		AfficherTableauEntier1D(tabTrie);
		AfficherChaine($"Le tableau est trié ? {VerifierTableauTrie(tabTrie)}\n");

		int[] tabNonTrie = new int[10]{1,2,3,4,6,5,7,8,9,10};
		AfficherChaine("Avec un tableau trié :\n");
		AfficherTableauEntier1D(tabNonTrie);
		AfficherChaine($"Le tableau est trié ? {VerifierTableauTrie(tabNonTrie)}\n");
	}
}