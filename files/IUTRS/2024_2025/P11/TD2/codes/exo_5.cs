// Auteur : Romain PERRIN

using System;

class AfficherPlusPetitDe10Entiers
{
	// Principe : Demander à l'utilisateur 10 entiers à la suite.
	// Maintenuir à jour le minimum sur les entiers déjà renseignés (initialisé au premier entier saisi)
	// Après la 10e saisie, afficher le minimum.
	public static void Main()
	{
		// variables
		int minimum = 0;	// minimum sur les entiers déjà saisis
		int nombre = 0;		// entier saisi pour l'itération courante

		// saisie du premier entier et initialisation du minimum
		Console.Write("Entrez un entier : ");
		minimum = int.Parse(Console.ReadLine());

		// saisie des 9 entiers suivants et mise à jour du minimum
		for (int i = 1; i <= 9; i++)
		{
			Console.Write("Entrez un entier : ");
			nombre = int.Parse(Console.ReadLine());

			if (nombre < minimum)
			{
				minimum = nombre;
			}
		}
		// affichage du minimum
		Console.WriteLine($"Le minimum est : {minimum}.");
	}
}
