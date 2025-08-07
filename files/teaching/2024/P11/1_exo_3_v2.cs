// Auteur : Romain PERRIN

using System;

// version 2 : précondition (affichage pour l'utilisation) et pas de test
class CalculSurfaceRectangle
{
	public static void Main()
	{
		// variables
		double longueur = 0.0;
		double largeur = 0.0;
		double surface = 0.0;

		// saisie de la longueur
		Console.Write("Entrez la longueur du rectangle (réel >= 0) : ");
		longueur = double.Parse(Console.ReadLine());

		// saisie de la largeur
		Console.Write("Entrez la largeur du rectangle (réel >= 0) : ");
		largeur = double.Parse(Console.ReadLine());

		// calcul de la surface = longueur * largeur
		surface = longueur * largeur;

		// affichage de la surface
		Console.WriteLine("La surface vaut {0}x{1} = {2}.", longueur, largeur, surface);
	}
}