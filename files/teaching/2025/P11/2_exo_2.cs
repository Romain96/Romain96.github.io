// Auteur : Romain PERRIN

using System;

class Exercice2
{
	public static void Main()
	{
		// constantes
		const int ENTIER_MAX = 7;
		const int ENTIER_MIN = 3;
		
		// variables
		int i, res;

		res = 6;

		for (i = ENTIER_MAX; i >= ENTIER_MIN; i--)
		{
			res = res + 3;
		}

		Console.WriteLine(res);
	}
}
