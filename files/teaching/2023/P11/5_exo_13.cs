// Auteur : Romain PERRIN

using System;

class Exercice13
{
	// Procédure : parsing d'un entier depuis la console
	// Paramètres :
	// 	- chaine (string): chaine à afficher à l'utilisateur
	// Retourne : n (int): entier lu et converti depuis la console
	public static int LireEntier(string chaine)
	{
		Console.Write(chaine);
		return int.Parse(Console.ReadLine());
	}
	
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
	
	// Fonction : remplissage d'un sous-tableau tableau avec des entiers alétoires
	// Paramètres :
	// 	- tab (int[]) tableau d'entiers
	// 	- entier_min (int): entier alétoire minimal
	// 	- entier_max (int): entier alétoire maximal
	//	- n (int): taille du sous-tableau à affecter (cases de 0 à n-1)
	// Retourne : rien, modification du tableau `tab` par effets de bord
	// Note : si n > tab.Length alors tout le tableau est initialisé
	public static void RemplirAleatoirePartiel(int[] tab, int entier_min, int entier_max, int n)
	{
		if (n > tab.Length)
			RemplirAleatoire(tab, entier_min, entier_max);
		else
		{
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				tab[i] = rnd.Next(entier_min, entier_max);
		}
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
	
	// Fonction : construction d'un tableau contenant les n premiers termes de la suite de Fibonacci
	// Paramètres :
	// 	- n (int): taille du tableau à générer
	// Retourne : fibo (int[]): tableau généré
	// Note : n doit être supérieur ou égal à 2
	public static int[] CreerTableauFibonacci(int n)
	{
		int[] fibo = new int[n];
		fibo[0] = 1;
		fibo[1] = 1;
		for (int i = 2; i < fibo.Length; i++)
			fibo[i] = fibo[i-1] + fibo[i-2];
		return fibo;
	}
	
	// Fonction : vérification de condition : le tableau est trié par ordre croissant
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// Retourne : trie (bool): vrai si `tab` est trié par ordre croissant, faux sinon
	public static bool EstTrieOrdreCroissant(int[] tab)
	{
		bool trie = true;
		int i = 1;
		while (i < tab.Length && trie)
		{
			if (tab[i] < tab[i-1])
			{
				trie = false;
			}
			i++;
		}
		return trie;
	}
	
	// Fonction : normalise un tableau d'entier entre une valeur plancher et une valeur plafond
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// 	- plancher (int): valeur plancher
	// 	- plafond (int): valeur plafond
	// Retourne : rien, modification de `tab` par effets de bord
	public static void Normaliser(int[] tab, int plancher, int plafond)
	{
		if (plancher > plafond)
		{
			AfficherChaine("Exercice8.Normaliser : le plancher " + plancher + " est supérieur au plafond " + plafond + "!");
			// permutation
			int tmp = plafond;
			plafond = plancher;
			plancher = tmp;
		}
		for (int i = 0; i < tab.Length; i++)
		{
			if (tab[i] < plancher)
				tab[i] = plancher;
			else if (tab[i] > plafond)
				tab[i] = plafond;
		}
	}
	
	// Fonction : tri à bulle sur tableau d'entiers (ordre croissant)
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	// Retourne : rien, modification de `tab` par effets de bord
	// Note : variante avec arrêt dès que le sous-tableau est trié (aucune permutation)
	public static void TriBullesCroissant(int[] tab)
	{
		int indice_fin = tab.Length - 1;
		int nb_permutations = -1;
		// trier le sous-tableau de 0 à n-i
		while (indice_fin > 0 && nb_permutations != 0)
		{
			nb_permutations = 0;
			for (int indice = 1; indice <= indice_fin; indice++)
			{
				// bulle [indice - 1, indice] à échanger ou non
				if (tab[indice-1] > tab[indice])
				{
					// échange
					int tmp = tab[indice-1];
					tab[indice-1] = tab[indice];
					tab[indice] = tmp;
					nb_permutations++;
				}
			}
			indice_fin--;
		}	
	}
	
	// Fonction : détermine l'indice d'insertion d'un entier dans un tableau dont la première partie est triée
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers dont les n premières valeurs sont triées (ordre croissant)
	//	- n (int): la taille du sous-tableau trié (cases de 0 à n-1)
	//	- val (int): valeur à insérer
	// Retourne : indice_insertion (int): l'indice dans `tab` où `val` doit être insérée afin de conserver `tab` trié
	public static int IndiceInsertionPartiellementTrie(int[] tab, int n, int val)
	{
		int indice_insertion = 0;
		int indice = 0;
		bool trouve = false;
		while (indice < n && !trouve)
		{
			if (tab[indice] > val)
			{
				indice_insertion = indice;
				trouve = true;
			}
			indice++;
		}
		if (!trouve)
			indice_insertion = n;
		return indice_insertion;
	}
	
	// Fonction : insertion d'un entier dans un tableau dont la première partie est triée et la position est donnée
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers dont les premières valeurs sont triées (ordre croissant)
	//	- n (int): le nombre de valeurs dans le tableau
	//	- indice (int): indice d'insertion de `val`
	//	- val (int): valeur à insérer
	// Retourne : rien, modification de `tab` par effets de bord
	public static void InsertionPartiellementTrie(int[] tab, int n, int indice, int val)
	{
		// décalage des valeurs à droite de la n-ième (position n-1) à la indice-ieme (position indice)
		// parcours de droite à gauche en copiant la valeur à gauche dans la case à sa droite
		for (int i = n; i > indice; i--)
		{
			tab[i] = tab[i-1];
		}
		
		// insertion de la valeur `val` à la position `index`
		tab[indice] = val;
	}

	// Fonction : recherche dichotomique d'un entier dans un tableau d'entiers trié par ordre croissant
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers
	//	- val (int): valeur à rechercher
	// Retourne : indice (int): indice de `val` dans `tab` ou -1 si non trouvé
	public static int RechercheDichotomique(int[] tab, int val)
	{
		int indice = -1;
		bool trouve = false;
		int debut = 0;
		int fin = tab.Length-1;
		int milieu = fin / 2;
		
		while (!trouve)
		{
			// regarder dans le sous-tableau de gauche
			if (val <= tab[milieu])
			{
				fin = milieu;
				if ((fin - debut) == 0)
				{
					if (tab[debut] == val)
					{
						indice = debut;
						trouve = true;
					}
					else
					{
						trouve = true;
					}
				}
				milieu = (fin + debut) / 2;
			}
			// regarder dans le sous-tableau de droite
			else
			{
				debut = milieu + 1;
				milieu = (fin + debut) / 2;
				if ((fin - debut) == 0)
				{
					if (tab[debut] == val)
					{
						indice = debut;
						trouve = true;
					}
					else
					{
						trouve = true;
					}
				}
			}
		}
		return indice;
	}
	
	static void Main()
	{
		// tableau trié
		int[] tab = {1,2,3,4,5,6,7,8,9,10};
		AfficherChaine("Tableau trié par ordre croissant.");
		AfficherTableau(tab);
		for (int i = -1; i < tab.Length + 1; i++)
		{
			int val_i = i+1;
			int indice_i = RechercheDichotomique(tab, val_i);
			AfficherChaine("La valeur " + val_i + " est à l'indice " + indice_i + " par recherche dichotomique.");
		}
	}
}
