// auteur : Romain PERRIN
// notes : utiliser BigInteger pour Factorielle et PParmiN
// remarque : pour la compilation, lancer la commande 'mono exo_3.cs -r:System.Numerics.dll'

using System;
using System.Numerics;

class Structures
{
	public struct Lotterie{
		public string nom;	// nom de la lotterie
		public int nMaxSerie1;	// nombre de numéros possibles à la première série
		public int nSerie1; // nombre de numéros tirés à la première série
		public int nMaxSerie2; // nombre de numéros possibles à la seconde série
		public int nSerie2; // nombre de numéros tités à la seconde série
		public BigInteger probaRang1; // probabilité de gagner au rang 1
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
	}
}