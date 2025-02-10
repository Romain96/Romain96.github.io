// Auteur : Romain PERRIN

using System;

class Exercice4
{
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
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- chaine : chaîne de caractères
	public static string SaisirChaine()
	{
		return Console.ReadLine();
	}
	
	// Fonction : Palindrome
	// Principe : vérifie qu'une chaîne de caractères est un palindrome (le caractère à la position i est identique à celui en position taille - i).
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- i : entier
	// Sortie :		- estPalindrome : booléen
	public static bool Palindrome(string chaine)
	{
		bool estPalindrome = true;	// par défaut
		for (int i = 0 ; i < chaine.Length / 2 && estPalindrome; i++)
		{
			if (chaine[i] != chaine[chaine.Length - 1 - i])
			{
				estPalindrome = false;
			}
		}
		return estPalindrome;
	}

	// Fonction : CompareChainesMemeLongueur
	// Principe : vérifie que deux chaines de même longueur sont identiques (charactère i identique dans les deux chaines)
	// Précondition : longueur chaine1 == longueur chaine2
	// Entrée :		- chaine1 : chaîne de caractères
	//				- chaine2 : chaîne de caractères
	// Local :		- i : entier
	// Sortie :		- identiques : booléen
	public static bool CompareChainesMemeLongueur(string chaine1, string chaine2)
	{
		bool identiques = true;	// par défaut
		for (int i = 0 ; i < chaine1.Length && identiques; i++)
		{
			if (chaine1[i] != chaine2[i])
			{
				identiques = false;
			}
		}
		return identiques;
	}

	// Fonction : CompareChaines
	// Principe : vérifie que deux chaines de même longueur sont identiques sur leur partie congrue (charactère i identique dans les deux chaines)
	// Entrée :		- chaine1 : chaîne de caractères
	//				- chaine2 : chaîne de caractères
	// Local :		- i : entier
	//				- borneSup : entier
	// Sortie :		- identiques : booléen
	public static bool CompareChaines(string chaine1, string chaine2)
	{
		bool identiques = true;	// par défaut
		int borneSup = chaine1.Length;
		if (chaine2.Length < borneSup)
		{
			borneSup = chaine2.Length;
		}
		for (int i = 0 ; i < borneSup && identiques; i++)
		{
			if (chaine1[i] != chaine2[i])
			{
				identiques = false;
			}
		}
		return identiques;
	}

	// Procédure principale
	public static void Main()
	{
		// saisir une chaine, vérifier si c'est un palindrome en appelant la fonction Palindrome et afficher le résultat
		AfficherChaine("Saisir une chaîne (test de palindrome) : ");
		string chaineUtilisateur = SaisirChaine();
		bool chaineEstPalindrome = Palindrome(chaineUtilisateur);
		if (chaineEstPalindrome)
		{
			AfficherChaine($"La chaine '{chaineUtilisateur}' est un palindrome.\n");
		}
		else
		{
			AfficherChaine($"La chaine '{chaineUtilisateur}' n'est pas un palindrome.\n");
		}


		// définir deux chaines et vérifier si les chaines sont identiques (longueur identiques) en appelant la fonction CompareChainesMemeLongueur
		string chaineTest1 = "Une chaine de longueur 25";
		string chaineTest2 = "Une autre chaine de 25 c.";
		string chaineTest3 = "Une chaine de longueur 25";
		// test de la précondition avant l'appel
		if (chaineTest1.Length == chaineTest2.Length)
		{
			bool chainesIdentiques12 = CompareChainesMemeLongueur(chaineTest1, chaineTest2);
			AfficherChaine($"CompareChainesMemeLongueur : les chaines '{chaineTest1}' et '{chaineTest2}' sont identiques ? {chainesIdentiques12}.\n");
		}
		if (chaineTest1.Length == chaineTest3.Length)
		{
			bool chainesIdentiques13 = CompareChainesMemeLongueur(chaineTest1, chaineTest3);
			AfficherChaine($"CompareChainesMemeLongueur : les chaines '{chaineTest1}' et '{chaineTest3}' sont identiques ? {chainesIdentiques13}.\n");
		}

		// définir deux chaines et vérifier si les chaines sont identiques (longueur identiques) en appelant la fonction CompareChaines
		string chaineTest4 = "Une chaine banale";
		string chaineTest5 = "Une autre chaine";
		string chaineTest6 = "Une chaine banale mais plus longue";

		bool chainesIdentiques45 = CompareChaines(chaineTest4, chaineTest5);
		AfficherChaine($"CompareChaines : les chaines '{chaineTest4}' et '{chaineTest5}' sont identiques ? {chainesIdentiques45}.\n");

		bool chainesIdentiques46 = CompareChaines(chaineTest4, chaineTest6);
		AfficherChaine($"CompareChaines : les chaines '{chaineTest4}' et '{chaineTest6}' sont identiques ? {chainesIdentiques46}.\n");
	}
}