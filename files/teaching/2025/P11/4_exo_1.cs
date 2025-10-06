// Auteur : Romain PERRIN

using System;

class Exercice1
{
    // Procédure : AfficherNotes
    // Entrée : - tab : tableau 1D de réels
    // Sortie : void
    public static void AfficherNotes(float[] tab)
    {
        Console.Write("tableau de flottants : { ");
        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write($"{tab[i]} ");
        }
        Console.WriteLine("}");
    }
    
    // Fonction : PlusPetiteNote
    // Entrée : - tab : tableau 1D de réels
    // Sortie : réel
    public static float PlusPetiteNote(float[] tab)
    {
        float plusPetite = tab[0];
        for (int i = 1; i < tab.Length; i++)
        {
            if (tab[i] < plusPetite)
            {
                plusPetite = tab[i];
            }
        }
        return plusPetite;
    }
    
    // Procédure : AfficherNotesALenvers
    // Entrée : - tab : tableau 1D de réels
    // Sortie : void
    public static void AfficherNotesALenvers(float[] tab)
    {
        Console.Write("tableau de flottants à l'envers : { ");
        for (int i = tab.Length - 1; i >= 0; i--)
        {
            Console.Write($"{tab[i]} ");
        }
        Console.WriteLine("}");
    }
    
    // Fonction : MoyenneValeursSup
    // Entrée : - tab : tableau 1D de réels
    //		- val : réel
    // Sortie : void
    public static float MoyenneValeursSup(float[] tab, float val)
    {
        float moyenne = 0.0f;
        int nValeurs = 0;
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i] >= val)
            {
                moyenne += tab[i];
                nValeurs++;
            }
        }
        moyenne = moyenne / nValeurs;
        return moyenne;
    }
    
    // Fonction : PremierIndiceVal
    // Entrée : - tab : tableau 1D de réels
    //		- val : réel
    // Sortie : void
    public static float PremierIndiceVal(float[] tab, float val)
    {
       int indice = -1; // si le tableau est vide ou si val n'est pas trouvé
        for (int i = 0; i < tab.Length && indice == -1; i++)
        {
            if (tab[i] == val)
            {
                indice = i;
            }
        }
        return indice;
    }
    
    // Fonction : DernierIndiceVal
    // Entrée : - tab : tableau 1D de réels
    //		- val : réel
    // Sortie : void
    public static float DernierIndiceVal(float[] tab, float val)
    {
       int indice = -1; // si le tableau est vide ou si val n'est pas trouvé
        for (int i = tab.Length - 1; i >= 0 && indice == -1; i--)
        {
            if (tab[i] == val)
            {
                indice = i;
            }
        }
        return indice;
    }
    
    // Fonction : ExisteValTab
    // Entrée : - tab : tableau 1D de réels
    //          - val : réel
    // Sortie : void
    public static bool ExisteValTab(float[] tab, float val)
    {
       bool existe = false;
        for (int i = 0; i < tab.Length && !existe; i++)
        {
            if (tab[i] == val)
            {
                existe = true;
            }
        }
        return existe;
    }
    
    // Fonction : NbOccurrencesTab
    // Entrée : - tab : tableau 1D de réels
    //          - val : réel
    // Sortie : void
    public static int NbOccurrencesTab(float[] tab, float val)
    {
       int occurences = 0;
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i] == val)
            {
                occurences++;
            }
        }
        return occurences;
    }
    
    // Fonction : SaisirFlottant
    // Entrée : - texte : chaîne de caractères
    // Sortie : réel (flottant)
    public static float SaisirFlottant(string texte)
    {
       Console.Write(texte);
       return float.Parse(Console.ReadLine());
    }
    
    public static void Main()
    {
        // initialisation du tableau lesNotes
        float[] lesNotes = new float[] {11.0f, 12.5f, 11.0f, 10.0f, 6.5f, 9.5f, 15.0f, 10.0f, 15.0f, 14.0f, 17.0f, 2.0f};
        
        // 1 - afficher les notes
        AfficherNotes(lesNotes);
        
        // 2 - afficher la plus petite note
        Console.WriteLine($"La plus petite note est : {PlusPetiteNote(lesNotes)}");
        
        // 3 - afficher les notes dans l'ordre inverse
        AfficherNotesALenvers(lesNotes);
        
        // 4 - afficher la moyenne des notes supérieures à 10
        Console.WriteLine($"La moyenne des notes supérieures à 10 est {MoyenneValeursSup(lesNotes, 10)}");
        
        // 5 - afficher l'indice de la première case contenant 6
        Console.WriteLine($"L'indice de la première case contenant 6 est {PremierIndiceVal(lesNotes, 6.0f)}");
        
        // 6 - afficher l'indice de la dernière case contenant 10
        Console.WriteLine($"L'indice de la dernière case contenant 10 est {DernierIndiceVal(lesNotes, 10.0f)}");
        
        // 7 - afficher si oui ou non il y a la note 20 dans le tableau
        Console.WriteLine($"La note 20 existe dans le tableau {ExisteValTab(lesNotes, 20.0f)}");
        
        // 8 - afficher le nombre d'occurences d'une note saisie par l'utilisateur
        float val = SaisirFlottant("Saisir un réel entre 0 et 20 : ");
        Console.WriteLine($"Le nombre d'occurrences de {val} dans le tableau est de {NbOccurrencesTab(lesNotes, val)}");
    }
}
