// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Globalization;

class Exercice2
{
	// structure Etudiant
	public struct Etudiant
	{
		public string _nom;
		public string _prenom;
		public int _groupe;
		public float[] _notes;
		public int _nbNotes;
		public float _moyenne;

		// constructeur
		public Etudiant(string nom, string prenom, int groupe)
		{
			_nom = nom;
			_prenom = prenom;
			_groupe = groupe;
			_notes = new float[6];
			_nbNotes = 0;
			_moyenne = 0.0f;
		}

		// affichage
		public override string ToString()
		{
			string res = "Étudiant < nom : " + _nom + ", prénom : " + _prenom + ", groupe : " + _groupe + ", notes : [";
			for (int i = 0; i < _notes.Length - 1; i++)
			{
				res = res + _notes[i] + ",";
			}
			res = res + _notes[_notes.Length - 1] + "] (" + _nbNotes + " notes renseignées), moyenne : " + _moyenne + ">";
			return res;
		}
	};

	// Procédure : AjouterNote
	// Entrée :	- référence etu : Etudiant
	// 		- note : réel
	// Sotie :	void
	public static void AjouterNote(ref Etudiant etu, float note)
	{
		if (etu._nbNotes < etu._notes.Length)
		{
			// recalcul de la moyenne sur les nbNotes saisies
			etu._notes[etu._nbNotes++] = note;
			etu._moyenne = 0.0f;
			for (int i = 0; i < etu._nbNotes; i++)
			{
				etu._moyenne += etu._notes[i];
			}
			etu._moyenne = etu._moyenne / etu._nbNotes;
		}
	}

	// Fonction : LireEtudiants
	// Entrée :	- chemin : chaîne de caractères
	// Sortie :	tableau de structure Etudiant
	public static Etudiant[] LireEtudiants(string chemin)
	{
		Etudiant[] etudiants;

		string[] lignes = File.ReadAllLines(chemin);
		etudiants = new Etudiant[lignes.Length];
		int numEtu = 0;

		foreach (string ligne in lignes)
		{
			// nom; prenom; groupe; note1; ... note6
			string[] elements = ligne.Split(";");
			Etudiant etu = new Etudiant(elements[0], elements[1], int.Parse(elements[2]));
			for (int i = 0; i < 6; i++)
			{
				AjouterNote(ref etu, float.Parse(elements[i + 3], new CultureInfo("fr-FR").NumberFormat));
			}
			etudiants[numEtu] = etu;
			numEtu++;
		}
		return etudiants;
	}

	// Fonction : CalculerMoyennePromotion
	// Entrée :	- etudiants : tableau de structure Etudiant
	// Sortie :	réel
	public static float CalculerMoyennePromotion(Etudiant[] etudiants)
	{
		float moyenne = 0.0f;
		foreach (Etudiant etu in etudiants)
		{
			moyenne += etu._moyenne;
		}
		return moyenne / etudiants.Length;
	}

	// Procédure : AfficherMoyennesGroupes
	// Entrée :	- etudiants : tableau de structure Etudiant
	// Sortie :	void
	public static void AfficherMoyennesGroupes(Etudiant[] etudiants)
	{
		if (etudiants.Length < 1)
		{
			return;
		}
		int groupe = etudiants[0]._groupe;
		int numEtu = 0;
		float moyenne = 0.0f;
		foreach (Etudiant etu in etudiants)
		{
			// changement de groupe, calcul et affichage de la moyenne
			if (etu._groupe != groupe)
			{
				moyenne = moyenne / numEtu;
				Console.WriteLine($"La moyenne du groupe {groupe} est de {moyenne}");
				moyenne = etu._moyenne;
				numEtu = 1;
				groupe = etu._groupe;
			}
			else
			{
				moyenne += etu._moyenne;
				numEtu++;
			}
		}
		// cas pour le dernier groupe
		moyenne = moyenne / numEtu;
		Console.WriteLine($"La moyenne du groupe {groupe} est de {moyenne}");
	}

	// Procédure : AfficherMajorChaqueUE
	// Entrée :	- etudiants : tableau de structure Etudiant
	// Sortie :	void
	public static void AfficherMajorChaqueUE(Etudiant[] etudiants)
	{
		for (int ue = 0; ue < 6; ue++)
		{
			Etudiant major = etudiants[0];
			foreach (Etudiant etu in etudiants)
			{
				if (etu._notes[ue] > major._notes[ue])
				{
					major = etu;
				}
			}
			Console.WriteLine($"Major de l'UE n°{ue} : {major._prenom} {major._nom} ({major._groupe}) avec une moyenne de {major._notes[ue]}/20");
		}
	}

	// Procédure : AjouterEtudiantPromotion
	// Entrée :	- etudiant : structure Etudiant
	// 		- chemin : chaîne de caractères
	// Sortie :	void
	public static void AjouterEtudiantPromotion(Etudiant etu, string chemin)
	{
		if (File.Exists(chemin))
		{
			using (StreamWriter writer = File.AppendText(chemin))
			{
				// format : nom; prenom; groupe; note1; ... ;note6 (notes avec des ',' et non des '.')
				string ligne = $"\n{etu._nom};{etu._prenom};{etu._groupe};";
				for (int i = 0; i < 5; i++)
				{
					ligne = ligne + etu._notes[i].ToString().Replace(".", ",") + ";";
				}
				ligne = ligne + etu._notes[5].ToString().Replace(".", ",");
				writer.WriteLine(ligne);
			}
		}
	}

	public static void Main()
	{
		string chemin = "Promotion.csv";
		string chemin2 = "PromotionCopie.csv";
		if (File.Exists(chemin))
		{
			Etudiant[] etudiants = LireEtudiants(chemin);
			for (int i = 0; i < etudiants.Length; i++)
			{
				Console.WriteLine(etudiants[i]);
			}
			Console.WriteLine($"La moyenne de la promotion est de {CalculerMoyennePromotion(etudiants)}");
			AfficherMoyennesGroupes(etudiants);
			AfficherMajorChaqueUE(etudiants);
			Etudiant albert = new Etudiant("Einstein", "Albert", 3);
			AjouterNote(ref albert, 10.0f);
			AjouterNote(ref albert, 15.0f);
			AjouterNote(ref albert, 7.5f);
			AjouterNote(ref albert, 7.5f);
			AjouterNote(ref albert, 13.25f);
			AjouterNote(ref albert, 18.0f);
			AjouterEtudiantPromotion(albert, chemin2);
		}
	}
}
