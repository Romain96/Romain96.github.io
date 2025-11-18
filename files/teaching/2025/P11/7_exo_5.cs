// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice5
{
	// Fonction : CalculVols
	// Entrée : 	- liaisons : tableau 2D d'entiers
	// Sortie :	entier
	public static int CalculVols(int[,] liaisons)
	{
		int total = 0;
		for (int i = 0; i < liaisons.GetLength(0); i++)
		{
			for (int j = 0; j < liaisons.GetLength(1); j++)
			{
				total += liaisons[i, j];
			}
		}
		return total;
	}

	// Fonction : RecapTotal
	// Entrée :	- pilotes : liste de chaînes de caractères
	// 		- liaisons : tableau 2D d'entiers
	// Sortie :	Dictionnaire<chaîne de caractères, entier>
	public static Dictionary<string, int> RecapTotal(List<string> pilotes, int[,] liaisons)
	{
		Dictionary<string, int> recap = new Dictionary<string, int>();
		for (int indicePilote = 0; indicePilote < pilotes.Count; indicePilote++)
		{
			int totalPilote = 0;
			for (int indiceVol = 0; indiceVol < liaisons.GetLength(1); indiceVol++)
			{
				totalPilote += liaisons[indicePilote, indiceVol];
			}
			recap.Add(pilotes[indicePilote], totalPilote);
		}
		return recap;
	}

	// Procédure : AfficherDicoRecap
	// Entrée :	- recap : Dictionnaire<chaîne de caractères, entier>
	// Sortie :	void
	public static void AfficherDicoRecap(Dictionary<string, int> recap)
	{
		foreach (KeyValuePair<string, int> kvp in recap)
		{
			Console.WriteLine($"<{kvp.Key},{kvp.Value}>");
		}
	}

	// Fonction : VilleDetails
	// Entrée :	- destinations : liste de chaînes de caractères
	// 		- pilotes : liste de chaînes de caractères
	// 		- liaisons : tableau 2D d'entiers
	// Sortie :	Dictionnaire<chaîne de caractères, liste de chaînes de caractères>
	public static Dictionary<string, List<string>> VilleDetails(List<string> pilotes, List<string> destinations, int[,] liaisons)
	{
		Dictionary<string, List<string>> details = new Dictionary<string, List<string>>();
		for (int indiceVille = 0; indiceVille < destinations.Count; indiceVille++)
		{
			List<string> pilotesVille = new List<string>();
			for (int indicePilote = 0; indicePilote < pilotes.Count; indicePilote++)
			{
				if (liaisons[indicePilote, indiceVille] > 0)
				{
					pilotesVille.Add(pilotes[indicePilote]);
				}
			}
			details.Add(destinations[indiceVille], pilotesVille);
		}
		return details;
	}

	// Procédure : AfficherDicoVilles
	// Entrée :	- villes : Dictionnaire<chaîne de caractères, liste de chaînes de caractères>
	// Sortie : 	void
	public static void AfficherDicoVilles(Dictionary<string, List<string>> villes)
	{
		foreach (KeyValuePair<string, List<string>> kvp in villes)
		{
			Console.Write($"<{kvp.Key},<");
			foreach (string pilote in kvp.Value)
			{
				Console.Write($"{pilote},");
			}
			Console.WriteLine("\b \b>>");
		}
	}

	public static void Main()
	{
		List<string> destinations = new List<string>() {"Monte-Carlo", "Paris", "Rennes"};
		List<string> pilotes = new List<string>() {"Dany", "Laurent", "Emilie", "Alex"};
		int[,] liaisons = new int[4, 3] {{5, 10, 3}, {2, 14, 5}, {4, 7, 6}, {8, 0, 12}};
	
		Console.WriteLine($"Nombre total de vols : {CalculVols(liaisons)}");

		Dictionary<string, int> recap = RecapTotal(pilotes, liaisons);
		AfficherDicoRecap(recap);

		Dictionary<string, List<string>> villes = VilleDetails(pilotes, destinations, liaisons);
		AfficherDicoVilles(villes);
	}
}
