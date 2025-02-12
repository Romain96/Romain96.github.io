// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class File
{
	// Procédure : affichage d'une file d'entiers
	// Paramètres :
	//	- file (Queue<int>): file d'entiers
	// Retourne : rien
	public static void AfficherFile(Queue<int> file)
	{
		foreach (int elt in file)
			Console.Write($"{elt} ");
		Console.Write("\n");
	}

	// Fonction : fusion et interclassement de deux files triées par ordre croissant 
	public static Queue<int> FusionFilesTriees(Queue<int> f1, Queue<int> f2)
	{
		Queue<int> res = new Queue<int>();
		while (f1.Count > 0 && f2.Count > 0)
		{
			if (f1.Peek() < f2.Peek())
			{
				res.Enqueue(f1.Dequeue());
			}
			else
			{
				res.Enqueue(f2.Dequeue());
			}
		}
		if (f1.Count > 0)
		{
			while (f1.Count > 0)
			{
				res.Enqueue(f1.Dequeue());
			}
		}
		else
		{
			while (f2.Count > 0)
			{
				res.Enqueue(f2.Dequeue());
			}
		}
		return res;
	}

	// Fonction : tri par fusion d'une file d'entiers non triés
	// Paramètres :
	//	- file (Queue<int>): file d'entiers
	// Retourne :
	//	- res (Queue<int>): file de même taille que `file` mais contenant les mêmes éléments triés dans l'ordre croissant
	public static Queue<int> TriFusion(Queue<int> file)
	{
		Queue<int> res = new Queue<int>();
		Queue<int> tmp = new Queue<int>();
		int prev;
		int cur;
		if (file.Count > 0)
		{
			// initialisation de res avec la première sous-file croissante
			prev = file.Dequeue();
			res.Enqueue(prev);
			while (file.Count > 0 && file.Peek() >= prev)
			{
				cur = file.Dequeue();
				res.Enqueue(cur);
				prev = cur;
			}

			// tant que la file n'est pas vide, recherche de première sous-file croissante, sauvegarde dans tmp et fusion avec res;
			while (file.Count > 0)
			{
				prev = file.Dequeue();
				tmp.Enqueue(prev);
				while (file.Count > 0 && file.Peek() >= prev)
				{
					cur = file.Dequeue();
					tmp.Enqueue(cur);
					prev = cur;
				}
				res = FusionFilesTriees(res, tmp);
			}
		}
		return res;
	}

	static void Main()
	{
		Queue<int> f1 = new Queue<int>(new int[]{5,7,8});
		Queue<int> f2 = new Queue<int>(new int[]{1,7});
		AfficherFile(f1);
		AfficherFile(f2);
		Queue<int> f = FusionFilesTriees(f1, f2);
		AfficherFile(f);

		Queue<int> f3 = new Queue<int>(new int[]{503,87,512,61,908,170,897,275,653,426,154,509,612,677,765,703});
		AfficherFile(f3);
		Queue<int> ff = TriFusion(f3);
		AfficherFile(ff);
	}
}
