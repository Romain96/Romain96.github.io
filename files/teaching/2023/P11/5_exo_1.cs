// Auteur : Romain PERRIN

using System;

class Exercice1
{
	// Procédure : affichage d'un tableau d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// Retourne : rien
	public static void AfficherTableau(int[] tab)
	{
		Console.Write("[");
		for (int i = 0; i < tab.Length-1; i++)
			Console.Write(tab[i] + ", ");
		Console.Write(tab[tab.Length-1] + "]\n");	
	}
	
	// Procédure : affichage d'une chaine de caractères dans le terminal
	// Paramètres :
	// 	- chaine (string): chaine à afficher
	// Retourne : rien
	public static void AfficherChaine(string chaine)
	{
		Console.WriteLine(chaine);
	}

	// Fonction : remplissage d'un tableau avec des entiers alétoires
	// Paramètres :
	// 	- tab (int[]) tableau d'entiers
	// 	- entier_min (int): entier alétoire minimal
	// 	- entier_max (int): entier alétoire maximal
	// Retourne : rien, modification du tableau `tab` par effets de bord
	public static void RemplirAleatoire(int[] tab, int entier_min, int entier_max)
	{
		Random rnd = new Random();
		for (int i = 0; i < tab.Length; i++)
			tab[i] = rnd.Next(entier_min, entier_max);
	}

	static void Main()
	{
		// déclaration sans initialisation
		int[] t = new int[10];
		// affichage avant alétoire
		AfficherChaine("Tableau déclaré mais non initialisé.");
		AfficherTableau(t);
		// initialisation alétoire
		RemplirAleatoire(t, 0, 5);
		// affichage après alétoire
		AfficherChaine("Tableau initialisé aléatoirement.");
		AfficherTableau(t);
	}
}
