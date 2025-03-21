using System.Diagnostics;
using System.Text;

namespace Ex_2.CoffeeTracker;

public class Programmeur
{
    private string id;
    private string nom;
    private string prenom;
    private string bureau;
    private List<ConsommationCafe> HistoriqueCafes;

    public Programmeur(string id, string nom, string prenom, string bureau)
    {
        HistoriqueCafes = new List<ConsommationCafe>();
        ID = id;
        Nom = nom;
        Prenom = prenom;
        Bureau = bureau;
    } 
    public string ID 
    {
        get => id; 
        set
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(id));
            id = value;
        }
    }
    public string Nom 
    {
        get => nom; 
        set{
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(nom));
            nom = value; 
        }  
    }
    public string Prenom 
    {
        get => prenom; 
        set{
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(prenom));
            prenom = value;
        }
    }
    public string Bureau 
    {
        get => bureau; 
        set{
            if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(bureau));
            bureau = value;
        }
    }

    public List<ConsommationCafe> historiqueCafes
    {
        get => HistoriqueCafes;
        set => HistoriqueCafes = value;
    }

    public void AjouterCafe(ConsommationCafe cafe)
    {
        HistoriqueCafes.Add(cafe);
    }

    public int GetTassesParSemaine(int semaine)
    {
        return historiqueCafes.Where(c => c.Semaine == semaine).Sum(c => c.NbrTasses);
    }

    public string consommationDuCafe()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("[");
        foreach (var c in historiqueCafes )
        {
            sb.Append(c);
        }

        sb.AppendLine("\t\t]");
        return sb.ToString();
    }

    public override string ToString()
    {
        return $"[\n\tID : {id} , nom : {nom} , prenom : {prenom} , bureau : {bureau} ,consommationTotale : {HistoriqueCafes.Sum(c => c.NbrTasses)} tasses " +
               $"\n\tconsommations :\n\t\t {(consommationDuCafe().Contains("Semaine") ? consommationDuCafe() : "0 consommations pour l'istant")} \n\t]";
    }
}