using System;

class CalculTempsTrajetTrain
{
	public static void Main()
	{
		// variables
		int heureDepart = 0;
		int heureArrivee = 0;
		int minuteDepart = 0;
		int minuteArrivee = 0;
		int deltaMinutes = 0;
		int deltaHeures = 0;

		// saisie de la date de départ
		Console.Write("Entrez l'heure de départ [1-23] : ");
		heureDepart = int.Parse(Console.ReadLine());
		Console.Write("Entrez la minute de départ [1-59] :");
		minuteDepart = int.Parse(Console.ReadLine());

		// saisie de la date d'arrivée
		Console.Write("Entrez l'heure d'arrivée [1-23] : ");
		heureArrivee = int.Parse(Console.ReadLine());
		Console.Write("Entrez la minute d'arrivée [1-59] : ");
		minuteArrivee = int.Parse(Console.ReadLine());

		// calcul du trajet
		deltaHeures = heureArrivee - heureDepart - 1;
		deltaMinutes = minuteArrivee + (60 - minuteDepart);
		deltaHeures = deltaHeures + deltaMinutes / 60;
		deltaMinutes = deltaMinutes % 60;
		Console.WriteLine($"Départ {heureDepart}:{minuteDepart}, Arrivée {heureArrivee}:{minuteArrivee} : durée {deltaHeures}:{deltaMinutes}.");
	}
}
