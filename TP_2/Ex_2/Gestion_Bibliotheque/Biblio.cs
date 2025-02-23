namespace Ex_2.Gestion_Bibliotheque;

public class Biblio
{
    private List<Document> documents;

    public Biblio()
    {
        documents = new List<Document>();
    }

    public void AddDocument(Document document)
    {
        documents.Add(document);
    }

    public void RemoveDocument(Document document)
    {
        documents.Remove(document);
    }

    public int NombreLivres()
    {
        return documents.Count(d=> d is Livre);
    }

    public void AfficherLivres()
    {
        var livres = documents.Where(d => d is Livre);
        if (!livres.Any())
        {
            Console.WriteLine("Aucun livre n'est trouve.\n");
            return;
        }
        Console.WriteLine("Affichage des livres:\n");
        foreach (var livre in livres)
        {
            Console.WriteLine(livre.Description());
        }
    }

    public void AfficherDictionnaires()
    {
        var dictionnaires = documents.Where(d => d is Dictionnaire);
        if (!dictionnaires.Any())
        {
            Console.WriteLine("Aucun dictionnaire n'est trouve.\n");
            return;
        }
        Console.WriteLine("Affichage dictionnaires:\n");
        foreach (var dictionnaire in dictionnaires)
        {
            Console.WriteLine(dictionnaire.Description());
        }
    }

    public void AfficherAuteurs()
    {
        var livres = documents.OfType<Livre>();
        if (!livres.Any())
        {
            Console.WriteLine("Aucun livre n'est trouve.\n");
            return;
        }
        Console.WriteLine("Affichage des auteurs des livres:\n");
        foreach (var livre in livres)
        {
            Console.WriteLine($"Livre #{livre.NumEnregistrement} : Auteur: {livre.Auteur}.\n");
        }
    }

    public void DocumentsDescription()
    {
        if (!documents.Any())
        {
            Console.WriteLine("Aucun document n'est trouve.\n");
            return;
        }
        Console.WriteLine("Affichage des documents:\n");
        foreach (var document in documents)
        {
            Console.WriteLine(document.Description());
        }
    }
}