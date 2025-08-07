// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class VolsCommerciaux
{
	// Structure : Classe du vol 707
	public struct Classe
	{
		public string code;
		public string nom;
		public double prix;

		// constructeur
		public Classe(string code, string nom, double prix)
		{
			this.code = code;
			this.nom = nom;
			this.prix = prix;
		}

		// affichage
		public override string ToString()
		{
			return $"Classe :\tcode = {code}\tnom = {nom}\tprix = {prix}";
		}
	};

	// Structure : Passager du vol 707
	public struct Passager
	{
		public int numero;
		public string nom;
		public string prenom;
		public string codeClasse;

		// constructeur
		public Passager(int numero, string nom, string prenom, string codeClasse)
		{
			this.numero = numero;
			this.nom = nom;
			this.prenom = prenom;
			this.codeClasse = codeClasse;
		}

		// affichage
		public override string ToString()
		{
			return $"Passager :\tnumero = {numero}\tnom = {nom}\tprenom = {prenom}\tcodeClasse = {codeClasse}";
		}
	};

	// Structure : Bagage du vol/passager 707
	public struct Bagage
	{
		public int numero;
		public int poids;
		public int numBillet;

		// constructeur
		public Bagage(int numero, int poids, int numBillet)
		{
			this.numero = numero;
			this.poids = poids;
			this.numBillet = numBillet;
		}

		// affichage
		public override string ToString()
		{
			return $"Bagage :\tnumero = {numero}\tpoids = {poids}\tnumBillet = {numBillet}";
		}
	}; 

	// Fonction : SaisirEntier
	// Entrée :		- texte : chaîne de caractères
	// Local : 		/
	// Sortie :		- entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}

	// Fonction : ChargerListeClasse
	// Entrée :		- numero : entier
	// Local :		- reader : flux de lecture
	// Sortie :		- listeClasses : liste de Classe
	public static List<Classe> ChargerListeClasse(int numero)
	{
		List<Classe> listeClasses = new List<Classe>();
		// ouverture du flux de lecture si le fichier existe
		string chemin = $"C{numero}.txt";
		if (File.Exists(chemin))
		{
			StreamReader reader = new StreamReader(chemin);
			// lecture du fichier ligne par ligne
			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				// code, nom, prix
				string[] details = line.Split(';');
				Classe c = new Classe(details[0], details[1], double.Parse(details[2]));
				listeClasses.Add(c);
			}
			// fermeture du flux de lecture
			reader.Close();
		}
		return listeClasses;
	}

	// Fonction : ChargerListePassager
	// Entrée :		- numero : entier
	// Local :		- reader : flux de lecture
	// Sortie :		- listePassagers : liste de Passager
	public static List<Passager> ChargerListePassager(int numero)
	{
		List<Passager> listePassagers = new List<Passager>();
		// ouverture du flux de lecture si le fichier existe
		string chemin = $"P{numero}.txt";
		if (File.Exists(chemin))
		{
			StreamReader reader = new StreamReader(chemin);
			// lecture du fichier ligne par ligne
			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				// numéro, nom, prénom, code de classe
				string[] details = line.Split(';');
				Passager p = new Passager(int.Parse(details[0]), details[1], details[2], details[3]);
				listePassagers.Add(p);
			}
			// fermeture du flux de lecture
			reader.Close();
		}
		return listePassagers;
	}

	// Fonction : ChargerListeBagage
	// Entrée :		- numero : entier
	// Local :		- reader : flux de lecture
	// Sortie :		- listeBagages : liste de Bagage
	public static List<Bagage> ChargerListeBagage(int numero)
	{
		List<Bagage> listeBagages = new List<Bagage>();
		// ouverture du flux de lecture si le fichier existe
		string chemin = $"B{numero}.txt";
		if (File.Exists(chemin))
		{
			StreamReader reader = new StreamReader(chemin);
			// lecture du fichier ligne par ligne
			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				// numéro, poids, billet
				string[] details = line.Split(';');
				Bagage b = new Bagage(int.Parse(details[0]), int.Parse(details[1]), int.Parse(details[2]));
				listeBagages.Add(b);
			}
			// fermeture du flux de lecture
			reader.Close();
		}
		return listeBagages;
	}

	// Fonction : RechercherPassager
	// Entrée :		- numero : entier
	//					- listePassagers : liste de Passager
	// Local : 		- i : entier
	// Sortie :		- Passager ou null (si non trouvé)
	public static Passager? RechercherPassager(int numero, List<Passager> listePassagers)
	{
		int i = 0;
		while (i < listePassagers.Count)
		{
			if (listePassagers[i].numero == numero)
			{
				return listePassagers[i];
			}
			i++;
		}
		return null;
	}

	// Fonction : RechercherClasse
	// Entrée :		- code : entier
	//					- listeClasses : liste de Classe
	// Local : 		- i : entier
	// Sortie :		- c : Classe ou null (si non trouvé)
	public static Classe? RechercherClasse(string code, List<Classe> listeClasses)
	{
		int i = 0;
		while (i < listeClasses.Count)
		{
			if (listeClasses[i].code.Equals(code))
			{
				return listeClasses[i];
			}
			i++;
		}
		return null;
	}

	// Procédure : RechercherPrixDepuisNumeroBillet (action 1)
	// Entrée :
	// Local :
	// Sortie :		void
	public static void RechercherPrixDepuisNumeroBillet(List<Passager> listePassagers, List<Classe> listeClasses, int numPassager)
	{
		// 1 - rechercher le passager dans la liste des passagers
		Passager? p = RechercherPassager(numPassager, listePassagers);
		if (p.HasValue)
		{
			// 2 - rechercher la classe correspondant à celle du passager
			Classe? c = RechercherClasse(p.Value.codeClasse, listeClasses);

			// 3 - afficher le prix de cette classe
			if (c.HasValue)
			{
				Console.WriteLine($"Le prix du billet du passager {numPassager} est de {c.Value.prix} euros.");
			}
			else
			{
				Console.WriteLine($"Erreur - la classe du passager {numPassager} n'existe pas dans la liste des classes.");
			}
		}
		else
		{
			Console.WriteLine($"Erreur - le passager {numPassager} n'existe pas dans la liste des passagers.");
		}
	}

	// Fonction : RechercherBagagesDepuisPassager
	// Entrée :		- listeBagages : liste de Bagage
	//					- passager : Passager
	// Local :		- i : entier
	// Sortie :		- bagages : liste de Bagage
	public static List<Bagage> RechercherBagagesDepuisPassager(List<Bagage> listeBagages, Passager passager)
	{
		List<Bagage> bagages = new List<Bagage>();
		foreach (Bagage b in listeBagages)
		{
			if (b.numBillet == passager.numero)
			{
				bagages.Add(b);
			}
		}
		return bagages;
	}

	// Procédure : AfficherPassagers (action 2)
	// Entrée :		- listePassagers : liste de Passager
	// Local :		- i : entier
	// Sortie :		void
	public static void AfficherPassagers(List<Passager> listePassagers, List<Classe> listeClasses, List<Bagage> listeBagages)
	{
		// pour chaque passager : rechercher la classe pour afficher le prix et rechercher les bagages pour afficher (+ somme des poids)
		Console.WriteLine("{0, -3}\t{1, -20}\t{2, -20}\t{3, -20}\t{4, -3}", "Numéro", "Passager", "Classe", "Nombre de bagages", "Poids cumulé");
		foreach (Passager p in listePassagers)
		{
			// 1 - rechercher la classe correspondant à celle du passager
			Classe? c = RechercherClasse(p.codeClasse, listeClasses);

			// rechercher tous les bagages de ce passager
			List<Bagage> bagages = RechercherBagagesDepuisPassager(listeBagages, p);

			// somme des poids des bagages du passager
			int sommePoids = 0;
			foreach (Bagage b in bagages)
			{
				sommePoids += b.poids;
			}
			// Affichage : numéro - nom prénom - classe - nb bagages - somme poids bagages
			Console.WriteLine($"{p.numero,-3}\t{p.prenom + " " + p.nom, -20}\t{c.Value.nom, -20}\t{bagages.Count, -20}\t{sommePoids, -3} Kg");
		}
	}

	// Fonction : CalculerPrix
	// Entrée :		- passager : Passager
	//				- bagages : liste de Bagage
	//				- classe : Classe
	// Local :		- b : Bagage
	//				- sommePoids : entier
	// Sortie :		- prix : réel
	public static double CalculerPrix(Passager passager, List<Bagage> bagages, Classe classe)
	{
		double prix = classe.prix;
		int sommePoids = 0;
		foreach (Bagage b in bagages)
		{
			sommePoids += b.poids;
		}
		// en desous ou égal à 20 Kg pas de surtaxe
		// entre 21 Kg et 30 Kg => 10% de surtaxe
		// entre 31 Kg et 40 Kg => 20% de surtaxe
		// au-delà de 41 Kg => 30% de surtaxe
		if (sommePoids > 20 && sommePoids <= 30)
		{
			prix *= 1.10;
		}
		else if (sommePoids >= 31 && sommePoids <= 40)
		{
			prix *= 1.20;
		}
		else if (sommePoids >= 41)
		{
			prix *= 1.30;
		}
		return prix;
	}

	// Procédure : AfficherChiffreAffaireVol (action 3)
	// Entrée : 	- listePassagers : liste de Passager
	//				- listeBagages : liste de Bagages
	//				- listeClasses : liste de Classe
	// Local :		-
	// Sortie :		void
	public static void AfficherChiffreAffaireVol(List<Passager> listePassagers, List<Bagage> listeBagages, List<Classe> listeClasses)
	{
		double caTotal = 0.0;
		foreach (Passager p in listePassagers)
		{
			// 1 - rechercher la classe correspondant à celle du passager
			Classe? c = RechercherClasse(p.codeClasse, listeClasses);

			// rechercher tous les bagages de ce passager
			List<Bagage> bagages = RechercherBagagesDepuisPassager(listeBagages, p);

			// calculer le prix en appelant la fonction CalculerPrix
			double caPassager = CalculerPrix(p, bagages, c.Value);
			caTotal += caPassager;

			// Affichage pour le passager courant
			Console.WriteLine($"Le passager {p.prenom} {p.nom} (n°{p.numero}) apporte un CA de {caPassager} euros.");
		}
		// affichage total
		Console.WriteLine($"Les {listePassagers.Count} passagers apportent un CA de {caTotal} euros.");
	}

	public static void Main()
	{
		// saisir le numéro du vol
		int numVol = SaisirEntier("Entrer le numéro du vol : ");

		// chargement des données depuis les fichiers
		List<Classe> listeClasses = ChargerListeClasse(numVol);
		Console.WriteLine($"Chargement de {listeClasses.Count} classes.");

		List<Passager> listePassagers = ChargerListePassager(numVol);
		Console.WriteLine($"Chargement de {listePassagers.Count} passagers.");

		List<Bagage> listeBagages = ChargerListeBagage(numVol);
		Console.WriteLine($"Chargement de {listeBagages.Count} bagages.");

		// boucle principale : affichage du menu et choix
		bool quitter = false;
		int choix = 0;

		while (!quitter)
		{
			Console.WriteLine("Menu :\n\t1 - Prix du billet d'un passager\n\t2 - Liste des passagers\n\t3 - Chiffre d'affaires du vol\n\t4 - Quitter");
			choix = 0;
			while (choix < 1 || choix > 4)
			{
				choix = SaisirEntier("Action à réaliser (1-4) : ");
				switch (choix)
				{
					case 1:
						int numPassager = SaisirEntier("Numéro du passager : ");
						RechercherPrixDepuisNumeroBillet(listePassagers, listeClasses, numPassager);
						break;
					case 2: 
						AfficherPassagers(listePassagers, listeClasses, listeBagages);
						break;
					case 3:
						AfficherChiffreAffaireVol(listePassagers, listeBagages, listeClasses); 
						break;
					case 4: quitter = true; break;
				}
			}
		}

	}
}