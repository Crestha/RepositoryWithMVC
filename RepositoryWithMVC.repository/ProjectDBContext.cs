using RepositoryWithMVC.model;
using System.Data.Entity;

namespace RepositoryWithMVC.repository
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
            : base("name=CompanyContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}