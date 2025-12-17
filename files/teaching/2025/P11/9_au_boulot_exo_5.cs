// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Exercice5
{
	// structure : Candidat
	public struct Candidat
	{
		public string _nom;
		public string _prenom;
		public string _pseudo;
		
		// Constructeur
		public Candidat(string nom, string prenom, string pseudo)
		{
			_nom = nom;
			_prenom = prenom;
			_pseudo = pseudo;
		}
		
		// Affichage
		public override string ToString()
		{
			return "Candidat { nom : " + _nom + ", prénom : " + _prenom + ", pseudo : " + _pseudo + " }";
		}
	};
	
	
	// Procédure : SaisirCandidat
	// Entrée :	- c : référence sur un Candidat
	// Sortie :	void
	public static void SaisirCandidat(ref Candidat c)
	{
		string nom, prenom, pseudo;
		
		do
		{
			Console.Write("Saisir le nom : ");
			nom = Console.ReadLine();
		}
		while (nom.Length < 1);
		
		do
		{
			Console.Write("Saisir le prénom : ");
			prenom = Console.ReadLine();
		}
		while (prenom.Length < 1);
		
		do
		{
			Console.Write("Saisir le pseudo : ");
			pseudo = Console.ReadLine();
		}
		while (pseudo.Length < 1);
		
		c = new Candidat(nom, prenom, pseudo);
	}
	
	
	// Procédure : LireParoles
	// Entrée :	- chemin : chaîne de caractères (chemin vers un fichier)
	// 			- paroles : référence sur une Liste<chaîne de caractères>
	// Sortie :	void
	public static void LireParoles(string chemin, ref List<string> paroles)
	{
		paroles = new List<string>();
		
		if (File.Exists(chemin))
		{
			FileStream fs = new FileStream(chemin, FileMode.Open);
			StreamReader reader = new StreamReader(fs);
			
			string ligne;
			while ((ligne = reader.ReadLine()) != null)
			{
				paroles.Add(ligne);
			}
			
			reader.Close();
		}
	}
	
	
	// structure Reponse
	public struct Reponse
	{
		public int _indice;	// indice des paroles dans la liste des paroles (lien entre les paroles et les réponses)
		public string _modif;	// chaîne modifiée
		public string _paroles;	// bonnes paroles à la place de _modif
		public string _titre;	// titre de l'oeuvre
		public string _artiste;	// nom de l'artiste original
		
		// Constructeur
		public Reponse(int indice, string modif, string paroles, string titre, string artiste)
		{
			_indice = indice;
			_modif = modif;
			_paroles = paroles;
			_titre = titre;
			_artiste = artiste;
		}
		
		// Affichage
		public override string ToString()
		{
			return "Reponse { indice : " + _indice + ", modif : " + _modif + ", paroles : " + _paroles + ", titre : " + _titre + ",  artiste : " + _artiste + " }";
		}
	};
	
	
	// Fonction : LireReponses
	// Entrée :	- chemin : chaîne de caractères (chemin vers un fichier)
	//			- paroles : Liste<chaîne de caractères> (liste des paroles à associer)
	//			- reponses : référence sur un Dictionnaire<entier, Reponse>
	public static void LireReponses(string chemin, List<string> paroles, ref Dictionary<int, Reponse> reponses)
	{
		reponses = new Dictionary<int, Reponse>();
		FileStream fs = new FileStream(chemin, FileMode.Open);
		StreamReader reader = new StreamReader(fs);
		
		int indice = 0;
		string ligne;
		while ((ligne = reader.ReadLine()) != null)
		{
			string[] elts = ligne.Split(";");
			Reponse rep = new Reponse(indice, elts[0], elts[1], elts[2], elts[3]);
			reponses.Add(indice, rep);
			indice++;
		}
		
		reader.Close();
	}
	

	public static void Main()
	{
		const string cheminInput = "exo_5_input";
		const string cheminParoles = "parolesKaraPasOk.txt";
		const string cheminReponses = "bonnesReponses.txt";
		
		// créer un candidat et initialiser son score à 0
		Candidat c = new Candidat();
		SaisirCandidat(ref c);
		int score = 0;
		
		// charger les paroles du KaraPasOK
		List<string> paroles = new List<string>();
		LireParoles(cheminInput + "/" + cheminParoles, ref paroles);
		
		// charger et associer les bonnes réponses aux paroles
		Dictionary<int, Reponse> reponses = new Dictionary<int, Reponse>();
		LireReponses(cheminInput + "/" + cheminReponses, paroles, ref reponses);
		
		const int nbQuestions = 5;
		Random gen = new Random();
		
		for (int indiceQuestion = 0; indiceQuestion < nbQuestions; indiceQuestion++)
		{
			// tirer au sort une question
			int i = gen.Next(0, paroles.Count);
			Console.WriteLine("Tour n°" + (indiceQuestion + 1) + "/" + nbQuestions + " voici les paroles :");
			Console.WriteLine(">> " + paroles[i]);
			
			// demander le mot à remplacer
			string motARemplacer = "";
			do
			{
				Console.Write("Saisir le mot à remplacer : ");
				motARemplacer = Console.ReadLine();
			}
			while (motARemplacer.Length < 1);
			
			// demander la chaîne de remplacement
			string motRemplace = "";
			do
			{
				Console.Write("Saisir la chaîne originale : ");
				motRemplace = Console.ReadLine();
			}
			while (motRemplace.Length < 1);
			
			// demander le titre et l'artiste
			string titre = "";
			string artiste = "";
			do
			{
				Console.Write("Saisir le titre de l'oeuvre originale : ");
				titre = Console.ReadLine();
			}
			while (titre.Length < 1);
			do
			{
				Console.Write("Saisir l'artiste de l'oeuvre originale : ");
				artiste = Console.ReadLine();
			}
			while (artiste.Length < 1);
			
			// maj du score
			if (motARemplacer == reponses[i]._modif && motRemplace == reponses[i]._paroles)
			{
				Console.WriteLine("--> paroles correctes ! +2 pts");
				score += 2;
			}
			if (titre == reponses[i]._titre)
			{
				Console.WriteLine("--> titre correct ! +5 pts");
				score += 5;
			}
			if (artiste == reponses[i]._artiste)
			{
				Console.WriteLine("--> artiste correct ! +10 pts");
				score += 10;
			}
		}
		
		Console.WriteLine("Partie terminée !");
		Console.WriteLine("Score de " + c._prenom + " " + c._nom + " aka " + c._pseudo + " : " + score);
	}
}
