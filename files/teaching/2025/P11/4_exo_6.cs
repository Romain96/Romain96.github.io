// Auteur : Romain PERRIN

using System;

class Exercice6
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
	
	// Fonction : RechercheIndiceInsertion
    // Entrée : - tab : tableau 1D d'entiers
	//			- val : entier
    // Sortie : entier
    public static int RechercheIndiceInsertion(int[] tab, int nbVal, int val)
    {
		int indice = 0;
		{
			for (int i = 0; i < nbVal && tab[i] < val; i++)
			{
				indice++;
			}
		}
        return indice;
	}
	
	// Procédure : InsererValeurTableau
    // Entrée : - tab : tableau 1D d'entiers
	//			- référence nbVal : entier
	//			- val : entier
    // Sortie : void
    public static void InsererValeurTableau(int[] tab, ref int nbVal, int val)
    {
		// insertion impossible, le tableau est plein !
        if (nbVal == tab.Length)
		{
			return;
		}
		// insertion en nbVal
		int indice = RechercheIndiceInsertion(tab, nbVal, val);
		
		if (indice != -1)
		{
			// décalage de toutes les valeurs vers la droite de 'indice' à 'nbVal'
			for (int i = nbVal; i >= indice + 1; i--)
			{
				tab[i] = tab[i - 1];
			}
			// insertion de la valeur en 'indice'
			tab[indice] = val;
			nbVal++;
		}
		else
		{
			// insertion de la valeur en 'nbVal'
			tab[nbVal] = val;
			nbVal++;
		}
	}
	
    public static void Main()
    {
		int[] tab = InitTabVideEntier(20);
		int nbVal = 0;
		int val;
		int choix;
		bool menu = true;
		
		while (menu)
		{
			do
			{
				choix = SaisirEntier("1 - Afficher le tableau\n2 - Insérer un nombre\n3 - Quitter\n Choix : ");
			}
			while (choix < 1 || choix > 3);
			
			switch (choix)
			{
				case 1: 
					AfficherTableauEntier(tab);
					break;
				case 2: 
					val = SaisirEntier("Saisir un valeur à insérer : ");
					InsererValeurTableau(tab, ref nbVal, val);
					break;
				case 3: 
					menu = false;
					break;
				default: 
					menu = false;
					break;
			}
		}
    }
}
