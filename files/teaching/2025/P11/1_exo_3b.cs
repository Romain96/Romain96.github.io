// Auteur : Romain PERRIN

using System;

class Exercice3
{
	public static void Main()
	{
		// variables
		double longueur;	// longueur du champ en mètre
		double largeur;	// largueur du champ en mètre
		double surface, perimetre;
		
		// saisie des données
		Console.Write("Saisir la longueur du champ en m : ");
		longueur = double.Parse(Console.ReadLine());
		Console.Write("Saisir la largeur du champ en m : ");
		largeur = double.Parse(Console.ReadLine());
		
		surface = longueur * largeur;
		perimetre = (longueur  + largeur) * 2;
		
		Console.WriteLine($"Surface = {longueur} * {largeur} = {surface} m².");
		Console.WriteLine($"Périmètre = ({longueur} + {largeur}) * 2 = {perimetre} m.");
	}
}
