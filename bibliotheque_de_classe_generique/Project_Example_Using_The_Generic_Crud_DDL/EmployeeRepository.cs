using CrudDDL.DAO;

namespace Project_Example_Using_The_Generic_Crud_DDL;

public class EmployeeRepository : DAO_Generique<Employee,int>, IEmployeeRepository { }