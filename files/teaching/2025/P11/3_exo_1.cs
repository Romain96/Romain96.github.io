// Auteur : Romain PERRIN

using System;

class Exercice1
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Procédure : AfficherHeure
	// Entrée :	- temps : entier
	// Type de sortie : void
	public static void AfficherHeure(int temps)
	{
		int heures = temps / 60;
		int minutes = temps % 60;
		Console.WriteLine($"{heures:D2}:{minutes:D2}");
	}
	
	public static void Main()
	{
		int n = SaisirEntier("Saisir un nombre de minutes : ");
		AfficherHeure(n);
	}
}
