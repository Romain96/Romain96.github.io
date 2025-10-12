// Auteur : Romain PERRIN

using System;

class Exercice4
{
	// Fonction : SommeLigne
	// Entrée : - tab : tableau2D d'entiers
	//			- ligne : entier
	// Type de sortie : entier
	public static int SommeLigne(int[,] tab, int ligne)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(1); i++)
		{
			somme += tab[ligne, i];
		}
		return somme;
	}
	
	// Fonction : SommeColonne
	// Entrée : - tab : tableau2D d'entiers
	//			- colonne : entier
	// Type de sortie : entier
	public static int SommeColonne(int[,] tab, int colonne)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i, colonne];
		}
		return somme;
	}
	
	// Fonction : SommeDiagonale1
	// Entrée : - tab : tableau2D d'entiers
	// Type de sortie : entier
	public static int SommeDiagonale1(int[,] tab)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i,i];
		}
		return somme;
	}
	
	// Fonction : SommeDiagonale2
	// Entrée : - tab : tableau2D d'entiers
	// Type de sortie : entier
	public static int SommeDiagonale2(int[,] tab)
	{
		int somme = 0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			somme += tab[i,  tab.GetLength(0) - 1 - i];
		}
		return somme;
	}
	
	// Fonction : VerifierCarreMagique
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : booléen
	public static bool VerifierCarreMagique(int[,] tab)
	{
		// vérification des diagonales
		int somme = SommeDiagonale1(tab);
		if (SommeDiagonale2(tab) != somme)
		{
			return false;
		}
		
		// vérification des lignes
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			if (SommeLigne(tab, i) != somme)
			{
				return false;
			}
		}
		
		// vérification des colonnes
		for (int i = 0; i < tab.GetLength(1); i++)
		{
			if (SommeColonne(tab, i) != somme)
			{
				return false;
			}
		}
		
		// tous les tests sont passés, c'est un carré magique !
		return true;
	}
	
	// Fonction : InitTab
	// Entrée :	- taille : entier
	// Type de sortie : tableau 2D d'entiers
	public static int[,] InitTab(int taille)
	{
		int[,] tab = new int[taille, taille];
		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				tab[i, j] = 0;
			}
		}
		return tab;
	}
	
	// Procédure : AfficherTableau2D
	// Entrée :	- tab : tableau 2D d'entiers
	// Type de sortie : void
	public static void AfficherTableau2D(int[,] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				Console.Write($"{tab[i,j]} ");
			}
			Console.Write("\n");
		}
	}
	
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Fonction : ConstruireCarreMagique
	// Entrée :	- taille : entier
	// Type de sortie : tableau 2D d'entiers
	public static int[,] ConstruireCarreMagique(int taille)
	{
		int[,] tab = InitTab(taille);
		
		// positionner le 1 au-dessus du centre
		int centre = taille / 2;
		int ligne = centre - 1;
		int colonne = centre;
		tab[ligne, colonne] = 1;
		
		// prochain numéro à insérer dans le tableau en ligne, colonne
		int valeur = 2;
		bool insere = true;
		
		while(valeur <= taille * taille)
		{
			if (insere)
			{
				// calcul du prochain emplacement (ligne, colonne) pour insertion
				ligne -= 1;
				colonne += 1;
			}
			
			// exception : sortie par le haut
			if (ligne < 0 && colonne < taille)
			{
				ligne = taille - 1;	// retour à la dernière ligne
			}
			
			// exception : sortie par la droite
			if (ligne >= 0 && ligne < taille && colonne == taille)
			{
				colonne = 0;	// retour à la première colonne
			}
			
			// exception : sortie par la diagonale supérieure droite
			if (ligne == -1 && colonne == taille)
			{
				// recherche de la première case libre de la colonne de droite
				int i = taille - 1;
				int j = taille - 1;
				while(i >= 0 && tab[i, j] > 0)
				{
					i--;
				}
				ligne = i;
				colonne = j;
			}
			
			// exception : la case (ligne, colonne) est déjà remplie
			if (tab[ligne, colonne] > 0)
			{
				ligne -= 1;
				colonne -= 1;
			}
			
			insere = false;
			if (ligne >= 0 && ligne <= taille - 1 && colonne >= 0 && colonne <= taille - 1)
			{
				// remplissage de la case (ligne, colonne) avec valeur
				tab[ligne, colonne] = valeur;
				valeur += 1;
				insere = true;
			}
		}
		
		return tab;
	}
	
	public static void Main()
	{
		int taille;
		do
		{
			taille = SaisirEntier("Saisir la taille du carré magique (entier positif impair) : ");
		}
		while (taille % 2 == 0 || taille <= 1);
		
		int[,] cm = ConstruireCarreMagique(taille);
		AfficherTableau2D(cm);
		Console.WriteLine($"Le tableau est un carré magique : {VerifierCarreMagique(cm)}");
	}
}
