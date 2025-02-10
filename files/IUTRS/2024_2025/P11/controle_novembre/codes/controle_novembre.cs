// Auteur : Romain PERRIN

using System;

class ControleNovembre
{
	// on suppose cette fonction connue
	public static bool Comparer(string s1, string s2)
	{
		return s1.Equals(s2);
	}

	// Fonction : TotalParUE (exercice 1, question 1)
	// Entrée :		- EDT : tableau 2D de 11*6 chaînes de caractères
	//				- UE : chaîne de caractère
	// Local :		- ligne, colonne : entiers
	// Sortie :		- total : entier
	public static int TotalParUE(string[,] EDT, string UE)
	{
		int total = 0;
		for (int ligne = 1; ligne < 11; ligne++)
		{
			for (int colonne = 1; colonne < 6; colonne++)
			{
				if (Comparer(EDT[ligne, colonne], UE))
				{
					total += 1;
				}
			}
		}
		return total;
	}

	// Fonction : NumJour (exercice 1, question 2)
	// Entrée :		- nomJour : chaîne de caractère
	// Local :		/
	// Sortie :		- indice : entier
	public static int NumJour(string nomJour)
	{
		int indice = -1;
		if (Comparer(nomJour, "Lundi"))
		{
			indice = 1;
		}
		else if (Comparer(nomJour, "Mardi"))
		{
			indice = 2;
		}
		else if (Comparer(nomJour, "Mercredi"))
		{
			indice = 3;
		}
		else if (Comparer(nomJour, "Jeudi"))
		{
			indice = 4;
		}
		else if (Comparer(nomJour, "Vendredi"))
		{
			indice = 5;
		}
		return indice;
	}

	// Fonction : TestTropDheure (exercice 1, question 3)
	// Entrée :		- EDT : tableau 2D de 11*6 chaînes de caractères
	//				- UE : chaîne de caractère 
	//				- jour : chaîne de caractères
	// Local :		- jour, colonne : entiers
	// Sortie :		- total : entier
	public static bool TestTropDheure(string[,] EDT, string UE, string jour)
	{
		// compter le nombre d'heures de l'UE pour le jour et vérifier que <= 3
		int colonne = NumJour(jour);
		int total = 0;
		for (int ligne = 1; ligne < 11; ligne++)
		{
			if (Comparer(EDT[ligne, colonne], UE))
			{
				total += 1;
			}
			if (total > 3)
			{
				return true;
			}
		}
		return false;
	}

	// Structure StructUE (exercice 2, question 1)
	public struct StructUE
	{
		public string nom;
		public int nbHeures;
	};

	// Procédure : InitUE (exercice 2, question 3)
	// Entrée :		- tabRecapUE : tableau 1D de 7 StructUE
	//				- tabUE : tableau de 7 chaînes de caractères (noms des UE)
	// Local :		-
	// Sortie :		void
	public static void InitUE(string[,] EDT, StructUE[] tabRecapUE, string[] tabUE)
	{
		// pour chaque UE
		for (int indiceUE = 0; indiceUE < 7; indiceUE++)
		{
			tabRecapUE[indiceUE].nom = tabUE[indiceUE];
			tabRecapUE[indiceUE].nbHeures = TotalParUE(EDT, tabUE[indiceUE]);
		}
	}

	public static void Main()
	{
		string[,] EDT = new string[11,6]{
			{"", 		"Lundi", 			"Mardi", 			"Mercredi",			"Jeudi",			"Vendredi"},
			{"8h-9h",	"Math pour l'info",	"Archi/Système",	"Algorithmique",	"Langue",			"Programmation C"},
			{"9h-10h",	"Math pour l'info",	"Archi/Système",	"Algorithmique",	"Langue",			"Programmation C"},
			{"10h-11h",	"Programmation C",	"Programmation C",	"Archi/Système",	"Archi/Système",	"Conduite projet"},
			{"11h-12h",	"Programmation C",	"Programmation C",	"Archi/Système",	"Archi/Système",	"Conduite projet"},
			{"12h-13h",	"Libre",			"Libre",			"Libre",			"Libre",			"Libre"},
			{"13h-14h",	"Libre",			"Libre",			"Libre",			"Archi/Système",	"Langue"},
			{"14h-15h",	"Langue",			"Programmation C",	"Libre",			"Conduite projet",	"Math pour l'info"},
			{"15h-16h",	"Algorithmique",	"Programmation C",	"Programmation C",	"Algorithmique",	"Math pour l'info"},
			{"16h-17h",	"Algorithmique",	"Algorithmique",	"Programmation C",	"Algorithmique",	"Archi/Système"},
			{"17h-18h",	"Libre",			"Algorithmique",	"Libre",			"Libre",			"Archi/Système"}
		};
		string[] tabUE = new string[7]{"Algorithmique", "Math pour l'info", "Archi/Système", "Réseaux", "Programmation C", "Conduite projet", "Langue"};
		string[] jours = new string[5]{"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi"};
		
		// algo principal (exercice 1, question 4)

		int total = 0;
		// pour chaque UE
		for (int indiceUE = 0; indiceUE < 7; indiceUE++)
		{
			string UE = tabUE[indiceUE];
			int totalUE = TotalParUE(EDT, UE);
			total += totalUE;
			bool tropDheure = false;

			// pour chaque jour de la semaine
			for (int indiceJour = 0; indiceJour < 5; indiceJour++)
			{
				string jour = jours[indiceJour];
				tropDheure = tropDheure || TestTropDheure(EDT, UE, jour);
			}

			// affichage
			if (tropDheure)
			{
				Console.WriteLine($"{UE} : {totalUE} (dépassement)");
			}
			else
			{
				Console.WriteLine($"{UE} : {totalUE}");
			}
		}
		Console.WriteLine($"Total : {total}");

		// exercice 2, question 2
		StructUE[] tabRecapUE = new StructUE[7];

		// exercice 3, question 3
		InitUE(EDT, tabRecapUE, tabUE);
		// affichage pour vérifier
		for (int i = 0; i < 7; i++)
		{
			Console.WriteLine($"UE {tabRecapUE[i].nom} total {tabRecapUE[i].nbHeures}");
		}
	}
}