using System;

class RemplirTableauEntierPartiellementInitialiseEtTrieCroissant
{
	public static void Main()
	{
		// variables
		int nVal = 0;	// nombre de cases pour lesquelles le tableau est initialisé et trié
		int[] tab = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		int valeur = 0;
		int indice = 0;

		// affichage du tableau
		Console.Write("T < ");
		foreach (int val in tab)
		{
			Console.Write($"{val} ");
		}
		Console.WriteLine(">");

		// remplir la première case avec le premier entier saisi
		Console.Write("Entrez la valeur à insérer : ");
		valeur = int.Parse(Console.ReadLine());
		tab[0] = valeur;
		nVal = 1;

		// Affichage du tableau
		Console.Write("T < ");
		foreach (int val in tab)
		{
			Console.Write($"{val} ");
		}
		Console.WriteLine(">");

		// demander 9 entiers et les insérer dans le tableau tab
		for (int n = 1; n <= 9; n++)
		{	

			// saisir la valeur à insérer
			Console.Write("Entrez la valeur à insérer : ");
			valeur = int.Parse(Console.ReadLine());

			// parcours du tableau jusqu'à trouver une valeur supérieure au seuil ou atteindre l'indice nVal
			for (indice = 0; indice < nVal && tab[indice] <= valeur; indice++)
			{
				// on ne fait rien !
			}

			// décalage des valeurs entre indice et nVal
			for (int i = nVal; i > indice; i--)
			{
				// décalage de i en i+1
				tab[i] = tab[i-1];
			}

			// insertion de la valeur à l'indice
			tab[indice] = valeur;
			nVal += 1;

			// affichage du tableau
			Console.Write("T < ");
			foreach (int val in tab)
			{
				Console.Write($"{val} ");
			}
			Console.WriteLine(">");
		}
	}
}
