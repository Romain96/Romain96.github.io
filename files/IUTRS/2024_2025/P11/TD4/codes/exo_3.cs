using System;

class ImagesCouleurs
{
	public static void Main()
	{
		// image
		const int hauteur = 7;
		const int largeur = 7;
		int[,] image = new int[hauteur,largeur] {
			{94, 94, 34, 94, 34, 34, 94},
			{94, 34, 34, 32, 34, 94, 34},
			{94, 34, 32, 32, 92, 34, 94},
			{94, 34, 32, 32, 92, 34, 94},
			{94, 92, 32, 32, 32, 92, 94},
			{97, 97, 90, 30, 30, 97, 94},
			{97, 97, 30, 30, 90, 97, 97}
		};

		// Algorithme 1 : afficher l'image en couleurs en interprétant les codes ANSI
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j] >= 30 && image[i,j] <= 37 || image[i,j] >= 90 && image[i,j] <= 97)
				{
					Console.Write($"\u001b[{image[i,j]}m * \u001b[0m");
				}
				else
				{
					// erreur
					Console.Write(" ");
				}
			}
			Console.Write("\n");
		}
	}
}
