using System;

class HeureDansUneSeconde
{
	public static void Main()
	{
		// variables
		int heure = -1;
		int minute = -1;
		int seconde = -1;
		int resHeure = 0;
		int resMinute = 0;
		int resSeconde = 0;

		// saisie de l'heure courante
		while (heure < 0 || heure > 23)
		{
			Console.Write("Entrez l'heure courante [1-23] : ");
			heure = int.Parse(Console.ReadLine());
		}
		while (minute < 0 || minute > 59)
		{
			Console.Write("Entrez la minute courante [1-59] : ");
			minute = int.Parse(Console.ReadLine());
		}
		while (seconde < 0 || seconde > 59)
		{
			Console.Write("Entrez la seconde courante [1-59] : ");
			seconde = int.Parse(Console.ReadLine());
		}
		resHeure = heure;
		resMinute = minute;
		resSeconde = seconde;

		// calcul de l'heure à la seconde suivante en partant des secondes, puis des minutes, puis des heures
		if (seconde < 59)
		{
			resSeconde += 1;
		}
		else
		{
			resSeconde = 0;
			if (minute < 59)
			{
				resMinute += 1;
			}
			else
			{
				resMinute = 0;
				if (heure < 23)
				{
					resHeure += 1;
				}
				else
				{
					resHeure = 0;
				}
			}
		}
		Console.WriteLine($"Une seconde après {heure:D2}:{minute:D2}:{seconde:D2} il sera {resHeure:D2}:{resMinute:D2}:{resSeconde:D2}.");
	}
}
