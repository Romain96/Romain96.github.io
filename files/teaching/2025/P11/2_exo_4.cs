// Auteur : Romain PERRIN

using System;

class Exercice4
{
	public static void Main()
	{
		// constantes
		const int NB_ETOILES_LIGNE_1 = 1;	// une seule étoile sur la première ligne
		const int NB_ETOILES_LIGNE_SUIVANTE = 2;	// +2 étoiles à ajouter à la ligne suivante
		const int NB_ESPACES_LIGNE_SUIVANTE = -1;	// -1 espace à la ligne suivante
		
		// variables
		int hauteur;	// hauteur du triangle
		int nEspaces;	// nombre d'espaces à écrite avant la première étoile
		int nEtoiles;	// nombre d'étoiles à afficher sur la ligne courante

		// saisie de la hauteur
		Console.Write("Saisir la hauteur du triangle isocèle : ");
		hauteur = int.Parse(Console.ReadLine());

		nEtoiles = NB_ETOILES_LIGNE_1;
		nEspaces = hauteur - 1;

		// affichage du triangle isocèle ligne par ligne
		for (int ligne = 1; ligne <= hauteur; ligne++)
		{
			// afficher nEspaces espaces
			for (int espace = 1; espace <= nEspaces; espace++)
			{
				Console.Write(" ");	// Write et non WriteLine car ce sont les espaces d'une même ligne !
			}
			// afficher nEtoiles étoiles
			for (int etoile = 1; etoile <= nEtoiles; etoile++)
			{
				Console.Write("*");	// Write et non WriteLine car ce sont les étoiles d'une même ligne !
			}
			Console.WriteLine();	// saut vers la ligne suivante
			nEtoiles = nEtoiles + NB_ETOILES_LIGNE_SUIVANTE;	// +2 étoiles sur la prochaine ligne
			nEspaces = nEspaces + NB_ESPACES_LIGNE_SUIVANTE;	// -1 espace sur la prochaine ligne
		}
	}
}
