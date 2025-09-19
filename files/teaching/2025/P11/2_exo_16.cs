// Auteur : Romain PERRIN

using System;

class Exercice16
{
	public static void Main()
	{
		// constantes
		const int POP_ALPHA_ORIG = 10000000;
		const int CROISSANCE_ALPHA_FIXE = 500000;	// 500 000 par an
		const int POP_BETA_ORIG = 5000000;
		const float CROISSANCE_BETA_FACT = 0.03f;	// 3% par an

		// variables
		int popAlpha, popBeta, annee;

		annee = 0;
		popAlpha = POP_ALPHA_ORIG;
		popBeta = POP_BETA_ORIG;

		while (popBeta <= popAlpha)
		{
			Console.WriteLine($"Année {annee} :\tAlpha : {popAlpha}\tBeta : {popBeta}");
			popAlpha = popAlpha + CROISSANCE_ALPHA_FIXE;
			popBeta = (int) (popBeta * (1 + CROISSANCE_BETA_FACT));
			annee++;
		}
		Console.WriteLine($"La population de Sims Beta dépasse la population de Sims Alpha au bout de {annee} années (Alpha {popAlpha} < Beta {popBeta}).");
	}
}
