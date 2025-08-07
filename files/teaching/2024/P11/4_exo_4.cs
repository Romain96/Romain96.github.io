using System;

class ImagesCouleursRGB
{
	public static void Main()
	{
		// image
		const int hauteurImage = 4;
		const int largeurImage = 4;
		int[,] image = new int[hauteurImage,largeurImage] {
			{91, 97, 97, 30},
			{97, 92, 97, 97},
			{97, 97, 93, 97},
			{30, 97, 97, 94}
		};
		// affichage de l'image
		Console.WriteLine("Image ANSI :");
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				Console.Write($"{image[i,j]:D2} ");
			}
			Console.Write("\n");
		}

		// Algorithme 1 : création de la table de conversion
		const int hauteurTab = 16;
		const int largeurTab = 4;
		int[,] tableConversion = new int[hauteurTab,largeurTab]{
			{30, 0, 0, 0},
			{31, 255, 0, 0},
			{32, 0, 255, 0},
			{33, 255, 255, 0},
			{34, 0, 0, 255},
			{35, 255, 0, 255},
			{36, 0, 255, 255},
			{37, 255, 255, 255},
			{90, 85, 85, 85},
			{91, 255, 85, 85},
			{92, 85, 255, 85},
			{93, 255, 255, 85},
			{94, 85, 85, 255},
			{95, 255, 85, 255},
			{96, 85, 255, 255},
			{97, 255, 255, 255}
		};

		// Algorithme 2 : afficher la valeur des pixels RGB en fonction des codes ANSI
		Console.WriteLine("valeurs RGB des codes ANSI :");
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				// parcours de la table en recherchant le code ANSI dans la première colonne
				bool trouve = false;
				int k = 0;
				int r = -1;
				int g = -1;
				int b = -1;
				while (k < hauteurTab && trouve == false)
				{
					if (tableConversion[k,0] == image[i,j])
					{
						r = tableConversion[k,1];
						g = tableConversion[k,2];
						b = tableConversion[k,3];
						trouve = true;
					}
					k++;
				}
				Console.Write($"({r:D3},{g:D3},{b:D3}) ");
			}
			Console.Write("\n");
		}

		// Algorithme 3 : convertir une image ANSI (2D) en image RGB (3D)
		// Précondition : tous les codes de l'image d'entrée sont des codes ANSI valides
		Console.WriteLine("Conversion en RGB :");
		int[,,] imageConversionRGB = new int[hauteurImage, largeurImage, 3];
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				// parcours de la table en recherchant le code ANSI dans la première colonne
				bool trouve = false;
				int k = 0;
				int r = -1;
				int g = -1;
				int b = -1;
				while (k < hauteurTab && trouve == false)
				{
					if (tableConversion[k,0] == image[i,j])
					{
						r = tableConversion[k,1];
						g = tableConversion[k,2];
						b = tableConversion[k,3];
						trouve = true;
					}
					k++;
				}
				imageConversionRGB[i,j,0] = r;
				imageConversionRGB[i,j,1] = g;
				imageConversionRGB[i,j,2] = b;
			}
		}
		// affichage
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				Console.Write($"({imageConversionRGB[i,j,0]:D3},{imageConversionRGB[i,j,1]:D3},{imageConversionRGB[i,j,2]:D3}) ");
			}
			Console.Write("\n");
		}

		// Algorithme 4 : conversion d'une image RGB (3D) en image ANSI (2D)
		// Précondition : toutes les valeurs de l'image (les triplets RGB) donnent des codes ANSI valides
		Console.WriteLine("Conversion en ANSI :");
		int[,] imageConversionANSI = new int[hauteurImage, largeurImage];
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				// parcours de la table en recherchant le code ANSI dans la première colonne
				bool trouve = false;
				int k = 0;
				int code = 0;
				while (k < hauteurTab && trouve == false)
				{
					if (tableConversion[k,1] == imageConversionRGB[i,j,0] && tableConversion[k,2] == imageConversionRGB[i,j,1] && tableConversion[k,3] == imageConversionRGB[i,j,2])
					{
						code = tableConversion[k,0];
						trouve = true;
					}
					k++;
				}
				imageConversionANSI[i,j] = code;
			}
		}
		// affichage
		for (int i = 0; i < hauteurImage; i++)
		{
			for (int j = 0; j < largeurImage; j++)
			{
				Console.Write($"{imageConversionANSI[i,j]:D2} ");
			}
			Console.Write("\n");
		}
	}
}
