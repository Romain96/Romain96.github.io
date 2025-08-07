// Auteur : Romain PERRIN

using System;

class Exercice1InverseReel
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

	// Fonction : SaisirReel
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- n : reel
	public static double SaisirReel()
	{
		return double.Parse(Console.ReadLine());
	}

	// Fonction : Inverse
	// Précondition : x != 0
	// Entrée :		- x : réel
	// Local :		/
	// Sortie :		- xInverse : reel
	public static double Inverse(double x)
	{
		double xInverse = 1 / x;
		return xInverse;
	}

	// Fonction : Inverse
	// Précondition : /
	// Entrée :		- x : réel
	// Local :		/
	// Sortie :		- xInverse : reel
	public static double InverseSansPrecondition(double x)
	{
		double xInverse = 0;	// mettre 0 car ce n'est l'inverse d'aucun nombre (cette valeur sert de code d'erreur)
		if (x != 0)
		{
			xInverse = 1 / x;
		}
		return xInverse;
	}

	// Procédure principale
	public static void Main()
	{
		double resultat = 0.0;
		// saisir un réel, l'inverser et afficher le résultat
		AfficherChaine("Saisir un nombre réel (calcul de l'inverse avec précondition) : ");
		double reel = SaisirReel();
		// tester la précondition de la fonction avant de l'appeler !
		if (reel != 0)
		{
			resultat = Inverse(reel);
			AfficherChaine($"L'inverse de {reel} est {resultat}.\n");
		}
		else 
		{
			AfficherChaine($"Erreur, le nombre {reel} n'est pas inversible (division par 0) !\n");
		}

		// saisir un réel, l'inverser sans précondition et afficher le résultat
		AfficherChaine("Saisir un nombre réel (calcul de l'inverse sans précondition) : ");
		reel = SaisirReel();
		resultat = InverseSansPrecondition(reel);
		if (resultat != 0)
		{
			AfficherChaine($"L'inverse de {reel} est {resultat}.\n");
		}
		else 
		{
			AfficherChaine($"Erreur, le nombre {reel} n'est pas inversible (division par 0) !\n");
		}
	}
}