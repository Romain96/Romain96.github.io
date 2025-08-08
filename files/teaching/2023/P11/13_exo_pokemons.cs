// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Revisions
{
    // structure Pokemon
    public struct Pokemon
    {
        // attributs
        public string _nom;
        public int _niveau;

        // constructeurs paramétré
        public Pokemon(string nom, int niveau)
        {
            _nom = nom;
            _niveau = niveau;
        }
    }

    // Procédure : génère le nom du fichier selon le nom du joueur
    // Paramètres :
    //  - nomJoueur (string): le nom du joueur
    // Retourne :
    //  - nomFichier (string): le nom du fichier à lire
    public static string GenererNomFichier(string nomJoueur)
    {
        string nomFichier = $"{nomJoueur}.txt";
        //string nomFichier = nomJoueur + ".txt"; // autre possibilité
        return nomFichier;
    }

    // Procédure : lecture d'un fichier ligne par ligne
    // Paramètres :
    //  - chemin (string): le chemin vers le fichier à lire
    // Retourne :
    //  - lignes (string[]): tableau des lignes lues dans le fichier indiqué par `chemin`
    public static string[] LireFichierLigneParLigne(string chemin)
    {
        string[] lignes = File.ReadAllLines(chemin);
        return lignes;
    }

    // Procédure : affichage du dictionnaire
    // Paramètres :
    //  - dico (Dictionary<string, List<Pokemon>>): dictionnaire avec clef sous forme de chaines et valeurs sous forme de listes de Pokemon
    // Retourne : rien, affichage dans le terminal
    public static void AfficherDictionnaire(Dictionary<string, List<Pokemon>> dico)
    {
        foreach (KeyValuePair<string, List<Pokemon>> kvp in dico)
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine($"Nom du joueur : {kvp.Key}");
            Console.Write("<");
            foreach (Pokemon p in kvp.Value)
            {
                Console.Write($"<Pokemon : Nom : {p._nom}, Niveau : {p._niveau}>");
            }
            Console.WriteLine(">");
        }
    }

    // Fonction : calcule le niveau maximum des Pokémons d'un joueur
    // Paramètres :
    //  - dico (Dictionary<string, List<Pokemon>>): dictionnaire avec clef sous forme de chaines et valeurs sous forme de listes de Pokemon
    //  - joueur (string): le joueur pour lequel on souhaite connaître le niveau maximum de ses Pokémons
    // Retourne :
    //  - niveauMax (int): le niveau maximum des Pokémons du joueur `joueur`.
    // Note : retourne -1 si `joueur` n'est pas une clef valide ou s'il n'a pas de Pokémon
    public static int NiveauMaxPokemonsDuJoueur(Dictionary<string, List<Pokemon>> dico, string joueur)
    {
        int niveauMax = -1;
        List<Pokemon> pokemons = new List<Pokemon>();
        dico.TryGetValue(joueur, out pokemons);
        foreach (Pokemon p in pokemons)
        {
            if (p._niveau > niveauMax)
            {
                niveauMax = p._niveau;
            }
        }
        return niveauMax;
    }

    static void Main()
    {
        // liste des joueurs
        List<string> joueurs = new List<string>(){"Coco", "Crash", "VonClutch"};
        // dictionnaire
        Dictionary<string, List<Pokemon>> jeu = new Dictionary<string, List<Pokemon>>();

        // pour chaque joueur
        foreach (string joueur in joueurs)
        {
            // liste des Pokémons du joueur
            List<Pokemon> lp = new List<Pokemon>();

            // générer le nom de fichier et lire celui-ci
            string fichierALire = GenererNomFichier(joueur);
            string[] lignes = LireFichierLigneParLigne(fichierALire);

            // lire chaque ligne du fichier
            foreach (string ligne in lignes)
            {
                // séparer la ligne selon la virgule, la première partie est le nom du Pokémon, la seconde son niveau
                string[] champs = ligne.Split(',');
                string nomPokemon = champs[0];
                int niveauPokemon = int.Parse(champs[1]); // conversion en entier

                // fabriquer un Pokémon à partir de la ligne et le placer dans une liste
                Pokemon p = new Pokemon(nomPokemon, niveauPokemon);
                lp.Add(p);
            }
            // ajouter un nouveau couple joueur, liste de Pokémons du joueur dans le dictionnnaire
            jeu.TryAdd(joueur, lp);
        }
        AfficherDictionnaire(jeu);

        // pour chaque joueur afficher le niveau max des pokémons
        foreach (string joueur in joueurs)
        {
            int niveauMax = NiveauMaxPokemonsDuJoueur(jeu, joueur);
            Console.WriteLine($"Le meilleur Pokémon de {joueur} a un niveau {niveauMax}");
        }
    }
}