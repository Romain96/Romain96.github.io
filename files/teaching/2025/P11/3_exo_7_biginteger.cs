// Auteur : Romain PERRIN

using System;
using System.Numerics;	// pour compiler : mcs exo_7_biginteger.cs -r:System.Numerics.dll

class Exercice7BigInteger
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Fonction : Factorielle
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
	
	// Fonction : ProbaGagnerOrdre
	// Entrée :	- n : entier
	//				- p : entier
	// Type de sortie : entier
	public static BigInteger ProbaGagnerOrdre(int n, int p)
	{
		BigInteger proba = Factorielle(n) / Factorielle(n - p);
		return proba;
	}
	
	// Fonction : ProbaGagnerDesordre
	// Entrée :	- n : entier
	//				- p : entier
	// Type de sortie : entier
	public static BigInteger ProbaGagnerDesordre(int n, int p)
	{
		BigInteger proba = Factorielle(n) / (Factorielle(p) * Factorielle(n - p));
		return proba;
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir le nombre de chevaux partants : ");
		int p = SaisirEntier("Saisir le nombre de chevaux sur le podium : ");
		BigInteger ordre = ProbaGagnerOrdre(n, p);
		BigInteger desordre = ProbaGagnerDesordre(n, p);
		Console.WriteLine($"Pour {n} chevaux partants et {p} chevaux sur le podium :");
		Console.WriteLine($"\tLa probabilité de gagner dans l'ordre est de une sur {ordre}");
		Console.WriteLine($"\tLa probabilité de gagner dans le désordre est de une sur {desordre}");
	}
}
