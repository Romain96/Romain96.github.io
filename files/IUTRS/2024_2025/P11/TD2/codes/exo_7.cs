// Auteur : Romain PERRIN

using System;

class DevinerNombreAletoire
{
	// Principe : Générer un nombre alétoire entre 1 et 100.
	// Tant que le nombre n'a pas été trouvé et que le nombre de tentative est inférieure à 10,
	// demander un entier, vérifier s'il s'agit du nombre et s'arrêter ou indiquer si le 
	// nombre est inférieur ou supérieur à celui renseigné.
	public static void Main()
	{
		// variables
		int nombre = 0;	// nombre à trouver
		int nombreUtilisateur = 0;	// nombre saisi par l'utilisateur
		const int TENTATIVES_MAX = 10;	// nombre maximal de tentatives autorisée avant d'échouer
		const int BORNE_INF = 1;	// borne inférieure de l'intervalle de génération du nombre
		const int BORNE_SUP = 100;	// borne supérieure de l'intervalle de génération du nombre
		bool trouve = false;	// indique si le nombre a été trouvé par l'utilisateur
		int tentative = 1;	// indice de la tentative actuelle
		int indiceTentative = 0;	// nombre de tentatives utilisées par l'utilisateur

		// générer un nombre alétoire entre 0 et 100
		Random generateur = new Random();   // instanciation du générateur pseudo-aléatoire
		nombre = generateur.Next(BORNE_INF, BORNE_SUP + 1);

		// boucle de jeu
		while (tentative <= TENTATIVES_MAX && trouve == false)
		{
			// saisir un entier
			Console.Write("Devinez le nombre entre {0} et {1} : ", BORNE_INF, BORNE_SUP);
			nombreUtilisateur = int.Parse(Console.ReadLine());

			// vérifier les conditions de victoire
			if (nombreUtilisateur < nombre)
			{
				Console.WriteLine("Plus grand !");
			}
			else if (nombreUtilisateur > nombre)
			{
				Console.WriteLine("Plus petit !");
			}
			// aka nombreUtilisateur == nombre
			else
			{
				indiceTentative = tentative;
				trouve = true;
			}
			tentative++;
		}

		// affichage du résultat (victoire en X tentatives ou défaite le nombre était Y)
		if (trouve)
		{
			Console.WriteLine($"Félicitations, vous avez trouvé le nombre en {indiceTentative} tentative(s) !");
		}
		else
		{
			Console.WriteLine($"Désolé, vous avez écoulé vos {TENTATIVES_MAX} tentatives ! Le nombre était {nombre}.");
		}
	}
}
