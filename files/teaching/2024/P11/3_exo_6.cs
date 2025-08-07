using System;

class ConversionDecimal8Bits
{
	public static void Main()
	{
		// variables
		int nombre = -1;
		int reste = 0;
		int[] puissances2 = new int[8] {0, 0, 0, 0, 0, 0, 0, 0};

		// saisir un entier entre 0 et 255
		while (nombre < 0 || nombre > 255)
		{
			Console.Write("Entrez un nombre entre 0 et 255 : ");
			nombre = int.Parse(Console.ReadLine());
		}
		reste = nombre;

		// division successives par les puissances de 2 et 2^0 à 2^7
		for (int puissance = 7; puissance >= 1; puissance--)
		{
			if (reste / (int)Math.Pow(2, puissance) == 0)
			{
				puissances2[puissance] = 0;
			}
			else
			{
				puissances2[puissance] = 1;
				reste = reste - (int)Math.Pow(2, puissance);
			}
		}
		if (reste == 1)
		{
			puissances2[0] = 1;
		}

		// affichage du résultat
		Console.Write($"Le nombre {nombre} équivaut à : ");
		for (int i = puissances2.Length - 1; i >= 0; i--)
		{
			Console.Write($"{puissances2[i]}");
		}
		Console.WriteLine(" sur 8 bits.");
	}
}
