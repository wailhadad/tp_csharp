namespace Ex_1.Gestion_Employes;

public class Directeur
{
    private static Directeur instance;
    private GestionEmployes gestionEmployes;

    private Directeur()
    {
        GestionEmployes = new GestionEmployes();
    }
    
    public GestionEmployes GestionEmployes { get => gestionEmployes; set => gestionEmployes = value; }

    public static Directeur GetInstance()
    {
        if(instance == null) instance = new Directeur();
        return instance;
    }

    public void InfosEntreprise()
    {
        Console.WriteLine("\n===== Informations de l'entreprise =====");
        Console.WriteLine($"Salaire total de l'entreprise : {GestionEmployes.GetSumOfSalaries()} $");
        Console.WriteLine($"Salaire moyen : {GestionEmployes.GetAverageSalary():F2} $");
        GestionEmployes.PrintEmployees();
        
    }

    public void AddEmployee(Employee employee)
    {
        GestionEmployes.AddEmployee(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        GestionEmployes.RemoveEmployee(employee);
    }

    public Employee GetEmployee(string name)
    {
        return GestionEmployes.GetEmployee(name);
    }
    
}