// Auteur : Romain PERRIN

using System;

class Exercice13
{
	public static void Main()
	{
		// variables
		int choix;	// numéro de la commande

		do
		{
			// Affichage du menu
			Console.WriteLine("\nMENU\n----------------------------------------");
			Console.WriteLine("1  - Exercice 1  : Afficher les nombres de 7 à 77.");
			Console.WriteLine("2  - Exercice 2  : Algo trace (pas très intéressant ici).");
			Console.WriteLine("3  - Exercice 3  : Triangle rectangle composé de *.");
			Console.WriteLine("4  - Exercice 4  : Triangle isocèle composé de *.");
			Console.WriteLine("5  - Exercice 5  : Table de multiplication de n.");
			Console.WriteLine("6  - Exercice 6  : Le plus petit de 10 entiers.");
			Console.WriteLine("7  - Exercice 7  : La somme de 10 entiers.");
			Console.WriteLine("8  - Exercice 8  : La factorielle de n.");
			Console.WriteLine("9  - Exercice 9  : Deviner un nombre tiré au sort.");
			Console.WriteLine("10 - Exercice 10 : Recherche des nombre d'Armstrong.");
			Console.WriteLine("11 - Exercice 11 : Taux et fréquence de a dans un texte.");
			Console.WriteLine("12 - Exercice 12 : Le nombre est-il premier ?");
			Console.WriteLine("13 - Exercice 13 : Quitter le menu.");

			// saisie du choix
			Console.Write("Saisir le choix : ");
			choix = int.Parse(Console.ReadLine());

			// lancer l'exercice selon le choix
			switch (choix)
			{
				case 1: Console.WriteLine("> copier coller l'exo 1 ici..."); break;
				case 2: Console.WriteLine("> copier coller l'exo 2 ici..."); break;
				case 3: Console.WriteLine("> copier coller l'exo 3 ici..."); break;
				case 4: Console.WriteLine("> copier coller l'exo 4 ici..."); break;
				case 5: Console.WriteLine("> copier coller l'exo 5 ici..."); break;
				case 6: Console.WriteLine("> copier coller l'exo 6 ici..."); break;
				case 7: Console.WriteLine("> copier coller l'exo 7 ici..."); break;
				case 8: Console.WriteLine("> copier coller l'exo 8 ici..."); break;
				case 9: Console.WriteLine("> copier coller l'exo 9 ici..."); break;
				case 10: Console.WriteLine("> copier coller l'exo 10 ici..."); break;
				case 11: Console.WriteLine("> copier coller l'exo 11 ici..."); break;
				case 12: Console.WriteLine("> copier coller l'exo 12 ici..."); break;
				case 13: Console.WriteLine("> Fin du programme !"); break;
				default: Console.WriteLine("> Erreur de saisie, le choix doit être un nombre entre 1 et 13."); break;
			}
		}
		while (choix != 13);
	}
}
