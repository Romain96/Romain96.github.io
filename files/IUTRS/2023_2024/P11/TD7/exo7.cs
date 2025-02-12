// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice7
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

	// Fonction : tri par insertion d'une liste d'entiers
	// Paramètres:
	// 	- liste (List<int>): liste d'entiers
	// Retourne:
	//	- triee (List<int>): une nouvelle liste de même taille que `liste` contenant les éléments de `liste` dans l'ordre coissant
	public static List<int> TriInsertionListeEntiers(List<int> liste)
	{
		List<int> triee = ListeVide();
		// parcours de chaque valeur de la liste non triée
		for (int indice_liste = 0; indice_liste < liste.Count; indice_liste++)
		{
			int valeur_a_inserer = liste[indice_liste];
			// recherche de l'indice d'insertion dans la liste triée et insertion
			int indice_insertion = 0;
			while (indice_insertion < triee.Count && triee[indice_insertion] < valeur_a_inserer)
			{
				indice_insertion += 1;
			}
			triee.Insert(indice_insertion, valeur_a_inserer);
		}
		return triee;
	}
	
	static void Main()
	{
		int n = LireEntier("Nombre de valeurs dans la liste : ");
		List<int> alea = ListeAleatoire(n, 0, 9);
		AfficherChaine("Liste alétoire");
		AfficherListe(alea);
		AfficherChaine("Liste triée");
		AfficherListe(TriInsertionListeEntiers(alea));
	}
}