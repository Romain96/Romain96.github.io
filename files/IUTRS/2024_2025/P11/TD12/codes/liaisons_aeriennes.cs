// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

public class LiaisonsAeriennes
{
	// Afficher le tableau liaisons (version complète avec les noms des lignes et colonnes)
	// Procédure : AfficherLiaisons
	// Entrée :		- liaisons : tableau 2D d'entiers
	//				- pilotes : liste de chaînes de caractères
	//				- destinations : liste de chaînes de caractères
	// Local :
	// Sortie : 	void
	public static void AfficherLiaisons(int[,] liaisons, List<string> pilotes, List<string> destinations)
	{
		// affichage des entrées (noms des destinations)
		string entree = "Pilote";
		Console.WriteLine("".PadRight(80, '-'));
		Console.Write($"{entree.PadRight(15, ' ')}\t");
		foreach (string dest in destinations)
		{
			Console.Write($"{dest.PadRight(15, ' ')}\t");
		}
		Console.Write("\n");

		// affichage des lignes avec les noms de pilotes en premier
		for (int ligne = 0; ligne < pilotes.Count; ligne++)
		{
			Console.Write($"{pilotes[ligne].PadRight(15, ' ')}\t");
			for (int colonne = 0; colonne < liaisons.GetLength(1); colonne++)
			{
				Console.Write($"{liaisons[ligne, colonne].ToString().PadRight(15, ' ')}\t");
			}
			Console.Write("\n");
		}
	}

	// 2)
	// Fonction : CalculVols
	// Entrée :		- liaisons : tableau 2D d'entiers
	// Local :		/
	// Sortie :		- total : entier
	public static int CalculVols(int[,] liaisons)
	{
		int total = 0;
		for (int ligne = 0; ligne < liaisons.GetLength(0); ligne++)
		{
			for (int colonne = 0; colonne < liaisons.GetLength(1); colonne++)
			{
				total += liaisons[ligne, colonne];
			}
		}
		return total;
	}

	// Fonction : CalculVolsPilote
	// Entrée :		- liaisons : tableau 2D d'entiers
	//				- pilote : entier (indice du pilote)
	// Local :		/
	// Sortie :		- total : entier
	public static int CalculVolsPilote(int[,] liaisons, int pilote)
	{
		if (pilote < 0 || pilote >= liaisons.GetLength(0))
		{
			throw new ArgumentException($"L'indice de pilote {pilote} n'est pas valide, il doît être entre 0 et {liaisons.GetLength(0)} !");
		}
		int total = 0;
		for (int colonne = 0; colonne < liaisons.GetLength(1); colonne++)
		{
			total += liaisons[pilote, colonne];
		}
		return total;
	}

	// 3) et 4)
	// Fonction : RecapAnnuel
	// Entrée :		- pilotes : liste de chaînes de caractères
	//				- tableau 2D d'entiers (nombre de lignes = taille de la liste pilotes)
	// Local :		- indicePiloce : entier
	//				- pilote : chaîne de caractères
	//				- vols : entier
	// Sortie :		- recapitulatif : dictionnaire (clef : chaînes de caractères, valeurs : entier)
	public static Dictionary<string, int> RecapAnnuel(List<string> pilotes, int[,] liaisons)
	{
		// 3) création du dictionnaire
		Dictionary<string, int> recapitulatif = new Dictionary<string, int>();

		// 4) remplissage des valeurs pour chaque pilote (clef)
		for (int indicePilote = 0; indicePilote < pilotes.Count; indicePilote++)
		{
			string pilote = pilotes[indicePilote];
			int vols = CalculVolsPilote(liaisons, indicePilote);
			// ajout du couple de clef, valeur
			recapitulatif.TryAdd(pilote, vols);
		}
		return recapitulatif;
	}

