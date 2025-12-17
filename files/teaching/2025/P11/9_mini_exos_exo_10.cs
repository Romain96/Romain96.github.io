// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

using static Exercice1;
using static Exercice2;
using static Exercice3;
using static Exercice4;
using static Exercice5;
using static Exercice6;
using static Exercice7;
using static Exercice8;
using static Exercice9;

// pour compiler : mcs exo_*.cs -main:Exercice10 -out:exo_10.exe

class Exercice10
{
	
	public static void Main()
	{
		string saisie;
		int choix;
		bool menu = true;
		
		while (menu)
		{
			// saisie blindée du choix de l'exercice
			do
			{
				do
				{
					Console.WriteLine("----------------------------------------");
					Console.WriteLine("Menu des exercices");
					Console.WriteLine("==================");
					Console.WriteLine("0 - Quitter");
					Console.WriteLine("1 - Exercice 1");
					Console.WriteLine("2 - Exercice 2");
					Console.WriteLine("3 - Exercice 3");
					Console.WriteLine("4 - Exercice 4");
					Console.WriteLine("5 - Exercice 5");
					Console.WriteLine("6 - Exercice 6");
					Console.WriteLine("7 - Exercice 7");
					Console.WriteLine("8 - Exercice 8");
					Console.WriteLine("9 - Exercice 9");
					Console.WriteLine("----------------------------------------");
					Console.Write("> Saisir le numéro de l'exercice à lancer : ");
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 1);
				choix = int.Parse(saisie);
			}
			while (choix < 0 || choix > 9);
			
			switch (choix)
			{
				case 1: 
					Console.Clear(); 
					Console.WriteLine("Exercice 1");
					Console.WriteLine("----------");
					Exercice1.Main(); 
					break;
				case 2: 
					Console.Clear(); 
					Console.WriteLine("Exercice 2");
					Console.WriteLine("----------");
					Exercice2.Main(); 
					break;
				case 3: 
					Console.Clear(); 
					Console.WriteLine("Exercice 3");
					Console.WriteLine("----------");
					Exercice3.Main(); 
					break;
				case 4: 
					Console.Clear(); 
					Console.WriteLine("Exercice 4");
					Console.WriteLine("----------");
					Exercice4.Main(); 
					break;
				case 5: 
					Console.Clear(); 
					Console.WriteLine("Exercice 5");
					Console.WriteLine("----------");
					Exercice5.Main(); 
					break;
				case 6: 
					Console.Clear(); 
					Console.WriteLine("Exercice 6");
					Console.WriteLine("----------");
					Exercice6.Main(); 
					break;
				case 7: 
					Console.Clear(); 
					Console.WriteLine("Exercice 7");
					Console.WriteLine("----------");
					Exercice7.Main(); 
					break;
				case 8: 
					Console.Clear(); 
					Console.WriteLine("Exercice 8");
					Console.WriteLine("----------");
					Exercice8.Main(); 
					break;
				case 9: 
					Console.Clear(); 
					Console.WriteLine("Exercice 9");
					Console.WriteLine("----------");
					Exercice9.Main(); 
					break;
				default : 
					menu = false; 
					break;
			}
		}
	}
}
