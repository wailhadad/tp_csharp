namespace Ex_2.Gestion_Bibliotheque;

public class Dictionnaire : Document
{
    public string Langue;
    public int NombreDefinitions;

    public Dictionnaire(string titre, string langue, int nombreDefinitions) : base(titre)
    {
        Langue = langue ?? throw new ArgumentNullException(nameof(langue),"la langue ne peut pas etre vide.\n");
        NombreDefinitions = nombreDefinitions < 0 ? throw new ArgumentOutOfRangeException(nameof(nombreDefinitions),"le ombre de definitions doit etre > 0.\n") :nombreDefinitions;
    }

    public override string Description()
    {
        return $"Dictionnaire #{NumEnregistrement}: \"{Titre}\", Langue: \"{Langue}\", Nombre de definitions: \"{NombreDefinitions}\".\n";
    }
}