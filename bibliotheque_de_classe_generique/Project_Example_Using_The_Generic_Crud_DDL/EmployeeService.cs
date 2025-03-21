using CrudDDL.DAO;

namespace Project_Example_Using_The_Generic_Crud_DDL;

public class EmployeeService : IEmployeeRepository
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeService()
    {
        _employeeRepository = new EmployeeRepository();
    }
    
    public void Add(Employee entity)
    {
        entity.Add();
    }

    public void Update(Employee entity)
    {
        entity.Update();
    }

    public void Delete(Employee entity)
    {
        entity.Delete();
    }

    public List<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }

    public Employee GetById(int id)
    {
        return _employeeRepository.GetById(id);
    }
}