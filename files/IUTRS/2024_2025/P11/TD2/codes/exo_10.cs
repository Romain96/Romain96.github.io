// Auteur : Romain PERRIN

using System;

class CompterTauxFrequenceA
{
	// Principe : Maintenir le nombre de "a" rencontrés et le nombre de caractères saisis.
	// Tant que l'utilisateur ne saisi pas '*', lire le premier caractère saisi, mettre à jour les deux variables
	// Quand '*' est rencontré, sortir de la boucle et afficher la fréquence et le taux de 'a'
	public static void Main()
	{
		// variables
			int nombreA = 0;            // nombre de 'a' saisis par l'utilisateur
			int nombreCaracteres = 0;   // nombre de caractères saisis
			bool quitter = false;       // décide quand quitter la boucle de traitement
			char caractere = '\0';      // caractère saisi
			double frequenceA = 0.0;    // fréquence d'apparition du caractère 'a'

		// boucle de traitement
		while (quitter == false)
		{
			// saisie d'un caractère
			Console.Write("Entrez un caractère : ");
			caractere = Console.ReadLine()[0];  // [0] est le premier caractère de la chaine

			if (caractere == '*')
			{
				quitter = true;
			}
			else if (caractere == 'a')
			{
				nombreA += 1;
				nombreCaracteres += 1;
			}
			else
			{
				nombreCaracteres += 1;
			}
		}

		frequenceA = (double) nombreA / (double) nombreCaracteres;

		// affichage du résultat
		Console.WriteLine($"Au total, {nombreA} 'a' ont été saisis sur {nombreCaracteres} caractères pour un taux de {nombreA}/{nombreCaracteres} et une fréquence de {frequenceA}.");
	}
}
