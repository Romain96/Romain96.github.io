using System;

class AfficherTableauEntier1D
{
	public static void Main()
	{
		// variables
		const int taille = 10;
		int[] tab = new int[taille] {4, 3, 1, 12, 0, 7, 24, 0, 2, 5};
		
		// parcourir les 10 cases du tableau et afficher le contenu de la ième case
		Console.Write("T < ");
		for (int i = 0; i < taille; i++)
		{
			Console.Write($"{tab[i]} ");
		}
		Console.WriteLine(">");
	}
}
