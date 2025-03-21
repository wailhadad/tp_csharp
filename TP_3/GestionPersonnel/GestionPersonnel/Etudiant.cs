namespace GestionPersonnel.GestionPersonnel;

public class Etudiant
{
    public int Code;
    public string Nom;
    public string Prenom;
    public string Niveau;
    public double Moyenne;

    public Etudiant(int code, string nom, string prenom, string niveau, double moyenne)
    {
        Code = code;
        Nom = nom;
        Prenom = prenom;
        Niveau = niveau;
        Moyenne = moyenne;
    }

    public string Afficher_etd()
    {
        return $"Etudiant: {Nom} {Prenom} | Niveau: {Niveau} | Moyenne: {Moyenne}";
    }

    public override string ToString()
    {
        return $"Etudiant: {Nom} {Prenom} | Niveau: {Niveau} | Moyenne: {Moyenne}";
    }
}