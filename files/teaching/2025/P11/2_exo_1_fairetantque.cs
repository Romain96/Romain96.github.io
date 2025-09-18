// Auteur : Romain PERRIN

using System;

class Exercice1FaireTantQue
{
	public static void Main()
	{
		// variable
		int i = 7;

		// affichage des entiers de 7 à 77
		do
		{
			Console.WriteLine(i);
			i = i + 1;
		}
		while (i <= 77);
	}
}
