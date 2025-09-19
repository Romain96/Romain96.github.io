// Auteur : Romain PERRIN

using System;

class Exercice17
{
	public static void Main()
	{
		// variable
		int n;
		double suiteHarmonique;

		// saisir n
		Console.WriteLine("Saisir un entier n : ");
		n = int.Parse(Console.ReadLine());

		// calcul de la suite harmmonique de rang n
		suiteHarmonique = 1.0;
		for (int i = 2; i <= n; i++)
		{
			suiteHarmonique = suiteHarmonique + (1.0 / (double) i);
		}

		Console.WriteLine($"La suite harmonique de rang {n} vaut : {suiteHarmonique}.");
	}
}
