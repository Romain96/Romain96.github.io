// Auteur : Romain PERRIN

using System;

class PremiersPasQuestions1A5
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

	// Fonction : SaisirEntier
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- n : entier
	public static int SaisirEntier()
	{
		return int.Parse(Console.ReadLine());
	}

	// Fonction : Carre
	// Principe : calcule et retourne le carré d'un entier donné
	// Précondition : /
	// Entrée :		- n : entier
	// Local :		/
	// Sortie :		- nCarre : entier
	public static int Carre(int n)
	{
		int nCarre = n * n;
		return nCarre;
	}

	// Fonction : Factorielle
	// Principe : calcule la factorielle d'un entier positif sans récursivité (boucle for)
	// Précondition : n >= 0
	// Entrée :		- n : entier
	// Local :		- i : entier
	// Sortie :		- fact : entier
	public static int Factorielle(int n)
	{
		int fact = 1;
		for (int i = 2; i <= n; i++)
		{
			fact = fact * i;
		}
		return fact;
	}

	// Fonction : DivisionPar10
	// Précondition : /
	// Entrée :		- n : entier
	// Local :		/
	// Sortie :		- div10 : réel
	public static double Div10(int n)
	{
		double div10 = (double)n / 10;
		return div10;
	}

	// Procédure principale
	public static void Main()
	{
		// menu : demander un entier, puis un numéro d'opération (1 = Carre, 2 = Factorielle, 3 = Div10) et afficher le résultat
		int operation = 0;
		int nombre = 0;

		// saisir le nombre entier
		AfficherChaine("Saisir un entier : ");
		nombre = SaisirEntier();

		// saisir le numéro de l'opération
		AfficherChaine("Opérations disponibles :\n\t1 : mettre au carré\n\t2 : calculer la factorielle\n\t3 : diviser par 10\nSaisir le numéro de l'opération : ");
		operation = SaisirEntier();

		// choix de l'opération et application puis affichage
		if (operation == 1)
		{
			AfficherChaine($"{nombre}^2 = {Carre(nombre)}\n");
		}
		else if (operation == 2)
		{
			AfficherChaine($"{nombre}! = {Factorielle(nombre)}\n");
		}
		else if (operation == 3)
		{
			AfficherChaine($"{nombre}/10 = {Div10(nombre)}\n");
		}
	}
}