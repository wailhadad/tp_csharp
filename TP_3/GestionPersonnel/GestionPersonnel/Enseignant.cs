using System.Text;

namespace GestionPersonnel.GestionPersonnel;

public class Enseignant : Personnel
{
    public string Grade;
    public int VolumeHoraire;
    public Dictionary<string, List<Etudiant>> groupes;

    public Enseignant(int code, string nom, string prenom, string grade, int volumeHoraire) : base(code, nom, prenom)
    {
        Grade = grade;
        VolumeHoraire = volumeHoraire;
        groupes = new Dictionary<string, List<Etudiant>>();
    }

    public void AjouterGroupe(string nom_grp)
    {
        if (!groupes.ContainsKey(nom_grp))
        {
            groupes.Add(nom_grp, new List<Etudiant>());
        }
        else
        {
            Console.WriteLine("le groupe "+ "\"" + nom_grp + "\"" +" existe déjà.\n");
        }
    }

    public void AjouterEtudiant(string nom_grp, Etudiant etudiant)
    {
        if (groupes.ContainsKey(nom_grp))
        {
            groupes[nom_grp].Add(etudiant);
        }
        else
        {
            Console.WriteLine("le groupe " + "\"" + nom_grp + "\"" + " n'existe pas.\n");
        }
    }
    
    public string AfficherGroupes()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var groupe in groupes)
        {
            sb.Append(groupe.Key + ": ");
            foreach (var etudiant in groupe.Value)
            {
                sb.Append(etudiant + "\n");
            }
        }
        return sb.ToString();
    }

    public override double Calculer_Salaire()
    {
        return Grade switch
        {
            "PA" => VolumeHoraire * 300,
            "PH" => VolumeHoraire * 350,
            "PES" => VolumeHoraire * 400,
            _ => 0
        };
    }

    public List<Etudiant> this[string nom_grp]
    {
        get => groupes.ContainsKey(nom_grp) ? groupes[nom_grp] : null;
    }

    public override string ToString()
    {
        return $"Enseigant #{Code} : {Nom} {Prenom} , grade : {Grade} , volume: {VolumeHoraire} , salaire : {Calculer_Salaire()}\n"
               + "\tAffichage des grps :\n"
               + "\t" + AfficherGroupes();
    }
}