using System.Collections.Generic;
using System.Linq;
using RepositoryWithMVC.model;
using System.Data.Entity;

namespace RepositoryWithMVC.repository
{
    public class DepartmentRepository : RepositoryBase<ProjectDBContext>, IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartment()
        {
            return DataContext.Departments.ToList();
        }

        public Department GetDepartmentId(int deparmentId)
        {
            return DataContext.Departments.Find(deparmentId);
        }

        public void InsertDepartment(Department department)
        {
            DataContext.Departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            DataContext.Entry(department).State = EntityState.Modified;
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }

        public void DeleteDepartment(int departmentId)
        {
            Department department = DataContext.Departments.Find(departmentId);
            DataContext.Departments.Remove(department);
        }
    }
}