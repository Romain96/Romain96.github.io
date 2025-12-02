// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice6
{
	// Fonction : SimulerIntersection
	// Entrée :	- f1 : File<entier>
	//			- f2 : File<entier>
	// Sortie :	Pile<entier>
	public static Queue<int> SimulerIntersection(Queue<int> f1, Queue<int> f2)
	{
		Queue<int> f3 = new Queue<int>();
		
		// deux piles vides = rien à faire :)
		if (f1.Count == 0 && f2.Count == 0)
		{
			return f3;
		}
		// sinon on priorise f1 car f2 contient un stop
		// on prend toujours f1 si la valeur est à 1 et seulement f2 si f1 est à 0 et f2 à 2
		else
		{
			while (f1.Count > 0 && f2.Count > 0)
			{
				// 0 et 0 -> on fait avancer les deux files
				if (f1.Peek() == 0 && f2.Peek() == 0)
				{
					f1.Dequeue();
					f2.Dequeue();
				}
				// 1 et 0 -> on ajoute 1 et on fait avancer f1 et f2
				else if (f1.Peek() == 1 && f2.Peek() == 0)
				{
					f3.Enqueue(f1.Dequeue());
					f2.Dequeue();
				}
				// 0 et 2 -> on ajoute 2 et on fait avancer f2 et f1
				else if (f1.Peek() == 0 && f2.Peek() == 2)
				{
					f3.Enqueue(f2.Dequeue());
					f1.Dequeue();
				}
				// 1 et 2 -> on ajoute 1 (qui est prioritaire) et on fait avancer f1
				else if (f1.Peek() == 1 && f2.Peek() == 2)
				{
					f3.Enqueue(f1.Dequeue());
				}
			}
			// copie des données restantes (1 et/ou 2 seulement) de la file non vide restante
			while (f1.Count > 0)
			{
				if (f1.Peek() == 1)
				{
					f3.Enqueue(f1.Dequeue());
				}
				else
				{
					f1.Dequeue();
				}
			}
			while (f2.Count > 0)
			{
				if (f2.Peek() == 2)
				{
					f3.Enqueue(f2.Dequeue());
				}
				else
				{
					f2.Dequeue();
				}
			}
			return f3;
		}
	}
	
	
	
	// Procédure : AfficherFileEntiers
	// Entrée :	- file : File<entier>
	// Sortie :	void
	public static void AfficherFileEntiers(Queue<int> file)
	{
		Console.Write("File : Tête <- ");
		foreach (int entier in file)
		{
			Console.Write(entier + " <- ");
		}
		Console.Write("Queue\n");
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		Queue<int> f1 = new Queue<int>();
		f1.Enqueue(0);
		f1.Enqueue(1);
		f1.Enqueue(1);
		f1.Enqueue(0);
		f1.Enqueue(1);
		Console.WriteLine("File f1");
		AfficherFileEntiers(f1);
		
		Queue<int> f2 = new Queue<int>();
		f2.Enqueue(0);
		f2.Enqueue(2);
		f2.Enqueue(2);
		f2.Enqueue(2);
		f2.Enqueue(0);
		f2.Enqueue(2);
		f2.Enqueue(0);
		Console.WriteLine("File f2");
		AfficherFileEntiers(f2);
		
		Queue<int> f3 = SimulerIntersection(f1, f2);
		Console.WriteLine("File f3");
		AfficherFileEntiers(f3);
	}
}
