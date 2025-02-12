// Ce programme a été écrit en collaboration avec les étudiants du groupe TP5
// Auteur : Romain PERRIN
using System;

// Note concernant les commentaires XML
// Le texte entre les balises <summary>...</summary> donne une description de la fonction/procédure
// Les balises <param name="">...</param> permettent de nommer et de décrire un paramètre d'une fonction/procédure
// Il est important de bien mettre les mêmes noms que ceux des paramètres du code !
// ex : <param name="age">L'âge de l'utilisateur.</param>
//      public static void AfficheAge(int age)
// On peut référencer un paramètre nommé avec <param name="">...</param> en utilisant la balise unique <paramref name=""/>
// Les deux noms doivent correspondre ! 
// ex : <param name="age">L'âge de l'utilisateur.</param>
//      Lâge de l'utilisateur est contenu dans la variable <paramref name="age">.

// Les méthodes sont écrites dans l'ordre suivant : procédures, fonctions, Main
class SalaireRepresentant
{
    //-------------------------------------------------------------------------
    //                            PROCEDURES
    //-------------------------------------------------------------------------

    /**
    * <summary>Procédure de lecture d'un entier depuis le terminal.</summary>
    * <param name="msg">Le message à afficher à l'utilisateur.</param>
    * <returns>L'entier lu et convertit depuis le terminal.</returns>
    */
    public static int LireEntier(string msg)
    {
        Console.Write(msg);
        return int.Parse(Console.ReadLine());
    }

    /**
    * <summary>Procédure de lecture d'un nombre réel depuis le terminal.</summary>
    * <param name="msg">Le message à afficher à l'utilisateur.</param>
    * <returns>Le nombre réel lu et convertit en double depuis le terminal.</returns>
    */
    public static double LireDouble(string msg)
    {
        Console.Write(msg);
        return double.Parse(Console.ReadLine());
    }

    /**
    * <summary>Affichage d'un message textuel contenant un nombre réel sur le terminal.</summary>
    * <param name="prefixe">Le message préfixant <paramref name="nb"/>.</param>
    * <param name="nb">Le nombre réel à afficher après le <paramref name="prefixe"/>.</param>
    * <param name="suffixe">Le message suffixant <paramref name="nb"/>.</param>
    * <returns></returns>
    */
    public static void AfficherDouble(string prefixe, double nb, string suffixe)
    {
        Console.WriteLine(prefixe + nb + suffixe);
    }

    //-------------------------------------------------------------------------
    //                             FONCTIONS
    //-------------------------------------------------------------------------

    /**
    * <summary>Fonction de calcul de la prime en fonction du chiffre d'affaire.</summary>
    * <param name="ca">Le chiffre d'affaire ([0, +inf]).</param>
    * <returns>La valeur de la prime en euros en fonction de <paramref name="ca"/>.</returns>
    */
    public static double CalculePrimeChiffreAffaire(double ca)
    {
        // Si 0 <= CA < 3000 --> 0
        // Si 3000 <= CA < 5000 --> 90
        // Si 5000 <= CA < 10000 --> 180
        // Si CA >= 10000 --> 225
        double prime = 0.0;
        // remarque inutile de tester si ca < 3000
        // on ne rentre dans aucune condition et la prime reste de 0 euro
        if (ca >= 3000 && ca < 5000)
        {
            prime = 90.0;
        }
        else if (ca >= 5000 && ca < 10000)
        {
            prime = 180.0;
        }
        else if (ca >= 10000)
        {
            prime = 225.0;
        }
        return prime;
    }

    /**
    * <summary>Fonction de calcul des frais de déplacement en fonction de la puissance du véhicule et de la distance parcourue.</summary>
    * <param name="cv">La puissance du véhicule en CV.</param>
    * <param name="distance">La distance parcourue en km.</param>
    * <returns>La valeur des frais de déplacement en euros en fonction 
    * de <paramref name="cv"/> et <paramref name="distance"/>.</returns>
    */
    public static double CalculeFraisDeplacement(int cv, double distance)
    {
        // Si CV = [4,5] --> si distance <= 3000 0.25/km, sinon 0.23/km
        // Si CV =  [6,7] --> si distance <= 3000 0.30/km, sinon 0.27/km
        // Si CV = [8,9] --> si distance <= 3000 0.33/km, sinon 0.30/km
        // Si CV >= 10 --> si distance <= 3000 0.35/km, sinon 0.31/km
        double taux = 0.0;
        // remarque : les parenthèses sont nécessaires car le ET (&&) est prioritaire sur le OU (||) !
        // remarque : on peut faire des if imbriqués (tester CV puis distance ou l'inverse)
        // remarque : si CV est strictement inférieur à 4 alors la valeur retournée est 0 
        if ((cv == 4 || cv == 5) && distance <= 3000)
            taux = 0.25;
        else if ((cv == 4 || cv == 5) && distance > 3000)
            taux = 0.23;
        else if ((cv == 6 || cv == 7) && distance <= 3000)
            taux = 0.30;
        else if ((cv == 6 || cv == 7) && distance > 3000)
            taux = 0.27;
        else if ((cv == 8 || cv == 9) && distance <= 3000)
            taux = 0.33;
        else if ((cv == 8 || cv == 9) && distance > 3000)
            taux = 0.30;
        else if (cv >= 10 && distance <= 3000)
            taux = 0.35;
        else if (cv >= 10 && distance > 3000)
            taux = 0.31;
        return distance * taux;
    }

