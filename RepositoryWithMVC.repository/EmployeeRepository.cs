using RepositoryWithMVC.model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryWithMVC.repository
{
    public class EmployeeRepository : RepositoryBase<ProjectDBContext>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            using (DataContext)
            {
                return DataContext.Employees.Include("Department").ToList();
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return DataContext.Employees.Include("Department").Single(e => e.EmployeeId == employeeId);
        }

        public IEnumerable<Employee> GetEmployeeByDepartment(int? departmentId)
        {
            var employeeeByDepartment = DataContext.Employees.Include("Department").Where(e => e.DepartmentId == departmentId).ToList();
            return employeeeByDepartment;
        }

        public void InsertEmployee(Employee employee)
        {
            DataContext.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            DataContext.Entry(employee).State = EntityState.Modified;
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employees = DataContext.Employees.Include("Department").Single(emp => emp.EmployeeId == employeeId);
            DataContext.Employees.Remove(employees);
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }
    }
}