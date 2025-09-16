// Auteur : Romain PERRIN

using System;

class Exercice8
{
	public static void Main()
	{
		// variables
		int n, res;

		// saisie de n
		do
		{
			Console.Write("Saisir un entier n >= 0 : ");
			n = int.Parse(Console.ReadLine());
		}
		while (n < 0);
		res = 1;

		for (int i = 1; i <= n; i++)
		{
			res = res * i;
		}

		Console.WriteLine($"{n}! = {res}");
	}
}
