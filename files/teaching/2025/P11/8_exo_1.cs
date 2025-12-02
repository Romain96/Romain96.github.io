// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice1
{
	// Procédure : AfficherPhrase
	// Entrée :	- phrase : ListeChaînée<chaîne de caractères>
	// Sortie :	void
	public static void AfficherPhrase(LinkedList<string> phrase)
	{
		foreach (string mot in phrase)
		{
			Console.Write(mot + " ");
		}
		Console.Write("\b \b.\n");	// effacer le dernier espace et le remplacer par un saut de ligne
	}
	
	
	// Procédure : InsererMot
	// Entrée :	- phrase : ListeChaînée<chaîne de caractères>
	//			- mot : chaîne de caractères
	//			- motAvant : chaîne de caractères
	//			- motApres : chaîne de caractères
	// Sortie :	void
	public static void InsererMot(LinkedList<string> phrase, string mot, string motAvant, string motApres)
	{
		LinkedListNode<string> noeud = phrase.First;
		bool rechercher = true;
		bool avant = false;
		
		while (noeud != null && rechercher)
		{
			if (noeud.Value == motAvant)
			{
				avant = true;	// on marque le noeud avant, si le noeud suivant est le motApres alors on insère
			}
			else if (noeud.Value == motApres && avant)
			{
				phrase.AddBefore(noeud, mot);	// insertion de mot entre ce noeud et le noeud précédent				
				rechercher = false;	// insertion réalisée, on quitte la boucle
			}
			else
			{
				avant = false;
			}
			noeud = noeud.Next;
		}
	}
	
	
	// Procédure : ModifierMot
	// Entrée :	- phrase : ListeChaînée<chaîne de caractères>
	//			- mot : chaîne de caractères
	//			- nouveauMot : chaîne de caractères
	// Sortie :	void
	public static void ModifierMot(LinkedList<string> phrase, string mot, string nouveauMot)
	{
		LinkedListNode<string> noeud = phrase.First;
		bool rechercher = true;
		
		while (noeud != null && rechercher)
		{
			if (noeud.Value == mot)
			{
				noeud.Value = nouveauMot;	// modification
				rechercher = false;	// quitter la boucle
			}
			noeud = noeud.Next;
		}
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		LinkedList<string> phrase = new LinkedList<string>();
		
		phrase.AddLast("je");
		phrase.AddLast("suis");
		phrase.AddLast("une");
		phrase.AddLast("phrase");
		phrase.AddLast("de");
		phrase.AddLast("7");
		phrase.AddLast("mots");
		AfficherPhrase(phrase);
		
		// Ajouter le mot 'petite' après le mot 'une' et avant le mot 'phrase'
		InsererMot(phrase, "petite", "une", "phrase");
		AfficherPhrase(phrase);
		
		// modifier le mot "7" en "8"
		ModifierMot(phrase, "7", "8");
		AfficherPhrase(phrase);
	}
}
