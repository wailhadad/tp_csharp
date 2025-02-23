namespace Ex_2.Gestion_Bibliotheque;

public abstract class Document
{
    private static int compteur = 1;
    public int NumEnregistrement;
    public string Titre;

    public Document(string titre)
    {
        NumEnregistrement = compteur++;
        Titre = titre ?? throw new ArgumentNullException(nameof(titre),"le titre ne peut pas etre vide.\n");
    }

    public virtual string Description()
    {
        return $"Document #{NumEnregistrement}: {Titre}.\n";
    }
}