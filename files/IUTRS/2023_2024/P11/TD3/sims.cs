// Auteur : Romain PERRIN
// écrit en collaboration avec les étudiants du TP6 (2023/09/29)
using System;

class Sims
{
    // Procédure : Affiche dans le terminal le nombre d'années pour que Beta >= Alpha
    // Paramètres :
    //  - annees (int) : le nombre d'années calculé
    // Retourne : /
    public static void AfficheSims(int annees)
    {
        Console.WriteLine("Il faut " + annees + " années pour que Beta >= Alpha.");
    }

    // Fonction : Calcule le premier entier tel que beta(n) >= alpha(n)
    // Paramètres :
    //  - popBaseAlpha (int): la population de base pour Alpha
    //  - AdditionAlpha (int): l'augmentation brute pour Alpha
    //  - popBaseBeta (int): la population de base pour Beta
    //  - croissanceBeta (double): le taux de croissance pour Beta
    // Retourne :
    //  - annnes (int): le nombre d'années calculé
    public static int CalculerSims(
        int popBaseAlpha, int additionAlpha,
        int popBaseBeta, double croissanceBeta
    )
    {
        // Alpha(n) = popBaseAlpha + n * additionAlpha
        // Beta(n) = croissanceBeta * n + popBaseBeta
        // Tant que Beta(n) < Alpha(n) avancer
        // renvoyer la première valeur de n telle que Beta(n) >= Alpha(n)
        int annees = 0;
        double alpha = popBaseAlpha;
        double beta = popBaseBeta;
        while (beta < alpha)
        {
            // calculer les nouvelles valeurs de alpha et beta
            alpha += additionAlpha;
            beta += croissanceBeta * beta;
            // incrémenter le nombre d'années
            annees += 1;
        }
        return annees;
    }
    static void Main()
    {
        // définition de 4 constantes
        // Alpha : POP_BASE_ALPHA, CROISSANCE_ALPHA
        // Beta : POP_BASE_BETA, CROISSANCE_BETA
        const int POP_BASE_ALPHA = 10000000;
        const int POP_BASE_BETA = 5000000;
        const int ADDITION_ALPHA = 500000;
        const double CROISSANCE_BETA = 0.03;
        // calculer le nombre d'années neccessaire pour que Beta >= Alpha
        int annees = CalculerSims(
            POP_BASE_ALPHA, ADDITION_ALPHA, 
            POP_BASE_BETA, CROISSANCE_BETA
        );
        // Afficher le nombre d'années
        AfficheSims(annees);
    }
}