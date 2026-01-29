// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice3
{
	// Procédure : ConstituerTrain
	// Entrée :	- demande : chaîne de caractères
	//			- stock : File<caractère>
	//			- temp : File<caractère>
	//			- train : File<caractère>
	// Sortie :	void
	public static void ConstituerTrain(string demande, Queue<char> stock, Queue<char> temp, Queue<char> train)
	{
		Console.WriteLine("État des files avant la constitution du train...");
		AfficherFiles(stock, temp, train);
		
		// constituer le train en remplissant les files train et temp
		for (int i = demande.Length - 1; i >= 0; i--)
		{
			// tant que le sommet de stock n'est pas le prochain wagon attendu, on le place dans la file temp
			while(stock.Peek() != demande[i])
			{
				temp.Enqueue(stock.Dequeue());
			}
			// quand le bon wagon est trouvé, on le place dans la file train et on passe au wagon suivant (caractère) de demande
			train.Enqueue(stock.Dequeue());
		}
		
		Console.WriteLine("État des files après la constitution du train...");
		AfficherFiles(stock, temp, train);
		
		// remettre en stock la file temp
		while (temp.Count > 0)
		{
			stock.Enqueue(temp.Dequeue());
		}
		
		Console.WriteLine("État des files après la remise en stock de temp...");
		AfficherFiles(stock, temp, train);
	}
	
	
	// Afficher les informations (3 files)
	public static void AfficherFiles(Queue<char> stock, Queue<char> temp, Queue<char> train)
	{
		Console.Write("Stock : { ");
		foreach (char wagon in stock)
		{
			Console.Write($"{wagon} ");
		}
		Console.WriteLine("}");
		
		Console.Write("Temp : { ");
		foreach (char wagon in temp)
		{
			Console.Write($"{wagon} ");
		}
		Console.WriteLine("}");
		
		Console.Write("Train : { ");
		foreach (char wagon in train)
		{
			Console.Write($"{wagon} ");
		}
		Console.WriteLine("}");
	}


	public static void Main()
	{
		// File stock
		Queue<char> stock = new Queue<char>();
		stock.Enqueue('C');
		stock.Enqueue('P');
		stock.Enqueue('P');
		stock.Enqueue('F');
		stock.Enqueue('C');
		stock.Enqueue('F');
		stock.Enqueue('F');
		stock.Enqueue('C');
		stock.Enqueue('C');
		stock.Enqueue('C');
		stock.Enqueue('P');
		stock.Enqueue('F');
		stock.Enqueue('F');
		stock.Enqueue('F');
		
		// file temp
		Queue<char> temp = new Queue<char>();
		
		// file train
		Queue<char> train = new Queue<char>();
		
		// Question 3.1
		ConstituerTrain("CCFPC", stock, temp, train);
	}
}
