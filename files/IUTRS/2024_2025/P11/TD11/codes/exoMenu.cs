// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ReseauxSociauxMenu
{
	// 1. Structure pour les réseaux sociaux
	public struct ReseauSocial
	{
		public string nom;	// nom du réseau social (Facebook, X, Téléphone...)
		public string relation;	// nature de la relation (contact, ami, follower, abonné...)

		// Constructeur
		public ReseauSocial(string nom, string relation)
		{
			this.nom = nom;
			this.relation = relation;
		}

		// affichage
		public override string ToString()
		{
			return $"ReseauSocial : nom = {nom}, relation = {relation}";
		}
	};

	// 1. Structure Date
	public struct Date
	{
		public int annee;
		public int mois;
		public int jour;

		// Constructeur
		public Date(int annee, int mois, int jour)
		{
			bool estBissextile = false;
			int nombreJoursDansMois = 31;
			this.annee = annee;
			this.mois = mois;
			this.jour = jour;
			if (annee < 0)
			{
				this.annee = 2000;
			}
			else
			{
				if ((annee % 4 == 0 && annee % 100 != 0) || annee % 400 == 0)
				{
					estBissextile = true;
				}
				if (mois < 1)
				{
					this.mois = 1;
				}
				else if (mois > 12)
				{
					this.mois = 12;
				}
				else
				{
					if (mois == 4 || mois == 6 || mois == 9 || mois == 11)
					{
						nombreJoursDansMois = 30;
					}
					else if (mois == 2)
					{
						if (estBissextile)
						{
							nombreJoursDansMois = 29;
						}
						else
						{
							nombreJoursDansMois = 28;
						}
					}
					if (jour < 1)
					{
						this.jour = 1;
					}
					else if (jour > nombreJoursDansMois)
					{
						this.jour = nombreJoursDansMois;
					}
				}
			}
		}

		// Affichage
		public override string ToString()
		{
			return $"{annee:D4}/{mois:D2}/{jour:D2}";
		}
	};

	// 2. Structure pour les relations
	public struct Relation
	{
		public string alias;	// nom ou alias
		public Date date;	// date de création
		public List<ReseauSocial> relations;	// liste des relations sous la forme (nom du réseau, type de relation)

		// Constructeur
		public Relation(string alias, Date date, List<ReseauSocial> relations)
		{
			this.alias = alias;
			this.date = date;
			this.relations = relations;
		}

		// Affichage
		public override string ToString()
		{
			string s = $"Relation : alias = {alias}, date = {date}\n\t";
			foreach (ReseauSocial rs in relations)
			{
				s += $"({rs.nom},{rs.relation}) ";
			}
			return s;
		}
	};

	// Procédure : AfficherRelations
	// Entrée :		- mesReseaux : liste de Relation
	// Local :		- r : Relation
	// Sortie :		void
	public static void AfficherRelations(List<Relation> mesRelations)
	{
		Console.WriteLine("Liste des relations :");
		foreach (Relation r in mesRelations)
		{
			Console.WriteLine(r);
		}
	}

	// Procédure : AjouterRelation
	// Entrée :		- mesRelations : liste de Relation (modifiable)
	//				- alias : chaîne de caractères
	//				- date : Date
	//				- rs : ReseauSocial
	// Local :		/
	// Sortie :		void
	public static void AjouterRelation(List<Relation> mesRelations, string alias, Date date, List<ReseauSocial> relations)
	{
		mesRelations.Add(new Relation(alias, date, relations));
	}

	// III.1.
	// Fonction : RechercherPersonnesEnRelation
	// Entrée :		- mesRelations : liste de Relation
	// Local :		- rel : Relation
	// Sortie :		- personnes : liste de chaînes de caractères
	public static List<string> RechercherPersonnesEnRelation(List<Relation> mesRelations)
	{
		List<string> personnes = new List<string>();
		foreach (Relation rel in mesRelations)
		{
			// si au moins une relation
			if (rel.relations.Count > 0)
			{
				// sans duplicata
				if (!personnes.Contains(rel.alias))
				{
					personnes.Add(rel.alias);
				}
			}
		}
		return personnes;
	}

	// III.2. (v1 : parcours des relations, v2 parcours des alias par appel à la fonction précédente)
	// Fonction : PersonneFairPartieDesRelations
	// Entrée :		- mesRelations : liste de Relation
	//				- alias : chaîne de caractères
	// Local :		- s : chaîne de caractères
	// Sortie :		- booléen
	public static bool PersonneFaitPartieDesRelations(List<Relation> mesRelations, string alias)
	{
		foreach (string s in RechercherPersonnesEnRelation(mesRelations))
		{
			if (s.Equals(alias))
			{
				return true;
			}
		}
		return false;
	}

	// III.3.
	// Fonction : RechercherListeReseauxSociauxPersonne
	// Note : retourne une exception si alias n'existe pas dans mesRelations
	// Entrée :		- mesRelations : liste de Relation
	//				- alias : chaîne de caractères
	// Local : 		- existe : booléen
	// Sortie :		- liste de ReseauSocial
	public static List<ReseauSocial> RechercherListeReseauxSociauxPersonne(List<Relation> mesRelations, string alias)
	{
		if (PersonneFaitPartieDesRelations(mesRelations, alias))
		{
			foreach (Relation rel in mesRelations)
			{
				// existe forcément car la fonction précédente retourne vrai
				if (rel.alias.Equals(alias))
				{
					return rel.relations;
				}
			}
		}
		throw new ArgumentException($"{alias} ne fait pas partie des relations !");
	}

	// III.4
	// Fonction : RechercherListePersonnesEnRelationParReseauSocial
	// Entrée :		- mesRelations : liste de Relation
	//				- rs : ReseauSocial
	// Local :		- rel : Relation
	// Sortie :		- personnes : liste de chaînes de caractères
	public static List<string> RechercherListePersonnesEnRelationParReseauSocial(List<Relation> mesRelations, ReseauSocial rs)
	{
		List<string> personnes = new List<string>();
		foreach (Relation rel in mesRelations)
		{
			// si le réseau social fait partie de la liste des types de relations
			if (rel.relations.Contains(rs))
			{
				// ajout si non duplicata
				if (!personnes.Contains(rel.alias))
				{
					personnes.Add(rel.alias);
				}
			}
		}
		return personnes;
	}

	// IV.1
	// Fonction : DateInferieure
	// Entrée :		- d1 : Date
	//				- d2 : Date
	// Local :		/
	// Sortie :		- booléen
	public static bool DateInferieure(Date d1, Date d2)
	{
		// comparaison des années
		if (d1.annee < d2.annee)
		{
			return true;
		}
		else if (d1.annee > d2.annee)
		{
			return false;
		}
		else
		{
			// comparaison des mois
			if (d1.mois < d2.mois)
			{
				return true;
			}
			else if (d1.mois > d2.mois)
			{
				return false;
			}
			else
			{
				// comparaison des jours
				if (d1.jour < d2.jour)
				{
					return true;
				}
				else if (d1.jour > d2.jour)
				{
					return false;
				}
				else
				{
					// identiques !
					return false;
				}
			}
		}
	}

	// Fonction : TrierParOrdreChronologique
	// Entrée :		- mesRelations : liste de Relation
	// Local :		- rel : Relation
	//				- i : entier
	// Sortie :		- mesRelationsTriees : liste de Relation (copie triée de mesRelations)
	public static List<Relation> TrierParOrdreChronologique(List<Relation> mesRelations)
	{
		List<Relation> mesRelationsTriees = new List<Relation>();
		// tri par insertion
		foreach (Relation rel in mesRelations)
		{
			int i = 0;
			while (i < mesRelationsTriees.Count && DateInferieure(mesRelationsTriees[i].date, rel.date))
			{
				i++;
			}
			if (i == mesRelationsTriees.Count)
			{
				mesRelationsTriees.Add(rel);
			}
			else
			{
				mesRelationsTriees.Insert(i, rel);
			}
		}
		return mesRelationsTriees;
	}

	// IV.2
	// Procédure : AjouterTypeDeRelation
	// Entrée :		- mesRelations : liste de Relation (modifiable)
	//				- mesReseaux : liste de ReseauSocial (modifiable)
	//				- alias : chaîne de caractères
	//				- relation : ReseauSocial
	// Local :		- rel : Relation
	// Sortie :		void
	public static void AjouterTypeDeRelation(List<Relation> mesRelations, List<ReseauSocial> mesReseaux, string alias, ReseauSocial rs)
	{
		if (PersonneFaitPartieDesRelations(mesRelations, alias))
		{
			foreach (Relation rel in mesRelations)
			{
				if (rel.alias.Equals(alias))
				{
					// ajout si ce type de relation n'existe pas déjà
					if (!rel.relations.Contains(rs))
					{
						rel.relations.Add(rs);
					}
					// ajout également à la liste des réseaux sociaux si non présent
					if (!mesReseaux.Contains(rs))
					{
						mesReseaux.Add(rs);
					}
					return;
				}
			}
		}
		else
		{
			throw new ArgumentException($"La personne {alias} ne fait pas partie de vos relations !");
		}
	}

	// IV.3
	// Procédure : SupprimerRelationsAUnReseauSocial
	// Entrée :		- mesRelations : liste de Relation (modifiable)
	//				- rs : ReseauSocial
	// Local :		- aSupprimer : liste de Relation
	//				- rel : Relation
	// Sortie :		void
	public static void SupprimerRelationsAUnReseauSocial(List<Relation> mesRelations, ReseauSocial rs)
	{
		List<Relation> aSupprimer = new List<Relation>();
		foreach (Relation rel in mesRelations)
		{
			if (rel.relations.Contains(rs))
			{
				rel.relations.Remove(rs);
				// à supprimer à posteriori
				if (rel.relations.Count == 0)
				{
					aSupprimer.Add(rel);
				}
			}
		}
		foreach (Relation rel in aSupprimer)
		{
			mesRelations.Remove(rel);
		}
	}

	// IV.4

	// Fonction : ReseauSocialExiste
	// Entrée :		- mesReseaux : liste de ReseauSocial
	//				- reseau : ReseauSocial
	// Local :		/
	// Sortie :		- booléen
	public static bool ReseauSocialExiste(List<ReseauSocial> mesReseaux, ReseauSocial reseau)
	{
		if (mesReseaux.Contains(reseau))
		{
			return true;
		}
		return false;
	}

	// Fonction : SupprimerReseauSocial
	// Entrée :		- mesReseaux : liste de ReseauSocial (modifiable)
	// Local :		/
	// Sortie :		void
	public static void SupprimerReseauSocial(List<ReseauSocial> mesReseaux, ReseauSocial rs)
	{
		if (ReseauSocialExiste(mesReseaux, rs))
		{
			mesReseaux.Remove(rs);
		}
		else
		{
			throw new ArgumentException($"Le réseau social {rs} n'existe pas dans la liste !");
		}
	}

	// V. 1
	// Procédure : SauvegarderMesReseaux
	// Entrée :		- mesReseaux : liste de ReseauSocial
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux d'écriture
	//				- rs : ReseauSocial
	// Sortie :		void
	public static void SauvegarderMesReseaux(List<ReseauSocial> mesReseaux, string chemin)
	{
		// ouverture
		StreamWriter writer = new StreamWriter(chemin);
		// écriture des données (1 ligne = un réseau social, séparateur ',')
		foreach (ReseauSocial rs in mesReseaux)
		{
			// nom = string et relation = string
			writer.WriteLine($"{rs.nom},{rs.relation}");
		}
		// fermeture
		writer.Close();
	}

	// Fonction : ChargerMesReseaux
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- reader : flux de lecture
	//				- line : chaîne de caractères
	// Sortie :		- mesReseaux : liste de ReseauSocial
	public static List<ReseauSocial> ChargerMesReseaux(string chemin)
	{
		List<ReseauSocial> mesReseaux = new List<ReseauSocial>();
		if (File.Exists(chemin))
		{
			// ouverture
			StreamReader reader = new StreamReader(chemin);
			// lecture ligne par ligne
			string ligne = "";
			while ((ligne = reader.ReadLine()) != null)
			{
				// nom,relation, séparateur ','
				string[] details = ligne.Split(',');
				ReseauSocial rs = new ReseauSocial(details[0], details[1]);
				mesReseaux.Add(rs);
			}
			// fermeture
			reader.Close();
		}
		return mesReseaux;
	}

	// V. 2
	// Procédure : SauvegarderMesRelations
	// Entrée :		- mesRelations : liste de Relation
	//				- chemin : chaîne de caractères
	// Local :		- writer : flux d'écriture
	//				- r : Relation
	// Sortie :		void
	public static void SauvegarderMesRelations(List<Relation> mesRelations, string chemin)
	{
		// ouverture
		StreamWriter writer = new StreamWriter(chemin);
		// écriture des données (1 ligne = une relation, séparateur ',')
		// le nombre de colonnes est variable !
		// dans l'ordre : alias, date (annee, mois, jour), nombre de relations , relations séparées par des ',' et en interne par des ';'
		foreach (Relation r in mesRelations)
		{
			// nom = string et relation = string
			writer.Write($"{r.alias},{r.date.annee},{r.date.mois},{r.date.jour},{r.relations.Count}");
			if (r.relations.Count > 0)
			{
				foreach (ReseauSocial rs in r.relations)
				{
					writer.Write($",{rs.nom};{rs.relation}");
				}
			}
			writer.Write("\n");
		}
		// fermeture
		writer.Close();
	}

	// Fonction : ChargerMesRelations
	// Entrée :		- chemin : chaîne de caractères
	// Local :		- reader : flux de lecture
	//				- line : chaîne de caractères
	// Sortie :		- mesRelations : liste de Relation
	public static List<Relation> ChargerMesRelations(string chemin)
	{
		List<Relation> mesRelations = new List<Relation>();
		if (File.Exists(chemin))
		{
			// ouverture
			StreamReader reader = new StreamReader(chemin);
			// lecture ligne par ligne
			string ligne = "";
			while ((ligne = reader.ReadLine()) != null)
			{
				// alias,annee,mois,jour,,nombre de relations, chaque relation séparée par des ',' et en interne par des ';'
				string[] details = ligne.Split(',');
				Date d = new Date(int.Parse(details[1]), int.Parse(details[2]), int.Parse(details[3]));
				int nRelations = int.Parse(details[4]);
				List<ReseauSocial> rss = new List<ReseauSocial>();
				if (nRelations > 0)
				{
					for (int i = 5; i < details.Length; i++)
					{
						string[] relDetails = details[i].Split(';');
						ReseauSocial rs = new ReseauSocial(relDetails[0], relDetails[1]);
						rss.Add(rs);
					}
				}
				Relation r = new Relation(details[0], d, rss);
				mesRelations.Add(r);
			}
			// fermeture
			reader.Close();
		}
		return mesRelations;
	}

	// Procédure : AfficherMenu
	// Entrée :		void
	// Local :		/
	// Sortie :		void
	public static void AfficherMenu()
	{
		Console.WriteLine("".PadRight(80, '-'));
		Console.WriteLine("MENU");
		Console.WriteLine("0 - Quitter");
		Console.WriteLine("1 - Charger les données (réseaux et relations)");
		Console.WriteLine("2 - Sauvegarder les données (réseaux et relations)");
		Console.WriteLine("3 - Afficher toutes les relations");
		Console.WriteLine("4 - Afficher la liste des personnes en relation");
		Console.WriteLine("5 - Ajouter une relation à une personne");
		Console.WriteLine("6 - Supprimer toutes les relations à un réseau social");
		Console.WriteLine("7 - Supprimer un réseau social");
		Console.WriteLine("8 - Trier les relations par ordre chronologique");
		Console.WriteLine("".PadRight(80, '-'));
	}

	public static void Main()
	{
		string cheminRelations = "mesRelations.txt";
		string cheminReseaux = "mesReseaux.txt";
		List<Relation> mesRelations = new List<Relation>();
		List<ReseauSocial> mesReseaux = new List<ReseauSocial>();

		// MENU
		bool quitter = false;
		while (!quitter)
		{
			AfficherMenu();

			int choix = -1;
			while (choix < 0 || choix > 8)
			{
				Console.Write("-> Choix (0-8) : ");
				choix = int.Parse(Console.ReadLine());	
			}
			switch (choix)
			{
				case 0: quitter = true; break;
				case 1:
					mesReseaux = ChargerMesReseaux(cheminReseaux);
					Console.WriteLine($"=> Chargement de {mesReseaux.Count} réseaux sociaux.");
					mesRelations = ChargerMesRelations(cheminRelations);
					Console.WriteLine($"=> Chargement de {mesRelations.Count} relations.");
					break;
				case 2:
					SauvegarderMesReseaux(mesReseaux, cheminReseaux);
					Console.WriteLine($"=> Sauvegarde de {mesReseaux.Count} réseaux sociaux.");
					SauvegarderMesRelations(mesRelations, cheminRelations);
					Console.WriteLine($"=> Sauvegarde de {mesRelations.Count} relations.");
					break;
				case 3:
					Console.WriteLine("=> Affichage des relations :");
					AfficherRelations(mesRelations);
					break;
				case 4:
					Console.WriteLine("=> Affichage des personnes en relation :");
					List<string> personnesEnRelation = RechercherPersonnesEnRelation(mesRelations);
					foreach(string pers in personnesEnRelation)
					{
						Console.WriteLine(pers);
					}
					break;
				case 5:
					Console.WriteLine("=> Ajout d'une relation à une personne : ");
					Console.Write("-> Alias de la personne : ");
					string personne = Console.ReadLine();
					Console.Write("-> Nom de la relation : ");
					string nomRelation = Console.ReadLine();
					Console.Write("-> Type de la relation : ");
					string typeRelation = Console.ReadLine();
					ReseauSocial rs = new ReseauSocial(nomRelation, typeRelation);
					if (!ReseauSocialExiste(mesReseaux, rs))
					{
						Console.WriteLine($"=> Attention : le réseau social {rs} n'existe pas dans la base de données, il sera ajouté!");
						mesReseaux.Add(rs);
					}
					try
					{
						Console.WriteLine($"=> Ajout du réseau social {rs} à l'alias {personne}.");
						AjouterTypeDeRelation(mesRelations, mesReseaux, personne, rs);
					}
					catch (ArgumentException)
					{
						Console.WriteLine($"=> Erreur : l'alias {personne} n'existe pas dans la base de données !");
					}
					break;
				case 6:
					Console.WriteLine("=> Suppression de toutes les relations par un réseau social : ");
					Console.Write("-> Nom du réseau social : ");
					string nomRelationSup = Console.ReadLine();
					Console.Write("-> Type de la relation : ");
					string typeRelationSup = Console.ReadLine();
					ReseauSocial rsSup = new ReseauSocial(nomRelationSup, typeRelationSup);
					Console.WriteLine($"=> Suppression de toutes les relations par un réseau social {rsSup}.");
					SupprimerRelationsAUnReseauSocial(mesRelations, rsSup);
					break;
				case 7:
					Console.WriteLine($"=> Suppression d'un réseau social :");
					Console.Write("-> Nom du réseau social : ");
					string nomRelationSup2 = Console.ReadLine();
					Console.Write("-> Type de la relation : ");
					string typeRelationSup2 = Console.ReadLine();
					ReseauSocial rsSup2 = new ReseauSocial(nomRelationSup2, typeRelationSup2);
					try
					{
						SupprimerReseauSocial(mesReseaux, rsSup2);
						// suppression des relation le concernant aussi
						Console.WriteLine($"=> Attention, le réseau social {rsSup2} existe dans la base de données, les relations le concernant seront également supprimées !");
						SupprimerRelationsAUnReseauSocial(mesRelations, rsSup2);
					}
					catch (ArgumentException)
					{
						Console.WriteLine($"=> Erreur : la suppression est impossible car le réseau social {rsSup2} n'est pas dans la base de données !");
					}
					break;
				case 8:
					Console.WriteLine("=> Tri des relations par ordre chronologique :");
					mesRelations = TrierParOrdreChronologique(mesRelations);
					foreach (Relation r in mesRelations)
					{
						Console.WriteLine(r);
					}
					break;
			}
		}
	}
}