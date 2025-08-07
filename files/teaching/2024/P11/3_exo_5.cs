using System;

class ManipulationsDeNotesDansUnTableau
{
	public static void Main()
	{
		// variable globale
		const int taille = 12;
		int[] lesNotes = new int[taille] {11, 12, 11, 10, 6, 9, 15, 10, 15, 14, 17, 2};

		// Algorithme 1 : affichage de toutes les notes
		Console.Write("lesNotes < ");
		foreach (int note in lesNotes)
		{
			Console.Write($"{note} ");
		}
		Console.WriteLine(">");

		// Algorithme 2 : affichage de la plus petite note
		int minimum = lesNotes[0];
		for (int i = 0; i < taille; i++)
		{
			if (lesNotes[i] < minimum)
			{
				minimum = lesNotes[i];
			}
		}
		Console.WriteLine($"La note minimale est {minimum}.");

		// Algorithme 3 : affichage des notes dans l'ordre inverse du tableau
		Console.Write("lesNotes (à l'envers) < ");
		for (int i = taille - 1; i >= 0; i--)
		{
			Console.Write($"{lesNotes[i]} ");
		}
		Console.WriteLine(">");

		// Algorithme 4 : affichage des notes supérieures à 12
		Console.Write("lesNotes (>= 12) < ");
		foreach (int note in lesNotes)
		{
			if (note >= 12)
			{
				Console.Write($"{note} ");
			}
		}
		Console.WriteLine(">");

		// Algorithme 5 : affichage de la moyenne des notes supérieures à 10
		double moyenneSup10 = 0.0;
		int valSup10 = 0;
		foreach (int note in lesNotes)
		{
			if (note >= 10)
			{
				moyenneSup10 += note;
				valSup10 += 1;
			}
		}
		moyenneSup10 = moyenneSup10 / valSup10;
		Console.WriteLine($"La moyenne des notes supérieures à 10 est de {moyenneSup10}.");

		// Algorithme 6 : affichage de l'indice de la première case contenant 6
		int indicePremier6 = -1;
		bool trouvePremier6 = false;
		for (int i = 0; i < taille && trouvePremier6 == false; i++)
		{
			if (lesNotes[i] == 6)
			{
				indicePremier6 = i;
				trouvePremier6 = true;
			}
		}
		Console.WriteLine($"L'indice du premier 6 est {indicePremier6} ({indicePremier6 + 1}e élément).");

		// Algorithme 7 : Affichage de la dernière case contenant la valeur 10
		int indiceDernier10 = -1;
		bool trouveDernier10 = false;
		for (int i = taille - 1; i >= 0 && trouveDernier10 == false; i--)
		{
			if (lesNotes[i] == 10)
			{
				indiceDernier10 = i;
				trouveDernier10 = true;
			}
		}
		Console.WriteLine($"L'indice du dernier 10 est {indiceDernier10} ({indiceDernier10 + 1}e élément).");

		// Algorithme 8 : affichage de si il y a ou non la valeur 20 dans le tableau
		bool existeValeur20 = false;
		for (int i = 0; i < taille && existeValeur20 == false; i++)
		{
			if (lesNotes[i] == 20)
			{
				existeValeur20 = true;
			}
		}
		if (existeValeur20)
		{
			Console.WriteLine("La valeur 20 existe dans le tableau.");
		}
		else
		{
			Console.WriteLine("La valeur 20 n'existe pas dans le tableau.");
		}
	}
}
