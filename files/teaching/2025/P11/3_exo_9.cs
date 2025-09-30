// Auteur : Romain PERRIN

using System;

class Exercice9
{
	// Fonction : SaisirEntier
	// Entrée :	- texte : chaîne de caractères
	// Type de sortie : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}
	
	// Procédure : Classer
	// Entrée :	- a : entier
	//				- b : entier
	//				- min : référence entier
	//				- max : référence entier
	// Type de sortie : void
	public static void Classer(int a, int b, ref int min, ref int max)
	{
		if (a <= b)
		{
			min = a;
			max = b;
		}
		else
		{
			min = b;
			max = a;
		}
	}
	
	public static void Main()
	{
		int a = SaisirEntier("Saisir un nombre entier a : ");
		int b = SaisirEntier("Saisir un nombre entier b : ");
		int min = 0;
		int max = 0;
		
		// Pour tester la question 2
		//Console.WriteLine($"Avant classement : a = {a}, b = {b}, min = {min}, max = {max}");
		//Classer(a, b, ref min, ref max);
		//Console.WriteLine($"Après classement : a = {a}, b = {b}, min = {min}, max = {max}");
		
		// question 3
		int c = SaisirEntier("Saisir un nombre entier c : ");
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		Classer(a, b, ref min, ref max);
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		a = min;
		b = max;
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		Classer(a, c, ref min, ref max);
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		a = min;
		c = max;
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		Classer(b, c, ref min, ref max);
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
		b = min;
		c = max;
		Console.WriteLine($"a = {a}, b = {b}, c = {c}, min = {min}, max = {max}");
	}
}
