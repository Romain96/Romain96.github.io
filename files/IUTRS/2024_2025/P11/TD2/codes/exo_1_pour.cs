// Auteur : Romain PERRIN

using System;
s
class AfficherEntiersBouclePour
{
	public static void Main()
	{
		// variables
		const int BORNE_INF = 7;
		const int BORNE_SUP = 77;

		// parcours des entiers de debut à fin (bornes incluses)
		for (int i = BORNE_INF; i <= BORNE_SUP; i++)
		{
			// affichage de i
			Console.WriteLine($"{i}");
		   }
	}
}
