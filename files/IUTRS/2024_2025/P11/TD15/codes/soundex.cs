// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Soundex
{
	// Fonction : FormaterChaine
	// supprime les caractères non alphabétiques, supprimes les espaces et mets la chaine en majuscules
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- c : caractère
	// Sortie :		- chaineFormatee : chaîne de caractères
	public static string FormaterChaine(string chaine)
	{
		string chaineFormatee = "";
		foreach (char c in chaine)
		{
			if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
			{
				chaineFormatee += c;
			}
		}
		chaineFormatee = chaineFormatee.ToUpper();
		return chaineFormatee;
	}

	// Fonction : SupprimerLettres
	// supprime A, E, I, O, U, Y, H et W
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- c : caractère
	// Sortie :		- chaineFormatee : chaine de caractères
	public static string SupprimerLettres(string chaine)
	{
		string chaineFormatee = "";
		foreach (char c in chaine)
		{
			if (c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U' && c != 'Y' && c != 'H' && c != 'W')
			{
				chaineFormatee += c;
			}
		}
		return chaineFormatee;
	}

	// Fonction : SupprimerRepetitions
	// supprime les caractères répétés
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- c : caractère
	// Sortie :		- chaineFormatee : chaine de caractères
	public static string SupprimerRepetitions(string chaine)
	{
		string chaineFormatee = "";
		int index = 0;
		while (index < chaine.Length)
		{
			char prev = chaine[index];
			index++;
			// ajouter le caractère
			chaineFormatee += prev;
			// ignorer les répétitions consécutives
			while (index < chaine.Length && chaine[index] == prev)
			{
				index++;
			}
		}
		return chaineFormatee;
	}

	// Fonction : CreerDictionnaireFrancais
	// Entrée :		void
	// Local :		/
	// Sortie :		- dico : dictionnaire (clef : caractère, valeur : entier)
	public static Dictionary<char, int> CreerDictionnaireFrancais()
	{
		Dictionary<char, int> dico = new Dictionary<char, int>();
		dico.Add('B', 1);
		dico.Add('P', 1);
		dico.Add('C', 2);
		dico.Add('K', 2);
		dico.Add('Q', 2);
		dico.Add('D', 3);
		dico.Add('T', 3);
		dico.Add('L', 4);
		dico.Add('M', 5);
		dico.Add('N', 5);
		dico.Add('R', 6);
		dico.Add('G', 7);
		dico.Add('J', 7);
		dico.Add('S', 8);
		dico.Add('X', 8);
		dico.Add('Z', 8);
		dico.Add('F', 9);
		dico.Add('V', 9);
		return dico;
	}

	// Fonction : CreerDictionnaireAnglais
	// Entrée :		void
	// Local :		/
	// Sortie :		- dico : dictionnaire (clef : caractère, valeur : entier)
	public static Dictionary<char, int> CreerDictionnaireAnglais()
	{
		Dictionary<char, int> dico = new Dictionary<char, int>();
		dico.Add('B', 1);
		dico.Add('F', 1);
		dico.Add('P', 1);
		dico.Add('V', 1);
		dico.Add('C', 2);
		dico.Add('G', 2);
		dico.Add('J', 2);
		dico.Add('K', 2);
		dico.Add('Q', 2);
		dico.Add('S', 2);
		dico.Add('X', 2);
		dico.Add('Z', 2);
		dico.Add('D', 3);
		dico.Add('T', 3);
		dico.Add('L', 4);
		dico.Add('M', 5);
		dico.Add('N', 5);
		dico.Add('R', 6);
		return dico;
	}

	// Fonction : CalculerCodeSoundexAnglais
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- c : caractère
	// Sortie :		- codeSoundex : chaîne de caractères
	public static string CalculerCodeSoundexAnglais(string chaine)
	{
		Dictionary<char, int> dico = CreerDictionnaireAnglais();
		string codeSoundex = "";
		foreach (char c in chaine)
		{
			codeSoundex += dico[c];
		}
		return codeSoundex;
	}

	// Fonction : CalculerCodeSoundexFrancais
	// Entrée :		- chaine : chaîne de caractères
	// Local :		- c : caractère
	// Sortie :		- codeSoundex : chaîne de caractères
	public static string CalculerCodeSoundexFrancais(string chaine)
	{
		Dictionary<char, int> dico = CreerDictionnaireFrancais();
		string codeSoundex = "";
		foreach (char c in chaine)
		{
			codeSoundex += dico[c];
		}
		return codeSoundex;
	}

	// Fonction : CalculerSoundex
	// Entrée :		- chaine : chaîne de caractères
	//				- langue : chaîne de caractères
	// Local :		- chaineFormatee, autresLettres, chaineAvecSuppressions, chiffres, chiffresSansRepetition : chaîne de caractères
	//				- premiereLettre : caractère
	// Sortie :		- codeSoundex : chaîne de caractères
	public static string CalculerSoundex(string chaine, string langue)
	{
		if (langue.ToLower().Equals("f") || langue.ToLower().Equals("a"))
		{
			if (chaine.Length < 1)
			{
				throw new ArgumentException("Soundex : la chaîne est vide !");
			}

			// supprimer les espaces, mettre en majuscules
			string chaineFormatee = FormaterChaine(chaine);
			char premiereLettre = chaineFormatee[0];
			string autresLettres = chaineFormatee.Substring(1, chaineFormatee.Length - 1);

			// supprimer A, E, I, O , U, Y, H et W
			string chaineAvecSuppressions = SupprimerLettres(autresLettres);

			// obtenir les chiffres en fonction des lettres et de la langue
			string chiffres = "";
			if (langue.ToLower().Equals("f"))
			{
				chiffres = CalculerCodeSoundexFrancais(chaineAvecSuppressions);
			}
			else if (langue.ToLower().Equals("a"))
			{
				chiffres = CalculerCodeSoundexAnglais(chaineAvecSuppressions);
			}

			// supprimer les chiffres répétés consécutivement
			string chiffresSansRepetition = SupprimerRepetitions(chiffres);

			// code final = 4 premières lettres de (première lettre + code sans répétitions) comblé avec des espaces
			string code = $"{premiereLettre}{chiffresSansRepetition}";
			if (code.Length == 4)
			{
				return code;
			}
			else if (code.Length > 4)
			{
				return code.Substring(0, 4);
			}
			else
			{
				return $"{code}".PadRight(4, ' ');
			}
		}
		else
		{
			throw new Exception($"Soundex : la langue {langue} n'est pas supportée.");
		}
	}
	
	// Procédure : AfficherCorrespondance
	// Entrée :		- noms : liste de chaînes de caractères
	//				- chaine : chaîne de caractères
	//				- langue : chaîne de caractères
	// Local :		- n, codeNom, codeN : chaîne de caractères
	// Sortie :		void
	public static void AfficherCorrespondances(List<string> noms, string nom, string langue)
	{
		string codeNom = CalculerSoundex(nom, langue);
		Console.WriteLine($"Liste des correspondances pour {nom} (code : {codeNom}) avec la langue {langue} :");
		foreach (string n in noms)
		{
			string codeN = CalculerSoundex(n, langue);
			if (codeN.Equals(codeNom))
			{
				Console.WriteLine($"-> {n}");
			}
		}
	}

	// Procédure : AfficherCodes
	// Entrée :		- noms : liste de chaînes de caractères
	// Local :		- codeFr, codeEn, n : chaîne de caractères
	// Sortie :		void
	public static void AfficherCodes(List<string> noms)
	{
		Console.WriteLine("| Nom".PadRight(32, ' ') + "| S_Fr".PadRight(7, ' ') + "| S_En".PadRight(7, ' ') + "|");
		Console.WriteLine("|" + "".PadRight(31, '-') + "|" + "".PadRight(6, '-') + "|" + "".PadRight(6, '-') + "|");
		foreach (string n in noms)
		{
			string codeFr = CalculerSoundex(n, "f");
			string codeEn = CalculerSoundex(n, "a");
			Console.Write($"| {n}".PadRight(32, ' '));
			Console.Write($"| {codeFr}".PadRight(7, ' '));
			Console.Write($"| {codeEn}".PadRight(7, ' '));
			Console.WriteLine("|");
		}
	}

	public static void Main()
	{
		List<string> etudiants = new List<string> {
			"Ramzan", "Ayoub", "Jason-Scott", "Fella", 
			"Halil", "Gauthier", "Noah", "Sacha",
			"Kadir", "Liam", "Bastien", "Valentin",
			"Farouk", "Elisabeth", "Andy", "Raphael",
			"Ferencz", "Nathan", "Victor", "Guillaume", "Matteo"
		};
		bool quitter = false;
		while (!quitter)
		{
			Console.WriteLine("MENU\n1 - Chercher un nom\n2 - Lister les noms et codes soudex\n3 - Quitter");
			int choix = 0;
			while (choix != 1 && choix != 2 && choix != 3)
			{
				choix = int.Parse(Console.ReadLine());
			}
			if (choix == 1)
			{
				Console.Write("Nom à rechercher : ");
				string nom = Console.ReadLine();
				AfficherCorrespondances(etudiants, nom, "f");
				AfficherCorrespondances(etudiants, nom, "a");
			}
			else if (choix == 2)
			{
				AfficherCodes(etudiants);
			}
			else if (choix == 3)
			{
				quitter = true;
			}
		};
	}
}