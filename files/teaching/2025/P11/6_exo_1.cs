// Auteur : Romain PERRIN

using System;
using System.IO;

class Exercice1
{
	// Procédure : AfficherPassagers
	// Entrée :	- chemin : chaîne de caractères
	// Sortie :	void
	public static void AfficherPassagers(string chemin)
	{
		int y = 0;
		int w = 0;
		int j = 0;
		int f = 0;

		// si le chemin est valide, ouvrir le fichier
		if (File.Exists(chemin))
		{
			Console.WriteLine("Numéro".PadRight(6) + " " + "Nom".PadRight(20) + " " + "Prénom".PadRight(20) + " " + "Classe");
			Console.WriteLine("-------------------------------------------------------");
			using (StreamReader reader = new StreamReader(chemin))
			{
				string line;

				while ((line = reader.ReadLine()) != null)
				{
					string[] elements = line.Split(";");
					Console.WriteLine(elements[0].PadRight(6) + " " + 
							elements[1].PadRight(20) + " " + 
							elements[2].PadRight(20) + " " + 
							elements[3].PadRight(6)
					);
					if (elements[3] == "Y")
					{
						y++;
					}
					else if (elements[3] == "W")
					{
						w++;
					}
					else if (elements[3] == "J")
					{
						j++;
					}
					else if (elements[3] == "F")
					{
						f++;
					}
				}
				// statistiques
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine($"Classe Y --> {y}");
				Console.WriteLine($"Classe W --> {w}");
				Console.WriteLine($"Classe J --> {j}");
				Console.WriteLine($"Classe F --> {f}");
			}
		}
		// sinon afficher un message d'erreur
		else
		{
			Console.WriteLine($"Erreur, le fichier {chemin} n'existe pas !");
		}
	}

	public static void Main()
	{
		string chemin = "Passagers.csv";
		AfficherPassagers(chemin);
	}
}
