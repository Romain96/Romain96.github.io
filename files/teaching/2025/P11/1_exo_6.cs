// Auteur : Romain PERRIN

using System;

class Exercice6
{
	public static void Main()
	{
		// constantes
		const double PRIX_TOTAL_TTC = 17.30;
		const double PRIX_SUPPORT_TTC = 0.20;
		const double TAUX_TVA = 0.10;
		// variables
		double totalHT, montantTVA, prixUnitaireTicketHT, prixTotalTicketHT, prixSupportHT;
		
		// calcul du total HT
		totalHT = PRIX_TOTAL_TTC / (TAUX_TVA + 1);
		montantTVA = PRIX_TOTAL_TTC - totalHT;
		
		// calcul du support HT
		prixSupportHT = PRIX_SUPPORT_TTC / (TAUX_TVA + 1);
		
		// calcul du total des tickets HT et du prix unitaire
		prixTotalTicketHT = totalHT - prixSupportHT;
		prixUnitaireTicketHT = prixTotalTicketHT / 10;
		
		// Affichage
		Console.WriteLine($"Support : {prixSupportHT} € HT");
		Console.WriteLine($"Tickets : 10 x {prixUnitaireTicketHT} = {prixTotalTicketHT} € HT");
		Console.WriteLine($"Montant TVA ({TAUX_TVA * 100} %) : {montantTVA} €");
		Console.WriteLine($"Total : {PRIX_TOTAL_TTC} € TTC");
	}
}
