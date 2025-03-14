using Ex_1.GestionAbsences.DAO;
using Ex_1.GestionAbsences.repository;
using Ex_1.GestionAbsences.service;

namespace Ex_1;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        
        string dbType = "mysql" ;
        string host = "localhost";
        string user = "root" ;
        string password = "";
        string dbName = "eleves_absences_csharp";
        int port = 3306 ;
         
        // Create repositories for Eleve and Absence
        IEleveRepository eleveRepository = new EleveDaoImpl(dbType, host, user, password, dbName, port);
        IAbsenceRepository absenceRepository = new AbsenceDaoImpl(dbType, host, user, password, dbName, port);

        // Create services
        IEleveService eleveService = new EleveService(eleveRepository);
        IAbsenceService absenceService = new AbsenceService(absenceRepository);
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(absenceService, eleveService));
    }
    
    // fais une classe connexion qui établis la connection avec la bd soit oracle soit my sql soit ...
    // établit aussi la fct save qui sert a la fois a l'update insert et une fct delete puis la fct get pour prendre les données
    // données liste ou bien individuelles. donne moi tous les classes nécéssaires et gestion d'exeption et encapsulation
    // avec aussi tout
}