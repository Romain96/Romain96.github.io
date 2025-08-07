// Auteur : Romain PERRIN

using System;

class CalculPrixTTC
{
	public static void Main()
	{
		// variables
		const double TAUX_TVA = 0.20;	// TVA fixée à 20%
		double prixHT = 0.0;		// prix hors taxe en euros
		double prixTTC = 0.0;		// prix TTC à calculer et afficher

		// saisie du prix hors taxe
		Console.Write("Entrez le prix hors taxe en euros : ");
		prixHT = double.Parse(Console.ReadLine());	// ReadLine retourne la chaine entrée par l'utilisateur, Parse effectue la conversion en double

		// calcul du prix TTC en utilisant la formule prixTTC = prixHT * (1 + TAUX_TVA)
		prixTTC = prixHT * (1 + TAUX_TVA);

		// affichage du prixTTC
		Console.WriteLine("Le prix TTC du produit est de {0} euros.", prixTTC);
	}
}
