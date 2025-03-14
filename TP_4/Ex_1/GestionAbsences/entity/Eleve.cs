using System.Text;

namespace Ex_1.GestionAbsences.entity;

public class Eleve
{
    private int id;
    private string nom;
    private string prenom;
    private string groupe;

    public Eleve(int id, string nom, string prenom, string groupe)
    {
        ID = id;
        Nom = nom;
        Prenom = prenom;
        Groupe = groupe;
    }
    
    public int ID { 
        get => id; 
        set
        { 
            if(value < 0) throw new ArgumentException("ID must be positive");
            id = value;
        } 
    }

    public string Nom
    {
        get => nom;
        set
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentException("Nom cannot be empty");
            nom = value;
        }
    }

    public string Prenom
    {
        get => prenom;
        set
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentException("Prenom cannot be empty");
            prenom = value;
        }
    }

    public string Groupe
    {
        get => groupe;
        set
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentException("Groupe cannot be empty");
            groupe = value;
        }
    }

    public override string ToString()
    {
        return $"Eleve #{ID} : Nom : {Nom} {Prenom}, Groupe : {Groupe}\n";
    }

    public string AfficherEleve()
    {
        StringBuilder sb = new StringBuilder();
        Dictionary<string,object> dict = this.ToDictionary();
        foreach (KeyValuePair<string, object> kvp in dict)
        {
            sb.Append($"{kvp.Key} - {kvp.Value}\n");
        }
        return sb.ToString();
    }
    
}
