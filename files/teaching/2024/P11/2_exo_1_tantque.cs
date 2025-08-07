// Auteur : Romain PERRIN

using System;

class AfficherEntiersBoucleTantQue
{
	public static void Main()
	{
		// variables
		const int BORNE_INF = 7;
		const int BORNE_SUP = 77;
		int i = BORNE_INF;

		// parcours des entiers de debut à fin (bornes incluses)
		while (i <= BORNE_SUP)
		{
			// affichage de i
			Console.WriteLine($"{i}");
			i += 1;
		}
	}
}
