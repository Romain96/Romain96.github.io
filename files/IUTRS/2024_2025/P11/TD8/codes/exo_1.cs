// Auteur : Romain PERRIN

using System;

class CarreMagique
{
	// Fonction : EstCarreMagique
	// Précondition : tab est un tableau 2D avec longueur = largeur
	// Principe : vérifie si un tableau 2D d'entiers est un carré magique en calculant la somme de chaque ligne, colonne et diagonale
	// et en vérifiant que toutes sont égales entre elles.
	// Entrée :     - tab : tableau 2D d'entiers
	// Local :      - somme : entiers
	//              - sommeLocale : entier
	// Sortie :     - booléen
	public static bool EstCarreMagique(int[,] tab)
	{
		// valeur de référence
		int somme = 0, sommeLigne = 0, sommeColonne = 0, sommeDiagonale1 = 0, sommeDiagonale2 = 0;
		for (int colonne = 0; colonne < tab.GetLength(1); colonne++)
		{
			somme += tab[0, colonne];
		}

		// parcours des lignes et des colonnes
		for (int ligne = 0; ligne < tab.GetLength(0); ligne++)
		{
			sommeLigne = 0;
			sommeColonne = 0;
			for (int colonne = 0; colonne < tab.GetLength(1); colonne++)
			{
				sommeLigne += tab[ligne, colonne];
				sommeColonne += tab[colonne, ligne];
			}
			if (sommeLigne != somme || sommeColonne != somme)
			{
				return false;
			}
		}

		// parcours des diagonales principales
		for (int indice = 0; indice < tab.GetLength(1); indice++)
		{
			sommeDiagonale1 += tab[indice, indice];
			sommeDiagonale2 += tab[tab.GetLength(1) - 1 - indice, indice];
		}
		if (sommeDiagonale1 != somme || sommeDiagonale2 != somme)
		{
			return false;
		}

		return true;
	}

	// Fonction : CreerCarreMagique
	// Précondition : n > 0
	// Entrée :     - n : entier
	// Local :
	// Sortie :     - carreMagique : tableau 2D de n*n entiers
	public static int[,] CreerCarreMagique(int n)
	{
		int[,] carreMagique = new int[n,n];
		for (int ligne = 0; ligne < n; ligne++)
		{
			for (int colonne = 0; colonne < n; colonne++)
			{
				carreMagique[ligne, colonne] = -1;
			}
		}

		int i = 0;
		int j = n / 2;
		carreMagique[i, j] = 1;

  		for (int k = 2; k <= n * n;) 
  		{
			int inext = i - 1;
			int jnext = j + 1;

			// dépassent par la droite
			if (jnext == n)
			{
				jnext = 0;
			}
			// dépassement par le haut
			if(inext < 0)
			{
				inext = n - 1;
			}
			// case occupée
			if (carreMagique[inext, jnext] != -1)
			{
				inext = i + 1;
				if (inext >= n)
				{
					inext = 0;
				}
				jnext = j;
			}
			carreMagique[inext, jnext] = k;
			k++;
			i = inext;
			j = jnext;
		}

		return carreMagique;
	}

	// Fonction : SaisirEntier
	// Entrée :     - texte : chaîne de caractères
	// Local :      /
	// Sortie :     - n : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}

	// Procédure : AfficherCarreMagique
	// Entrée :     - carreMagique : tableau 2D d'entiers
	// Local :      - ligne, colonne : entiers
	// Sortie :     void
	public static void AfficherCarreMagique(int[,] carreMagique)
	{
		for (int ligne = 0; ligne < carreMagique.GetLength(0); ligne++)
		{
			for (int colonne = 0; colonne < carreMagique.GetLength(1); colonne++)
			{
				Console.Write($"{carreMagique[ligne, colonne]} ");
			}
			Console.Write("\n");
		}
		Console.Write("\n");
	}

	public static void Main()
	{
		int taille = 0;
		while (taille <= 0)
		{
			taille = SaisirEntier("Entrer la taille du carré magique : ");
		}
		int[,] carreM = CreerCarreMagique(taille);
		AfficherCarreMagique(carreM);
		Console.WriteLine($"Le tableau est un carré magique : {EstCarreMagique(carreM)}.");
	}
}