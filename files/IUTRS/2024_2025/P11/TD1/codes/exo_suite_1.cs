using System;

class MeilleureFormuleLocation
{
	public static void Main()
	{
		// variables
		const int ESSENCE_JOURNALIER = 23;
		const double ESSENCE_KILOMETRAGE = 0.16;
		const int DIESEL_JOURNALIER = 25;
		const double DIESEL_KILOMETRAGE = 0.13;
		const int ELECTRIQUE_JOURNALIER = 40;
		const double ELECTRIQUE_KILOMETRAGE = 0.03;
		double valeurFormuleEssence = 0;
		double valeurFormuleDiesel = 0;
		double valeurFormuleElectrique = 0;
		int duree = 0;
		int distance = 0;

	
		// saisie de la durée et du kilométrage parcouru
		Console.Write("Entrez la durée prévue en jours : ");
		duree = int.Parse(Console.ReadLine());
		Console.Write("Entrez le nombre de kilomètres parcourus : ");
		distance = int.Parse(Console.ReadLine());

		// calcul de la formule essence
		valeurFormuleEssence = duree * ESSENCE_JOURNALIER + distance * ESSENCE_KILOMETRAGE;
		// calcul de la formule diesel
		valeurFormuleDiesel = duree * DIESEL_JOURNALIER + distance * DIESEL_KILOMETRAGE; 
		// calcul de la formule électrique
		valeurFormuleElectrique = duree * ELECTRIQUE_JOURNALIER + distance * ELECTRIQUE_KILOMETRAGE;

		Console.WriteLine($"Essence : {valeurFormuleEssence} euros\nDiesel : {valeurFormuleDiesel} euros\nÉlectrique : {valeurFormuleElectrique} euros.");

		// meilleure formule = plus faible valeur
		if (valeurFormuleEssence <= valeurFormuleDiesel && valeurFormuleEssence <= valeurFormuleElectrique)
		{
			Console.WriteLine($"La meilleure formule est la formule essence pour {valeurFormuleEssence} euros.");
		}
		else if (valeurFormuleDiesel <= valeurFormuleEssence && valeurFormuleDiesel <= valeurFormuleElectrique)
		{
			Console.WriteLine($"La meilleure formule est la formule diesel pour {valeurFormuleDiesel} euros.");
		}
		else
		{
			Console.WriteLine($"La meilleure formule est la formule électrique pour {valeurFormuleElectrique} euros.");
		}
	}
}
