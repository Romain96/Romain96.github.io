// Auteur : Romain PERRIN

using System;

class VerifierValiditeDate
{
	public static void Main()
	{
		// variables
		int jour = 1;
		int mois = 1;
		int annee = 1959;
		bool estBissextile = false;
		int nombreDeJoursDuMois = 31;

		// saisie de l'année
		Console.Write("Entrez une année (>= 1959): ");
		annee = int.Parse(Console.ReadLine());

		// saisie du mois
		Console.Write("Entrez un mois (1-12) : ");
		mois = int.Parse(Console.ReadLine());

		// saisie du jour
		Console.Write("Entrez un jour (1-28/30/31) : ");
		jour = int.Parse(Console.ReadLine());

		// déterminer si l'année est bissextile ou non
		// une année est bissextile si elle est divisible par 4 et pas par 100 ou divisible par 400
		if (annee % 4 == 0 && annee % 100 != 0 || annee % 400 == 0)
		{
			estBissextile = true;
		}

		// déterminer le nombre de jours du mois courant
		if (mois == 4 || mois == 6 || mois == 9 || mois == 11)
		{
			nombreDeJoursDuMois = 30;
		}
		else if (mois == 2)
		{
			if (estBissextile)
			{
				nombreDeJoursDuMois = 29;
			}
			else
			{
				nombreDeJoursDuMois = 28;
			}
		}

		// vérification de l'année >= 1959
		if (annee < 1959)
		{
			Console.WriteLine($"Erreur : année ({annee}) invalide, doît être supérieure à 1959.");
		}
		else
		{
			// vérifier le mois (1-12)
			if (mois < 1 || mois > 12)
			{
				Console.WriteLine($"Erreur, mois ({mois}) invalide, doît être entre 1 et 12 !");
			}
			else
			{
				// vérifier le jour (1-nombreDeJoursDuMois)
				if (jour < 1 || jour > nombreDeJoursDuMois)
				{
					Console.WriteLine($"Erreur, jour ({jour}) invalide, doît être entre 1 et {nombreDeJoursDuMois} !");
				}
				// date valide
				else
				{
					Console.WriteLine($"Date valide : {jour}/{mois}/{annee}.");
				}
			}
		}
	}
}