// Auteur : Romain PERRIN

using System;

class Exercice1
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
	

	// Fonction : FormaterHeure (Q1.1 - bonus)
	// Entrée :	- minutes : entier
	// Sortie :	chaîne de caractères
	public static string FormaterHeure(int minutes)
	{
		int h = minutes / 60;
		int m = minutes % 60;
		return $"{h}:{m}";
	}
	

	// Fonction : GetIndice (considérée connue dans l'énoncé)
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
	

	// Procédure : AfficherHoraires (Q1.1)
	// Entrée :	- horaires : tableau 2D d'entiers
	// 		- horaire : entier
	// 		- gare : chaîne de caractères
	// Sortie :	void
	public static void AfficherHoraires(int[,] horaires, int horaire, string gare)
	{
		int indiceGare = GetIndice(gare);
		// si l'indice est valide
		if (indiceGare > -1)
		{
			// parcours des lignes des horaires
			for (int indiceTrajet = 0; indiceTrajet < horaires.GetLength(0); indiceTrajet++)
			{
				// affichage de la ligne indiceTrajet, colonne indiceGare si l'horaire est >= à l'horaire donnée en paramètre
				if (horaires[indiceTrajet, indiceGare] >= horaire)
				{
					Console.WriteLine(FormaterHeure(horaires[indiceTrajet, indiceGare]));
				}
			}
		}
		// sinon afficher une erreur
		else
		{
			Console.WriteLine($"Erreur - La gare {gare} n'existe pas dans la table des horaires");
		}
	}
	
	
	// Procédure : Details (Q1.2)
	// Entrée :	- arrets : tableau 1D de chaînes de caractères
	//			- horaires : tableau 2D d'entiers
	//			- horaire : entier
	//			- gareDepart : chaîne de caractères
	//			- gareArrivee : chaîne de caractères
	// Sortie :	void
	public static void Details(string[] arrets, int[,] horaires, int horaire, string gareDepart, string gareArrivee)
	{
		int indiceGareDepart = GetIndice(gareDepart);
		int indiceGareArrivee = GetIndice(gareArrivee);
		
		if (indiceGareDepart == -1 || indiceGareArrivee == -1)
		{
			Console.WriteLine($"Erreur - La gare de départ {gareDepart} ou d'arrivée {gareArrivee} n'existe pas !");
		}
		else
		{
			int indiceLigne = 0;
			// recherche de l'horaire de départ, parcours des lignes sur la colonne indiceGareDepart
			while (indiceLigne < horaires.GetLength(0) - 1 && horaires[indiceLigne, indiceGareDepart] != horaire)
			{
				indiceLigne++;
			}
			
			if (horaires[indiceLigne, indiceGareDepart] != horaire)
			{
				Console.WriteLine($"Erreur - Il n'y a pas de départ à l'horaire {horaire} depuis la gare {gareDepart} !");
			}
			else
			{
				Console.WriteLine($"{gareDepart} -> {gareArrivee}");
				Console.WriteLine($"Départ : {FormaterHeure(horaires[indiceLigne, indiceGareDepart])}");
				Console.WriteLine($"Arrivée : {FormaterHeure(horaires[indiceLigne, indiceGareArrivee])}");
				int duree = horaires[indiceLigne, indiceGareArrivee] - horaires[indiceLigne, indiceGareDepart];
				Console.WriteLine($"Durée : {duree} minutes");
				Console.WriteLine("Dessert :");
				
				// parcours des arrêts de la ligne
				for (int indiceGare = indiceGareDepart + 1; indiceGare < indiceGareArrivee; indiceGare++)
				{
					Console.WriteLine($"{arrets[indiceGare]} ({FormaterHeure(horaires[indiceLigne, indiceGare])})");
				}
			}
		}
	}
	

	// Algorithme principal
	public static void Main()
	{
		// demander le nom d'un gare à l'utilisateur puis un horaire (format numérique)
		string nomGare = "";
		do
		{
			Console.Write("Saisir le nom d'une gare : ");
			nomGare = Console.ReadLine();
		}
		while (nomGare.Length < 1);
		
		int horaireArret = -1;
		do
		{
			Console.Write("Saisir un horaire entre 0 (00:00) et 1439 (23:59) : ");
			horaireArret = int.Parse(Console.ReadLine());
		}
		while (horaireArret < 0 || horaireArret > 1439);
		
		// Question 1.1
		AfficherHoraires(horaires, horaireArret, nomGare);
		
		// demander le nom d'une gare de départ, d'arrivée et un horaire de départ
		string nomGareDepart = "";
		do
		{
			Console.Write("Saisir le nom d'une gare de départ : ");
			nomGareDepart = Console.ReadLine();
		}
		while (nomGareDepart.Length < 1);
		
		int horaireDepart = -1;
		do
		{
			Console.Write($"Saisir un horaire de départ de {nomGareDepart} entre 0 (00:00) et 1439 (23:59) : ");
			horaireDepart = int.Parse(Console.ReadLine());
		}
		while (horaireDepart < 0 || horaireDepart > 1439);
		
		string nomGareArrivee = "";
		do
		{
			Console.Write("Saisir le nom d'une gare d'arrivée : ");
			nomGareArrivee = Console.ReadLine();
		}
		while (nomGareArrivee.Length < 1);
		
		// Qestion 1.2
		Details(arrets, horaires, horaireDepart, nomGareDepart, nomGareArrivee);
	}
}
