// Auteur : Romain PERRIN

using System;
using System.IO;

class Conjugaison
{
	// Fonction : CreerPronoms
	// Entrée :	/
	// Sortie :	tableau 2D de 6*4 chaînes de caractères
	public static string[,] CreerPronoms()
	{
		// verbes commençant par une cosonne, une voyelle, se, s'
		string[,] pronoms = new string[6, 4] {
			{"je", "j'", "je me", "je m'"},
			{"tu", "tu", "tu te", "tu t'"},
			{"il/elle/on", "il/elle/on", "il/elle/on se", "il/elle/on s'"},
			{"nous", "nous", "nous nous", "nous nous"},
			{"vous", "vous", "vous vous", "vous vous"},
			{"ils/elles", "ils/elles", "ils/elles se", "ils/elles s'"}
		};
		return pronoms;
	}

	// Fonction : CreerTerminaisons
	// Entrée :	/
	// Sortie :	tableau 2D de 6*4 chaînes de caractères
	public static string[,] CreerTerminaisons()
	{
		// terminaisons au présent, futur, imparfait, passé simple
		string[,] terminaisons = new string[6, 4] {
			{"e", "erai", "ais", "ai"},
			{"es", "eras", "ais", "as"},
			{"e", "era", "ait", "a"},
			{"ons", "erons", "ions", "âmes"},
			{"ez", "erez", "iez", "âtre"},
			{"ent", "eront", "aient", "èrent"}
		};
		return terminaisons;
	}

	// Fonction : Radical
	// Entrée :	- verbe : chaîne de caractères
	// Sortie :	chaîne de caractères
	public static string Radical(string verbe)
	{
		string verbeSansParticule = "";
		
		// séparation de la particule (se)
		string[] morceaux = verbe.Split(" ");
		if (morceaux.Length == 2)
		{
			verbeSansParticule = morceaux[1];
		}
		else if (morceaux.Length == 1)
		{
			verbeSansParticule = morceaux[0];
		}

		// séparation de la particule (s')
		morceaux = verbeSansParticule.Split("'");
		if (morceaux.Length == 2)
		{
			verbeSansParticule = morceaux[1];
		}
		else if (morceaux.Length == 1)
		{
			verbeSansParticule = morceaux[0];
		}

		// retirer les deux derniers caractères (er)
		verbeSansParticule = verbeSansParticule.Substring(0, verbeSansParticule.Length - 2);
		return verbeSansParticule;
	}

	// Fonction : TypeVerbe
	// Entrée :	- verbe : chaîne de caractères
	// Sortie :	entier
	public static int TypeVerbe(string verbe)
	{
		int type = 0;	// 0 = commence par une consonne (choix le plus courant, par défaut)
		if (verbe[0] == 'a' || verbe[0] == 'e' || verbe[0] == 'i' || verbe[0] == 'o' || verbe[0] == 'u' || verbe[0] == 'y')
		{
			type = 1;	// commence par une voyelle
		}
		else if (verbe.Substring(0, 3) == "se ")
		{
			type = 2;	// commence par se (puis un espace sinon separer ne fonctionne pas)
		}
		else if (verbe.Substring(0, 2) == "s'")
		{
			type = 3;	// commence par s'
		}
		return type;
	}

	// structure Verbe
	public struct Verbe
	{
		public string _verbe;
		public string _radical;
		public int _type;

		// Constructeur
		public Verbe(string verbe, string radical, int type)
		{
			_verbe = verbe;
			_radical = radical;
			_type = type;
		}

		// Affichage
		public override string ToString()
		{
			return "Verbe { verbe = " + _verbe + ", radical = " + _radical + ", type = " + _type + " }";
		}
	}
	
	// Fonction :	LireVerbes
	// Entrée :	- chemin : chaîne de caractères
	// Sortie :	tableau 1D de structure Verbe
	public static Verbe[] LireVerbes(string chemin)
	{
		// solution avec double lecture :
		// - la première compte le nombre de lignes (et donc de verbes)
		// - la seconde lit les lignes et rempli le tableau
		FileStream fs = new FileStream(chemin, FileMode.Open, FileAccess.Read);
		StreamReader reader = new StreamReader(fs);
		int n = 0;
		string ligne;
		while (!reader.EndOfStream)
		{
			ligne = reader.ReadLine();
			n++;	// compter +1
		}
		
		// création du tableau de n Verbe
		Verbe[] verbes = new Verbe[n];
		int position = 0;
		
		// retour au début du fichier, positionnement de la tête de lecture
		reader.DiscardBufferedData();
		reader.BaseStream.Seek(0, SeekOrigin.Begin);
		
		// lecture ligne par ligne en stockant les verbes
		while (!reader.EndOfStream)
		{
			ligne = reader.ReadLine();
			Verbe verbe = new Verbe(ligne, Radical(ligne), TypeVerbe(ligne));
			verbes[position++] = verbe;	// ajoute le verbe dans la case position puis fait position + 1 (après)
		}
		
		reader.Close();
		
		return verbes;
	}
	
