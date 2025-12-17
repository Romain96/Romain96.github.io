// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Exercice4
{
	// Fonction : LireFichier
	// Entrée :	- chemin : chaîne de caractère
	// Sortie :	tableau 1D de chaînes de caractères
	public static string[] LireFichier(string chemin)
	{
		string[] contenu = new string[0];
		Console.WriteLine("chargement de " + chemin);
		
		if (File.Exists(chemin))
		{
			contenu = File.ReadAllLines(chemin);
		}
		return contenu;
	}
	
	
	// Procédure : EcrireFichier
	// Entrée :	- dir : chaîne de caractères (répertoire de sauvegarde)
	//			- file : chaîne de caractères (fichier de sauvegarde)
	//			- texte : chaîne de caractères
	// Sortie :	void
	public static void EcrireFichier(string dir, string file, string[] texte)
	{
		string chemin = dir + "/" + file;
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		File.WriteAllLines(chemin, texte, Encoding.UTF8);
	}
	
	
	// Procédure : EcrireFichierComplet
	// Entrée :	- dir : chaîne de caractères (répertoire de sauvegarde)
	//			- file : chaîne de caractères (fichier de sauvegarde)
	//			- texte : Liste<chaîne de caractères>
	// Sortie :	void
	public static void EcrireFichierComplet(string dir, string file, List<string> texte)
	{
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		
		string chemin = dir + "/" + file;
		FileStream fs = new FileStream(chemin, FileMode.Create);
		StreamWriter writer = new StreamWriter(fs);
		
		foreach (string ligne in texte)
		{
			writer.WriteLine(ligne);
		}
		
		writer.Close();
	}
	
	
	// structure Fichier
	public struct Fichier
	{
		public int _id;
		public string[] _contenu;
		
		// Constructeur
		public Fichier(int id, string[] contenu)
		{
			_id = id;
			_contenu = contenu;
		}
	};
	
	
	// Fonction : OrdonnerFichiers
	// Entrée :	- fichiers : Liste<Fichier>
	// Sortie :	Liste<Fichier>
	public static List<Fichier> OrdonnerFichiers(List<Fichier> fichiers)
	{
		List<Fichier> fichiersOrdonnes = new List<Fichier>();
		
		// étape 1 : chercher le fichier n°1 (celui dont la première ligne n'est la dernière ligne d'aucun autre)
		int idPremier = -1;
		
		bool rechercherPremier = true;
		for (int i = 0; i < fichiers.Count && rechercherPremier; i++)
		{
			bool estPremier = true;
			for (int j = 0; j < fichiers.Count && estPremier; j++)
			{
				if (i != j && fichiers[i]._contenu[0] == fichiers[j]._contenu[fichiers[j]._contenu.Length - 1])
				{
					estPremier = false;
				}
			}
			if (estPremier)
			{
				idPremier = i;
				rechercherPremier = false;
			}
		}
		fichiersOrdonnes.Add(fichiers[idPremier]);
		fichiers.RemoveAt(idPremier);
		
		// étape 2 : pour les autres fichiers restants, rechercher itérativement celui dont la première ligne est la dernière du fichier précédent (déjà ordonné)
		while (fichiers.Count > 0)
		{
			// rechercher le fichier dans fichiers dont la première ligne est la dernière du dernier ficheir de fichiersOrdonnes
			bool trouve = false;
			for (int i = 0; i < fichiers.Count && !trouve; i++)
			{
				if (fichiers[i]._contenu[0] == fichiersOrdonnes[fichiersOrdonnes.Count - 1]._contenu[fichiersOrdonnes[fichiersOrdonnes.Count - 1]._contenu.Length - 1])
				{
					trouve = true;
					fichiersOrdonnes.Add(fichiers[i]);
					fichiers.RemoveAt(i);
				}
			}
		}
		
		return fichiersOrdonnes;
	}
	
	
	// Fonction : FusionnerTextes
	// Entrée :	- textes : Liste<Fichier>
	// Sortie :	Liste<chaînes de caractères>
	public static List<string> FusionnerTextes(List<Fichier> textes)
	{
		List<string> texteComplet = new List<string>();
		
		for (int i = 0; i < textes.Count; i++)
		{
			Fichier texte = textes[i];
			foreach (string ligne in texte._contenu)
			{
				texteComplet.Add(ligne);
			}
			
			// suppression de la dernière ligne (commune avec le prochain fichier) pour tous les fichiers sauf le dernier
			if (i < textes.Count - 1)
			{
				texteComplet.RemoveAt(texteComplet.Count - 1);
			}
		}
		
		return texteComplet;
	}
	
	
	// Procédure : LireLigneParLigne
	// Entrée :	- texte : Liste<chaîne de caractères>
	// Sortie :	void
	public static void LireLigneParLigne(List<string> texte)
	{
		foreach (string ligne in texte)
		{
			Console.WriteLine("> " + ligne);
			Console.Write("Appuyer sur entrée pour passer à la ligne suivante...");
			Console.ReadLine();
		}
	}
	

	public static void Main()
	{
		const string cheminInput = "exo_4_input";	// chemin vers le répertoire contenant les fichier à lire
		const string cheminOutput = "exo_4_output";	// chemin vers le répertoire où les fichiers générés seront sauvegardés
		const string radical = "petitPrinceMorceau";	// pour l'écriture
		// liste des fichiers à charger depuis cheminInput
		List<string> cheminsFichiers = new List<string>() {
			"petitPrinceMorceau1", 
			"petitPrinceMorceau2", 
			"petitPrinceMorceau3", 
			"petitPrinceMorceau4"
		};
		
		// charger les fichiers
		List<Fichier> fichiers = new List<Fichier>();
		int id = 0;
		foreach (string chemin in cheminsFichiers)
		{
			string cheminComplet = cheminInput + "/" + chemin + ".txt";
			string[] contenuFichier = LireFichier(cheminComplet);
			if (contenuFichier.Length > 0)
			{
				Fichier f = new Fichier(id, contenuFichier);
				fichiers.Add(f);
				id++;
			}
		}
		
		// trier les fichiers
		List<Fichier> fichiersTries = OrdonnerFichiers(fichiers);
		
		// écrire les fichiers dans l'ordre chronologique
		int indice = 1;
		foreach (Fichier f in fichiersTries)
		{
			EcrireFichier(cheminOutput, radical + indice + ".txt", f._contenu);
			indice++;
		}
		
		// fusionner les fichiers et écrire un fichier complet
		List<string> texte = FusionnerTextes(fichiersTries);
		EcrireFichierComplet(cheminOutput,  radical + ".txt", texte);
		
		// lire le fichier
		LireLigneParLigne(texte);
	}
}
