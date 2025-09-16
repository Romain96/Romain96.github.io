// Auteur : Romain PERRIN

using System;

class Exercice12
{
	public static void Main()
	{
		// variables
		int n;
		bool estPremier = true;	// vrai par défaut

		// saisie de n
		Console.Write("Saisir un nombre : ");
		n = int.Parse(Console.ReadLine());

		// pour que n soit premier, il ne doît être divisible par aucun de ces nombres
		// on sort de la boucle si i = n ou si estPremier devient faux (sortie précoce)
		for (int i = 2; i < n && estPremier; i++)
		{
			// divisible donc pas premier
			if (n % i == 0)
			{
				estPremier = false;	// permet d'interrompre la boucle
			}
		}

		// si on est sorti de la boucle avec estPremier qui vaut vrai alors n est premier
		if (estPremier)
		{
			Console.WriteLine($"{n} est un nombre premier.");
		}
		// sinon on est sorti prématurément donc n n'est pas premier
		else
		{
			Console.WriteLine($"{n} n'est pas un nombre premier.");
		}
	}
}
