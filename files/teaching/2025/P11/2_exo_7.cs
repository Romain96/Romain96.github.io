// Auteur : Romain PERRIN

using System;

class Exercice7
{
	public static void Main()
	{
		// constantes
		const int NB_ENTIERS = 10;
		// variables
		int entierCourant;
		int somme = 0;

		// saisie de 10 valeurs consécutivement
		for (int i = 0; i < NB_ENTIERS; i++)
		{
			// saisie d'une valeur entière (entierCourant)
			Console.Write($"Saisir le {i + 1}ème entier : ");
			entierCourant = int.Parse(Console.ReadLine());

			// mise à jour de la somme partielle
			somme = somme + entierCourant;
		}

		// afficher le plus petit entier
		Console.WriteLine($"La somme des {NB_ENTIERS} entiers est égale à : {somme}");
	}
}
