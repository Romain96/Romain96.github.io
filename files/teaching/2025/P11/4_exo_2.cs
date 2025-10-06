// Auteur : Romain PERRIN

using System;

class Exercice2
{
    // Procédure : AfficherTableauFlottant
    // Entrée : - tab : tableau 1D de réels
    // Sortie : void
    public static void AfficherTableauFlottant(float[] tab)
    {
        Console.Write("tableau de flottants : { ");
        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write($"{tab[i]} ");
        }
        Console.WriteLine("}");
    }
    
    // Fonction : InitialiserTableau1
    // Entrée : - n : entier
    // Sortie : tableau de réels (flottants)
    public static float[] InitialiserTableau1(int n)
    {
        float[] tab = new float[n];
        for (int i = 0; i < n; i++)
        {
            tab[i] = 0;
        }
        return tab;
    }
    
    // Fonction : InitialiserTableau2
    // Entrée : - n : entier
    // Sortie : tableau de réels (flottants)
    public static float[] InitialiserTableau2(int n)
    {
        float[] tab = new float[n];
        for (int i = 0; i < n; i++)
        {
            tab[i] = i + 1;
        }
        return tab;
    }
    
    // Fonction : InitialiserTableau3
    // Entrée : - n : entier
    // Sortie : tableau de réels (flottants)
    public static float[] InitialiserTableau3(int n)
    {
        float[] tab = new float[n];
        float val = (float) n * 2.0f;
        for (int i = 0; i < n; i++)
        {
            tab[i] = val;
            val -= 2.0f;
        }
        return tab;
    }
    
    public static void Main()
    {
        Console.WriteLine("Tableau 1");
        AfficherTableauFlottant(InitialiserTableau1(10));
        Console.WriteLine("Tableau 2");
        AfficherTableauFlottant(InitialiserTableau2(10));
        Console.WriteLine("Tableau 3");
        AfficherTableauFlottant(InitialiserTableau3(10));
    }
}
