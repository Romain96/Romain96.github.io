// Auteur : Romain PERRIN

using System;
using System.Text;

class Bouteille
{
	static void Main()
	{
		// déclaration des constantes
		const double PRIX_UNITAIRE = 0.57;
		const double TAUX_LIVRAISON = 0.15;
		
		// déclaration des variables
		string nomClient;
		int nbBouteilles;
		double montant, livraison, total;
		
		// saisies
		Console.Write("Saisir le nom du client : ");
		nomClient = Console.ReadLine();
		
		Console.Write("Saisir le nombre de bouteilles : ");
		nbBouteilles = int.Parse(Console.ReadLine());
		
		// calculs
		montant = PRIX_UNITAIRE * nbBouteilles;
		livraison = montant * TAUX_LIVRAISON;
		total = montant + livraison;
		
		// affichage du résultat
		Console.OutputEncoding = Encoding.UTF8;
		Console.WriteLine("Client : " + nomClient);
		Console.WriteLine("Prix unitaire : " + PRIX_UNITAIRE + " €\n");
		Console.WriteLine("Montant : " + montant + " €");
		Console.WriteLine("Livraison (" + (TAUX_LIVRAISON * 100) + " %) : " + livraison + " €\n");
		Console.WriteLine("Total à régler : " + total + " €");
	}
}