    /** <summary>Fonction de calcul de la prime exceptionnelle en fonction du nombre de nouveaux clients.</summary>
    * <param name="nb_clients">Le nombre de nouveaux clients (>= 0).</param>
    * <returns>La valeur de la prime exceptionnelle en euros en fonction de <paramref name="nb_clients"/>.</returns>
    */
    public static double CalculPrimeExceptionnelle(int nb_clients)
    {
        // 75 pour 1 nouveau client
        // 35 pour chaque nouveau client après le premier
        double prime = 0.0;
        // remarque : si nb_clients <= 0 alors la prime est de 0
        if (nb_clients > 0)
        {
            prime = 75 + (nb_clients - 1) * 35;
        }
        return prime;
    }

    /**
    * <summary>Fonction de calcul du salaire final en fonction du 
    * salaire de base, des primes et frais et des charges sociales.</summary>
    * <param name="salaire_base">Le salaire de base (fixe) en euros.</param>
    * <param name="ca">Le chiffre d'affaire en euros.</param>
    * <param name="cv">La puissance du véhicule en CV.</param>
    * <param name="distance">La distance parcourue en km.</param>
    * <param name="nb_clients">Le nombre de nouveaux clients.</param>
    * <param name="charges_sociales">Le taux des charges sociales en % ([0,100]).</param>
    * <returns>La valeur du salaire en euros en fonction de <paramref name="salaire_base"/>, 
    * <paramref name="prime_ca"/>,<paramref name="frais_deplacement"/>, 
    * <paramref name="prime_ex"/> et <paramref name="charges_sociales"/></returns>
    */
    public static double CalculeSalaire(
        double salaire_base, double ca, 
        int cv, double distance,
        int nb_clients, double charges_sociales
    )
    {
        // calculer la prime en fonction du chiffre d'affaire
        double prime_ca = CalculePrimeChiffreAffaire(ca);

        // calculer les frais de déplacement en fonction de la puissande du véhicule et de la distance
        double frais_deplacement = CalculeFraisDeplacement(cv, distance);

        // calculer la prime exceptionnelle en fonction du nombre de nouveaux clients
        double prime_exceptionnelle = CalculPrimeExceptionnelle(nb_clients);

        double salaire = salaire_base + prime_ca + frais_deplacement + prime_exceptionnelle;
        // remarque : x *= 2 est équivaut à x = x * 2
        // remarque : +=, -= et /= existent aussi
        salaire *= (100 - charges_sociales);
        salaire /= 100;
        return salaire;
    }

    //-------------------------------------------------------------------------
    //                               MAIN
    //-------------------------------------------------------------------------
    
    /**
    * <summary>Fonction principale du programme.</summary>
    */
    static void Main()
    {
        // constantes
        const double SALAIRE_BASE = 1500.0;
        const double CHARGES_SOCIALES = 4.25;

        // lire depuis le terminal : chiffre d'affaire, CV, distance, nb nouveaux clients
        double chiffre_affaire = LireDouble("entrez le chiffre d'affaire (euros) : ");
        int cv = LireEntier("Entrez la puissance du véhicule (CV) : ");
        double distance = LireDouble("Entrez la distance parcourue (km) : ");
        int nb_nouveaux_clients = LireEntier("Entrez le nombre de nouveaux clients : ");
        
        // calculer le salaire en fonction du salaire de base, de la prime au CA, 
        // des frais de déplacement, de la prime excxceptionnelle et des charges sociales
        double salaire = CalculeSalaire(
            SALAIRE_BASE, chiffre_affaire, cv, distance, 
            nb_nouveaux_clients, CHARGES_SOCIALES
        );
        
        // afficher le salaire
        AfficherDouble("Le salaire est de : ", salaire, " euros.");
    }
}