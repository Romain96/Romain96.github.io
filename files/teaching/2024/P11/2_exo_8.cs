// Auteur : Romain PERRIN

using System;

class ChercherNombresArmstrong
{
	// Principe : Parcourir les entiers de 100 à 999.
	// Pour chaque entier, extraire le chiffre des centaines, dizaines et unités.
	// vérifier que centaines^3 + dizaines^3 + unités^3 est égal à l'entier
	// si oui l'afficher, sinon ne rien faire.
	public static void Main()
	{
		// variables
		const int BORNE_INF = 100;
		const int BORNE_SUP = 999;
		int centaines = 0;	// chiffre des centaines
		int dizaines = 0;	// chiffre des dizaines
		int unites = 0;	// chiffre des unités
		int armstrong = 0;	// résultat de centaines^3 + dizaines^3 + unites^3

		// parcourir les entiers de debut à fin
		for (int nombre = BORNE_INF; nombre <= BORNE_SUP; nombre++)
		{
			centaines = nombre / 100;
			dizaines = (nombre / 10) % 10;
			unites = (nombre % 100) % 10;
			armstrong = centaines * centaines * centaines + dizaines * dizaines * dizaines + unites * unites * unites;

			if (armstrong == nombre)
			{
				Console.WriteLine($"{nombre} est un nombre d'Armstrong car {centaines}^3 + {dizaines}^3 + {unites}^3 = {armstrong}.");
			}
		}
	}
}
