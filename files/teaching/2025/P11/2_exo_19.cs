// Auteur : Romain PERRIN

using System;

class Exercice19
{
	public static void Main()
	{
		// constantes
		const float P1 = 2.0f;
		const float P2 = 1.0f;
		const float P3 = 0.5f;
		const float P4 = 0.2f;
		const float P5 = 0.1f;
		const float PRIX_UNITAIRE = 0.4f;	// en centimes
		const char STOP = 'n';
		const char CONTINUE = 'o';

		// variables
		bool saisieEnCours, rendreMonaie;
		float saisiePiece, totalPieces, aRendre;
		int nP1, nP2, nP3, nP4, nP5;	// nombre de pièces de P1, P2, P3, P4 et P5 à rendre
		string reponse;

		// saisir des pieces jusqu'à la fin de la saisie (n)
		saisieEnCours = true;
		totalPieces = 0;
		aRendre = 0;
		rendreMonaie = true;
		Console.WriteLine($"Prix à payer : {PRIX_UNITAIRE} €.");
		
		do
		{
			Console.Write("Insérez le montant de la pièce : ");
			saisiePiece = float.Parse(Console.ReadLine());
			
			if (saisiePiece == P1 || saisiePiece == P2 || saisiePiece == P3 || saisiePiece == P4 || saisiePiece == P5)
			{
					totalPieces = totalPieces + saisiePiece;
			}
			else
			{
				Console.WriteLine("Cette pièce n'est pas acceptée !");
			}
			
			do
			{
				Console.Write("Une autre pièce (o/n) ? ");
				reponse = Console.ReadLine();
			}
			while (reponse[0] != CONTINUE && reponse[0] != STOP);
			
			// stopper la saisie
			if (reponse[0] == STOP)
			{
				// vérifier si la somme à payer est atteinte sinon échec
				if (totalPieces >= PRIX_UNITAIRE)
				{
					rendreMonaie = true;
				}
				saisieEnCours = false;	// sortir de la boucle
			}
		}
		while (saisieEnCours);

		// si rendreMonaie est vrai calculer les pièces à rendre sinon message d'erreur et rendre la somme versée
		if (rendreMonaie)
		{
			Console.WriteLine("Distribution en cours... Je rends :");
			aRendre = totalPieces - PRIX_UNITAIRE;
		}
		else
		{
			Console.WriteLine("Distribution annulée... Je rends :");
			aRendre = totalPieces;
		}

		// rendre la monaie
		nP1 = (int) (aRendre / P1);
		aRendre = aRendre % P1;
		Console.WriteLine($"{nP1} pièce(s) de {P1} €");
		nP2 = (int) (aRendre / P2);
		aRendre = aRendre % P2;
		Console.WriteLine($"{nP2} pièce(s) de {P2} €");
		nP3 = (int) (aRendre / P3);
		aRendre = aRendre % P3;
		Console.WriteLine($"{nP3} pièce(s) de {P3} €");
		nP4 = (int) (aRendre / P4);
		aRendre = aRendre % P4;
		Console.WriteLine($"{nP4} pièce(s) de {P4} €");
		nP5 = (int) (aRendre / P5);
		aRendre = aRendre % P5;
		Console.WriteLine($"{nP5} pièce(s) de {P5} €");
	}
}
