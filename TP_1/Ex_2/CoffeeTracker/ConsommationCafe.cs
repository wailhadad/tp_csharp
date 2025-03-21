namespace Ex_2.CoffeeTracker;

public class ConsommationCafe
{
    private int nbrTasses;
    private int semaine ;
    private string programmeur ;

    public ConsommationCafe(int nbrTasses, int semaine, string programmeur)
    {
        NbrTasses = nbrTasses;
        Semaine = semaine;
        Programmeur = programmeur;
    }

    public int NbrTasses
    {
        get => nbrTasses;
        set
        {
            if (value < 0) throw new ArgumentException("NbrTasses cannot be negative");
            nbrTasses = value;
        }
    }

    public int Semaine
    {
        get => semaine;
        set
        {
            if (value < 0) throw new ArgumentException("Semaine doit etre > 0\n");
            semaine = value;
        }
    }

    public string Programmeur
    {
        get => programmeur;
        set
        {
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Programmeur cannot be null or empty");
            programmeur = value;
        }
    }

    public override string ToString()
    {
        return $"\t\tSemaine : {Semaine}, Programmeur : {programmeur}, Nbr Tasses : {NbrTasses}\n";
    }
}