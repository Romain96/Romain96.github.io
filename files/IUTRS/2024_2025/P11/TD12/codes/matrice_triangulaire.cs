// Auteur : Romain PERRIN

using System;

public class MatriceTriangulaire
{
	// Fonction : EstTriangulaireSuperieure
	// Entrée :		- matrice : tableau 2D d'entiers
	// Local :		- ligne, colonne : entiers
	// Sortie :		- booléen
	public static bool EstTriangulaireSuperieure(int[,] matrice)
	{
		// en partant du postulat que c'est vrai
		for (int ligne = 1; ligne < matrice.GetLength(0); ligne++)
		{
			for (int colonne = 0; colonne < ligne; colonne++)
			{
				if (matrice[ligne, colonne] != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Procédure : AfficherMatrice
	// Entrée :		- matrice : tableau 2D d'entiers
	// Local :		- ligne, colonne : entiers
	// Sortie :		void
	public static void AfficherMatrice(int[,] matrice)
	{
		for (int ligne = 0; ligne < matrice.GetLength(0); ligne++)
		{
			for (int colonne = 0; colonne < matrice.GetLength(1); colonne++)
			{
				Console.Write($"{matrice[ligne, colonne]}".PadRight(3, ' '));
			}
			Console.Write("\n");
		}
	}

	public static void Main()
	{
		int[,] matrice1 = new int[,] {
			{3, 1, 3, 0, 1, 0, 7}, 
			{0, 1, 2, 5, 0, 0, 1}, 
			{0, 0, 1, 1, 3, 1, 8}, 
			{0, 0, 0, 5, 1, 0, 5}, 
			{0, 0, 0, 0, 3, 1, 0}, 
			{0, 0, 0, 0, 0, 2, 1}, 
			{0, 0, 0, 0, 0, 0 ,4}
        };
		int[,] matrice2 = new int[,] {
			{3, 1, 3, 0, 1, 0, 7}, 
			{0, 1, 2, 5, 0, 0, 1}, 
			{0, 0, 1, 1, 3, 1, 8}, 
			{7, 0, 0, 5, 1, 0, 5}, 
			{0, 1, 0, 0, 3, 1, 0}, 
			{0, 0, 0, 0, 0, 2, 1}, 
			{0, 0, 8, 0, 0, 0 ,4}
        };

		Console.WriteLine("Matrice 1");
		AfficherMatrice(matrice1);
		Console.WriteLine($"La matrice est triangulaire supérieure : {EstTriangulaireSuperieure(matrice1)}.");

		Console.WriteLine("Matrice 2");
		AfficherMatrice(matrice2);
		Console.WriteLine($"La matrice est triangulaire supérieure : {EstTriangulaireSuperieure(matrice2)}.");

	}
}