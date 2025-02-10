using System;

class CalculerMoyenneTableauEntier1D
{
	public static void Main()
	{
		// variables
		const int taille = 10;
		int[] tab = new int[taille] {4, 3, 1, 12, 0, 7, 24, 0, 2, 5};
		double moyenne = 0.0;

		// parcourir les 10 cases du tableau, sommer les valeurs dans moyenne puis diviser moyenne par 10
		for (int i = 0; i < taille; i++)
		{
			moyenne += tab[i];
		}

		// calcul de la moyenne
		moyenne = moyenne / taille;
		
		// Affichage
		Console.WriteLine($"La moyenne de T est {moyenne}.");
	}
}
