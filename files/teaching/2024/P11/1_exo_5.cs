// Auteur : Romain PERRIN

using System;

class CalculIMCAvecCategorie
{
	public static void Main()
	{
		// variables
		double taille = 0.0;
		double poids = 0.0;
		double imc = 0.0;
		const double NORMAL = 18.5;     // début de la tranche "normale"
		const double SURPOIDS = 25.0;   // début de la tranche "surpoids"
		const double OBESITE_1 = 30.0;  // début de la tranche "obésité I"
		const double OBESITE_2 = 35.0;  // début de la tranche "obésité II"
		const double OBESITE_3 = 40.0;  // début de la tranche "obésité III"
		double categorie = -2;          // niveau correspondant à l'IMC calculé

		// saisie de la taille
		Console.Write("Entrez votre taille en m : ");
		taille = double.Parse(Console.ReadLine());

		// saisie du poids
		Console.Write("Entrez votre poids en kg : ");
		poids = double.Parse(Console.ReadLine());

		// calcul de l'IMC = poids / taille^2
		imc = poids / (Math.Pow(taille, 2));

		// détermination de la catégorie
		if (imc < NORMAL)
		{
			categorie = -1;    // niveau "insuffisant" [0-18.5[
		}
		else
		{
			if (imc < SURPOIDS)
			{
				categorie = 0; // niveau "normal" [18.5-25.0[
			}
			else
			{
				if (imc < OBESITE_1)
				{  
					categorie = 1; // niveau "surpoids" [25.0-30.0[
				}
				else
				{
					if (imc < OBESITE_2)
					{
						categorie = 2; // niveau "obésité I" [30.0-35.0[
					}
					else
					{
						if (imc < OBESITE_3)
						{
							categorie = 3; // niveau "obésité II" [35.0-40.0[
						}
						else
						{
							categorie = 4; // niveau "obésité III" [40.0-inf[
						}
					}
				}
			}
		}

		// affichage de l'IMC et de la catégorie
		Console.WriteLine("Votre IMC est de {0}/{1}² = {2:F2} (categorie {3})", poids, taille, imc, categorie);
	}
}