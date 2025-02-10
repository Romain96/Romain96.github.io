// Auteur : Romain PERRIN

using System;

class ChiffrementSimple
{
	// Procédure : AfficherChaine
	// Entrée :     - chaine : chaîne de caractères
	// Local :      /
	// Sortie :     void
	public static void AfficherChaine(string chaine)
	{
		Console.Write(chaine);
	}

	// Fonction : SaisirChaine
	// Entrée :     - texte : chaîne de caractères
	// Local :      /
	// Sortie :     - chaine : chaîne de caractères
	public static string SaisirChaine(string texte)
	{
		AfficherChaine(texte);
		string chaine = Console.ReadLine();
		return chaine;
	}

	// Fonction : SaisirEntier
	// Entrée :     - texte : chaîne de caractères
	// Local :      /
	// Sortie :     - n : entier
	public static int SaisirEntier(string texte)
	{
		AfficherChaine(texte);
		int n = int.Parse(Console.ReadLine());
		return n;
	}

	// Fonction : CaractereADroite
	// Précondition : c appartient à l'ensemble {'A', ... , 'Z', ' '}
	// Entrée :     - c : caractère
	// Local :
	// Sortie :     - droite : caractère
	public static char CaractereADroite(char c)
	{
		char droite = c;
		if (c == ' ')
		{
			droite = 'A';   // retour au début
		}
		else if (c == 'Z')
		{
			droite = ' ';
		}
		else
		{
			droite = (char) ((int) c + 1);
		}
		return droite;
	}

	// Fonction : CaractereAGauche
	// Précondition : c appartient à l'ensemble {'A', ... , 'Z', ' '}
	// Entrée :     - c : caractère
	// Local :
	// Sortie :     - gauche : caractère
	public static char CaractereAGauche(char c)
	{
		char gauche = c;
		if (c == 'A')
		{
			gauche = ' ';   // retour à la fin
		}
		else if (c == ' ')
		{
			gauche = 'Z';
		}
		else
		{
			gauche = (char) ((int) c - 1);
		}
		return gauche;
	}

	// Fonction : DecalerCaractere
	// Principe : Décaler le caractère donné de offset caractères dans l'ensemble circulaire ['A' = 0, 'B' = 1, ... , 'Z' = 25, ' ' = 26]
	// Entrée :     - c : caractère
	//              - offset : entier
	// Local :      - i : entier
	// Sortie :     - caractereDecale : caractère
	public static char DecalerCaractere(char c, int offset)
	{
		char caractereDecale = c;

		// décalage vers la droite
		if (offset > 0)
		{
			for (int i = 0; i < offset; i++)
			{
				caractereDecale = CaractereADroite(caractereDecale);
			}
		}
		// décalage vers la gauche
		else if (offset < 0)
		{
			for (int i = 0; i < -offset; i++)
			{
				caractereDecale = CaractereAGauche(caractereDecale);
			}
		}
		return caractereDecale;
	}

	// Fonction : DecalerCaracteres
	// Principe : Créer une chaîne vide de même longueur que la chaîne en entrée. Parcourir les caractères de la chaine d'entrée.
	// Pour chacun, décaler de offset caractères vers la droite dans l'ordre alphabétique ('A' = 0, 'Z' = 25, ' ' = 27) 
	// en considérant cet ensemble de manière circulaire (utiliser l'opérateur de modulo).
	// Entrée :     - chaine : chaîne de caractères
	//              - offset : entier
	// Local :      - i : entier
	// Sortie :     - chaineDecalee
	public static string DecalerCaracteres(string chaine, int offset)
	{
		string chaineDecalee = "";
		for (int i = 0; i < chaine.Length; i++)
		{
			chaineDecalee = chaineDecalee + DecalerCaractere(chaine[i], offset);
		}
		return chaineDecalee;
	}

	// Fonction : CodeDeCesar
	// Entrée :     - message : chaîne de caractères
	//              - clef : entier
	//              - coder : booléen
	// Local :      /
	// Sortie :     - messageCode : chaîne de caractères
	public static string CodeDeCesar(string message, int clef, bool coder)
	{
		if (coder)
		{
			return DecalerCaracteres(message, clef);
		}
		else
		{
			// décoder le message = coder le message avec un décalage vers la gauche en utilisant la même clef
			return DecalerCaracteres(message, -clef);
		}
	}

	public static void Main()
	{
		AfficherChaine("Chiffrement code de César.\n");
		string messageU = "";
		string messageChiffre = "";
		string messageDechiffre = "";
		int clefChiffrement = -1;

		messageU = SaisirChaine("Saisir un message : ").ToUpper();
		while (clefChiffrement < 0)
		{
			clefChiffrement = SaisirEntier("Saisir la clef de chiffrement (entier >= 0) : ");
		}
		// chiffrement
		messageChiffre = CodeDeCesar(messageU, clefChiffrement, true);
		AfficherChaine($"Le message chiffré avec la clef {clefChiffrement} est '{messageChiffre.ToUpper()}'.\n");
		// déchiffrement
		messageDechiffre = CodeDeCesar(messageChiffre, clefChiffrement, false);
		AfficherChaine($"Le message déchiffré avec la clef {clefChiffrement} est '{messageDechiffre.ToUpper()}'.\n");
	}
}