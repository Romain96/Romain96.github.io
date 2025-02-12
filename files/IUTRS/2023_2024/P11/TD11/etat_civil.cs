// Auteur: Romain PERRIN

using System;
using System.Collections.Generic;

class ExerciceStructuresEtatCivil
{
    // Procédure : vérifie si un numéro de mois est correct et retourne le mois le plus proche dans le cas contraire
    // Paramètres :
    //  - mois (int): le numéro du mois
    // Retourne :
    //  - valide (int): le mois le plus proche dans l'intervalle [1,12]
    public static int VerifierValiditeMois(int mois)
    {
        int valide = mois;
        if (mois < 1)
            valide = 1;
        else if (mois > 12)
            valide = 12;
        return valide;
    }

    // Procédure : détermine si une année est bissextile ou non
    // Paramètres :
    //  - annee (int): l'année en question
    // Retourne :
    //  - (bool): vrai si `année` est bissextile, faux sinon
    public static bool EstBissextile(int annee)
    {
        if ((annee % 4 == 0 && annee % 100 != 0) || annee % 400 == 0)
            return true;
        return false;
    }

    // Procédure : retourne le nombre de jours dans un mois
    // Paramètres :
    //  - mois (int): le mois à considérer
    //  - annee (int): l'année à considérer
    // Retourne :
    //  - jours (int): le nombre de jours dans le mois `mois` de l'année `annee`
    public static int JoursDuMois(int mois, int annee)
    {
        int jours = 31;
        // vérification des paramètres
        mois = VerifierValiditeMois(mois);
        // calcul du nombre de jours
        if (mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12)
            jours = 30;
        if (mois == 2)
        {
            if (EstBissextile(annee))
                jours = 29;
            else
                jours = 28;
        }
        return jours;
    }

    // Procédure : vérifie si un numéro de jour est correct et retourne le numéro le plus proche dans le cas contraire
    // Paramètres :
    //  - jour (int): le numéro du jour
    //  - mois (int): le numéro du mois
    //  - annee (int): l'année à considérer
    // Retourne :
    //  - valide (int): le jour le plus proche dans l'intervalle [1,nb_jour_du_mois(mois,annee)]
    public static int VerifierValiditeJour(int jour, int mois, int annee)
    {
        int jours_du_mois = JoursDuMois(annee, mois);
        int valide = jour;
        if (jour < 1)
            valide = 1;
        else if (jour > jours_du_mois)
            valide = jours_du_mois;
        return valide;
    }

    // Structure : date (jour, mois et année)
    public struct EtatCivilDate
    {
        public int _jour;
        public int _mois;
        public int _annee;

        public EtatCivilDate(int jour, int mois, int annee)
        {
            _jour = VerifierValiditeJour(jour, mois, annee);
            _mois = VerifierValiditeMois(mois);
            _annee = annee;
        }
    }

    // Procédure : formattage de date (struct EtatCivilDate)
    // Paramètres :
    //  - date (EtatCivilDate): la date à afficher
    // Retourne :
    //  - fdate (string): la date `date` formattée sour la forme JJ/MM/AAAA
    public static string FormatterDate(EtatCivilDate date)
    {
        string fdate = "";
        fdate += $"{date._jour}/{date._mois}/{date._annee}";
        return fdate;
    }

    // Structure : représente l'Etat civil simplifié d'une personne
    public struct EtatCivil
    {
        public string _nom;
        public string _prenom;
        public EtatCivilDate _date_naissance;
        public string _lieu_naissance;
        public string _pere;
        public string _mere;

        public EtatCivil(
            string nom, string prenom, 
            EtatCivilDate date_naissance, string lieu_naissance, 
            string pere, string mere
        )
        {
            _nom = nom.ToUpper();
            _prenom = prenom;
            _date_naissance = date_naissance;
            _lieu_naissance = lieu_naissance;
            _pere = pere;
            _mere = mere;
        }
    }

    public static void AfficherEtatCivil(EtatCivil e)
    {
        Console.WriteLine($"ETAT CIVIL");
        Console.WriteLine($"{e._nom} {e._prenom}");
        Console.WriteLine($"né(e) le {FormatterDate(e._date_naissance)} à {e._lieu_naissance}");
        Console.WriteLine($"Père : {e._pere != "" ? e._pere : "N/A"}");
        Console.WriteLine($"Mère : {e._mere != "" ? e._mere : "N/A"}");
    }

    // Fonction : détermine l'état civil en fonction des informations complètes
    // Paramètres :
    //  - nom (string)
    //  - prenom (string)
    //  - date_naissance (EtatCivilDate) : date de naissance
    //  - lieu_naissance (string): lieu de naissance
    //  - pere (string): prénom du père
    //  - mere (string): prénom de la mère
    // Retourne : 
    //  - enfant (EtatCivil): l'Etat civil de l'enfant en fonction des informations transmises
    public static EtatCivil Enfant1(
        string nom, string prenom, 
        EtatCivilDate date_naissance, string lieu_naissance, 
        string pere, string mere
    )
    {
        return new EtatCivil(nom, prenom, date_naissance, lieu_naissance, pere, mere);
    }

    // Fonction : détermine l'état civil en fonction des informations partielles + des structures EtatCivil
    // Paramètres :
    //  - prenom (string)
    //  - date_naissance (EtatCivilDate) : date de naissance
    //  - lieu_naissance (string): lieu de naissance
    //  - pere (EtatCivil): Etat civil du père
    //  - mere (EtatCivil): Etat civil de la mère
    // Retourne : 
    //  - enfant (EtatCivil): l'Etat civil de l'enfant en fonction des informations transmises
    public static EtatCivil Enfant2(
        string prenom, 
        EtatCivilDate date_naissance, string lieu_naissance, 
        EtatCivil pere, EtatCivil mere
    )
    {
        return new EtatCivil(pere._nom, prenom, date_naissance, lieu_naissance, pere._prenom, mere._prenom);
    }

    static void Main()
    {
        EtatCivil jean = new EtatCivil("Dupont", "Jean", new EtatCivilDate(1, 5, 1965), "Paris", "", "");
        EtatCivil marie = new EtatCivil("Delmotte", "Marie", new EtatCivilDate(25, 9, 1967), "Lyon", "", "");
        AfficherEtatCivil(jean);
        AfficherEtatCivil(marie);
        EtatCivil albert = Enfant1("Dupont", "Albert", new EtatCivilDate(5, 7, 1985), "Strasbourg", "Jean", "Marie");
        AfficherEtatCivil(albert);
        EtatCivil jeanne = Enfant2("Jeanne", new EtatCivilDate(31, 12, 1989), "Obernai", jean, marie);
        AfficherEtatCivil(jeanne);
    }
}