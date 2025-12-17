// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

// chaîne à tester : rèilp tciuovuah,uemertam ’j )niiaomuF ! te éF P elll tnd etrepsemi tusaot ( sroC da’J uchc siellbaet ayéssiiuu
// résultat : J’adore le Chablis certes (pas du tout chauvin), mais j’aime tout particulièrement le Pouilly Fuissé et Fumé!

class Exercice6
{
	// Fonction : RechercherMultiplesLongueur
	// Entrée :	- chaine : chaîne de caractères
	// Sortie : Liste<entier>
	public static List<int> RechercherMultiplesLongueur(string chaine)
	{
		List<int> multiples = new List<int>();
		
		for (int i = 1; i < chaine.Length - 1; i++)
		{
			if (chaine.Length % i == 0)
			{
				multiples.Add(i);
			}
		}
		
		return multiples;
	}
	
	
	// Fonction : EchangerBlocsChaine
	// Entrée :	- chaine : chaîne de caractères
	//			- taille : entier (longueur des blocs à échanger)
	// Sortie :	chaîne de caractères
	public static string EchangerBlocsChaine(string chaine, int taille)
	{
		string reponse = "";
		Console.WriteLine("> encodage de " + chaine + " avec une longueur de bloc de " + taille);
		
		int i = 0;
		while (i + taille * 2 <= chaine.Length)
		{
			string bloc1 = chaine.Substring(i, taille);
			string bloc2 = chaine.Substring(i + taille, taille);
			Console.WriteLine("> > échange des blocs '" + bloc1 + "' et '" + bloc2 + "'");
			reponse = reponse + bloc2 + bloc1;
			i += taille * 2;
		}
		// copier la partie restante si échange non possible
		if (reponse.Length < chaine.Length)
		{
			reponse = reponse + chaine.Substring(i);
		}
		
		Console.WriteLine("> chaine encodée : " + reponse);
		return reponse;
	}
	
	
	// Fonction : EncoderChaineMultiples
	// Entrée :	- chaine : chaîne de caractères
	//			- multiples : Liste<entier>
	// Sortie :	chaîne de caractères
	public static string EncoderChaineMultiples(string chaine, List<int> multiples)
	{
		string encodee = chaine;
		
		foreach (int multiple in multiples)
		{
			encodee = EchangerBlocsChaine(encodee, multiple);
		}
		
		return encodee;
	}
	
	
	// Fonction : DecoderChaineMultiples
	// Entrée :	- chaine : chaîne de caractères
	//			- multiples : Liste<entier>
	// Sortie : chaîne de caractères
	public static string DecoderChaineMultiples(string chaine, List<int> multiples)
	{
		string decodee = chaine;
		
		multiples.Reverse();
		foreach (int multiple in multiples)
		{
			decodee = EchangerBlocsChaine(decodee, multiple);
		}
		
		return decodee;
	}
	
	
	public static void Main()
	{
		// menu encoder-décoder
		bool menu = true;
		string saisie = "";
		int choix = 0;
		
		while (menu)
		{
			do
			{
				do
				{
					Console.WriteLine("Menu - Encodage décodage mystère");
					Console.WriteLine("--------------------------------");
					Console.WriteLine("0 - Quitter");
					Console.WriteLine("1 - encoder une chaîne");
					Console.WriteLine("2 - décoder une chaîne");
					Console.WriteLine("--------------------------------");
					Console.Write("\nChoix : ");
					saisie = Console.ReadLine();
				}
				while (saisie.Length < 1);
				choix = int.Parse(saisie);
			}
			while (choix < 0 || choix > 2);
			
			switch (choix)
			{
				// encoder une chaîne
				case 1: 
					string chaineAEncoder = "";
					do
					{
						Console.WriteLine("Saisir une chaîne à encoder : ");
						chaineAEncoder = Console.ReadLine();
					}
					while (chaineAEncoder.Length < 1);
					List<int> multiplesEncodage = RechercherMultiplesLongueur(chaineAEncoder);
					string chaineEncodee = EncoderChaineMultiples(chaineAEncoder, multiplesEncodage);
					Console.WriteLine("La chaîne encodée est : " + chaineEncodee);
					break;
				
				// décoder une chaine
				case 2:
					string chaineADecoder = "";
					do
					{
						Console.Write("Saisir une chaîne à décoder : ");
						chaineADecoder = Console.ReadLine();
					}
					while (chaineADecoder.Length < 1);
					Console.WriteLine("longueur à décoder " + chaineADecoder.Length);
					List<int> multiplesDecodage = RechercherMultiplesLongueur(chaineADecoder);
					Console.WriteLine("multiples " + multiplesDecodage.Count);
					string chaineDecodee = DecoderChaineMultiples(chaineADecoder, multiplesDecodage);
					Console.WriteLine("La chaîne décodée est : " + chaineDecodee);
					break;
				
				// quitter
				default:
					menu = false;
					break;
			}
		}
	}
}
