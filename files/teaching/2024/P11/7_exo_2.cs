// auteur : Romain PERRIN
// notes : utiliser BigInteger pour Factorielle et PParmiN sinon le résultat de la factorielle est faux pour des paramètres de 49 et 50
// remarque : pour la compilation, lancer la commande 'mono exo_2.cs -r:System.Numerics.dll'

using System;
using System.Numerics;

class Lotterie
{
	// Fonction : Factorielle
	// Précondition : n >= 0
	// Entrée :		- n : entier
	// Local :		- i : entier
	// Sortie :		- fact : entier
	public static BigInteger Factorielle(int n)
	{
		BigInteger fact = 1;
		for (BigInteger i = 2; i <=  (BigInteger) n; i++)
		{
			fact = fact * i;
		}
		return fact;
	}

	// Fonction : PParmiN
	// Principe : calcule la probabilité d'obtenir P bon numéros parmi N boules en utilisant la formule proba = N! / (P! * (N-P)!)
	// Précondition : p > 0, N > 0
	// Entrée :		- P : entier
	//				- N : entier
	// Local :		/
	// Sortie :		- proba : entier
	public static BigInteger PParmiN(int p, int n)
	{
		BigInteger proba = Factorielle(n) / (Factorielle(p) * Factorielle(n - p));
		return proba;
	}

	// Fonction : ProbaRang1Loto
	// Principe : calcule la probabilité de gagner au rang 1 au Loto (5 bons numéros parmi 49 + 1 bon numéro chance parmi 10)
	// Entrée :		/
	// Local :		/
	// Sortie :		- proba : entier
	public static BigInteger ProbaRang1Loto()
	{
		BigInteger proba = PParmiN(5, 49) * PParmiN(1, 10);
		return proba;
	}

	// Fonction : ProbaRang1Euromillions
	// Principe : calcule la probabilité de gagner au rang 1 à l'Euromillions (5 bons numéros parmi 50 + 2 bons numéros chance parmi 12)
	// Entrée :		/
	// Local :		/
	// Sortie :		- proba : entier
	public static BigInteger ProbaRang1Euromillions()
	{
		BigInteger proba = PParmiN(5, 50) * PParmiN(2, 12);
		return proba;
	}
	
	public static void Main()
	{
		BigInteger probaLoto = ProbaRang1Loto();
		BigInteger probaEuromillions = ProbaRang1Euromillions();
		if (probaLoto > probaEuromillions)
		{
			Console.WriteLine($"Probabilité de gagner au Loto 1/{probaLoto} < probabilité de gagner à l'Euromillions 1/{probaEuromillions}.");
		}
		else if (probaLoto < probaEuromillions)
		{
			Console.WriteLine($"Probabilité de gagner au Loto 1/{probaLoto} > probabilité de gagner à l'Euromillions 1/{probaEuromillions}.");
		}
		else
		{
			Console.WriteLine($"Probabilité de gagner au Loto 1/{probaLoto} = probabilité de gagner à l'Euromillions 1/{probaEuromillions}.");
		}
	}
}