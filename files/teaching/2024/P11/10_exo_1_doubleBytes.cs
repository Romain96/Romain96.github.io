// Auteur : Romain PERRIN

using System;
using System.IO;
using System.Text;

class Program
{
	static void Main()
	{
		// Déclarer le réel
		double number = 3.14159265358979;
		
		// Ouvrir le fichier en mode écriture seule
		FileStream fs = new FileStream("test.bin", FileMode.Create, FileAccess.Write);

		// Écrire le réel
		byte[] numberBytes = BitConverter.GetBytes(number);
		fs.Write(numberBytes, 0, numberBytes.Length);
		fs.Close();  // Indispensable !

		// Ouvrir le fichier en mode lecture seule
		FileStream fsR = new FileStream("test.bin", FileMode.Open, FileAccess.Read);

		// Lire la chaîne de caractères
		byte[] strBytesR = new byte[8];
		fsR.Read(strBytesR, 0, strBytesR.Length);
		string readStrR = Encoding.ASCII.GetString(strBytesR);
		
		// Afficher l'entier et la chaîne de caractères lus
		Console.WriteLine("La chaîne de caractères lue est : " + readStrR);
		fsR.Close();
  }
}