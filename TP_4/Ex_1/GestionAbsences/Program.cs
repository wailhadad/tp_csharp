// using Ex_1.GestionAbsences.DAO;
// using Ex_1.GestionAbsences.entity;
// using Ex_1.GestionAbsences.repository;
// using Ex_1.GestionAbsences.service;
//
// namespace Ex_1.GestionAbsences;
//
// using System;
// using System.Collections.Generic;
//
// class Program
// {
//     static void Main(string[] args)
//     {
//          string dbType = "mysql" ;
//          string host = "localhost";
//          string user = "root" ;
//          string password = "";
//          string dbName = "eleves_absences_csharp";
//          int port = 3306 ;
//          
//          // Create repositories for Eleve and Absence
//          IEleveRepository eleveRepository = new EleveDaoImpl(dbType, host, user, password, dbName, port);
//          IAbsenceRepository absenceRepository = new AbsenceDaoImpl(dbType, host, user, password, dbName, port);
//          
//          // Create services
//          IEleveService eleveService = new EleveService(eleveRepository);
//          IAbsenceService absenceService = new AbsenceService(absenceRepository);
//
//         Console.WriteLine("TESTING ELEVE SERVICE");
//         // Create a new Eleve
//         Eleve eleve = new Eleve(1, "Dupont", "Jean", "GI1");
//         
//         /*Dictionary<string, object> eleve7 = eleve.ToDictionary() ;
//         Console.WriteLine("DICTIONNAIRE §§§");
//         foreach (KeyValuePair<string, object> kvp in eleve7)
//         {
//             Console.WriteLine(kvp.Key + " : " + kvp.Value);
//         }*/
//         
//         Console.WriteLine(eleve);
//         eleveService.AjouterEleve(eleve);
//         Console.WriteLine("Eleve ajoute !");
//
//         // Display all Eleves
//         List<Eleve> eleves = eleveService.AfficherTous();
//         Console.WriteLine("Liste des eleves:");
//         foreach (var e in eleves)
//         {
//             Console.WriteLine(e);
//         }
//
//         // Find Eleve by ID
//         Eleve foundEleve = eleveService.TrouverParId(1);
//         if (foundEleve != null)
//         {
//             Console.WriteLine($"Eleve trouve : {foundEleve}");
//         }
//
//         // Update Eleve
//         foundEleve.Nom = "Martin";
//         eleveService.ModifierEleve(foundEleve);
//         Console.WriteLine($"Eleve mis a jour ! {foundEleve}");
//
//         Console.WriteLine("\nTESTING ABSENCE SERVICE");
//         // Create a new Absence
//         Absence absence = new Absence(4, 1, 2);
//         absenceService.AjouterAbsence(absence);
//         Console.WriteLine("Absence ajoutee !");
//
//         // Display all Absences
//         List<Absence> absences = absenceService.AfficherToutesAbsences();
//         Console.WriteLine("Liste des absences:");
//         foreach (var a in absences)
//         {
//             Console.WriteLine(a);
//         }
//
//         // Find Absence by ID
//         AbsenceId absenceId = new AbsenceId(1,4);
//         Absence foundAbsence = absenceService.TrouverParId(absenceId);
//         if (foundAbsence != null)
//         {
//             Console.WriteLine($"Absence trouvee : {foundAbsence}");
//         }
//         else
//         {
//             Console.WriteLine("Absence introuvable");
//         }
//
//         // Update Absence
//         foundAbsence.NbrAbsences = 3;
//         absenceService.ModifierAbsence(foundAbsence);
//         Console.WriteLine("Absence mise a jour ! " + foundAbsence);
//
//         // Delete Absence
//         absenceService.SupprimerAbsence(absenceId);
//         Console.WriteLine("Absence supprimee !");
//         
//         // Delete Eleve
//         eleveService.SupprimerEleve(1);
//         Console.WriteLine("Eleve supprime !");
//
//     }
//     
// }
