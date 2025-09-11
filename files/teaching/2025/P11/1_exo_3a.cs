// Auteur : Romain PERRIN

using System;

class Exercice3
{
	public static void Main()
	{
		// constantes
		const double LONGUEUR = 127.50;	// longueur du champ en m
		const double LARGEUR = 58.95;	// largueur du champ en m
		
		// variables
		double surface, perimetre;
		
		surface = LONGUEUR * LARGEUR;
		perimetre = (LONGUEUR + LARGEUR) * 2;
		
		Console.WriteLine($"Surface = {LONGUEUR} * {LARGEUR} = {surface} m².");
		Console.WriteLine($"Périmètre = ({LONGUEUR} + {LARGEUR}) * 2 = {perimetre} m.");
	}
}
