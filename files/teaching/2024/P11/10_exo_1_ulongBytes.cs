// Auteur : Pierre Gançarski

using System;
using System.IO;
using System.Text;

class Program {
	static void Main()
	{
		// Déclarer l'entier et la chaîne de caractères à écrire
		ulong number = 8679950949494910836;
		
		// Ouvrir le fichier en mode écriture seule
		FileStream fs = new FileStream("test.bin", FileMode.Create, FileAccess.Write);

		// Écrire l'entier
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