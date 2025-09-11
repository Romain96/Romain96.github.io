// Auteur : Romain PERRIN

using System;

class Exercice5
{
	public static void Main()
	{
		// constantes
		const double PRIX_HA = 3000.0;	// prix à l'hectare (pour info : 1 ha = 100m*100m = 10 000 m²)
		// variables
		double longueur;	// longueur du champ en mètre
		double largeur;	// largueur du champ en mètre
		double surface, perimetre, prix;
		
		// saisie des données
		Console.Write("Saisir la longueur du champ en m : ");
		longueur = double.Parse(Console.ReadLine());
		Console.Write("Saisir la largeur du champ en m : ");
		largeur = double.Parse(Console.ReadLine());
		
		surface = longueur * largeur;
		perimetre = (longueur  + largeur) * 2;
		prix = surface / 10000 * PRIX_HA;
		
		Console.WriteLine($"Surface = {longueur} * {largeur} = {surface} m².");
		Console.WriteLine($"Périmètre = ({longueur} + {largeur}) * 2 = {perimetre} m.");
		Console.WriteLine($"Prix = {surface} / 10000 * {PRIX_HA} = {prix} €.");
	}
}
