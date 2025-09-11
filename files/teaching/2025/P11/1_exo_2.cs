// Auteur : Romain PERRIN

using System;

class Exercice2
{
	public static void Main()
	{
		// constantes
		const int CAP_SP = 10;	// capacité du sean en plastique
		const int CAP_SB = 7;	// capacité du sean en bois
		const int CAP_SF = 9;	// capacité du sean en fer
		
		// variables
		int seauP, seauB, seauF, temp;
		
		// 10h00
		seauP = 0;
		seauB = 0;
		seauF = 0;
		
		// 10h05
		seauB = 6;
		
		// 10h10
		seauF = 6;
		seauB = 0;
		
		// 10h15
		seauP = CAP_SP;
		
		// 10h20
		seauP = seauP - (seauP / 2);
		
		// 10h25
		seauB = seauP;
		seauP = 0;
		
		// 10h30
		temp = CAP_SF - seauF;	// quantité disponible dans le seau en fer
		seauF = seauF + temp;
		seauB = seauB - temp;
		
		// 10h35
		Console.WriteLine($"Le seau en plastique contient {seauP} litre(s).");
		Console.WriteLine($"Le seau en bois contient {seauB} litre(s).");
		Console.WriteLine($"Le seau en fer contient {seauF} litre(s).");
		
	}
}
