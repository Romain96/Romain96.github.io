// Auteur : Romain PERRIN

using System;

class Exercice7
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
	
	// Fonction : ProbaGagnerOrdre
	// Entrée :	- n : entier
	//				- p : entier
	// Type de sortie : entier
	public static int ProbaGagnerOrdre(int n, int p)
	{
		int proba = Factorielle(n) / Factorielle(n - p);
		return proba;
	}
	
	// Fonction : ProbaGagnerDesordre
	// Entrée :	- n : entier
	//				- p : entier
	// Type de sortie : entier
	public static int ProbaGagnerDesordre(int n, int p)
	{
		int proba = Factorielle(n) / (Factorielle(p) * Factorielle(n - p));
		return proba;
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir le nombre de chevaux partants : ");
		int p = SaisirEntier("Saisir le nombre de chevaux sur le podium : ");
		int ordre = ProbaGagnerOrdre(n, p);
		int desordre = ProbaGagnerDesordre(n, p);
		Console.WriteLine($"Pour {n} chevaux partants et {p} chevaux sur le podium :");
		Console.WriteLine($"\tLa probabilité de gagner dans l'ordre est de une sur {ordre}");
		Console.WriteLine($"\tLa probabilité de gagner dans le désordre est de une sur {desordre}");
	}
}
