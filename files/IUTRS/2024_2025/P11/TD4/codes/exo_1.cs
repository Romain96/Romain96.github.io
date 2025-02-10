using System;

class ImagesNoirEtBlanc
{
	public static void Main()
	{
		// Algorithme 1 : créer une image de taille hauteur * largeur avec la diagonale à faux et le reste à vrai
		const int hauteur = 4;
		const int largeur = 4;
		bool[,] image = new bool[hauteur,largeur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (i == j)
				{
					image[i,j] = false;
				}
				else
				{
					image[i,j] = true;
				}
			}
		}

		// afficher l'image
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j])
				{
					Console.Write("V ");
				}
				else
				{
					Console.Write("F ");
				}
			}
			Console.Write("\n");
		}


		// Algorithme 2 : Afficher le nombre de pixels blancs (vrai) et noirs (faux) de l'image
		int nBlancs = 0;
		int nNoirs = 0;
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j])
				{
					nBlancs += 1;
				}
				else
				{
					nNoirs += 1;
				}
			}
		}
		Console.WriteLine($"Pixels blancs : {nBlancs}\nPixels noirs : {nNoirs}");


		// Algorithme 3 : Inverser une image (inversion des valeurs)
		bool[,] imageInverseValeur = new bool[hauteur,largeur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (image[i,j])
				{
					imageInverseValeur[i,j] = false;
				}
				else
				{
					imageInverseValeur[i,j] = true;
				}
			}
		}

		// affichage de l'inverse des valeurs
		Console.WriteLine("Inversion des valeurs :");
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (imageInverseValeur[i,j])
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


		// Algorithme 3 : Inverser une image (inversion des dimensions)
		bool[,] imageInverseDimensions = new bool[largeur,hauteur];
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				imageInverseDimensions[j,i] = image[i,j];
			}
		}

		// affichage de l'inverse des valeurs
		Console.WriteLine("Inversion des dimensions :");
		for (int i = 0; i < hauteur; i++)
		{
			for (int j = 0; j < largeur; j++)
			{
				if (imageInverseDimensions[j,i])
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


		// Algorithme 4 : Comparaison de deux images
		// Précondition : les deux images sont de même dimensions
		bool quitter = false;
		bool diff = false;
		for (int i = 0; i < hauteur || quitter == false; i++)
		{
			for (int j = 0; j < largeur || quitter == false; j++)
			{
				if (image[i,j] != imageInverseValeur[i,j])
				{
					diff = true;
					quitter = true;
				}
			}
		}
		Console.WriteLine($"Comparaison de l'image originale et l'inverse des valeurs : Différentes ? {diff}");

		quitter = false;
		diff = false;
		for (int i = 0; i < hauteur && quitter == false; i++)
		{
			for (int j = 0; j < largeur && quitter == false; j++)
			{
				if (image[i,j] != image[i,j])
				{
					diff = true;
					quitter = true;
				}
			}
		}
		Console.WriteLine($"Comparaison de l'image originale et elle-même : Différentes ? {diff}");

		// création d'une image de 9x9
		const int hauteurImage = 9;
		const int largeurImage = 9;
		bool[,] imageDiag = new bool[hauteurImage,largeurImage];
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				if (i == j)
				{
					imageDiag[i,j] = false;
				}
				else
				{
					imageDiag[i,j] = true;
				}
			}
		}
		// afficher l'image
		Console.WriteLine("Image 9x9 :");
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				if (imageDiag[i,j])
				{
					Console.Write("V ");
				}
				else
				{
					Console.Write("F ");
				}
			}
			Console.Write("\n");
		}

		// création du motif (2x2)
		const int hauteurMotif = 2;
		const int largeurMotif = 2;
		bool[,] motif = new bool[hauteurMotif,largeurMotif];
		for (int i = 0; i < hauteurMotif; i++)
		{
			for (int j = 0; j < largeurMotif; j++)
			{
				if (i == j)
				{
					motif[i,j] = false;
				}
				else
				{
					motif[i,j] = true;
				}
			}
		}
		// afficher du motif
		Console.WriteLine("Motif 2x2 :");
		for (int i = 0; i < hauteurMotif; i++)
		{
			for (int j = 0; j < largeurMotif; j++)
			{
				if (motif[i,j])
				{
					Console.Write("V ");
				}
				else
				{
					Console.Write("F ");
				}
			}
			Console.Write("\n");
		}

		// Algorithme 5 : recherche et quantification d'un motif dans une image
		// Précondition : les dimensions du motif sont inférieures à celles de l'image
		quitter = false;
		diff = false;
		int nMotif = 0;
		for (int i1 = 0; i1 < hauteurImage - hauteurMotif; i1++)
		{
			for (int j1 = 0; j1 < largeurImage - largeurMotif; j1++)
			{
				quitter = false;
				diff = false;
				for (int i2 = 0; i2 < hauteurMotif && quitter == false; i2++)
				{
					for (int j2 = 0; j2 < largeurMotif && quitter == false; j2++)
					{
						if (imageDiag[i1 + i2, j1 + j2] != motif[i2, j2])
						{
							diff = true;
							quitter = true;
						}
					}
				}
				if (diff == false)
				{
					nMotif += 1;
				}
			}
		}
		Console.WriteLine($"Recherche du motif de taille {hauteurMotif}x{largeurMotif} dans une image {hauteurImage}x{largeurImage} : {nMotif} fois.");
	}
}
