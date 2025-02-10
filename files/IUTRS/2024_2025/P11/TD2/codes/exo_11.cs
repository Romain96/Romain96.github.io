// Auteur : Romain PERRIN

using System;

class AfficherFactorielle
{
	// Principe : Parcourir les nombres de l'entier saisi (> 0) à 2 et maintenir à jour le produit des nombre précédent par l'itérateur
	public static void Main()
	{
		// variables
		int nombre = 0;	// nombre saisi par l'utilisateur
		int factorielle = 1;	// initialisation de la factorielle

		// saisie du nombre entier
		Console.Write("Saisissez un entier (>= 0): ");
		nombre = int.Parse(Console.ReadLine());

		// vérification de la validité du nombre saisi
		if (nombre < 0)
		{
			Console.WriteLine($"ERREUR ! Seul un entier positif est accepté (vous avez saisi {nombre}).");
		}
		else
		{
			// calcul de la factorielle 1 * 2 * ... * n-1 * n
			for (int i = 2; i <= nombre; i++)
			{
				factorielle = factorielle * i;
			}

			// affichage de la factorielle
			Console.WriteLine($"La factorielle de {nombre} est {nombre}! = {factorielle}.");
		}
	}
}
