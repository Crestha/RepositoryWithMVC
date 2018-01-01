using RepositoryWithMVC.Models;
using System;
using System.Collections.Generic;

namespace RepositoryWithMVC.Repository
{
    public interface IDepartmentRepository: IDisposable
    {
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartmentId(int departmentId);
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void Save();
    }
}