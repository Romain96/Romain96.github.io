// Auteur : Romain PERRIN

using System;

class Loto
{
	// Procédure : AfficherTirage
	// Entrée :	- loto : tableau 2D d'entiers, valeurs des tirages (lignes = semaines/tirages, colonnes = numéros tirés)
	//		- semaine : entier, numéro de la semaine du tirage ([1, 52])
	//		- tirage : entier, numéro du tirage de la semaine ([1,3])
	// Sortie :	void
	public static void AfficherTirage(int[,] loto, int semaine, int tirage)
	{
		// seulement pour les semaines et numéro de tirage valides
		if (semaine < 1 || semaine > 52)
		{
			Console.WriteLine($"AfficherTirage : erreur - la semaine {semaine} est invalide, valeurs autorisées : [1,52]");
		}
		else if (tirage < 1 || tirage > 3)
		{
			Console.WriteLine($"AfficherTirage : erreur - le tirage {tirage} est invalide, valeurs autorisées : [1,3]");
		}
		else
		{
			int indice = (semaine - 1) * 3 + (tirage - 1);
			for (int i = 0; i < 5; i++)
			{
				Console.Write($"{loto[indice, i]} - ");
			}
			Console.WriteLine($"numéro chance : {loto[indice, 5]}");
		}
	}
	
	// Procédure : AfficherTousLesTirages
	// Entrée :	- loto : tableau 2D d'entiers
	// Sortie :	void
	public static void AfficherTousLesTirages(int[,] loto)
	{
		for (int semaine = 1; semaine <= 52; semaine++)
		{
			Console.Write($"Semaine {semaine}\t");
			for (int tirage = 1; tirage <= 3; tirage++)
			{
				if (tirage == 1)
				{
					Console.Write($"tirage {tirage} :\t");
				}
				else
				{
					Console.Write($"\t\ttirage {tirage} :\t");
				}
				AfficherTirage(loto, semaine, tirage);
			}
		}
	}
	
	// Procédure : AfficherTousLesNumerosChance
	// Entrée :	- loto : tableau 2D d'entiers
	// Sortie :	void
	public static void AfficherTousLesNumerosChance(int[,] loto)
	{
		for (int semaine = 1; semaine <= 52; semaine++)
		{
			for (int tirage = 1; tirage <= 3; tirage++)
			{
				int indice = (semaine - 1) * 3 + (tirage - 1);
				Console.Write($"{loto[indice, 5]}\t");
			}
			Console.Write("\n");
		}
	}
	
	// Fonction : CalculerFrequencesNumeros
	// Entrée :	- loto : tableau 2D d'entiers
	// Sortie :	tableau 1D de 50 réels
	public static double[] CalculerFrequencesNumeros(int[,] loto)
	{
		double[] frequences = new double[50];
		int n = 0;
		for (int ligne = 0; ligne < loto.GetLength(0); ligne++)
		{
			for (int numero = 0; numero < loto.GetLength(1) - 1; numero++)
			{
				frequences[loto[ligne, numero]] += 1.0;
				n++;
			}
		}
		for (int i = 1; i < 50; i++)
		{
			frequences[i] /= n;
		}
		return frequences;
	}
	
	// Fonction : CalculerFrequencesNumerosChance
	public static double[] CalculerFrequencesNumerosChance(int[,] loto)
	{
		double[] frequences = new double[50];
		int n = 0;
		for (int ligne = 0; ligne < loto.GetLength(0); ligne++)
		{
			frequences[loto[ligne, 5]] += 1.0;
			n++;
		}
		for (int i = 1; i < 50; i++)
		{
			frequences[i] /= n;
		}
		return frequences;
	}
	
	// Fonction : FrequencesDecroissantes
	// Entrée :	- frequences : tableau 1D de réels
	// Sortie :	tableau 2D de réels (même nb de lignes que frequences, 2 colonnes)
	public static double[,] FrequencesDecroissantes(double[] frequences)
	{
		double[,] frequencesTriees = new double[frequences.GetLength(0), 2];
		for (int i = 0; i < frequences.GetLength(0); i++)
		{
			frequencesTriees[i, 0] = i;	// numéro
			frequencesTriees[i, 1] = frequences[i];	// fréquence correspondant au numéro
		}
		// tri à bulle (la bulle est sur deux lignes)
		for (int i = 0; i < frequencesTriees.GetLength(0); i++)
		{
			for (int j = frequencesTriees.GetLength(0) - 1; j > i; j--)
			{
				if (frequencesTriees[j, 1] > frequencesTriees[j - 1, 1])
				{
					// échange de ft[j] avec ft[j - 1]
					double tempNum = frequencesTriees[j, 0];
					double tempFreq = frequencesTriees[j, 1];
					frequencesTriees[j, 0] = frequencesTriees[j - 1, 0];
					frequencesTriees[j, 1] = frequencesTriees[j - 1, 1];
					frequencesTriees[j - 1, 0] = tempNum;
					frequencesTriees[j - 1, 1] = tempFreq;
				}
			}
		}
		return frequencesTriees;
	}
	
