using RepositoryWithMVC.model;
using System.Collections.Generic;

namespace RepositoryWithMVC.repository
{
    //Repository Interface of type "Employee"
    public interface IEmployeeRepository 
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        IEnumerable<Employee> GetEmployeeByDepartment(int? departmentId);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void Save();
    }
}

/*Repository Pattern is used to create an abstraction layer between data access layer and business logic layer of an application. 
 * Repository directly communicates with data access layer [DAL] and gets the data and provides it to business logic layer [BAL]. 
 * The main advantage to use repository pattern to isolate the data access logic and business logic, so that if you make changes in any of this logic that cannot effect directly on other logic.
 * Implementing these patterns can help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development (TDD).
 * 
 * Non-Repository: Direct Access to Database Context from Controller
 * With Repository: Abstraction layer between Controller and Database Context
 */
