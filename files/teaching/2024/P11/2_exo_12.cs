// Auteur : Romain PERRIN

using System;

class AfficherNombrePremier
{
	// Principe : Parcourir les entiers de 2 au nombre saisi moins 1 et vérifier que celui-ci n'est divisible par aucun d'entre eux
	// c'est-à-dire que le modulo de la division de l'entier par l'itérateur ne donne jamais 0.
	public static void Main()
	{
		// variables
		int nombre = 0;	// nombre saisi par l'utilisateur
		bool estPremier = true;	// décide si le nombre est premier ou non

		// saisie du nombre entier
		Console.Write("Saisissez un entier : ");
		nombre = int.Parse(Console.ReadLine());

		// boucle de traitement
		for (int i = 2; i < nombre && estPremier; i++)
		{
			if (nombre % i == 0)
			{
				estPremier = false;
			}
		}

		// affichage du résultat
		if (estPremier)
		{
			Console.WriteLine($"Le nombre {nombre} est premier !");
		}
		else
		{
			Console.WriteLine($"Le nombre {nombre} n'est pas premier !");
		}
	}
}
