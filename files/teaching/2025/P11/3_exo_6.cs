// Auteur : Romain PERRIN

using System;

class Exercice6
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
	public static int Factorielle(int n)
	{
		if (n < 0)
		{
			return -1;	// erreur
		}
		int fact = 1;
		for (int i = 2; i <= n; i++)
		{
			fact = fact * i;
		}
		return fact;
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir un nombre entier positif : ");
		int nFact = Factorielle(n);
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
