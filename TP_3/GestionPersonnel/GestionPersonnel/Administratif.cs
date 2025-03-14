namespace GestionPersonnel.GestionPersonnel;

public class Administratif : Personnel
{
    public Administratif(int code, string nom, string prenom) : base(code, nom, prenom) {}
    public override double Calculer_Salaire()
    {
        return 15000;
    }
}