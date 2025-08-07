// Auteur : Romain PERRIN

using System;

class CarreMagique
{
	// Fonction : CreerGrille
	// Crée un carré magique de taille alphabet * alphabet dont le 1 original est positionné en indiceLigne1, indiceColonne1
	// Précondition : alphabet > 0
	// Entrée :     - alphabet : entier
	//				- indiceLigne1 : entier
	//				- indiceColonne1 : entier
	// Local :
	// Sortie :     - grille : tableau 2D de alphabet*alphabet entiers
	public static string[,] CreerGrille(int alphabet, int indiceLigne1, int indiceColonne1)
	{
		string[,] grille = new string[alphabet, alphabet];
		for (int ligne = 0; ligne < alphabet; ligne++)
		{
			for (int colonne = 0; colonne < alphabet; colonne++)
			{
				grille[ligne, colonne] = "";
			}
		}

		int i = indiceLigne1;
		int j = indiceColonne1;
		grille[i, j] = 1.ToString("D3");

  		for (int k = 2; k <= alphabet * alphabet;) 
  		{
			int inext = i - 1;
			int jnext = j + 1;

			// dépassent par la droite
			if (jnext == alphabet)
			{
				jnext = 0;
			}
			// dépassement par le haut
			if(inext < 0)
			{
				inext = alphabet - 1;
			}
			// case occupée
			if (!grille[inext, jnext].Equals(""))
			{
				inext = i + 1;
				if (inext >= alphabet)
				{
					inext = 0;
				}
				jnext = j;
			}
			grille[inext, jnext] = k.ToString("D3");
			k++;
			i = inext;
			j = jnext;
		}

		return grille;
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

	// Procédure : AfficherCarreMagique
	// Entrée :     - carreMagique : tableau 2D d'entiers
	// Local :      - ligne, colonne : entiers
	// Sortie :     void
	public static void AfficherCarreMagique(string[,] carreMagique)
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

	// Fonction : DonnerIndice
	// Précondition : c appartient à l'ensemble {'A', ..., 'Z', ' ', '.'}
	// Entrée : 	- c : caractère
	// Local :		/
	// Sortie :		- indice : entier
	public static int DonnerIndice(char c)
	{
		if (c == ' ')
		{
			return 26;
		}
		if (c == '.')
		{
			return 27;
		}
		return (int)c - (int)'A';
	}

	// Fonction : DonnerCaractere
	// Précondition : indice appartient à l'intervalle [0, 27]
	// Entrée : 	- indice : entier
	// Local :		/
	// Sortie :		- c : caractère
	public static char DonnerCaractere(int indice)
	{
		if (indice == 26)
		{
			return ' ';
		}
		if (indice == 27)
		{
			return '.';
		}
		return (char)(indice + (int)'A');
	}

	// Fonction : Code2Gramme
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'A', ..., 'Z', ' ', '.'}
	// Entrée : 	- grille : tableau 2D de alphabet*alphabet chaînes de caractères
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
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'A', ..., 'Z', ' ', '.'}
	// Entrée : 	- grille : tableau 2D de alphabet*alphabet chaînes de caractères
	//				- message : chaîne de caractères
	//				- indice1 : entier (modifiable)
	//				- indice2 : entier (modifiable)
	// Local :		- i, j : entiers
	// Sortie :		void : chaîne de caractères
	public static void RechercheDansGrille(string[,] grille, string message, ref int indice1, ref int indice2)
	{
		indice1 = -1;
		indice2 = -1;
		for (int i = 0; i < grille.GetLength(0); i++)
		{
			for (int j = 0; j < grille.GetLength(1); j++)
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
	// Précondition : le message ne contient que des caractères appartemant à l'ensemble {'A', ..., 'Z', ' ', '.'}
	// Entrée : 	- grille : tableau 2D de alphabet*alphabet chaînes de caractères
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

	public static void Main()
	{
		int alphabet = 28;  // A-Z (26) + ' ' + '.'
		int ligneDepart1 = -1;
		int colonneDepart1 = -1;
		while (ligneDepart1 < 0)
		{
			ligneDepart1 = SaisirEntier($"Entrer le nombre initial de la séquence : ");
		}
		while (colonneDepart1 < 0)
		{
			colonneDepart1 = SaisirEntier($"Entrer l'écart des nombre dans la séquence : ");
		}
		string[,] grille = CreerGrille(alphabet, ligneDepart1, colonneDepart1);
		AfficherCarreMagique(grille);
		
		// saisir un message
		Console.Write("Entrer un message : ");
		string messageU = Console.ReadLine().ToUpper();

		// coder et afficher le résultat
		string messageUCode = Code2Gramme(grille, messageU);
		Console.WriteLine($"Le message codé est '{messageUCode}'.");

		// décoder et afficher le résultat
		string messageUDecode = Decode2Gramme(grille, messageUCode);
		Console.WriteLine($"Le message décodé est '{messageUDecode}'.");
	}
}