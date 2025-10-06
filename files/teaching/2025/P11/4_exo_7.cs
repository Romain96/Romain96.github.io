// Auteur : Romain PERRIN

using System;

class Exercice7
{  
    // Fonction : SaisirEntier
    // Entrée : - texte : chaîne de caractères
    // Sortie : entier
    public static int SaisirEntier(string texte)
    {
       Console.Write(texte);
       return int.Parse(Console.ReadLine());
    }
	
	// Fonction : InitTab
    // Sortie : tableau 1D de 10 entiers
    public static int[] InitTab()
    {
       int[] tab = new int[] {5, 11, 19, 38, 54, 55, 78, 87, 100, 105};
	   return tab;
    }
	
	// Procédure : AfficherTableauEntier
    // Entrée : - tab : tableau 1D d'entiers
    // Sortie : void
    public static void AfficherTableauEntier(int[] tab)
    {
        Console.Write("tableau d'entiers : { ");
        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write($"{tab[i]} ");
        }
        Console.WriteLine("}");
	}
	
	// Fonction : RechercheDichotomique
    // Entrée : - tab : tableau 1D d'entiers
	//			- val : entier
    // Sortie : entier (indice dans le tableau ou -1 si non trouvé)
    public static int RechercheDichotomique(int[] tab, int val)
    {
		int debut = 0;
		int fin = tab.Length - 1;
		int milieu;
		
		while (fin - debut >= 0)
		{
			milieu = debut + ((fin - debut) / 2);

			// recherche dans la partie droite
			if (val > tab[milieu])
			{
				debut = milieu + 1;
			}
			// recherche dans la partie gauche
			else if (val < tab[milieu])
			{
				fin = milieu - 1;
			}
			else
			{
				return milieu;
			}
		}
		return -1;	// non trouvé dans le tableau
	}
	
    public static void Main()
    {
		int[] tab = InitTab();
		AfficherTableauEntier(tab);
		int n = SaisirEntier("Saisir un entier à rechercher dans le tableau par dichotomie : ");
		Console.WriteLine($"Indice de la valeur {n} : {RechercheDichotomique(tab, n)}");
    }
}
