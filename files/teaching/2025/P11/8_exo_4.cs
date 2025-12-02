// Auteur : Romain PERRIN

using System;
using System.Collections.Generic;

class Exercice4
{
	// Fonction : EvaluerExpression
	// Entrée :	- expression : chaîne de caractères
	//			- variables : Dictionnaire<caractère, réel>
	// Sortie :	réel
	public static double EvaluerExpression(string expression, Dictionary<char, double> variables)
	{
		Stack<double> pile = new Stack<double>();
		
		foreach (char caractere in expression)
		{
			// évaluer la sous-expression
			if (caractere == '+' || caractere == '-' || caractere == '*' || caractere == '/')
			{
				double v1 = pile.Pop();
				double v2 = pile.Pop();
				
				if (caractere == '+')
				{
					pile.Push(v1 + v2);
				}
				else if (caractere == '-')
				{
					pile.Push(v1 - v2);
				}
				else if (caractere == '*')
				{
					pile.Push(v1 * v2);
				}
				else if (caractere == '/')
				{
					pile.Push(v1 / v2);
				}
			}
			// empiler les variables
			else
			{
				pile.Push(variables[caractere]);	// empiler la valeur de la variable 'caractere'
			}
		}
		
		return pile.Peek();
	}
	
	
	// Algorithme principal
	public static void Main()
	{
		Console.Write("Saisir une expression post-fixée : ");
		string saisie = Console.ReadLine();
		
		List<char> nomsVariables = new List<char>() {'a', 'b', 'c'};
		Dictionary<char, double> variables = new Dictionary<char, double>();
		
		
		foreach (char nomVariable in nomsVariables)
		{
			string saisieValeur = "";
			double valeur = 0.0;
			
			do
			{
				Console.Write("Saisie une valeur pour " + nomVariable + " : ");
				saisieValeur = Console.ReadLine();
			}
			while (saisieValeur.Length < 1);
			valeur = double.Parse(saisieValeur);
			
			variables.Add(nomVariable, valeur);
		}
		
		Console.WriteLine("Résultat : " + EvaluerExpression(saisie, variables));
	}
}
