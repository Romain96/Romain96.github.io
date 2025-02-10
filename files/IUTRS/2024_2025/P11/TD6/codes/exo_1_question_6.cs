// Auteur : Romain PERRIN

using System;

class PremiersPasSuestion6
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

	// Fonction : Saisir10EntiersEtRetournerLeMinimum
	// Précondition : /
	// Entrée :		/
	// Local :		- compteur : entier
	//				- nombre : entier
	// Sortie :		- minimum : entier
	public static int Saisir10EntiersEtRetournerLeMinimum()
	{
		AfficherChaine("Saisir le 1e entier : ");
		int minimum = SaisirEntier();
		int nombre = 0;

		for (int compteur = 2; compteur <= 10; compteur++)
		{
			AfficherChaine($"Saisir le {compteur}e entier : ");
			nombre = SaisirEntier();

			if (nombre < minimum)
			{
				minimum = nombre;
			}
		}

		return minimum;
	}

	// Procédure principale
	public static void Main()
	{
		int resultat = Saisir10EntiersEtRetournerLeMinimum();
		AfficherChaine($"Le minimum des 10 entiers saisis est : {resultat}\n");
	}
}