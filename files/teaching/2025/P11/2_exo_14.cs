// Auteur : Romain PERRIN

using System;

class Exercice14
{
	public static void Main()
	{
		// constantes
		const float TARIF_NORMAL = 8.0f;
		const float TARIF_PREF_1 = 6.0f;
		const float TARIF_PREF_2 = 5.50f;
		const int LIMITE_1 = 5;
		const int LIMITE_2 = 10;

		// variables
		int nbPlaces, nbNormal, nbPref1, nbPref2;
		float prix;

		// saisir du nombre de places
		Console.Write("Saisir le nombre de places : ");
		nbPlaces = int.Parse(Console.ReadLine());

		// calcul du prix en fonction de nbPlaces
		nbNormal = 0;
		nbPref1 = 0;
		nbPref2 = 0;

		if (nbPlaces <= LIMITE_1)
		{
			nbNormal = nbPlaces;
		}
		else if (nbPlaces <= LIMITE_2)
		{
			nbNormal = LIMITE_1;
			nbPref1 = nbPlaces - LIMITE_1;
		}
		else
		{
			nbNormal = LIMITE_1;
			nbPref1 = LIMITE_2 - nbNormal;
			nbPref2 = nbPlaces - LIMITE_2;
		}
		prix = TARIF_NORMAL * nbNormal + TARIF_PREF_1 * nbPref1 + TARIF_PREF_2 * nbPref2;

		// affichage du résultat
		Console.WriteLine($"Nombre de places demandées : {nbPlaces}.");
		Console.WriteLine($"Nombre de places <= {LIMITE_1} ({TARIF_NORMAL} € l'unité) : {nbNormal}.");
		Console.WriteLine($"Nombre de places > {LIMITE_1} et <= {LIMITE_2} ({TARIF_PREF_1} € l'unité) : {nbPref1}.");
		Console.WriteLine($"Nombre de places > {LIMITE_2} ({TARIF_PREF_2} € l'unité) : {nbPref2}.");
		Console.WriteLine($"Prix total : {nbNormal} x {TARIF_NORMAL} + {nbPref1} x {TARIF_PREF_1} + {nbPref2} x {TARIF_PREF_2} = {prix} €.");
	}
}
