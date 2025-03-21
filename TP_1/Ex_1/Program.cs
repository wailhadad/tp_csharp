// See https://aka.ms/new-console-template for more information
using System;
using Ex_1.fichiers_repertoires;

class Program
{
    internal static void Main(string[] args)
    {
        try
        {
            // 🔹 Création du répertoire
            Repertoire rep = new Repertoire("Mes Documents");

            // 🔹 Ajout de fichiers
            Fichier fichier1 = new Fichier("Cours", ".pdf", 1500);
            Fichier fichier2 = new Fichier("Projet", ".cs", 250);
            Fichier fichier3 = new Fichier("Rapport", ".docx", 800);

            rep.AjouterFichier(fichier1);
            rep.AjouterFichier(fichier2);
            rep.AjouterFichier(fichier3);

            // 🔹 Affichage du répertoire
            Console.WriteLine(rep.Afficher());

            // 🔹 Rechercher un fichier
            string nomRecherche = "Cours";
            int index = rep.Rechercher(nomRecherche);
            Console.WriteLine(index != -1
                ? $"\nFichier '{nomRecherche}' trouvé à l'index {index}."
                : "\nFichier non trouvé.");

            // 🔹 Rechercher par extension
            Console.WriteLine("\nFichiers avec extension .pdf:");
            foreach (var fichier in rep.rechercherParExtension(".pdf"))
            {
                Console.WriteLine(fichier);
            }

            // 🔹 Renommer un fichier
            Console.WriteLine("\nRenommage de 'Projet' en 'CodeCSharp'...");
            rep.renommerFichier("CodeCSharp", fichier2);
            Console.WriteLine(rep.Afficher());

            // 🔹 Modifier la taille d'un fichier
            Console.WriteLine("\nModification de la taille de 'Rapport' à 1200Ko...");
            rep.modifierTailleFichier(1200, fichier3);
            Console.WriteLine(rep.Afficher());

            // 🔹 Supprimer un fichier
            Console.WriteLine("\nSuppression de 'Cours'...");
            rep.SupprimerFichier("Cours");
            Console.WriteLine(rep.Afficher());

            // 🔹 Taille totale du répertoire
            Console.WriteLine($"Taille totale du répertoire : {rep.getTailleMo():F2} Mo");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erreur: {ex.Message}");
        }
    }
}