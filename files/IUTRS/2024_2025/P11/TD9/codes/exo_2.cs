// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;

class CarreMagique
{
	// Procédure : AfficherCarreMagique
	// Entrée :     - carreMagique : tableau 2D d'entiers
	// Local :      - ligne, colonne : entiers
	// Sortie :     void
	public static void AfficherCarreMagique(int[,] carreMagique)
	{
		for (int ligne = 0; ligne < carreMagique.GetLength(0); ligne++)
		{
			for (int colonne = 0; colonne < carreMagique.GetLength(1); colonne++)
			{
				Console.Write($"{carreMagique[ligne, colonne]} ");
			}
			Console.Write("\n");
		}
		Console.Write("\n");
	}

	// Fonction : SaisirEntier
	// Entrée :     - texte : chaîne de caractères
	// Local :      /
	// Sortie :     - n : entier
	public static int SaisirEntier(string texte)
	{
		Console.Write(texte);
		return int.Parse(Console.ReadLine());
	}

	// Fonction : CreerCarreMagique
	// Précondition : n > 0
	// Entrée :     - n : entier
	// Local :
	// Sortie :     - carreMagique : tableau 2D de n*n entiers
	public static int[,] CreerCarreMagique(int n)
	{
		int[,] carreMagique = new int[n,n];
		for (int ligne = 0; ligne < n; ligne++)
		{
			for (int colonne = 0; colonne < n; colonne++)
			{
				carreMagique[ligne, colonne] = -1;
			}
		}

		int i = 0;
		int j = n / 2;
		carreMagique[i, j] = 1;

  		for (int k = 2; k <= n * n;) 
  		{
			int inext = i - 1;
			int jnext = j + 1;

			// dépassent par la droite
			if (jnext == n)
			{
				jnext = 0;
			}
			// dépassement par le haut
			if(inext < 0)
			{
				inext = n - 1;
			}
			// case occupée
			if (carreMagique[inext, jnext] != -1)
			{
				inext = i + 1;
				if (inext >= n)
				{
					inext = 0;
				}
				jnext = j;
			}
			carreMagique[inext, jnext] = k;
			k++;
			i = inext;
			j = jnext;
		}

		return carreMagique;
	}

	// Procédure : EcrireCarreMagique
	// Entrée :		- carreMagique : tableau 2D d'entiers
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux d'écriture
	// Sortie :		void
	public static void EcrireCarreMagique(int[,] carreMagique, string chemin)
	{
		// ouverture du flux d'écriture
		StreamWriter writer = new StreamWriter(chemin);
		// écriture des dimensions du carré magique (nb lignes, nb colonnes)
		writer.Write($"{carreMagique.GetLength(0)},{carreMagique.GetLength(1)}\n");
		// écriture de chaque ligne séparées par un saut de ligne
		// et de chaque colonne séparées par des virgules
		// parcours des lignes
		for (int ligne = 0; ligne < carreMagique.GetLength(0); ligne++)
		{
			// parcours des colonnes
			for (int colonne = 0; colonne < carreMagique.GetLength(1) - 1; colonne++)
			{
				writer.Write($"{carreMagique[ligne, colonne].ToString()},");
			}
			// dernière colonne -> ajout du saut de ligne
			writer.Write($"{carreMagique[ligne, carreMagique.GetLength(1) - 1].ToString()}\n");
		}
		// fermeture du flux
		writer.Close();
	}

	// Fonction : LireCarreMagique
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- stream : flux de lecture
	// Sortie :		- carreMagique : tableau 2D d'entiers
	public static int[,] LireCarreMagique(string chemin)
	{
		StreamReader reader = new StreamReader(chemin);
		
		// lecture des dimensions
		string line = reader.ReadLine();
		string[] lineDetails = line.Split(',');	// séparation selon le caractère ','
		int lines = int.Parse(lineDetails[0]);
		int cols = int.Parse(lineDetails[1]);

		// création du tableau
		int[,] carreMagique = new int[lines, cols];

		// lecture ligne par ligne
		int i = 0;	// première ligne
		while ((line = reader.ReadLine()) != null)
        {
			// lecture colonne par colonne
			string[] columns = line.Split(',');
			for (int j = 0; j < columns.Length; j++)
			{
				carreMagique[i, j] = int.Parse(columns[j]);
			}
			i++;
		}
		// fermeture du flux
		reader.Close();
		return carreMagique;
	}

	public static void Main()
	{
		// demander la taille du carré magique à créer et le créer
		int taille = -1;
		while (taille < 1 && taille % 2 != 0)
		{
			taille = SaisirEntier("Entrer la taille du carré magique (nombre impair, supérieur à 1) : ");
		}
		int[,] cm1 = CreerCarreMagique(taille);
		Console.WriteLine("Carré magique créé : ");
		AfficherCarreMagique(cm1);

		// sauvegarder le carré magique dans un fichier
		string chemin = "carremagique.txt";
		EcrireCarreMagique(cm1, chemin);

		// lire le carré magique depuis un fichier
		int[,] cm2 = LireCarreMagique(chemin);

		// afficher le carré magique
		Console.WriteLine("Carré magique lu depuis le fichier :");
		AfficherCarreMagique(cm2);
	}
}