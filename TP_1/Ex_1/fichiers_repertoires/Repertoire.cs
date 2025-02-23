using System.Text;

namespace Ex_1.fichiers_repertoires;

public class Repertoire
{
    private String nom;
    private List<Fichier> fichiers;

    public Repertoire(String nom)
    {
        Nom = nom;
        fichiers = new List<Fichier>();
    }
    
    public int nbr_fichiers => fichiers.Count; // Read-only property

    public String Nom
    {
        get { return nom; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Nom n'est obligatoire\n");
            }

            if (value.Length > 255)
            {
                throw new ArgumentException("Taille max doit etre 255\n");
            }
            nom = value;
        }
    }

    public String Afficher()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[\nNom du Repertoire : \n" + nom + "\n");
        for (var i = 0; i < fichiers.Count; i++)
        {
            sb.Append("Fichier " + (i+1) + "\n");
            sb.Append("\t" + fichiers[i].ToString() + "\n");
        }
        sb.Append("]");
        return sb.ToString();
    }

    public int Rechercher(String nomFichier)
    {
        for (var i = 0; i < fichiers.Count; i++)
        {
            if (fichiers[i].Nom.Equals(nomFichier)) return i;
        }
        return -1;
    }

    public void AjouterFichier(Fichier fichier)
    {
        fichiers.Add(fichier);
    }

    public void SupprimerFichier(String nomFichier)
    {
        Fichier fichierToDelete = fichiers.Find(f => f.Nom.Equals(nomFichier)) ?? throw new InvalidOperationException();
        fichiers.Remove(fichierToDelete);
        
        //OR
        // fichiers.Remove(fichiers[Rechercher(nomFichier)]);
    }

    public List<Fichier> rechercherParExtension(String extension)
    {
        List<Fichier> fichiersOfExtension = new List<Fichier>();
        foreach (var fichier in fichiers)
        {
            if (fichier.Extension.Equals(extension, StringComparison.CurrentCultureIgnoreCase))
            {
                fichiersOfExtension.Add(fichier);
            }
        }
        return fichiersOfExtension;
    }

    public void renommerFichier(String nouveauNomFichier, Fichier fichier)
    {
        fichier.Nom = nouveauNomFichier;
    }

    public void modifierTailleFichier(int nouvelleTaille, Fichier fichier)
    {
        fichier.Taille = nouvelleTaille;
    }

    public float getTailleMo()
    {
        return fichiers.Sum(f => f.Taille)/1024;
    }
}