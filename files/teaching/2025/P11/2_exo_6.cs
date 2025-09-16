// Auteur : Romain PERRIN

using System;

class Exercice6
{
	public static void Main()
	{
		// constantes
		const int NB_ENTIERS = 10;
		// variables
		int plusPetitEntier, entierCourant;

		// saisie de la première valeur
		Console.Write("Saisir le 1er entier : ");
		plusPetitEntier = int.Parse(Console.ReadLine());	// par défaut c'est le plus petit (car le seul)

		// saisie de 9 valeurs consécutivement
		for (int i = 1; i < NB_ENTIERS; i++)
		{
			// saisie d'une valeur entière (entierCourant)
			Console.Write($"Saisir le {i + 1}ème entier : ");
			entierCourant = int.Parse(Console.ReadLine());

			// conserver le plus petit entre entierCourant et plusPetitEntier
			if (entierCourant < plusPetitEntier)
			{
				plusPetitEntier = entierCourant;
			}
		}

		// afficher le plus petit entier
		Console.WriteLine($"Le plus petit des {NB_ENTIERS} entiers est : {plusPetitEntier}");
	}
}
