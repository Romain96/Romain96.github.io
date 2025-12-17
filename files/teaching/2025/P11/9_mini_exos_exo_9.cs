// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice9
{
	// Fonction : CreerDictionnaireDesMots
	// Entrée :	- tab : tableau 1D de chaînes de caractères
	// Sortie :	Dictionnaire<chaîne de caractères, entier>
	public static Dictionary<string, int> CreerDictionnaireDesMots(string[] chaines)
	{
		Dictionary<string, int> dico = new Dictionary<string, int>();
		
		foreach (string chaine in chaines)
		{
			if (!dico.ContainsKey(chaine))
			{
				dico.Add(chaine, chaine.Length);
			}
		}
		
		return dico;
	}
	
	
	// Procédure : AfficherDictionnaire
	// Entrée :	- dico : Dictionnaire<chaîne de caractères, entier>
	// Sortie :	void
	public static void AfficherDictionnaire(Dictionary<string, int> dico)
	{
		foreach (KeyValuePair<string, int> kvp in dico)
		{
			Console.WriteLine("Clef : '" + kvp.Key + "', valeur : " + kvp.Value);
		}
	}
	
	
	public static void Main()
	{
		string[] mots = new string[] {
			"Etre", "ou", "n'être", "pas", "," ,"c'est", "là", "la", "question", ";", 
			"S'il", "est", "plus", "noble", "dans", "l'esprit", "de", "souffrir",
			"Les", "piqûres", "et", "les", "flèches", "de", "l'affreuse", "fortune",
			"Ou", "de", "prendre", "les", "armes", "contre", "une", "mer", "de", "troubles",
			"Et", "en", "s'opposant", "à", "eux", ",", "les", "finir", "?", "Mourir", ",",  "dormir", ",",
			"Rien", "de", "plus", ";", "et", "par", "ce", "sommeil", "dire", ":", "Nous", "terminons",
			"Les", "peines", "du", "cœur", ",", "et", "dix", "mille", "chocs", "naturels",
			"Dont", "la", "chair", "est", "héritière", ",", "c'est", "une", "consommation",
			"Ardemment", "désirable", ".", "Mourir", ",", "dormir", ":",
			"Dormir", ",", "peut-être", "rêver", "!", "Ah", ",", "voilà", "le", "mal", "!",
			"Car", ",", "dans", "ce", "sommeil", "de", "la", "mort", ",", "quels", "rêves", "aura-t-on",
			"Quand", "on", "a", "dépouillé", "cette", "enveloppe", "mortelle", "?",
			"C'est", "là", "ce", "qui", "fait", "penser", ":", "c'est", "là", "la", "raison",
			"Qui", "donne", "à", "la", "calamité", "une", "vie", "si", "longue", ":",
			"Car", "qui", "voudrait", "supporter", "les", "coups", ",", "et", "les", "injures", "du", "temps",
			"Les", "torts", "de", "l'oppresseur", ",", "les", "dédains", "de", "l'orgueilleux", ".",
			"Les", "angoisses", "d'un", "amour", "méprisé", ",", "les", "délais", "de", "la", "justice", ",",
			"L'insolence", "des", "grandes", "places", "et", "les", "rebuts",
			"Que", "le", "mérite", "patient", "essuie", "de", "l'homme", "indigne", ".",
			"Quand", "il", "peut", "faire", "son", "quietus",
			"Avec", "une", "simple", "aiguille", "à", "tête", "?", "qui", "voudrait", "porter", "ces", "fardeaux", ",",
			"Sangloter", ",", "suer", "sous", "une", "fatigante", "vie", "?",
			"Mais", "cette", "crainte", "de", "quelque", "chose", "après", "la", "mort", ",",
			"Ce", "pays", "ignoré", ",", "des", "bornes", "duquel",
			"Nul", "voyageur", "ne", "revient", ",", "embarrasse", "la", "volonté",
			"Et", "nous", "fait", "supporter", "les", "maux", "que", "nos", "avons", ",",
			"Plutôt", "que", "de", "courir", "vers", "d'autres", "que", "nous", "ne", "connaissons", "pas", ".",
			"Ainsi", "la", "conscience", "fait", "des", "poltrons", "de", "nous", "tous", ";",
			"Ainsi", "la", "couleur", "naturelle", "de", "la", "résolution",
			"Est", "ternie", "par", "les", "pâles", "teintes", "de", "la", "pensée", ";",
			"Et", "les", "entreprises", "les", "plus", "importantes", ",",
			"Par", "ce", "respect", ",", "tournent", "leur", "courant", "de", "travers", ",",
			"Et", "perdent", "leur", "nom", "d'action", ";"
		};
		Dictionary<string, int> dico = CreerDictionnaireDesMots(mots);
		AfficherDictionnaire(dico);
	}
}
