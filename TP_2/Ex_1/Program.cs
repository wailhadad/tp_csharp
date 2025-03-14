using System;
using Ex_1.Gestion_Employes;

class Program
{
    static void Main()
    {
        // Création du gestionnaire d'employés
        GestionEmployes gestionEmployes = new GestionEmployes();

        Employee emp1 = new Employee("Alice Dupont", 3500, "Développeur", new DateTime(2022, 3, 15));
        Employee emp2 = new Employee("Jean Durand", 4200, "Chef de projet", new DateTime(2020, 6, 20));
        Employee emp3 = new Employee("Marie Curie", 5000, "Scientifique", new DateTime(2018, 11, 5));
        // Ajout de quelques employés
        gestionEmployes.AddEmployee(emp1);
        gestionEmployes.AddEmployee(emp2);
        gestionEmployes.AddEmployee(emp3);

        // Obtention de l'instance unique du directeur
        Directeur directeur = Directeur.GetInstance();
        directeur.GestionEmployes = gestionEmployes;

        // Affichage des informations de l'entreprise
        directeur.InfosEntreprise();

        // Suppression d'un employé
        directeur.RemoveEmployee(emp2);

        // Affichage mis à jour
        directeur.InfosEntreprise();
        
        //Affichage d'un employee par Nom
        Console.WriteLine($"voici les infos de l'employee au nom \"Marie Curie\" :\n{directeur.GetEmployee("Marie Curie")}");
    }
}