// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

public class FootballSimple
{
	// Fonction : ToString1
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : entier)
	// Local :		/
	// Sortie :		chaine : chaîne de caractères
	public static string ToString1(Dictionary<string, int> stats)
	{
		string chaine = "";
		foreach (KeyValuePair<string, int> kvp in stats)
		{
			chaine += $"{kvp.Key} a marqué {kvp.Value} but(s)\n";
		}
		return chaine;
	}

	// Fonction : CalculNombreButsTotal1
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : entier)
	// Local :		/
	// Sortie :		total : entier
	public static int CalculNombreButsTotal1(Dictionary<string, int> stats)
	{
		int total = 0;
		foreach (KeyValuePair<string, int> kvp in stats)
		{
			total += kvp.Value;
		}
		return total;
	}

	// Procédure : Inverse
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : entier)
	//				- joueur1 : chaîne de caractères
	//				- joueur2 : chaîne de caractères
	// Local :		- tmp : entier
	// Sortie :		void
	public static void Inverse(Dictionary<string, int> stats, string joueur1, string joueur2)
	{
		if (!stats.ContainsKey(joueur1))
		{
			throw new ArgumentException($"Le joueur {joueur1} n'existe pas !");
		}
		else if (!stats.ContainsKey(joueur2))
		{
			throw new ArgumentException($"Le joueur {joueur2} n'existe pas !");
		}
		else
		{
			int tmp = stats[joueur1];
			// attention : [] remplace la valeur si la clef existe mais TryAdd lève une exception !
			stats[joueur1] = stats[joueur2];
			stats[joueur2] = tmp;
		}
	}

	public static void Main()
	{
		// dictionnaire des joueurs : clef = nom, valeur = nombre de buts marqués
		Dictionary<string, int> joueurs = new Dictionary<string, int>();

		// Ajout des données
		joueurs.TryAdd("Lise", 15);
		joueurs.TryAdd("Fab", 30);
		joueurs.TryAdd("Tom", 2);
		joueurs.TryAdd("Léa", 8);
		joueurs.TryAdd("Sam", 0);

		Console.Write(ToString1(joueurs));
		Console.WriteLine($"Un nombre total de {CalculNombreButsTotal1(joueurs)} buts ont été marqués.");

		Console.WriteLine("Échange des buts de Sam et Lise");
		Inverse(joueurs, "Sam", "Lise");
		Console.Write(ToString1(joueurs));
	}
}