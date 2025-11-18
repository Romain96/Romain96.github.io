// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Collections.Generic;

class Exercice6
{
	// structure : Classe
	public struct Classe
	{
		public string _code;
		public string _nom;
		public double _prix;

		// Constructeur
		public Classe(string code, string nom, double prix)
		{
			_code = code;
			_nom = nom;
			_prix = prix;
		}

		// Affichage
		public override string ToString()
		{
			return "Classe < code = " + _code + ", nom = '" + _nom + "', prix = " + _prix + " >";
		}
	};
	
	// structure : Passager
	public struct Passager
	{
		public int _numero;
		public string _nom;
		public string _prenom;
		public string _codeClasse;

		// Constructeur
		public Passager(int numero, string nom, string prenom, string codeClasse)
		{
			_numero = numero;
			_nom = nom;
			_prenom = prenom;
			_codeClasse = codeClasse;
		}

		// Affichage
		public override string ToString()
		{
			return "Passager < numéro = " + _numero + ", nom = '" + _nom + "', prénom = '" + _prenom + "', codeClasse = '" + _codeClasse + "' >";
		}
	};
	
	// structure : Bagage
	public struct Bagage
	{
		public int _numero;
		public int _poids;
		public int _numBillet;

		// Constructeur
		public Bagage(int numero, int poids, int numBillet)
		{
			_numero = numero;
			_poids = poids;
			_numBillet = numBillet;
		}

		// Affichage
		public override string ToString()
		{
			return "Bagage < numéro = " + _numero + ", poids = " + _poids + ", numBillet = " + _numBillet + " >";
		}
	};

	// Fonction : ChargerListeClasses
	// Entrée :	- chemin : chaîne de caractères
	// Sortie : 	liste de structure Classe
	public static List<Classe> ChargerListeClasses(string chemin)
	{
		List<Classe> classes = new List<Classe>();
		
		if (File.Exists(chemin))
		{
			FileStream fs = new FileStream(chemin, FileMode.Open);
			StreamReader reader = new StreamReader(fs);
			string line;

			while ((line = reader.ReadLine()) != null)
			{
				// code;nom;prix
				string[] elts = line.Split(";");
				Classe c = new Classe(elts[0], elts[1], double.Parse(elts[2]));
				classes.Add(c);
			}
			reader.Close();
		}

		return classes;
	}

	// Fonction : ChargerListePassagers
	// Entrée :	- chemin : chaîne de caractères
	// Sortie :	liste de structure Passager
	public static List<Passager> ChargerListePassagers(string chemin)
	{
		List<Passager> passagers = new List<Passager>();

		if (File.Exists(chemin))
		{
			FileStream fs = new FileStream(chemin, FileMode.Open);
			StreamReader reader = new StreamReader(fs);
			string line;

			while ((line = reader.ReadLine()) != null)
			{
				//numéro;nom;prénom;codeClasse
				string[] elts = line.Split(";");
				Passager p = new Passager(int.Parse(elts[0]), elts[1], elts[2], elts[3]);
				passagers.Add(p);
			}
			reader.Close();
		}

		return passagers;
	}

	// Fonction : ChargerListeBagages
	// Entrée : 	- chemin : chaîne de caractères
	// Sortie :	liste de structure Bagage
	public static List<Bagage> ChargerListeBagages(string chemin)
	{
		List<Bagage> bagages = new List<Bagage>();

		if (File.Exists(chemin))
		{
			FileStream fs = new FileStream(chemin, FileMode.Open);
			StreamReader reader = new StreamReader(fs);
			string line;

			while ((line = reader.ReadLine()) != null)
			{
				// numéro;poids;numBillet
				string[] elts = line.Split(";");
				Bagage b = new Bagage(int.Parse(elts[0]), int.Parse(elts[1]), int.Parse(elts[2]));
				bagages.Add(b);
			}
		}

		return bagages;
	}

	// Fonction : ChercherNomClasse
	// Entrée :	- classes : liste de structure Classe
	// 		- code : chaîne de caractères
	// Sortie :	chaîne de caractères
	public static string ChercherNomClasse(List<Classe> classes, string code)
	{
		foreach (Classe c in classes)
		{
			if (c._code == code)
			{
				return c._nom;
			}
		}
		return "";
	}

	// Fonction : ChercherBagagesPassager
	// Entrée :	- bagages : liste de structure Bagage
	// 		- numero : entier
	// Sortie :	liste de structure Bagage
	public static List<Bagage> ChercherBagagesPassager(List<Bagage> bagages, int numero)
	{
		List<Bagage> bagagesPassager = new List<Bagage>();
		foreach (Bagage b in bagages)
		{
			if (b._numBillet == numero)
			{
				bagagesPassager.Add(b);
			}
		}
		return bagagesPassager;
	}

	// Procédure : AfficherPassagers
	// Entrée :	- passagers : liste de structure Passager
	// 		- classes : liste de structure Classe
	// 		- bagages : liste de structure Bagage
	// Sortie :	void
	public static void AfficherPassagers(List<Passager> passagers, List<Classe> classes, List<Bagage> bagages)
	{
		Console.WriteLine("Numero Passager                  Classe                    Nombre bagages Poids Cumulé");
		Console.WriteLine("------------------------------------------------------------------------------------");
		foreach (Passager p in passagers)
		{
			// numéro, prénom, nom, nom classe (à extraire), nombre de bagages (à calculer), poids cumulé (à calculer)
			string nomClasse = ChercherNomClasse(classes, p._codeClasse);
			List<Bagage> bagagesDuPassager = ChercherBagagesPassager(bagages, p._numero);
			int poids = 0;
			foreach (Bagage b in bagagesDuPassager)
			{
				poids += b._poids;
			}
			Console.Write($"{p._numero}".PadRight(6) + " ");
			Console.Write($"{p._prenom} {p._nom}".PadRight(25) + " ");
			Console.Write($"{nomClasse}".PadRight(25) + " ");
			Console.Write($"{bagagesDuPassager.Count}".PadRight(14) + " ");
			Console.Write($"{poids}".PadRight(12) + "\n");
		}
	}

