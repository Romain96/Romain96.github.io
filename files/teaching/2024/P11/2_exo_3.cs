// Auteur : Romain PERRIN

using System;

class AfficherTriangleIsocele
{
	// Principe : Parcourir chaque ligne jusqu'à la hauteur saisie par l'utilisateur tout en maintenant à jour le nombre
	// d'étoile par ligne (initialisé à 1 et augmentant de 2 par ligne) et le nombre d'espaces (commençant à hauteur-1 et diminuant de 1 par ligne).
	// Pour chaque ligne afficher un caractère espace à la fois le bon nombre de fois puis un caractère étoile à la fois jusqu'au nombre requis 
	// et enfin puis ajouter le caractère de retour à la ligne.
	public static void Main()
	{
		// variables
		int nbEspaces = 0;	// nombre d'espaces à afficher avant la première étoile sur la ligne courante
		int nbEtoiles = 1;	// nombre d'étoiles à afficher sur la ligne courante
		int hauteur = 0;	// hauteur du triangle (nombre de ligne à générer)

		// saisie de la hauteur du triangle (>=0)
		Console.Write("Entrez la hauteur du triangle : ");
		hauteur = int.Parse(Console.ReadLine());
		nbEspaces = hauteur - 1;

		// génération de hauteur lignes
		for (int ligne = 1; ligne <= hauteur; ligne++)
		{
			// affichage de nombreEspaces espaces
			for (int indiceEspace = 1; indiceEspace <= nbEspaces; indiceEspace++)
			{
				Console.Write(" ");
			}
			// affichage de nombreEtoiles étoiles
			for (int indiceEtoile = 1; indiceEtoile <= nbEtoiles; indiceEtoile++)
			{
				Console.Write("*");
			}
			// ajout du retour à la ligne
			Console.Write("\n");
			// mise à jour du nombre d'espaces (-1) et du nombre d'étoiles (+2) pour la ligne suivante
			nbEspaces -= 1;
			nbEtoiles += 2;
			}
	}
}
