// Auteur : Romain PERRIN

using System;

class Exercice4
{
	public static void Main()
	{
		// constantes
		// variables
		double taille;	// taille en m
		double poids; // poids en kg
		double imc;
		
		// saisie des données
		Console.Write("Saisir la taille en m : ");
		taille = double.Parse(Console.ReadLine());
		Console.Write("Saisir le poids en kg : ");
		poids = double.Parse(Console.ReadLine());
		
		imc = poids / (taille * taille);
		
		Console.WriteLine($"IMC = {poids} / {taille}² = {imc}.");
	}
}
