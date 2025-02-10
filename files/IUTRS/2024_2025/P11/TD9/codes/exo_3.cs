// Auteur : Romain PERRIN

using System;
using System.Numerics;	// compilation : mcs exo_3.exe -r:System.Numerics.dll
using System.IO;
using System.Text;

class LotterieStructureIO
{
	public struct Lotterie{
		public string nom;	// nom de la lotterie
		public int nMaxSerie1;	// nombre de numéros possibles à la première série
		public int nSerie1; // nombre de numéros tirés à la première série
		public int nMaxSerie2; // nombre de numéros possibles à la seconde série
		public int nSerie2; // nombre de numéros tités à la seconde série
		public BigInteger probaRang1; // probabilité de gagner au rang 1

		public override string ToString()
		{
			return $"Structure Lotterie :\n\tnom = {nom}\n\tSerie 1 : {nSerie1} parmi {nMaxSerie1}\n\tSerie 2 : {nSerie2} parmi {nMaxSerie2}\n\tProba rang 1 : 1 sur {probaRang1}";
		}
	};

	// Fonction : Factorielle
	// Précondition : n >= 0
	// Entrée :		- n : entier
	// Local :		- i : entier
	// Sortie :		- fact : entier
	public static BigInteger Factorielle(int n)
	{
		BigInteger fact = 1;
		for (BigInteger i = 2; i <=  (BigInteger) n; i++)
		{
			fact = fact * i;
		}
		return fact;
	}

	// Fonction : PParmiN
	// Principe : calcule la probabilité d'obtenir P bon numéros parmi N boules en utilisant la formule proba = N! / (P! * (N-P)!)
	// Précondition : p > 0, N > 0
	// Entrée :		- P : entier
	//				- N : entier
	// Local :		/
	// Sortie :		- proba : entier
	public static BigInteger PParmiN(int p, int n)
	{
		BigInteger proba = Factorielle(n) / (Factorielle(p) * Factorielle(n - p));
		return proba;
	}

