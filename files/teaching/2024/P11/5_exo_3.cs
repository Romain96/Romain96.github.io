using System;

// Auteur : Romain PERRIN

// structure Etudiant
public struct Etudiant
{
	public string nom;
	public string prenom;
	public int groupe;
	public double[] notes;
	public int nbNotes;
	public double moyenne;
}

class Etudiants
{
	public static void Main()
	{
		string xNom = "Albert";
		string xPrenom = "Einstein";
		int xGroupe = 1;
		const int xNombreNotes = 6;

		// 1) création d'un étudiant selon son nom, prénom et numéro de groupe
		// Principe : initialiser les champs renseignés, déclarer et initialiser le tableau des notes avec des 0
		// Entrée :
		// 	- xNom : entier
		// 	- xPrenom : entier
		// 	- xGroupe : entier
		// 	- xNombreNotes : entier
		// Local  :
		// 	- i : entier
		// Sortie :
		// 	- e1 : Etudiant
		Etudiant e1 = new Etudiant();
		e1.nom = xNom;
		e1.prenom = xPrenom;
		e1.groupe = xGroupe;
		e1.notes = new double[xNombreNotes];
		for (int i = 0; i < xNombreNotes; i++)
		{
			e1.notes[i] = 0.0;
		}
		e1.nbNotes = 0;
		e1.moyenne = 0.0;

		// 2) affichage d'un étudiant
		// Principe : afficher les champs et parcourir le tableau des notes pour les afficher
		// Préconditions : etudiant =/= null
		// Entrée :
		// 	- xEtudiant : Etudiant
		// 	- xnombreNotes : entier
		// Local  :
		//	- i : entier
		// Sortie : void
		Etudiant xEtudiant = e1;
		Console.WriteLine("-> Étudiant(e) : {0} {1} Groupe {2}", xEtudiant.prenom, xEtudiant.nom, xEtudiant.groupe);
		Console.Write("   notes : < ");
		for (int i = 0; i < xNombreNotes; i++)
		{
			Console.Write("{0:F2} ", xEtudiant.notes[i]);
		}
		Console.WriteLine("> moyenne {0:F2} ({1} notes renseignées).", xEtudiant.moyenne, xEtudiant.nbNotes);

		// 3) insérer la prochaine note d'un étudiant
		// Principe : insérer la note à la première position libre (champs nbNotes) et parcourir le tableau pour mettre à jour la moyenne sur les nbNotes+1 valeurs
		// Préconditions : etudiant =/= null
		// Entrée :
		// 	- xEtudiant : Etudiant
		// 	- xnombreNotes : entier
		// 	- xEntier : entier
		// Local  :
		//	- i : entier
		// Sortie : void
		double note = 10.0;
		if (xEtudiant.nbNotes < xNombreNotes)
		{
			xEtudiant.notes[xEtudiant.nbNotes] = note;
			xEtudiant.nbNotes += 1;
			xEtudiant.moyenne = 0.0;
			for (int i = 0; i < xEtudiant.nbNotes; i++)
			{
				xEtudiant.moyenne += xEtudiant.notes[i];
			}
			xEtudiant.moyenne = xEtudiant.moyenne / xEtudiant.nbNotes;
		}
		Console.WriteLine("-> Étudiant(e) : {0} {1} Groupe {2}.", xEtudiant.prenom, xEtudiant.nom, xEtudiant.groupe);
		Console.Write("   notes : < ");
		for (int i = 0; i < xNombreNotes; i++)
		{
			Console.Write("{0:F2} ", xEtudiant.notes[i]);
		}
		Console.WriteLine("> moyenne {0:F2} ({1} notes renseignées).", xEtudiant.moyenne, xEtudiant.nbNotes);

		// remplir 5 autres notes
		xEtudiant.notes[1] = 15.0;
		xEtudiant.notes[2] = 7.5;
		xEtudiant.notes[3] = 13.25;
		xEtudiant.notes[4] = 18.0;
		xEtudiant.notes[5] = 9.75;
		xEtudiant.moyenne = 0.0;
		xEtudiant.nbNotes = 6;
		for (int i = 0; i < xNombreNotes; i++)
		{
			xEtudiant.moyenne += xEtudiant.notes[i];
		}
		xEtudiant.moyenne = xEtudiant.moyenne / xEtudiant.nbNotes;
		
		// affichage
		Console.WriteLine("-> Étudiant {0} {1} Groupe {2}", xEtudiant.prenom, xEtudiant.nom, xEtudiant.groupe);
		Console.Write("   notes < ");
		for (int i = 0; i < xNombreNotes; i++)
		{
			Console.Write("{0:F2} ", xEtudiant.notes[i]);
		}
		Console.WriteLine("> moyenne {0:F2} ({1} notes renseignées).", xEtudiant.moyenne, xEtudiant.nbNotes);

		// initialisation des données pour les questions 4, 5, 6 et 7
		Etudiant etu1 = new Etudiant();
		etu1.nom = "Turing";
		etu1.prenom = "Alan";
		etu1.groupe = 1;
		etu1.notes = new double[] {12, 15.5, 17.5, 12, 10, 18};
		etu1.nbNotes = xNombreNotes;
		
		Etudiant etu2 = new Etudiant();
		etu2.nom = "Lovelace";
		etu2.prenom = "Ada";
		etu2.groupe = 1;
		etu2.notes = new double[] {14, 14, 15, 15, 16, 16};
		etu2.nbNotes = xNombreNotes;
		
		Etudiant etu3 = new Etudiant();
		etu3.nom = "Boole";
		etu3.prenom = "George";
		etu3.groupe = 1;
		etu3.notes = new double[] {18, 19, 20, 8, 10.5, 12};
		etu3.nbNotes = xNombreNotes;
		
		Etudiant etu4 = new Etudiant();
		etu4.nom = "Babbage";
		etu4.prenom = "Charles";
		etu4.groupe = 2;
		etu4.notes = new double[] {15, 15, 10, 5.5, 18, 19};
		etu4.nbNotes = xNombreNotes;
		
		Etudiant etu5 = new Etudiant();
		etu5.nom = "von Neumann";
		etu5.prenom = "John";
		etu5.groupe = 2;
		etu5.notes = new double[] {7.5, 14.75, 17.5, 18.25, 11.25, 9.75};
		etu5.nbNotes = xNombreNotes;
		
		Etudiant etu6 = new Etudiant();
		etu6.nom = "Créhange";
		etu6.prenom = "Marion";
		etu6.groupe = 2;
		etu6.notes = new double[] {12, 14, 18, 9.5, 11.25, 20};
		etu6.nbNotes = xNombreNotes;
		
		Etudiant[] promo = new Etudiant[6];
		promo[0] = etu1;
		promo[1] = etu2;
		promo[2] = etu3;
		promo[3] = etu4;
		promo[4] = etu5;
		promo[5] = etu6;
		
		// calcul des moyennes (on utiliserait normalement la fonction d'insertion qui maintient à jour la moyenne mais bon sans fonction...on fait ce qu'on peut)
		double moyenneEtudiant = 0.0;
		for (int indiceEtudiant = 0; indiceEtudiant < 6; indiceEtudiant++)
		{
			// calcul de la moyenne générale de l'étudiant(e) i
			moyenneEtudiant = 0.0;
			for (int indiceNote = 0; indiceNote < xNombreNotes; indiceNote++)
			{
				moyenneEtudiant += promo[indiceEtudiant].notes[indiceNote];
			}
			moyenneEtudiant = moyenneEtudiant / xNombreNotes;
			promo[indiceEtudiant].moyenne = moyenneEtudiant;
		}
		
		// 4) affichage des étudiants de la promotion
		Etudiant[] xPromo = promo;
		const int xTaillePromo = 6;
		// Principe : parcourir le tableau d'étudiants et afficher
		// Entrée :
		// 	- xPromo : tableau de xTaillePromo Etudiant
		// 	- xTaillePromo : entier
		// Local  :
		//	- i : entier
		// Sortie : void
		for (int i = 0; i < xTaillePromo; i++)
		{
			Console.WriteLine("-> Étudiant(e) : {0} {1} Groupe {2}", xPromo[i].prenom, xPromo[i].nom, xPromo[i].groupe);
			Console.Write("   notes : < ");
			for (int j = 0; j < xNombreNotes; j++)
			{
				Console.Write("{0:F2} ", xPromo[i].notes[j]);
			}
			Console.WriteLine("> moyenne {0:F2} ({1} notes renseignées).", xPromo[i].moyenne, xPromo[i].nbNotes);
		}

		// 5) calcul de la moyenne générale de la promo
		// Principe : parcourir le tableau d'étudiants et sommer la moyenne de chaque étudiant puis diviser par le nombre d'étudiants
		// Préconditions : tableau non vide et cases non nulles et chaque étudiant a xNombreNotes notes renseignées et un moyenne à jour
		// Entrée :
		// 	- xPromo : tableau de xTaillePromo Etudiant
		// 	- xTaillePromo : entier
		// Local  :
		//	- indiceEtudiant : entier
		// Sortie :
		//	- moyennePromo : réel
		double moyennePromo = 0.0;
		for (int indiceEtudiant = 0; indiceEtudiant < xTaillePromo; indiceEtudiant++)
		{
			moyennePromo += xPromo[indiceEtudiant].moyenne;
		}
		moyennePromo = moyennePromo / xTaillePromo;
		Console.WriteLine("-> La moyenne générale de la promo est de {0:F3}/20.", moyennePromo);
		
		// 6) calcul de la moyenne générale d'un groupe donné
		// Principe : parcourir le tableau d'étudiants et sommer la moyenne de chaque étudiant si son numéro de groupe correspond puis diviser par le nombre d'étudiants comptés
		// Préconditions : tableau non vide et cases non nulles et chaque étudiant a xNombreNotes notes renseignées et un moyenne à jour
		// Entrée :
		// 	- xPromo : tableau de xTaillePromo Etudiant
		// 	- xTaillePromo : entier
		// Local  :
		//	- indiceEtudiant : entier
		// 	- nbEtudiantsGroupe : entier
		// Sortie :
		//	- moyennePromo : réel
		int xIndiceGroupe = 1;
		double moyenneGroupe = 0.0;
		int nbEtudiantsGroupe = 0;
		for (int indiceEtudiant = 0; indiceEtudiant < xTaillePromo; indiceEtudiant++)
		{
			// calcul de la moyenne de l'étudiant(e) s'il fait partie du groupe i
			if (xPromo[indiceEtudiant].groupe == xIndiceGroupe)
			{
				moyenneGroupe += xPromo[indiceEtudiant].moyenne;
				nbEtudiantsGroupe += 1;
			}
		}
		if (nbEtudiantsGroupe == 0)
		{
			Console.WriteLine("-> Il n'y a pas d'étudiant dans le groupe {0} !", xIndiceGroupe);
		}
		else
		{
			moyenneGroupe = moyenneGroupe / nbEtudiantsGroupe;
			Console.WriteLine("-> La moyenne générale du groupe {0} est de {1:F3}/20.", xIndiceGroupe, moyenneGroupe);
		}
		
		xIndiceGroupe = 2;
		moyenneGroupe = 0.0;
		nbEtudiantsGroupe = 0;
		for (int indiceEtudiant = 0; indiceEtudiant < 6; indiceEtudiant++)
		{
			// calcul de la moyenne de l'étudiant(e) s'il fait partie du groupe i
			if (xPromo[indiceEtudiant].groupe == xIndiceGroupe)
			{
				moyenneGroupe += xPromo[indiceEtudiant].moyenne;
				nbEtudiantsGroupe += 1;
			}
		}
		if (nbEtudiantsGroupe == 0)
		{
			Console.WriteLine("-> Il n'y a pas d'étudiant dans le groupe {0} !", xIndiceGroupe);
		}
		else
		{
			moyenneGroupe = moyenneGroupe / nbEtudiantsGroupe;
			Console.WriteLine("-> La moyenne générale du groupe {0} est de {1:F3}/20.", xIndiceGroupe, moyenneGroupe);
		}
		
		// 7) recherche du major de promo pour chaque UE
		// Principe : parcourir les indices d'UE puis les indices d'étudiants. Pour chaque indice d'UE recherche l'étudiant ayant la note maximale à cet indice.
		// Préconditions : tableau non vide et cases non nulles et chaque étudiant a xNombreNotes notes renseignées
		// Entrée :
		// 	- xPromo : tableau de xTaillePromo Etudiant
		//	- xTaillePromo : entier
		// 	- xNombreNotes : entier
		// Local  :
		// 	- indiceUE : entier
		//	- indiceEtudiant : entier
		// 	- major : Etudiant
		// Sortie : void
		for (int indiceUE = 0; indiceUE < xNombreNotes; indiceUE++)
		{
			Etudiant major = xPromo[0];
			for (int indiceEtudiant = 1; indiceEtudiant < xTaillePromo; indiceEtudiant++)
			{
				if (xPromo[indiceEtudiant].notes[indiceUE] > major.notes[indiceUE])
				{
					major = xPromo[indiceEtudiant];
				}
			}
			Console.WriteLine("-> Major de l'UE {0} : {1} {2} (groupe {3}) avec une moyenne de {4:F3}/20.", indiceUE, major.prenom, major.nom, major.groupe, major.notes[indiceUE]);
		}
	}
}
