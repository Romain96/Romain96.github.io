// Auteur : Romain PERRIN

using System;

// version 1 : algorithme naïf sans vérification/précondition
class CalculSurfaceRectangle
{
	public static void Main()
	{
		// variables
		double longueur = 0.0;
		double largeur = 0.0;
		double surface = 0.0;

		// saisie de la longueur
		Console.Write("Entrez la longueur du rectangle : ");
		longueur = double.Parse(Console.ReadLine());

		// saisie de la largeur
		Console.Write("Entrez la largeur du rectangle : ");
		largeur = double.Parse(Console.ReadLine());

		// calcul de la surface = longueur * largeur
		surface = longueur * largeur;

		// affichage de la surface
		Console.WriteLine("La surface vaut {0}x{1} = {2}.", longueur, largeur, surface);
	}
}