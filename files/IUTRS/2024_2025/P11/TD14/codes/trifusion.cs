// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

public class ExoTriFusion
{
	// Fonction : Fusion
	// Précondition : f1 et f2 triées par ordre croissant
	// Entrée :		- f1 : file d'entiers
	//				- f2 : file d'entiers
	// Local :		/
	// Sortie :		- ftrie : file d'entiers
	public static Queue<int> Fusion(Queue<int> f1, Queue<int> f2)
	{
		Queue<int> ftrie = new Queue<int>();
		while (f1.Count > 0 && f2.Count > 0)
		{
			// ajout de la tête de f1 dans ftrie
			if (f1.Peek() < f2.Peek())
			{
				ftrie.Enqueue(f1.Dequeue());
			}
			// ajout de la tête de f2 dans ftrie
			else
			{
				ftrie.Enqueue(f2.Dequeue());
			}
		}
		// remplissage du reste (seulement l'un des deux est appliqué en pratique)
		while (f1.Count > 0)
		{
			ftrie.Enqueue(f1.Dequeue());
		}
		while (f2.Count > 0)
		{
			ftrie.Enqueue(f2.Dequeue());
		}
		return ftrie;
	}

	// Procédure : AfficherFile
	// Entrée :		- f : file d'entiers
	// Local :		- n : entier
	// Sortie :		void
	public static void AfficherFile(Queue<int> f)
	{
		Console.Write("File : { ");
		foreach (int n in f)
		{
			Console.Write($"{n} ");
		}
		Console.Write("}\n");
	}

	// Fonction : TriFusion
	// Entrée :		- f : file d'entiers
	// Local :		- prev : entier
	//				- ftemp : file d'entiers
	// Sortie :		- ftrie : file d'entiers
	public static Queue<int> TriFusion(Queue<int> f)
	{
		Queue<int> fres = new Queue<int>();
		if (f.Count == 0)
		{
			return fres;
		}
		int prev = f.Dequeue();
		fres.Enqueue(prev);
		// initialiser fres avec les premiers éléments triés
		while (f.Count > 0 && f.Peek() >= prev)
		{
			prev = f.Dequeue();
			fres.Enqueue(prev);
		}
		while (f.Count > 0)
		{
			// file temporaire avec les éléments triés suivants
			Queue<int> ftemp = new Queue<int>();
			prev = f.Dequeue();
			ftemp.Enqueue(prev);
			while (f.Count > 0 && f.Peek() >= prev)
			{
				prev = f.Dequeue();
				ftemp.Enqueue(prev);
			}
			// fusion des deux files
			fres = Fusion(fres, ftemp);
		}
		return fres;
	}

	public static void Main()
	{
		// Exo 1
		Queue<int> f1 = new Queue<int>();
		f1.Enqueue(5); f1.Enqueue(7); f1.Enqueue(8);
		Queue<int> f2 = new Queue<int>();
		f2.Enqueue(1); f2.Enqueue(7);
		AfficherFile(f1);
		AfficherFile(f2);
		Queue<int> ffusion = Fusion(f1, f2);
		Console.WriteLine("Fusion :");
		AfficherFile(ffusion);

		// Exo 2
		Queue<int> f3 = new Queue<int>();
		f3.Enqueue(503); f3.Enqueue(87); f3.Enqueue(512); f3.Enqueue(61);
		f3.Enqueue(908); f3.Enqueue(170); f3.Enqueue(897); f3.Enqueue(275);
		f3.Enqueue(653); f3.Enqueue(426); f3.Enqueue(154); f3.Enqueue(509);
		f3.Enqueue(612); f3.Enqueue(677); f3.Enqueue(765); f3.Enqueue(703);
		AfficherFile(f3);
		Console.WriteLine("Tri fusion :");
		Queue<int> f3trie = TriFusion(f3);
		AfficherFile(f3trie);
	}
}