// Auteur : Romain PERRIN

using System;
using System.Numerics;	// pour compiler : mcs exo_6_biginteger.cs -r:System.Numerics.dll

class Exercice6BigInteger
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Procédure : Factorielle
	// Entrée :	- n : entier
	// Type de sortie : entier
	public static BigInteger Factorielle(int n)
	{
		if (n < 0)
		{
			return -1;	// erreur
		}
		BigInteger fact = 1;
		for (BigInteger i = 2; i <= n; i++)
		{
			fact = fact * i;
		}
		return fact;
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir un nombre entier positif : ");
		BigInteger nFact = Factorielle(n);
		if (nFact == -1)
		{
			Console.WriteLine($"Erreur, {n} n'est pas un nombre valide !");
		}
		else
		{
			Console.WriteLine($"{n}! = {nFact}");
		}
	}
}
