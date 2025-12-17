// Auteur : Romain PERRIN

using System;

class Exercice5
{
	// Procédure : AfficherPremiereLettreChaine
	// Entrée :	- chaines : tableau 1D de chaînes de caractères
	// Sortie :	void
	public static void AfficherPremiereLettreChaine(string[] chaines)
	{
		foreach (string chaine in chaines)
		{
			if (chaine.Length > 0)
			{
				Console.WriteLine("chaîne : '" + chaine + "', première lettre : '" + chaine[0] + "'");
			}
			else
			{
				Console.WriteLine("chaîne : '" + chaine + "', pas de première lettre :(");
			}
		}
	}
	
	
	public static void Main()
	{
		// créer un tableau de chaînes
		string[] chaines = new string[5] {"Hello world", "test", "Être ou ne pas être, telle est la question", "", "chaîne inutile"};
		
		// Afficher la première lettre de chaque chaine
		AfficherPremiereLettreChaine(chaines);
	}
}
