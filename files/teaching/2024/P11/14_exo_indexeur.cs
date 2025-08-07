// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Indexeur
{
	// Fonction : SeparerMots
	// Entrée :		- chaine : chaîne de caractères
	// Local :
	// Sortie :		- mots : liste de chaînes de caractères
	public static List<string> SeparerMots(string chaine)
	{
		List<string> mots = new List<string>();
		// parcours de la chaine
		int indice = 0;
		string mot = "";
		while (indice < chaine.Length)
		{
			mot = "";
			// recherche de la première lettre ou du premier chiffre (début d'un mot)
			while (indice < chaine.Length && (!Char.IsLetterOrDigit(chaine[indice]) && chaine[indice] != '\'' && chaine[indice] != '-'))
			{
				indice++;
			}
			// recherche de la fin d'un mot
			while (indice < chaine.Length && (Char.IsLetterOrDigit(chaine[indice]) || chaine[indice] == '\'' || chaine[indice] == '-'))
			{
				mot += chaine[indice];
				indice++;
			}
			// ajout du mot dans la liste
			else
			{
				mots.Add(mot);
			}
		}
		return mots;
	}

	// Fonction : Indexer
	// Entrée :		- chemin : chaîne de caractères
	// Local :		-
	// Sortie :		- dico : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	public static Dictionary<string, List<int>> Indexer(string chemin)
	{
		// création du dictionnaire des mots
		Dictionary<string, List<int>> dico = new Dictionary<string, List<int>>();
		// ouverture du fichier (le chemin existe, cf précondition)
		FileStream fs = new FileStream(chemin, FileMode.Open);
		StreamReader reader = new StreamReader(fs);
		int numLigne = 1;
		string ligne = "";
		// lecture ligne par ligne
		while ((ligne = reader.ReadLine()) != null)
		{
			// lecture mot par mot (un mot = une série de lettre ou chiffres)
			List<string> mots = SeparerMots(ligne);
			foreach (string mot in mots)
			{
				if (!mot.Equals(""))
				{
					// si le mot n'existe pas dans le dictionnaire, on l'ajoute et un crée une liste contenant le numéro de la ligne courante
					if (!dico.ContainsKey(mot))
					{
						List<int> occurrences = new List<int> ();
						occurrences.Add(numLigne);
						dico.TryAdd(mot, occurrences);
					}
					// sinon on ajoute simplement le numéro de la ligne courante
					{
						dico[mot].Add(numLigne);
					}
				}
			}
			numLigne++;
		}
		return dico;
	}

	// Procédure : AfficherIndexeur
	// Entrée :		- indexeur : dictionnaire (clef : chaîne de caractères, valeur : liste d'entiers)
	// Local :
	// Sortie :		void
	public static void AfficherIndexeur(Dictionary<string, List<int>> indexeur)
	{
		foreach (KeyValuePair<string, List<int>> kvp in indexeur)
		{
			Console.Write($"Mot : {kvp.Key}, occurrences : {{ ");
			foreach (int ligne in kvp.Value)
			{
				Console.Write($"{ligne} ");
			}
			Console.Write("}\n");
		}
	}

	public static void Main()
	{
		string chemin = "";
		while (!File.Exists(chemin))
		{
			Console.Write("Entrer un nom de fichier à traiter : ");
			chemin = Console.ReadLine();
		}

		Dictionary<string, List<int>> indexeur = Indexer(chemin);
		AfficherIndexeur(indexeur);
	}
}
