// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice1
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

    // Fonction : ordonne les éléments d'une pile en empilant les éléments impairs en premier
    // puis les éléments pairs; converse l'ordre original des élémenrs impairs et inverse celui
    // des éléments pais.
    // Paramètres :
    //  - pile (Stack<int>): pile d'entiers
    // Retourne :
    //  - res (Stack<int>): une nouvelle pile d'entiers de même taille que `pile` et contenant les mêmes éléments ordonnés
    public static Stack<int> OrdonnerImpairPair(Stack<int> pile)
    {
        Stack<int> res = new Stack<int>();
        Stack<int> tmp = new Stack<int>();
        // on dépile les éléments un par un
        // si l'élément est impair, on l'empile dans res
        // si l'élément des pair, on l'empile dans tmp
        // quand la pile est vide, on dépile les éléments de tmp et on les impile dans pile
        while (pile.Count > 0)
        {
            int elt = pile.Pop();
            if (elt % 2 != 0)
            {
                res.Push(elt);
            }
            else
            {
                tmp.Push(elt);
            }
        }
        while (tmp.Count > 0)
        {
            res.Push(tmp.Pop());
        }
        return res;
    }

    static void Main()
    {
        Stack<int> p1 = new Stack<int>(new int[]{17, 8, 14, 5, 21, 6, 3, 5, 12, 7});
        AfficherPile(p1);
        Stack<int> p2 = OrdonnerImpairPair(p1);
        AfficherPile(p2);
    }
}