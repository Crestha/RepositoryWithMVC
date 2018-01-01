using RepositoryWithMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryWithMVC.Repository
{
    //Repository class of type "Employee"
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        //DAL(Data Access Layer)
        //The database context is defined in a class variable, and the constructor expects the calling object to pass in an instance of the context:
        private EmployeeContext _db;

        public EmployeeRepository(EmployeeContext context)
        {
            _db = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _db.Employees.Include("Department").ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            //return _db.Employees.Find(employeeId);
            return _db.Employees.Include("Department").Single(e=>e.EmployeeId==employeeId);
        }

        public IEnumerable<Employee> GetEmployeeByDepartment(int? departmentId)
        {
            var employeeeByDepartment = _db.Employees.Include("Department").Where(e => e.DepartmentId == departmentId).ToList();
            return employeeeByDepartment;
        }

        public void InsertEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employees = _db.Employees.Include("Department").Single(emp => emp.EmployeeId == employeeId);
            _db.Employees.Remove(employees);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}