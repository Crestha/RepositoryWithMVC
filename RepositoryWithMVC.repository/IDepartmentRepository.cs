using RepositoryWithMVC.model;
using System.Collections.Generic;

namespace RepositoryWithMVC.repository
{
    public interface IDepartmentRepository 
    {
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartmentId(int departmentId);
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void Save();
    }
}