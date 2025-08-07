using System;

// Auteur : Romain PERRIN

// 1) structure Date
public struct Date
{
	public int annee;
	public int mois;
	public int jour;
}

class ManipulationStructureDate
{
	public static void Main()
	{
		// 2) création d'une date sans vérification
		// Entrée :
		//	- xAnnee : entier
		//	- xMois : entier
		//	- xJour : entier
		// Local  : /
		// Sortie :
		//	- date : Date
		int xJour = 2;
		int xMois = 10;
		int xAnnee = 2024;
		Date date = new Date{annee = xAnnee, mois = xMois, jour = xJour};

		// 3) affichage d'une date au format JJ/MM/AAAA
		// Entrée :
		//	- xDate : Date
		// Local  : /
		// Sortie : void
		Date xDate = date;
		Console.WriteLine("-> Date : {0:D2}/{1:D2}/{2:D4}", xDate.jour, xDate.mois, xDate.annee);
		
		// 4) création d'une date seulement si valide
		// Entrée :
		// 	- xAnnee : entier
		// 	- xMois : entier
		// 	- xJour : entier
		// Local  :
		// 	- estBissextile : booléen
		// 	- nombreJoursDansMois : entier
		// Sortie :
		//	- dateTest : Date
		bool estBissextile = false;	// par défaut
		int nombreJoursDansMois = 31;	// par défaut
		Date dateTest = new Date();
		if (xAnnee < 0)
		{
			Console.WriteLine("Erreur, l'année {0} est invalide !", xAnnee);
		}
		else
		{
			// déterminer si l'année est bissextile ou non (bissextile = divisible par 4 mais pas 100 ou divisible par 400)
			if ((xAnnee % 4 == 0 && xAnnee % 100 != 0) || xAnnee % 400 == 0)
			{
				estBissextile = true;
			}
			if (xMois < 0 || xMois > 12)
			{
				Console.WriteLine("Erreur, le mois {0} est invalide !", xMois);
			}
			else
			{
				// déterminer le nombre de jours dans le mois
				if (xMois == 4 || xMois == 6 || xMois == 9 || xMois == 11)
				{
					nombreJoursDansMois = 30;
				}
				else if (xMois == 2)
				{
					if (estBissextile)
					{
						nombreJoursDansMois = 29;
					}
					else
					{
						nombreJoursDansMois = 28;
					}
				}
				if (xJour < 0 || xJour > nombreJoursDansMois)
				{
					Console.WriteLine("Erreur, le jour {0} est invalide, il doît être entre 0 et {1} pour les mois/année donnés.", xJour, nombreJoursDansMois);
				}
				else
				{
					// création de la date
					dateTest = new Date{annee = xAnnee, mois = xMois, jour = xJour};
				}
			}
		}
		Console.WriteLine("-> Date : {0:D2}/{1:D2}/{2:D4}", dateTest.jour, dateTest.mois, dateTest.annee);
		
		// 5) comparaison de deux dates et affichage
		// Préconditions : les deux dates ne sont pas nulles (impossible si usage de Date et non de Date?)
		// Entrée :
		// 	- xDate1 : Date
		// 	- xDate2 : Date
		// Local  : /
		// Sortie : void
		Date xDate1 = new Date{annee = 2024, mois = 10, jour = 4};
		Date xDate2 = new Date{annee = 2024, mois = 10, jour = 1};
		// comparaison des années
		if (xDate1.annee > xDate2.annee)
		{
			Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} > xDate2 {3:D2}/{4:D2}/{5:D4}", 
				xDate1.jour, xDate1.mois, xDate1.annee, 
				xDate2.jour, xDate2.mois, xDate2.annee
			);
		}
		else if (xDate1.annee < xDate2.annee)
		{
			Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} < xDate2 {3:D2}/{4:D2}/{5:D5}",
				xDate1.jour, xDate1.mois, xDate1.annee,
				xDate2.jour, xDate2.mois, xDate2.annee
			);
		}
		else
		{
			// comparaison des mois
			if (xDate1.mois > xDate2.mois)
			{
				Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} > xDate2 {3:D2}/{4:D2}/{5:D4}",
					xDate1.jour, xDate1.mois, xDate1.annee,
					xDate2.jour, xDate2.mois, xDate2.annee
				);
			}
			else if (xDate1.mois < xDate2.mois)
			{
				Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} < xDate2 {3:D2}/{4:D2}/{5:D4}",
					xDate1.jour, xDate1.mois, xDate1.annee,
					xDate2.jour, xDate2.mois, xDate2.annee
				);
			}
			else
			{
				// comparaison des jours
				if (xDate1.jour > xDate2.jour)
				{
					Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} > xDate2 {3:D2}/{4:D2}/{5:D4}",
						xDate1.jour, xDate1.mois, xDate1.annee,
						xDate2.jour, xDate2.mois, xDate2.annee
					);
				}
				else if (xDate1.jour < xDate2.jour)
				{
					Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} < xDate2 {3:D2}/{4:D2}/{5:D4}",
						xDate1.jour, xDate1.mois, xDate1.annee,
						xDate2.jour, xDate2.mois, xDate2.annee
					);
				}
				else
				{
					// identiques !
					Console.WriteLine("-> xDate1 {0:D2}/{1:D2}/{2:D4} = xDate2 {3:D2}/{4:D2}/{5:D4}",
						xDate1.jour, xDate1.mois, xDate1.annee,
						xDate2.jour, xDate2.mois, xDate2.annee
					);
				}
			}
		}
	}
}
