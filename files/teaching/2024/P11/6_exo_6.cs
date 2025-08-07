// Auteur : Romain PERRIN

using System;



class ExerciceSupplementaireChaines
{
	const int TAILLE_CHAINE_ZERO = 101;	// taille du tableau de caractères (paramètre global)

	// Procédure : AfficherChaine
	// Principe : Affiche un chaîne de caractères donnée dans la console
	// Précondition : /
	// Entrée :		- chaine : chaîne de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherChaine(string chaine)
	{
		Console.Write(chaine);
	}

	// Fonction : SaisirChaine
	// Entrée :		/
	// Local :		/
	// Sortie :		- chaine : chaîne de caractères
	public static string SaisirChaine()
	{
		return Console.ReadLine();
	}

	// Procédure : AfficherChaineTableau
	// Principe : Affiche un chaîne de caractères (sous forme de tableau de caractères) donnée dans la console
	// Précondition : /
	// Entrée :		- chaine : tableau de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherChaineTableau(char[] chaine)
	{
		for (int i = 0; i < chaine.Length && chaine[i] != '\0'; i++)
		{
			Console.Write($"{chaine[i]}");
		}
		Console.Write("\n");
	}

	// Fonction : CreerChaineZero
	// Principe : initialiser un tableau de TAILLE_CHAINE_ZERO caractères et recopier 
	// les caractères de la chaine en entrée (dans la limite de TAILLE_CHAINE_ZERO - 1) puis ajouter '\0'
	// Entrée :		- init : chaine de caractères
	// Local :		- i : entier
	// 				- borneSup : entier
	// Sortie :		- chaine : tableau 1D de TAILLE_CHAINE_ZERO caractères
	public static char[] CreerChaineZero(string init)
	{
		char[] chaine = new char[TAILLE_CHAINE_ZERO];
		int borneSup = TAILLE_CHAINE_ZERO;
		if (init.Length < borneSup)
		{
			borneSup = init.Length;
		}
		for (int i = 0; i < borneSup; i++)
		{
			chaine[i] = init[i];
		}
		chaine[borneSup] = '\0';
		return chaine;
	}

	// Fonction : ValideChaineZero
	// Principe : Parcourir le tableau de caractère jusqu'à trouver le caractère '\0' ou atteindre la fin. si trouvé alors valide sinon invalide.
	// Entrée :		- chaine : tableau 1D de TAILLE_CHAINE_ZERO caractères
	// Local :		- i : entier
	// Sortie :		- valide : booléen
	public static bool ValideChaineZero(char[] chaine)
	{
		bool valide = false;	// par défaut
		for (int i = 0; i < TAILLE_CHAINE_ZERO && !valide; i++)
		{
			if (chaine[i] == '\0')
			{
				valide = true;
			} 
		}
		return valide;
	}

	// Fonction : LongueurChaineZero
	// Principe : Parcourir le tableau de caractère jusqu'à trouver le caractère '\0' et retourner l'indice + 1.
	// Précondition : la chaine est une chaine zero valide
	// Entrée :		- chaine : tableau 1D de TAILLE_CHAINE_ZERO caractères
	// Local :		- i : entier
	// Sortie :		- longueur : entier
	public static int LongueurChaineZero(char[] chaine)
	{
		int longueur = 0;	// par défaut
		while (longueur < TAILLE_CHAINE_ZERO && chaine[longueur] != '\0')
		{
			longueur++;
		}
		return longueur;
	}

	// Fonction : ComparerChainesZero
	// Principe : Parcourir les tableaux de caractères et vérifier que toutes les cases au même indice sont identiques
	// Précondition : les deux chaines sont des chaines zero valides
	// Entrée :		- chaine1 : tableau 1D de TAILLE_CHAINE_ZERO caractères
	//				- chaine2 : tableau 1D de TAILLE_CHAINE_ZERO caractères
	// Local :		- i : entier
	// Sortie :		- identiques : booléen
	public static bool ComparerChainesZero(char[] chaine1, char[] chaine2)
	{
		bool identiques = true;	// par défaut
		if (LongueurChaineZero(chaine1) != LongueurChaineZero(chaine2))
		{
			identiques = false;
		}
		else
		{
			for (int i = 0; i < LongueurChaineZero(chaine1) && identiques; i++)
			{
				if (chaine1[i] != chaine2[i])
				{
					identiques = false;
				}
			}
		}
		return identiques;
	}

