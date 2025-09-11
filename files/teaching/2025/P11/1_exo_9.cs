// Auteur : Romain PERRIN

using System;

class Exercice9
{
	public static void Main()
	{
		// constantes
		const double TAILLE_MIN = 1.50;
		const double TAILLE_MAX = 2.10;
		// variables
		double taille;	// taille en m
		double poids; // poids en kg
		double imc;
		
		// saisie de la taille
		Console.Write("Saisir la taille en m : ");
		taille = double.Parse(Console.ReadLine());
		
		// vérification de la taille valide
		if (taille < TAILLE_MIN || taille > TAILLE_MAX)
		{
			Console.WriteLine("Erreur de saisie : la taille doit être comprise entre {TAILLE_MIN} et {TAILLE_MAX} (valeur saisie : {taille}).");
		}
		else 
		{
			// saisie du poids
			Console.Write("Saisir le poids en kg : ");
			poids = double.Parse(Console.ReadLine());
			
			// calcul de l'IMC
			imc = poids / (taille * taille);
			Console.WriteLine($"IMC = {poids} / {taille}² = {imc}.");
			
			// détermination du niveau
			if (imc < 16.5)
			{
				Console.WriteLine("Niveau -2 : insuffisance pondérale sévère.");
			}
			else
			{
				if (imc < 18.5)
				{
					Console.WriteLine("Niveau -1 : insuffisance pondérale.");
				}
				else
				{
					if (imc < 25)
					{
						Console.WriteLine("Niveau 0 : corpulence normale.");
					}
					else
					{
						if (imc < 30)
						{
							Console.WriteLine("Niveau 1 : surpoids.");
						}
						else
						{
							if (imc < 35)
							{
								Console.WriteLine("Niveau 2 : obésité modérée.");
							}
							else
							{
								if (imc < 40)
								{
									Console.WriteLine("Niveau 3 : obésité sévère.");
								}
								else
								{
									Console.WriteLine("Niveau 4 : obésité morbide.");
								}
							}
						}
					}
				}
			}
		}
	}
}
