// Auteur : Romain PERRIN

using System;

class Exercice15
{
	public static void Main()
	{
		// constantes
		const int MIN_MOIS_PRIME = 10;
		const int BONUS_PRIME_MAX_JOURS_ARRET = 2;	// inférieur à 3
		const int MALUS_PRIME_MAX_JOURS_ARRET = 9;	// inférieur à 10 mais supérieur à 2
		const float BONUS_PRIME_FACT = 2.0f;	// prime doublée
		const float MALUS_PRIME_FACT_1 = 0.50f;	// réduite de 50%
		const float MALUS_PRIME_FACT_2 = 0.25f;	// réduite de 75%

		// variables
		int n;	// nombre de salariés
		int matricule, moisTravailles, joursArret;
		float salaireBase, prime;

		// saisir le nombre de salariés à traiter
		Console.Write("Saisir le nombre de salariés à traiter : ");
		n = int.Parse(Console.ReadLine());

		// pour chaque salarié
		for (int i = 0; i < n; i++)
		{
			// saisir le matricule, le salaire de base, le nombre de mois travaillés et le nombre de jours d'arrêt
			Console.Write($"Saisir le matricule du salarié n°{i+1} : ");
			matricule = int.Parse(Console.ReadLine());
			Console.Write($"Saisir le salaire de base en € du salarié n°{i+1} : ");
			salaireBase = float.Parse(Console.ReadLine());
			Console.Write($"Saisir le nombre de mois travaillés du salarié n°{i+1} : ");
			moisTravailles = int.Parse(Console.ReadLine());
			Console.Write($"Saisir le nombre de jours d'arrêt du salarié n°{i+1} : ");
			joursArret = int.Parse(Console.ReadLine());

			// calcul de la prime
			if (moisTravailles < MIN_MOIS_PRIME)
			{
				prime = salaireBase;
			}
			else
			{
				prime = (salaireBase * moisTravailles) / 12;
				if (joursArret <= BONUS_PRIME_MAX_JOURS_ARRET)
				{
					prime = prime * BONUS_PRIME_FACT;
				}
				else
				{
					if (joursArret <= MALUS_PRIME_MAX_JOURS_ARRET)
					{
						prime = prime * MALUS_PRIME_FACT_1;
					}
					else
					{
						prime = prime * MALUS_PRIME_FACT_2;
					}
				}
			}

			// affichage du résultat
			Console.WriteLine($"Salarié n°{i+1}:\tMatricule {matricule}\tSalaire {salaireBase}\tMois travaillés {moisTravailles}\tJours d'arrêt {joursArret}\tPrime {prime}");
		}
	}
}
