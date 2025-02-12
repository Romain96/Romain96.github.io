// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice1
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
	
	static void Main()
	{
		int n = LireEntier("Nombre de termes de la suite de Fibonacci à générer : ");
		List<int> fibo = ListeFibonacci(n);
		AfficherListe(fibo);
	}
}