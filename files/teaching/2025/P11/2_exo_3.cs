// Auteur : Romain PERRIN

using System;

class Exercice3
{
	public static void Main()
	{
		// constantes
		const int NB_ETOILES_LIGNE_1 = 1;	// une seule étoile sur la première ligne
		const int NB_ETOILES_LIGNE_SUIVANTE = 2;	// 2 étoiles à ajouter à la ligne suivante
		
		// variables
		int hauteur;	// hauteur du triangle
		int nEtoiles = NB_ETOILES_LIGNE_1;	// nombre d'étoiles à afficher sur la ligne courante
		
		// saisie de la hauteur
		Console.Write("Saisir la hauteur du triangle rectangle : ");
		hauteur = int.Parse(Console.ReadLine());

		// affichage du triangle rectangle ligne par ligne
		for (int ligne = 1; ligne <= hauteur; ligne++)
		{
			// afficher nEtoiles étoiles
			for (int etoile = 1; etoile <= nEtoiles; etoile++)
			{
				Console.Write("*");	// Write et non WriteLine car ce sont les étoiles d'une même ligne !
			}
			Console.WriteLine();	// saut vers la ligne suivante
			nEtoiles = nEtoiles + NB_ETOILES_LIGNE_SUIVANTE;	// +2 étoiles sur la prochaine ligne
		}
	}
}
