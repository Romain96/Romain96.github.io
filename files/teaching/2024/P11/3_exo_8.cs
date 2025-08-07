using System;

class DecalerEtInsererValeurTableauEntierPartiellementInitialiseEtTrieCroissant
{
	public static void Main()
	{
		// variables
		int nVal = 6;	// nombre de cases pour lesquelles le tableau est initialisé et trié
		int[] tab = new int[10] {1, 3, 5, 8, 14, 20, 0, 0, 0, 0};
		int valeur = 0;
		int indice = 0;

		// affichage du tableau
		Console.Write("T < ");
		foreach (int val in tab)
		{
			Console.Write($"{val} ");
		}
		Console.WriteLine(">");

		// saisir la valeur seuil
		Console.Write("Entrez la valeur à insérer : ");
		valeur = int.Parse(Console.ReadLine());

		// parcours du tableau jusqu'à trouver une valeur supérieure au seuil ou atteindre l'indice nVal
		for (indice = 0; indice < nVal && tab[indice] <= valeur; indice++)
		{
			// on ne fait rien !
		}
		Console.WriteLine($"Indice d'insertion : {indice}.");

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
