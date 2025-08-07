// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ReseauxSociaux
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
				this.annee = 0;
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
	// Fonction : PersonneFaitPartieDesRelations
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
	// Local :		- rel : structure Relation
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

	public static void Main()
	{
		// 3. liste des réseaux et affichage
		List<ReseauSocial> mesReseaux = new List<ReseauSocial> {
			new ReseauSocial("Facebook", "Ami"), 
			new ReseauSocial("X", "Follower"), 
			new ReseauSocial("Téléphone", "Contact"), 
			new ReseauSocial("Youtube", "Abonné")
		};

		// 4. liste des relations et affichage
		List<Relation> mesRelations = new List<Relation> {
			new Relation("Gérard_Menvussat", new Date(2023, 10, 1), new List<ReseauSocial> {mesReseaux[0], mesReseaux[2]}),
			new Relation("Alain*Provist", new Date(2022, 12, 24), new List<ReseauSocial> {mesReseaux[0], mesReseaux[1], mesReseaux[3]}),
			new Relation("Aline___Éha", new Date(2024, 8, 14), new List<ReseauSocial> {mesReseaux[0], mesReseaux[3]})
		};

		// 5. affichage des relations
		AfficherRelations(mesRelations);

		// 6. Ajouter des relations à la liste des relations
		int n = mesRelations.Count;
		while (n < 7)
		{
			// saisir l'alias
			Console.Write("\n\nSaisir une nouvelle relation.\nEntrer l'alias : ");
			string alias = Console.ReadLine();
			// saisir la date
			string dateTexte = "";
			string[] dateChamps = dateTexte.Split('/');
			while (dateChamps.Length != 3)
			{
				Console.Write("Saisir la date au format AAAA/MM/JJ : ");
				dateTexte = Console.ReadLine();
				dateChamps = dateTexte.Split('/');
			}
			Date d = new Date(int.Parse(dateChamps[0]), int.Parse(dateChamps[1]), int.Parse(dateChamps[2]));
			// saisir le réseau social
			Console.WriteLine("Liste des réseaux sociaux :");
			for (int i = 0; i < mesReseaux.Count; i++)
			{
				Console.WriteLine($"{i+1} - {mesReseaux[i]}");
			}
			int r = -1;
			bool quitter = false;
			List<ReseauSocial> lrs = new List<ReseauSocial>();
			while (!quitter)
			{
				Console.WriteLine($"Saisir le réseau social à ajouter 1-{mesReseaux.Count} (0 pour quitter)");
				r = int.Parse(Console.ReadLine());
				if (r >= 1 && r <= mesReseaux.Count)
				{
					if (!lrs.Contains(mesReseaux[r-1]))
					{
						lrs.Add(mesReseaux[r-1]);
					}
				}
				else if (r == 0)
				{
					quitter = true;
				}
			}
			// ajout de la nouvelle relation
			AjouterRelation(mesRelations, alias, d, lrs);
			n++;
		}
		AfficherRelations(mesRelations);

		// III. 1 - afficher la liste des personnes en relation
		List<string> personnesRel = RechercherPersonnesEnRelation(mesRelations);
		Console.WriteLine("\n\nListe des personnes en relation :");
		foreach (string s in personnesRel)
		{
			Console.Write($"{s} ");
		}
		Console.Write("\n");

		// III. 2. - recherche de personnes parmi les relations
		Console.WriteLine($"\n\nGérard_Menvussat fait partie de vos relations : {PersonneFaitPartieDesRelations(mesRelations, "Gérard_Menvussat")}");
		Console.WriteLine($"L'inconnu fait partie de vos relations : {PersonneFaitPartieDesRelations(mesRelations, "L'inconnu")}");

		// III. 3 - rechercher la liste des RS d'une relation (existante ou non => exception)
		try
		{
			List<ReseauSocial> rsGerard = RechercherListeReseauxSociauxPersonne(mesRelations, "Gérard_Menvussat");
		}
		catch (ArgumentException)
		{
			Console.WriteLine($"La personne \"Gérard_Menvussat\" ne fait pas partie de vos relations !");
		}
		try
		{
			List<ReseauSocial> rsInconnu = RechercherListeReseauxSociauxPersonne(mesRelations, "L'inconnu");
		}
		catch (ArgumentException)
		{
			Console.WriteLine($"La personne \"L'iconnu\" ne fait pas partie de vos relations !");
		}

		// III. 4 - rechercher la liste des relations (personnes) à partir d'un réseau social
		List<string> relRSGerard = RechercherListePersonnesEnRelationParReseauSocial(mesRelations, mesReseaux[0]);
		Console.WriteLine($"\n\nListe des personnes en relation avec vous par le réseau {mesReseaux[0]} :");
		foreach (string s in relRSGerard)
		{
			Console.Write($"{s} ");
		}
		Console.Write("\n");

		// IV. 1. - tri chronologique
		List<Relation> mesRelationsTriees = TrierParOrdreChronologique(mesRelations);
		Console.WriteLine("\n\nTri chronologique des relations :");
		foreach(Relation rel in mesRelationsTriees)
		{
			Console.WriteLine(rel);
		}

		// IV. 2. - ajout d'une relation
		Console.WriteLine("\n\nAjout d'une relation à Gérard_Menvussat : ");
		AjouterTypeDeRelation(mesRelationsTriees, mesReseaux, "Gérard_Menvussat", mesReseaux[1]);
		AfficherRelations(mesRelations);

		Console.WriteLine("\n\nAjout d'une relation (nouvelle) à Gérard_Menvussat : ");
		AjouterTypeDeRelation(mesRelationsTriees, mesReseaux, "Gérard_Menvussat", new ReseauSocial("X selon l'Académie Française", "Acolyte des illustres"));
		AfficherRelations(mesRelations);

		// IV. 3. - suppression d'une relation (réseau social)
		Console.WriteLine($"\n\nSuppression des relations par le réseau social {mesReseaux[0]} : ");
		SupprimerRelationsAUnReseauSocial(mesRelationsTriees, mesReseaux[0]);
		AfficherRelations(mesRelationsTriees);
		
		Console.WriteLine($"\n\nSuppression des relations par le réseau social {mesReseaux[3]} : ");
		SupprimerRelationsAUnReseauSocial(mesRelationsTriees, mesReseaux[3]);
		AfficherRelations(mesRelationsTriees);

		// IV. 4. - suppression du réseau social mesReseaux[3] de la liste
		Console.WriteLine($"\n\nSuppression du réseau social {mesReseaux[3]} :");
		try
		{
			SupprimerReseauSocial(mesReseaux, mesReseaux[3]);	// existe
		}
		catch (ArgumentException)
		{
			Console.WriteLine("Suppression impossible car l'élément n'est pas dans la liste !");
		}
		foreach (ReseauSocial rs in mesReseaux)
		{
			Console.WriteLine(rs);
		}

		Console.WriteLine($"\n\nSuppression du réseau social {new ReseauSocial("Mastodon", "Suiveur à distance")} :");
		try
		{
			SupprimerReseauSocial(mesReseaux, new ReseauSocial("Mastodon", "Suiveur à distance"));	// n'existe pas
		}
		catch (ArgumentException)
		{
			Console.WriteLine("Suppression impossible car l'élément n'est pas dans la liste !");
		}
		foreach (ReseauSocial rs in mesReseaux)
		{
			Console.WriteLine(rs);
		}

		// V. 1. - sauvegarde des réseaux
		string cheminReseaux = "mesReseaux.txt";
		Console.WriteLine($"\n\nSauvegarde des réseaux sociaux dans {cheminReseaux}.");
		SauvegarderMesReseaux(mesReseaux, cheminReseaux);

		// V. 2 - sauvegarde des relations
		string cheminRelations = "mesRelations.txt";
		Console.WriteLine($"\n\nSauvegarde des relations dans {cheminRelations}.");
		SauvegarderMesRelations(mesRelations, cheminRelations);

		// test de chargement des réseaux
		Console.WriteLine($"\n\nChargement des réseaux depuis {cheminReseaux}");
		List<ReseauSocial> mesReseaux2 = ChargerMesReseaux(cheminReseaux);
		foreach (ReseauSocial rs in mesReseaux2)
		{
			Console.WriteLine(rs);
		}

		// test de chargement des relations
		Console.WriteLine($"\n\nChargement des relations depuis {cheminRelations}");
		List<Relation> mesRelations2 = ChargerMesRelations(cheminRelations);
		foreach (Relation r in mesRelations2)
		{
			Console.WriteLine(r);
		}
	}
}