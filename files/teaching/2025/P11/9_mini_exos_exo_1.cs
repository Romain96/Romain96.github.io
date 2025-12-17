// Auteur : Romain PERRIN

using System;

class Exercice1
{
	// Procédure : EstPair
	// Entrée :	- n : entier
	// Sortie :	void
	public static void EstPair(int n)
	{
		if (n % 2 == 0)
		{
			Console.WriteLine($"l'entier {n} est pair.");
		}
		else
		{
			Console.WriteLine($"l'entier {n} est impair.");
		}
	}
	
	public static void Main()
	{
		int n;
		string saisie;
		
		// saisir un entier
		do
		{
			Console.Write("Saisir en entier : ");
			saisie = Console.ReadLine();
		}
		while (saisie.Length < 1);
		
		// conversion
		n = int.Parse(saisie);
		EstPair(n);
	}
}
