// Auteur : Romain PERRIN

using System;

class Exercice3
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Fonction : HeureVersMin
	// Entrée :	- heures : entier
	//				- minutes : entier
	// Type de sortie : entier
	public static int HeureVersMin(int heures, int minutes)
	{
		if (heures < 0)
		{
			return -1;	// erreur sur les heures
		}
		if (minutes > 59)
		{
			return -1;	// erreur sur les minutes
		}
		int temps = heures * 60 + minutes;
		return temps;
	}
	
	public static void Main()
	{
		int heures = SaisirEntier("Saisir un nombre d'heures : ");
		int minutes = SaisirEntier("Saisir un nombre de minutes : ");
		int temps = HeureVersMin(heures, minutes);
		if (temps == -1)
		{
			Console.WriteLine($"{heures},{minutes} n'est pas valide !");
		}
		else
		{
			Console.WriteLine($"{heures},{minutes} = {temps} minutes");
		}
	}
}
