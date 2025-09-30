// Auteur : Romain PERRIN

using System;

class Exercice5
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Fonction : EstPremier
	// Entrée :	- n : entier
	// Type de sortie : booléen
	public static bool EstPremier(int n)
	{
		for (int i = 2; i < n; i++)
		{
			if (n % i == 0)
			{
				return false;	// n ne doit être divisible que par 1 et n
			}
		}
		return true;
	}
	
	public static void Main()
	{
		int borneMin = SaisirEntier("Saisir la borne inférieure de recherche : ");
		int borneMax = SaisirEntier("Saisir la borne supérieure de recherche : ");
		for (int i = borneMin; i <= borneMax; i++)
		{
			if (EstPremier(i))
			{
				Console.WriteLine($"{i} est un nombre premier.");
			}
		}
	}
}
