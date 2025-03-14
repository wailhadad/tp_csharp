namespace GestionPersonnel.GestionPersonnel;

public class RessourcesHumaines : IRessourcesHumaines
{
    private List<Personnel> GRH = new List<Personnel>();

    public void AjouterPersonnel(Personnel personnel)
    {
        GRH.Add(personnel);
    }
    
    public void Afficher_Enseignants()
    {
        var enseignats = GRH.OfType<Enseignant>().ToList();
        Console.WriteLine("Affichage de enseigants : \n");
        foreach (var enseignant in enseignats)
        {
            Console.WriteLine(enseignant);
        }
    }

    public int Rechercher_Ens(int code)
    {
        for (int i = 0; i < GRH.Count; i++)
        {
            if (GRH[i] is Enseignant && GRH[i].Code == code)
            {
                return i;
            }
        }
        return -1;
    }
}