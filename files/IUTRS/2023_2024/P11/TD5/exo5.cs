// Auteur : Romain PERRIN

using System;

class Exercice5
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
	
	// Fonction : calcule la moyenne d'un tableau d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// Retourne : (double) la moyenne des entiers contenus dans le tableau `tab`
	public static double CalculerMoyenne(int[] tab)
	{
		double somme = 0.0;
		for (int i = 0; i < tab.Length; i++)
			somme += tab[i];
		double moyenne = somme / tab.Length;
		return moyenne;
	}
	
	// Fonction : comptage du nombre d'occurrences d'un entier dans un tableau d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// 	- n (int): entier à rechercher dans `tab`
	// Retourne: nb_occurrences (int) : le nombre d'occurrences de `n` dans `tab`
	public static int CompterOccurrences(int[] tab, int n)
	{
		int nb_occurrences = 0;
		for (int i = 0; i < tab.Length; i++)
		{
			if (tab[i] == n)
				nb_occurrences++;
		}
		return nb_occurrences;
	}
	
	// Fonction : retourne l'indice de la première occurrence d'un entier dans un tableau d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// 	- n (int): entier à rechercher
	// Retourne : indice (int): l'indice de la première occurrence de `n` dans `tab` ou -1 si non trouvé
	public static int IndicePremiereOccurrence(int[] tab, int n)
	{
		int indice = -1;
		bool trouve = false;
		int i = 0;
		while (i < tab.Length && trouve == false)
		{
			if (tab[i] == n)
			{
				indice = i;
				trouve = true;
			}
			else
			{
				i++;
			}
		}
		return indice;
	}
	
	// Fonction : recherche de la valeur maximale dans un tableau d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// Retourne : nmax (int): entier maximal dans `tab`
	// Note : le tableau doit être non vide
	public static int Maximum(int[] tab)
	{
		int nmax = tab[0];
		for (int i = 1; i < tab.Length; i++)
		{
			if (tab[i] > nmax)
			{
				nmax = tab[i];
			}
		}
		return nmax;
	}

	static void Main()
	{
		// déclaration sans initialisation
		int[] t = new int[10];
		// initialisation alétoire
		RemplirAleatoire(t, 0, 11);
		// affichage après alétoire
		AfficherChaine("Tableau initialisé aléatoirement.");
		AfficherTableau(t);
		// indice de la première occurrence de chaque élément (0-10)
		int valeur_max = Maximum(t);
		AfficherChaine("La plus grande valeur dans le tableau est " + valeur_max);
	}
}
