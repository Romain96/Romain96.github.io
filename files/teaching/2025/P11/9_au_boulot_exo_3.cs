// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice3
{
	// Fonction : GenererListeAleatoire
	// Entrée :	- n : entier (nombre de réels à générer)
	// Sortie :	Liste<réel>
	public static List<double> GenererListeAleatoire(int n)
	{
		Random gen = new Random();
		List<double> liste = new List<double>();
		for (int i = 0; i < n; i++)
		{
			liste.Add(gen.NextDouble());
		}
		return liste;
	}
	
	// Procédure : CompterPourContre
	// Entrée :	- referendum : Liste<réel>
	//			- pour : référence sur un entier
	//			- contre : référence sur un entier
	// Sortie :	void
	public static void CompterPourContre(List<double> referendum, ref int pour, ref int contre)
	{
		pour = 0;
		contre = 0;
		foreach (double rep in referendum)
		{
			if (rep < 0.5)
			{
				contre++;
			}
			else 
			{
				pour++;
			}
		}
	}
	
	// structure Guerremanien
	public struct Guerremanien
	{
		public string _nom;
		public string _prenom;
		
		// Constructeur
		public Guerremanien(string nom, string prenom)
		{
			_nom = nom;
			_prenom = prenom;
		}
		
		// Affichage
		public override string ToString()
		{
			return "Guerremanien { nom : " + _nom + ", prénom : " + _prenom + " }";
		}
	};
	
	public static void Main()
	{
		List<string> questions = new List<string>() {
			"Interdire les pauses toilettes durant les heures de travail", 
			"Mettre en place un brouillage IA et une interdire l'utilisation des smartphones intelligents", 
			"Relancer les usines d’armement et de tanks"
		};
		List<Guerremanien> ennemis = new List<Guerremanien>();
		
		// pour chacune des questions du référendum (tant que négative)
		int i = 0;
		while (i < questions.Count)
		{
			string question = questions[i];
				
			// demander les infos à l'utilisateur (nom, prénom)
			string nom, prenom, reponse;
			do
			{
				Console.Write("> Nom : ");
				nom = Console.ReadLine();
			}
			while (nom.Length < 1);
			do
			{
				Console.Write("> Prénom : ");
				prenom = Console.ReadLine();
			}
			while (prenom.Length < 1);
			Guerremanien g = new Guerremanien(nom, prenom);
				
			// poser la question et noter la réponse
			do
			{
				Console.WriteLine("Êtes-vous pour ou contre la proposition suivante : '" + question + "' ?");
				Console.Write("> Réponse (o/n) : ");
				reponse = Console.ReadLine();
			}
			while (reponse != "n" && reponse != "o");
				
			// si contre ajouter à la liste d'ennemis (si non déjà présent)
			if (reponse == "n" && !ennemis.Contains(g))
			{
				ennemis.Add(g);
			}
				
			// générer un référendum parfaitement 'juste'
			List<double> referendum = GenererListeAleatoire(1000);
			int pour = 0;
			int contre = 0;
			CompterPourContre(referendum, ref pour, ref contre);
				
			// si le référendum est négatif, afficher erreur et recommencer
			Console.WriteLine("Pour : " + pour + ", contre : " + contre);
			if (contre > pour)
			{
				Console.WriteLine("Malheureusement, nous avons constaté des erreurs lors du référendum, celui-ci va être recommencé !");
			}
			// sinon avancer à la question suivante
			else
			{
				i++;
			}
		}
		
		// afficher la liste des ennemis de Guerman
		Console.WriteLine("Voici la liste officielle des ennemis de Guerman et de la Guerremanie :");
		foreach (Guerremanien ennemi in ennemis)
		{
			Console.WriteLine(ennemi);
		}
	}
}
