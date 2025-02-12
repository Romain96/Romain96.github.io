// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice5
{
	// Procédure : lecture d'un nombre entier depuis le terminal
	// Paramètres : 
	//	- msg (string): message textuel à afficher à l'utilisateur
	// Retourne :
	//	- n (int): entier lu depuis le terminal
	public static int LireEntier(string msg)
	{
		Console.Write(msg);
		int n = int.Parse(Console.ReadLine());
		return n;
	}
	
	// Procédure : affichage d'une chaine de caractères dans le terminal
	// Paramètres : 
	//	- msg (string): message textuel à afficher à l'utilisateur
	// Retourne : /
	public static void AfficherChaine(string msg)
	{
		Console.WriteLine(msg);
	}
	
	// Procédure : Création d'une liste de chaines de caractères vide
	// Paramètres : /
	// Retourne :
	//	- liste (List<string>): nouvelle liste de chaines de caractères vide
	public static List<string> ListeVide()
	{
		List<string> liste = new List<string>();
		return liste;
	}
	
	// Procédure : affichage d'une liste de chaines de caractères dans le terminal
	// Paramètres :
	//	- liste (List<string>): liste d'entiers à afficher
	// Retourne : /
	public static void AfficherListe(List<string> liste)
	{
		if (liste.Count < 1)
			Console.WriteLine("{}");
		else
		{
			Console.Write("{");
			for (int i = 0; i < liste.Count - 1; i++)
				Console.Write("\"" + liste[i] + "\", ");
			Console.WriteLine(liste[liste.Count - 1] + "}");
		}
	}
	
	// Fonction : vérifie si un tableau de chaines de caractères est trié par ordre alphabétique
	// Paramètres :
	//	- liste (List<string>): liste de chaines de caractères
	// Retourne :
	//	- triee (bool): vrai si `liste` est triée par ordre alphabétique, faux sinon
	public static bool TrieeAlphabetique(List<string> liste)
	{
		bool triee = true;
		int i = 1;
		bool fin = false;
		while (i < liste.Count && !fin)
		{
			// a.Compare(b) retourne -1 si a est avant b alphabétiquement
			// a.Compare(b) retourne 0 si a = b
			// a.Compare(b) retourne 1 si a est après b alphabétiquement
			if (string.Compare(liste[i-1], liste[i]) > 0)
			{
				triee = false;
				fin = true;
			}
			i += 1;
		}
		return triee;
	}
	
	static void Main()
	{
		List<string> alpha = ListeVide();
		alpha.Add("a");
		alpha.Add("aba");
		alpha.Add("abba");
		AfficherListe(alpha);
		AfficherChaine("La liste est dans l'ordre alphabétique : " + TrieeAlphabetique(alpha));
		
		List<string> pas_alpha = ListeVide();
		pas_alpha.Add("a");
		pas_alpha.Add("oui");
		pas_alpha.Add("hello world !");
		AfficherListe(pas_alpha);
		AfficherChaine("La liste est dans l'ordre alphabétique : " + TrieeAlphabetique(pas_alpha));
	}
}