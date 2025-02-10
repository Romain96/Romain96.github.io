// Auteur : Romain PERRIN

using System;

public class Conway
{
	// Fonction : ChiffreEnCaractere
	// Précondition : 0 >= n <= 9
	// Entrée :		- n : entier
	// Local :		/
	// Sortie :		- caractère
	public static char ChiffreEnCaractere(int n)
	{
		switch (n)
		{
			case 0 : return '0';
			case 1 : return '1';
			case 2 : return '2';
			case 3 : return '3';
			case 4 : return '4';
			case 5 : return '5';
			case 6 : return '6';
			case 7 : return '7';
			case 8 : return '8';
			case 9 : return '9';
			default : throw new ArgumentException($"ChiffreEnCaractere : n doit être entre 0 et 9 (n = {n}).");
		};
	}

	// Fonction : ChiffreEnCaractere2
	// Précondition : 0 >= n <= 9
	// Entrée :		- n : entier
	// Local :		/
	// Sortie :		- caractère
	public static char ChiffreEnCaractere2(int n)
	{
		if (n < 0 || n > 9)
		{
			throw new ArgumentException($"ChiffreEnCaractere : n doit être entre 0 et 9 (n = {n}).");
		}
		return n.ToString()[0];
	}


	// Fonction : NombreApparitionsConsecutives
	// Entrée :		- chaine : chaîne de caractères
	//				- terme : caractère
	//				- indice : entier
	// Local :		- i : entier
	// Sortie :		- app : entier
	public static int NombreApparitionsConsecutives(string chaine, char terme, int indice)
	{
		int app = 0;
		for (int i = indice; i < chaine.Length && chaine[i] == terme; i++)
		{
			app++;
		}
		return app;
	}

	// Fonction : TermeSuivantConway
	// Entrée :		- termeCourant : chaîne de caractères
	// Local :		- nbApparitions : entier
	//				- nbApparitionsCaractere : caractère
	//				- chiffreCaractere : caractère
	// Sortie :		- termeSuivant : chaîne de caractères
	public static string TermeSuivantConway(string termeCourant)
	{
		string termeSuivant = "";
		int indice = 0;
		while (indice < termeCourant.Length)
		{
			int nbApparitions = NombreApparitionsConsecutives(termeCourant, termeCourant[indice], indice);
			char nbApparitionsCaractere = ChiffreEnCaractere2(nbApparitions);
			char chiffreCaractere = ChiffreEnCaractere2((int) termeCourant[indice] - (int) '0');
			termeSuivant += $"{nbApparitionsCaractere}{chiffreCaractere}";
			indice += nbApparitions;
		}
		return termeSuivant;
	}

	// Procédure : GenererSuiteConway
	// Précondition : n >= 0
	// Entrée :		- n : entier
	// Local :		- terme : chaîne de caractères
	//				- i : entier
	// Sortie :		void
	public static void GenererSuiteConway(int n)
	{
		if (n < 0)
		{
			throw new ArgumentException($"GenererSuiteConway : n doit être supérieur à 0 (n = {n}).");
		}
		string terme = "1";	// n = 0
		Console.WriteLine($"Conway(0) = {terme}");
		for (int i = 1; i <= n; i++)
		{
			terme = TermeSuivantConway(terme);
			Console.WriteLine($"Conway({i}) = {terme}");
		}
	}

	public static void Main()
	{
		Console.WriteLine("Suite de Conway.");
		Console.Write("Entrer n : ");
		int n = int.Parse(Console.ReadLine());
		GenererSuiteConway(n);
	}
}