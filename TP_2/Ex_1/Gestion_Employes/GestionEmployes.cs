namespace Ex_1.Gestion_Employes;

public class GestionEmployes
{
    private List<Employee> employees;

    public GestionEmployes()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void PrintEmployees()
    {
        Console.WriteLine("\nAffichage de " + employees.Count + " employees");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }
    }

    public Employee GetEmployee(string name)
    {
        return employees.Find(emp=> emp.Nom == name) ?? throw new KeyNotFoundException("No employee found with this name\n");
    }

    public void RemoveEmployee(Employee employee)
    {
        var emp = GetEmployee(employee.Nom);
        employees.Remove(emp);
        Console.WriteLine($"\nEmployee \"{employee.Nom}\" deleted successfully !\n");
    }
    
    public double GetSumOfSalaries()
    {
        return employees.Sum(emp => emp.Salaire);
    }

    public double GetAverageSalary()
    {
        return employees.Average(emp=>emp.Salaire);
    }
    
    
}