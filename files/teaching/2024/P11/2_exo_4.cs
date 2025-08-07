// Auteur : Romain PERRIN

using System;

class AfficherTableDeMultiplication
{
	// Principe : demander le table à l'utilisateur puis parcourir les entiers de 0 à 10, 
	// calculer table*entier courant et afficher le résultant dans la boucle
	public static void Main()
	{
		// variables
		int table = 0;
		const int BORNE_INF = 0;
		const int BORNE_SUP = 10;

		// saisie de la table
		Console.Write("Entrez la table souhaitée : ");
		table = int.Parse(Console.ReadLine());

		// parcours de entiers de debut à fin (bornes incluses)
			for (int nombre = BORNE_INF; nombre <= BORNE_SUP; nombre++)
			{
				Console.WriteLine($"{nombre} x {table} = {nombre * table}");
			}
	}
}