	// Fonction : ChercherPrixClasse
	// Entrée :	- classes : liste de strcture Classe
	// 		- code : chaîne de caractères
	// Sortie :	réel
	public static double ChercherPrixClasse(List<Classe> classes, string code)
	{
		foreach (Classe c in classes)
		{
			if (c._code == code)
			{
				return c._prix;
			}
		}
		return 0.0;
	}

	// Fonction : CalculerPrixBilletPassager
	// Entrée : 	- bagages : liste de structure Bagage
	// 		- prixBillet : réel
	// Sortie :	réel
	public static double CalculerPrixBilletPassager(List<Bagage> bagages, double prixBillet)
	{
		double prix = prixBillet;
		int poids = 0;
		foreach (Bagage b in bagages)
		{
			poids += b._poids;
		}
		if (poids > 20 && poids <= 30)
		{
			prix *= 1.10;
		}
		else if (poids > 30 && poids <= 40)
		{
			prix *= 1.20;
		}
		else if (poids > 40)
		{
			prix *= 1.30;
		}
		return prix;
	}

	// Procédure : RechercherPassager
	// Entrée :	- passagers : liste de structure Passager 
	// 		- num : entier
	// 		- référence p : structure Passager
	// Sortie :	booléen
	public static bool RechercherPassager(List<Passager> passagers, int num, ref Passager p)
	{
		foreach (Passager pas in passagers)
		{
			if (pas._numero == num)
			{
				p = pas;
				return true;	// trouvé et renseigné
			}
		}
		return false;	// non trouvé
	}

	// Fonction : CalculerChiffreAffairesVol
	// Entrée :	- passagers : liste de structure Passager
	// 		- classes : liste de structure Classe
	// 		- bagages : liste de structure Bagage
	// Sortie :	réel
	public static double CalculerChiffreAffairesVol(List<Passager> passagers, List<Classe> classes, List<Bagage> bagages)
	{
		double ca = 0.0;

		foreach (Passager p in passagers)
		{
			double prixBase = ChercherPrixClasse(classes, p._codeClasse);
			List<Bagage> bagagesP = ChercherBagagesPassager(bagages, p._numero);
			ca += CalculerPrixBilletPassager(bagagesP, prixBase);
		}

		return ca;
	}

	public static void Main()
	{
		const string PREFIX_CLASSES = "C";
		const string PREFIX_PASSAGERS = "P";
		const string PREFIX_BAGAGES = "B";

		int choix, numVol;
		string saisie;
		bool menu = true;

		// saisie du numéro de vol
		do
		{
			Console.WriteLine("Liaisons aériennes (ou lésions ARN :D)");
			Console.Write("> Saisir le numéro du vol : ");
			saisie = Console.ReadLine();
		}
		while (saisie.Length < 1);
		numVol = int.Parse(saisie);

		// lecture des données
		List<Classe> classes = ChargerListeClasses($"{PREFIX_CLASSES}{numVol}.txt");
		List<Passager> passagers = ChargerListePassagers($"{PREFIX_PASSAGERS}{numVol}.txt");
		List<Bagage> bagages = ChargerListeBagages($"{PREFIX_BAGAGES}{numVol}.txt");
	
		while (menu)
		{
			// menu principal
			do
			{
				do
				{
					Console.WriteLine("Liaisons aériennes (ou lésions ARN :D)");
					Console.WriteLine("1 - Prix du billet d'un passager");
					Console.WriteLine("2 - Liste des passagers");
					Console.WriteLine("3 - Chiffre d'affaires du vol");
					Console.WriteLine("4 - Quitter");
					Console.Write("> Saisir le numéro du choix : ");
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 1);
				choix = int.Parse(saisie);
			}
			while (choix < 0 || choix > 4);

			switch (choix)
			{
				case 1: 
					int numPassager;
					bool trouve;
					Passager p1 = new Passager();
					do
					{
						do
						{
							Console.Write("> Saisir le numéro d'un passager : ");
							saisie = Console.ReadLine();
						}
						while (saisie.Length < 1);
						numPassager = int.Parse(saisie);
						// recherche du passager
						trouve = RechercherPassager(passagers, numPassager, ref p1);
					}
					while (!trouve);
					// calcul du prix du billet
					List<Bagage> bagages1 = ChercherBagagesPassager(bagages, numPassager);
					double prixBase1 = ChercherPrixClasse(classes, p1._codeClasse);
					double prix1 = CalculerPrixBilletPassager(bagages1, prixBase1);
					Console.WriteLine($"Prix du billet du passager n°{numPassager} ({p1._prenom} {p1._nom}) est de {prix1} €");
					break;
				case 2: 
					AfficherPassagers(passagers, classes, bagages);
					break;
				case 3: 
					double ca = CalculerChiffreAffairesVol(passagers, classes, bagages);
					Console.WriteLine($"Le chiffre d'affaires du vol n°{numVol} est de {ca} €");
					break;
				default: menu = false; break;
			}
		}
	}
}
