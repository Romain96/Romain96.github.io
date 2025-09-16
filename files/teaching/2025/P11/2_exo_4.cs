// Auteur : Romain PERRIN

using System;

class Exercice4
{
	public static void Main()
	{
		// variables
		int hauteur;	// hauteur du triangle
		int nEspaces;	// nombre d'espaces à écrite avant la première étoile
		int nEtoiles;	// nombre d'étoiles à afficher sur la ligne courante

		// saisie de la hauteur
		Console.Write("Saisir la hauteur du triangle isocèle : ");
		hauteur = int.Parse(Console.ReadLine());

		nEtoiles = 1;
		nEspaces = hauteur - 1;

		// affichage du triangle isocèle ligne par ligne
		for (int ligne = 0; ligne < hauteur; ligne++)
		{
			// afficher nEspaces espaces
			for (int espace = 0; espace < nEspaces; espace++)
			{
				Console.Write(" ");	// Write et non WriteLine car ce sont les espaces d'une même ligne !
			}
			// afficher nEtoiles étoiles
			for (int etoile = 0; etoile < nEtoiles; etoile++)
			{
				Console.Write("*");	// Write et non WriteLine car ce sont les étoiles d'une même ligne !
			}
			Console.WriteLine();	// saut vers la ligne suivante
			nEtoiles = nEtoiles + 2;	// +2 étoiles sur la prochaine ligne
			nEspaces = nEspaces - 1;	// -2 espaces sur la prochaine ligne
		}
	}
}
