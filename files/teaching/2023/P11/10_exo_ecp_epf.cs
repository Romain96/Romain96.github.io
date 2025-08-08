// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceECPEPF
{
    // Procédure : suppression des caractères non valides dans nos ECP
    // Paramètres :
    //  - chaine (string): chaine de caractères représentant un ECP
    // Retourne :
    //  - res (string): la chaine `chaine` ne contenant que les caractères autorisés
    // Note : caractères autorisés : '(', ')', '0', '1', '&', '|', '!', '^'
    public static string SupprimerCaracteresInterdits(string chaine)
    {
        string res = "";
        foreach (char c in chaine)
        {
            if (c == '(' || c == ')' || c == '0' || c == '1' || c == '&' || c == '|' || c == '^' || c == '!')
            {
                res += c;
            }
        }
        return res;
    }

    // Procédure : décide si un caractère est une constante booléenne
    // Paramètres :
    //  - c (char): caractère à tester
    // Retourne : 
    //  - (bool): vrai si c est 0 ou 1, faux sinon
    public static bool EstConstante(char c)
    {
        if (c == '0' || c == '1')
            return true;
        else
            return false;
    }

    // Procédure : décide si un caractère est un opérateur booléen unaire
    // Paramètres :
    //  - c (char): caractère à tester
    // Retourne : 
    //  - (bool): vrai si c est !, faux sinon
    public static bool EstOperateurUnaire(char c)
    {
        if (c == '!')
            return true;
        else
            return false;
    }

    // Procédure : décide si un caractère est un opérateur booléen binaire
    // Paramètres :
    //  - c (char): caractère à tester
    // Retourne : 
    //  - (bool): vrai si c est &, | ou ^, faux sinon
    public static bool EstOperateurBinaire(char c)
    {
        if (c == '&' || c == '|' || c == '^')
            return true;
        else
            return false;
    }

    // Procédure : décide si un caractère est un opérateur booléen
    // Paramètres :
    //  - c (char): caractère à tester
    // Retourne : 
    //  - (bool): vrai si c est &, |, ^ ou !, faux sinon
    public static bool EstOperateur(char c)
    {
        if (EstOperateurUnaire(c) || EstOperateurBinaire(c))
            return true;
        else
            return false;
    }

    // Procédure : transforme un caractère en une valeur booleénne
    // Paramètres :
    //  - c (char): caractère à transformer
    // Retourne :
    //  - (bool): valeur booléenne
    // Pré-conditions :
    //  - c doit être une constante booléenne (0 ou 1)
    public static bool Char2Bool(char c)
    {
        if (c == 0)
            return false;
        else
            return true;
    }

    // Procédure : transforme un booléen en un caractère 0 ou 1
    // Paramètres :
    //  - b (bool): booléen
    // Retourne :
    //  - c (char): 0 ou 1
    public static char Bool2Char(bool b)
    {
        char c = '0';
        if (b)
            c = '1';
        return c;
    }

    // Fonction : transforme une ECP en une EPF
    // Paramètres :
    //  - ecp (string): ECP à transformer
    // Retourne :
    //  - epf (string): EPF résultant de l'ECP `ecp`
    public static String ECP2EPF(string ecp)
    {
        string epf = "";
        Stack<char> operateurs = new Stack<char>();
        foreach (char c in ecp)
        {
            if (EstConstante(c))
            {
                epf += c;
            }
            else if (EstOperateur(c))
            {
                operateurs.Push(c);
            }
            else if (c == ')')
            {
                epf += operateurs.Pop();
            }
        }
        return epf;
    }

    // Fonction : évaluation d'une EPF
    // Paramètres :
    //  - epf (chaine): EPF à évaluer
    // Retourne : 
    //  - res (bool): résultat de l'EPF
    public static bool EvaluerEPF(string epf)
    {
        bool res = false;
        Stack<bool> pile = new Stack<bool>();
        foreach (char c in epf)
        {
            if (EstConstante(c))
            {
                pile.Push(Char2Bool(c));
            }
            else if (EstOperateurBinaire(c))
            {
                bool operande1 = pile.Pop();
                bool operande2 = pile.Pop();
                if (c == '&')
                    pile.Push(operande1 & operande2);
                else if (c == '|')
                    pile.Push(operande1 | operande2);
                else if (c == '^')
                    pile.Push(operande1 ^ operande2);
            }
            else if (EstOperateurUnaire(c))
            {
                if (c == '!')
                    pile.Push(! pile.Pop());
            }
        }
        res = pile.Pop();
        return res;
    }

    // Fonction : évaluation et vérification de syntaxe d'une ECP
    // Paramètres :
    //  - ecp (string): ECP à vérifier et à évaluer
    // Retourne : 
    //  - res (bool): résultat de l'évaluation de l'ECP
    public static bool EvaluerEtVerifierECP(string ecp)
    {
        bool res = false;
        Stack<char> pile = new Stack<char>();
        int i = 0;
        bool stop = false;
        List<char> l = new List<char>();

        // parcours de la chaine
        while (i < ecp.Length)
        {
            // empilement des caractères jusqu'à trouver une parenthèse fermante
            stop = false;
            while (! stop)
            {
                char c = ecp[i];
                pile.Push(c);
                i++;
                if (c == ')' || i >= ecp.Length)
                    stop = true;
            }

            // dépilement jusqu'à obtenir une parenthèse ouvrante et stockage dans une liste
            stop = false;
            l.Clear();
            if (pile.Count == 0)
                stop = true;
            while (! stop)
            {
                char c = pile.Pop();
                l.Add(c);
                if (pile.Count == 0 || c == '(')
                    stop = true;
            }

            // varification de l'expression courante et évaluation si correcte
            // ( const1 op const2 ) avec op opérateur binaire
            if (l.Count == 5 && l[0] == ')' && EstConstante(l[1]) && EstOperateurBinaire(l[2]) && EstConstante(l[3]) && l[4] == '(')
            {
                if (l[2] == '&')
                    pile.Push(Bool2Char(Char2Bool(l[1]) & Char2Bool(l[3])));
                else if (l[2] == '|')
                    pile.Push(Bool2Char(Char2Bool(l[1]) | Char2Bool(l[3])));
                else if (l[2] == '^')
                    pile.Push(Bool2Char(Char2Bool(l[1]) ^ Char2Bool(l[3])));
            }
            // ( const op ) avec op opérateur unaire
            else if (l.Count == 4 && l[0] == ')' && EstConstante(l[1]) && EstOperateurUnaire(l[2]) && l[3] == '(')
            {
                if (l[2] == '!')
                    pile.Push(Bool2Char(! Char2Bool(l[1])));
            }
            else
            {
                Console.WriteLine("l'ECP n'est pas correcte !");
                return false;
            }
        }
        if (pile.Count != 1)
        {
            Console.WriteLine("L'ECP n'est pas correcte !");
            return false;
        }
        res = Char2Bool(pile.Pop());
        return res;
    }

    static void Main()
    {
        Console.Write("Écrivez une ECP  : ");
        string exp = Console.ReadLine();
        Console.WriteLine($"ECP originale    : {exp}");
        exp = SupprimerCaracteresInterdits(exp);
        Console.WriteLine($"ECP à traiter    : {exp}");
        string epf = ECP2EPF(exp);
        Console.WriteLine($"EPF résultante   : {epf}");
        bool res_epf = EvaluerEPF(epf);
        Console.WriteLine($"Évaluation EPF   : {res_epf}");
        bool res_ecp = EvaluerEtVerifierECP(exp);
        Console.WriteLine($"Évaluation ECP   : {res_ecp}");
    }
}