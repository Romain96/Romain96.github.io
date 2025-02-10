// Auteur : Romain PERRIN

using System;

class AfficherSommeDe10Entiers
{
	// Principe : Demander à l'utilisateur 10 entiers à la suite.
	// Maintenuir à jour la somme sur les entiers déjà renseignés (initialisé à 0)
	// Après la 10e saisie, afficher la somme.
	public static void Main()
	{
		// variables
		int somme = 0;	// somme sur les entiers déjà saisis
		int nombre = 0;	// entier saisi pour l'itération courante

		// saisie des 10 entiers suivants et mise à jour du minimum
		for (int i = 1; i <= 10; i++)
		{
			Console.Write("Entrez un entier : ");
			nombre = int.Parse(Console.ReadLine());
			somme += nombre;
		}
		// affichage de la somme
		Console.WriteLine($"La somme est : {somme}.");
	}
}
