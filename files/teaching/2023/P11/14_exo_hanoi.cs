// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

// Structure de tour : contient un nom et un pile de disques (numéros)
public struct Tour
{
	public string nom;
	public Stack<int> pile;
}

class ResolutionToursDeHanoi
{

	// structure : état des tours de Hanoi pour la résolution
	// contient : 
	// 	- un nombre de disques n (int)
	// 	- une tour dite source (Tour)
	// 	- une tour dite intermédiaire (Tour)
	// 	- une tour dite destination  (Tour)
	struct EtatHanoi
	{
		public int N;	// disques
		public Tour TourSrc, TourInt, TourDst;

		public EtatHanoi(int n, Tour source, Tour destination, Tour intermediaire)
		{
			N = n;
			TourSrc = source;
			TourInt = intermediaire;
			TourDst = destination;
		}
	}

	// Procédure : affichage d'un message textuel dans la console
	// Paramètres :
	// 	- msg (string): le message à afficher
	// Retourne : rien
	public static void AfficherChaine(string msg)
	{
		Console.WriteLine(msg);
	}	

	// Procédure : déplacement d'un disque d'une tour à une autre
	// Paramètres :
	// 	- src (Tour): tour de départ sur laquelle le disque se trouve
	// 	- dst (Tour): tour vers laquelle le disque doit être déplacé
	// Retourne : rien
	public static void DeplacerDisque(Tour src, Tour dst)
	{
		// seulement si le disque s'y trouve (la pile n'est pas vide)
		if (src.pile.Count > 0)
		{
			int disque = src.pile.Pop();	// dépiler
			// seulement si la pile est vide ou si le disque en sommet de pile n'est pas inférieur au disque à empiler
			if (dst.pile.Count == 0 || dst.pile.Peek() > disque)
			{
				dst.pile.Push(disque);
			}
			AfficherChaine($"Déplacement du disque {disque} de  la tour {src.nom} vers la tour {dst.nom}");
		}
		else
		{
			AfficherChaine($"Impossible de déplacer le disque, la tour {src.nom} est vide !");
		}
	}
	
	// Procédure : affichage des trois tours (horizontal)
	// Paramètres : 
	// 	- t1 (Tour): première tour à afficher
	//	- t2 (Tour): seconde tour à afficher
	//	- t3 (Tour): troisième tour à afficher
	// Retourne : rien
	public static void AfficherTours(Tour t1, Tour t2, Tour t3)
	{
		Console.Write($"Tour {t1.nom} :\t");
		foreach (int val in t1.pile)
			Console.Write($"{val}\t");
		Console.Write("\n");
		Console.Write($"Tour {t2.nom} :\t");
		foreach (int val in t2.pile)
			Console.Write($"{val}\t");
		Console.Write("\n");
		Console.Write($"Tour {t3.nom} :\t");
		foreach (int val in t3.pile)
			Console.Write($"{val}\t");
		Console.Write("\n");
	}

	// Fonction : résolution du problème de déplacement de tour de Hanoi
	// Paramètres :
	// 	- disques (int): nombre de disques considérés
	// 	- source (Tour): tour dite source
	// 	- destination (Tour): tour dite destination
	// 	- intermediaire (Tour): tour dite intermédiaire
	public static void ResolutionTourHanoi(int disques, Tour source, Tour destination, Tour intermediaire)
	{
		AfficherTours(source, intermediaire, destination);
		Stack<EtatHanoi> pile = new Stack<EtatHanoi>();
		pile.Push(new EtatHanoi(disques, source, destination, intermediaire));

		while (pile.Count > 0)
		{
			EtatHanoi etat_courant = pile.Pop();
			// dernier disque à deplacer --> dernière étape de résolution
			if (etat_courant.N == 1)
			{
				DeplacerDisque(etat_courant.TourSrc, etat_courant.TourDst);
				AfficherTours(source, intermediaire, destination);
			}
			// création des sous-problèmes à résoudre
			else
			{
				pile.Push(new EtatHanoi(etat_courant.N - 1, etat_courant.TourInt, etat_courant.TourDst, etat_courant.TourSrc));
				pile.Push(new EtatHanoi(1, etat_courant.TourSrc, etat_courant.TourDst, etat_courant.TourInt));
				pile.Push(new EtatHanoi(etat_courant.N - 1, etat_courant.TourSrc, etat_courant.TourInt, etat_courant.TourDst));
			}
		}
	}

	static void Main()
	{
		int disques = 5;
		Stack<int> s = new Stack<int>();
		for (int i = disques; i > 0; i--)
			s.Push(i);
		Tour source = new Tour();
		source.nom = "A";
		source.pile = s;
		Tour intermediaire = new Tour();
		intermediaire.nom = "B";
		intermediaire.pile = new Stack<int>();
		Tour destination = new Tour();
		destination.nom = "C";
		destination.pile = new Stack<int>();
		AfficherChaine($"Résolution de la Tour de Hanoi avec {disques} disques.");
		ResolutionTourHanoi(disques, source, destination, intermediaire);
	}
}
