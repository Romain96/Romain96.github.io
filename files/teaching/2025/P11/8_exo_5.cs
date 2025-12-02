// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice5
{
	// Procédure : CreerRecetteTarteSucree
	// Entrée :	void
	// Sortie : File<chaîne de caractères>
	public static Queue<string> CreerRecetteTarteSucree()
	{
		Queue<string> recette = new Queue<string>();
		
		recette.Enqueue("Étape 1 : faire fondre le beurre dans un peu d'eau avec 4 sucres");
		recette.Enqueue("Étape 2 : mettre la farine et remuer jusqu'à obtenir une boule compacte");
		recette.Enqueue("Étape 3 : pétrir la boule");
		recette.Enqueue("Étape 4 : étaler la boule à l'aide d'un rouleau à pâtisserie");
		recette.Enqueue("Étape 5 : placer la pâte étalée dans un plat à tarte");
		
		return recette;
	}
	
	
	// Procédure : AfficherRecetteParEtape
	// Entrée :	- recette : Pile<chaîne de caractères>
	// Sortie :	void
	public static void AfficherRecetteParEtape(Queue<string> recette)
	{
		while (recette.Count > 1)
		{
			// afficher l'étape courante
			Console.Write(recette.Peek());
			
			// demander si l'étape est terminée
			string saisie = "";
			char reponse = ' ';
			do
			{
				do
				{
					Console.Write("\nAvez-vous terminé cette étape ? ");
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 1);
				reponse = saisie[0];
			}
			while (reponse != 'o' && reponse != 'O' && reponse != 'n' && reponse != 'N');
			
			// passer à l'étape suivante
			if (reponse == 'o' || reponse == 'O')
			{
				recette.Dequeue();
			}
		}
		Console.WriteLine("Recette terminée !");
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		Queue<string> recette = CreerRecetteTarteSucree();
		AfficherRecetteParEtape(recette);
	}
}
