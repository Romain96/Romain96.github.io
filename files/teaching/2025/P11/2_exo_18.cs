// Auteur : Romain PERRIN

using System;

class Exercice18
{
	public static void Main()
	{
		// variables
		int hauteur, ligne, colonne;

		// saisir la hauteur
		Console.Write("Saisir la hauteur de la matrice : ");
		hauteur = int.Parse(Console.ReadLine());

		for (ligne = 0; ligne < hauteur; ligne++)
		{
			for (colonne = 0; colonne < hauteur; colonne++)
			{
				if (colonne >= ligne)
				{
					Console.Write("1 ");
				}
				else
				{
					Console.Write("0 ");
				}
			}
			Console.WriteLine("");
		}
	}
}