	// 5)
	// Procédure : AfficherRecapitulatif
	// Entrée :		- recap : dictionnaire (clef : chaînes de caractères, valeur : entier)
	// Local :		- kvp : couple de clef-valeur du dictionnaire
	// Sortie :		void
	public static void AfficherRecapitulatif(Dictionary<string, int> recap)
	{
		Console.WriteLine("Dictionnaire recapitulatif :");
		foreach (KeyValuePair<string, int> kvp in recap)
		{
			Console.WriteLine($"Clef : {kvp.Key.PadRight(10, ' ')} valeur : {kvp.Value}");
		}
	}

	// 6) et 7)
	// Fonction : DestinationsPilotes
	// Entrée :		- pilotes : liste de chaînes de caractères
	//				- destinations : liste de chaînes de caractères
	//				- liaisons : tableau 2D d'entiers (nombre de colonnes = taille de la liste destinations)
	// Local :		- indiceDestination, indicePilote : entier
	//				- pilotesDestination : liste de chaînes de caractères
	//				- destination : chaîne de caractères
	// Sortie :		- destPil : dictionnaire (clef : chaîne de caractères, valeur : liste de chaînes de caractères)
	public static Dictionary<string, List<string>> DestinationsPilotes(List<string> pilotes, List<string> destinations, int[,] liaisons)
	{
		// 3) création du dictionnaire
		Dictionary<string, List<string>> destPil = new Dictionary<string, List<string>>();

		// 4) remplissage des valeurs pour chaque destination
		for (int indiceDestination = 0; indiceDestination < destinations.Count; indiceDestination++)
		{
			string destination = destinations[indiceDestination];
			// recherche des pilotes dont le nombre de vols vers la destination est supérieur à 0
			List<string> pilotesDestination = new List<string>();
			for (int indicePilote = 0; indicePilote < pilotes.Count; indicePilote++)
			{
				if (liaisons[indicePilote, indiceDestination] > 0)
				{
					pilotesDestination.Add(pilotes[indicePilote]);
				}
			}
			// ajout du couple de clef, valeur
			destPil.TryAdd(destination, pilotesDestination);
		}
		return destPil;
	}

	// 8)
	// Procédure : AfficherDestinationsPilotes
	// Entrée :		- destPil : dictionnaire (clef : chaînes de caractères, valeur : liste de chaînes de caractères)
	// Local :		- kvp : couple de clef-valeur du dictionnaire
	// Sortie :		void
	public static void AfficherDestinationsPilotes(Dictionary<string, List<string>> destPil)
	{
		Console.WriteLine("Dictionnaire destPil :");
		foreach (KeyValuePair<string, List<string>> kvp in destPil)
		{
			Console.Write($"Clef : {kvp.Key.PadRight(15, ' ')} valeur : {{ ");
			foreach (string destination in kvp.Value)
			{
				Console.Write($"{destination} ");
			}
			Console.WriteLine("}");
		}
	}

	// 9) BONUS

	// Procédure : AjouterVol
	// Entrée :		- liaisons : tableau 2D d'entiers (modifiable)
	//				- pilotes : liste de chaînes de caractères
	//				- destinations : liste de chaînes de caractères
	//				- pilote : chaîne de caractères
	//				- destination : chaîne de caractères
	// Local :		- indicePilote, indiceDestination : entier
	// Sortie :		void
	public static void AjouterVol(int[,] liaisons, List<string> pilotes, List<string> destinations, string pilote, string destination)
	{
		int indicePilote = pilotes.FindIndex(x => x.Equals(pilote));
		if (indicePilote == -1)
		{
			throw new ArgumentException($"Ajout impossible, le pilote {pilote} n'existe pas dans la liste des pilotes !");
		}
		int indiceDestination = destinations.FindIndex(x => x.Equals(destination));
		if (indiceDestination == -1)
		{
			throw new ArgumentException($"Ajout impossible, la destination {destination} n'existe pas dans la liste des destinations !");
		}
		// +1 dans la case correspondante
		if (indicePilote != 1 && indiceDestination != -1)
		{
			Console.WriteLine($"Ajout de {pilote} à la destination {destination}.");
			liaisons[indicePilote, indiceDestination] += 1;
		}
	}

