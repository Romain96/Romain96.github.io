// Auteur : Romain PERRIN

using System;

class Exercice4
{
	// Fonction : SaisirReel
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : reel
	public static float SaisirReel(string texte)
	{
		Console.Write(texte);
		return float.Parse(Console.ReadLine());
	}
	
	// Fonction : Compare
	// Entrée :	- a : réel
	//				- b : réel
	// Type de sortie : entier (-1, 0 ou 1)
	public static int Compare(float a, float b)
	{
		if (a < b)
		{
			return -1;
		}
		else if (b < a)
		{
			return 1;
		}
		else
		{
			return 0;	// égalité
		}
	}
	
	public static void Main()
	{
		float n1 = SaisirReel("Saisir un réel n1 : ");
		float n2 = SaisirReel("Saisir un réel n2 : ");
		int comparaison = Compare(n1, n2);
		
		if (comparaison == -1)
		{
			Console.WriteLine($"{n1} < {n2}");
		}
		else if (comparaison == 1)
		{
			Console.WriteLine($"{n1} > {n2}");
		}
		else if (comparaison == 0)
		{
			Console.WriteLine($"{n1} = {n2}");
		}
		else
		{
			Console.WriteLine("Erreur !");
		}
	}
}
