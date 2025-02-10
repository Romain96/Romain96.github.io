using System;

// Auteur : Romain PERRIN

// 1) structures Date et EtatCivil
public struct Date
{
	public uint annee;
	public uint mois;
	public uint jour;
};

public struct EtatCivil
{
	public string nomDeNaissance;
	public string nomDeFamille;
	public string prenom;
	public Date dateNaissance;
	public string lieuNaissance;
	public string prenomPere;
	public string prenomMere;
};

class ManipulationEtatCivil
{
	public static void Main()
	{
		// 2) générer un état civil
		// Préconditions : xPere =/= null, xMere =/= null, xDateNaissance =/= null
		// Entrée :	
		// - xPere : EtatCivil
		// 	- xMere : EtatCivil
		// 	- xPrenom : chaîne de caractères
		// 	- xDateNaissance : Date
		// 	- xLieuNaissance : chaîne de caractères
		// Local  :	/
		// Sortie :	
		//	- individu : EtatCivil
		EtatCivil xPere = new EtatCivil{
			nomDeNaissance = "Dupont",
			nomDeFamille = "Dupont",
			prenom  = "Joseph",
			dateNaissance = new Date{annee = 1945, mois = 10, jour = 5},
			lieuNaissance = "Paris",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil xMere = new EtatCivil{
			nomDeNaissance = "Martin",
			nomDeFamille = "Dupont",
			prenom = "Françoise",
			dateNaissance = new Date{annee = 1946, mois = 2, jour = 25},
			lieuNaissance = "Besançon",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		string xPrenom = "Albert";
		string xLieuNaissance = "Strasbourg";
		Date xDateNaissance = new Date{annee = 1975, mois = 12, jour = 12};
		EtatCivil xIndividu = new EtatCivil{
			nomDeNaissance = xPere.nomDeNaissance,
			nomDeFamille = xPere.nomDeFamille,
			prenom = xPrenom, 
			dateNaissance = xDateNaissance, 
			lieuNaissance = xLieuNaissance, 
			prenomPere = xPere.prenom, 
			prenomMere = xMere.prenom
		};

		// 3) Affichage d'un EtatCivil
		// Préconditions : xIndividu =/= null
		// Entrée :	
		//	- xIndividu : EtatCivil
		// Local  : /
		// Sortie : void
		Console.Write("-> EtatCivil : {0} {1} (nom de famille : {2}) ", xIndividu.prenom, xIndividu.nomDeNaissance, xIndividu.nomDeFamille);
		Console.WriteLine("né(e) le {0:D2}/{1:D2}/{2:D4} à {3}.", xIndividu.dateNaissance.jour, xIndividu.dateNaissance.mois, xIndividu.dateNaissance.annee, xIndividu.lieuNaissance);

		// génération des données pour la suite, c'est fastidieux sans fonction :(
		EtatCivil individu1 = new EtatCivil{
			nomDeNaissance = "Béranger", 
			nomDeFamille = "Béranger", 
			prenom = "Alfred", 
			dateNaissance = new Date{annee = 1939, mois = 9, jour = 12},
			lieuNaissance = "Ostwald",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil individu2 = new EtatCivil{
			nomDeNaissance = "Dupuy", 
			nomDeFamille = "Béranger", 
			prenom = "Valérie", 
			dateNaissance = new Date{annee = 1942, mois = 6, jour = 21},
			lieuNaissance = "Haguenau",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil individu3 = new EtatCivil{
			nomDeNaissance = "Béranger", 
			nomDeFamille = "Béranger", 
			prenom = "Charles", 
			dateNaissance = new Date{annee = 1964, mois = 2, jour = 1},
			lieuNaissance = "Ostwald",
			prenomPere = "Alfred",
			prenomMere = "Valérie"
		};
		EtatCivil individu4 = new EtatCivil{
			nomDeNaissance = "Bonhomme", 
			nomDeFamille = "Béranger", 
			prenom = "Aline", 
			dateNaissance = new Date{annee = 1965, mois = 9, jour = 8},
			lieuNaissance = "Illkirch",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil individu5 = new EtatCivil{
			nomDeNaissance = "Béranger", 
			nomDeFamille = "Béranger", 
			prenom = "Mathieu", 
			dateNaissance = new Date{annee = 1992, mois = 5, jour = 25},
			lieuNaissance = "Strasbourg",
			prenomPere = "Charles",
			prenomMere = "Aline"
		};
		EtatCivil individu6 = new EtatCivil{
			nomDeNaissance = "Béranger", 
			nomDeFamille = "Béranger", 
			prenom = "Pascale", 
			dateNaissance = new Date{annee = 1995, mois = 1, jour = 30},
			lieuNaissance = "Strasbourg",
			prenomPere = "Charles",
			prenomMere = "Aline"
		};
		EtatCivil individu7 = new EtatCivil{
			nomDeNaissance = "Duchamps", 
			nomDeFamille = "Duchamps", 
			prenom = "Paul", 
			dateNaissance = new Date{annee = 1963, mois = 4, jour = 3},
			lieuNaissance = "Mulhouse",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil individu8 = new EtatCivil{
			nomDeNaissance = "Chevalier", 
			nomDeFamille = "Duchamps", 
			prenom = "Isabelle", 
			dateNaissance = new Date{annee = 1966, mois = 11, jour = 11},
			lieuNaissance = "Altkirch",
			prenomPere = "\0",
			prenomMere = "\0"
		};
		EtatCivil individu9 = new EtatCivil{
			nomDeNaissance = "Duchamps", 
			nomDeFamille = "Duchamps", 
			prenom = "Marie", 
			dateNaissance = new Date{annee = 1994, mois = 5, jour = 12},
			lieuNaissance = "Mulhouse",
			prenomPere = "Paul",
			prenomMere = "Isabelle"
		};
		EtatCivil individu10 = new EtatCivil{
			nomDeNaissance = "Béranger", 
			nomDeFamille = "Béranger", 
			prenom = "Louis", 
			dateNaissance = new Date{annee = 2020, mois = 7, jour = 1},
			lieuNaissance = "Ostwald",
			prenomPere = "Mathieu",
			prenomMere = "Marie"
		};
		
		// stockage dans un tableau
		const int xTaille = 10;
		EtatCivil[] xIndividus = new EtatCivil[xTaille]{individu1, individu2, individu3, individu4, individu5, individu6, individu7, individu8, individu9, individu10};
		
		// 4) Affichage des états civils du tableau (sans fonction...)
		// Préconditions : cases du tableau =/= null
		// Principe : Parcourir le tableau et afficher le champs si l'EtatCivil n'est pas null
		// Entrée :
		// 	- xIndividus : tableau de xTaille EtatCivil
		// 	- xTaille : entier
		// Local  :
		// 	- i : entier
		// Sortie : void (affichage)
		for (int i = 0; i < xTaille; i++)
		{
			Console.Write("-> EtatCivil : {0} {1} (nom de famille : {2}) ", 
				xIndividus[i].prenom, xIndividus[i].nomDeNaissance, xIndividus[i].nomDeFamille
			);
			Console.WriteLine("né(e) le {0:D2}/{1:D2}/{2:D4} à {3}.", 
				xIndividus[i].dateNaissance.jour, xIndividus[i].dateNaissance.mois, 
				xIndividus[i].dateNaissance.annee, xIndividus[i].lieuNaissance
			);
		}

		// 5) Affichage des parents d'un individu
		// Principe : Si l'individu a des parents, parcourir le tableau et comparer les noms de famille avec l'individu et les prénoms avec ceux des champs de l'individu
		// Précontidions : individu =/= null
		// Entrée :
		// 	- xIndividus : tableau de xTaille EtatCivil
		// 	- xTaille : entier
		// 	- xIndividu : EtatCivil
		// Local  : /
		// Sortie : void (affichage)
		xIndividu = xIndividus[4]; // test avec Mathieu Béranger (parents : Charles Béranger et Aline Bonhomme)
		Console.WriteLine("-> Recherche des parents de {0} {1} :", xIndividu.prenom, xIndividu.nomDeNaissance);
		for (int i = 0; i < xTaille; i++)
		{
			if (xIndividus[i].nomDeFamille == xIndividu.nomDeNaissance)
			{
				if (xIndividus[i].prenom == xIndividu.prenomPere)
				{
					Console.WriteLine("-> -> {0} {1} est le père de {2} {3}.", 
						xIndividus[i].prenom, xIndividus[i].nomDeNaissance, xIndividu.prenom, xIndividu.nomDeNaissance
					);
				}
				else if (xIndividus[i].prenom == xIndividu.prenomMere)
				{
					Console.WriteLine("-> -> {0} {1} est la mère de {2} {3}.", 
						xIndividus[i].prenom, xIndividus[i].nomDeNaissance, xIndividu.prenom, xIndividu.nomDeNaissance
					);
				}
			}
		}
		
		// 6) Affichage des enfants d'un individu
		// Principe : Parcours des éléments du tableau, si l'individu a les champs prenomPere/prenomMere et nomDeFamille/nomDeFamille correspondant alors l'afficher
		// Précontidions : individu =/= null
		// Entrée :
		// 	- xIndividus : tableau de xTaille EtatCivil
		// 	- xTaille : entier
		// 	- xIndividu : EtatCivil
		// Local  : /
		// Sortie : void (affichage)
		xIndividu = xIndividus[3]; // test avec Aline Bonhomme (enfants : Mathieu Béranger et Pascale Béranger)
		Console.WriteLine("-> Recherche des enfants de {0} {1} :", xIndividu.prenom, xIndividu.nomDeNaissance);
		for (int i = 0; i < xTaille; i++)
		{
			// 2 cas possibles
			// Soit le nom du père est celui de l'enfant et le prénom du père correspond
			// Soit le nom marital de la mère est celui de l'enfant et le prénom de la mère correspond
			if (xIndividus[i].nomDeNaissance == xIndividu.nomDeNaissance && xIndividus[i].prenomPere == xIndividu.prenom)
			{
				Console.WriteLine("-> -> {0} {1} est l'enfant de {2} {3} (père).", 
					xIndividus[i].prenom, xIndividus[i].nomDeNaissance, xIndividu.prenom, xIndividu.nomDeNaissance
				);
			}
			else if (xIndividus[i].nomDeNaissance == xIndividu.nomDeFamille && xIndividus[i].prenomMere == xIndividu.prenom)
			{
				Console.WriteLine("-> -> {0} {1} est l'enfant de {2} {3} (mère).", 
					xIndividus[i].prenom, xIndividus[i].nomDeNaissance, xIndividu.prenom, xIndividu.nomDeNaissance
				);
			}
		}
	}
}
