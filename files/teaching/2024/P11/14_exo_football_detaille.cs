// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

public class FootballDetaillee
{
	// Fonction : ToString1
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	// Local :		- kvp : couple de clef, valeur de stats
	// Sortie :		chaine : chaîne de caractères
	public static string ToString2(Dictionary<string, List<int>> stats)
	{
		string chaine = "";
		foreach (KeyValuePair<string, List<int>> kvp in stats)
		{
			chaine += $"{kvp.Key}".PadRight(10, ' ');
			foreach (int buts in kvp.Value)
			{
				if (buts == -1)
				{
					chaine += "absent(e)".PadRight(15, ' ');
				}
				else if (buts == 0)
				{
					chaine += "aucun but".PadRight(15, ' ');
				}
				else if (buts == 1)
				{
					chaine += "1 but".PadRight(15, ' ');
				}
				else
				{
					chaine += $"{buts} buts".PadRight(15, ' ');
				}
			}
			chaine += "\n";
		}
		return chaine;
	}

	// Fonction : CalculNombreButsTotal2
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	// Local :		- kvp : couple de clef, valeur de stats
	// Sortie :		total : entier
	public static int CalculNombreButsTotal2(Dictionary<string, List<int>> stats)
	{
		int total = 0;
		foreach (KeyValuePair<string, List<int>> kvp in stats)
		{
			foreach (int buts in kvp.Value)
			{
				if (buts >= 0)
				{
					total += buts;
				}
			}
		}
		return total;
	}

	// Fonction : CalculMeilleurJoueur
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	// Local :		- buts, butsMax : entier
	// Sortie :		- meilleur : chaîne de caractères
	public static string CalculMeilleurJoueur(Dictionary<string, List<int>> stats)
	{
		string meilleur = "";
		int butsMax = 0;
		foreach (KeyValuePair<string, List<int>> kvp in stats)
		{
			// calcul de la somme des buts du joueur courant
			int buts = 0;
			foreach (int butsMatch in kvp.Value)
			{
				if (butsMatch >= 0)
				{
					buts += butsMatch;
				}
			}
			if (buts > butsMax)
			{
				meilleur = kvp.Key;
				butsMax = buts;
			}
		}
		return meilleur;
	}

	// Fonction : CalculJoueursAbsents
	// Entrée :		- stats : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	// Local :		- nbAbsences : entier
	// Sortie :		- absents : liste de chaîne de caractères
	public static List<string> CalculJoueursAbsents(Dictionary<string, List<int>> stats)
	{
		List<string> absents = new List<string>();
		foreach (KeyValuePair<string, List<int>> kvp in stats)
		{
			// joueur absent = absent à tous les matchs
			int nbAbsences = 0;
			foreach (int butsMatch in kvp.Value)
			{
				if (butsMatch == -1)
				{
					nbAbsences++;
				}
			}
			// autant d'absences que de matchs disputés en tout
			if (nbAbsences == kvp.Value.Count)
			{
				absents.Add(kvp.Key);
			}
		}
		return absents;
	}

	public static void Main()
	{
		// dictionnaire des joueurs : clef = nom, valeur = liste des nombre de buts marqués (-1 = absent, 0 = pas de but marqué)
		Dictionary<string, List<int>> joueurs = new Dictionary<string, List<int>>();

		// Ajout des données
		joueurs.TryAdd("Lise", new List<int> {2, 8, -1, 0});
		joueurs.TryAdd("Fab", new List<int> {18, -1, -1, -1});
		joueurs.TryAdd("Tom", new List<int> {2, 2, 0, 0});
		joueurs.TryAdd("Léa", new List<int> {-1, -1, -1, -1});
		joueurs.TryAdd("Sam", new List<int> {-1, -1, -1, -1});

		Console.Write(ToString2(joueurs));

		Console.WriteLine($"Un nombre total de {CalculNombreButsTotal2(joueurs)} buts ont été marqué.");

		Console.WriteLine($"Le meilleur buteur est {CalculMeilleurJoueur(joueurs)}.");

		Console.Write($"Joueurs absents : ");
		foreach (string absent in CalculJoueursAbsents(joueurs))
		{
			Console.Write($"{absent}".PadRight(15, ' '));
		}
		Console.Write("\n");
	}
}