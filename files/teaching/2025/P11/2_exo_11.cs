// Auteur : Romain PERRIN

using System;

class Exercice11
{
	public static void Main()
	{
		// constantes
		const char STOP = '*';	// caractère utilisé pour stopper la saisie
		// variables
		char c;	// caractère saisi par l'utilisateur
		int frequenceA = 0;
		int nbCaracteres = 0;	// nombre de caractères saisis
		double tauxA = 0;

		// boucle de saisie
		do
		{
			Console.Write("Saisir une lettre : ");
			c = Console.ReadLine()[0];	// la chaîne doit contenir au moins un caractère !
			
			// si c'est un 'a' alors on compte +1
			if (c == 'a')
			{
				frequenceA += 1;
			}

			nbCaracteres += 1;
		}
		// on sort de la boucle si c'est le caractère STOP
		while (c != STOP);

		// on retire le dernier caractères du nombre (car c'est le caractère STOP)
		nbCaracteres -= 1;

		// le taux est le nombre d'occurrences divisé par le nombre total de caractères
		tauxA = (double) frequenceA / (double) nbCaracteres;

		// affichages
		Console.WriteLine($"La chaîne saisie contient {nbCaracteres} caractère(s).");
		Console.WriteLine($"Il y a {frequenceA} 'a' dans la chaîne.");
		Console.WriteLine($"Le taux de 'a' est alors de {tauxA}.");
	}
}
