// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExerciceGaulois
{
    // structure Gaulois
    public struct Gaulois
    {
        public string _nom;
        public char _sexe;
        public string _occupation;
        public int _village;

        // constructeur
        public Gaulois(string nom, char sexe, string occupation, int village)
        {
            _nom = nom;
            _sexe = sexe;
            _occupation = occupation;
            _village = village;
        }
    }

    // structure Village
    public struct Village
    {
        public string _nom;
        public int _habitants;

        // constructeur
        public Village(string nom, int habitants)
        {
            _nom = nom;
            _habitants = habitants;
        }
    }

    // Procédure : transformation d'un Gaulois en chaine de caractères
    // Paramètres :
    //  - g (Gaulois): Gaulois
    // Retourne :
    //  - chaine (string): Gaulois `g` sous forme de chaine de caractères
    public static string GauloisToString(Gaulois g)
    {
        string chaine = "";
        if (g._sexe == 'M')
            chaine = $"{g._nom} est un homme, son occupation est {g._occupation} et il vit dans le village {g._village}.";
        else
            chaine = $"{g._nom} est une femme, son occupation est {g._occupation} et elle vit dans le village {g._village}.";
        return chaine;
    }

    // Procédure : transforme une table de Gaulois en chaine
    // Paramètres :
    //  - table (Dictionary<int, Gaulois>): table de Gaulois
    // Retourne :
    //  - chaine (string): table `table` sous forme de chaine de caractères
    public static string TableGauloisToString(Dictionary<int, Gaulois> table)
    {
        string chaine = "";
        foreach (KeyValuePair<int, Gaulois> kvp in table)
        {
            chaine += $"Clef {kvp.Key} - Gaulois : {GauloisToString(kvp.Value)}\n";
        }
        return chaine;
    }

    // Procédure : affichage d'une table de Gaulois
    // Paramètres :
    //  - table (Dictionary<int, Gaulois>): table de Gaulois à afficher
    // Retourne : rien
    public static void AfficherTableGaulois(Dictionary<int, Gaulois> table)
    {
        Console.WriteLine("Table de Gaulois");
        Console.WriteLine($"{TableGauloisToString(table)}");
    }

    // Procédure : transformation d'un Village en chaine de caractères
    // Paramètres :
    //  - v (Village): Village
    // Retourne :
    //  - chaine (string): villafe `v` sous forme de chaine de caractères
    public static string VillageToString(Village v)
    {
        string chaine = $"{v._nom} ({v._habitants} habitants).";
        return chaine;
    }

    // Procédure : transforme une table de Village en chaine
    // Paramètres :
    //  - table (Dictionary<int, Village>): table de Village
    // Retourne :
    //  - chaine (string): table `table` sous forme de chaine de caractères
    public static string TableVillageToString(Dictionary<int, Village> table)
    {
        string chaine = "";
        foreach (KeyValuePair<int, Village> kvp in table)
        {
            chaine += $"Clef {kvp.Key} - Village : {VillageToString(kvp.Value)}\n";
        }
        return chaine;
    }

    // Procédure : affichage d'une table de Village
    // Paramètres :
    //  - table (Dictionary<int, Village>): table de Village à afficher
    // Retourne : rien
    public static void AfficherTableVillages(Dictionary<int, Village> table)
    {
        Console.WriteLine("Table de Village");
        Console.WriteLine($"{TableVillageToString(table)}");
    }

    // Fonction : lecture d'une chaine de caractères d'un ficher texte
    // Paramètres :
    //  - chemin (string): chemin vers le ficher à ouvrir
    // Retourne :
    //  - texte (string): contenu textuel du fichier passé en paramètre
    // Pré-conditions :
    //  - `chemin` doit être un chemin de fichier valide
    public static string[] LireFichier(string chemin)
    {
        string[] texte = File.ReadAllLines(chemin);
        return texte;
    }

    // Fonction : lecture du fichier gaulois
    // Paramètres :
    //  - chemin (string): chemin vers le fichier contenant les gaulois
    // Retourne : 
    //  - gaulois (Dictionary<int, Gaulois>): la table des Gaulois lue depuis le fichier `chemin`
    public static Dictionary<int, Gaulois> RemplirTableGaulois(string chemin)
    {
        Dictionary<int, Gaulois> gaulois = new Dictionary<int, Gaulois>();
        if (File.Exists(chemin))
        {
            string[] lignes = LireFichier(chemin);
            foreach (string ligne in lignes)
            {
                // séparation selon le caractère ';'
                string[] elements = ligne.Split(';');
                // les éléments sont clef, nom, sexe, occupation, village
                if (elements.Length >= 5)
                {
                    int clef = int.Parse(elements[0]);
                    string nom = elements[1];
                    char sexe = elements[2][0];
                    string occupation = elements[3];
                    int village = int.Parse(elements[4]);
                    Gaulois g = new Gaulois(nom, sexe, occupation, village);
                    gaulois.TryAdd(clef, g);
                }
            }
        }
        return gaulois;
    }

    // Fonction : lecture du fichier gaulois
    // Paramètres :
    //  - chemin (string): chemin vers le fichier contenant les gaulois
    // Retourne : 
    //  - villages (Dictionary<int, Village>): la table des Village lue depuis le fichier `chemin`
    public static Dictionary<int, Village> RemplirTableVillage(string chemin)
    {
        Dictionary<int, Village> villages = new Dictionary<int, Village>();
        if (File.Exists(chemin))
        {
            string[] lignes = LireFichier(chemin);
            foreach (string ligne in lignes)
            {
                // séparation selon le caractère ';'
                string[] elements = ligne.Split(';');
                // les éléments sont clef, nom, habitants
                if (elements.Length >= 3)
                {
                    int clef = int.Parse(elements[0]);
                    string nom = elements[1];
                    int habitants = int.Parse(elements[2]);
                    Village v = new Village(nom, habitants);
                    villages.TryAdd(clef, v);
                }
            }
        }
        return villages;
    }

    // Fonction : recherche les informations d'un Gaulois
    // Paramètres :
    //  - clef (int): clef de recherche
    // Retourne :
    //  - g (Gaulois): le Gaulois correspondant à la clef ou null si non existant
    public static Gaulois? ChercherGaulois(Dictionary<int, Gaulois> table, int clef)
    {
        // si la clef existe, on retourne le Gaulois
        Gaulois tmp;
        Gaulois? g; // Gaulois? = peut contenir un Gaulois ou null
        bool existe = table.TryGetValue(clef, out tmp);
        if (existe)
            g = tmp;
        // sinon on retourne null
        else
            g = null;
        return g;
    }

    // Procédure : affiche les informations d'un Gaulois
    // Paramètres :
    //  - g (Gaulois?): Gaulois ou null
    // Retourne : rien
    public static void AfficherInformationsGaulois(Gaulois? g)
    {
        if (g == null)
            Console.WriteLine("Gaulois : N/A");
        else
            Console.WriteLine($"Gaulois : {GauloisToString((Gaulois)g)}");
    }


    // Fonction : recherche les informations d'un Village
    // Paramètres :
    //  - clef (int): clef de recherche
    // Retourne :
    //  - v (Village): le Village correspondant à la clef ou null si non existant
    public static Village? ChercherVillage(Dictionary<int, Village> table, int clef)
    {
        // si la clef existe, on retourne le Gaulois
        Village tmp;
        Village? v;
        bool existe = table.TryGetValue(clef, out tmp);
        if (existe)
            v = tmp;
        // sinon on retourne null
        else
            v = null;
        return v;
    }

    // Procédure : affiche les informations d'un Village
    // Paramètres :
    //  - v (Village?): Village ou null
    // Retourne : rien
    public static void AfficherInformationsVillage(Village? v)
    {
        if (v == null)
            Console.WriteLine("Village : N/A");
        else
            Console.WriteLine($"Village : {VillageToString((Village)v)}");
    }

    // Fonction : recherche le clef d'un village donné
    // Paramètres :
    //  - village (string): nom du village
    //  - tableVillages (Dictionary<int, Village>): table des villages
    //  - tableGaulois (Dictionary<int, Gaulois>): table des Gaulois
    // Retourne :
    //  - chef (Gaulois?): le chef du village donné ou null si le village et/ou le chef n'existe pas
    public static Gaulois? ChercherChefVillage(string village, Dictionary<int, Village> tableVillages, Dictionary<int, Gaulois> tableGaulois)
    {
        Gaulois? chef = null;

        // recherche de la clef du village
        int villageNum = -1;
        foreach (KeyValuePair<int, Village> kvp in tableVillages)
        {
            if (kvp.Value._nom == village)
            {
                villageNum = kvp.Key;
            }
        }

        // recherche du Gaulois dont l'occupation est 'Chef' et la clef est celle trouvée
        if (villageNum != -1)
        {
            foreach (KeyValuePair<int, Gaulois> kvp in tableGaulois)
            {
                if (kvp.Value._occupation == "Chef" && kvp.Value._village == villageNum)
                {
                    chef = kvp.Value;
                }
            }
        }

        return chef;
    }

    // Fonction : recherche les Gaulois d'un village donné
    // Paramètres :
    //  - village (string): nom du village
    //  - tableVillages (Dictionary<int, Village>): table des villages
    //  - tableGaulois (Dictionary<int, Gaulois>): table des Gaulois
    // Retourne :
    //  - chef (Gaulois?): le chef du village donné ou null si le village et/ou le chef n'existe pas
    public static List<Gaulois> ChercherGauloisVillage(string village, Dictionary<int, Village> tableVillages, Dictionary<int, Gaulois> tableGaulois)
    {
        List<Gaulois> gauloisVillage = new List<Gaulois>();

        // recherche de la clef du village
        int villageNum = -1;
        foreach (KeyValuePair<int, Village> kvp in tableVillages)
        {
            if (kvp.Value._nom == village)
            {
                villageNum = kvp.Key;
            }
        }

        // recherche du Gaulois dont l'occupation est 'Chef' et la clef est celle trouvée
        if (villageNum != -1)
        {
            foreach (KeyValuePair<int, Gaulois> kvp in tableGaulois)
            {
                if (kvp.Value._village == villageNum)
                {
                    gauloisVillage.Add(kvp.Value);
                }
            }
        }

        return gauloisVillage;
    }

    // Procédure : affichage d'une liste de Gaulois
    // Paramètres :
    //  - gaulois (List<Gaulois>): liste de Gaulois
    // Retourne : rien
    public static void AfficherListeGaulois(List<Gaulois> gaulois)
    {
        Console.WriteLine("Liste de Gaulois");
        foreach (Gaulois g in gaulois)
        {
            Console.WriteLine($"Gaulois : {GauloisToString(g)}");
        }
    }

    static void Main()
    {
        // lire le fichier gaulois.txt
        Dictionary<int, Gaulois> gaulois = RemplirTableGaulois("gaulois.txt");
        AfficherTableGaulois(gaulois);

        // lire le fichier village.txt
        Dictionary<int, Village> villages = RemplirTableVillage("village.txt");
        AfficherTableVillages(villages);

        // recherche d'un Gaulois valide et invalide
        Console.WriteLine("Recherche d'un Gaulois valide :");
        Gaulois? gauloisValide = ChercherGaulois(gaulois, 10);
        AfficherInformationsGaulois(gauloisValide);
        Console.WriteLine("Recherche d'un Gaulois invalide :");
        Gaulois? gauloisInvalide = ChercherGaulois(gaulois, 42);
        AfficherInformationsGaulois(gauloisInvalide);

        // recherche d'un Village valide et invalide
        Console.WriteLine("Recherche d'un Village valide :");
        Village? villageValide = ChercherVillage(villages, 2);
        AfficherInformationsVillage(villageValide);
        Console.WriteLine("Recherche d'un Village invalide :");
        Village? villageInvalide = ChercherVillage(villages, 42);
        AfficherInformationsVillage(villageInvalide);

        // afficher le chef d'un village
        Gaulois? chefVercingetorix = ChercherChefVillage("Alésia", villages, gaulois);
        Console.WriteLine($"Le chef du village Alésia est :");
        AfficherInformationsGaulois(chefVercingetorix);

        Gaulois? chefFictif = ChercherChefVillage("Argentoratum", villages, gaulois);
        Console.WriteLine($"Le chef du village Argentoratum est :");
        AfficherInformationsGaulois(chefFictif);

        // afficher les Gaulois d'un village
        List<Gaulois> gauloisGergovie = ChercherGauloisVillage("Gergovie", villages, gaulois);
        Console.WriteLine("Affichage des Gaulois du villade de Gergovie :");
        AfficherListeGaulois(gauloisGergovie);
        List<Gaulois> gauloisMassilia = ChercherGauloisVillage("Massilia", villages, gaulois);
        Console.WriteLine("Affichage des Gaulois du villade de Massilia :");
        AfficherListeGaulois(gauloisMassilia);
    }
}