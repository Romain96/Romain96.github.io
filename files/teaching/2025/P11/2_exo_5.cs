// Auteur : Romain PERRIN

using System;

class Exercice5
{
	public static void Main()
	{
		// constantes
		const int FACTEUR_MIN = 0;
		const int FACTEUR_MAX = 10;
		// variables
		int n;	// nombre saisi par l'utilisateur : table de multiplication à afficher
		
		// saisie de n
		Console.Write("Saisir un nombre n : ");
		n = int.Parse(Console.ReadLine());

		// affichage de la table de n de 0 à 10
		for (int i = FACTEUR_MIN; i <= FACTEUR_MAX; i++)
		{
			Console.WriteLine($"{i} x {n} = {i * n}");
		}
	}
}
