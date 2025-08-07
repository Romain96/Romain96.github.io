// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ChiffrementAmelioreIO
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

	// Procédure : AfficherGrille
	// Entrée :		- grille : tableau 2D de chaînes de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherGrille(string[,] grille)
	{
		for (int i = 0; i < grille.GetLength(0); i++)
		{
			for (int j = 0; j < grille.GetLength(1); j++)
			{
				Console.Write($"{grille[i,j]} ");
			}
			Console.Write("\n");
		}
		Console.Write("\n");
	}

	// Procédure : SauverGrille
	// Entrée :		- grille : tableau 2D de chaînes de caractères
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux de sortie
	// Sortie :		void
	public static void SauverGrille(string[,] grille, string chemin)
	{
		// ouverture du flux d'écriture
		StreamWriter writer = new StreamWriter(chemin);

		// sauvegarde des dimensions sur la première ligne
		writer.Write($"{grille.GetLength(0)},{grille.GetLength(1)}\n");

		// sauvegarde des valeurs ligne par ligne, colonne par colonne (séparateur ',')
		for (int ligne = 0; ligne < grille.GetLength(0); ligne++)
		{
			// parcours des colonnes
			for (int colonne = 0; colonne < grille.GetLength(1) - 1; colonne++)
			{
				writer.Write($"{grille[ligne, colonne]},");
			}
			// dernière colonne -> ajout du saut de ligne
			writer.Write($"{grille[ligne, grille.GetLength(1) - 1]}\n");
		}
		// fermeture du flux
		writer.Close();
	}

	// Fonction : ChargerGrille
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- reader : flux de lecture
	// Sortie : 	- grille : tableau 2D de chaînes de caractères
	public static string[,] ChargerGrille(string chemin)
	{
		// ouverture du flux de lecture
		StreamReader reader = new StreamReader(chemin);
		
		// lecture des dimensions
		string line = reader.ReadLine();
		string[] lineDetails = line.Split(',');	// séparation selon le caractère ','
		int lines = int.Parse(lineDetails[0]);
		int cols = int.Parse(lineDetails[1]);

		// création du tableau
		string[,] grille = new string[lines, cols];

		// lecture ligne par ligne
		int i = 0;	// première ligne
		while ((line = reader.ReadLine()) != null)
        {
			// lecture colonne par colonne
			string[] columns = line.Split(',');
			for (int j = 0; j < columns.Length; j++)
			{
				grille[i, j] = columns[j];
			}
			i++;
		}
		// fermeture du flux
		reader.Close();
		return grille;
	}

	public static void Main()
	{
		// demander à l'utilisateur si la grille est à créer ou a lire depuis un fichier
		// si création alors création, demander le chemin et sauvegarde
		// sinon demander le chemin et lire puis afficher la grille
		bool creerGrille = false;
		Console.Write("Faut-il créer la grille (y/n) ? ");
		if (Console.ReadLine().ToLower()[0] == 'y')
		{
			creerGrille = true;
		}
		string chemin = "";

		// création, sauvegarde
		if (creerGrille)
		{
			string[,] grille = new string[27, 27];
			InitGrille(grille);
			Console.WriteLine("Création d'une grille aléatoire :");
			AfficherGrille(grille);

			Console.Write("Entrer le chemin du fichier pour écriture : ");
			chemin = Console.ReadLine();

			Console.WriteLine($"Sauvegarde de la grille dans {chemin}.");
			SauverGrille(grille, chemin);
		}
		// lecture
		else
		{
			Console.Write("Entrer le chemin du fichier pour lecture : ");
			chemin = Console.ReadLine();

			Console.WriteLine($"Lecture de la grille depuis {chemin}.");
			string[,] grille2 = ChargerGrille(chemin);
			Console.WriteLine("Grille chargée :");
			AfficherGrille(grille2);
		}
	}
}