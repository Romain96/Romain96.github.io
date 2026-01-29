// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
{
	// pour coller aux contraites du sujet, les tableau arrets et horaires sont des variables globales.
	public static string[] arrets = new string[] {"Strasbourg", "Sélestat", "Colmar", "Mulhouse", "Saint-Louis", "Bâle"};
	
	// oui, il s'agit de la vrai table des horaires de la ligne A01 Strasbourg -> Bâle 
	// (du lundi au vendredi , du 14 décembre 2025 au 03 juillet 2026)
	public static int[,] horaires = new int[,] {
		{319, 339, 351, 376, 391, 398}, 
		{351, 371, 383, 406, 421, 428},
		{381, 401, 413, 436, 451, 458},
		{411, 431, 443, 466, 481, 488},
		{441, 461, 473, 496, 511, 518},
		{471, 491, 503, 526, 541, 948},
		{501, 521, 533, 556, 571, 578},
		{591, 611, 623, 646, 661, 668},
		{621, 641, 653, 676, 691, 698},
		{651, 671, 683, 706, 721, 728},
		{711, 731, 743, 766, 781, 788},
		{771, 791, 803, 826, 841, 848},
		{831, 851, 863, 886, 901, 908},
		{891, 912, 924, 946, 961, 968},
		{951, 971, 983, 1006, 1021, 1028},
		{981, 1001, 1013, 1036, 1051, 1058},
		{1011, 1031, 1043, 1066, 1081, 1088},
		{1041, 1061, 1073, 1096, 1111, 1118},
		{1131, 1151, 1163, 1186, 1201, 1208},
		{1161, 1181, 1193, 1216, 1231, 1238},
		{1191, 1211, 1223, 1246, 1261, 1268},
		{1221, 1241, 1253, 1276, 1291, 1298},
		{1281, 1301, 1313, 1336, 1351, 1358}
	};
	
	// structure Place
	public struct Place
	{
		public int numero;
		public int[] portions;
		
		// constructeur
		public Place(int num)
		{
			numero = num;
			portions = new int[5];
			for (int i = 0; i < 4; i++)
			{
				portions[i] = 0;
			}
		}
	};
	
	
	// structure Usager
	public struct Usager
	{
		public string nom;
		public string prenom;
		public string telephone;
		
		// constructeur
		public Usager(string nm, string pn, string tel)
		{
			nom = nm;
			prenom = pn;
			telephone = tel;
		}
	};
	
	
	// structure Trajet
	public struct Trajet
	{
		public int dernierNumeroResa;
		public List<Place> lesPlaces;
		
		// constructeur
		public Trajet(int dnr)
		{
			dernierNumeroResa = dnr;
			lesPlaces = new List<Place>();
			for (int i = 0; i < 20; i++)
			{
				Place unePlace = new Place(i);
				lesPlaces.Add(unePlace);
			}
		}
	};
	
	
	// Fonction : GetIndice
	// Entrée :	- gare : chaîne de caractères
	// Sortie : 	entier (indice dans le tableau, -1 si non trouvé)
	public static int GetIndice(string gare)
	{
		for (int i = 0; i < arrets.Length; i++)
		{
			if (arrets[i] == gare)
			{
				return i; 
			}
		}
		return -1;
	}
	
	
	// Fonction : Reserver
	// Entrée :	- trajet : référence sur une structure Trajet
	//			- gareDepart : chaîne de caractères
	//			- gareArrivee : chaîne de caractères
	//			- lesReservations : Dictionnaire<entier, Usager>
	//			- nom : chaîne de caractères
	//			- prenom : chaîne de caractères
	//			- tel : chaîne de caractères
	// Sortie :	booléen
	public static bool Reserver(
		ref Trajet trajet, 
		string gareDepart, string gareArrivee, 
		Dictionary<int, Usager> lesReservations, 
		string nom, string prenom, string tel
	)
	{
		// recherche d'une place disponible
		int p = 0;
		bool trouve = false;
		
		while (p < trajet.lesPlaces.Count && !trouve)
		{
			Place unePlace = trajet.lesPlaces[p];
			
			// vérifier que la place soit libre
			bool libre = true;
			
			for (int i = GetIndice(gareDepart); i < GetIndice(gareArrivee); i++)
			{
				if (unePlace.portions[i] != 0)
				{
					libre = false;
				}
			}
			
			// réservation si libre sur toutes les portions du trajet
			if (libre)
			{
				trajet.dernierNumeroResa = trajet.dernierNumeroResa + 1;
				for (int i = GetIndice(gareDepart); i < GetIndice(gareArrivee); i++)
				{
					unePlace.portions[i] = trajet.dernierNumeroResa;
				}
				trouve = true;	// réservation effectuée
			}
			// sinon on continue la recherche sur la place suivante
			else
			{
				p++;
			}
		}
		
		if (trouve)
		{
			Usager unUsager = new Usager(nom, prenom, tel);
			lesReservations.Add(trajet.dernierNumeroResa, unUsager);
		}
		
		return trouve;
	}
	
	
	// Affichage de la réservation
	public static void AfficherEtat(Dictionary<int, Usager> lesReservations, Trajet trajet)
	{
		foreach (KeyValuePair<int, Usager> kvp in lesReservations)
		{
			Console.WriteLine($"n° de réservation : {kvp.Key}, Usager : {kvp.Value.nom} {kvp.Value.prenom} ({kvp.Value.telephone})");
		}
		
		Console.WriteLine($"Trajet : dernier n° de réservation : {trajet.dernierNumeroResa}, places :");
		for (int i = 0; i < trajet.lesPlaces.Count; i++)
		{
			Console.WriteLine($"Place {i} :");
			for (int j = 0; j < trajet.lesPlaces[i].portions.Length; j++)
			{
				Console.WriteLine($"\tPortion {j} : {trajet.lesPlaces[i].portions[j]}");
			}
		}
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		// données du sujet
		Trajet trajet1251 = new Trajet(0);
		Dictionary<int, Usager> lesReservations = new Dictionary<int, Usager>();
		
		// petit menu avec réservation et affichage
		bool menu = true;
		while (menu)
		{
			// options (1 - afficher, 2 - ajouter, 3 - quitter)
			int choix = 0;
			do
			{
				Console.WriteLine("Menu\n");
				Console.WriteLine("1 - Afficher les informations");
				Console.WriteLine("2 - Ajouter une réservation");
				Console.WriteLine("3 - Quitter");
				Console.Write("Choix : ");
				choix = int.Parse(Console.ReadLine());
			}
			while (choix < 1 || choix > 3);
			
			switch (choix)
			{
				case 1:
					AfficherEtat(lesReservations, trajet1251);
					break;
				
				case 2:
					// demander le nom, prénom, téléphone
					string nom = "";
					string prenom = "";
					string tel = "";
					
					do
					{
						Console.Write("Saisir le nom de l'usager : ");
						nom = Console.ReadLine();
					}
					while (nom.Length < 1);
					
					do
					{
						Console.Write("Saisir le prénom de l'usager : ");
						prenom = Console.ReadLine();
					}
					while (prenom.Length < 1);
					
					do
					{
						Console.Write("Saisir le n° de télephone de l'usager : ");
						tel = Console.ReadLine();
					}
					while (tel.Length < 1);
					
					// demander la gare de départ et d'arrivée
					string gareD = "";
					string gareA = "";
					
					do
					{
						Console.Write("Saisir la gare de départ de l'usager : ");
						gareD = Console.ReadLine();
					}
					while (gareD.Length < 1);
					
					do
					{
						Console.Write("Saisir la gare d'arrivée de l'usager : ");
						gareA = Console.ReadLine();
					}
					while (gareA.Length < 1);
					
					// Question 2.1
					Reserver(ref trajet1251, gareD, gareA, lesReservations, nom, prenom, tel);
					break;
					
				default:
					menu = false;
					break;
			}
		}
	}
}
