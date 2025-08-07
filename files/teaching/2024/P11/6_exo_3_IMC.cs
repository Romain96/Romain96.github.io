// Auteur : Romain PERRIN

using System;

class Exercice2IMC
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

	// Fonction : CalculerIMC
	// Principe : calculer l'IMC avec la formule poids / taille²
	// Précondition : taille != 0
	// Entrée :		- taille : réel
	//				- poids : réel
	// Local :		/
	// Sortie :		- imc : reel
	public static double CalculerIMC(double taille, double poids)
	{
		double imc = poids / (taille * taille);
		return imc;
	}

	// Procédure principale
	public static void Main()
	{
		// saisir la taille et le poids, vérifier que la taille n'est pas nulle, appeler la fonction de calcul et afficher le résultat
		AfficherChaine("Saisir la taille en m : ");
		double tailleUtilisateur = SaisirReel();
		AfficherChaine("Saisir le poids en kg : ");
		double poidsUtilisateur = SaisirReel();
		if (tailleUtilisateur != 0)
		{
			double imcUtilisateur = CalculerIMC(tailleUtilisateur, poidsUtilisateur);
			AfficherChaine($"L'IMC pour une taille de {tailleUtilisateur} m et un poids de {poidsUtilisateur} kg est de {imcUtilisateur}.\n");
		}
	}
}