using System;
using CrudDDL.DAO;
using CrudDDL.repository;
using CrudDDL.utils;
using DotNetEnv;

namespace Project_Example_Using_The_Generic_Crud_DDL;

public class Program1
{
    public static void Main(string[] args)
    {
        string absolutePath = Directory.GetCurrentDirectory();
        string dotEnvPath = Directory.GetParent(absolutePath)?.Parent.Parent.FullName + "\\.env";
        
        Env.Load(dotEnvPath);
        
        string dbType   = Env.GetString("DB_TYPE");
        string host     = Env.GetString("DB_HOST");
        string user     = Env.GetString("DB_USER"); 
        string password = Env.GetString("DB_PASSWORD");
        string dbName   = Env.GetString("DB_NAME");
        int    port     = Env.GetInt   ("DB_PORT");
        
        Console.WriteLine($"DB Type: {dbType}");
        Console.WriteLine($"DB Host: {host}");
        Console.WriteLine($"DB User: {user}");
        Console.WriteLine($"DB Password: {password}");
        Console.WriteLine($"DB DB Name: {dbName}");
        Console.WriteLine($"DB Port: {port}");
        
        DbConnexionManager.GetConnection(dbType, host, user, password, dbName, port);
        EmployeeService employeeService = new EmployeeService();
        
        Employee employee = new Employee(1, "John Doe", "Janitor");
        employeeService.Add(employee);

        // ICrudRepository<Employee, int> empRepository = new DAO_Generique<Employee, int>();
        // empRepository.Add(employee);
        
        Employee employee2 = new Employee(2, "Mary Smith", "Mary Smith");
        employeeService.Add(employee2);
        
        Employee employee2Updated = new Employee(2, "WAIL HADAD", "Professor");
        employeeService.Update(employee2Updated);
        
        foreach (Employee emp in employeeService.GetAll())
        {
            Console.WriteLine(emp);
        }
        
        Console.WriteLine("Enter l'ID de l'employee a chercher:");
        Console.Write($"Employee Recherche:"); 
        Console.WriteLine($"{employeeService.GetById(int.Parse(Console.ReadLine()))}");
        
        employeeService.Delete(employee);
        Console.WriteLine($"Nouvelle Liste d'employee apres suppression de l'employee No# {employee.ID}");
        foreach (Employee emp in employeeService.GetAll())
        {
            Console.WriteLine(emp);
        }

    }
}