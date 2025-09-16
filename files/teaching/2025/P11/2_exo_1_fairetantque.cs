// Auteur : Romain PERRIN

using System;

class Exercice1FaireTantQue
{
	public static void Main()
	{
		// constantes
		const int ENTIER_MIN = 7;
		const int ENTIER_MAX = 77;
		
		// variable
		int i;

		// affichage des entiers de 7 à 77
		i = ENTIER_MIN;
		do
		{
			Console.WriteLine(i);
			i = i + 1;
		}
		while (i <= ENTIER_MAX);
	}
}
