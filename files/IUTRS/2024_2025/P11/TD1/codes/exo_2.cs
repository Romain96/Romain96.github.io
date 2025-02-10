// Auteur : Romain PERRIN

using System;

class CalculPrixTTCAvecRemise
{
	public static void Main()
	{
		// variables
		const double TAUX_TVA = 0.20;	// TVA fixée à 20%
		double prixHT = 0.0;		// prix hors taxe en euros
		double prixTTC = 0.0;		// prix TTC à calculer et afficher
		const int VALEUR_REMISE = 8;	// valeur de la remise (8 euros par tranche)
		const int TRANCHE_REMISE = 100;	// tranche de remise (tous les 100 euros)
		int nombreRemise = 0;		// nombre de fois que la remise est appliquée à calculer
		double prixTTCAvecRemise = 0.0;	// prix TTC avec application de la remise à calculer et afficher

		// saisie du prix hors taxe
		Console.Write("Entrez le prix hors taxe en euros : ");
		prixHT = double.Parse(Console.ReadLine());	// ReadLine retourne la chaine entrée par l'utilisateur, Parse effectue la conversion en double

		// calcul du prix TTC en utilisant la formule prixTTC = prixHT * (1 + TAUX_TVA)
		prixTTC = prixHT * (1 + TAUX_TVA);

		// affichage du prixTTC
		Console.WriteLine("Le prix TTC du produit est de {0} euros.", prixTTC);

		// calcul de la remise
		nombreRemise = (int) (prixTTC / TRANCHE_REMISE);	// (int) est un cast qui permet de convertir le résultat double en int

		// application de la remise et calcul du prix TTC final
		prixTTCAvecRemise = prixTTC - VALEUR_REMISE * nombreRemise;

		// affichage du prix final avec remise
		Console.WriteLine("Le prix final est de {0} euros après application de {1} remise(s) de {2} euros.", prixTTCAvecRemise, nombreRemise, valeurRemise);
	}
}
