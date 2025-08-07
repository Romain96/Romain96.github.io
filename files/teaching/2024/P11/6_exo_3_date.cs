// Auteur : Romain PERRIN

using System;

class Exercice2ValiditeDate
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

	// Fonction : EstBissextile
	// Principe : détermine si l'année donnée en entrée est bissextile ou non. 
	// Une année est bissextile si elle est (divisible par 4 mais pas par 100) ou (divisible par 400)
	// Entrée :		- annee : entier
	// Local :		/
	// Sortie :		- bissextile : booléen
	public static bool EstBissextile(int annee)
	{
		bool bissextile = false;	// par défaut
		if ((annee % 4 == 0 && annee % 100 != 0) || (annee % 400 == 0))
		{
			bissextile = true;
		}
		return bissextile;
	}

	// Fonction : NombreJoursDansMois
	// Principe : détermine le nombre de jours du mois donné en entrée.
	// Entrée :		- mois : entier
	//				- bissextile : booléen
	// Local :		/
	// Sortie :		- nJours : entier
	public static int NombreJoursDansMois(int mois, bool bissextile)
	{
		int nJours = 31;	// par défaut
		if (mois == 4 || mois == 6 || mois == 9 || mois == 11)
		{
			nJours = 30;
		}
		else if (mois == 2)
		{
			if (bissextile == true)
			{
				nJours = 29;
			}
			else
			{
				nJours = 28;
			}
		}
		return nJours;
	}

	// Fonction : VerifierValiditeAnnee
	// Principe : vérifie que le mois en entrée est un numéro valide
	// Entrée :		- annee : entier
	// Local :		/
	// Sortie :		- valide : booléen
	public static bool VerifierValiditeAnnee(int annee)
	{
		bool validite = true;	// par défaut
		if (annee < 1959)
		{
			validite = false;
		}
		return validite;
	}

	// Fonction : VerifierValiditeMois
	// Principe : vérifie que le mois en entrée est un numéro valide
	// Entrée :		- mois : entier
	// Local :		/
	// Sortie :		- valide : booléen
	public static bool VerifierValiditeMois(int mois)
	{
		bool validite = true;	// par défaut
		if (mois < 1 || mois > 12)
		{
			validite = false;
		}
		return validite;
	}

	// Fonction : VerifierValiditeJour
	// Principe : vérifie que le jour en entrée est un numéro valide
	// Entrée :		- jour : entier
	//				- nJours : entier
	// Local :		/
	// Sortie :		- valide : booléen
	public static bool VerifierValiditeJour(int jour, int nJours)
	{
		bool validite = true;	// par défaut
		if (jour < 1 || jour > nJours)
		{
			validite = false;
		}
		return validite;
	}

	// Fonction : VerifierValiditeDate
	// Principe : vérifie que la date en entrée est une date valide
	// Entrée :		- jour : entier
	//				- mois : entier
	//				- annee : entier
	// Local :		- anneeEstBissextile : booléen
	//				- nJoursDansMois : entier
	// Sortie :		- dateValide : booléen
	public static bool VerifierValiditeDate(int jour, int mois, int annee)
	{
		bool dateValide = false;	// par défaut
		bool anneeEstBissextile = EstBissextile(annee);
		int nJoursDansMois = NombreJoursDansMois(mois, anneeEstBissextile);
		if (VerifierValiditeJour(jour, nJoursDansMois) == true && VerifierValiditeMois(mois) == true && VerifierValiditeAnnee(annee))
		{
			dateValide = true;
		}
		return dateValide;
	}

	// Procédure principale
	public static void Main()
	{
		// saisir le jour, le mois et l'année puis appeler la fonction de vérification de date et afficher le résultat (valide/non valide)
		AfficherChaine("Saisir le jour : ");
		int jourUtilisateur = SaisirEntier();
		AfficherChaine("Saisir le mois : ");
		int moisUtilisateur = SaisirEntier();
		AfficherChaine("Saisir l'année : ");
		int anneeUtilisateur = SaisirEntier();
		bool dateUtilisateurValide = VerifierValiditeDate(jourUtilisateur, moisUtilisateur, anneeUtilisateur);
		if (dateUtilisateurValide == true)
		{
			AfficherChaine($"La date {jourUtilisateur:D2}/{moisUtilisateur:D2}/{anneeUtilisateur:D4} est valide.\n");
		}
		else
		{
			AfficherChaine($"La date {jourUtilisateur:D2}/{moisUtilisateur:D2}/{anneeUtilisateur:D4} n'est pas valide.\n");
		}
	}
}