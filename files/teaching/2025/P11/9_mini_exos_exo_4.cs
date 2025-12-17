// Auteur : Romain PERRIN

using System;

class Exercice4
{
	// Fonction : RechercherValeurN
	// Entrée :	- seuil : réel
	// Sortie : entier
	public static int RechercherValeurN(double seuil)
	{
		int n = 1;
		
		while (1.0 / n >= seuil)
		{
			n++;
		}
		
		return n;
	}
	
	
	public static void Main()
	{
		// saisir un seuil (réel > 0)
		string saisie;
		double seuil;
		
		do
		{
			do
			{
				Console.Write("Saisir un seuil (réel > 0) : ");
				saisie = Console.ReadLine();
			}
			while (saisie.Length < 1);
			seuil = double.Parse(saisie);
		}
		while (seuil <= 0.0);
		
		int n = RechercherValeurN(seuil);
		Console.WriteLine("Pour n = " + n + ", 1/" + n + " = " + 1.0/n + " < " + seuil);
	}
}
