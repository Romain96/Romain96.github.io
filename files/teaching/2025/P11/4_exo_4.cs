// Auteur : Romain PERRIN

using System;

class Exercice4
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
	
	// Fonction : ConversionDecimalBinaire
    // Entrée : - n : entier
    // Sortie : chaîne de caractères
    public static string ConversionDecimalBinaire(int n)
    {
       int[] tab = InitTabVideEntier(8);
	   
	   // conversion par division successives par les puissances de 2
	   for (int i = 0; i < 8; i++)
	   {
		   tab[i] = n % 2;
		   n = n / 2;
	   }
	   
	   // lecture à l'envers et extraction du nombre binaire sous forme de chaîne
	   string binaire = "";
	   for (int i = 7; i >= 0; i--)
	   {
		   binaire += tab[i].ToString();
	   }
	   return binaire;
    }
    
    public static void Main()
    {
		int n;
		do
		{
			n = SaisirEntier("Saisir un entier entre 0 et 255 : ");
		}
		while (n < 0 || n > 255);
		
		Console.WriteLine($"Le nombre {n} sous forme décimale est égal à {ConversionDecimalBinaire(n)} sous forme binaire");
    }
}
