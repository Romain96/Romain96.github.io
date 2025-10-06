// Auteur : Romain PERRIN

using System;

class Exercice5
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
	
	// Procédure : AfficherHistogramme
    // Entrée : - hist : tableau 1D d'entiers
    // Sortie : void
    public static void AfficherHistogramme(int[] hist)
    {
		// pour chaque entrée dans l'histogramme
       for (int i = 0; i < hist.Length; i++)
	   {
		   Console.Write($"{i}\t");
		   // afficher "=" autant de fois que hist[i]
		   for (int j = 0; j < hist[i]; j++)
		   {
			   Console.Write("=");
		   }
		   Console.WriteLine("");	// saut de ligne
	   }
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
