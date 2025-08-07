// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class Pokemons
{
	public struct Pokemon
	{
		public string nom;
		public int niveau;
		public int attaque;
		public int defense;
		public int pointsDeVie;

		// constructeur paramétré
		public Pokemon(string nom, int niveau, int attaque, int defense, int pointsDeVie)
		{
			this.nom = nom;
			this.niveau = niveau;
			this.attaque = attaque;
			this.defense = defense;
			this.pointsDeVie = pointsDeVie;
		}
	};

	public static void LirePokemons(string repertoire, List<string> joueurs, Dictionary<string, List<Pokemon>> dico)
	{
		foreach (string joueur in joueurs)
		{
			string path = $"{repertoire}/{joueur}.txt";
			if (File.Exists(path))
			{
				FileStream fs = new FileStream(path, FileMode.Open);
				StreamReader sr = new StreamReader(fs);
				string ligne = "";
				List<Pokemon> pokemons = new List<Pokemon>();
				while ((ligne = sr.ReadLine()) != null)
				{
					string[] elts = ligne.Split(',');
					pokemons.Add(new Pokemon(elts[0], int.Parse(elts[1]), int.Parse(elts[2]), int.Parse(elts[3]), int.Parse(elts[4])));
				}
				dico.TryAdd(joueur, pokemons);
			}
		}
	}

	public static void AfficherDicionnaire(Dictionary<string, List<Pokemon>> jeu)
	{
		foreach (KeyValuePair<string, List<Pokemon>> kvp in jeu)
		{
			Console.WriteLine("".PadRight(80, 'X'));
			Console.WriteLine($"Deck du joueur {kvp.Key}");
			foreach (Pokemon p in kvp.Value)
			{
				Console.WriteLine($"Pokémon {p.nom} : niveau {p.niveau} attaque {p.attaque} défense {p.defense} pointsDeVie {p.pointsDeVie}");
			}
		}
	}

	public static void AfficherNiveauMax(Dictionary<string, List<Pokemon>> jeu)
	{
		foreach (KeyValuePair<string, List<Pokemon>> kvp in jeu)
		{
			int niveauMax = -1;
			foreach (Pokemon p in kvp.Value)
			{
				if (p.niveau > niveauMax)
				{
					niveauMax = p.niveau;
				}
			}
			if (kvp.Value.Count == 0)
			{
				Console.WriteLine($"Le joueur {kvp.Key} n'a pas de Pokémon !");
			}
			else
			{
				Console.WriteLine($"Le joueur {kvp.Key} a un Pokémon de niveau max égal à {niveauMax}.");
			}
		} 
	}

	// combat entre deux Pokémons
	// le combat se fait à tour de rôle
	// le plus faible niveau commence
	// le pokémon qui attaque inflige des dégâts (aux pointsDeVie de celui qui défend) égaux
	// -> son niveau + max (0, attaque de l'attaquant - défense du défenseur)
	// ex : P1 : n = 50, att = 75, def = 50, pointsDeVie = 500; P2 : n = 70, att = 100, def = 50, pointsDeVie = 600
	// P1 commence et inflige 50 + max(0, (75 - 50)) = 50 + 25 = 75 ce qui mets les pointsDeVie de P2 à 600 - 75 = 525
	// P2 inflige 70 + max(0, (100 - 50)) = 70 + 50 = 120 ce qui mets les pointsDeVie de P1 à 500 - 120 = 380
	// P1 inflige 75 dommages, les pointsDeVie de P2 valent 525 - 75 = 450
	// P2 inflige 120 dommages, les pointsDeVie de P1 valent 380 - 120 = 260
	// P1 inflige 75 dommages, les pointsDeVie de P2 valent 450 - 75 = 375
	// P2 inflige 120 dommages, les pointsDeVie de P1 valent 260 - 120 = 140
	// P1 inflige 75 dommages, les pointsDeVie de P2 valent 375 - 75 = 300
	// P2 inflige 120 dommages, les pointsDeVie de P1 valent 140 - 120 = 20
	// P1 inflige 75 dommages, les pointsDeVie de P2 valent 300 - 75 = 225
	// P2 inflige 120 dommages, les pointsDeVie de P1 valent 20 - 120 = -100 ==> P2 remporte le combat
	public static Pokemon SimulerCombatPokemons(Pokemon p1, Pokemon p2)
	{
		Console.WriteLine("".PadRight(80, 'x'));
		Console.WriteLine($"Combat entre {p1.nom} et {p2.nom}");
		Console.WriteLine($"Pokémon {p1.nom} --- niveau : {p1.niveau} attaque : {p1.attaque} defense : {p1.defense} pointsDeVie : {p1.pointsDeVie}");
		Console.WriteLine($"Pokémon {p2.nom} --- niveau : {p2.niveau} attaque : {p2.attaque} défense : {p2.defense} pointsDeVie : {p2.pointsDeVie}");
		int pdv1 = p1.pointsDeVie;
		int pdv2 = p2.pointsDeVie;		
		int degats1 = p1.niveau + Math.Max(0, p1.attaque - p2.defense);
		int degats2 = p2.niveau + Math.Max(0, p2.attaque - p1.defense);
		int indiceJoueur = 0;
		if (p2.niveau <= p1.niveau)
		{
			indiceJoueur = 1;
		}
		while (pdv1 > 0 && pdv2 > 0)
		{
			// attaque de P1
			if (indiceJoueur == 0)
			{
				Console.Write($"{p1.nom} inflige {degats1} dégâts à {p2.nom}");
				pdv2 -= degats1;
				Console.WriteLine($" (pointsDeVie de {p2.nom} : {pdv2})");
				indiceJoueur = 1;
			}
			// attaque de P2
			else
			{
				Console.Write($"{p2.nom} inflige {degats2} dégâts à {p1.nom}");
				pdv1 -= degats2;
				Console.WriteLine($" (pointsDeVie de {p1.nom} : {pdv1})");
				indiceJoueur = 0;
			}
		}
		Console.WriteLine($"Fin du combat ! Vainqueur : {p1.pointsDeVie <= 0 ? p2.nom : p1.nom}");
		// déterminer le vainqueur à retourner
		if (pdv1 <= 0)
		{
			return p1;
		}
		else
		{
			return p2;
		}
	}

	public static string SimulerCombatJoueurs(string j1, string j2, Dictionary<string, List<Pokemon>> jeu, ref List<Pokemon> vaincus)
	{
		Console.WriteLine("".PadRight(80, 'x'));
		Console.WriteLine($"Combat entre les joueurs {j1} et {j2}.");

		List<Pokemon> vaincus1 = new List<Pokemon>();
		List<Pokemon> vaincus2 = new List<Pokemon>();

		// tant qu'il y a deux Pokémons valides, lancer un combat entre les têtes de listes
		while (jeu[j1].Count > 0 && jeu[j2].Count > 0)
		{
			// lancer un combat, le gagnant est indiqué par le booléen retourné
			Pokemon perdant = SimulerCombatPokemons(jeu[j1][0], jeu[j2][0]);
			if (perdant.nom.Equals(jeu[j1][0].nom))
			{
				vaincus1.Add(jeu[j1][0]);
				jeu[j1].Remove(jeu[j1][0]);
			}
			else
			{
				vaincus2.Add(jeu[j2][0]);
				jeu[j2].Remove(jeu[j2][0]);
			}
		}

		if (jeu[j1].Count == 0)
		{
			Console.WriteLine($"Fin du combat ! Le joueur {j2} remporte le combat !");
			vaincus = vaincus1;
			return j2;
		}
		else
		{
			Console.WriteLine($"Fin du combat ! Le joueur {j1} remporte le combat !");
			vaincus = vaincus2;
			return j1;
		}
	}

	public static void Main()
	{
		// liste des joueurs
		List<string> joueurs = new List<string> {"Coco", "Crash", "VonClutch"};
		// dictionnaire contenant les joueurs et leurs pokémons
		Dictionary<string, List<Pokemon>> jeu = new Dictionary<string, List<Pokemon>>();

		// lecture de tous les joueurs
		LirePokemons("joueurs", joueurs, jeu);

		// Affichage du dictionnaire
		AfficherDicionnaire(jeu);

		// pokémon de niveau max pour chaque joueur
		AfficherNiveauMax(jeu);

		// combat simple ente Pokémons factices
		Pokemon vainqueur = SimulerCombatPokemons(new Pokemon("Frospark", 50, 75, 50, 500), new Pokemon("Vaporvolt", 70, 100, 50, 600));
		Console.WriteLine($"Le vainqueur retourné est {vainqueur.nom}.");

		// combat complet entre Coco et VonClutch
		List<Pokemon> vaincus = new List<Pokemon>();
		string perdant = SimulerCombatJoueurs("Coco", "VonClutch", jeu, ref vaincus);
		Console.WriteLine($"Le dresseur vainqueur retourné est {perdant}.");
	}
}