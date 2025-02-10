using System;

class RechercheMaximumDansTableauEntier1D
{
	// Principe : initialiser le maximum à la valeur de la première case puis parcourir les cases restantes
	// tout en maintenant à jour le maximum entre la variable maximum et la valeur de la case courante.
	public static void Main()
	{
		// variables
		const int taille = 10;
		int[] tab = new int[taille] {4, 3, 1, 12, 0, 7, 24, 0, 2, 5};
		int maximum = tab[0];	// entier à rechercher dans le tableau

		// parcours des cases du tableau et maintenir à jour le maximum
		for (int i = 1; i < taille; i++)
		{
			if (tab[i] > maximum)
			{
				maximum = tab[i];
			}
		}

		// Affichage
		Console.WriteLine($"Le nombre {maximum} est le maximum dans le tableau.");
	}
}
