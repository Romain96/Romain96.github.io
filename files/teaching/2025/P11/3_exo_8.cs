// Auteur : Romain PERRIN

using System;

class Exercice8
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Procédure : Permuter
	// Entrée :	- a : référence entier
	//				- b : référence entier
	// Type de sortie : void
	public static void Permuter(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}
	
	public static void Main()
	{
		int a = SaisirEntier("Saisir un nombre entier a : ");
		int b = SaisirEntier("Saisir un nombre entier b : ");
		Console.WriteLine($"Avant permutation : a = {a}, b = {b}");
		Permuter(ref a, ref b);
		Console.WriteLine($"Après permutation : a = {a}, b = {b}");
	}
}