	// Fonction : AjouterPilote
	// Entrée :		- liaisons : tableau 2D d'entiers
	//				- pilotes : liste de chaînes de caractères (modifiable)
	//				- pilote : chaîne de caractères
	// Local :		- ligne, colonne : entiers
	// Sortie :		- liaisonsEtendues : tableau 2D d'entiers
	public static int[,] AjouterPilote(int[,] liaisons, List<string> pilotes, string pilote)
	{
		// seulement si le pilote n'existe pas déjà
		if (pilotes.Contains(pilote))
		{
			throw new ArgumentException($"Impossible d'ajoute le pilote {pilote} (existe déjà) !");
		}
		else
		{
			// création d'un nouveau tableau, copie des valeurs existantes, laisser la dernière ligne vide
			int[,] liaisonsEtendues = new int[liaisons.GetLength(0) + 1, liaisons.GetLength(1)];
			for (int ligne = 0; ligne < liaisons.GetLength(0); ligne++)
			{
				for (int colonne = 0; colonne < liaisons.GetLength(1); colonne++)
				{
					liaisonsEtendues[ligne, colonne] = liaisons[ligne, colonne];
				}
			}
			// ajout du pilote
			pilotes.Add(pilote);
			return liaisonsEtendues;
		}
	}

	// Fonction : AjouterDestination
	// Entrée :		- liaisons : tableau 2D d'entiers
	//				- destinations : liste de chaînes de caractères (modifiable)
	//				- destination : chaîne de caractères
	// Local :		- ligne, colonne : entiers
	// Sortie :		- liaisonsEtendues : tableau 2D d'entiers
	public static int[,] AjouterDestination(int[,] liaisons, List<string> destinations, string destination)
	{
		// seulement si la destination n'existe pas déjà
		if (destinations.Contains(destination))
		{
			throw new ArgumentException($"Impossible d'ajoute la destination {destination} (existe déjà) !");
		}
		else
		{
			// création d'un nouveau tableau, copie des valeurs existantes, laisser la dernère colonne vide
			int[,] liaisonsEtendues = new int[liaisons.GetLength(0), liaisons.GetLength(1) + 1];
			for (int ligne = 0; ligne < liaisons.GetLength(0); ligne++)
			{
				for (int colonne = 0; colonne < liaisons.GetLength(1); colonne++)
				{
					liaisonsEtendues[ligne, colonne] = liaisons[ligne, colonne];
				}
			}
			// ajout de la destination
			destinations.Add(destination);
			return liaisonsEtendues;
		}
	}

	public static void Main()
	{
		// 1) variables utilisées
		List<string> destinations = new List<string> {"Monte-Carlo", "Paris", "Rennes"};
		List<string> pilotes = new List<string> {"Dany", "Laurent", "Émilie", "Alex"};
		int[,] liaisons = new int[4, 3] {
			{5, 10, 3}, 
			{2, 14, 5}, 
			{4, 7, 6}, 
			{8, 0, 12}
		};

		Console.WriteLine($"Nombre total de vols : {CalculVols(liaisons)}.");

		Dictionary<string, int> recap = RecapAnnuel(pilotes, liaisons);
		AfficherRecapitulatif(recap);

		Dictionary<string, List<string>> destPil = DestinationsPilotes(pilotes, destinations, liaisons);
		AfficherDestinationsPilotes(destPil);

		// ajouter Alex, Paris et Dany Paris
		AfficherLiaisons(liaisons, pilotes, destinations);
		AjouterVol(liaisons, pilotes, destinations, "Alex", "Paris");
		AfficherLiaisons(liaisons, pilotes, destinations);
		AjouterVol(liaisons, pilotes, destinations, "Dany", "Paris");
		AfficherLiaisons(liaisons, pilotes, destinations);

		// ajouter Charlène
		liaisons = AjouterPilote(liaisons, pilotes, "Charlène");
		AfficherLiaisons(liaisons, pilotes, destinations);

		// Ajouter Strasbourg
		liaisons = AjouterDestination(liaisons, destinations, "Strasbourg");
		AfficherLiaisons(liaisons, pilotes, destinations);
	}
}