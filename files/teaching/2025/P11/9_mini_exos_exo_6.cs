// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice6
{
	// Procédure : SupprimerMultiplesDeN
	// Entrée :	- liste : Liste<entier>
	//			- n : entier
	// Sortie :	void
	public static void SupprimerMultiplesDeN(List<int> liste, int n)
	{
		int indice = 0;
		
		while (indice < liste.Count)
		{
			if (liste[indice] % n == 0)
			{
				liste.RemoveAt(indice);
			}
			else
			{
				indice++;
			}
		}
	}
	
	// Procédure : AfficherListeEntier
	// Entrée :	- entiers : Liste<entier>
	// Sortie :	void
	public static void AfficherListeEntier(List<int> entiers)
	{
		Console.Write("Liste<entier> { ");
		foreach (int entier in entiers)
		{
			Console.Write(entier + " ");
		}
		Console.WriteLine("}");
	}
	
	
	public static void Main()
	{
		// créer une liste d'entiers
		List<int> entiers = new List<int>() {1, 2, 4, 9, 11, 25, 50, 100, 111};
		const int n = 2;
		AfficherListeEntier(entiers);
		
		// suppression des multiples de n
		Console.WriteLine("Suppression des multiples de " + n + ".");
		SupprimerMultiplesDeN(entiers, n);
		AfficherListeEntier(entiers);
		
	}
}
