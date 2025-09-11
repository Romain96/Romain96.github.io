// Auteur : Romain PERRIN

using System;

class Exercice7
{
	public static void Main()
	{
		// constantes
		const int I1 = 10;
		const double D2 = 67000.0;
		const double F3 = 20.6;
		// variables
		int a, b;
		double c, d;
		bool enRetard;
		
		a = 2204;
		b = 5;
		c = 1000;
		d = 200;
		enRetard = true;
		
		// conditions
		Console.WriteLine($"a == 2204 -> {a == 2204}");
		Console.WriteLine($"c >= F3-> {c >= F3}");
		Console.WriteLine($"a < 10 ET b <> D2 -> {a < 10 && b != D2}");
		Console.WriteLine($"a < 10 OU b <> D2 -> {a < 10 || b != D2}");
		Console.WriteLine($"b == 5 ET c == d -> {b == 5 && c == d}");
		Console.WriteLine($"b == 5 OU c == d -> {b == 5 || c == d}");
		Console.WriteLine($"NON(F3 > d) -> {!(F3 > d)}");
		Console.WriteLine($"enRetard -> {enRetard}");
		Console.WriteLine($"I1 < 20 ET NON(enRetard) -> {I1 < 20 && !enRetard}");
		Console.WriteLine($"c == 1000 OU (F3 == 68000 ET enRetard) -> {c == 1000 || (F3 == 68000 && enRetard)}");
		Console.WriteLine($"(c == 1000 ET F3 == 68000) OU enRetard -> {(c == 1000 && F3 == 68000) || enRetard}");
		Console.WriteLine($"c == 1000 ET F3 == 68000 OU NON(enRetard) -> {c == 1000 && F3 == 68000 || !enRetard}");
		Console.WriteLine($"c <> 1000 ET F3 <> 68000 OU NON(enRetard) -> {c != 1000 && F3 != 68000 || !enRetard}");
	}
}
