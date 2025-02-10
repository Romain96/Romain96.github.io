using System;

class CompterNombreApparitionsEntierDansTableauEntier1D
{
	// Principe : demander un entier à l'utilisateur et parcourir les cases du tableau.
	// initialier un compteur et à chaque case contenant la valeur x, incrémenter ce compteur de 1.
	public static void Main()
	{
		// variables
		const int taille = 10;
		int[] tableau = new int[10] {4, 3, 1, 12, 0, 7, 24, 0, 2, 5};
		int nCible = -1;	// entier à rechercher dans le tableau
		int nApparitions = 0;	// nombre d'apparitions de x dans tableau
		
		// saisir l'entier x
		Console.Write("Saisissez un entier à rechercher dans le tableau : ");
		nCible = int.Parse(Console.ReadLine());

		// parcours des cases du tableau et recherche de x
		for (int i = 0; i < taille; i++)
		{
			if (tableau[i] == nCible)
			{
				nApparitions += 1;
			}
		}

		// Affichage
		Console.WriteLine($"Le nombre {nCible} apparait {nApparitions} fois dans le tableau.");
	}
}
