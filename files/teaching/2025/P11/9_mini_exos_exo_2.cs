// Auteur : Romain PERRIN

using System;

class Exercice2
{
	// Fonction : Comparer
	// Entrée :	- a : entier
	//			- b : entier
	// Sortie :	entier (-1, 0 ou 1)
	public static int Comparer(int a, int b)
	{
		Console.WriteLine(a + "\t" + b);
		if (a < b)
		{
			return -1;
		}
		if (a > b)
		{
			return 1;
		}
		return 0;
	}
	
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Sortie :	entier
	public static int SaisirEntier(string texte)
	{
		string saisie;
		do
		{
			Console.Write(texte);
			saisie = Console.ReadLine();
		}
		while (saisie.Length < 1);
		
		return int.Parse(saisie);
	}
	
	public static void Main()
	{
		int a, b;
		
		// saisir deux entiers
		a = SaisirEntier("Saisir une valeur pour a : ");
		b = SaisirEntier("Saisir une valeur pour b : ");
		
		// comparer et afficher
		Console.WriteLine($"Comparer({a}, {b}) = {Comparer(a, b)}");
	}
}