	// Procédure : AfficherNumerosFrequencesDecroissantes
	// Entrée :	- frequences : tableau 2D de réels
	// Sortie :	void
	public static void AfficherNumerosFrequencesDecroissantes(double[,] frequences)
	{
		for (int i = 0; i < 49; i++)
		{
			Console.WriteLine($"{frequences[i, 0]}".PadLeft(2) + $" ({frequences[i, 1] * 100} %)");
		}
	}
	
	// Procédure : AfficherNumerosChanceFrequencesDecroissantes
	// Entrée :	- frequences : tableau 2D de réels
	// Sortie :	void
	public static void AfficherNumerosChanceFrequencesDecroissantes(double[,] frequences)
	{
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine($"{frequences[i, 0]}".PadLeft(2) + $" ({frequences[i, 1] * 100} %)");
		}
	}
	
	public static void Main()
	{
		int[,] loto = {
			{18,21,26,44,47,3}, {5,10,15,43,45,9}, {6,8,31,36,45,9},
			{2,13,24,39,48,1}, {13,28,37,45,48,9}, {7,8,22,28,38,10},
			{3,21,32,33,38,10}, {4,7,14,31,37,8}, {6,20,24,31,36,4},
			{4,14,23,35,46,7}, {19,31,38,44,49,3}, {18,21,32,33,41,9},
			{5,17,23,43,49,4}, {2,10,13,35,40,1}, {1,2,27,31,45,8},
			{11,18,24,41,48,2}, {23,34,36,39,49,8}, {22,23,26,29,40,5},
			{8,15,24,39,48,8}, {1,3,7,14,38,5}, {6,11,12,19,45,10},
			{7,13,24,36,42,4}, {5,16,18,34,37,5}, {7,13,30,44,48,7},
			{1,18,29,39,40,2}, {21,28,39,46,49,1}, {2,34,41,44,46,2},
			{9,21,42,43,46,6}, {8,9,28,35,42,6}, {25,29,34,44,47,9},
			{2,15,28,36,49,3}, {1,9,18,24,46,7}, {1,4,15,18,38,6},
			{6,8,16,32,37,7}, {1,13,36,44,48,2}, {10,11,23,43,49,10},
			{5,9,18,26,36,9}, {2,17,23,25,37,7}, {8,11,19,48,49,7},
			{9,25,34,38,49,1}, {4,7,24,29,46,10}, {3,17,27,34,41,4},
			{1,9,24,26,35,4}, {2,17,22,38,44,8}, {9,16,24,32,42,3},
			{2,9,12,21,29,7}, {4,11,31,36,46,10}, {13,22,33,36,49,4},
			{2,11,28,33,43,1}, {17,18,21,36,47,6}, {20,35,39,42,48,2},
			{5,32,33,46,49,1}, {21,26,33,46,49,1}, {3,6,22,35,47,1},
			{3,8,12,29,35,1}, {2,17,40,46,48,10}, {12,17,24,30,38,7},
			{9,26,27,29,36,5}, {9,27,31,32,44,8}, {14,22,23,27,28,4},
			{4,10,33,35,41,5}, {1,16,29,31,39,2}, {4,10,18,27,30,1},
			{8,11,12,26,48,6}, {3,6,28,39,42,5}, {14,17,18,28,44,2},
			{12,19,41,42,49,8}, {7,11,16,37,47,10}, {1,16,27,35,41,1},
			{24,35,37,45,48,2}, {19,21,23,36,49,4}, {3,9,15,40,48,10},
			{15,23,45,48,49,2}, {15,24,30,43,48,7}, {14,20,24,44,48,10},
			{26,28,29,42,48,1}, {22,31,37,43,45,5}, {11,14,17,23,43,10},
			{2,8,25,28,44,4}, {7,10,25,37,47,10}, {4,23,37,42,43,7},
			{7,16,18,33,43,5}, {3,9,21,43,45,1}, {10,16,24,27,47,5},
			{20,22,28,32,47,6}, {5,11,26,30,48,1}, {11,15,24,38,47,6},
			{12,27,30,32,42,7}, {20,26,31,47,49,10}, {22,31,33,39,43,10},
			{2,10,28,33,46,8}, {3,16,22,28,49,4}, {13,16,18,19,20,2},
			{19,23,36,39,49,3}, {9,16,28,41,49,5}, {8,14,29,44,48,7},
			{23,27,43,46,49,6}, {13,22,28,31,40,9}, {9,11,21,27,49,5},
			{5,7,8,22,26,2}, {7,8,15,18,25,6}, {5,6,27,43,46,7},
			{8,9,22,32,46,8}, {16,32,37,38,44,3}, {25,26,32,33,41,3},
			{1,15,22,23,46,9}, {5,12,21,29,42,2}, {2,14,17,37,38,1},
			{1,17,25,37,45,9}, {1,7,11,33,43,1}, {1,8,30,38,40,6},
			{8,25,33,39,43,8}, {7,13,36,41,45,5}, {13,21,24,44,47,3},
			{17,19,22,29,43,8}, {9,11,15,42,49,3}, {16,20,21,33,39,2},
			{4,14,22,35,38,5}, {3,13,15,32,46,5}, {4,10,36,40,41,10},
			{9,14,16,47,49,7}, {11,13,18,24,33,7}, {1,26,29,31,38,5},
			{1,13,22,37,46,9}, {9,22,25,33,44,3}, {1,4,9,20,35,8},
			{2,17,23,26,43,3}, {6,25,33,37,43,1}, {7,9,29,31,46,8},
			{7,13,16,35,41,1}, {15,16,23,30,41,8}, {9,10,15,43,44,5},
			{14,20,22,32,47,5}, {4,17,21,23,26,2}, {1,11,12,27,29,2},
			{4,9,30,38,46,10}, {14,17,20,33,47,1}, {5,17,25,29,38,2},
			{16,20,39,47,48,4}, {6,9,14,35,47,9}, {7,19,24,35,42,3},
			{6,15,33,46,49,1}, {1,15,17,24,28,10}, {11,15,29,46,47,3},
			{13,30,39,42,44,9}, {7,10,16,29,30,5}, {1,8,18,29,36,9},
			{6,9,13,23,32,4}, {11,22,35,40,41,7}, {4,6,16,28,37,8},
			{6,9,14,40,49,3}, {3,9,11,28,38,1}, {4,15,19,24,44,1},
			{13,25,30,33,36,9}, {7,12,15,24,33,6}, {14,31,32,34,46,3}
		};
		
		int choix;
		bool menu = true;
		// menu
		do
		{
			do
			{
				Console.Clear();
				Console.WriteLine("MENU - Loto");
				Console.WriteLine("Choix disponibles :");
				Console.WriteLine("0 - Quitter");
				Console.WriteLine("1 - Afficher tous les tirages");
				Console.WriteLine("2 - Afficher tous les numéros chance");
				Console.WriteLine("3 - Afficher un tirage particulier");
				Console.WriteLine("4 - Afficher les numéros des tirages par fréquences décroissantes");
				Console.WriteLine("5 - Afficher les numéros chance par fréquences décroissantes");		
				Console.Write("Entrez votre choix : ");
				choix = int.Parse(Console.ReadLine());
			}
			while (choix < 0 || choix > 5);
			
			// action
			switch (choix)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("Affichage de tous les tirages");
					AfficherTousLesTirages(loto);
					Console.Write("Appuyer sur une touche pour retourner au menu...");
					Console.ReadLine();
					break;
				case 2:
					Console.Clear();
					Console.WriteLine("Affichage de tous les numéros chance");
					AfficherTousLesNumerosChance(loto);
					Console.Write("Appuyer sur une touche pour retourner au menu...");
					Console.ReadLine();
					break;
				case 3:
					int semaine;
					int tirage;
					do
					{
						Console.Clear();
						Console.WriteLine("Affichage d'un tirage en particulier");
						Console.WriteLine("Saisir la semaine (entre 1 et 52) ainsi que le numéro du tirage (entre 1 et 3).");
						Console.Write("Entrez le numéro de la semaine : ");
						semaine = int.Parse(Console.ReadLine());
					}
					while (semaine < 1 || semaine > 52);
					
					do
					{
						Console.Clear();
						Console.WriteLine("Affichage d'un tirage en particulier");
						Console.WriteLine("Saisir la semaine (entre 1 et 52) ainsi que le numéro du tirage (entre 1 et 3).");
						Console.WriteLine("==> semaine choisie : " + semaine);
						Console.Write("Entrez le numéro du tirage : ");
						tirage = int.Parse(Console.ReadLine());
					}
					while (tirage < 1 || tirage > 3); 
					AfficherTirage(loto, semaine, tirage);
					Console.Write("Appuyer sur une touche pour retourner au menu...");
					Console.ReadLine();
					break;
				case 4:
					Console.Clear();
					Console.WriteLine("Affichage des numéros par fréquences décroissantes");
					double[] frequencesNumeros = CalculerFrequencesNumeros(loto);
					double[,] frequencesNumerosTriees = FrequencesDecroissantes(frequencesNumeros);
					AfficherNumerosFrequencesDecroissantes(frequencesNumerosTriees);
					Console.Write("Appuyer sur une touche pour retourner au menu...");
					Console.ReadLine();
					break;
				case 5:
					Console.Clear();
					Console.WriteLine("Affichage des numéros chance par fréquences décroissantes");
					double[] frequencesNumerosChance = CalculerFrequencesNumerosChance(loto);
					double[,] frequencesNumerosChanceTriees = FrequencesDecroissantes(frequencesNumerosChance);
					AfficherNumerosChanceFrequencesDecroissantes(frequencesNumerosChanceTriees);
					Console.Write("Appuyer sur une touche pour retourner au menu...");
					Console.ReadLine();
					break;
				default: menu = false; break;
			}	
		}
		while (menu);
	}
}
