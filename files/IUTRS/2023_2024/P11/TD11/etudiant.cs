// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceStructuresEtudiants
{
    // Structure : représente un étudiant de première année ainsi que les notes de ses UV
    public struct Etudiant
    {
        public string _nom;  // identité (nom)
        public string _prenom;   // identité (prénom)
        public double[] _notes; // notes aux UV
        public double _total;   // total actuel des notes
        public double _moyenne; // moyenne actuelle des notes
        public int _n;   // nombre de résultats actuellement enregistrés

        // constructeur avec le nombre de notes maximales
        public Etudiant(int nb_notes, string nom, string prenom)
        {
            _nom = nom.ToUpper();   // cosmétique : mettre le nom en majuscules
            _prenom = prenom;
            _notes = new double[nb_notes];
            for (int i = 0; i < _notes.Length; i++)
                _notes[i] = -1; // -1 pour différencier les notes non renseignées des notes nulles (0)
            _total = 0.0;
            _moyenne = 0.0;
            _n = 0;
        }
    }

    // Procédure : affiche une structure Etudiant (version complète)
    // Paramètres :
    //  - e (Etudiant): étudiant à afficher
    // Retourne : rien
    public static void AfficherEtudiant(Etudiant e)
    {
        Console.WriteLine("------------Étudiant------------");
        Console.WriteLine($"{e._nom} {e._prenom}");
        Console.WriteLine($"nombre de notes : {e._n}");
        for (int i = 0; i < e._notes.Length; i++)
        {
            Console.WriteLine($"UV {i+1} : {e._notes[i]}/20");
        }
        Console.WriteLine($"total des notes : {e._total}");
        Console.WriteLine($"moyenne des notes : {e._moyenne}");
        Console.WriteLine("--------------------------------");
    }

    // Procédure : affiche une structure Etudiant (version simple)
    // Paramètres :
    //  - e (Etudiant): étudiant à afficher
    // Retourne : rien
    public static void AfficherEtudiantSimple(Etudiant e)
    {
        Console.WriteLine($"Étudiant : {e._nom} {e._prenom} : {e._n} notes, total {e._total}, moyenne {e._moyenne}");
    }

    // Procédure : affichage d'une liste d'étudiants (struct Etudiant)
    // Paramètres :
    //  - liste (List<Etudiant>): liste d'étudiants
    // Retourne : rien
    public static void AfficherListeEtudiants(List<Etudiant> liste)
    {
        foreach (Etudiant e in liste)
        {
            //AfficherEtudiant(e);
            AfficherEtudiantSimple(e);
        }
    }

    // Procédure : ajoute une note à l'UV numéro i
    // Paramètres :
    //  - etudiant (Etudiant): étudiant à qui ajouter la note
    //  - note (double): note de l'UV / 20
    //  - numero_uv (int): numéro de l'UV
    // Retourne : rien, modification de l'Etudiant
    // Pré-conditions :
    //  - `i` doit être dans l'intervalle [0,`etudiant`._notes.Length]
    // Note : les `ref` indiquent de passer la structure par référence car par défaut les structures sont passées par copie
    // dans le cas contraire, c'est la copie de l'étudiant qui sera modifiée et non l'étudiant crée en dehors de la fonction !
    public static void AjouterNote(ref Etudiant etudiant, double note, int numero_uv)
    {
        // si la note vaut -1 alors elle n'était pas renseignée, 
        // on l'ajoute et on incrémente le nombre de notes
        if (etudiant._notes[numero_uv] == -1)
        {
            etudiant._notes[numero_uv] = note;
            etudiant._n += 1;
        }
        // sinon on remplace la note sans incrémenter le nombre de notes
        else
        {
            etudiant._notes[numero_uv] = note;
        }
        // mise à jour de la somme et de la moyenne
        double somme = CalculerSommeEtudiant(etudiant);
        double moyenne = CalculerMoyenneEtudiant(etudiant);
        etudiant._total = somme;
        etudiant._moyenne = moyenne;
    }

    // Fonction : calcule la somme des notes d'un étudiant en tenant compte du nombre de notes renseignées
    // Paramètres :
    //  - etudiant (Etudiant): l'étudiant à traiter
    // Retourne :
    //  - moyenne (double): la somme des notes de l'étudiant `etudiant`
    public static double CalculerSommeEtudiant(Etudiant etudiant)
    {
        double somme = 0.0;
        for (int i = 0; i < etudiant._notes.Length; i++)
        {
            // on ignore les notes non renseignées (égales à -1)
            if (etudiant._notes[i] >= 0)
            {
                somme += etudiant._notes[i];
            }
        }
        return somme;
    }
    
    // Fonction : calcule la moyenne d'un étudiant en tenant compte du nombre de notes renseignées
    // Paramètres :
    //  - etudiant (Etudiant): l'étudiant à traiter
    // Retourne :
    //  - moyenne (double): la moyenne de l'étudiant `etudiant`
    // Pré-conditions :
    //  - `etudiant`._n > 0 sinon erreur car division par 0
    public static double CalculerMoyenneEtudiant(Etudiant etudiant)
    {
        double somme = CalculerSommeEtudiant(etudiant);
        double moyenne =  somme / etudiant._n;
        return moyenne;
    }

    // Procédure : fabrique 5 étudiants factices
    // Paramètres : aucun
    // Retourne : 
    //  - etudiants (List<Etudiant>) : une liste de 5 étudiants
    public static List<Etudiant> FabriquerCinqEtudiants()
    {
        List<Etudiant> etudiants = new List<Etudiant>();
        // etudiant 1
        Etudiant e1 = new Etudiant(5, "Dupont", "Arthur");
        AjouterNote(ref e1, 8.5, 0);
        AjouterNote(ref e1, 9, 1);
        AjouterNote(ref e1, 5, 2);
        AjouterNote(ref e1, 12, 3);
        AjouterNote(ref e1, 15, 4);
        etudiants.Add(e1);

        // etudiant 2
        Etudiant e2 = new Etudiant(5, "Fontaine", "Simon");
        AjouterNote(ref e2, 12, 0);
        AjouterNote(ref e2, 15, 1);
        AjouterNote(ref e2, 15, 2);
        AjouterNote(ref e2, 18, 3);
        AjouterNote(ref e2, 17, 4);
        etudiants.Add(e2);

        // etudiant 3
        Etudiant e3 = new Etudiant(5, "Tremble", "Adolphe");
        AjouterNote(ref e3, 7, 0);
        AjouterNote(ref e3, 9, 1);
        AjouterNote(ref e3, 3, 2);
        AjouterNote(ref e3, 5, 3);
        AjouterNote(ref e3, 8, 4);
        etudiants.Add(e3);

        // etudiant 4
        Etudiant e4 = new Etudiant(5, "Bouchard", "Florence");
        AjouterNote(ref e4, 20, 0);
        AjouterNote(ref e4, 18, 1);
        AjouterNote(ref e4, 7, 2);
        AjouterNote(ref e4, 12, 3);
        AjouterNote(ref e4, 14, 4);
        etudiants.Add(e4);

        // etudiant 5
        Etudiant e5 = new Etudiant(5, "Martel", "Carine");
        AjouterNote(ref e5, 12, 0);
        AjouterNote(ref e5, 10, 1);
        AjouterNote(ref e5, 8, 2);
        AjouterNote(ref e5, 9, 3);
        AjouterNote(ref e5, 11, 4);
        etudiants.Add(e5);

        return etudiants;
    }

    // Procédure : fabrique un étudiant factice
    // Paramètres : aucun
    // Retourne : 
    //  - etudiants (Etudiant) : un nouvel étudiant
    public static Etudiant FabriquerUnEtudiantRattrapage()
    {
        Etudiant e = new Etudiant(5, "Gaby", "Valentine");
        AjouterNote(ref e, 8, 0);
        AjouterNote(ref e, 13.75, 1);
        AjouterNote(ref e, 6.75, 2);
        AjouterNote(ref e, 12, 3);
        AjouterNote(ref e, 11.5, 4);
        return e;
    }

    // Fonction : retourne la liste des étudiants ayant une moyenne supérieure à une moyenne donnée
    // Paramètres :
    //  - liste (List<Etudiant>): liste d'étudiants
    //  - moyenne (double): moyenne cible
    // Retourne :
    //  - sup (List<Etudiant>): sous-ensemble de `liste` ne contenant que les étudiants respectant la condition _moyenne >= `moyenne`
    public static List<Etudiant> ExtraireEtudiantsMoyenneSupN(List<Etudiant> liste, double moyenne)
    {
        List<Etudiant> sup = new List<Etudiant>();
        foreach (Etudiant e in liste)
        {
            if (e._moyenne >= moyenne)
            {
                sup.Add(e);
            }
        }
        return sup;
    }

    // Procédure : retourne la liste des étudiants triés par ordre décroissant de moyenne
    // Paramètres :
    //  - liste (List<Etudiant>): liste d'étudiants
    // Retourne :
    //  - trie (List<Etudiant>): liste `liste` par ordre décroissant de moyenne
    public static List<Etudiant> TrierListeParMoyennesDecroissantes(List<Etudiant> liste)
    {
        List<Etudiant> trie = new List<Etudiant>();
		// tri par insertion (TD7, exercice 7) adapté à la structure Etudiant
        // comparaison de deux Etudiant e1 et e2 signifie comparaison de leurs moyennes
		for (int indice_liste = 0; indice_liste < liste.Count; indice_liste++)
		{
			Etudiant valeur_a_inserer = liste[indice_liste];
			// recherche de l'indice d'insertion dans la liste triée et insertion
			int indice_insertion = 0;
			while (indice_insertion < trie.Count && trie[indice_insertion]._moyenne > valeur_a_inserer._moyenne)
			{
				indice_insertion += 1;
			}
			trie.Insert(indice_insertion, valeur_a_inserer);
		}
		return trie;
    }

    static void Main()
    {
        List<Etudiant> l = FabriquerCinqEtudiants();
        Console.WriteLine("5 étudiants : ");
        AfficherListeEtudiants(l);
        Console.WriteLine("------------------------------------------------");
        List<Etudiant> sup10 = ExtraireEtudiantsMoyenneSupN(l, 10);
        Console.WriteLine("Étudiants avec une moyenne supérieure à 10 :");
        AfficherListeEtudiants(sup10);
        Console.WriteLine("------------------------------------------------");
        List<Etudiant> trie = TrierListeParMoyennesDecroissantes(l);
        Console.WriteLine("Étudiants par ordre décroissant de moyennes :");
        AfficherListeEtudiants(trie);
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Étudiants par ordre décroissant de moyennes avec l'étudiant au rattrapage :");
        Etudiant rat = FabriquerUnEtudiantRattrapage();
        l.Add(rat);
        trie = TrierListeParMoyennesDecroissantes(l);
        AfficherListeEtudiants(trie);
        Console.WriteLine("------------------------------------------------");
    }
}