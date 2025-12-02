// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
{
	// Structure : Patient
	public struct Patient
	{
		public string _nom;
		public string _prenom;
		public string _heureArrivee;
		public int _code;
		
		// Constructeur
		public Patient(string nom, string prenom, string heureArrivee, int code)
		{
			_nom = nom;
			_prenom = prenom;
			_heureArrivee = heureArrivee;
			_code = code;
		}
		
		// Affichage
		public override string ToString()
		{
			return "Patient { " + _nom + " " + _prenom + " arrivé(e) à " + _heureArrivee + " (code : " + _code + ") }";
		}
	};
	
	
	// Procédure : AfficherMenu
	// Entrée :	void
	// Sortie :	void
	public static void AfficherMenu()
	{
		Console.WriteLine("Menu");
		Console.WriteLine("----------");
		Console.WriteLine("1 - Accueillir un patient");
		Console.WriteLine("2 - Appeler un patient");
		Console.WriteLine("3 - Retirer un patient");
		Console.WriteLine("4 - Afficher la liste des patient");
		Console.WriteLine("5 - Quitter");
	}
	
	
	// Procédure : AfficherPatients
	// Entrée :	- patients : ListeChaînée<Patient>
	// Sortie :	void
	public static void AfficherPatients(LinkedList<Patient> patients)
	{
		foreach (Patient patient in patients)
		{
			Console.WriteLine(patient);	// utilise le ToString défini dans la structure Patient :)
		}
	}
	
	
	// Procédure : InsererPatient
	// Entrée :	- patients : ListeChaînée<chaîne de caractères>
	//			- patient : Patient
	// Sortie :	void
	public static void InsererPatient(LinkedList<Patient> patients, Patient patient)
	{
		// recherche du code, ajout en fin de peloton (dernier des 1 si un 1, dernier des 2 si 2 et dernier des 3 si 3)
		// ou bien en tête de peloton si seul représentant de son indice
		
		// cas simple : liste vide, ajout en tête
		if (patients.Count == 0)
		{
			patients.AddFirst(patient);
		}
		// sinon recherche
		else
		{
			LinkedListNode<Patient> noeud = patients.First;
			bool recherche = true;
			
			while (noeud != null && recherche)
			{
				// si code plus grand alors insertion avant
				if (noeud.Value._code > patient._code)
				{
					patients.AddBefore(noeud, patient);
					recherche = false;
				}
				// si code identique ou plus petit alors on avance jusqu'à la fin du peloton
				else
				{
					noeud = noeud.Next;
				}
			}
			
			// attention : si le noeud est le dernier code (le plus grand) et seul représentant
			// alors on quitte la boucle au-dessus sans l'insertion, il faut donc insérer en fin de liste
			if (recherche)
			{
				patients.AddLast(patient);
			}
		}
	}
	
	
	// Fonction : AppelerPatient
	// Entrée :	- patients : ListeChaînée<Patient>
	// Sortie :	Patient (nullable)
	public static Patient? AppelerPatient(LinkedList<Patient> patients)
	{
		Patient? res = null;
		
		if (patients.Count > 0)
		{
			res = patients.First.Value;
			patients.RemoveFirst();
		}
		
		return res;
	}
	
	
	// Procédure : RetirerPatient
	// Entrée :	- patients : ListeChaînée<Patient>
	// 			- nom : chaîne de caractères 
	// 			- prenom : chaîne de caractères 
	// Sortie :	void
	public static void RetirerPatient(LinkedList<Patient> patients, string nom, string prenom)
	{
		LinkedListNode<Patient> noeud = patients.First;
		bool rechercher = true;
		
		while (noeud != null && rechercher)
		{
			if (noeud.Value._nom == nom && noeud.Value._prenom == prenom)
			{
				patients.Remove(noeud);
				rechercher = false;
			}
			else
			{
				noeud = noeud.Next;
			}
		}
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		LinkedList<Patient> patients = new LinkedList<Patient>();
		bool menu = true;
		string saisie = "";
		int choix = -1;
		
		while (menu)
		{
			do
			{
				do
				{
					AfficherMenu();
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 0);
				choix = int.Parse(saisie);
			}
			while (choix < 1 || choix > 5);
			
			switch (choix)
			{
				// insérer un patient
				case 1:
					string nomAjouter = "";
					string prenomAjouter = "";
					string saisieCode = "";
					int code = -1;
					do
					{
						Console.Write("Saisir le nom du patient à accueillir : ");
						nomAjouter = Console.ReadLine();
					}
					while (nomAjouter.Length < 1);
					
					do
					{
						Console.Write("Saisir le prénom du patient à accueillir : ");
						prenomAjouter = Console.ReadLine();
					}
					while (prenomAjouter.Length < 1);
					
					do
					{
						do
						{
							Console.Write("Saisir le code (1, 2, ou 3) : ");
							saisieCode = Console.ReadLine();
						}
						while (saisieCode.Length < 1);
						code = int.Parse(saisieCode);
					}
					while (code < 1 || code > 3);
					Patient patientInserer = new Patient(nomAjouter, prenomAjouter, DateTime.Now.ToString(), code);	// nouveau patient
					InsererPatient(patients, patientInserer);
					break;
				
				// afficher le patient en tête de liste et le retirer
				case 2:
					Patient? prochain = AppelerPatient(patients);
					if (prochain.HasValue)
					{
						Console.WriteLine("On appelle le patient " + prochain.Value);
					}
					else
					{
						Console.WriteLine("Il n'y a aucun patient dans la salle d'attente !");
					}
					break;
				
				// retirer un patient
				case 3:
					string nomRetirer = "";
					string prenomRetirer = "";
					do
					{
						Console.Write("Saisir le nom du patient à retirer : ");
						nomRetirer = Console.ReadLine();
					}
					while (nomRetirer.Length < 1);
					
					do
					{
						Console.Write("Saisir le prénom du patient à retirer : ");
						prenomRetirer = Console.ReadLine();
					}
					while (prenomRetirer.Length < 1);
					
					RetirerPatient(patients, nomRetirer, prenomRetirer);
					break;
				
				// Afficher la liste des patients
				case 4:
					AfficherPatients(patients);
					break;
					
				// Quitter
				default:
					menu = false; 
					break;
			}
			
		}
	}
}
