// Auteur : Romain PERRIN

using System;

class Exercice5
{
	const int TAILLE_PALIERS = 5;   // variable globale

	// Procédure : AfficherChaine
	// Entrée :     - chaine : chaîne de caractères
	// Type de sortie :	void
	public static void AfficherChaine(string chaine)
	{
		Console.Write($"{chaine}");
	}

	// Fonction : SaisirEntier
	// Entrée :		/
	// Type de sortie :	- n : entier
	public static int SaisirEntier()
	{
		int n = int.Parse(Console.ReadLine());
		return n;
	}

	// Fonction : ChercherIndiceDuree
	// Entrée :		- durees : tableau 1D de tailleDurees entiers
	//				- tailleDurees : entier
	// 				- duree : entier 
	// Type de sortie :	entier
	public static int ChercherIndiceDuree(int[] durees, int tailleDurees, int duree)
	{
		int indice = 0;
		while (indice < tailleDurees)
		{
			if (durees[indice] >= duree)
			{
				return indice;
			}
			indice++;
		}
		return -1;	// erreur
	}

	// Procédure : AfficherPaliers
	// Entrée :		- duree : entier
	//				- durees : tableau 1D de tailleDurees entiers
	//				- tailleDurees : entier
	//				- attentes : tableau2D de TAILLE_PALIERS * tailleDurees entier
	// Type de sortie :	void
	public static void AfficherPaliers(int duree, int[] durees, int tailleDurees, int[,] attentes)
	{
		// générer le tableau des paliers
		int[] paliers = new int[TAILLE_PALIERS]{3, 6, 9, 12, 15};

		// vérifier la validité de la durée (<= 55)
		if (duree < 0)
		{
			AfficherChaine($"Erreur : une durée de mois de 0 minutes n'est pas autorisée (durée fournie : {duree}).\n");
		}
		else if (duree > 55)
		{
			AfficherChaine($"Erreur : une durée de plus de 55 minutes n'est pas autorisée (durée fournie : {duree}).\n");
		}
		else
		{
			int indice = ChercherIndiceDuree(durees, tailleDurees, duree);
			if (indice != -1)
			{
				// parcourir la colonne de bas en haut
				int dureePalier = 0;
				int profondeurPalier = 0;
				int somme = 0;
				for (int i = TAILLE_PALIERS - 1; i >= 0; i--)
				{
					profondeurPalier = paliers[i];
					dureePalier = attentes[i, indice];
					somme += dureePalier;
					AfficherChaine($"Attendre {dureePalier} minutes à {profondeurPalier} mètres\n");
				}
				// affichage du temps total
				AfficherChaine($"Soit une durée cumulée de {somme} minutes ({somme / 60:D2}:{somme % 60:D2}).\n");
			}
		}
	}

	public static void Main()
	{
		// données
		const int TAILLE_DUREES = 11;
		int[] durees = new int[TAILLE_DUREES]{5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55};
		int[,] attentes = new int[TAILLE_PALIERS, TAILLE_DUREES]{
			{2, 6, 19, 32, 41, 48, 54, 62, 69, 78, 88},
			{0, 2, 4, 8, 15, 22, 28, 30, 35, 37, 40},
			{0, 0, 1, 3, 5, 8, 11, 17, 19, 22, 24},
			{0, 0, 0, 0, 0, 1, 4, 6, 9, 13, 15},
			{0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 5}
		};

		// saisir la durée en minutes
		AfficherChaine("Saisir la durée de la plongée : ");
		int dureeUtilisateur = SaisirEntier();

		// appeler la procédure AfficherPaliers
		AfficherPaliers(dureeUtilisateur, durees, TAILLE_DUREES, attentes);
	}
}