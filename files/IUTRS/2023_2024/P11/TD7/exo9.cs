// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice9
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
	
	// Procédure : création d'une liste d'entiers avec n entiers alétoires
	// Paramètres :
	//	- n (int): nombre d'entiers aléatoires à générer
	// Retourne :
	//	- alea (List<int>): nouvelle liste d'entiers remplie avec les n entiers aléatoires entre `entier_min` et `entier_max`
	// Pré-conditions : 
	//	entier_min <= entier_max, sinon permutation des valeurs
	//	n > 0, sinon la liste générée est vide
	public static List<int> ListeAleatoire(int n, int entier_min, int entier_max)
	{
		if (entier_max < entier_min)
		{
			int tmp = entier_min;
			entier_min = entier_max;
			entier_max = tmp;
		}
		List<int> alea = ListeVide();
		Random rnd = new Random();
		for (int i = 0; i < n; i++)
		{
			alea.Add(rnd.Next(entier_min, entier_max + 1));
		}
		return alea;
	}
	
	// Fonction : recherche de la plus grande monotonie croissante dans une liste d'entiers
	// Paramètres:
	//	- liste (List<int>): liste d'entiers
	// Retourne:
	//	- monotonie (List<int>): la plus grande monotonie croissante de `liste`
	public static List<int> PlusGrandeMonotonieCroissante(List<int> liste)
	{
		List<int> monotonie = ListeVide();
		int indice_debut = 0;
		int indice_fin = 0;
		int size = 0;
		while (indice_debut < liste.Count)
		{
			// parcours de la monotonie locale
			int i = indice_debut + 1;
			while (i < liste.Count && liste[i-1] <= liste[i])
			{
				i += 1;
			}
			indice_fin = i;
			size = indice_fin - indice_debut;
			// extraction si plus grande
			if (size > monotonie.Count)
			{
				monotonie = liste.GetRange(indice_debut, size);
			}
			indice_debut = indice_fin;
		}
		return monotonie;
	}
	
	// Fonction : recherche de la plus grande monotonie décroissante dans une liste d'entiers
	// Paramètres:
	//	- liste (List<int>): liste d'entiers
	// Retourne:
	//	- monotonie (List<int>): la plus grande monotonie décroissante de `liste`
	public static List<int> PlusGrandeMonotonieDecroissante(List<int> liste)
	{
		List<int> monotonie = ListeVide();
		int indice_debut = 0;
		int indice_fin = 0;
		int size = 0;
		while (indice_debut < liste.Count)
		{
			// parcours de la monotonie locale
			int i = indice_debut + 1;
			while (i < liste.Count && liste[i-1] >= liste[i])
			{
				i += 1;
			}
			indice_fin = i;
			size = indice_fin - indice_debut;
			// extraction si plus grande
			if (size > monotonie.Count)
			{
				monotonie = liste.GetRange(indice_debut, size);
			}
			indice_debut = indice_fin;
		}
		return monotonie;
	}
	
	// Fonction : recherche de la plus grande monotonie dans une liste d'entiers
	// Paramètres:
	//	- liste (List<int>): liste d'entiers
	// Retourne:
	//	- monotonie (List<int>): la plus grande monotonie de `liste`
	public static List<int> PlusGrandeMonotonie(List<int> liste)
	{
		List<int> croissante = PlusGrandeMonotonieCroissante(liste);
		List<int> decroissante = PlusGrandeMonotonieDecroissante(liste);
		if (croissante.Count >= decroissante.Count)
		{
			return croissante;
		}
		else
		{
			return decroissante;
		}
	}
	
	static void Main()
	{
		int n = LireEntier("Taille de la liste aléatoire : ");
		List<int> alea = ListeAleatoire(n, 0, 9);
		AfficherChaine("Liste alétoire");
		AfficherListe(alea);
		AfficherChaine("La plus grande monotonie est :");
		AfficherListe(PlusGrandeMonotonie(alea));
		AfficherChaine("La plus grande monotonie croissante est :");
		AfficherListe(PlusGrandeMonotonieCroissante(alea));
		AfficherChaine("La plus grande monotonie décroissante est :");
		AfficherListe(PlusGrandeMonotonieDecroissante(alea));
	}
}