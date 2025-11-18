// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice4
{
	// Fonction : EstBissextile
	// Entrée :	- annee : entier
	// Sortie :	booléen
	public static bool EstBissextile(int annee)
	{
		if ((annee % 4 == 0 && annee % 100 != 0) || (annee % 400 == 0))
		{
			return true;
		}
		return false;
	}

	// Fonction : GenererDicoAnnee
	// Entrée :	- annee : entier
	// Sortie :	Dictionnaire<chaîne de caractères, entier>
	public static Dictionary<string, int> GenererDicoAnnee(int annee)
	{
		Dictionary<string, int> cal = new Dictionary<string, int>();
		cal.Add("Janvier", 31);
		if (EstBissextile(annee))
		{
			cal.Add("Février", 29);
		}
		else
		{
			cal.Add("Février", 28);
		}
		cal.Add("Mars", 31);
		cal.Add("Avril", 30);
		cal.Add("Mai", 31);
		cal.Add("Juin", 30);
		cal.Add("Juillet", 31);
		cal.Add("Août", 31);
		cal.Add("Septembre", 30);
		cal.Add("Octobre", 31);
		cal.Add("Novembre", 30);
		cal.Add("Décembre", 31);
		return cal;
	}

	// Procédure : AfficherDicoAnnee
	// Entrée :	- dico : Dictionnaire<chaîne de caractères, entier>
	// 		- annee : entier
	// Sortie :	void
	public static void AfficherDicoAnnee(Dictionary<string, int> dico, int annee)
	{
		int total = 0;
		Console.WriteLine($"Année : {annee}");
		foreach (KeyValuePair<string, int> kvp in dico)
		{
			Console.WriteLine("\t" + $"{kvp.Key}".PadRight(10) + " : " + $"{kvp.Value} jours");
			total += kvp.Value;
		}
		Console.WriteLine($"Total : {total} jours");
	}

	// structure : Joueur
	public struct Joueur
	{
		public string _nom;
		public string _prenom;

		// Constructeur
		public Joueur(string nom, string prenom)
		{
			_nom = nom;
			_prenom = prenom;
		}

		// Affichage
		public override string ToString()
		{
			return "Joueur { nom = " + _nom + ", prénom = " + _prenom + " }";
		}
	};

	// Procédure : AfficherJoueurs
	// Entrée :	- joueurs : Dictionnaire<entier, structure Joueur>
	// Sortie :	void
	public static void AfficherJoueurs(Dictionary<int, Joueur> joueurs)
	{
		foreach (KeyValuePair<int, Joueur> kvp in joueurs)
		{
			Console.WriteLine($"Joueur n°{kvp.Key} : {kvp.Value._prenom} {kvp.Value._nom}");
		}
	}

	// Procédure : AfficherScores
	// Entrée :	scores : Dictionnaire<structure Joueur, entier>
	// Sortie :	void
	public static void AfficherScores(Dictionary<Joueur, int> scores)
	{
		Joueur gagnant = new List<Joueur>(scores.Keys)[0];
		int scoreGagnant = 0;

		foreach (KeyValuePair<Joueur, int> kvp in scores)
		{
			Console.WriteLine($"Joueur : {kvp.Key._prenom} {kvp.Key._nom}, score = {kvp.Value}");
			if (kvp.Value > scoreGagnant)
			{
				gagnant = kvp.Key;
				scoreGagnant = kvp.Value;
			}
		}
		Console.WriteLine($"Gagnant(e) : {gagnant._prenom} {gagnant._nom}");
	}

	public static void Main()
	{
		string saisie;
		int n;

		do
		{
			Console.Write("Saisir une année : ");
			saisie = Console.ReadLine();
		}
		while (saisie.Length < 1);
		n = int.Parse(saisie);

		Dictionary<string, int> calendrier = GenererDicoAnnee(n);
		AfficherDicoAnnee(calendrier, n);

		Joueur j1 = new Joueur("EINSTEIN", "Albert");
		Joueur j2 = new Joueur("TURING", "Alan");
		Joueur j3 = new Joueur("LOVELACE", "Ada");
		Dictionary<int, Joueur> lesJoueurs = new Dictionary<int, Joueur>();
		lesJoueurs.Add(55956, j1);
		lesJoueurs.Add(56871, j2);
		lesJoueurs.Add(57213, j3);
		AfficherJoueurs(lesJoueurs);

		Dictionary<Joueur, int> lesScores = new Dictionary<Joueur, int>();
		lesScores.Add(j1, 323);
		lesScores.Add(j2, 188);
		lesScores.Add(j3, 413);
		AfficherScores(lesScores);
	}
}
