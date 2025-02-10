// Auteur : Romain PERRIN

using System;

class OperationsEntier
{
	// Idée : Maintenir à jour entier saisi par l'utilisateur.
		// Tant que la saisie n'est pas "4", lire la saisie entre 1 et 4 et appliquer l'opération correspondant sur le nombre stocké
		// si "4" est saisi, quitter la boucle.
	public static void Main()
	{
		// variables
		int nombre = 0;	// nombre saisi par l'utilisateur
		int operation = 0;	// numéro de l'opération à effectuer (saisi par l'utilisateur)
		bool continuer = true;	// décide quand quitter la boucle de traitement

		// saisie du nombre entier
		Console.Write("Saisissez un entier : ");
		nombre = int.Parse(Console.ReadLine());

		// boucle de traitement
		while (continuer == true)
		{
			// saisie de l'opération (1-4)
			Console.Write("Le nombre est {0}\n1 - Ajouter 1\n2 - Multiplier par 2\n3 - Soustraire 4\n4 - Quitter\nEntrez votre choix : ", nombre);
			operation = int.Parse(Console.ReadLine());

			// traitement de l'opération
			if (operation == 1)
			{
				nombre = nombre + 1;
			}
			else if (operation == 2)
			{
				nombre = nombre * 2;
			}
			else if (operation == 3)
			{
				nombre = nombre - 4;
			}
			else if (operation == 4)
			{
				continuer = false;
			}
			// else : on ignore la saisie
		}
	}
}
