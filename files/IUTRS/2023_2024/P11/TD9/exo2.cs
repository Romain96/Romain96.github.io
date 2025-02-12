// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
{
    // Procédure : affichage d'une pile d'entiers
    // Paramètres :
    //  - pile (Stack<int>): pile d'entiers
    // Retourne : rien
    public static void AfficherPile(Stack<int> pile)
    {
        foreach (int e in pile)
        {
            Console.Write($"{e} ");
        }
        Console.Write("\n");
    }

    // Fonction : dépile les éléments d'une pile jusq'à une valeur donnée
    // Paramètres :
    //  - pile (Stack<int>): pile d'entiers
    //  - elt (int): élément marquant la fin du dépilage (elt n'est pas dépilé)
    // Retourne : rien, modification de `pile` par effets de bord
    // Post-conditions : si `elt` n'est pas dans `pile`, la pile est vide en sortie.
    public static void DepilerJusqua(Stack<int> pile, int elt)
    {
        while (pile.Count > 0 && pile.Peek() != elt)
        {
            pile.Pop();
        }
    }

    static void Main()
    {
        Stack<int> p = new Stack<int>(new int[]{17, 8, 14, 5, 21, 6, 3, 5, 12, 7});
        AfficherPile(p);
        DepilerJusqua(p, 21);
        AfficherPile(p);
    }
}