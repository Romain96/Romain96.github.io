// Auteur : Romain PERRIN

using System;

class Exercice2PrixTTC
{
	// Procédure : AfficherChaine
	// Principe : Affiche un chaîne de caractères donnée dans la console
	// Précondition : /
	// Entrée :		- chaine : chaîne de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherChaine(string chaine)
	{
		Console.Write(chaine);
	}

	// Fonction : SaisirReel
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- n : reel
	public static double SaisirReel()
	{
		return double.Parse(Console.ReadLine());
	}

	// Fonction : CalculerPrixTTC
	// Entrée :		- prixHT : réel
	//				- valeurTVA : réel
	// Local :		/
	// Sortie :		- prixTTC : reel
	public static double CalculerPrixTTC(double prixHT, double valeurTVA)
	{
		double prixTTC = prixHT * (1 + valeurTVA);
		return prixTTC;
	}

	// Procédure principale
	public static void Main()
	{
		// saisir le prixHT, appeler la fonction de calcul et afficher le résultat
		const double VALEUR_TVA = 0.20;
		AfficherChaine("Saisir le prix hors taxe : ");
		double prixHT = SaisirReel();
		double prixTTC = CalculerPrixTTC(prixHT, VALEUR_TVA);
		AfficherChaine($"Le prix TTC d'un article au prix hors taxe de {prixHT} euros avec une TVA de {VALEUR_TVA}% est de {prixTTC} euros.\n");
	}
}