using System.Text;

namespace Ex_2.CoffeeTracker;

public class Projet
{
    private string code;
    private string sujet;
    private int dureesemaine;
    private List<Programmeur> programmeurs;

    public Projet(string code, string sujet, int dureesemaine)
    {
        this.code = code;
        this.sujet = sujet;
        this.dureesemaine = dureesemaine;
        programmeurs = new List<Programmeur>();
    }

    public void AddProgrammeur(Programmeur programmeur)
    {
        programmeurs.Add(programmeur);
    }

    public Programmeur GetProgrammeur(string Code)
    {
        return programmeurs.Find(p => p.ID.Equals(Code, StringComparison.OrdinalIgnoreCase)) ?? throw new NullReferenceException("No such programmer with the code provided !\n");
    }

    public void AfficherProgrammeur(string Code)
    {
        try
        {
            Console.WriteLine(GetProgrammeur(Code).ToString());
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string AfficherListProgrammeurs()
    {
        if (programmeurs.Count == 0) return "Aucun programmeur n'est ajouté dans ce projet.\n";
        
        StringBuilder sb = new StringBuilder();
        sb.Append("\nAffichage de la liste des programmeurs pour ce projet :\n");
        sb.Append($"[\n");
        foreach (var p in programmeurs)
        {
            sb.AppendLine("\t" + p);
        }
        sb.Append("\n]\n");
        return sb.ToString();
    }

    public void RemoveProgrammeur(string Code)
    {
        // programmeurs.RemoveAll(p => p.ID.Equals(Code, StringComparison.OrdinalIgnoreCase));
        // OR
        try
        {
            programmeurs.Remove(GetProgrammeur(Code));
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void AjouterConsommation(ConsommationCafe consommationCafe, string CodeProgrammeur)
    {
        GetProgrammeur(CodeProgrammeur).AjouterCafe(consommationCafe);
    }

    public void AfficheConsommationParSemaine(int semaine)
    {
        Console.WriteLine("Total de consommation du cafe dans la semaine No " + semaine + " : "
                          + programmeurs.Sum(p=> p.GetTassesParSemaine(semaine)) + " tasses\n");
    }

    public override string ToString()
    {
        return $"Info du Projet :\ncode : {code} , sujet : {sujet} , dureesemine : {dureesemaine} \nprogrammeurs : {AfficherListProgrammeurs()}";
    }
}