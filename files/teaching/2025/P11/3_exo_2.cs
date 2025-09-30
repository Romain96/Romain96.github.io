// Auteur : Romain PERRIN

using System;

class Exercice2
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Procédure : AfficherTableMult
	// Entrée :	- n : entier
	// Type de sortie : void
	public static void AfficherTableMult(int n)
	{
		for (int i = 0; i <= 10; i++)
		{
			Console.WriteLine($"{i} x {n} = {i*n}");
		}
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir un nombre : ");
		AfficherTableMult(n);
	}
}
