// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice6
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
	
	// Procédure : création d'une liste d'entiers avec les n premiers termes de la suite de Fibonacci
	// Paramètres :
	//	- n (int): nombre de termes de la suite de Fibonacci à générer
	// Retourne :
	//	- fibo (List<int>): nouvelle liste d'entiers remplie avec les n premiers termnes de la suite de Fibonacci
	// Pré-condition : n >= 0, sinon la liste retournée est vide
	public static List<int> ListeFibonacci(int n)
	{
		List<int> fibo = ListeVide();
		if (n == 1)
		{
			fibo.Add(1);
		}
		else if (n == 2)
		{
			fibo.Add(1);
			fibo.Add(1);
		}
		else if (n >= 2)
		{
			fibo.Add(1);
			fibo.Add(1);
			for (int i = 2; i <= n; i++)
			{
				// f(i) = f(i-1) + f(i-2) pour i >= 2
				fibo.Add(fibo[fibo.Count - 1] + fibo[fibo.Count - 2]);
			}
		}
		return fibo;
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
	
	// Fonction : vérifie qu'une sous-liste d'entiers est triée dans l'ordre croissant
	// Paramètres :
	//	- liste (List<int>): liste d'entiers
	// 	- borne_inf (int): indice du premier entier de la sous-liste
	//	- borne_sup (int): indice du dernier entier de la sous-liste
	// Retourne :
	//	- triee (bool): vrai si la sous-liste de `liste` entre `borne_inf` et `borne_sup` est triée, faux sinon
	// Pré-condition : 
	//	- 0 <= borne_inf <= borne_sup < liste.Count
	public static bool TrieeCroissantSousListe(List<int> liste, int borne_inf, int borne_sup)
	{
		bool triee = true;
		int i = borne_inf + 1;
		bool stop = false;
		while (i <= borne_sup && !stop)
		{
			if (liste[i] < liste[i-1])
			{
				triee = false;
				stop = true;
			}
			i += 1;
		}
		return triee;
	}
	
	static void Main()
	{
		int n = 10;
		List<int> alea = ListeAleatoire(n, 0, 9);
		AfficherListe(alea);
		AfficherChaine("La sous-liste de 2 à 8 est triée par ordre croissant : " + TrieeCroissantSousListe(alea, 2, 8));
		List<int> fibo = ListeFibonacci(n);
		AfficherListe(fibo);
		AfficherChaine("La sous-liste de 2 à 8 est triée par ordre croissant : " + TrieeCroissantSousListe(fibo, 2, 8));
	}
}