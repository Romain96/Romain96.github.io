// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice8
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
	
	// Procédure : Création d'une liste d'entiers vide
	// Paramètres : /
	// Retourne :
	//	- liste (List<int>): nouvelle liste d'entiers vide
	public static List<int> ListeVide()
	{
		List<int> liste = new List<int>();
		return liste;
	}
	
	// Procédure : affichage d'une liste d'entiers dans le terminal
	// Paramètres :
	//	- liste (List<int>): liste d'entiers à afficher
	// Retourne : /
	public static void AfficherListe(List<int> liste)
	{
		if (liste.Count < 1)
			Console.WriteLine("{}");
		else
		{
			Console.Write("{");
			for (int i = 0; i < liste.Count - 1; i++)
				Console.Write(liste[i] + ", ");
			Console.WriteLine(liste[liste.Count - 1] + "}");
		}
	}
	
	// Fonction : suppression des nombres entiers multiples d'un nombre donné (sauf le nombre lui-même)
	// Paramètres:
	//	- liste (List<int>): liste d'entiers
	//	- n (int): entier
	// Retourne:
	//	- res (List<int>): nouvelle liste, sous-liste de `liste` dont les multiples de `n` ont été supprimés
	public static List<int> SupprimerMultiples(List<int> liste, int n)
	{
		List<int> res = ListeVide();
		for (int i = 0; i < liste.Count; i++)
		{
			if (liste[i] % n != 0 || liste[i] == n)
			{
				res.Add(liste[i]);
			}
		}
		return res;
	}

	// Fonction : construction de la liste des entiers premiers de 2 à n par ma méthode du crible d'Ératosthène
	// Paramètres:
	//	- n (int): le nombre premier maximal généré sera <= n
	// Retourne:
	//	- premiers (List<int>): une liste d'entiers premiers de >= 2 et <= n
	// Pré-condition : 
	//	- n >= 2
	public static List<int> ListePremiers(int n)
	{
		// génération d'une liste contenant les entiers de 2 à n
		List<int> premiers = ListeVide();
		for (int i = 2; i <= n; i++)
		{
			premiers.Add(i);
		}
		AfficherListe(premiers);
		// suppresion des multiples de 2, 3 et 5
		premiers = SupprimerMultiples(premiers, 2);
		AfficherListe(premiers);
		premiers = SupprimerMultiples(premiers, 3);
		AfficherListe(premiers);
		premiers = SupprimerMultiples(premiers, 5);
		AfficherListe(premiers);
		// suppression des multiples de toutes les valeurs restantes [6,n]
		for (int i = 6; i <= n; i++)
		{
			premiers = SupprimerMultiples(premiers, i);
		}
		return premiers;
	}
	
	static void Main()
	{
		int n = LireEntier("Nombres premiers de 2 à n, entrez n : ");
		List<int> premiers = ListePremiers(n);
		AfficherChaine("Liste des nombres premiers de 2 à " + n);
		AfficherListe(premiers);
	}
}