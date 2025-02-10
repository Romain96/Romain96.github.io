// Auteur : Romain PERRIN

using System;

class AfficherTriangleRectangle
{
	// Principe : Parcourir chaque ligne jusqu'à la hauteur saisie par l'utilisateur tout en maintenant à jour le nombre
	// d'étoile par ligne en commançant à 1 et en ajoutant 2 à chaque ligne générée.
	// Pour chaque ligne afficher un caractère étoile à la fois jusqu'au nombre requis puis ajouter le caractère de retour à la ligne.
	public static void Main()
	{
		// variables
		int nbEtoiles = 1;	// nombre d'étoiles à afficher sur la ligne courante
		int hauteur = 0;	// hauteur du triangle (nombre de ligne à générer)

		// saisie de la hauteur du triangle (>=0)
		Console.Write("Entrez la hauteur du triangle : ");
		hauteur = int.Parse(Console.ReadLine());

		// génération de hauteur lignes
		for (int ligne = 1; ligne <= hauteur; ligne++)
		{
			// affichage de nombreEtoiles étoiles
			for (int indiceEtoile = 1; indiceEtoile <= nbEtoiles; indiceEtoile++)
			{
				Console.Write("*");
			}
			// ajout du retour à la ligne
			Console.Write("\n");
			// mise à jour du nombre d'étoiles pour la ligne suivante (+2)
			nbEtoiles += 2;
		}
	}
}
