// Auteur : Romain PERRIN

using System;

class Exercice9
{
	public static void Main()
	{
		// constantes
		const int ANNEE_MIN = 1901;
		const int ANNEE_MAX = 2038;
		const int MOIS_MIN = 12;
		const int MOIS_MAX = 1;
		const int JOUR_MIN = 13;
		const int JOUR_MAX = 19;
		// variables
		int jour, mois, annee;	// numéro de jour, mois et année saisis par l'utilisateur
		bool bissextile;	// si le mois est bissextile ou non
		int nJours;	// nombre de jours max dans le mois
		
		// saisie du jour, du mois et de l'année
		Console.Write("Saisir le jour : ");
		jour = int.Parse(Console.ReadLine());
		Console.Write("Saisir le mois : ");
		mois = int.Parse(Console.ReadLine());
		Console.Write("Saisir l'année : ");
		annee = int.Parse(Console.ReadLine());
		
		// vérification de l'année
		if (annee < ANNEE_MIN || annee > ANNEE_MAX)
		{
			// année invalide
			Console.WriteLine($"Erreur de saisie : l'année doit être comprise entre {ANNEE_MIN} et {ANNEE_MAX} (valeur saisie : {annee}).");
		}
		// année valide
		else
		{
			// vérification du mois (entre 1 et 12)
			if (mois < 1 || mois > 12)
			{
				Console.WriteLine($"Erreur de saisie : le mois doit être compris entre 1 et 12 (valeur saisie : {mois}).");
			}
			// vérification du mois (année minimale et mois avant la date min)
			else if (annee == ANNEE_MIN && mois < MOIS_MIN)
			{
				Console.WriteLine($"Erreur de saisie : le mois ne peut précéder {MOIS_MIN} pour l'année {ANNEE_MIN} (valeur saisie : {mois}).");
			}
			// vérification du mois (année maximale et mois après la date max
			else if (annee == ANNEE_MAX && mois > MOIS_MAX)
			{
				Console.WriteLine($"Erreur de saisie : le mois ne peut excéder {MOIS_MAX} pour l'année {ANNEE_MAX} (valeur saisie : {mois}).");
			}
			// mois correct
			else
			{
				// déterminer si l'année est bissextile
				bissextile = false;
				if ((annee % 4 == 0 && annee % 100 != 0) || annee % 400 == 0)
				{
					bissextile = true;
				}
				
				// déterminer le nombre de jours maximal du mois en question
				nJours = 31;	// occurrence la plus fréquente
				
				if (mois == 2)
				{
					nJours = 28;
					if (bissextile)
					{
						nJours = 29;
					}
				}
				else
				{
					if (mois == 4 || mois == 6 || mois == 9 || mois == 11)
					{
						nJours = 30;
					}
				}
				
				// vérification du jour (avant la date min)
				if (annee == ANNEE_MIN && mois == MOIS_MIN && jour < JOUR_MIN)
				{
					Console.WriteLine($"Erreur de saisie : le jour ne peut précéder {JOUR_MIN} pour l'année {ANNEE_MIN} et le mois {MOIS_MIN}  (valeur saisie : {jour}).");
				}
				// vérification du jour (après la date max)
				else if (annee == ANNEE_MAX && mois == MOIS_MAX && jour > JOUR_MAX)
				{
					Console.WriteLine($"Erreur de saisie : le jour ne peut excéder {JOUR_MAX} pour l'année {ANNEE_MAX} et le mois {MOIS_MAX} (valeur saisie : {jour}).");
				}
				// vérification du jour (valide en fonction du mois et de l'année)
				else if (jour < 1 || jour > nJours)
				{
					Console.WriteLine($"Erreur de saisie : le jour doit être compris entre 1 et {nJours} pour le mois {mois} et l'année {annee} (valeur saisie : {jour}).");
				}
				// la date est valide !
				else
				{
					Console.WriteLine($"La date  {jour}/{mois}/{annee} est valide.");
				}
			}
		}
		
	}
}
