// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice4
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
	
	// Fonction : recherche de l'entier maximal dans une liste d'entiers
	// Paramètres :
	//	- liste (List<int>): liste d'entiers
	// Retourne :
	//	- entier_max (int): entier maximal dans `liste`
	// Pré-condition : la liste doit être non vide
	public static int Maximum(List<int> liste)
	{
		// erreur si la liste est vide
		int entier_max = liste[0];
		for (int i = 1; i < liste.Count; i++)
		{
			if (liste[i] > entier_max)
			{
				entier_max = liste[i];
			}
		}
		return entier_max;
	}
	
	// Fonction : recherche de l'entier maximal dans une liste d'entiers
	// Paramètres :
	//	- liste (List<int>): liste d'entiers
	// Retourne :
	//	- entier_max (int): entier maximal dans `liste`
	// Pré-conditions : 
	//	- la liste doit être non vide
	//	- 0 <= borne_inf <= borne_sup < liste.Count
	public static int Minimum(List<int> liste, int borne_inf, int borne_sup)
	{
		// erreur si la liste est vide ou borne_inf n'est pas dans [0, liste.Count-1]
		int entier_max = liste[borne_inf];
		for (int i = borne_inf + 1; i <= borne_sup; i++)
		{
			if (liste[i] > entier_max)
			{
				entier_max = liste[i];
			}
		}
		return entier_max;
	}
	
	static void Main()
	{
		int n = LireEntier("Nombre d'entiers aléatoires à générer : ");
		List<int> alea = ListeAleatoire(n, 0, 9);
		AfficherChaine("Liste aléatoire");
		AfficherListe(alea);
		AfficherChaine("Le maximum est " + Maximum(alea));
		AfficherChaine("Le minimum entre 0 et " + n/2 + " est " + Minimum(alea, 0, n/2));
	}
}