namespace Ex_1.Gestion_Employes;

public class Employee
{
    private string nom;
    private double salaire;
    private string poste;
    private DateTime dateEmbauche;

    public Employee(string nom, double salaire, string poste, DateTime dateEmbauche)
    {
        Nom = nom;
        Salaire = salaire;
        Poste = poste;
        DateEmbauche = dateEmbauche;
    }

    public string Nom
    {
        get => nom;
        set
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Nom));
            nom = value;
        }
    }

    public double Salaire
    {
        get => salaire;
        set
        {
            if(value <= 0) throw new ArgumentOutOfRangeException(nameof(Salaire));
            salaire = value;
        }
    }

    public string Poste
    {
        get => poste;
        set
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Poste));
            poste = value;
        }
    }

    public DateTime DateEmbauche
    {
        get => dateEmbauche;
        set
        {
            if(value > DateTime.Now) throw new ArgumentOutOfRangeException(nameof(DateEmbauche));
            dateEmbauche = value;
        }
    }

    public override string ToString()
    {
        return $"Employee Name: {Nom}, Salary : {Salaire}, Post : {Poste}, Date Embauche : {DateEmbauche}";
    }
    
}