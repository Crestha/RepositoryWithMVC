using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryWithMVC.Models;
using System.Data.Entity;

namespace RepositoryWithMVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository, IDisposable
    {
        private EmployeeContext _db;

        public DepartmentRepository(EmployeeContext context)
        {
            _db = context;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _db.Departments.ToList();
        }

        public Department GetDepartmentId(int deparmentId)
        {
            return _db.Departments.Find(deparmentId);
        }
       
        public void InsertDepartment(Department department)
        {
            _db.Departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void DeleteDepartment(int departmentId)
        {
            Department department = _db.Departments.Find(departmentId);
            _db.Departments.Remove(department);
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