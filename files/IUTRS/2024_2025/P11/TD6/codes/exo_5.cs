// Auteur : Romain PERRIN

using System;

class Exercice5
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

	// Fonction : SaisirReel
	// Précondition : /
	// Entrée :		/
	// Local :		/
	// Sortie :		- chaine : réel
	public static double SaisirReel()
	{
		return double.Parse(Console.ReadLine());
	}

	// Procédure : AfficherTableauReel1D
	// Principe : Affiche un tableau de réels 1D dans la console
	// Précondition : /
	// Entrée :		- tab : tableau 1D de réels
	// Local :		- i : entier
	//				- j : entier
	// Sortie :		void
	public static void AfficherTableauReel1D(double[] tab)
	{
		AfficherChaine("Tableau < ");
		for (int i = 0; i < tab.Length; i++)
		{
			AfficherChaine($"{tab[i]} ");
		}
		AfficherChaine(">\n");
	}

	// Fonction : NbBonnesNotes
	// Principe : parcourir le tableau et pour chaque case, si la valeur est supérieure ou égale au seuil, compter +1. retourner le compteur.
	// Précondition : /
	// Entrée :		- notes : tableau 1D de réels
	// Local :		- i : entier
	// Sortie :		- n : entier
	public static int NbBonnesNotes(double[] notes, double seuil)
	{
		int n = 0;
		for (int i = 0; i < notes.Length; i++)
		{
			if (notes[i] >= seuil)
			{
				n++;
			} 
		}
		return n;
	}

	// Procédure : Ecart
	// Principe : créé un tableau 1D de même taille que celui donné en paramètre. Parcourir les cases du tableau en entrée et pour chacune, 
	// stocker dans le nouveau tableau au même indice, la différence entre le seuil et la valeur dans le tableau.
	// Précondition : /
	// Entrée :		- notes : tableau 1D de réels
	//				- seuil : réel
	// Local :		- i : entier
	//				- ecarts : tableau 1D de réels de même taille que notes
	// Sortie :		void
	public static void Ecart(double[] notes, double seuil)
	{
		double[] ecarts = new double[notes.Length];
		for (int i = 0; i < notes.Length; i++)
		{
			ecarts[i] = Math.Abs(seuil - notes[i]);
		}
		AfficherTableauReel1D(ecarts);
	}


	// Procédure principale
	public static void Main()
	{
		// données
		double[] pTab = new double[]{7.5, 18.25, 15.0, 14.75, 13.75, 9.5, 5.5, 12.5, 13.0, 13.5, 14.75, 18.50, 20.0, 19.5, 1.25, 0.0, 11.25, 4.5};
		AfficherChaine("Notes : \n");
		AfficherTableauReel1D(pTab);

		//  saisir un réel, appeler la fonction NbBonnesNotes avec cet argument et afficher le résultat
		AfficherChaine("Saisir un seuil entre 0 et 20 :");
		double seuilUtilisateur = SaisirReel();
		int bonnesNotes = NbBonnesNotes(pTab, seuilUtilisateur);
		AfficherChaine($"Il y a {bonnesNotes} notes supérieures à {seuilUtilisateur}.\n");

		// écarts par rapport au seuil
		AfficherChaine($"Les écarts par rapport au seuil {seuilUtilisateur} :\n");
		Ecart(pTab, seuilUtilisateur);
	}
}