	// Fonction : SaisirEntier
	// Entrée :		- texte : chaîne de caractères
	// Local :		/
	// Sortie :		- n : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		int n = int.Parse(Console.ReadLine());
		return n;
	}

	// Fonction : SaisirChaine
	// Entrée :		- texte : chaîne de caractères
	// Local :		/
	// Sortie :		- chaine : chaîne de caractères
	public static string SaisirChaine(string texte)
	{
		Console.Write(texte);
		string chaine = Console.ReadLine();
		return chaine;
	}

	// Fonction : CreerListeJeux
	// Entrée :		- n : entier (modifiable)
	// Local :		- i : entier
	//				- nomJeu : chaîne de caractères
	// Sortie :		- listeJeux : tableau de n chaînes de caractères
	public static string[] CreerListeJeux(ref int n)
	{
		n = -1;
		while (n <= 0)
		{
			n = SaisirEntier("Entrer le nombre de jeux : ");
		}
		string[] listeJeux = new string[n];
		string nomJeu = "";
		for (int i = 0; i < n; i++)
		{
			nomJeu = SaisirChaine($"Entrer le nom du {i+1}e jeu : ");
			listeJeux[i] = nomJeu;
		}
		return listeJeux;
	}

	// Procédure : InitTabLotteries
	// Précondition : tailleTabLotteries == tailleListeJeux
	// Principe : initialise le champ "nom" de la structure Lotterie pour chaque jeu
	// Entrée :		- tabLotteries : tableau de tailleTabLotteries structures Lotterie
	//				- tailleTabLotteries : entier
	//				- listeJeux : tableau de tailleListeJeux chaînes de caractères
	//				- tailleListeJeux : entier
	// Local :		- i : entier
	// Sortie :		/
	public static void InitTabLotteries(Lotterie[] tabLotteries, int tailleTabLotteries, string[] listeJeux, int tailleListeJeux)
	{
		for (int i = 0; i < tailleTabLotteries; i++)
		{
			tabLotteries[i].nom = listeJeux[i];
		}
	}

	// Procédure : CompleterTabLotteries
	// Principe : initialise les 4 autres champs de la structure Lotterie pour chaque jeu
	// Entrée :		- tabLotteries : tableau de tailleTabLotteries structures Lotterie
	//				- tailleTabLotteries : entier
	// Local :		- i : entier
	//				- nMaxSerie1 : entier
	//				- nSerie1 : entier
	//				- nMaxSerie2 : entier
	//				- nSerie1 : entier
	// Sortie :		/
	public static void CompleterTabLotteries(Lotterie[] tabLotteries, int tailleTabLotteries)
	{
		int nMaxSerie1 = 0;
		int nSerie1 = 0;
		int nMaxSerie2 = 0;
		int nSerie2 = 0;
		for (int i = 0; i < tailleTabLotteries; i++)
		{
			nMaxSerie1 = SaisirEntier($"Entrer le nombre de numéros possibles pour la série 1 de {i+1}e jeu : ");
			nSerie1 = SaisirEntier($"Entrer le nombre de numéros tirés pour la série 1 de {i+1}e jeu : ");
			nMaxSerie2 = SaisirEntier($"Entrer le nombre de numéros possibles pour la série 2 de {i+1}e jeu : ");
			nSerie2 = SaisirEntier($"Entrer le nombre de numéros tirés pour la série 2 de {i+1}e jeu : ");
			tabLotteries[i].nMaxSerie1 = nMaxSerie1;
			tabLotteries[i].nSerie1 = nSerie1;
			tabLotteries[i].nMaxSerie2 = nMaxSerie2;
			tabLotteries[i].nSerie2 = nSerie2;
		}
	}

	// Procédure : AjoutProbaTabLotteries
	// Principe : calcule et initialise le champ "probaRang1" de la structure Lotterie pour chaque jeu
	// Entrée :		- tabLotteries : tableau de tailleTabLotteries structures Lotterie
	//				- tailleTabLotteries : entier
	// Local :		- i : entier
	// Sortie :		/
	public static void AjoutProbaTabLotteries(Lotterie[] tabLotteries, int tailleTabLotteries)
	{
		for (int i = 0; i < tailleTabLotteries; i++)
		{
			tabLotteries[i].probaRang1 = PParmiN(tabLotteries[i].nSerie1, tabLotteries[i].nMaxSerie1) * PParmiN(tabLotteries[i].nSerie2, tabLotteries[i].nMaxSerie2);
		}
	}

	// Procédure : SauverStructLotterie
	// Entrée :		- lotterie : structure Lotterie
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux d'écriture
	// Sortie :		void
	public static void SauverStructLotterie(Lotterie lotterie, string chemin)
	{
		// ouverture du flux d'écriture
		StreamWriter writer = new StreamWriter(chemin);

		// sauvegarde de chaque champ dans l'ordre
		// -> nom (string), nMaxSerie1 (int), nSerie1 (int), nMaxSerie2 (int), nSerie2 (int), probaRang1 (BigInteger)
		writer.Write($"{lotterie.nom},");
		writer.Write($"{lotterie.nMaxSerie1.ToString()},");
		writer.Write($"{lotterie.nSerie1.ToString()},");
		writer.Write($"{lotterie.nMaxSerie2.ToString()},");
		writer.Write($"{lotterie.nSerie2.ToString()},");
		writer.WriteLine($"{lotterie.probaRang1.ToString()}");

		// fermeture du flux
		writer.Close();
	}

	// Procédure : SauverTableauStructLotterie
	// Entrée :		- lotteries : tableau 1D de structure Lotterie
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux d'écriture
	// Sortie :		void
	public static void SauverTableauStructLotterie(Lotterie[] lotteries, string chemin)
	{
		// ouverture du flux d'écriture
		StreamWriter writer = new StreamWriter(chemin);

		// écriture du nombre de lignes
		writer.WriteLine($"{lotteries.Length}");

		// sauvegarder chaque Lotterie sur une ligne
		for (int i = 0; i < lotteries.Length; i++)
		{
			// sauvegarde de chaque champ dans l'ordre
			// -> nom (string), nMaxSerie1 (int), nSerie1 (int), nMaxSerie2 (int), nSerie2 (int), probaRang1 (BigInteger)
			writer.Write($"{lotteries[i].nom},");
			writer.Write($"{lotteries[i].nMaxSerie1.ToString()},");
			writer.Write($"{lotteries[i].nSerie1.ToString()},");
			writer.Write($"{lotteries[i].nMaxSerie2.ToString()},");
			writer.Write($"{lotteries[i].nSerie2.ToString()},");
			writer.WriteLine($"{lotteries[i].probaRang1.ToString()}");
		}

		// fermeture du flux
		writer.Close();
	}

	// Fonction : ChargerStructLotterie
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- reader : flux de lecture
	// Sortie :		lotterie : structure lotterie
	public static Lotterie ChargerStructLotterie(string chemin)
	{
		// ouverture du flux de lecture
		StreamReader reader = new StreamReader(chemin);

		// création de la structure
		Lotterie lotterie = new Lotterie();

		// lecture de la ligne
		string line = reader.ReadLine();
		string[] details = line.Split(',');

		// remplissage des champs dans l'ordre
		lotterie.nom = details[0];	// string
		lotterie.nMaxSerie1 = int.Parse(details[1]);	// int donc conversion
		lotterie.nSerie1 = int.Parse(details[2]);	// int donc conversion
		lotterie.nMaxSerie2 = int.Parse(details[3]);	// int donc conversion
		lotterie.nSerie2 = int.Parse(details[4]);	// int donc conversion
		lotterie.probaRang1 = BigInteger.Parse(details[5]);	// BigInteger donc conversion

		// fermeture du flux
		reader.Close();
		return lotterie;
	}

	// Fonction : ChargerTableauStructLotterie
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- reader : flux de lecture
	// Sortie :		lotteries : tableau 1D de structure lotterie
	public static Lotterie[] ChargerTableauStructLotterie(string chemin)
	{
		// ouverture du flux de lecture
		StreamReader reader = new StreamReader(chemin);

		// lecture du nombre de lignes sur la première ligne
		string line = reader.ReadLine();
		int taille = int.Parse(line);

		// création de la structure
		Lotterie[] lotteries = new Lotterie[taille];

		// lecture de chaque ligne (une ligne = une lotterie)
		int i = 0;
		while ((line = reader.ReadLine()) != null)
		{
			string[] details = line.Split(',');
			lotteries[i] = new Lotterie();
			// remplissage des champs de la ième structure dans l'ordre
			lotteries[i].nom = details[0];	// string
			lotteries[i].nMaxSerie1 = int.Parse(details[1]);	// int donc conversion
			lotteries[i].nSerie1 = int.Parse(details[2]);	// int donc conversion
			lotteries[i].nMaxSerie2 = int.Parse(details[3]);	// int donc conversion
			lotteries[i].nSerie2 = int.Parse(details[4]);	// int donc conversion
			lotteries[i].probaRang1 = BigInteger.Parse(details[5]);	// BigInteger donc conversion
			i++;
		}

		// fermeture du flux
		reader.Close();
		return lotteries;
	}
	
	public static void Main()
	{
		// tableau pour stocker 10 lotteries
		const int tailleTabLotteries = 10;
		Lotterie[] tabLotteries = new Lotterie[tailleTabLotteries];
		int tailleListeJeux = 0;
		string[] listeJeux = CreerListeJeux(ref tailleListeJeux);
		InitTabLotteries(tabLotteries, tailleTabLotteries, listeJeux, tailleListeJeux);
		CompleterTabLotteries(tabLotteries, tailleTabLotteries);
		AjoutProbaTabLotteries(tabLotteries, tailleTabLotteries);
		// flemme d'afficher dans l'ordre décroissant, tri du tableau et affichage
		Array.Sort(tabLotteries, (x, y) => x.probaRang1.CompareTo(y.probaRang1));
		for (int i = 0; i < tailleTabLotteries; i++)
		{
			Console.WriteLine($"{tabLotteries[i].nom} probabilité au rang 1 = 1/{tabLotteries[i].probaRang1}.");
		}

		// test : sauvegarde de la première structure
		string chemin = "lotterie.txt";
		Console.WriteLine($"Sauvegarde de la première lotterie dans {chemin}.");
		SauverStructLotterie(tabLotteries[0], chemin);
		// lecture de la première lotterie
		Console.WriteLine($"Chargement de la première lotterie depuis {chemin}.");
		Lotterie test = ChargerStructLotterie(chemin);
		Console.WriteLine(test);

		// sauvegarde des toutes les lotteries
		chemin = "lotteries.txt";
		Console.WriteLine($"Sauvegarde des lotteries dans {chemin}.");
		SauverTableauStructLotterie(tabLotteries, chemin);
		// chargement de toutes les lotteries
		Console.WriteLine($"Chargement des lotteries depuis {chemin}.");
		Lotterie[] toutesLesLotteries = ChargerTableauStructLotterie(chemin);
		for (int i = 0; i < toutesLesLotteries.Length; i++)
		{
			Console.WriteLine(toutesLesLotteries[i]);
		}
	}
}