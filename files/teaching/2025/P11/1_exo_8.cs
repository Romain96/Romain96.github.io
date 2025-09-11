// Auteur : Romain PERRIN

using System;

class Exercice8
{
	public static void Main()
	{
		// constante
		const int MAJORITE = 18;
		
		// variables
		int age;
		
		// saisie des variables
		Console.Write("Saisir l'age : ");
		age = int.Parse(Console.ReadLine());
		
		// age invalide
		if (age < 0 || age > 122)
		{
			Console.WriteLine($"Erreur de saisie, l'age doit être entre 0 et 122 (valeur saisie {age}");
		}
		// age valide, affichage de majeur ou mineur
		else 
		{
			if (age < MAJORITE)
			{
				Console.WriteLine("Vous êtes mineur(e) !");
			}
			else
			{
				Console.WriteLine("Vous êtes majeur(e) !");
			}
		}
	}
}
