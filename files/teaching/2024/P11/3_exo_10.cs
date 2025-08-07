using System;

class RechercheDichotomiqueTableauEntier1D
{
	public static void Main()
	{
		// variables
		const int taille = 9;
		int[] tab = new int[taille] {1, 3, 5, 8, 9, 14, 20, 28, 32};
		int debut = 0;
		int fin = taille - 1;
		int milieu = 0;
		bool trouve = false;
		int valeur = 0;
		int indice = -1;

		// saisie de la valeur à rechercher
		Console.Write("Entrez la valeur à rechercher : ");
		valeur = int.Parse(Console.ReadLine());

		// boucle de recherche
		while (trouve == false && fin - debut >= 0)
		{
			milieu = (debut + fin) / 2;
			if (valeur == tab[milieu])
			{
				indice = milieu;
				trouve = true;
			}
			else if (valeur < tab[milieu])
			{
				fin = milieu - 1;
			}
			else// valeur > ttab[milieu]
			{
				debut = milieu + 1;
			}
		}

		if (trouve)
		{
			Console.WriteLine($"La valeur {valeur} est présente à l'indice {indice}.");
		}
		else
		{
			Console.WriteLine($"La valeur {valeur} n'est pas présente (indice = {indice}).");
		}
	}
}
