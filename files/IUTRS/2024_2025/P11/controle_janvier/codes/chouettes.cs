// Auteur : Romain PERRIN

using System;

public class Chouettes
{
	public static void Main()
	{
		Console.WriteLine("Avec la variante 1 du calcul :");
		for (int annee = 1; annee < 11; annee++)
		{
			int chouettes = NombreDeChouettes1(annee);
			Console.WriteLine($"Il y a {chouettes} chouettes après {annee} année(s).");
		}

		Console.WriteLine("Avec la variante 2 du calcul :");
		for (int annee = 1; annee < 11; annee++)
		{
			int chouettes = NombreDeChouettes2(annee);
			Console.WriteLine($"Il y a {chouettes} chouettes après {annee} année(s).");
		}
	}
	
	public static int NombreDeChouettes1(int annee)
	{
		int chouettes = 10;

		for (int i = 1; i <= annee; i++)
		{
			// suppression avant si l'année est divisible par 3
			if (i % 3 == 0)
			{
				chouettes = chouettes - 6;
			}
			chouettes = chouettes + (chouettes / 2) * 8;
		}

		return chouettes;
	}

	public static int NombreDeChouettes2(int annee)
	{
		int chouettes = 10;

		for (int i = 1; i <= annee; i++)
		{
			chouettes = chouettes + (chouettes / 2) * 8;

			// suppression après si l'année est divisible par 3
			if (i % 3 == 0)
			{
				chouettes = chouettes - 6;
			}
		}

		return chouettes;
	}
}