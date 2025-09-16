// Auteur : Romain PERRIN

using System;

class Exercice1TantQue
{
	public static void Main()
	{
		// constantes
		const int ENTIER_MIN = 7;
		const int ENTIER_MAX = 77;
		
		// variable
		int i;

		// affichage des entiers de 7 à 77
		i = ENTIER_MIN
		while (i <= ENTIER_MAX)
		{
			Console.WriteLine(i);
			i = i + 1;
		}
	}
}