	// Procédure :	LireVerbeAvecVerification
	// Entrée :	- chemin : chaîne de caractères
	//			- référence verbes : tableau 1D de chaînes de caractères
	// Sortie :	void
	public static void LireVerbeAvecVerification(string chemin, ref Verbe[] verbes)
	{
		if (File.Exists(chemin))
		{
			verbes = LireVerbes(chemin);
		}
		// sinon le tableau verbes n'est pas rempli
	}

	public static void Main()
	{
		const string FICHIER_VERBES = "lesVerbesDuPremierGroupe.txt";
		string[,] lesPronoms = CreerPronoms();
		string[,] lesTerminaisons = CreerTerminaisons();
		Verbe[] verbes = null;
		
		// charger les verbes depuis le fichier
		LireVerbeAvecVerification(FICHIER_VERBES, ref verbes);
		
		// menu
		bool menu = true;
		string saisie;
		int indiceVerbe;
		int indiceTemps;
		int choix;
		
		do
		{
			Console.WriteLine("\n\nConjugaison des verbes du premier degré");
			Console.WriteLine("---------------------------------------------");
			Console.WriteLine("1 - Afficher tous les verbes");
			Console.WriteLine("2 - Rechercher un verbe spécifique");
			Console.WriteLine("3 - Quitter");
			// saisie blindée du choix
			do 
			{	
				do
				{
					Console.Write("\nSaisir le choix : ");
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 1);
				choix = int.Parse(saisie);
			}
			while (choix < 0 || choix > 3);
			
			switch (choix)
			{
				case 1:
					for (int i = 0; i < verbes.Length; i++)
					{
						Console.WriteLine($"\t{i} - {verbes[i]._verbe}");
					}
					break;
					
				case 2:
					do 
					{
						Console.Write("\nSaisir les premières lettre du verbe à rechercher (chaîne vide pour quitter) : ");
						saisie = Console.ReadLine();
					}
					while (saisie.Length < 1);
					// recherche des verbes commeçant par la saisie
					for (int i = 0; i < verbes.Length; i++)
					{
						if (verbes[i]._verbe.StartsWith(saisie))
						{
							Console.WriteLine($"\t{i} - {verbes[i]._verbe}");
						}
					}
					// saisie blindée du numéro du verbe
					do
					{
						do
						{
							Console.Write("\nSaisir le numéro du verbe à traiter : ");
							saisie = Console.ReadLine();
						}
						while (saisie.Length < 1);
						indiceVerbe = int.Parse(saisie);
					}
					while (indiceVerbe < 0 || indiceVerbe >= verbes.Length);
					
					// saisie blindée du temps de conjugaison
					Console.WriteLine("\n1 - Présent");
					Console.WriteLine("2 - Futur");
					Console.WriteLine("3 - Imparfait");
					Console.WriteLine("4 - Passé simple");
					do
					{
						do
						{
							Console.Write("Choisir le numéro du temps de conjugaison : ");
							saisie = Console.ReadLine();
						}
						while (saisie.Length < 1);
						indiceTemps = int.Parse(saisie) - 1;	// -1 pour l'indexation dans les tableaux
					}
					while (indiceTemps < 0 || indiceTemps >= lesTerminaisons.GetLength(1));
					// affichage du résultat (pour tous les pronoms, le temps choisi)
					Console.WriteLine("");
					for (int i = 0; i < lesPronoms.GetLength(0); i++)
					{
						Console.WriteLine($"{lesPronoms[i, verbes[indiceVerbe]._type]} {verbes[indiceVerbe]._radical}{lesTerminaisons[i, indiceTemps]}");
					}
					break;
				default :
					menu = false;
					break;
			}
		}
		while (menu);
	}
}
