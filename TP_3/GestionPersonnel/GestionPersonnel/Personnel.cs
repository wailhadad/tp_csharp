namespace GestionPersonnel.GestionPersonnel;

public abstract class Personnel
{
    public int Code;
    public string Nom;
    public string Prenom;

    protected Personnel(int code, string nom, string prenom)
    {
        Code = code;
        Nom = nom;
        Prenom = prenom;
    }

    public abstract double Calculer_Salaire();
}