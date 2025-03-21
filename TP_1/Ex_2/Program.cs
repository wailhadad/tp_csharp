using System;
using Ex_2.CoffeeTracker;

class Program
{
    static void Main()
    {
        Console.WriteLine("Initialisation du projet...");
        Projet projet = new Projet("P456", "Développement Web", 5);

        // 🔹 Ajouter des programmeurs
        projet.AddProgrammeur(new Programmeur("1", "Regnier", "Patrick", "205"));
        projet.AddProgrammeur(new Programmeur("2", "Favre", "Jean-Marie", "566"));
        projet.AddProgrammeur(new Programmeur("3", "Scholl", "Pierre-Claude", "123"));

        // 🔹 Afficher tous les programmeurs
        Console.WriteLine(projet.AfficherListProgrammeurs());

        // 🔹 Ajouter consommation de café
        projet.AjouterConsommation(new ConsommationCafe(4, 1, "Regnier"), "1");
        projet.AjouterConsommation(new ConsommationCafe(3, 1, "Favre"), "2");
        projet.AjouterConsommation(new ConsommationCafe(6, 1, "Scholl"), "3");
        projet.AjouterConsommation(new ConsommationCafe(7, 2, "Regnier"), "1");
        projet.AjouterConsommation(new ConsommationCafe(5, 2, "Scholl"), "3");
        projet.AjouterConsommation(new ConsommationCafe(4, 2, "Favre"), "2");

        // 🔹 Afficher consommation de café pour chaque programmeur
        Console.WriteLine("\nConsommation totale de café par programmeur :");
        projet.AfficherProgrammeur("1");
        projet.AfficherProgrammeur("2");
        projet.AfficherProgrammeur("3");

        // 🔹 Afficher consommation de café pour une semaine spécifique
        Console.WriteLine("\nConsommation de café pour la semaine 1:");
        projet.AfficheConsommationParSemaine(1);

        Console.WriteLine("\nConsommation de café pour la semaine 2:");
        projet.AfficheConsommationParSemaine(2);

        // 🔹 Supprimer un programmeur
        Console.WriteLine("\nSuppression du programmeur 'Favre'");
        projet.RemoveProgrammeur("2");

        // 🔹 Afficher tous les programmeurs après suppression
        Console.WriteLine("\nListe des programmeurs après suppression:");
        Console.WriteLine(projet.AfficherListProgrammeurs());

        // 🔹 Affichage final des infos du projet
        Console.WriteLine("\nDétails du projet:");
        Console.WriteLine(projet.ToString());
    }
}
