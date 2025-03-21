using System.ComponentModel.DataAnnotations.Schema;
using CrudDDL.utils;

namespace Project_Example_Using_The_Generic_Crud_DDL;

[Table("Employees")]
public class Employee
{
    private int Id;
    private string Name;
    private string position;

    public Employee(int id, string name, string position)
    {
        ID = id;
        Nom = name;
        Position = position;
    }
    
    public Employee(){}
    
    [PrimaryKey]
    [ColumnName("EmployeeID")]
    public int ID
    {
        get => Id;
        set => Id = value;
    }
    
    [ColumnName("EmployeeName")]
    public string Nom
    {
        get => Name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Nom ne peut pas etre vide !");
            }
            Name = value;
        }
    }
    
    [ColumnName("EmployeePosition")]
    public string Position
    {
        get => position;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Nom ne peut pas etre vide !");
            }
            position = value;
        }
    }

    public override string ToString()
    {
        return $"Employee ID: {ID}, Nom: {Nom}, Position: {Position}";
    }
}