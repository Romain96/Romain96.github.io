// Auteur : Romain PERRIN

using System;

class CalculerIMC
{
	public static void Main()
	{
		// variables
		double taille = 0.0;
		double poids = 0.0;
		double imc = 0.0;

		// saisie de la taille
		Console.Write("Entrez votre taille en m : ");
		taille = double.Parse(Console.ReadLine());

		// saisie du poids
		Console.Write("Entrez votre poids en kg : ");
		poids = double.Parse(Console.ReadLine());

		// calcul de l'IMC = poids / taille^2
		imc = poids / (Math.Pow(taille, 2));

		// affichage de l'IMC
		Console.WriteLine("Votre IMC est de {0}/{1}² = {2:F2}", poids, taille, imc);    // {:F2} signifie que seuls deux chiffres significatifs sont affichés
	}
}