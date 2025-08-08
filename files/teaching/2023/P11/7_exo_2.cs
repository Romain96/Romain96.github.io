// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice2
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
	
	// Fonction : calcul du nombre d'occurrences d'un entier dans une liste d'entiers
	// Paramètres :
	//	- liste (List<int>): liste d'entiers
	//	- n (int): entier à rechercher dans `liste`
	// Retourne :
	//	- occ (int): le nombre d'occurrences de `n` dans `liste`
	public static int Occurrences(List<int> liste, int n)
	{
		int occ = 0;
		for (int i = 0; i < liste.Count; i++)
		{
			if (liste[i] == n)
			{
				occ += 1;
			}
		}
		return occ;
	}
	
	static void Main()
	{
		int n = LireEntier("Nombre d'entiers aléatoires à générer : ");
		List<int> alea = ListeAleatoire(n, 0, 9);
		AfficherChaine("Liste aléatoire");
		AfficherListe(alea);
		for (int i = 0; i <= 9; i++)
		{
			AfficherChaine("Il y a " + Occurrences(alea, i) + " occurrences de " + i + " dans la liste");
		}
	}
}