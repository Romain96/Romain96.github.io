using System;

class CalculFraisDePort
{
	public static void Main()
	{
		// variables
		int quantite = 0;			// quantité de bouteilles
		double prixUnitaire = 0.0;		// prix d'une bouteille
		const int SEUIL_FDP = 150;		// seuil à partir duquel il n'y a pas de frais de port
		const double POURCENTAGE_FDP = 0.15;	// 15% de la commande si < SEUIL_FDP
		const int MINIMUM_FORFAITAIRE = 15;	// minimum de frais de port lorsqu'il y en a
		double fraisDePort = 0.0;		// résultat

		// saisie de la quantité et du prix unitaire
		Console.Write("Entrez la quantité de bouteilles à commander : ");
		quantite = int.Parse(Console.ReadLine());
		Console.Write("Entrez le prix unitaire : ");
		prixUnitaire = double.Parse(Console.ReadLine());

		// frais de port ou non ?
		if (quantite * prixUnitaire < SEUIL_FDP)
		{
			fraisDePort = POURCENTAGE_FDP * quantite * prixUnitaire;
			// fortait ou non
			if (fraisDePort < MINIMUM_FORFAITAIRE)
			{
				fraisDePort = MINIMUM_FORFAITAIRE;
			}
		}
		Console.WriteLine($"Les frais de port s'élèvent à {fraisDePort} euros.");
	}
}
