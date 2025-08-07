// Auteur : Romain PERRIN

using System;

class PremiersPasSuestion7
{
	// Procédure : AfficherChaine
	// Principe : Affiche un chaîne de caractères donnée dans la console
	// Précondition : /
	// Entrée :		- chaine : chaîne de caractères
	// Local :		/
	// Sortie :		void
	public static void AfficherChaine(string chaine)
	{
		Console.Write(chaine);
	}

	// Fonction : SaisirEntier
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- n : entier
	public static int SaisirEntier()
	{
		return int.Parse(Console.ReadLine());
	}

	// Procédure : TableMult
	// Principe : affiche la table de multiplication de l'entier donné
	// Précondition : /
	// Entrée :		/
	// Local :		- BORNE_INF : entier constant
	//				- BORNE_SUP : entier constant
	//				- i : entier
	// Sortie :		void
	public static void TableMult(int n)
	{
		const int BORNE_INF = 0;
		const int BORNE_SUP = 10;

		for (int i = BORNE_INF; i <= BORNE_SUP; i++)
		{
			AfficherChaine($"{i} x {n} = {i * n}\n");
		}
	}

	// Procédure principale
	public static void Main()
	{
		// saisir un entier puis appeler TableMult avec cet entier en paramètre
		AfficherChaine("Saisir un entier : ");
		int nombre = SaisirEntier();
		TableMult(nombre);
	}
}