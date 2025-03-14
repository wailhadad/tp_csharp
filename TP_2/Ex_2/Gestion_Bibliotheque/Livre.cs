namespace Ex_2.Gestion_Bibliotheque;

public class Livre : Document
{
    public string Auteur;
    public int NombrePages;

    public Livre(string titre, string auteur, int nombrePages) : base(titre)
    {
        Auteur = auteur ?? throw new ArgumentNullException(nameof(auteur), "l'auteur ne peut pas etre vide.\n");
        NombrePages = nombrePages < 0 ? throw new ArgumentException("le nombre de pages doit etre > 0.\n") : nombrePages;
    }

    public override string Description()
    {
        return $"Livre #{NumEnregistrement}: \"{Titre}\", Auteur: \"{Auteur}\", Nombre de pages: \"{NombrePages}\".\n";
    }
}