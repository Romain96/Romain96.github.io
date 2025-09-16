// Auteur : Romain PERRIN

using System;

class Exercice10
{
	public static void Main()
	{
		// constantes
		const int BORNE_MIN = 2;
		const int BORNE_MAX = 1000;
		const int NB_ARMSTRONG = 4;	// il y 4 nombres à trouver entre BORNE_MIN et BORNE_MAX
		// variables
		int centaines, dizaines, unites;	// chiffre des centaines, dizaines et unités respectivement
		int trouves = 0;	// nombre de nombres d'Armstrong trouvés
		int temp;

		// boucle de recherche entre RECHERCHE_MIN et RECHERCHE_MAX
		for (int n = BORNE_MIN; n < BORNE_MAX && trouves < NB_ARMSTRONG; n++)
		{
			// décomposition en centaines, dizaines et unités
			centaines = n / 100;
			temp = n % 100;	// reste de la division de n par 100
			dizaines = temp / 10;
			unites = temp % 10;

			if (centaines * centaines * centaines + dizaines * dizaines * dizaines + unites * unites * unites == n)
			{
				Console.WriteLine($"{n} est un nombre d'Armstrong car {n} = {centaines}^3 + {dizaines}^3 + {unites}^3");
				trouves = trouves + 1;
			}
		}

	}
}
