using System;

class ImageNiveauxDeGris
{
	public static void Main()
	{
		// Algorithme 1 : créer une image 2D d'entiers
		// formule : i*255 + j*255 / (H+L)
		const int hauteur = 10;
		const int largeur = 10;
		int[,] image = new int[hauteur,largeur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				int val = (i * 255 + j * 255) / (hauteur + largeur);
				if (val > 255)
				{
					image[i,j] = 255;
				}
				else
				{
					image[i,j] = val;
				}
			}
		}

		// affichage
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				Console.Write($"{image[i,j]:D3} ");
			}
			Console.Write("\n");
		}

		// Algorithme 2 : seuiller une image 2D d'entiers
		Console.Write("Entrez un seuil (seuillage) entre 0 et 255 : ");
		int seuil = int.Parse(Console.ReadLine());
		int[,] imageSeuillee = new int[hauteur,largeur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j] < seuil)
				{
					imageSeuillee[i,j] = 0;
				}
				else
				{
					imageSeuillee[i,j] = image[i,j];
				}
			}
		}

		// affichage
		Console.WriteLine("Image seuillée :");
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				Console.Write($"{imageSeuillee[i,j]:D3} ");
			}
			Console.Write("\n");
		}

		// Algorithme 3 : binariser une image 2D d'entiers
		Console.Write("Entrez un seuil (binarisation) entre 0 et 255 : ");
		seuil = int.Parse(Console.ReadLine());
		bool[,] imageBinarisee = new bool[hauteur,largeur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j] < seuil)
				{
					imageBinarisee[i,j] = false;
				}
				else
				{
					imageBinarisee[i,j] = true;
				}
			}
		}

		// affichage
		Console.WriteLine("Image binarisée :");
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (imageBinarisee[i,j])
				{
					Console.Write("T ");
				}
				else
				{
					Console.Write("F ");
				}
			}
			Console.Write("\n");
		}

		// Algorithme 4 : calcul de l'histogramme d'une image 2D d'entiers
		int[] histogramme = new int[256];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				// on ajoute 1 dans la case de l'histogramme dont l'indice est la valeur de la case (i,j) dans l'image
				histogramme[image[i,j]] += 1;
			}
		}
		// affichage
		Console.WriteLine("Histogramme de l'image originale :");
		for (int i = 0; i < 256; i++)
		{
			Console.Write($"{histogramme[i]} ");
		}
	}
}
