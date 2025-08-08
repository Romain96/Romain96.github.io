// Auteur : Romain PERRIN

using System;

class Tableaux2D
{
	// Procédure : affichage d'un chaine dans le terminal
	// Paramètres :
	// 	- chaine (string): chaine de caractères
	// Retourne : rien
	public static void AfficherChaine(string chaine)
	{
		Console.WriteLine(chaine);
	}
	
	//-------------------------------------------------------------------------
	
	// Procédure : affichage d'un tableau 1D d'entiers
	// Paramètres :
	// 	- tab (int[]): tableau d'entiers 1D
	// Retourne : rien
	public static void AfficherTableau1D(int[] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			Console.Write(tab[i] + " ");
		}
		Console.Write("\n");
	}
	
	//-------------------------------------------------------------------------
	
	// Procédure : affichage d'un tableau 2D d'entiers
	// Paramètres :
	// 	- tab (int[,]): tableau d'entiers 2D
	// Retourne : rien
	public static void AfficherTableau2D(int[,] tab)
	{
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				Console.Write(tab[i,j] + "\t");
			}
			Console.Write("\n");
		}
		Console.Write("\n");	
	}
	
	//-------------------------------------------------------------------------
	
	// Procédure : remplissage tableau 2D avec les lignes paires avec des 0 et lignes impaires avec des 1
	// Paramètres :
	// 	- tab (int[,]): tableau 2D d'entiers
	// Retourne : rien, modification de `tab` par effets de bord
	public static void RemplirRaye(int[,] tab)
	{
		bool est_pair = true;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			est_pair = (i % 2 == 0);
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (est_pair)
				{
					tab[i,j] = 0;
				}
				else
				{
					tab[i,j] = 1;
				}
			}
		}
	}
	
	//-------------------------------------------------------------------------
	
	// Procédure : remplissage des diagonales d'un tableau 2D par des 1
	// Paramètres :
	// 	- tab (int[,]): tableau 2D d'entiers
	//	- entier_min (int): entier minimal pour le choix aléatoire
	//	- entier_max (int): entier maximal pour le choix aléatoire
	// Retourne : rien, modification de `tab` par effets de bord
	// Précondition : le tableau est carré sinon aucune modification
	public static void RemplirDiagonales(int[,] tab)
	{
		if (tab.GetLength(0) == tab.GetLength(1))
		{
			int offset = 0;
			for (int i = 0; i < tab.GetLength(0); i++)
			{
				for (int j = 0; j < tab.GetLength(1); j++)
				{
					if (j == offset || j == tab.GetLength(1) - 1 - offset)
					{
						tab[i,j] = 1;
					}
					else
					{
						tab[i,j] = 0;
					}
				}
				offset++;
			}
		}
	}
	
	//-------------------------------------------------------------------------
	
	// Procédure : remplissage d'un tableau 2D par des entiers aléatoires
	// Paramètres :
	// 	- tab (int[,]): tableau 2D d'entiers
	//	- entier_min (int): entier minimal pour le choix aléatoire
	//	- entier_max (int): entier maximal pour le choix aléatoire
	// Retourne : rien, modification de `tab` par effets de bord
	public static void RemplirAleatoire(int[,] tab, int entier_min, int entier_max)
	{
		Random rnd = new Random();
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				tab[i,j] = rnd.Next(entier_min, entier_max + 1);
			}
		}
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : clonage d'un tableau d'entiers 2D
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- clone (int[,]) : tableau de même dimension que `tab` et contenant les mêmes valeurs
	public static int[,] ClonerTableau(int[,] tab)
	{
		int[,] clone = new int[tab.GetLength(0),tab.GetLength(1)];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				clone[i,j] = tab[i,j];
			}
		}
		return clone;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : calcul de la moyenne d'un tableau d'entiers 2D
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- moyenne (double) : moyenne des valeurs de `tab`
	public static double MoyenneTableau(int[,] tab)
	{
		double moyenne = 0.0;
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				moyenne += tab[i,j];
			}
		}
		return moyenne/tab.Length;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : recherche de la valeur minimale d'un tableau d'entiers 2D
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- minimum (int) : minimum des valeurs de `tab`
	public static int MinimumTableau(int[,] tab)
	{
		int minimum = tab[0,0];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] < minimum)
				{
					minimum = tab[i,j];
				}
			}
		}
		return minimum;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : recherche de la valeur maximale d'un tableau d'entiers 2D
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- maximum (int) : maximum des valeurs de `tab`
	public static int MaximumTableau(int[,] tab)
	{
		int maximum = tab[0,0];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] > maximum)
				{
					maximum = tab[i,j];
				}
			}
		}
		return maximum;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : calcul de l'histogramme d'un tableau d'entiers 2D
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- histogramme (int[]) : histogramme des valeurs de `tab` [0-255]
	public static int[] CalculerHistogramme(int[,] tab)
	{
		int[] histogramme = new int[256];
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				histogramme[tab[i,j]] += 1;
			}
		}
		return histogramme;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : binarisation d'un tableau d'entiers 2D étant donné un seuil
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	//	- seuil (int): seuil de binarisation [0-255]
	// Retourne : 
	//	- binarise (int[,]) : copie de `tab` binarisée selon le seuil `seuil`
	// Note : si le seuil est en dehors de [0,255], tout le tableau contiendra des 0 ou des 255
	public static int[,] BinariserTableau(int[,] tab, int seuil)
	{
		int[,] binarise = ClonerTableau(tab);
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] < seuil)
				{
					binarise[i,j] = 0;
				}
				else
				{
					binarise[i,j] = 255;
				}
			}
		}
		return binarise;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : binarisation d'un tableau d'entiers 2D étant donné un seuil
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	//	- plancher (int): valeur plancher
	//	- plafond (int): valeur plafond
	// Retourne : 
	//	- normalise (int[,]) : copie de `tab` normalisé selon `plancher` et `plafond`
	public static int[,] NormaliserTableau(int[,] tab, int plancher, int plafond)
	{
		if (plafond < plancher)
		{
			int tmp = plafond;
			plafond = plancher;
			plancher = tmp;
		}
		
		int[,] normalise = ClonerTableau(tab);
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				if (tab[i,j] < plancher)
				{
					normalise[i,j] = plancher;
				}
				else if (tab[i,j] > plafond)
				{
					normalise[i,j] = plafond;
				}
				else
				{
					normalise[i,j] = tab[i,j];
				}
			}
		}
		return normalise;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : assombrit une image (tableau d'entiers 2D) en divisant ses valeurs par 2
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- assombrit (int[,]) : copie de `tab` assombrit
	public static int[,] AssombrireImage(int[,] tab)
	{
		int[,] assombrit = ClonerTableau(tab);
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				assombrit[i,j] = tab[i,j] / 2;
			}
		}
		return assombrit;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : retourne la valeur absolue d'un nombre réel
	// Paramètres :
	//	- x (double): nombre réel
	// Retourne : 
	//	- abs (double) : x ou -x selon le signe de x
	public static double ValeurAbsolue(double x)
	{
		double abs = x;
		if (x < 0)
			abs = -x;
		return abs;
	}
	
	// Fonction : recentre une image (tableau d'entiers 2D) sur une moyenne de 128
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- recentree (int[,]) : copie de `tab` recentrée sur une moyenne de 128
	public static int[,] RecentrerImage(int[,] tab)
	{
		int[,] recentree = ClonerTableau(tab);
		double moyenne = MoyenneTableau(tab);
		double facteur = 0.0;
		if (moyenne < 128)
			facteur = 1.0 + (128 - moyenne)/128;
		else
			facteur = 1.0 - (moyenne - 128)/128;
		bool stop = false;
		while (!stop)
		{
			for (int i = 0; i < tab.GetLength(0); i++)
			{
				for (int j = 0; j < tab.GetLength(1); j++)
				{
					recentree[i,j] = (int)(recentree[i,j] * facteur);
				}
			}
			NormaliserTableau(recentree, 0, 255);
			moyenne = MoyenneTableau(recentree);
			if (moyenne < 128)
				facteur = 1.0 + (128 - moyenne)/128;
			else
				facteur = 1.0 - (moyenne - 128)/128;
			// arrêt quand moins de 1 valeur de différence (127.xxx ou 128.xxx)
			if (ValeurAbsolue(moyenne - 128) < 1.0)
				stop = true;
		}
		return recentree;
	}
	
	//-------------------------------------------------------------------------
	
	// Fonction : recadre une image (tableau d'entiers 2D) sur l'ensemble [0-255]
	// Paramètres :
	//	- tab (int[,]): tableau d'entiers 2D
	// Retourne : 
	//	- recadree (int[,]) : copie de `tab` recentrée sur une moyenne de 128
	public static int[,] RecadrerImage(int[,] tab)
	{
		int[,] recadree = ClonerTableau(tab);
		int minimum = MinimumTableau(tab);
		int maximum = MaximumTableau(tab);
		for (int i = 0; i < tab.GetLength(0); i++)
		{
			for (int j = 0; j < tab.GetLength(1); j++)
			{
				recadree[i,j] = (int)(255 * (recadree[i,j] - minimum) / (maximum - minimum));
			}
		}
		return recadree;
	}

	//-------------------------------------------------------------------------
	// MAIN
	//-------------------------------------------------------------------------
	static void Main()
	{
		// déclaration sans initialisation
		int[,] t = new int[10,10];
		// affichage avant aléatoire
		AfficherChaine("Tableau 2D 'vide'.");
		AfficherTableau2D(t);
		// tableau rayé
		RemplirRaye(t);
		AfficherChaine("Tableau rayé.");
		AfficherTableau2D(t);
		// diagonales avec 1, 0 ailleurs
		RemplirDiagonales(t);
		AfficherChaine("Diagonales avec des 1.");
		AfficherTableau2D(t);
		// initialisation aléatoire
		RemplirAleatoire(t, 0, 255);
		AfficherChaine("Tableau 2D avec valeurs aléatoires.");
		AfficherTableau2D(t);
		// clonage
		int[,] ct = ClonerTableau(t);
		AfficherChaine("Clone du tableau précédent.");
		AfficherTableau2D(ct);
		// moyenne, minimum et maximum
		double moy_t = MoyenneTableau(t);
		AfficherChaine("La moyenne du tableau est " + moy_t);
		int min_t = MinimumTableau(t);
		AfficherChaine("Le minimum du tableau est " + min_t);
		int max_t = MaximumTableau(t);
		AfficherChaine("Le maximum du tableau est " + max_t);
		// histogramme
		int[] hist = CalculerHistogramme(t);
		AfficherChaine("Histogramme du tableau précédent.");
		AfficherTableau1D(hist);
		// binarisation
		int[,] bin = BinariserTableau(t, 100);
		AfficherChaine("Binarisation du tableau avec seuil=100.");
		AfficherTableau2D(bin);
		// normalisation
		int[,] norm = NormaliserTableau(t, 25, 75);
		AfficherChaine("Normalisation du tableau avec plancher=25, plafond=75.");
		AfficherTableau2D(norm);
		// assombrissement
		AfficherChaine("Image.");
		AfficherTableau2D(t);
		int[,] assombrit = AssombrireImage(t);
		AfficherChaine("Assombrissement de l'image.");
		AfficherTableau2D(assombrit);
		// recantrage de l'image
		AfficherChaine("Image.");
		AfficherTableau2D(t);
		int[,] recentree = RecentrerImage(t);
		AfficherChaine("Recentrage de l'image sur une moyenne de 128.");
		AfficherTableau2D(recentree);
		// recadrage de l'image
		AfficherChaine("Image.");
		AfficherTableau2D(t);
		int[,] recadree = RecadrerImage(t);
		AfficherChaine("Recadrage de l'image sur dans l'ensemble [0,255]");
		AfficherTableau2D(recadree);
	}
}
