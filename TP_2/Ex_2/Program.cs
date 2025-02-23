// See https://aka.ms/new-console-template for more information

using Ex_2.Gestion_Bibliotheque;

class Program
{
    static void Main(string[] args)
    {
        Biblio bibliotheque = new Biblio();

        Livre livre1 = new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 120);
        Livre livre2 = new Livre("1984", "George Orwell", 328);
        
        Document document1 = new Dictionnaire("Oxford Dictionary", "Anglais", 60000);
        Document document2 = new Dictionnaire("Oxford Dictionary", "Anglais", 60000);
        
        // Ajout de documents
        bibliotheque.AddDocument(livre1);
        bibliotheque.AddDocument(livre2);
        bibliotheque.AddDocument(document1);
        bibliotheque.AddDocument(document2);

        // Affichage des documents
        bibliotheque.DocumentsDescription();

        // Affichage des livres et dictionnaires
        Console.WriteLine($"\nNombre de livres : {bibliotheque.NombreLivres()}");
        bibliotheque.AfficherDictionnaires();
            
        // Liste des auteurs
        bibliotheque.AfficherAuteurs();
    }
}