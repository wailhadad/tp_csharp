using CrudDDL.repository;

namespace Project_Example_Using_The_Generic_Crud_DDL;

public interface IEmployeeRepository : ICrudRepository<Employee, int> { }