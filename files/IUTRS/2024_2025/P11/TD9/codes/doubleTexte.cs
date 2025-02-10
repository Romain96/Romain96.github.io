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

		string FilePath = "testTexte.txt";  

		StreamWriter sw = new StreamWriter(FilePath);
		string str = number.ToString();  // Convertir le réel en string
		sw.WriteLine(str);  // Écrire la chaîne dans le fichier
		sw.Close();  // Indispensable !
		
		// Ouvrir le fichier en lecture
		StreamReader sr = new StreamReader(FilePath);
		string line;
		while ((line = sr.ReadLine()) != null)
        {
			Console.WriteLine("La chaîne de caractères lue est : " + line);
		}
		sr.Close();
  }
}