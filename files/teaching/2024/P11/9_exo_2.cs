// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ChiffrementAmeliore
{
	// Fonction : DonnerIndice
	// Précondition : c appartient à l'ensemble {'a', ..., 'z', ' '}
	// Entrée : 	- c : caractère
	// Local :		/
	// Sortie :		- indice : entier
	public static int DonnerIndice(char c)
	{
		if (c == ' ')
		{
			return 26;
		}
		return (int)c - (int)'a';
	}

	// Fonction : DonnerCaractere
	// Précondition : indice entre 0 et 26
	// Entrée : 	- indice : entier
	// Local :		/
	// Sortie :		- c : caractère
	public static char DonnerCaractere(int indice)
	{
		if (indice == 26)
		{
			return ' ';
		}
		return (char)(indice + (int)'a');
	}

	// Fonction : Code2Gramme
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'a', ..., 'z', ' '}
	// Entrée : 	- grille : tableau 2D de 27*27 chaînes de caractères
	//				- message : chaîne de caractères
	// Local :		- indice1, indice2 : entiers
	// Sortie :		- messageCode : chaîne de caractères
	public static string Code2Gramme(string[,] grille, string message)
	{
		string messageCode = "";
		int indice1 = -1;
		int indice2 = -1;
		for (int i = 0; i < message.Length - 1; i += 2)
		{
			indice1 = DonnerIndice(message[i]);
			indice2 = DonnerIndice(message[i + 1]);
			messageCode = messageCode + grille[indice1, indice2];
		}
		return messageCode;
	}

	// Fonction : RechercheDansGrille
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'a', ..., 'z', ' '}
	// Entrée : 	- grille : tableau 2D de 27*27 chaînes de caractères
	//				- message : chaîne de caractères
	//				- indice1 : entier (modifiable)
	//				- indice2 : entier (modifiable)
	// Local :		- i, j : entiers
	// Sortie :		void : chaîne de caractères
	public static void RechercheDansGrille(string[,] grille, string message, ref int indice1, ref int indice2)
	{
		indice1 = -1;
		indice2 = -1;
		for (int i = 0; i < 27; i++)
		{
			for (int j = 0; j < 27; j++)
			{
				if (grille[i, j].Equals(message))
				{
					indice1 = i;
					indice2 = j;
					return;
				}
			}
		}
	}

	// Fonction : Decode2Gramme
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'a', ..., 'z', ' '}
	// Entrée : 	- grille : tableau 2D de 27*27 chaînes de caractères
	//				- message : chaîne de caractères
	// Local :		/
	// Sortie :		- messageDecode : chaîne de caractères
	public static string Decode2Gramme(string[,] grille, string message)
	{
		string messageDecode = "";
		int indice1 = -1;
		int indice2 = -1;
		for (int i = 0; i < message.Length; i += 3)
		{
			// extraction de la sous-chaîne débutant en i et ayant une longueur de 3 caractères, soit ~ message[i, i+1]
			string msg = message.Substring(i, 3);
			RechercheDansGrille(grille, msg, ref indice1, ref indice2);
			if (indice1 != -1 && indice2 != -1)
			{
				messageDecode = messageDecode + DonnerCaractere(indice1) + DonnerCaractere(indice2);
			}
		}
		return messageDecode;
	}

	// Bonus : générer une grille avec des entiers aléatoires uniques entre 100 et 999
	public static void InitGrille(string[,] grille)
	{
		Random gen = new Random();
		List<int> uniques = new List<int>();
		int compteur = 0;
		while (compteur < grille.GetLength(0) * grille.GetLength(1))
		{
			int entier = gen.Next(100, 1000);
			if (!uniques.Contains(entier))
			{
				uniques.Add(entier);
				compteur++;
			}
		}
		for (int i = 0; i < uniques.Count; i++)
		{
			grille[i / grille.GetLength(0), i % grille.GetLength(0)] = uniques[i].ToString();
		}
	}

	public static void Main()
	{
		string[,] grille = new string[27, 27];
		InitGrille(grille);
		Console.WriteLine("Grille aléatoire :");
		for (int i = 0; i < 27; i++)
		{
			for (int j = 0; j < 27; j++)
			{
				Console.Write($"{grille[i,j]} ");
			}
			Console.Write("\n");
		}
		Console.Write("\n");

		// saisir un message
		Console.Write("Entrer un message : ");
		string messageU = Console.ReadLine().ToLower();

		// coder et afficher le résultat
		string messageUCode = Code2Gramme(grille, messageU);
		Console.WriteLine($"Le message codé est '{messageUCode}'.");

		// décoder et afficher le résultat
		string messageUDecode = Decode2Gramme(grille, messageUCode);
		Console.WriteLine($"Le message décodé est '{messageUDecode}'.");
	}
}