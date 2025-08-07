// Auteur : Romain PERRIN

using System;

// version 5 : saisie blindée (boucle de traitement tant que la valeur est irrecevable)
class CalculSurfaceRectangle
{
	public static void Main()
	{
		// variables
		double longueur = 0.0;
		double largeur = 0.0;
		double surface = 0.0;

		// saisie de la longueur
		do
		{
			Console.Write("Entrez la longueur du rectangle (réel >= 0) : ");
			longueur = double.Parse(Console.ReadLine());
		}
		while (longueur < 0.0);

		// saisie de la largeur
		do {
			Console.Write("Entrez la largeur du rectangle (réel >= 0) : ");
			largeur = double.Parse(Console.ReadLine());
		}
		while (largeur < 0.0);

		// calcul de la surface = longueur * largeur
		surface = longueur * largeur;

		// affichage de la surface
		Console.WriteLine("La surface vaut {0}x{1} = {2}.", longueur, largeur, surface);
	}
}