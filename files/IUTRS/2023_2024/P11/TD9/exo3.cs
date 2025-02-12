// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice3
{
    // Procédure : affichage d'une pile d'entiers
    // Paramètres :
    //  - pile (Stack<int>): pile d'entiers
    // Retourne : rien
    public static void AfficherPile(Stack<string> pile)
    {
        foreach (string e in pile)
        {
            Console.Write($"{e} ");
        }
        Console.Write("\n");
    }

    // Procédure : affichage d'une liste d'élève (liste de liste de trois chaines de caractères)
    // Paramètres :
    //  - liste (List<List<string>>): liste de liste de chaines de caractères
    // Retourne : rien
    public static void AfficherListeEleve(List<List<string>> liste)
    {
        foreach (List<string> l in liste)
        {
            Console.Write("{ ");
            foreach (string e in l)
            {
                Console.Write($"{e} ");
            }
            Console.Write("}\n");
        }
        Console.Write("\n");
    }

    // Fonction : remplit une pile de feux en fonction d'une liste d'élève (question/réponse/note)
    // Paramètres :
    //  -
    public static Stack<string> RemplirFeux(List<List<string>> listeEleve)
    {
        Stack<string> feux = new Stack<string>();
        foreach (List<string> triplet in listeEleve)
        {
            string note = triplet[2];
            if (note == "A")
            {
                feux.Push("vert");
            }
            else if (note == "B")
            {
                feux.Push("orange");
            }
            else if (note == "C")
            {
                feux.Push("rouge");
            }
        }
        return feux;
    }

    // Fonction : calcule les points d'un élève étant donné une pile de feux
    // Paramètres :
    //  - p (Stack<string>): pile de feux de l'élève
    // Retourne :
    //  - points (int): le nombre de points obtenus par l'élève en fonction de la pile de feux
    public static int CalculePoints(Stack<string> p)
    {
        int points = 0;
        if (p.Count >= 2)
        {
            string prev = p.Pop();
            string cur = prev;
            while (p.Count > 0)
            {
                cur = p.Pop();
                if (prev == cur)
                {
                    if (prev == "vert")
                    {
                        points += 10;
                    }
                    else if (prev == "orange")
                    {
                        points += 5;
                    }
                    else if (prev == "rouge")
                    {
                        points -= 10;
                    }
                }
                prev = cur;
            }
        }
        return points;
    }

    static void Main()
    {
        List<List<string>> le = new List<List<string>>();
        le.Add(new List<String>(){"question1", "reponse1", "A"});
        le.Add(new List<String>(){"question2", "reponse2", "A"});
        le.Add(new List<String>(){"question3", "reponse3", "B"});
        le.Add(new List<String>(){"question4", "reponse4", "A"});
        le.Add(new List<String>(){"question5", "reponse5", "A"});
        le.Add(new List<String>(){"question6", "reponse6", "B"});
        le.Add(new List<String>(){"question7", "reponse7", "B"});
        le.Add(new List<String>(){"question8", "reponse8", "C"});
        le.Add(new List<String>(){"question9", "reponse9", "C"});
        le.Add(new List<String>(){"question10", "reponse10", "A"});
        le.Add(new List<String>(){"question11", "reponse11", "C"});
        le.Add(new List<String>(){"question12", "reponse12", "C"});
        le.Add(new List<String>(){"question13", "reponse13", "B"});
        AfficherListeEleve(le);
        Stack<string> fe = RemplirFeux(le);
        AfficherPile(fe);
        int pts = CalculePoints(fe);
        Console.WriteLine($"Nombre de points obtenus par l'élève : {pts}");
    }
}