// Auteur : Romain PERRIN

using System;

class Exercice9
{
	public static void Main()
	{
		// constantes
		const int TENTATIVES_MAX = 10;
		const int ENTIER_MIN = 0;
		const int ENTIER_MAX = 100;

		// variables
		int tentative = 1;	// numéro de la tentative (< TENTATIVE_MAX)
		int nAleatoire;	// nombre généré par la machine, à deviner (>= ENTIER_MIN et <= ENTIER_MAX)
		int nSaisi;	// nombre saisi par l'utilisateur
		bool trouve = false;	// vrai si l'utilisateur trouve le bon nombre

		// générer un entier alétoire entre ENTIER_MIN et ENTIER_MAX
		Random generateur = new Random();	// générateur de nombre alétoire
		nAleatoire = generateur.Next(ENTIER_MIN, ENTIER_MAX + 1);

		// boucle de jeu
		while (tentative <= TENTATIVES_MAX && trouve == false)
		{
			// saisie de nSaisi
			Console.Write($"Tentative {tentative} - Saisir un nombre entre {ENTIER_MIN} et {ENTIER_MAX} : ");
			nSaisi = int.Parse(Console.ReadLine());

			// plus petit que le nombre
			if (nSaisi < nAleatoire)
			{
				Console.WriteLine("Plus grand !");
			}
			// plus grand que le nombre
			else if (nSaisi > nAleatoire)
			{
				Console.WriteLine("Plus petit !");
			}
			// nombre trouvé !
			else
			{
				Console.WriteLine($"Bravo ! trouvé en {tentative} coups !");
				trouve = true;	// pour sortir de la boucle de jeu
			}
			tentative = tentative + 1;	// +1 tentative
		}
		
		// échec
		if (trouve == false)
		{
			Console.WriteLine($"Échec ! le nombre à trouvé était : {nAleatoire}.");
		}

	}
}