	// Procédure principale
	public static void Main()
	{
		// tester une chaine valide et une chaine invalide
		char[] chaineValide = CreerChaineZero("chaine valide");
		char[] chaineInvalide = CreerChaineZero("chaine invalide");
		// rendre la chaine invalide en éliminant tous les '\0' jusqu'à la fin de la chaine/tableau
		for (int i = 15; i < TAILLE_CHAINE_ZERO; i++)
		{
			chaineInvalide[i] = '.';
		}

		AfficherChaine("Chaine 1 : ");
		AfficherChaineTableau(chaineValide);
		AfficherChaine($"La chaîne est valide ? {ValideChaineZero(chaineValide)}.\n");

		AfficherChaine("Chaine 2 : ");
		AfficherChaineTableau(chaineInvalide);
		AfficherChaine($"La chaîne est valide ? {ValideChaineZero(chaineInvalide)}.\n");
		AfficherChaine("\n\n");

		// longueurs
		// test de la préconditon
		AfficherChaine("Chaine 1 : ");
		AfficherChaineTableau(chaineValide);
		if (ValideChaineZero(chaineValide))
		{
			AfficherChaine($"Longueur de la chaîne 1 : {LongueurChaineZero(chaineValide)}.\n");
		}
		else
		{
			AfficherChaine($"Impossible d'appeler la fonction LongueurChaineZero, la chaîne n'est pas valide !\n");
		}

		AfficherChaine("Chaine 2 : ");
		AfficherChaineTableau(chaineInvalide);
		if (ValideChaineZero(chaineInvalide))
		{
			AfficherChaine($"Longueur de la chaîne 1 : {LongueurChaineZero(chaineInvalide)}.\n");
		}
		else
		{
			AfficherChaine($"Impossible d'appeler la fonction LongueurChaineZero, la chaîne n'est pas valide !\n");
		}
		AfficherChaine("\n\n");

		// identiques
		char[] chaine1 = CreerChaineZero("une petite chaîne");
		char[] chaine2 = CreerChaineZero("une petite chaîne de taille différente");

		AfficherChaine($"Chaine 1 : ");
		AfficherChaineTableau(chaine1);
		AfficherChaine($"Chaine 2 : ");
		AfficherChaineTableau(chaine2);
		// test de la précondition
		if (ValideChaineZero(chaine1) && ValideChaineZero(chaine2))
		{
			AfficherChaine($"Les chaînes sont identiques : {ComparerChainesZero(chaine1, chaine2)}.\n");
		}
		else
		{
			AfficherChaine("Impossible d'appeler la fonction ComparerChainesZero car au moins une des chaînes n'est pas valide!\n");
		}

		AfficherChaine($"Chaine 1 : ");
		AfficherChaineTableau(chaine1);
		AfficherChaine($"Chaine 2 : ");
		AfficherChaineTableau(chaine1);
		// test de la précondition
		if (ValideChaineZero(chaine1) && ValideChaineZero(chaine1))
		{
			AfficherChaine($"Les chaînes sont identiques : {ComparerChainesZero(chaine1, chaine1)}.\n");
		}
		else
		{
			AfficherChaine("Impossible d'appeler la fonction ComparerChainesZero car au moins une des chaînes n'est pas valide!\n");
		}

		AfficherChaine($"Chaîne 1 : ");
		AfficherChaineTableau(chaine1);
		AfficherChaine($"Chaîne 2 : ");
		AfficherChaineTableau(chaineInvalide);
		// test de la précondition
		if (ValideChaineZero(chaine1) && ValideChaineZero(chaineInvalide))
		{
			AfficherChaine($"Les chaînes sont identiques : {ComparerChainesZero(chaine1, chaineInvalide)}.\n");
		}
		else
		{
			AfficherChaine("Impossible d'appeler la fonction ComparerChainesZero car au moins une des chaînes n'est pas valide!\n");
		}
	}
}