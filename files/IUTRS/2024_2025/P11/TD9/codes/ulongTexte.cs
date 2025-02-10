// Auteur : Pierre Gançarski

using System;
using System.IO;
using System.Text;

class Program {
	static void Main()
	{
		// Déclarer l'entier et la chaîne de caractères à écrire
		ulong number = 8679950949494910836;

		string FilePath = "testTexte.txt";  

		StreamWriter sw = new StreamWriter(FilePath);
		string str = number.ToString();  // Convertir l'ulong en string
		sw.WriteLine(str);  // Écrire la chaîne dans le fichier
		sw.Close();  // Indispensable !
		
		// Ouvrir le fichier en lecture
		StreamReader sr = new StreamReader(FilePath);
		string line;
		while ((line = sr.ReadLine()) != null) { // Lire ligne par ligne
			Console.WriteLine("La chaîne de caractères lue est : " + line);
		}
		sr.Close(); 
  }
}