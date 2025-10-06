// Auteur : Romain PERRIN

using System;

class Exercice9
{  
    // Fonction : SaisirEntier
    // Entrée : - texte : chaîne de caractères
    // Sortie : entier
    public static int SaisirEntier(string texte)
    {
       Console.Write(texte);
       return int.Parse(Console.ReadLine());
    }
	
	// Fonction : InitTabVideEntier
    // Entrée : - n : entier
    // Sortie : tableau 1D de n entiers
    public static int[] InitTabVideEntier(int n)
    {
       int[] tab = new int[n];
	   for (int i = 0; i < n; i++)
	   {
		   tab[i] = 0;
	   }
	   return tab;
    }
	
	// Fonction : RechercheMaxTab
	// Entrée :	- tab : tableau 1D d'entiers
	// Sortie : entier
	public static int RechercheMaxTab(int[] tab)
	{
		int max = tab[0];
		for (int i = 1; i < tab.Length; i++)
		{
			if (tab[i] > max)
			{
				max = tab[i];
			}
		}
		return max;
	}
	
	// Procédure : AfficherHistogramme
    // Entrée : - hist : tableau 1D d'entiers
    // Sortie : void
    public static void AfficherHistogramme(int[] hist)
    {
		// nombre de lignes max (hors affichage des nombres)
		int valMax = RechercheMaxTab(hist);
		
       for (int i = valMax; i > 0; i--)
	   {
		   // pour chaque entrée dans l'histogramme
		   for (int j = 0; j < hist.Length; j++)
		   {
			   // si la valeur est supérieure ou égale à la i alors on écrit "| "
			   if (hist[j] >= i)
			   {
				   Console.Write("|  ");
			   }
			   else
			   {
				   Console.Write("   ");
			   }
		   }
		   Console.WriteLine("");
	   }
	   
	   // affichage des nombres (légende)
	   for (int i = 0; i < hist.Length; i++)
	   {
		   Console.Write($"{i:D2} ");
	   }
	   Console.WriteLine("");
    }
	
    public static void Main()
    {
		int[] tab = InitTabVideEntier(21);
		int n;
		bool saisir = true;
		
		while (saisir)
		{
			do
			{
				n = SaisirEntier("Saisir un entier entre 0 et 20 (-1 pour stopper la saisie) : ");
			}
			while (n < -1 || n > 20);
			
			if (n == -1)
			{
				saisir = false;
			}
			else
			{
				tab[n]++;
			}
		}
		AfficherHistogramme(tab);
    }
}
