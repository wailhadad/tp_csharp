namespace GestionPersonnel.GestionPersonnel;

public class Directeur : Personnel
{
    private static Directeur instance;
    public double PrimesDeplacement;

    public Directeur(int code, string nom, string prenom, double primesDeplacement) : base(code, nom, prenom)
    {
        this.PrimesDeplacement = primesDeplacement;
    }

    public static Directeur GetInstance(int code, string nom, string prenom, double primesDeplacement)
    {
        if (instance == null)
        {
            instance = new Directeur(code, nom, prenom, primesDeplacement);
        }
        else
        {
            throw new Exception("Il y a un seul directeur déjà instancié.\n");
        }
        return instance;
    }

    public override double Calculer_Salaire()
    {
        return 30000 + PrimesDeplacement;
    }
}